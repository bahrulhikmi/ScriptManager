using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using System.Diagnostics;
using System.IO;
using Serilog;

namespace Runner.Classes
{
    public class WinScriptRunner
    {
        protected IDefinitionItem DefinitionItem { get; set; }
        protected List<IConfigItem> ConfigItems { get; set; }

        public WinScriptRunner(IDefinitionItem definitionItem, List<IConfigItem> configItems)
        {
            this.DefinitionItem = definitionItem;
            this.ConfigItems = configItems;

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.File(Path.Combine(definitionItem.Path, definitionItem.LogFileName ?? "script_" + DateTime.Now.ToString("yyyyMMdd") + ".log"))
                            .CreateLogger();
        }

        public IRunnerResult Run()
        {
            Log.Debug("Start script runner....");

            var result = new RunnerResult() { Success = true };
            var scriptFileName = Path.Combine(DefinitionItem.Path, DefinitionItem.ScriptFileName);

            if (!File.Exists(scriptFileName))
            {
                Log.Error($"Script {scriptFileName} file not found.");
                result.Success = false; 

                return result;
            }
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";
            startInfo.Arguments = $"-NoProfile {scriptFileName}";
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            try
            {
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                result.Success = (errors.Length == 0);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                result.Success = false;
            }
            finally
            {
                Log.Debug("Finish script runner....");
            }

            return result;
        }
    }
}
