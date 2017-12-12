using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedEF6.Domain;

namespace GettingStartedEF6.DataModel
{
    public class AttachmentEntityConfiguration : EntityTypeConfiguration<Attachment>
    {
        public AttachmentEntityConfiguration()
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
