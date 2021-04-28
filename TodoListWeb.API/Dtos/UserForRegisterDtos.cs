using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.API.Dtos
{
    public class UserForRegisterDtos
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string MobileNo { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required]
        public int RoleId { get; set; }

        public UserForRegisterDtos()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}