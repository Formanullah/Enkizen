using System;

namespace TodoListWeb.API.Dtos
{
    public class TaskForCreationDtos
    {
        public string TaskName { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public TaskForCreationDtos()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}