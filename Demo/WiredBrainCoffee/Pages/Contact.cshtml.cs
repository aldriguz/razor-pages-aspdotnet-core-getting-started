using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public string Message { get; set; }
        
        public void OnGet()
        {
            Message = "Your contact page.";
        }

        public void OnPost(Contact contact)
        {
            if (ModelState.IsValid)
            {
                EmailService.SendEmail(Contact);
                Message = "Your message has been sent.";
            }
        }

        public void OnPostSubscribe(string subscribeEmail)
        {
            EmailService.SendEmail(subscribeEmail);
            Message = "You are suscribe now, thanks!";
        }
    }
}
