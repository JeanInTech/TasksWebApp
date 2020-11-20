using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<ToDo> TaskList = _db.ToDo.ToList();
            return View(TaskList);
        }
        public IActionResult CreateTask()
        {
            return View();
        }
    }
}
