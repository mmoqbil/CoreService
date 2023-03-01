using AutoMapper;
using CoreService_Core.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace CoreService_Core.Infrastructure
{
    internal class QueueManager
    {
        private readonly IMapper _mapper;
        
        public QueueManager()
        {
            
        }

        public async Task<List<ResourceDto>> checkallavailableresources(List<ResourceDto> resourceList, HttpClient client, ILogger<Worker> logger)
        {
            List<ResourceDto> availableresources = new List<ResourceDto>();
            foreach (var resource in resourceList)
            {
                if (resource.TimeLeft <= TimeSpan.Zero)
                {
                    resource.TimeLeft = resource.Refresh;
                    availableresources.Add(resource);
                    var result = await client.GetAsync(resource.UrlAdress);
                    if (result.IsSuccessStatusCode)
                    {
                        logger.LogInformation("the status code was: {statuscode}, time: {time}, name: {name}", result.StatusCode, DateTime.Now, resource.Name);
                    }
                    else
                    {
                        logger.LogError("the website is down. status code {statuscode}", result.StatusCode);
                        SendEmailWithError(result.StatusCode,resource.Name);
                    }
                }
                else
                {
                    resource.TimeLeft -= TimeSpan.FromSeconds(60);
                }
            }
            return availableresources;
        }
        public void SendEmailWithError(HttpStatusCode statusCode, string serviceName)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("coreserviceinfo@gmail.com");
            message.To.Add(new MailAddress("adres@uzytkownika.com"));
            message.Subject = "Error with service" + serviceName;
            message.Body = "There is in service: " + serviceName + " With this error: " + statusCode;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("coreserviceinfo@gmail.com", "Coreservice123");
            client.Send(message);
        }
    }
}
