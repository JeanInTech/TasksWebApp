using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.Models;


namespace ToDoApp.Controllers
{
    [Authorize]
    public class TaskListController : Controller
    { 
        private readonly TaskListDbContext _db;
        public TaskListController(TaskListDbContext db)
        {
            _db = db;
        }
        public IActionResult TaskList()
        {
            string userId = FindUser();
            TempData["User"] = userId;
            List<ToDo> TaskList = _db.ToDo.ToList();
            return View(TaskList);
        }
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTask(ToDo td)
        {
            if (ModelState.IsValid)
            {
                string userId = FindUser();
                td.UserId = userId;
                _db.ToDo.Add(td);
                _db.SaveChanges();
            }

            return RedirectToAction("TaskList");
        }
        [HttpGet]
        public IActionResult UpdateTask(int Id)
        {
            ToDo td = _db.ToDo.Find(Id);
            return View(td);
        }
        [HttpPost]
        public IActionResult UpdateTask(ToDo td)
        {
            if (ModelState.IsValid)
            {
                _db.Update(td);
                _db.SaveChanges();
            }
            return RedirectToAction("TaskList");
        }
        public IActionResult DeleteTask(int Id)
        {
            ToDo td = _db.ToDo.Find(Id);
            return View(td);
        }
        [HttpPost]
        public IActionResult DeleteTask(ToDo td)
        {
            _db.ToDo.Remove(td);
            _db.SaveChanges();
            return RedirectToAction("TaskList");
        }
        public IActionResult MarkAsCompleted(int Id)
        {
            ToDo td = _db.ToDo.Find(Id);
            td.Completed = true;
            _db.Update(td);
            _db.SaveChanges();
            return RedirectToAction("TaskList");
        }

        public string FindUser()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            return userId;
        }
    }
}
