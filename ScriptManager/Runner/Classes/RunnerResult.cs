﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Runner.Classes
{
    public class RunnerResult : IRunnerResult
    {
        public bool Success { get; set; }
    }
}
