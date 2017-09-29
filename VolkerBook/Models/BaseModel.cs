using System.ComponentModel.DataAnnotations;

namespace VolkerBook.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Administrator { get; set; }
    }
}