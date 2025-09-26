using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCMS.DataAccess.Data;
using MyCMS.DataAccess.Services;
using MyCMS.Models.Model;
using MyCMS.Utilities.Security;

namespace MyCMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index(int pageId = 1, int pageSize = 3)
        {
            var list = _UserService.GetAllUsers(pageId, pageSize);
            ViewBag.PageCount = _UserService.PageCount(pageSize);
            ViewBag.PageId = pageId;
            return View(list);
        } 

        public IActionResult Search(string param)
        {
            var FindList=_UserService.GetAllUsers(param).ToList();
            return View("Index",FindList);
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _UserService.GetById(id);                
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,Email,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsDelete = false;
                user.CreateDate = DateTime.Now;
                user.Password = PasswordHasher.HashPassword(user.Password);
                _UserService.Add(user);                               
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _UserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserName,Password,Email,IsAdmin,Id,CreateDate,ModifiedDate,IsDelete")] User user)
        {

            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                user.ModifiedDate = DateTime.Now;
                _UserService.Update(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _UserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = _UserService.GetById(id);
            if (user != null)
            {
                //userRepository.DeleteUser(user);
                user.IsDelete = true;
                _UserService.Update(user);
            }
            return RedirectToAction(nameof(Index));
        }        
    }
}
