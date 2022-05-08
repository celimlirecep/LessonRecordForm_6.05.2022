using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserInterfaceLayer.Models;

namespace UserInterfaceLayer.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _repo;
        private readonly LessonRecordFormContext _context;
        public LessonController(ILessonRepository repo,LessonRecordFormContext context)
        {
            _repo = repo;
            _context = context;
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
        public IActionResult Create(Lesson lesson, IFormFile file)
        {
            string filePath = ImageUpload(file);
            if (filePath != null)
            {
                lesson.LessonImage = filePath;
                _repo.Add(lesson);
                return RedirectToAction("Index", _repo.GetAll());
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Lesson lesson= _context.Lessons.Find(id);
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{lesson.LessonImage}");
          

            if (System.IO.File.Exists(path))
            {

                try
                {
                    System.IO.File.Delete(path);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

         
            }
            


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


        public string ImageUpload(IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/lesson/{imageName}");
                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                return $"/images/lesson/{imageName}";
            }
            return null;
        }
    }
}
