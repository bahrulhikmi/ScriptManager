using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runner.Classes;
using Common.Interfaces;
using Serilog;

namespace TestingMamat
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitionItem = new DefinitionItem()
            {
                Path = "F:\\",
                ScriptFileName = "mamat.ps1",
                Name = "mamat"
            };

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.File("F:\\app.log")
                            .CreateLogger();

            var configItems = new List<IConfigItem>();
            var wsRunner = new WinScriptRunner(definitionItem, configItems);
            var res = wsRunner.Run();
        }
    }
}
