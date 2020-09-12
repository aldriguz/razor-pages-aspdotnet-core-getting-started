using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Pages
{
    public class ContactModel : PageModel
    {
        public Contact Contact { get; set; }

        public void OnGet()
        {

        }
    }
}
