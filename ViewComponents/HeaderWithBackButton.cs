using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace efcoreApp.ViewComponents
{
    public class HeaderWithBackButton: ViewComponent
    {
        public IViewComponentResult Invoke(string pageTitle)
        {
            ViewData["PageTitle"] = pageTitle;
            return View();
        }
    }
}
 