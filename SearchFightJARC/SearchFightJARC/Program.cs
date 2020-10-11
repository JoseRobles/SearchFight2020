using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace SearchFightJARC
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No words were entered");
                return;
            }

            Console.WriteLine("Running Search...");
            await ProcessHandler.RunProcess(args.ToList());
        }
    }

    
}
