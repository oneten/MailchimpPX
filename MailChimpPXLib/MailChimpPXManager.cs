using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

namespace MailchimpPXLib
{
    public class MailchimpPXManager
    {
        private readonly MailChimpManager manager;

        public MailchimpPXManager(string apiKey)
        {
            if (String.IsNullOrEmpty(apiKey)) throw new NoAPIKeyException();
            manager = new MailChimpManager(apiKey);
        }

        public List<List> GetLists()
        {
            var mc_lists = Task.Run(async () => await manager.Lists.GetAllAsync()).Result;
            return mc_lists.ToList();
        }

        public List GetList(string listId)
        {
            List mc_list;
            try
            {
                mc_list = Task.Run(async () => await manager.Lists.GetAsync(listId)).Result;
            } catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
            return mc_list;
        }

        public Member GetMember(string listId, string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new NoEmailException();
            }
            var email_md5 = CalculateMD5Hash(email);
            Member member;
            try
            {
                member = Task.Run(async () => await manager.Members.GetAsync(listId, email_md5)).Result;
            }
            catch (AggregateException ae) when (ae.InnerException is MailChimpNotFoundException)
            {
                // If fetching the member on the list doesn't find anything, try to get the list.
                // If we can't find the list, then the list doesn't exist. Otherwise, the member doesn't exist on the list.
                try
                {
                    GetList(listId);
                }
                catch (MailChimpNotFoundException)
                {
                    throw new ListDoesNotExistException();
                }
                throw new MemberDoesNotExistException();
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }

            return member;
        }

        public Member AddEmailToList(string email, string listID, string first_name, string last_name, int ContactID)
        {
            var member = new Member
            {
                EmailAddress = email,
                ListId = listID,
                MergeFields = new Dictionary<string, object>
                {
                    { "FNAME", first_name },
                    { "LNAME", last_name }
                }
            };
            return AddEmailToList(listID, member, ContactID);

        }

        public Member AddEmailToList(string listID, Member member, int ContactID)
        {
            member.MergeFields["ContactID"] = ContactID;
            member.TimestampSignup = DateTime.UtcNow.ToString("s");
            member.StatusIfNew = Status.Subscribed;
            try
            {
                member = Task.Run(async () => await manager.Members.AddOrUpdateAsync(listID, member)).Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }

            return member;
        }

        public List<Activity> GetActivities(string listId, string email)
        {
            var email_md5 = CalculateMD5Hash(email);
            IEnumerable<Activity> mc_activities;
            try
            {
                mc_activities = Task.Run(async () => await manager.Members.GetActivitiesAsync(listId, email_md5)).Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }

            return mc_activities.ToList();
        }

        // From https://blogs.msdn.microsoft.com/csharpfaq/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string/
        protected string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}