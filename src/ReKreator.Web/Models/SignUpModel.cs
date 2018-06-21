using System.ComponentModel.DataAnnotations;

namespace ReKreator.Web.Models
{
    public class SignUpModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", 
            ErrorMessageResourceName = "EmailValidator",
            ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Your password")]
        public string UserPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(UserPassword))]
        [MinLength(8)]
        [Display(Name = "Confirm your password")]
        public string ConfirmUserPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{4,50}$",
            ErrorMessageResourceName = "UserNameValidator",
            ErrorMessageResourceType = typeof(Resources.Resources))]
        public string UserName { get; set; }
    }
}