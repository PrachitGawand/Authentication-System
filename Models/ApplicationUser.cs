using System.ComponentModel.DataAnnotations;

namespace TeamAuthMvc.Models
{
    // This class represents the "Users" table in the database.
    public class ApplicationUser
    {
        // Primary Key
        // EF automatically treats "Id" as the primary key and auto-increments it.
        [Key]
        public int Id { get; set; }

        // StringLength(80) limits the column size 
        [Required, StringLength(80)]
        public string Name { get; set; } = string.Empty;

        // Age must be between 18 and 60.
        // Range attribute validates user input at MVC level.
        [Required, Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }

        // Enum is stored as an integer in the database.
        [Required]
        public Gender Gender { get; set; }

        
        [Required, StringLength(50)]
        public string Region { get; set; } = string.Empty;

        
        [Required, StringLength(20)]
        public string Mobile { get; set; } = string.Empty;

        // RegularExpression validates proper email format at MVC level.
        // This prevents invalid email submission before saving to database.
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        
        // We never store plain passwords in database.
        // This column stores the hashed password only.
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Default role is "User".
        // Later we can assign "Admin" manually.
        public string Role { get; set; } = "User";
    }

    // Enum for Gender.
    // In database this will be stored as int:
    // Male = 1, Female = 2, Other = 3
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}