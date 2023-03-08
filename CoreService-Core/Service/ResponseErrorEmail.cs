using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Service.Interface;

namespace CoreService_Core.Service
{
    public class ResponseErrorEmail : IResponseErrorEmail
    {
        public void SendEmailWithError(HttpStatusCode statusCode, string serviceName)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("coreserviceinfo@gmail.com");
            message.To.Add(new MailAddress("mateuszmoqbil@gmail.com"));
            message.Subject = "Error with service " + serviceName;
            message.Body = "There is in service: " + serviceName + " With this error: " + statusCode;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("coreserviceinfo@gmail.com", "fgnavpgprpgzjyew");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Send(message);
            
        }
    }
}
