using Microsoft.Extensions.Configuration;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class MailService : IMailService
    {
        private readonly IConfiguration config;

        public MailService(IConfiguration config)
        {
            this.config = config;
        }
        public async Task SendMessageAsync(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(to) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                throw new ArgumentNullException("One or more message parameters are null or empty.");
            }

            MailMessage mail = new();
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body= body;
            mail.From=new("rentacarsystemproject@gmail.com","Rent A Car Project",System.Text.Encoding.UTF8);
            mail.IsBodyHtml = true;
            mail.BodyEncoding= Encoding.UTF8;

            SmtpClient smtp = new();
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential(config.GetSection("EmailUsername").Value, config.GetSection("EmailPassword").Value);
            smtp.Credentials = new NetworkCredential("rentacarsystemproject@gmail.com", "dutdbtbjepczzhor");
            smtp.Port = 587;

            //smtp.Host = config.GetSection("EmailHost").Value;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl= true;
            await smtp.SendMailAsync(mail);

           
        }
    }
}
