using System;

namespace GettingStartedEF6.Domain
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public FileType FileType { get; set; }
        public Email Email { get; set; }
        public Guid EmailId { get; set; }
    }
}
