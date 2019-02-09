using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionApp.Helpers
{
    public static class Config
    {
        public static bool ShowOutput => Convert.ToBoolean(ConfigurationManager.AppSettings["ShowOutput"]);
    }
}
