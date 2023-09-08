using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    private SettingsService _settingsService;

    public override string ScreenDefinitionJson { get; set; } = "MainScreenDefinition.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        SettingsService settingsService)
    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleColorForScreen("MainScreen");
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        _settingsService.ChangeConsoleColorForScreen();
                        break;

                    case MainScreenChoices.Exit:
                        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
            }
        }
    }

    #endregion // Public Methods
}