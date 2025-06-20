using System;
using ZentrixLabs.FalconConsoleDemo.Models;
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
            ConsoleHelpers.ClearScreen();
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

                    DemoContext.LastUsedAid = deviceIds.FirstOrDefault();
                    if (!string.IsNullOrEmpty(DemoContext.LastUsedAid))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{ConsoleHelpers.EmojiOrText("💡", "[Tip]")} The first AID has been saved and can be reused in other demos.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching device IDs: {ex.Message}");
            }

            Console.WriteLine();
            ConsoleHelpers.WaitForUser();
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetDeviceDetailsAsync(CrowdStrikeDeviceService deviceService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔍", "[Device Details]")} Demo: Get Device Details by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID)");
            if (!string.IsNullOrEmpty(DemoContext.LastUsedAid))
            {
                Console.Write($" [{DemoContext.LastUsedAid}]: ");
            }
            else
            {
                Console.Write(": ");
            }

            var input = Console.ReadLine();
            var aid = string.IsNullOrWhiteSpace(input) ? DemoContext.LastUsedAid : input;

            if (string.IsNullOrWhiteSpace(aid))
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} No device ID (AID) provided. Returning to menu.");
                ConsoleHelpers.WaitForUser();
                ConsoleHelpers.ClearScreen();
                return;
            }

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
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetVulnerabilityIdsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔦", "[Vuln IDs]")} Demo: Get Vulnerability IDs by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID)");
            if (!string.IsNullOrEmpty(DemoContext.LastUsedAid))
            {
                Console.Write($" [{DemoContext.LastUsedAid}]: ");
            }
            else
            {
                Console.Write(": ");
            }

            var input = Console.ReadLine();
            var aid = string.IsNullOrWhiteSpace(input) ? DemoContext.LastUsedAid : input;

            if (string.IsNullOrWhiteSpace(aid))
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} No device ID (AID) provided. Returning to menu.");
                ConsoleHelpers.WaitForUser();
                ConsoleHelpers.ClearScreen();
                return;
            }

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
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetVulnerabilityDetailsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔦", "[Vuln Details]")} Demo: Get Vulnerability Details by AID");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a device ID (AID)");
            if (!string.IsNullOrEmpty(DemoContext.LastUsedAid))
            {
                Console.Write($" [{DemoContext.LastUsedAid}]: ");
            }
            else
            {
                Console.Write(": ");
            }

            var input = Console.ReadLine();
            var aid = string.IsNullOrWhiteSpace(input) ? DemoContext.LastUsedAid : input;

            if (string.IsNullOrWhiteSpace(aid))
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("⚠️", "[Warning]")} No device ID (AID) provided. Returning to menu.");
                ConsoleHelpers.WaitForUser();
                ConsoleHelpers.ClearScreen();
                return;
            }

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
            ConsoleHelpers.ClearScreen();
        }
        public static async Task DemoGetVulnerabilityHostsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🖥️", "[Hosts]")} Demo: Get Vulnerability Hosts");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a filter (or leave blank for all): ");
            var filter = Console.ReadLine();

            try
            {
                var result = await spotlightService.GetVulnerabilityHostsAsync(string.IsNullOrWhiteSpace(filter) ? null : filter);
                if (result.Data.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} No hosts found.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found {result.Data.Count} hosts:");
                    foreach (var host in result.Data)
                    {
                        Console.WriteLine($" - {host.Hostname} (AID: {host.Aid})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching hosts: {ex.Message}");
            }

            ConsoleHelpers.WaitForUser();
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetVulnerabilityRemediationsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🛠️", "[Remediations]")} Demo: Get Vulnerability Remediations");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a filter (or leave blank for all): ");
            var filter = Console.ReadLine();

            try
            {
                var result = await spotlightService.GetVulnerabilityRemediationsAsync(string.IsNullOrWhiteSpace(filter) ? null : filter);
                if (result.Data.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} No remediations found.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found {result.Data.Count} remediations:");
                    foreach (var remediation in result.Data)
                    {
                        Console.WriteLine($" - {remediation.Name} (ID: {remediation.Id})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching remediations: {ex.Message}");
            }

            ConsoleHelpers.WaitForUser();
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetVulnerabilityCountsAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("5️⃣", "[Counts]")} Demo: Get Vulnerability Counts");
            Console.Write($"{ConsoleHelpers.EmojiOrText("👉", "[Input]")} Enter a filter (or leave blank for all): ");
            var filter = Console.ReadLine();

            try
            {
                var vulnCount = await spotlightService.GetVulnerabilityCountAsync(string.IsNullOrWhiteSpace(filter) ? null : filter);
                var hostCount = await spotlightService.GetVulnerabilityHostCountAsync(string.IsNullOrWhiteSpace(filter) ? null : filter);
                var remediationCount = await spotlightService.GetVulnerabilityRemediationCountAsync(string.IsNullOrWhiteSpace(filter) ? null : filter);

                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Vulnerability Count: {vulnCount.Data}");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Host Count: {hostCount.Data}");
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Remediation Count: {remediationCount.Data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching counts: {ex.Message}");
            }

            ConsoleHelpers.WaitForUser();
            ConsoleHelpers.ClearScreen();
        }

        public static async Task DemoGetEvaluationLogicAsync(CrowdStrikeSpotlightService spotlightService)
        {
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🧠", "[Eval Logic]")} Demo: Get Evaluation Logic");

            try
            {
                var result = await spotlightService.GetVulnerabilityEvaluationLogicAsync();
                if (result.Data.Count == 0)
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} No evaluation logic found.");
                }
                else
                {
                    Console.WriteLine($"{ConsoleHelpers.EmojiOrText("✅", "[Success]")} Found {result.Data.Count} evaluation logic entries:");
                    foreach (var logic in result.Data)
                    {
                        Console.WriteLine($" - {logic.Name} (ID: {logic.Id})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔥", "[Error]")} Error fetching evaluation logic: {ex.Message}");
            }

            ConsoleHelpers.WaitForUser();
            ConsoleHelpers.ClearScreen();
        }
    }
    
}
// This code provides methods for various SDK demos, including authentication, fetching device IDs, and vulnerability details.
// Each method interacts with the respective service and handles user input/output, including error handling and displaying results.