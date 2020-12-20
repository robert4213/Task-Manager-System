using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core.Entities
{
    [Table("Tasks")]
    public class Tasks
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(TypeName="datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName="char(1)")]
        public char? Priority { get; set; }
        [MaxLength(50)]
        public string Remarks { get; set; }

        public User User { get; set; }
    }
}