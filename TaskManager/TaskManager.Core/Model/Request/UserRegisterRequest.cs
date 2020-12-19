using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Model.Request
{
    public class UserRegisterRequest
    {
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Fullname { get; set; }
        [StringLength(50)]
        public string MobileNo { get; set; }
    }
}