using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Settings
{
    public class Settings : ISettings
    {
        public Dictionary<string, ConsoleColor> screenColors { get; set; } = new Dictionary<string, ConsoleColor>();
        public string Version { get; set; } = "1.1.0";
    }
}
