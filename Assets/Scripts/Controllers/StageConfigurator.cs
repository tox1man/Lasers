using System;
using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class StageConfigurator
{
    public Dictionary<ModuleType, int> Modules { get; private set; }
    public StageConfigurator(Dictionary<ModuleType, int> modules)
    {
        Modules = modules;
    }
}
