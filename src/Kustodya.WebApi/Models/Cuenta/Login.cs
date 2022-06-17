using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class Login
    {
        /// <summary>
        /// The User password, this should be a Hash!
        /// </summary>
        /// <example>123456aA</example>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// The user's Email
        /// </summary>
        /// <example>juan.almonacid</example>
        [Required]
        //[EmailAddress]
        public string User { get; set; }
    }
}