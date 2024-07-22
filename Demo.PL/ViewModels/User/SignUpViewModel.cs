using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels.User
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        [Display(Name = "Frist Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(5, ErrorMessage = "Minimum Length Is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword Is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password doesn't mattch with Password")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }

    }
}
