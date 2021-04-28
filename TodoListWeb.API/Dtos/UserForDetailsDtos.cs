using System;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Dtos
{
    public class UserForDetailsDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}