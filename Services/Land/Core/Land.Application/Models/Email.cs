using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;

namespace Merchandising.Application.Models
{
    public class Email
    {
        public List<MailboxAddress> To { get; set; }
        public List<MailboxAddress> CC { get; set; }
        public List<MailboxAddress> BCC { get; set; }
        public string Subject { get; set; }  
        public string Content { get; set; }
         
        public IFormFileCollection Attachments { get; set; }

        
    }
}
