using System;
using GettingStartedEF6.Domain.Interfaces;

namespace GettingStartedEF6.Domain
{
    public class User : IModificationHistory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
