using System.ComponentModel.DataAnnotations;

namespace Buoi05_Validation.Models
{
    public class AgeForWorkingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var age = DateTime.Now.Year - birthDate.Year;
                if (age >= 16 && age <= 65)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Tuổi phải từ 16 đến 65.");
                }
            }
            return new ValidationResult("Sai kiểu dữ liệu hoặc giá trị không hợp lệ.");
        }
    }
}