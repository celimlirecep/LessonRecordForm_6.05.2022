using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterfaceLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        private readonly LessonRecordFormContext _context;
        private readonly ILessonRepository _lessonRepo;
        public StudentController(IStudentRepository repo, LessonRecordFormContext context, ILessonRepository lessonrepo)
        {
            _repo = repo;
            _context = context;
            _lessonRepo = lessonrepo;
        }
        public IActionResult Index()
        {

            return View(_repo.GetAll());
        }
        public IActionResult Create()
        {
            ViewData["Department"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {

            _repo.Add(student);
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
        public IActionResult Edit(Student student)
        {
            _repo.Update(student);
            return RedirectToAction("Index");
        }
        public IActionResult Assign(int id)
        {
            ViewBag.Lessons = _lessonRepo.GetAll();
            Student combinedStudent = _repo.CombineStudentLessson(id);
            ViewBag.SelectedList = combinedStudent.StudentLessons.Select(x => x.Lesson);
            return View(combinedStudent);
        }
        [HttpPost]
        public IActionResult Assign()
        {
            return View();
        }
    }
}
