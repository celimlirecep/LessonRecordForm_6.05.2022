using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterfaceLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public   IActionResult Index()
        {
            return View(  _repo.GetAll());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _repo.Add(department);
           return RedirectToAction("Index");
        }
     
        public IActionResult Delete(int id )
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetSingle(id));
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _repo.Update(department);
            return RedirectToAction("Index");
        }
    }
}
