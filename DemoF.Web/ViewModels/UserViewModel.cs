using System.ComponentModel.DataAnnotations;

namespace DemoF.Web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
