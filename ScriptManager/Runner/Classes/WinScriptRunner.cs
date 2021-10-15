using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using System.Diagnostics;

namespace Runner.Classes
{
    public class WinScriptRunner
    {
        public IRunnerResult Run(IDefinitionItem definitionItem, List<IConfigItem> configItems)
        {
            var result = new RunnerResult();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";
            startInfo.Arguments = $"-NoProfile {definitionItem.Path}\\{definitionItem.ScriptFileName}";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            try
            {
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                result.Success = (errors.Length > 0);
            }
            catch
            {
                // Log error.
                result.Success = false;
            }

            return result;
        }
    }
}
