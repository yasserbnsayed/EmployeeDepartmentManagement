using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //Inhertiance : DepartmentController is a Controller
        // composition : DepartmentController has a DepartmentRepository

        //private  readonly IDepartmentRepository _departmentsRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork /*IDepartmentRepository departmenrRepo*/)
        {
           // _departmentsRepo= departmenrRepo;
           _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(department);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department); 

        }

        public IActionResult Details(int? id, string ViewName= "Details") 
        {
            if (id is null)
                return BadRequest();//400
            var department = _unitOfWork.DepartmentRepository.Get(id.Value);

            if(department is null)
                return NotFound();//404

            return View(ViewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ///if (id is null)
            ///    return BadRequest();//400
            ///var department = _departmentsRepo.Get(id.Value);
            ///if (department is null)
            /// return NotFound();//404

            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if(id!=department.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

               
            }
            return View(department);
        }

        public IActionResult Delete(int? id) 
        {
            return Details(id, "Delete");
        
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Delete(department);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(department);
                }


            }
            return View(department);
        }



    }
}
