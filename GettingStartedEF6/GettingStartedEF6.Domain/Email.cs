using System;
using System.Collections.Generic;
using GettingStartedEF6.Domain.Interfaces;

namespace GettingStartedEF6.Domain
{
    public class Email  : IModificationHistory
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public string ToStr { get; set; } 
        public EmailImportance Importance { get; set; }
        public List<Attachment> Attachments { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
