using Microsoft.Extensions.Options;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;


namespace RestaurantAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private IHostEnvironment hostEnvironment;

        public EmailService(IOptions<EmailSettings> emailSettings, IHostEnvironment _hostEnvironment)
        {
            _emailSettings = emailSettings.Value;
            this.hostEnvironment = _hostEnvironment;
        }

        public void SendEmailAsync(string to, string username)
        {
            string subject = "Welcome to ASHFOOD";

            string basePath = hostEnvironment.ContentRootPath;
            string htmlPath = Path.Combine(basePath, "EmailTemplates", "WelcomeTemplate.html");
            string logo = Path.Combine(basePath, "EmailTemplates", "logo.png");


            string htmlContent = File.ReadAllText(htmlPath);
            htmlContent = htmlContent.Replace("[Username]", username);
            htmlContent = htmlContent.Replace("logo.png", logo);


            using (var message = new MailMessage())
            {
                message.From = new MailAddress(_emailSettings.MailFrom, _emailSettings.MailFromName);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = htmlContent;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    client.EnableSsl = _emailSettings.EnableSsl;
                    client.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);

                    client.Send(message);
                }
            }
        }
    }


}

