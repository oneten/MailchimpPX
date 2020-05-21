using System;
using System.Runtime.Serialization;

namespace MailchimpPXLib
{
    [Serializable]
    public class MemberDoesNotExistException : Exception
    {
        public MemberDoesNotExistException() : base("Mailchimp member does not exist on any list.")
        {
        }

        public MemberDoesNotExistException(string message) : base(message)
        {
        }
    }
}