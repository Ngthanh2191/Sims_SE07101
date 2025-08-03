using System.ComponentModel.DataAnnotations;

namespace WebSIMS.Models
{
    public class StudentViewModel
    {
        // User Information
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        // Student Specific Information
        [Required(ErrorMessage = "Student code is required")]
        [StringLength(20, ErrorMessage = "Student code cannot exceed 20 characters")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Program is required")]
        [StringLength(100, ErrorMessage = "Program cannot exceed 100 characters")]
        public string Program { get; set; }

        [StringLength(100, ErrorMessage = "Major cannot exceed 100 characters")]
        public string? Major { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public int? AdvisorID { get; set; }
    }

    public class StudentUpdateViewModel
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }

        // User Information
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        // Student Specific Information
        [Required(ErrorMessage = "Student code is required")]
        [StringLength(20, ErrorMessage = "Student code cannot exceed 20 characters")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Program is required")]
        [StringLength(100, ErrorMessage = "Program cannot exceed 100 characters")]
        public string Program { get; set; }

        [StringLength(100, ErrorMessage = "Major cannot exceed 100 characters")]
        public string? Major { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? GraduationDate { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public decimal? GPA { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public int? AdvisorID { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class StudentListViewModel
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Program { get; set; }
        public string? Major { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? GPA { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string? AdvisorName { get; set; }
    }

    public class StudentDetailViewModel
    {
        // User Information
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Student Information
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string Program { get; set; }
        public string? Major { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public decimal? GPA { get; set; }
        public string Status { get; set; }
        public string? AdvisorName { get; set; }

        // Statistics
        public int TotalEnrollments { get; set; }
        public int CompletedCourses { get; set; }
        public int ActiveEnrollments { get; set; }
    }

    public class StudentDeleteViewModel
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Program { get; set; }
        public string Status { get; set; }
        public int ActiveEnrollments { get; set; }
        public bool CanDelete => ActiveEnrollments == 0 && Status != "Graduated";
        public string DeleteWarning => ActiveEnrollments > 0
            ? $"Cannot delete student with {ActiveEnrollments} active enrollments"
            : Status == "Graduated"
                ? "Cannot delete graduated student (Archive instead)"
                : "";
    }
}

