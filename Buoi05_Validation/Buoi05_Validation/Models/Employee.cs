using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace Buoi05_Validation.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Employee
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Employee number must be between 5 and 20 characters.")]
[Remote(controller:"Employee", action:"IsEmployeeAvailable", ErrorMessage = "Employee number already exists.")]
public string EmployeeNo { get; set; }

        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string? Website { get; set; }

        [DataType(DataType.Date)]
        [AgeForWorking]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be from 0 or above")]
        public double Salary { get; set; } = 0;

        public bool IsPartTime { get; set; } = false;

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match the password.")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public string? CreditCard { get; set; }


        [MaxLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
