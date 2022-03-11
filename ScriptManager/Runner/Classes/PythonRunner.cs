using Common.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Runner.Classes
{
    public class PythonRunner
    {
        protected IDefinitionItem DefinitionItem { get; set; }
        protected List<IConfigItem> ConfigItems { get; set; }

        public PythonRunner(IDefinitionItem definitionItem, List<IConfigItem> configItems)
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

            //Check if Python is isntalled
            if (string.IsNullOrEmpty(PythonCheck()))
            {
                return result;
            }

            var processInfo = new ProcessStartInfo("py", scriptFileName);
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
            catch (Exception ex)
            {
                result.Success = false;
                Log.Error(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Check if phyton is installed
        /// </summary>
        public string PythonCheck()
        {
            string result = "";

            ProcessStartInfo pycheck = new ProcessStartInfo();
            pycheck.FileName = @"py";
            pycheck.Arguments = "--version";
            pycheck.UseShellExecute = false;
            pycheck.RedirectStandardOutput = true;
            pycheck.CreateNoWindow = true;

            try
            {
                using (Process process = Process.Start(pycheck))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        result = reader.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return result;
            }
        }
    }
}
