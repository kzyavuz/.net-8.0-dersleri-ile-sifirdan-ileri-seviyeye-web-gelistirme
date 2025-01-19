using Microsoft.AspNetCore.Mvc;

public class CreateDataViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string actionUrl, string buttonText)
    {
        ViewData["ActionUrl"] = actionUrl;
        ViewData["ButtonText"] = buttonText;
        return View();
    }
}
