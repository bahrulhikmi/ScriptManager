using Common.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Runner.Classes
{
    public class BatRunner
    {
        public IRunnerResult Run(IDefinitionItem definitionItem, List<IConfigItem> configItems)
        {
            var result = new RunnerResult();
            int errorCount = 0;
            var filePath = Path.Combine(definitionItem.Path, definitionItem.ScriptFileName);
            var message = "";

            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + filePath);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

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

            //Log message
            //message

            return result;
        }
    }
}
