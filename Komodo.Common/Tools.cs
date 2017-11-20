using System;
using System.Text.RegularExpressions;

namespace Komodo.Common
{
    public static class Tools
    {
        public static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty).Trim();
        }
    }
}