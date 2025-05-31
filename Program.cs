namespace ZentrixLabs.FalconConsoleDemo;

using Microsoft.Extensions.Options;
using ZentrixLabs.FalconSdk.Configuration;
using ZentrixLabs.FalconSdk.Services;
using ZentrixLabs.FalconConsoleDemo.Menus;
using ZentrixLabs.FalconConsoleDemo.Utilities;

class Program
{
    static async Task Main(string[] args)
    {
        // Force UTF-8 encoding at startup for emoji support
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        catch
        {
            // Ignore errors; fallback will handle non-UTF8 consoles
        }

        // Print environment check once at app start
        if (!ConsoleHelpers.SupportsEmoji())
        {
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} You're not running inside a fully emoji-supported terminal!");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("💡", "[Info]")} For the best experience (including emoji support), please run this demo in Windows Terminal, VS Code terminal, or PowerShell 7+.");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔐", "[Note]")} You must complete the Authentication Service demo first.");
        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🚫", "[Restriction]")} Device and Spotlight demos require valid authentication.");
        Console.WriteLine();

        // Initialize options but leave them empty so the user can provide them interactively
        var options = new CrowdStrikeOptions();

        // Set up HTTP client
        var httpClient = new HttpClient();

        // Services will be initialized after authentication
        var authService = new CrowdStrikeAuthService(httpClient, Options.Create(options));
        var deviceService = new CrowdStrikeDeviceService(httpClient, authService, Options.Create(options));
        var spotlightService = new CrowdStrikeSpotlightService(httpClient, authService, Options.Create(options));

        // Show main menu
        var mainMenu = new MainMenu(options, authService, deviceService, spotlightService);
        await mainMenu.ShowAsync();
    }
}
