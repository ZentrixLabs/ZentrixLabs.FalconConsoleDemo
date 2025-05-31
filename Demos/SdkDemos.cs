using System;
using ZentrixLabs.FalconConsoleDemo.Utilities;
using ZentrixLabs.FalconSdk.Services;

namespace ZentrixLabs.FalconConsoleDemo.Demos
{
    public class SdkDemos
    {
        public static async Task DemoAuthenticateAsync(CrowdStrikeAuthService authService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔑", "[Auth]")} Demo: Authentication");

            try
            {
                var token = await authService.GetAccessTokenAsync();
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Successfully authenticated! Token length: {token.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Authentication failed: {ex.Message}");
            }

            ConsoleHelpers.WaitForUser();
        }

        public static async Task DemoGetDeviceIdsAsync(CrowdStrikeDeviceService deviceService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔍", "[Device IDs]")} Demo: Get Device IDs by Hostname");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a hostname: ");
            var hostname = Console.ReadLine() ?? "";

            try
            {
                var deviceIds = await deviceService.GetDeviceIdsAsync(hostname);
                if (deviceIds.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} No device IDs found for that hostname.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found device IDs:");
                    foreach (var id in deviceIds)
                    {
                        Console.WriteLine($" - {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching device IDs: {ex.Message}");
            }

            Console.WriteLine();
            ConsoleHelpers.WaitForUser();
        }

        public static async Task DemoGetDeviceDetailsAsync(CrowdStrikeDeviceService deviceService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔍", "[Device Details]")} Demo: Get Device Details by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID): ");
            var aid = Console.ReadLine() ?? "";

            try
            {
                var details = await deviceService.GetDeviceDetailsAsync(aid);
                if (details == null)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} No details found for this AID.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Device ID: {details.DeviceId}");
                    Console.WriteLine($"   Hostname: {details.Hostname}");
                    Console.WriteLine($"   OS: {details.OSVersion}");
                    Console.WriteLine($"   Kernel: {details.KernelVersion}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching device details: {ex.Message}");
            }

            Console.WriteLine();
            ConsoleHelpers.WaitForUser();
        }

        public static async Task DemoGetVulnerabilityIdsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔦", "[Vuln IDs]")} Demo: Get Vulnerability IDs by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID): ");
            var aid = Console.ReadLine() ?? "";

            try
            {
                var vulnIds = await spotlightService.GetVulnerabilityIdsForHostAsync(aid);
                if (vulnIds.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} No vulnerabilities found for this device.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found {vulnIds.Count} vulnerability IDs:");
                    foreach (var id in vulnIds)
                    {
                        Console.WriteLine($" - {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching vulnerability IDs: {ex.Message}");
            }

            Console.WriteLine();
            ConsoleHelpers.WaitForUser();
        }

        public static async Task DemoGetVulnerabilityDetailsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔦", "[Vuln Details]")} Demo: Get Vulnerability Details by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID): ");
            var aid = Console.ReadLine() ?? "";

            try
            {
                var vulnDetails = await spotlightService.GetVulnerabilityDetailsAsync(aid);
                if (vulnDetails.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} No vulnerability details found for this device.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found {vulnDetails.Count} vulnerabilities:");
                    foreach (var vuln in vulnDetails)
                    {
                        Console.WriteLine($" - CVE: {vuln.Cve.Id}");
                        Console.WriteLine($"   Severity: {vuln.Severity}");
                        Console.WriteLine($"   Status: {vuln.Status}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching vulnerability details: {ex.Message}");
            }

            Console.WriteLine();
            ConsoleHelpers.WaitForUser();
        }
    }
}
