using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Services;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Pages
{
    public class ItemModel : PageModel
    {
        public string Message { get; set; }

        public MenuItem Item { get; set; }

        public void OnGet(int id)
        {
            var menuService = new MenuService();
            Item = menuService.GetMenuItems().FirstOrDefault(x => x.Id == id);

        }
    }
}
