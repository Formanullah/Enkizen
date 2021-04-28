using System;
using System.Collections.Generic;

namespace TodoListWeb.API.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDone { get; set; }

        public virtual Users User { get; set; }
    }
}
