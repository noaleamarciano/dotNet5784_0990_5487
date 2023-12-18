﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal static class Config
{
    static string s_data_config_xml = "data-config";
    internal static int NextDependenceId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextDependenceId"); }
    internal static int NextTaskId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextTaskId"); }

}
