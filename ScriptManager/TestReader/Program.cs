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
            var y = reader.Read();
            foreach(var b in y)
            {
                Console.WriteLine(b.ConfigKey + " " + b.Value + " " + b.Type);
            }
            DefinitionReader reader1 = new DefinitionReader();
            var x = reader1.Read();
            foreach(var a in x)
            {
                Console.WriteLine(a.Name + " " + a.IconPath + " " + a.Label + " " + a.Category + " " + a.Path + " "+ a.ScriptFileName);
            }
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.ReadLine();
        }
    }
}
