using System;
using System.Collections.Generic;

namespace GettingStartedEF6.Domain
{
    public class Email
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public string ToStr { get; set; } 
        public List<Attachment> Attachments { get; set; } 
    }
}
