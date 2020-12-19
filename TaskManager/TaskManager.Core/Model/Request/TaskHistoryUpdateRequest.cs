using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Model.Request
{
    public class TaskHistoryUpdateRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int TaskId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Completed { get; set; }
        [StringLength(500)]
        public string Remarks { get; set; }
    }
}