using System;
using System.Runtime.Serialization;

namespace MailchimpPXLib
{
    [Serializable]
    class NoAPIKeyException : Exception
    {
        public NoAPIKeyException() : base("Mailchimp API key is empty.")
        {
        }

        public NoAPIKeyException(string message) : base(message)
        {
        }
    }
}
