using System;

namespace GettingStartedEF6.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
