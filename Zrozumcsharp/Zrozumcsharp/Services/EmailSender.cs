using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zrozumcsharp.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"[EMAIL TO] {email}");
            Console.WriteLine($"[EMAIL Subject] {subject}");
            Console.WriteLine($"[EMAIL TO] {htmlMessage}");
            
            await Task.CompletedTask;
        }
    }
}
