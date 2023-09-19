using MailKit.Net.Smtp;
using Merchandising.Application.Contracts.Infrastructure.Mail;
using Merchandising.Application.Models;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandising.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        
        public ILogger<EmailService> _logger { get; }

        public EmailService( ILogger<EmailService> logger)
        {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

       

        public async Task SendEmailAsync(Email email,EmailSettings emailSettings,string fileNameWithPath)
        {
            var mailMessage = CreateEmailMessage(email,emailSettings, fileNameWithPath);
            await SendAsync(mailMessage,emailSettings);
        }

        private async Task SendAsync(MimeMessage mailMessage, EmailSettings emailSettings)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                   await client.ConnectAsync("mail.hameemgroup.com", 465, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                     await client.AuthenticateAsync(emailSettings.FromName, emailSettings.Password);
                    //client.Authenticate("homayun.it", "Nu%Ha5!Mk@7");
                    await client.SendAsync(mailMessage);

                }
                catch
                {
                    
                    throw;
                }
                finally
                {
                   await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(Email email, EmailSettings emailSettings, string fileNameWithPath)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailSettings.FromAddress));
            emailMessage.To.AddRange(email.To);
            emailMessage.Cc.AddRange(email.CC);
            emailMessage.Bcc.AddRange(email.BCC);
            emailMessage.Bcc.Add(new MailboxAddress(emailSettings.FromAddress));
            emailMessage.Subject = email.Subject;
              var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = email.Content;

            if (email.Attachments != null && email.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in email.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }
            if(fileNameWithPath != null)
            {
                var fileName = Path.GetFileName(fileNameWithPath);
                byte[] fileBytes = File.ReadAllBytes(fileNameWithPath);
                string mimeType = MimeTypes.GetMimeType(fileName);

                bodyBuilder.Attachments.Add(fileName, fileBytes, ContentType.Parse(mimeType));
               
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
    }
}
