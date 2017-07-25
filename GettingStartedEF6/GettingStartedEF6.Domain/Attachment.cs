using System;
using GettingStartedEF6.Domain.Interfaces;

namespace GettingStartedEF6.Domain
{
    public class Attachment : IModificationHistory
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public FileType FileType { get; set; }
        public Email Email { get; set; }
        public Guid EmailId { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
