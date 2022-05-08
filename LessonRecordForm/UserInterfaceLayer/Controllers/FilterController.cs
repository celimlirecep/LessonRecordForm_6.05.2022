using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterfaceLayer.Controllers
{
    public class FilterController : Controller
    {
        private readonly IStudentRepository _repo;
       
        public FilterController(IStudentRepository repo)
        {
            _repo = repo;
        }



        public IActionResult Index()
        {

            return View(_repo.GetAll());
        }
}
}
