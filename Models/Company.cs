using System.ComponentModel.DataAnnotations;

namespace Clocker.Models
{
    public class Company
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? NOE { get; set; }

        [Required]
        public string? Logo { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }   
    }
}
