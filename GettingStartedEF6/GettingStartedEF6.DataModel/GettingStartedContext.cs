using System;
using System.ComponentModel.DataAnnotations.Schema;
using GettingStartedEF6.Domain;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using GettingStartedEF6.Domain.Interfaces;

namespace GettingStartedEF6.DataModel
{
    public class GettingStartedContext : DbContext
    {

        
        public GettingStartedContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<GettingStartedContext>());

            //migration commands reference
            //https://coding.abel.nu/2012/03/ef-migrations-command-reference/
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmailEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new AttachmentEntityConfiguration());

            modelBuilder.Types().Configure(e => e.Ignore("IsDirty"));

            base.OnModelCreating(modelBuilder);
        }


        //если не проставлять даты создания и модификация таким образом, то нужно изменить тип полей на nullable
        //в этом случае будет срабатывать defaultValue, определенное в миграции (если не nullable, то будет передаваться DateTime.Min и будет валиться исключение)
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();

            // проставим все сущностям, которые были добавлены или изменились соответствующие даты
            foreach (var historyItem in ChangeTracker.Entries().Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified )).Select(e => (IModificationHistory) e))
            {
                historyItem.DateModified = DateTime.Now;

                if (historyItem.DateCreated == DateTime.MinValue)
                    historyItem.DateCreated = DateTime.Now;

            }

            var saveChangesResult = base.SaveChanges();

            //снимем флаг IsDirty
            foreach (var historyItem in ChangeTracker.Entries().OfType<IModificationHistory>())
            {
                historyItem.IsDirty = false;
            }

            return saveChangesResult;
        }
    }
}
