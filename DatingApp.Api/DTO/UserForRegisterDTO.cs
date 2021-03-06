using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        [StringLength(8)]       
        public string UserName { get; set; }

         [Required]
         [StringLength(8, MinimumLength =4, ErrorMessage = "You must specify password between 4 and 8 characters")]       
        public string Password { get; set; }
    }
}