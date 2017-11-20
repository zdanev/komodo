using System;

namespace Komodo.Common
{
    public static class ConsoleHelper
    {
        public enum Style { Normal, Highlight, Subtle, Error }

        public static void SetConsoleColor(Style style)
        {
            var foregroundColor = ConsoleColor.White;

            switch (style)
            {
                case Style.Normal:
                    foregroundColor = ConsoleColor.Gray;
                    break;
                case Style.Highlight:
                    foregroundColor = ConsoleColor.White;
                    break;
                case Style.Subtle:
                    foregroundColor = ConsoleColor.DarkGray;
                    break;
                case Style.Error:
                    foregroundColor = ConsoleColor.Red;
                    break;
            }

            Console.ForegroundColor = foregroundColor;
        }

        public static void Write(string s, Style style = Style.Normal)
        {
            SetConsoleColor(style);
            Console.Write(s);
            Console.ResetColor();
        }

        public static void WriteLine(string s, Style style = Style.Normal)
        {
            SetConsoleColor(style);
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void ClearPrevConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, currentLineCursor - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor - 1);
        }
        
        public static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, currentLineCursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }  
        
        public static void WordWrap(string s)
        {
            int w = 0;
            var words = s.Split(' ');

            foreach (var word in words)
            {
                if (w + word.Length > 80) // todo: setting
                {
                    w = 0;
                    Console.WriteLine("");
                }

                Write(word + " ");

                w += word.Length;
            }

            Console.WriteLine("");
        }     

        public static void NewLine()
        {
            Console.WriteLine();
        }
    }
}