
using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entites;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper, IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(string SearchValue)
        {
            var employees = Enumerable.Empty<Employee>();//Empty Sequance -> IEnumbrabel<Emplyee>
            if (string.IsNullOrEmpty(SearchValue))
            {
                employees = _uniteOfWork.EmployeeRepository.GetAll();
            }
            else
            {
                employees = _uniteOfWork.EmployeeRepository.SearchEmployeesByName(SearchValue);
            }
            var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedEmps);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _uniteOfWork.EmployeeRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                ///Manual Mapping
                ///var mappedEmp = new Employee()
                /// {
                ///Name = employeeVM.Name,
                ///Age = employeeVM.Age,
                ///Address = employeeVM.Address,
                ///Salary = employeeVM.Salary,
                ///IsActive = employeeVM.IsActive,
                ///Email = employeeVM.Email,
                ///HireDate = employeeVM.HireDate,
                ///PhoneNumber = employeeVM.PhoneNumber,
                ///DepartmentId = employeeVM.DepartmentId    
                /// };

                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _uniteOfWork.EmployeeRepository.Add(mappedEmp);
                TempData["Message"] = "The Employee Has Been Created Successfuly";
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _uniteOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(viewName, mappedEmp);
        }
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
            #region code 
            //if (id == null)
            //{ 
            //    return NotFound();
            //}
            //var department = _departmentrepository.Get(id.Value);
            //if(department == null)
            //    return NotFound();
            //return View(department); 
            #endregion
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    _uniteOfWork.EmployeeRepository.Update(mappedEmp);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //It Will Put ex.Message in <div asp-validation-summary="All"></div> To View It in Edit View
                    ModelState.AddModelError("", ex.Message);
                    return View(employeeVM);
                }
            }

            return View(employeeVM);

        }
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int? id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _uniteOfWork.EmployeeRepository.Delete(mappedEmp);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(employeeVM);

            }

        }
    }
}
