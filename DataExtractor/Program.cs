using System;

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
