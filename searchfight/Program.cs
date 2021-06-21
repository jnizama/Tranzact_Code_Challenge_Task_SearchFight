using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Infrastructure.Factory;

namespace SearchFight
{
    class Program
    {
        /// <summary>
        /// Code main to engine search
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
           
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a query to search....");
                args = Console.ReadLine()?.Split(' ');
            }

            Console.WriteLine("Wait please, searching results.......");
            
            
            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();

        }
        static async Task MainAsync(string[] args)
        {
            //Endpoint to search engine
            await SearchFightKernel.ExecuteSearchFight(args.ToList());
            SearchFightKernel.Reports.ForEach(report => Console.WriteLine(report));
        }
    }
}
