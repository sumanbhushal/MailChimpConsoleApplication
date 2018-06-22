using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMailChimpManager mailChimpManager = new MailChimpManager(config.api_key);
           
            Task<IEnumerable<MailChimp.Net.Models.List>> ListTask = GetList(mailChimpManager);
            ListTask.Wait();
            var ListCollection = ListTask.Result;
            foreach (var value in ListCollection)
            {
                Console.WriteLine(value.Id + " Web_id: " + value.WebId + " Name: " + value.Name);
            }
            Console.ReadKey();
        }

        public static async Task<IEnumerable<MailChimp.Net.Models.List>> GetList(IMailChimpManager mailChimpManager)
        {
            IEnumerable<List> mailChimpListCollection = await mailChimpManager.Lists.GetAllAsync().ConfigureAwait(false);
            
            return mailChimpListCollection;
        }
    }
}
