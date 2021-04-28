using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.API.Dtos
{
    public class UserForLoginDtos
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}