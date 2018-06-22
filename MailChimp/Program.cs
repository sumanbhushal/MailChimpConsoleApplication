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
           
            Task<IEnumerable<List>> ListTask = GetList(mailChimpManager);
            ListTask.Wait();
            var ListCollection = ListTask.Result;
            foreach (var value in ListCollection)
            {
                Console.WriteLine(value.Id + " Web_id: " + value.WebId + " Name: " + value.Name);
            }

            Task<IEnumerable<Campaign>> CampaignTask = GetAllCampaign(mailChimpManager);
            CampaignTask.Wait();
            var CampaignCollection = CampaignTask.Result;
            foreach (var value in CampaignCollection)
            {
                Console.WriteLine(value.Id + " Web_id: " + value.WebId + " Created Time: " + value.CreateTime + " Title Name: " + value.Settings.Title);
            }

            Console.ReadKey();
        }

        public static async Task<IEnumerable<List>> GetList(IMailChimpManager mailChimpManager)
        {
            IEnumerable<List> mailChimpListCollection = await mailChimpManager.Lists.GetAllAsync().ConfigureAwait(false);
            
            return mailChimpListCollection;
        }

        public static async Task<IEnumerable<Campaign>> GetAllCampaign(IMailChimpManager mailChimpManager)
        {
            IEnumerable<Campaign> mailChimpCampaignCollection = await mailChimpManager.Campaigns.GetAllAsync().ConfigureAwait(false);

            return mailChimpCampaignCollection;
        }
    }
}
