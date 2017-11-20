using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Komodo.Common.ConsoleHelper;

namespace Komodo.Cnn
{
    public class CnnService
    {
        string url = "http://rss.cnn.com/rss/cnn_topstories.rss";

        public async Task<FeedItem[]> GetStories()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseMessage = await client.GetAsync(url);
                var responseString = await responseMessage.Content.ReadAsStringAsync();

                // extract feed items
                var doc = XDocument.Parse(responseString);
                var feedItems = from item in doc.Root.Descendants()
                    .First(i => i.Name.LocalName == "channel")
                    .Elements()
                    .Where(i => i.Name.LocalName == "item")
                                select new FeedItem
                                {
                                    Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                    //Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                    //PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                                    Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                                };

                return feedItems.ToArray();
            }
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            
            if (DateTime.TryParse(date, out result))
            {
                return result;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}