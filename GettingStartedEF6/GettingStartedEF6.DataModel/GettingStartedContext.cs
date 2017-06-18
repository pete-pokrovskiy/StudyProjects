using System.ComponentModel.DataAnnotations.Schema;
using GettingStartedEF6.Domain;
using System.Data.Entity;

namespace GettingStartedEF6.DataModel
{
    public class GettingStartedContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Attachment>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
