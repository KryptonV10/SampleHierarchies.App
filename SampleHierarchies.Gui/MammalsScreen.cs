using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Dogs screen.
    /// </summary>
    private DogsScreen _dogsScreen;

    /// <summary>
    /// Tigers screen.
    /// </summary>
    private TigersScreen _tigersScreen;

    /// <summary>
    /// Flying squirrels screen.
    /// </summary>
    private FlyingSquirrelScreen _flyingSquirrelScreen;

    public override string ScreenDefinitionJson { get; set; } = "MammalsScreenDefinition.json";

    /// <summary>
    /// Hedgehogs screen.
    /// </summary>
    private HedgehogsScreen _hedgehogsScreen;

    private SettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, TigersScreen tigersScreen, FlyingSquirrelScreen flyingSquirrelScreen, HedgehogsScreen hedgehogsScreen, SettingsService settingsService)
    {
        _dogsScreen = dogsScreen;
        _tigersScreen = tigersScreen;
        _flyingSquirrelScreen = flyingSquirrelScreen;
        _hedgehogsScreen = hedgehogsScreen;
        _settingsService = settingsService;

    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.SetConsoleColorForScreen("MammalsScreen");
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

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;

                    case MammalsScreenChoices.Tigers:
                        _tigersScreen.Show();
                        break;

                    case MammalsScreenChoices.FlyingSquirrels:
                        _flyingSquirrelScreen.Show();
                        break;

                    case MammalsScreenChoices.Hedgehogs:
                        _hedgehogsScreen.Show();
                        break;

                    case MammalsScreenChoices.Exit:
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
}
