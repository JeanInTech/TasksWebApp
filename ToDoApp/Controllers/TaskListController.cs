using Microsoft.AspNetCore.Authorization;
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
        //userManager.GetUserName(HttpContext.User)
        private readonly TaskListDbContext _db;
        public TaskListController(TaskListDbContext db)
        {
            _db = db;
        }
        public IActionResult TaskList()
        {
            List<ToDo> TaskList = _db.ToDo.ToList();
            AspNetUsers c = userManager.GetUserName(HttpContext.User);
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
    }
}
