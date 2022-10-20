using System.ComponentModel.DataAnnotations;

namespace RMZBuildingMS.Authentication
{
    public class RegisterModel
    {
        [Required (ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password Required")]
        public string Password { get; set; }
    }
}
