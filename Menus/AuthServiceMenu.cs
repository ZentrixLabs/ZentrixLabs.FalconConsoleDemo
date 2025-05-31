using ZentrixLabs.FalconSdk.Services;
using ZentrixLabs.FalconSdk.Configuration;
using ZentrixLabs.FalconConsoleDemo.Models;
using ZentrixLabs.FalconConsoleDemo.Demos;
using ZentrixLabs.FalconConsoleDemo.Utilities;
using Microsoft.Extensions.Options;

namespace ZentrixLabs.FalconConsoleDemo.Menus;

public class AuthServiceMenu
{
    private readonly CrowdStrikeAuthService _authService;
    private readonly CrowdStrikeOptions _options;

    public AuthServiceMenu(CrowdStrikeAuthService authService, CrowdStrikeOptions options)
    {
        _authService = authService;
        _options = options;
    }

    public async Task ShowAsync()
    {
        ConsoleHelpers.DisplayHeader($"{ConsoleHelpers.EmojiOrText("🔑", "[Auth]")} Authentication Service");

        // Prompt the user for credentials
        Console.WriteLine();
        Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter API Base URL (e.g., https://api.crowdstrike.com): ");
        var baseUrlInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(baseUrlInput))
        {
            _options.BaseUrl = baseUrlInput;
        }

        Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter Client ID: ");
        var clientIdInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(clientIdInput))
        {
            _options.ClientId = clientIdInput;
        }

        Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter Client Secret: ");
        var clientSecretInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(clientSecretInput))
        {
            _options.ClientSecret = clientSecretInput;
        }

        Console.WriteLine();

        ExplainAuthentication.DisplayAuthenticationInfo();

        if (ConsoleHelpers.ConfirmRun())
        {
            // Re-initialize auth service with the updated options
            var updatedAuthService = new CrowdStrikeAuthService(new HttpClient(), Options.Create(_options));
            await SdkDemos.DemoAuthenticateAsync(updatedAuthService);
        }
    }
}
