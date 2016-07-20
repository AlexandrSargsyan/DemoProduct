using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlatClubDemoApp.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "*")]
        //[RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        // [RegularExpression("@(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$",ErrorMessage ="")]
        public string Password { get; set; }

    }
}