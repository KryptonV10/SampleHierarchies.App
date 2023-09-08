using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using SampleHierarchies.Services;
using SampleHierarchies.Data.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.ServicesTests
{
    [TestClass]
    public class ScreenDefinitionServiceTests
    {
        private const string ValidJsonFileName = "valid.json";
        private const string InvalidJsonFileName = "invalid.json";

        [TestMethod]
        public void Load_ValidJsonFile_ReturnsScreenDefinition()
        {
            // Arrange
            var validScreenDefinition = new ScreenDefinition
            {
                LineEntries = new List<ScreenLineEntry>
            {
                new ScreenLineEntry
                {
                    BackgroundColor = ConsoleColor.Black,
                    ForegroundColor = ConsoleColor.White,
                    Text = "Test Entry"
                }
            }
            };

            File.WriteAllText(ValidJsonFileName, JsonConvert.SerializeObject(validScreenDefinition));

            try
            {
                // Act
                var result = ScreenDefinitionService.Load(ValidJsonFileName);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.LineEntries);
                Assert.AreEqual(validScreenDefinition.LineEntries.Count, result.LineEntries.Count);
                // Add more assertions if necessary
            }
            finally
            {
                File.Delete(ValidJsonFileName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Settings file (settings.json) does not exist.")]
        public void Load_InvalidJsonFile_ThrowsException()
        {
            // Act
            ScreenDefinitionService.Load("nonexistent.json");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error while deserializing settings")]
        public void Load_InvalidJsonContent_ThrowsException()
        {
            // Arrange
            File.WriteAllText(InvalidJsonFileName, "Invalid JSON content");

            try
            {
                // Act
                ScreenDefinitionService.Load(InvalidJsonFileName);
            }
            finally
            {
                File.Delete(InvalidJsonFileName);
            }
        }

        [TestMethod]
        public void PrintLineEntry_ValidInput_PrintsToConsole()
        {
            // Arrange
            var validScreenDefinition = new ScreenDefinition
            {
                LineEntries = new List<ScreenLineEntry>
            {
                new ScreenLineEntry
                {
                    BackgroundColor = ConsoleColor.Black,
                    ForegroundColor = ConsoleColor.White,
                    Text = "Test Entry"
                }
            }
            };

            File.WriteAllText(ValidJsonFileName, JsonConvert.SerializeObject(validScreenDefinition));

            try
            {
                // Act
                ScreenDefinitionService.PrintLineEntry(ValidJsonFileName, 0);

                // Assert
                // You can add assertions to check if the expected text was printed to the console
            }
            finally
            {
                File.Delete(ValidJsonFileName);
            }
        }
    }
}
