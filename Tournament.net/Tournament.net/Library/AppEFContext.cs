using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tournament.net.Library
{
    public class AppEFContext : DbContext
    {

        public AppEFContext() : base("name=Tournament_DataBase")
        {

        }

        // Models we want to add to context
        public DbSet<App_User> App_User { get; set; }
        public DbSet<App_UserVerification> App_UserVerification { get; set; }
    }


    public class App_User
    {
        // Row ID
        public Guid ID { get; set; }
        // Email ID
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Password { get; set; }
        // If user is verified from email or not
        public bool IsVerified { get; set; }

    }


    public class App_UserVerification
    {
        public Guid ID { get; set; }
        // Users email id who generated verification code
        public string EmailID { get; set; }
        public string VerificationCode { get; set; }
        public DateTime CreateDate { get; set; }

    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string EmailID { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}