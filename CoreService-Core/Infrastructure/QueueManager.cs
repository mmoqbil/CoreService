using CoreService_Core.Model.Dto;
using CoreService_Core.Service;
using CoreService_Core.Service.Interface;

namespace CoreService_Core.Infrastructure;

public class QueueManager : IQueueManager
{
    private readonly IResponseService _responseService;
    private ResponseErrorEmail _errorEmail;
    private const int SecondsPerAction = 60;

    public QueueManager(IResponseService responseService)
    {
        _responseService = responseService ?? throw new ArgumentNullException(nameof(responseService));
        _errorEmail = new ResponseErrorEmail();
    }

    public async Task<List<ResourceDto>> CheckAllAvailableResources(IEnumerable<ResourceDto>? resourceList, HttpClient client, ILogger<Worker> logger)
    {
        var availableResources = new List<ResourceDto>();

        if (resourceList == null)
        {
            return availableResources;
        }

        foreach (var resource in resourceList)
        {
            if (resource.TimeLeft <= TimeSpan.Zero)
            {
                resource.TimeLeft = resource.Refresh;
                var result = await GetHttpResponseMessageAsync(client, resource, logger);

                if (result == null)
                {
                    continue;
                }

                if (result.IsSuccessStatusCode)
                {
                    logger.LogInformation("[{status}]The status code was: {statusCode}, time: {time}, name: {name}", "SUCCESS", result.StatusCode, DateTime.Now, resource.Name);
                    await _responseService.CreateResponseHandler(result.StatusCode, resource);
                }

                else
                {
                    logger.LogError("[{status}]The website is down. status code {statusCode}", "SUCCESS", result.StatusCode);
                    _errorEmail.SendEmailWithError(result.StatusCode, resource.Name);
                }
            }

            logger.LogInformation("[{status}] Resource {name} was skipped, left time to refresh: {timeLeft}", "SKIP", resource.Name, resource.TimeLeft);

            resource.TimeLeft -= TimeSpan.FromSeconds(SecondsPerAction);
            availableResources.Add(resource);

        }
        logger.LogInformation("End loop");
        return availableResources;
    }


    private async Task<HttpResponseMessage?> GetHttpResponseMessageAsync(HttpClient client, ResourceDto resource, ILogger logger)
    {
        try
        {
            var result = await client.GetAsync(resource.UrlAdress);
            return result;
        }

        catch (UriFormatException exception)
        {
            logger.LogError(
                "[{status}] An UriFormatException has occurred: the UrlAdress parameter value is an invalid URL. Please check if the parameter value is correctly formatted.",
                "FAIL");

            await _responseService.CreateResponseHandlerWithErrorMessage(resource, exception.Message);
            return null;
        }

        catch (HttpRequestException exception)
        {
            logger.LogError("[{status}] An HttpRequestException has occurred while retrieving the resource from the URL {Url}: {Message}.", "FAIL", resource.UrlAdress, exception.Message);

            await _responseService.CreateResponseHandlerWithErrorMessage(resource, exception.Message);
            return null;
        }
        catch (Exception exception)
        {
            logger.LogError("[{status}] Unexpected error, error message: {Message}", "FAIL", exception.Message);

            await _responseService.CreateResponseHandlerWithErrorMessage(resource, exception.Message);
            return null
        }

    }
}