using System;

namespace OChat.Common
{
    public sealed class Account
    {
        public Int32 AccountId { get; set; }
        public String Login { get; set; }
        public String PasswordHash { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}