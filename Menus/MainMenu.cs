using ZentrixLabs.FalconConsoleDemo.Utilities;
using ZentrixLabs.FalconSdk.Services;
using ZentrixLabs.FalconSdk.Configuration;

namespace ZentrixLabs.FalconConsoleDemo.Menus;

public class MainMenu
{
    private readonly CrowdStrikeOptions _options;
    private readonly CrowdStrikeAuthService _authService;
    private readonly CrowdStrikeDeviceService _deviceService;
    private readonly CrowdStrikeSpotlightService _spotlightService;

    public MainMenu(
        CrowdStrikeOptions options,
        CrowdStrikeAuthService authService,
        CrowdStrikeDeviceService deviceService,
        CrowdStrikeSpotlightService spotlightService)
    {
        _options = options;
        _authService = authService;
        _deviceService = deviceService;
        _spotlightService = spotlightService;
    }

    public async Task ShowAsync()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            ConsoleHelpers.DisplayHeader($"{ConsoleHelpers.EmojiOrText("🦅🛡️", "[Falcon]")} Falcon SDK Console Demo");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("1️⃣ 🔑", "1. [Auth]")} Authentication Service");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("2️⃣ 🖥️", "2. [Device]")} Device Service");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("3️⃣ 🔦", "3. [Spotlight]")} Spotlight Service");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("0️⃣ 🚪", "0. [Exit]")} Exit");
            Console.Write("👉 Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var authMenu = new AuthServiceMenu(_authService, _options);
                    await authMenu.ShowAsync();
                    break;
                case "2":
                    if (!IsAuthenticated())
                    {
                        Console.WriteLine("⚠️  Please authenticate first using the Authentication Service.");
                        ConsoleHelpers.WaitForUser();
                    }
                    else
                    {
                        var deviceMenu = new DeviceServiceMenu(_deviceService);
                        await deviceMenu.ShowAsync();
                    }
                    break;
                case "3":
                    if (!IsAuthenticated())
                    {
                        Console.WriteLine("⚠️  Please authenticate first using the Authentication Service.");
                        ConsoleHelpers.WaitForUser();
                    }
                    else
                    {
                        var spotlightMenu = new SpotlightServiceMenu(_spotlightService);
                        await spotlightMenu.ShowAsync();
                    }
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Invalid choice. Try again.");
                    break;
            }
        }

        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("👋", "[Goodbye]")} Exiting. Thanks for using the ZentrixLabs Falcon SDK Demo!");
    }

    private bool IsAuthenticated()
    {
        // A quick check: make sure base URL, client ID, and client secret are all provided
        return !string.IsNullOrWhiteSpace(_options.BaseUrl) &&
               !string.IsNullOrWhiteSpace(_options.ClientId) &&
               !string.IsNullOrWhiteSpace(_options.ClientSecret);
    }
}
