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
    public sealed class HedgehogsScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        private SettingsService _settingsService;

        public override string ScreenDefinitionJson { get; set; } = "HedgehogsScreenDefinition.json";
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public HedgehogsScreen(IDataService dataService, SettingsService settingsService)
        {
            _dataService = dataService;
            _settingsService = settingsService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                _settingsService.SetConsoleColorForScreen("HedgehogsScreen");
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    HedgehogsScreenChoices choice = (HedgehogsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case HedgehogsScreenChoices.List:
                            ListHedgehogs();
                            break;

                        case HedgehogsScreenChoices.Create:
                            AddHedgehog(); break;

                        case HedgehogsScreenChoices.Delete:
                            DeleteHedgehog();
                            break;

                        case HedgehogsScreenChoices.Modify:
                            EditHedgehogMain();
                            break;

                        case HedgehogsScreenChoices.Exit:
                            Console.ResetColor();
                            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);
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

        /// <summary>
        /// List all hedgehogs.
        /// </summary>
        private void ListHedgehogs()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Hedgehogs is not null &&
                _dataService.Animals.Mammals.Hedgehogs.Count > 0)
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 10);
                int i = 1;
                foreach (Hedgehog hedgehog in _dataService.Animals.Mammals.Hedgehogs)
                {
                    Console.Write($"Hedgehog number {i}, ");
                    hedgehog.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 11);
            }
        }

        /// <summary>
        /// Add a hedgehog.
        /// </summary>
        private void AddHedgehog()
        {
            try
            {
                Hedgehog hedgehog = AddEditHedgehog();
                _dataService?.Animals?.Mammals?.Hedgehogs?.Add(hedgehog);
                Console.WriteLine("Hedgehog with name: {0} has been added to a list of hedgehogs", hedgehog.Name);
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 12);
            }
        }

        /// <summary>
        /// Deletes a hedgehog.
        /// </summary>
        private void DeleteHedgehog()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 13);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs
                    ?.FirstOrDefault(h => h is not null && string.Equals(h.Name, name)));
                if (hedgehog is not null)
                {
                    _dataService?.Animals?.Mammals?.Hedgehogs?.Remove(hedgehog);
                    Console.WriteLine("Hedgehog with name: {0} has been deleted from a list of hedgehogs", hedgehog.Name);
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

        /// <summary>
        /// Edits an existing hedgehog after choice made.
        /// </summary>
        private void EditHedgehogMain()
        {
            try
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 16);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Hedgehog? hedgehog = (Hedgehog?)(_dataService?.Animals?.Mammals?.Hedgehogs
                    ?.FirstOrDefault(h => h is not null && string.Equals(h.Name, name)));
                if (hedgehog is not null)
                {
                    Hedgehog hedgehogEdited = AddEditHedgehog();
                    hedgehog.Copy(hedgehogEdited);
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 17);
                    hedgehog.Display();
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

        /// <summary>
        /// Adds/edit specific hedgehog.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Hedgehog AddEditHedgehog()
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 20);
            string? name = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 21);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 22);
            string? spinesLengthAsString = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 23);
            string? diet = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 24);
            string? colorOfQuills = Console.ReadLine();
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 25);
            string? numberOfSpikesAsString = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (spinesLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(spinesLengthAsString));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            if (colorOfQuills is null)
            {
                throw new ArgumentNullException(nameof(colorOfQuills));
            }
            if (numberOfSpikesAsString is null)
            {
                throw new ArgumentNullException(nameof(numberOfSpikesAsString));
            }

            int age = Int32.Parse(ageAsString);
            int spinesLength = Int32.Parse(spinesLengthAsString);
            int numberOfSpikes = Int32.Parse(numberOfSpikesAsString);

            Hedgehog hedgehog = new Hedgehog(name, age, spinesLength, diet, colorOfQuills, numberOfSpikes);

            return hedgehog;
        }

        #endregion // Private Methods
    }

}
