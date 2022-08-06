using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceDataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            new ApiDataExtractor().GetAllData();
            Console.Read();
        }
    }
}
