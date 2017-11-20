using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Komodo.Common;

using static Komodo.Common.ConsoleHelper;

namespace Komodo.Cnn
{
    public class CnnClient : ConsoleApp
    {
        public override string Title => "CNN";

        public override async Task ExecuteAsync(string[] args)
        {
            var service = new CnnService();
            var feed = await service.GetStories();

            foreach (var item in feed)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.Title);
                
                var content = Tools.StripHtml(item.Content);
                if (string.IsNullOrEmpty(content))
                {
                    NewLine();
                }
                else
                {
                    WordWrap(content);
                    NewLine();
                }
            }
        }
    }   
}