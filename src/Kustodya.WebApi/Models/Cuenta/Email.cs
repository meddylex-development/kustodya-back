using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Email
    {
        /// <summary>
        /// </summary>
        /// <example>demouser@roojo.tech</example>
        [Required]
        [EmailAddress]
        public string EmailString { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }
}