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
    public sealed class TigersScreen : Screen
    {
        #region Properties and Constructor

        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "TigersScreenDefinition.json";

        public TigersScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.SetConsoleColorForScreen("TigersSreen");
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

                    TigersScreenChoices choice = (TigersScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case TigersScreenChoices.List:
                            ListTigers();
                            break;

                        case TigersScreenChoices.Create:
                            AddTiger();
                            break;

                        case TigersScreenChoices.Delete:
                            DeleteTiger();
                            break;

                        case TigersScreenChoices.Modify:
                            EditTigerMain();
                            break;

                        case TigersScreenChoices.Exit:
                            Console.ResetColor();
                            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson,9);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void ListTigers()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Tigers is not null &&
                _dataService.Animals.Mammals.Tigers.Count > 0)
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (Tiger tiger in _dataService.Animals.Mammals.Tigers)
                {
                    Console.Write($"Tiger number {i}, ");
                    tiger.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 11);
            }
        }

        private void AddTiger()
        {
            try
            {
                Tiger tiger = AddEditTiger();
                _dataService?.Animals?.Mammals?.Tigers?.Add(tiger);
                Console.WriteLine("Tiger with name: {0} has been added to the list of tigers", tiger.Name);
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 12);
            }
        }

        private void DeleteTiger()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Tiger? tiger = (Tiger?)(_dataService?.Animals?.Mammals?.Tigers
                    ?.FirstOrDefault(t => t is not null && string.Equals(t.Name, name)));
                if (tiger is not null)
                {
                    _dataService?.Animals?.Mammals?.Tigers?.Remove(tiger);
                    Console.WriteLine("Tiger with name: {0} has been deleted from the list of tigers", tiger.Name);
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

        private void EditTigerMain()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Tiger? tiger = (Tiger?)(_dataService?.Animals?.Mammals?.Tigers
                    ?.FirstOrDefault(t => t is not null && string.Equals(t.Name, name)));
                if (tiger is not null)
                {
                    Tiger tigerEdited = AddEditTiger();
                    tiger.Copy(tigerEdited);
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 17);
                    tiger.Display();
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

        private Tiger AddEditTiger()
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 22);
            string? countOfStripsAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 23);
            string? lengthOfToothAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 24);
            string? packHunting = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 25);
            string? kindOf = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (countOfStripsAsString is null)
            {
                throw new ArgumentNullException(nameof(countOfStripsAsString));
            }
            if (lengthOfToothAsString is null)
            {
                throw new ArgumentNullException(nameof(lengthOfToothAsString));
            }
            if (packHunting is null)
            {
                throw new ArgumentNullException(nameof(packHunting));
            }
            if (kindOf is null)
            {
                throw new ArgumentNullException(nameof(kindOf));
            }

            int age = Int32.Parse(ageAsString);
            int countOfStrips = Int32.Parse(countOfStripsAsString);
            double lengthOfTooth = Double.Parse(lengthOfToothAsString);

            Tiger tiger = new Tiger(name, age, countOfStrips, lengthOfTooth, packHunting, kindOf);

            return tiger;
        }

        #endregion // Private Methods
    }

}
