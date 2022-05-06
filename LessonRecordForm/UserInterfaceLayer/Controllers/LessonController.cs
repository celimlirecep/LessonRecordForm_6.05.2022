using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterfaceLayer.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _repo;
        public LessonController(ILessonRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            _repo.Add(lesson);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_repo.GetSingle(id));
        }
        [HttpPost]
        public IActionResult Edit(Lesson lesson)
        {
            _repo.Update(lesson);
            return RedirectToAction("Index");
        }
    }
}
