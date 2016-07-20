using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using FlatClubDemoApp.Custom;

namespace FlatClubDemoApp.Models.Login
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid email format")]
        [IsUnique(ErrorMessage = "login already exists.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage ="At least 8 characters, including uppercase lowercase and digit")]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }
    }

   
}