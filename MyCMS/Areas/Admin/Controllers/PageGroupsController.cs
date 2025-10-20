using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCMS.DataAccess.Data;
using MyCMS.Models.Model;

namespace MyCMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PageGroupsController : Controller
    {
        private readonly MyDbContext _context;

        public PageGroupsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PageGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.PageGroups.ToListAsync());
        }

        // GET: Admin/PageGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupTitle,Id,CreateDate,ModifiedDate,IsDelete")] PageGroup pageGroup)
        {
           if (ModelState.IsValid)
            {
                pageGroup.CreateDate = DateTime.Now;
                pageGroup.IsDelete = false;
                _context.Add(pageGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups.FindAsync(id);
            if (pageGroup == null)
            {
                return NotFound();
            }
            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupTitle,Id,CreateDate,ModifiedDate,IsDelete")] PageGroup pageGroup)
        {
            if (id != pageGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pageGroup.ModifiedDate = DateTime.Now;
                    _context.Update(pageGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageGroupExists(pageGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        public IActionResult Delete(int id)
        {
            var group = _context.PageGroups.IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            _context.PageGroups.Remove(group);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool PageGroupExists(int id)
        {
            return _context.PageGroups.Any(e => e.Id == id);
        }
    }
}
