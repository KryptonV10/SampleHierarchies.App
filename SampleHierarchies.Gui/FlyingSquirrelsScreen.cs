using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public sealed class FlyingSquirrelScreen : Screen
    {
        #region Properties and Constructor

        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "FlyingSquirrelsScreenDefinition.json";

        public FlyingSquirrelScreen(IDataService dataService, SettingsService settingsService)
        {
            _dataService = dataService;
            _settingsService = settingsService;
        }

        #endregion // Properties and Constructor

        #region Public Methods

        public override void Show()
        {
            while (true)
            {
                _settingsService.SetConsoleColorForScreen("FlyingSquirrelsScreen");
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 6);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);

                string? choiceAsString = Console.ReadLine();

                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    FlyingSquirrelsScreenChoices choice = (FlyingSquirrelsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case FlyingSquirrelsScreenChoices.List:
                            ListFlyingSquirrels();
                            break;

                        case FlyingSquirrelsScreenChoices.Create:
                            AddFlyingSquirrel();
                            break;

                        case FlyingSquirrelsScreenChoices.Delete:
                            DeleteFlyingSquirrel();
                            break;

                        case FlyingSquirrelsScreenChoices.Modify:
                            EditFlyingSquirrelMain();
                            break;

                        case FlyingSquirrelsScreenChoices.Exit:
                            Console.ResetColor();
                            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 9);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void ListFlyingSquirrels()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.FlyingSquirrels is not null &&
                _dataService.Animals.Mammals.FlyingSquirrels.Count > 0)
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (FlyingSquirrel squirrel in _dataService.Animals.Mammals.FlyingSquirrels)
                {
                    Console.Write($"Flying Squirrel number {i}, ");
                    squirrel.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 11);
            }
        }

        private void AddFlyingSquirrel()
        {
            try
            {
                FlyingSquirrel squirrel = AddEditFlyingSquirrel();
                _dataService?.Animals?.Mammals?.FlyingSquirrels?.Add(squirrel);
                Console.WriteLine("Flying Squirrel with name: {0} has been added to the list of flying squirrels", squirrel.Name);
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 12);
            }
        }

        private void DeleteFlyingSquirrel()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                FlyingSquirrel? squirrel = (FlyingSquirrel?)(_dataService?.Animals?.Mammals?.FlyingSquirrels
                    ?.FirstOrDefault(s => s is not null && string.Equals(s.Name, name)));
                if (squirrel is not null)
                {
                    _dataService?.Animals?.Mammals?.FlyingSquirrels?.Remove(squirrel);
                    Console.WriteLine("Flying Squirrel with name: {0} has been deleted from the list of flying squirrels", squirrel.Name);
                }
                else
                {
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 14);
                }
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 15);
            }
        }

        private void EditFlyingSquirrelMain()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                FlyingSquirrel? squirrel = (FlyingSquirrel?)(_dataService?.Animals?.Mammals?.FlyingSquirrels
                    ?.FirstOrDefault(s => s is not null && string.Equals(s.Name, name)));
                if (squirrel is not null)
                {
                    FlyingSquirrel squirrelEdited = AddEditFlyingSquirrel();
                    squirrel.Copy(squirrelEdited);
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 17);
                    squirrel.Display();
                }
                else
                {
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 18);
                }
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 19);
            }
        }

        private FlyingSquirrel AddEditFlyingSquirrel()
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 22);
            string? airSpeedAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 23);
            string? pawSpanAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 24);
            string? furColor = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 25);
            string? habitat = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (airSpeedAsString is null)
            {
                throw new ArgumentNullException(nameof(airSpeedAsString));
            }
            if (pawSpanAsString is null)
            {
                throw new ArgumentNullException(nameof(pawSpanAsString));
            }
            if (furColor is null)
            {
                throw new ArgumentNullException(nameof(furColor));
            }
            if (habitat is null)
            {
                throw new ArgumentNullException(nameof(habitat));
            }

            int age = Int32.Parse(ageAsString);
            int airSpeed = Int32.Parse(airSpeedAsString);
            double pawSpan = Double.Parse(pawSpanAsString);

            FlyingSquirrel squirrel = new FlyingSquirrel(name, age, airSpeed, pawSpan, furColor, habitat);

            return squirrel;
        }

        #endregion // Private Methods
    }

}
