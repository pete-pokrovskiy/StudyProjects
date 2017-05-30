using GettingStartedEF6.Domain;
using System.Data.Entity;

namespace GettingStartedEF6.DataModel
{
    public class GettingStartedContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

    }
}
