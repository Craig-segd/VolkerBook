using System;
using System.ComponentModel.DataAnnotations;

namespace VolkerBook.Models
{
    public class Members : BaseModel
    {
        [Required]
        public Guid MemberId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The First Name field is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Last Name field is required")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid contact number")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Role field is required")]
        [StringLength(100)]
        public string Role { get; set; }
    }
}