using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DemoAppContext : DbContext
    {
        public DemoAppContext() : base("name=DemoApp")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Story> Stories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Groups)
                        .WithMany(g => g.Users)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("GroupId");
                        });
            modelBuilder.Entity<Story>()
                .HasMany(g=>g.Groups)
                .WithMany(s => s.Stories)
                .Map(cs =>
            {
                cs.MapLeftKey("StoryId");
                cs.MapRightKey("GroupId");
             
            });

            modelBuilder.Entity<Story>().HasRequired(s => s.User).WithMany().Map(m => m.MapKey("UserId"));
            

        }
    }
}
