using System.Net;


namespace CoreService_Core.Service.Interface
{
    public interface IResponseErrorEmail
    {
        public void SendEmailWithError(HttpStatusCode statusCode, string serviceName);
    }
}
