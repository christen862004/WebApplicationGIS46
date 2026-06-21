using System.ComponentModel.DataAnnotations;

namespace WebApplicationGIS46.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
