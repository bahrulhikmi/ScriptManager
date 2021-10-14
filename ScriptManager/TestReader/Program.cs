using Reader;
using System;

namespace TestReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConfigReader reader = new ConfigReader();
            var x = reader.Read();
            foreach(var a in x)
            {
                Console.WriteLine(a.ConfigKey + " " + a.Value);
            }
            Console.ReadLine();
        }
    }
}
