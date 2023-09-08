using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class DogsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    private SettingsService _settingsService;

    public override string ScreenDefinitionJson { get; set; } = "DogsScreenDefinition.json";
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public DogsScreen(IDataService dataService, SettingsService settingsService)
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
            _settingsService.SetConsoleColorForScreen("DogsScreen");
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 6);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                DogsScreenChoices choice = (DogsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case DogsScreenChoices.List:
                        ListDogs();
                        break;

                    case DogsScreenChoices.Create:
                        AddDog(); break;

                    case DogsScreenChoices.Delete: 
                        DeleteDog();
                        break;

                    case DogsScreenChoices.Modify:
                        EditDogMain();
                        break;

                    case DogsScreenChoices.Exit:
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

    /// <summary>
    /// List all dogs.
    /// </summary>
    private void ListDogs()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dogs is not null &&
            _dataService.Animals.Mammals.Dogs.Count > 0)
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 10);
            int i = 1;
            foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
            {
                Console.Write($"Dog number {i}, ");
                dog.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 11);
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddDog()
    {
        try
        {
            Dog dog = AddEditDog();
            _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
            Console.WriteLine("Dog with name: {0} has been added to a list of dogs", dog.Name);
        }
        catch
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 12);
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteDog()
    {
        try
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 13);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                Console.WriteLine("Dog with name: {0} has been deleted from a list of dogs", dog.Name);
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
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditDogMain()
    {
        try
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 16);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                Dog dogEdited = AddEditDog();
                dog.Copy(dogEdited);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 17);
                dog.Display();
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
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Dog AddEditDog()
    {
        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 20);
        string? name = Console.ReadLine();
        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 21);
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 22);
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Dog dog = new Dog(name, age, breed);

        return dog;
    }

    #endregion // Private Methods
}
