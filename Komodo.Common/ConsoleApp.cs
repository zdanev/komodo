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
    }
}