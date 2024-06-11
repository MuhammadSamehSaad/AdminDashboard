using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entites;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var departments = _uniteOfWork.DepartmentRepository.GetAll();
            var mappedEmps = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);
            return View(mappedEmps);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                var mappedDep = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                _uniteOfWork.DepartmentRepository.Add(mappedDep);

                TempData["Message"] = "The Department Has Been Created Successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
        }
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _uniteOfWork.DepartmentRepository.Get(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            var mappedEmp = _mapper.Map<Department,DepartmentViewModel>(department);
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
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _uniteOfWork.DepartmentRepository.Update(mappedEmp);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //It Will Put ex.Message in <div asp-validation-summary="All"></div> To View It in Edit View
                    ModelState.AddModelError("", ex.Message);
                    return View(departmentVM);
                }
            }

            return View(departmentVM);

        }
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();
            try
            {
                var mapppedEmp = _mapper.Map<DepartmentViewModel,Department>(departmentVM);
                _uniteOfWork.DepartmentRepository.Delete(mapppedEmp);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(departmentVM);
            }
        }
    }
}
