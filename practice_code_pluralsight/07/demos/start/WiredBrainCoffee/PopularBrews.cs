using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee
{
    public class PopularBrews : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var menu = new MenuService();
            return View(menu.GetPopularItems().Take(count));
        }
    }
}
