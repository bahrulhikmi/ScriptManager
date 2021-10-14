using Reader;
using System;

namespace TestReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ConfigReader reader = new ConfigReader();
            
            DefinitionReader reader = new DefinitionReader();
            var x = reader.Read();
            foreach(var a in x)
            {
                Console.WriteLine(a.Name + " " + a.IconPath + " " + a.Label + " " + a.Category + " " + a.ScriptFileName);
            }
            Console.ReadLine();
        }
    }
}
