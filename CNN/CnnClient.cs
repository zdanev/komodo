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
            // Console.WindowWidth = 80;

            var service = new CnnService();
            var feed = await service.GetStories();

            foreach (var item in feed)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.Title);
                // WriteHighlightLine(item.Title);
                
                var content = StripHtml(item.Content);
                if (string.IsNullOrEmpty(content))
                {
                    WriteLine("");
                }
                else
                {
                    WordWrap(content);
                    // WriteSubtleLine(StripHtml(item.Content));
                    WriteLine("");
                }
            }
        }

        public static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty).Trim();
        }

        public static void WordWrap(string s)
        {
            int w = 0;
            var words = s.Split(' ');

            foreach (var word in words)
            {
                if (w + word.Length > 80)
                {
                    w = 0;
                    Console.WriteLine("");
                }

                Write(word + " ");

                w += word.Length;
            }

            Console.WriteLine("");
        }
    }   
}