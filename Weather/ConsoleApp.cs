using System;
using System.Threading.Tasks;

namespace Komodo.Common
{
    public abstract class ConsoleApp
    {
        public abstract string Title { get; }

        public virtual Task ExecuteAsync(string[] args)
        {
            return Task.CompletedTask;
        }

        public virtual void Execute(string[] args)
        {
            var task = ExecuteAsync(args);
            task.Wait();
        }

        public void Run(string[] args)
        {
            Console.Title = Title;
            Console.WriteLine();

            Execute(args);

            Console.ResetColor();
        }

        public virtual void Help()
        {
            Console.WriteLine("Copyright (c) " + DateTime.Now.Year);
        }

        public virtual void WriteLine(string s)
        {
            ConsoleHelper.WriteLine(s);
        }

        public virtual void WriteSubtleLine(string s)
        {
            ConsoleHelper.WriteLine(s, ConsoleHelper.Style.Subtle);
        }

        public virtual void WriteHighlightLine(string s)
        {
            ConsoleHelper.WriteLine(s, ConsoleHelper.Style.Highlight);
        }

        public virtual void WriteError(string error)
        {
            ConsoleHelper.WriteLine(error, ConsoleHelper.Style.Error);
        }

        public virtual void ClearPrevConsoleLine()
        {
            ConsoleHelper.ClearPrevConsoleLine();
        }
    }
}