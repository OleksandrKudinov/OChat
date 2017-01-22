using System;

namespace OChat.Common
{
    public sealed class Account
    {
        public String AccountId { get; set; }
        public String Login { get; set; }
        public String PasswordHash { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}