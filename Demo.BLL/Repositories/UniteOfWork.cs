﻿using Demo.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UniteOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)    
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }
    }
}
