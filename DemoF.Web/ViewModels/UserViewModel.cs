using System.ComponentModel.DataAnnotations;

namespace DemoF.Web.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "You must enter First name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "You must enter Last name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string LastName { get; set; }
    }
}
