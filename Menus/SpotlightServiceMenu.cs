using ZentrixLabs.FalconSdk.Services;
using ZentrixLabs.FalconConsoleDemo.Models;
using ZentrixLabs.FalconConsoleDemo.Demos;
using ZentrixLabs.FalconConsoleDemo.Utilities;

namespace ZentrixLabs.FalconConsoleDemo.Menus
{
    internal class SpotlightServiceMenu
    {
        private readonly CrowdStrikeSpotlightService _spotlightService;

        public SpotlightServiceMenu(CrowdStrikeSpotlightService spotlightService)
        {
            _spotlightService = spotlightService;
        }

        public async Task ShowAsync()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine();
                ConsoleHelpers.DisplayHeader($"{ConsoleHelpers.EmojiOrText("🔦", "[Spotlight]")} Spotlight Service Options");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("1️⃣ 📝", "1. [IDs]")} Get Vulnerability IDs by AID");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("2️⃣ 🗂️", "2. [Details]")} Get Vulnerability Details by AID");
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
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
