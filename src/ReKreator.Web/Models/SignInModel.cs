using System.ComponentModel.DataAnnotations;

namespace ReKreator.Web.Models
{
    public class SignInModel
    {
        [Required]
        [MaxLength(250)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}