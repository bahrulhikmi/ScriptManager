using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Runner.Classes
{
    public class PythonRunner
    {
        public IRunnerResult Run(IDefinitionItem definitionItem, List<IConfigItem> configItems)
        {
            var result = new RunnerResult();
            int errorCount = 0;
            var filePath = Path.Combine(definitionItem.Path, definitionItem.ScriptFileName);
            var message = "";

            //Check if Python is isntalled
            if (string.IsNullOrEmpty(PythonCheck()))
            {
                return result;
            }

            var processInfo = new ProcessStartInfo("py", filePath);
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
            catch (Exception)
            {
                //Log message
                //message

                return result;
            }
        }
    }
}
