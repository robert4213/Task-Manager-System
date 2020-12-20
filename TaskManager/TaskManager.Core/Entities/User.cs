using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; }
        [MaxLength(50)]
        public string MobileNo { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        
        public ICollection<TaskHistory> TaskHistories { get; set; }
    }
}