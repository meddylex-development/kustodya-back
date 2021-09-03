using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    /// <summary>
    /// The User model used for the token generation
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user's Email
        /// </summary>
        /// <example>demouser@roojo.tech</example>
        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The user's first name
        /// </summary>
        /// <example>Demo</example>
        [Required, MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// The User Id to be used throgout all of the session
        /// </summary>
        /// <example>1</example>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The User profile selected or assigned at login
        /// </summary>
        /// <example>1</example>
        [Required]
        public int IdProfile { get; set; }

        /// <summary>
        /// The user's last name
        /// </summary>
        /// <example>User</example>
        [Required, MinLength(2), MaxLength(20)]
        public string LastName { get; set; }
    }
}