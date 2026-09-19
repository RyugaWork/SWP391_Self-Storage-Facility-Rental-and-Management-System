using BackendAPI.Controllers;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace BackendAPI.Utils.Email {
    public class EmailProvider: IEmailSender {

        private readonly ILogger<EmailProvider> _logger;

        public EmailProvider(ILogger<EmailProvider> logger) {
            _logger = logger;
        }

        /// <summary>
        /// Send mail to email with subject and message
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message) {
            SmtpClient client = new SmtpClient {
                Port = 587,
                Host = "smtp.gmail.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("codewithgao@gmail.com", "asxm yjlc njjb nnou\r\n")
            };

            _logger.LogInformation(client.ToString());

            return client.SendMailAsync("codewithgao@gmail.com", email, subject, message);
        }
    }
}
