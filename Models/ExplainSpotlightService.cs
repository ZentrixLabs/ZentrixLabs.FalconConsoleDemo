using System;
using ZentrixLabs.FalconConsoleDemo.Utilities;

namespace ZentrixLabs.FalconConsoleDemo.Models
{
    public static class ExplainSpotlightService
    {
        public static void DisplaySpotlightServiceInfo()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔦", "[Spotlight]")} CrowdStrikeSpotlightService");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("This service provides methods to interact with the CrowdStrike Spotlight API to retrieve vulnerability data.");
            Console.WriteLine("It supports fetching vulnerability IDs for a device and getting detailed vulnerability information.");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("📦", "[Class]")} SDK Class: ZentrixLabs.FalconSdk.Services.CrowdStrikeSpotlightService");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("👉", "[Methods]")} Key Methods:");
            Console.WriteLine("   - GetVulnerabilityIdsForHostAsync(string aid)");
            Console.WriteLine("   - GetVulnerabilityDetailsAsync(string aid, List<string>? vulnIds = null, ...)");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("💡", "[Usage]")} Usage:");
            Console.WriteLine("Use the AID from the DeviceService to get vulnerability IDs and then details.");
            Console.WriteLine("You can use filters and facets to refine results.");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("📄", "[Code]")} Code Snippet:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("// using statements");
            Console.WriteLine("using ZentrixLabs.FalconSdk.Services;");
            Console.WriteLine("using ZentrixLabs.FalconSdk.Configuration;");
            Console.WriteLine("using Microsoft.Extensions.Options;");
            Console.WriteLine();
            Console.WriteLine("// Setup options");
            Console.WriteLine("var options = new CrowdStrikeOptions");
            Console.WriteLine("{");
            Console.WriteLine("    BaseUrl = \"https://api.crowdstrike.com\",");
            Console.WriteLine("    ClientId = \"<your-client-id>\",");
            Console.WriteLine("    ClientSecret = \"<your-client-secret>\"");
            Console.WriteLine("};");
            Console.WriteLine();
            Console.WriteLine("// Create HTTP client and services");
            Console.WriteLine("var httpClient = new HttpClient();");
            Console.WriteLine("var authService = new CrowdStrikeAuthService(httpClient, Options.Create(options));");
            Console.WriteLine("var spotlightService = new CrowdStrikeSpotlightService(httpClient, authService, Options.Create(options));");
            Console.WriteLine();
            Console.WriteLine("// Example: Get vulnerability IDs for a device");
            Console.WriteLine("var deviceAid = \"<your-device-aid>\";");
            Console.WriteLine("var vulnIds = await spotlightService.GetVulnerabilityIdsForHostAsync(deviceAid);");
            Console.WriteLine("Console.WriteLine($\"Found {vulnIds.Count} vulnerability IDs.\");");
            Console.WriteLine();
            Console.WriteLine("// Example: Get detailed vulnerability info");
            Console.WriteLine("var vulnDetails = await spotlightService.GetVulnerabilityDetailsAsync(deviceAid);");
            Console.WriteLine("foreach (var vuln in vulnDetails)");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine($\"CVE: {vuln.Cve.Id}, Severity: {vuln.Severity}, Status: {vuln.Status}\");");
            Console.WriteLine("}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
