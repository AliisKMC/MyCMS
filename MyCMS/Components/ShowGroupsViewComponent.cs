using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCMS.DataAccess.Data;

namespace MyCMS.Components
{
    public class ShowGroupsViewComponent:ViewComponent
    {
        private readonly MyDbContext _context;
        public ShowGroupsViewComponent(MyDbContext context)
        {
            _context = context;            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groups = _context.PageGroups.ToList();
            return View(groups);
        }
    }
}
