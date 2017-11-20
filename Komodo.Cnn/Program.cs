using System;

namespace Komodo.Cnn
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CnnClient();
            app.Run(args);
        }
    }
}
