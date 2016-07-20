using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class User
    {
        public string UserId { get; set; }
        [Required]
         public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
     
        public virtual ICollection<Group> Groups { get; set; }
    }
}
