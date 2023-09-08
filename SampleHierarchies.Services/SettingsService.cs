using Newtonsoft.Json;
using SampleHierarchies.Data.Settings;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        ISettings? result = null;

        return result;
    }

    public Settings? Settings { get; set; } = new Settings();

    public string JsonFilePath = "settings.json";

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        
    }

    /// <summary>
    /// Method that set ForegroundColor
    /// </summary>
    /// <param name="screenName"></param>
    /// <exception cref="Exception"></exception>
    public void SetConsoleColorForScreen(string screenName)
    {
        DeserializeColorsFromFile();
        if (Settings != null)
        {
            if (Settings.screenColors != null)
            {
                if (Settings.screenColors.TryGetValue(screenName, out ConsoleColor color))
                {
                    Console.ForegroundColor = color;
                }
                else
                {
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ResetColor();
            }
        }
        else
        {
            throw new Exception("Settings fail read");
        }
    }

    /// <summary>
    /// Deserializing screen colors from json
    /// </summary>
    public void DeserializeColorsFromFile()
    {
        try
        {
            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                Settings = JsonConvert.DeserializeObject<Settings>(json);
            }
            else
            {
                Console.WriteLine("Settings file (settings.json) does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while deserializing settings: {ex.Message}");
        }
    }

    private void SetDefaultColors(Dictionary<string, ConsoleColor> screenColors)
    {
        // Define default colors
        Dictionary<string, ConsoleColor> defaultColors = new Dictionary<string, ConsoleColor>
        {
            ["MainScreen"] = ConsoleColor.DarkRed,
            ["AnimalsScreen"] = ConsoleColor.DarkBlue,
            ["MammalsScreen"] = ConsoleColor.DarkBlue,
            ["DogsScreen"] = ConsoleColor.DarkYellow,
            ["TigersScreen"] = ConsoleColor.Yellow,
            ["FlyingSquirrelsScreen"] = ConsoleColor.Green,
            ["HedgehogsScreen"] = ConsoleColor.DarkCyan
        };

        // Update the screenColors dictionary with default values if they don't already exist
        foreach (var kvp in defaultColors)
        {
            if (!screenColors.ContainsKey(kvp.Key))
            {
                screenColors[kvp.Key] = kvp.Value;
            }
        }
    }

    /// <summary>
    /// Serializing screen colors to json
    /// </summary>
    public void SerializeColorsToFile()
    {
        try
        {
            if (Settings != null && Settings.screenColors != null)
            {
                string jsonFilePath = "settings.json";

                // Deserialize existing colors, or create a new dictionary if it doesn't exist
                Dictionary<string, ConsoleColor> screenColors = Settings.screenColors ?? new Dictionary<string, ConsoleColor>();

                // Update the colors with the default values if they don't already exist
                SetDefaultColors(screenColors);

                // Serialize the updated settings to JSON
                string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

                Console.WriteLine("Settings have been serialized and saved to settings.json.");
            }
            else
            {
                throw new Exception("Settings failed to read or screen colors dictionary is null.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while serializing settings: {ex.Message}");
        }
    }

    public void ChangeConsoleColorForScreen()
    {
        DeserializeColorsFromFile();

        if (Settings != null && Settings.screenColors != null)
        {
            Console.Write("Enter the name of the screen: ");
            string? screenName = Console.ReadLine();

            if (screenName != null)
            {
                if (Settings.screenColors.ContainsKey(screenName))
                {
                    Console.Write("Enter the new color (e.g., Red, Green, Blue): ");
                    string? colorInput = Console.ReadLine();

                    if (Enum.TryParse(typeof(ConsoleColor), colorInput, true, out var newColor))
                    {
                        if (newColor is ConsoleColor consoleColor)
                        {
                            Settings.screenColors[screenName] = consoleColor;
                            SerializeColorsToFile();
                            Console.WriteLine($"Color for screen '{screenName}' has been updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid color input. Please use a valid ConsoleColor name (case insensitive).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid color input. Please use a valid ConsoleColor name (case insensitive).");
                    }
                }
                else
                {
                    Console.WriteLine($"Screen '{screenName}' does not exist in the settings.");
                }
            }
            else
            {
                throw new Exception("Invalid input");
            }
        }
        else
        {
            throw new Exception("Settings failed to read or screen colors dictionary is null.");
        }
    }

    #endregion // ISettings Implementation
}