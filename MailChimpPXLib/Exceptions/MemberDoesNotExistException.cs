using System;
using System.Runtime.Serialization;

namespace MailchimpPXLib
{
    [Serializable]
    class MemberDoesNotExistException : Exception
    {
        public MemberDoesNotExistException() : base("Mailchimp member does not exist on list.")
        {
        }

        public MemberDoesNotExistException(string message) : base(message)
        {
        }
    }
}