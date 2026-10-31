using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.Helpers;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IEmployeeRepository _employeeRepo;
        //private readonly IDepartmentRepository _departmentRepo;

        public EmployeeController(IMapper mapper,IUnitOfWork unitOfWork
            /*IEmployeeRepository employeeRepo,IDepartmentRepository departmentRepo*/)
        {
            _mapper = mapper;
           _unitOfWork = unitOfWork;
            //_employeeRepo = employeeRepo;
            //_departmentRepo = departmentRepo;
        }
        
        public IActionResult Index(string SearchInpu)
        {

            TempData.Keep();
            ///1. veiwData
            ///ViewData["Message"] = "Hello ViewData ";
            ///2. ViewBage
            ///ViewBag.message = "Hello ViewBag";
            var employees=Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(SearchInpu))

                 employees = _unitOfWork.EmployeeRepository.GetAll();
            else
                 employees= _unitOfWork.EmployeeRepository.SearchEmployeeByName(SearchInpu.ToLower());

            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel> >(employees);

                return View(mappedEmp);

        }

        [HttpGet]
        public IActionResult Create()
        {
           // ViewData["Departments"]=_departmentRepo.GetAll();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeVM.ImageName= DecumentSettings.UpLoadFile(employeeVM.Image, "images");

                //1.Manual mapping
                ///var mappedEmp = new Employee()
                ///{
                ///  /// Name = employeeVM.Name,
                ///  /// Age = employeeVM.Age,
                ///  /// Address = employeeVM.Address,
                ///  /// Salary= employeeVM.Salary,
                ///  /// Email = employeeVM.Email,
                ///  /// PhoneNumber = employeeVM.PhoneNumber,
                ///  /// IsActive = employeeVM.IsActive,
                ///  /// HireDate = employeeVM.HireDate,
                ///};
                ///

                ///if (count > 0)
                ///    TempData["message"] = "Employee is Created Successfully";
                ///else 
                ///    TempData["message"] = "An Error Has Occured, Employee Not Created :(";
                var mappedEmp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);
                _unitOfWork.EmployeeRepository .Add(mappedEmp);


                //_dbContext.Savechanges();
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));

                
            }
            return View(employeeVM);

        }

        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();//400


            var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            var mappedEmp = _mapper.Map<Employee,EmployeeViewModel >(employee);

            if (employee is null)
                return NotFound();//404

            return View(ViewName, mappedEmp);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ///if (id is null)
            ///    return BadRequest();//400
            ///var department = _departmentsRepo.Get(id.Value);
            ///if (department is null)
            /// return NotFound();//404
           // ViewData["Departments"] = _departmentRepo.GetAll();

            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    _unitOfWork.EmployeeRepository.Update(mappedEmp);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }


            }
            return View(employeeVM);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                    _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                     var count=_unitOfWork.Complete();
                    if (count > 0)
                        DecumentSettings.DeleteFile(employeeVM.ImageName, "images");
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeVM);
                }


            }
            return View(employeeVM);
        }
    }
}
