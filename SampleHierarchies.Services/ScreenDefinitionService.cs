using Newtonsoft.Json;
using SampleHierarchies.Data.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public static class ScreenDefinitionService
    {
        public static ScreenDefinition Load(string jsonFileName)
        {
            try
            {
                if (File.Exists(jsonFileName))
                {
                    string json = File.ReadAllText(jsonFileName);
                    ScreenDefinition? screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(json);
                    if (screenDefinition != null)
                        return screenDefinition;
                    else
                        throw new Exception("Screen definition is null");
                }
                else
                {
                    throw new Exception("Settings file (settings.json) does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deserializing settings: {ex.Message}");
            }
        }

        public static void PrintLineEntry(string jsonFileName, int numberOfLine)
        {
            ScreenDefinition screenDefinition = Load(jsonFileName);
            if (screenDefinition.LineEntries != null)
            {
                Console.ForegroundColor = screenDefinition.LineEntries[numberOfLine].ForegroundColor;
                Console.BackgroundColor = screenDefinition.LineEntries[numberOfLine].BackgroundColor;
                Console.WriteLine(screenDefinition.LineEntries[numberOfLine].Text);
                Console.ResetColor();
            }
            else
            {
                throw new Exception($"Lines not loading from {jsonFileName}");
            }
        }
    }
}
