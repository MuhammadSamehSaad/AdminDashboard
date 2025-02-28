﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entites
{
    public class Department
    {

        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        //Navigationl Property (Many)

        public ICollection<Employee> Employees { get; set; }



    }
}
