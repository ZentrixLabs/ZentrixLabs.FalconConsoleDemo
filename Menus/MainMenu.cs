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
            ConsoleHelpers.DisplayHeader($"{ConsoleHelpers.EmojiOrText("🔦", "[Spotlight]")} Spotlight Service Options");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("1️⃣ 📝", "1. [IDs]")} Get Vulnerability IDs by AID");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("2️⃣ 🗂️", "2. [Details]")} Get Vulnerability Details by AID");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("3️⃣ 🖥️", "3. [Hosts]")} Get Vulnerability Hosts");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("4️⃣ 🛠️", "4. [Remediations]")} Get Vulnerability Remediations");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("5️⃣ #️⃣", "5. [Counts]")} Get Vulnerability Counts");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("6️⃣ 🧠", "6. [Eval Logic]")} Get Evaluation Logic");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("0️⃣ 🔙", "0. [Back]")} Back to Main Menu");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExplainSpotlightService.DisplaySpotlightServiceInfo();
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetVulnerabilityIdsAsync(_spotlightService);
                    break;
                case "2":
                    ExplainSpotlightService.DisplaySpotlightServiceInfo();
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetVulnerabilityDetailsAsync(_spotlightService);
                    break;
                case "3":
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetVulnerabilityHostsAsync(_spotlightService);
                    break;
                case "4":
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetVulnerabilityRemediationsAsync(_spotlightService);
                    break;
                case "5":
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetVulnerabilityCountsAsync(_spotlightService);
                    break;
                case "6":
                    if (ConsoleHelpers.ConfirmRun())
                        await SdkDemos.DemoGetEvaluationLogicAsync(_spotlightService);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} Invalid choice.");
                    break;
            }

            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("👋", "[Goodbye]")} Exiting. Thanks for using the ZentrixLabs Falcon SDK Demo!");
        }
    }

    private bool IsAuthenticated()
    {
        // A quick check: make sure base URL, client ID, and client secret are all provided
        return !string.IsNullOrWhiteSpace(_options.BaseUrl) &&
               !string.IsNullOrWhiteSpace(_options.ClientId) &&
               !string.IsNullOrWhiteSpace(_options.ClientSecret);
    }
}
