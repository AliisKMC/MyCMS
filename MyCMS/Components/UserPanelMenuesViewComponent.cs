using Microsoft.AspNetCore.Mvc;

namespace MyCMS.Components
{
    public class UserPanelMenuesViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
