using Demo.DAL.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required!")]
        [MaxLength(50, ErrorMessage = "The name must be less than 50 characters.")]
        [MinLength(5, ErrorMessage = "The Minemum Length Of Name Is 5 characters.")]
        public string Name { get; set; }


        [Range(22, 30, ErrorMessage = "Age Must Be Between 22 and 30")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Invalid address format.")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Range(4000, 8000)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }


        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        //Navigation Property (One)
        public Department Department { get; set; }


    }
}
