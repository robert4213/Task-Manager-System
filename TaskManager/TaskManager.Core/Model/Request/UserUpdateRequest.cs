using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Model.Request
{
    public class UserUpdateRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Id { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [StringLength(50)]
        public string Fullname { get; set; }
        [StringLength(50)]
        public string MobileNo { get; set; }
    }
}