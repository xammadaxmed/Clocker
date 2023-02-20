using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clocker.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        public string LastName { get; set; }    = string.Empty;


        [Required]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Phone { get; set; } = string.Empty;


        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string Address { get;set; } = string.Empty;

        [Required]
        public bool IsFullTime { get; set; }

        [Required]
        public decimal HourlyWage { get; set; }

        [Required]
        public int RequiredHoursPerWeak { get;set; }

        [Required]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set;} = 0;


        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
