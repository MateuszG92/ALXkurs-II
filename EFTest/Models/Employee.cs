using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models
{
    [Table("pracownicy")]
    [Index(nameof(Email),IsUnique =true)]
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Podaj imię i naziwsko")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(12)]
        public string? PhoneNumber { get; set; }
    }
}
