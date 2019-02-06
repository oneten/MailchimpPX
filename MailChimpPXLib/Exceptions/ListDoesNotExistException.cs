using System;
using System.Runtime.Serialization;

namespace MailchimpPXLib
{
    [Serializable]
    class ListDoesNotExistException : Exception
    {
        public ListDoesNotExistException() : base("Mailchimp list does not exist.")
        {
        }

        public ListDoesNotExistException(string message) : base(message)
        {
        }
    }
}