using Common.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Serilog;
using System;

namespace Runner.Classes
{
    public class BatRunner
    {
        protected IDefinitionItem DefinitionItem { get; set; }
        protected List<IConfigItem> ConfigItems { get; set; }

        public BatRunner(IDefinitionItem definitionItem, List<IConfigItem> configItems)
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
            var result = new RunnerResult() { Success = true };
            var scriptFileName = Path.Combine(DefinitionItem.Path, DefinitionItem.ScriptFileName);
            int errorCount = 0;
            var message = "";

            if (!File.Exists(scriptFileName))
            {
                Log.Error($"Script {scriptFileName} file not found.");
                result.Success = false;

                return result;
            }

            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + scriptFileName);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            try
            {
                var process = Process.Start(processInfo);

                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        message += e.Data;
                        errorCount += 1;
                    }
                };

                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();

                result.Success = errorCount == 0;
                if (errorCount > 0)
                {
                    Log.Error(message);
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                Log.Error(ex.Message);
            }


            return result;
        }
    }
}
