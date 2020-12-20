using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core.Entities
{
    [Table("Tasks History")]
    public class TaskHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }
        public int? UserId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(TypeName="datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName="datetime")]
        public DateTime? Completed { get; set; }
        [MaxLength(500)]
        public string Remarks { get; set; }

        public User User { get; set; }
    }
}