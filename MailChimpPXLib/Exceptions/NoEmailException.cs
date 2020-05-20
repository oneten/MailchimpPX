using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimpPXLib.Exceptions
{
    [Serializable]
    public class NoEmailException : Exception
    {
        public NoEmailException() : base("The contact does not have an email address and therefore cannot be found in Mailchimp.")
        {
        }

        public NoEmailException(string message) : base(message)
        {
        }
    }
}
