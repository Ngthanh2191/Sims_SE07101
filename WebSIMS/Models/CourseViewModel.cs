using System.ComponentModel.DataAnnotations;

namespace WebSIMS.Models
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        public string CourseName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6")]
        public int Credits { get; set; }

        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string? Department { get; set; }

        [StringLength(200, ErrorMessage = "Prerequisites cannot exceed 200 characters")]
        public string? Prerequisites { get; set; }

        [Range(1, 500, ErrorMessage = "Max enrollment must be between 1 and 500")]
        public int? MaxEnrollment { get; set; }

        public int? InstructorID { get; set; }

        [StringLength(100, ErrorMessage = "Schedule cannot exceed 100 characters")]
        public string? Schedule { get; set; }

        [StringLength(50, ErrorMessage = "Location cannot exceed 50 characters")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(2020, 2030, ErrorMessage = "Year must be between 2020 and 2030")]
        public int Year { get; set; }
    }

    public class CourseUpdateViewModel
    {
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        public string CourseName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6")]
        public int Credits { get; set; }

        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string? Department { get; set; }

        [StringLength(200, ErrorMessage = "Prerequisites cannot exceed 200 characters")]
        public string? Prerequisites { get; set; }

        [Range(1, 500, ErrorMessage = "Max enrollment must be between 1 and 500")]
        public int? MaxEnrollment { get; set; }

        public int? InstructorID { get; set; }

        [StringLength(100, ErrorMessage = "Schedule cannot exceed 100 characters")]
        public string? Schedule { get; set; }

        [StringLength(50, ErrorMessage = "Location cannot exceed 50 characters")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(2020, 2030, ErrorMessage = "Year must be between 2020 and 2030")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public int CurrentEnrollment { get; set; }
    }

    public class CourseListViewModel
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string? Department { get; set; }
        public string? InstructorName { get; set; }
        public string Schedule { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public int CurrentEnrollment { get; set; }
        public int? MaxEnrollment { get; set; }
    }

    public class CourseDeleteViewModel
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public int CurrentEnrollment { get; set; }
        public bool CanDelete => CurrentEnrollment == 0;
        public string DeleteWarning => CurrentEnrollment > 0
            ? $"Cannot delete course with {CurrentEnrollment} enrolled students"
            : "";
    }
}

