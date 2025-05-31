using ZentrixLabs.FalconSdk.Services;
using ZentrixLabs.FalconConsoleDemo.Models;
using ZentrixLabs.FalconConsoleDemo.Demos;
using ZentrixLabs.FalconConsoleDemo.Utilities;

namespace ZentrixLabs.FalconConsoleDemo.Menus
{
    internal class DeviceServiceMenu
    {
        private readonly CrowdStrikeDeviceService _deviceService;

        public DeviceServiceMenu(CrowdStrikeDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public async Task ShowAsync()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine();
                ConsoleHelpers.DisplayHeader($"{ConsoleHelpers.EmojiOrText("🖥️", "[Device]")} Device Service Options");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("1️⃣ 🔍", "1. [Get IDs]")} Get Device IDs by Hostname");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("2️⃣ 🔎", "2. [Get Details]")} Get Device Details by AID");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("0️⃣ 🔙", "0. [Back]")} Back to Main Menu");
                Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ExplainDeviceService.DisplayDeviceServiceInfo();
                        if (ConsoleHelpers.ConfirmRun())
                            await SdkDemos.DemoGetDeviceIdsAsync(_deviceService);
                        break;
                    case "2":
                        ExplainDeviceService.DisplayDeviceServiceInfo();
                        if (ConsoleHelpers.ConfirmRun())
                            await SdkDemos.DemoGetDeviceDetailsAsync(_deviceService);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} Invalid choice.");
                        break;
                }
            }
        }
    }
}
