using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Member
    {
        [Required(ErrorMessage = "podaj nazwę")]
        [MinLength(2, ErrorMessage = "za krótki tekst")]
        [MaxLength(20)]
        public string Name { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage ="podaj poprawny kod")]
        public string ZipCode { get; set; } = "";
        //[Range(10,120)]
        [AgeOverAttribute(18)]
        public int Age { get; set; }

        private class AgeOverAttribute : ValidationAttribute
        {
            public int Age { get; }
            public AgeOverAttribute(int age) 
            {
                Age = age;
            }

            public string GetError() => $"Wiek musi być powyżej {Age}";

            protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
            {
                var member = (Member)validationContext.ObjectInstance;
                if (member.Age < Age)
                {
                    return new ValidationResult(GetError());
                }
                return ValidationResult.Success;
            }
        }
    }
}
