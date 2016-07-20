using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DataAccess
{
    public class Group
    {
        public Group()
        {
            this.Users = new List<User>();
            this.Stories = new List<Story>();
        }
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }
        [Required]
        public string GroupDescription { get; set; }

 
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}