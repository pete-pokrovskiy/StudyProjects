using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GettingStartedEF6.Domain;

namespace GettingStartedEF6.DataModel
{
    public class EmailEntityConfiguration : EntityTypeConfiguration<Email>
    {
        public EmailEntityConfiguration()
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
