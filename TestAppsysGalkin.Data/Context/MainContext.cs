using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Data.Context
{
    public class MainContext : IdentityDbContext<ApplicationUser>
    {
        public MainContext() : base("name=GalkinDatabase")
        { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<HeadPhone> HeadPhones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.FromUser)
                        .WithMany(t => t.SentMessages)
                        .HasForeignKey(m => m.FromUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.ToUser)
                        .WithMany(t => t.ReceivedMessages)
                        .HasForeignKey(m => m.ToUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }


}
