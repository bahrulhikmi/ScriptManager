﻿using System;
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
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = definitionItem.Path + '\\' + definitionItem.ScriptFileName;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }

                result.Success = true;
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
