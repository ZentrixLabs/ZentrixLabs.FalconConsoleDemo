using System;
using ZentrixLabs.FalconConsoleDemo.Utilities;

namespace ZentrixLabs.FalconConsoleDemo.Models
{
    public static class ExplainDeviceService
    {
        public static void DisplayDeviceServiceInfo()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🖥️", "[Device]")} CrowdStrikeDeviceService");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("This service provides methods to retrieve device information from the CrowdStrike Falcon API.");
            Console.WriteLine("It can fetch device IDs by hostname, retrieve device details by ID, and list all servers.");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("📦", "[Class]")} SDK Class: ZentrixLabs.FalconSdk.Services.CrowdStrikeDeviceService");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("👉", "[Methods]")} Key Methods:");
            Console.WriteLine("   - GetDeviceIdsAsync(string hostname)");
            Console.WriteLine("   - GetDeviceDetailsAsync(string aid)");
            Console.WriteLine("   - GetAllServerDevicesAsync()");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("💡", "[Usage]")} Usage:");
            Console.WriteLine("Call GetAccessTokenAsync() from the AuthService first, then use these methods to interact with devices.");
            Console.WriteLine("The service handles pagination and filtering for server-type devices.");
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
            Console.WriteLine("var deviceService = new CrowdStrikeDeviceService(httpClient, authService, Options.Create(options));");
            Console.WriteLine();
            Console.WriteLine("// Option 1: Async context (recommended)");
            Console.WriteLine("public static async Task QueryDevicesAsync()");
            Console.WriteLine("{");
            Console.WriteLine("    var deviceIds = await deviceService.GetDeviceIdsAsync(\"your-hostname\");");
            Console.WriteLine("    foreach (var id in deviceIds)");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine($\"Found device ID: {id}\");");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    if (deviceIds.Any())");
            Console.WriteLine("    {");
            Console.WriteLine("        var deviceDetail = await deviceService.GetDeviceDetailsAsync(deviceIds.First());");
            Console.WriteLine("        if (deviceDetail != null)");
            Console.WriteLine("        {");
            Console.WriteLine("            Console.WriteLine($\"Hostname: {deviceDetail.Hostname}, OS: {deviceDetail.OSVersion}\");");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("// Option 2: Synchronous context (use with caution in console apps)");
            Console.WriteLine("var deviceIds = deviceService.GetDeviceIdsAsync(\"your-hostname\").GetAwaiter().GetResult();");
            Console.WriteLine("foreach (var id in deviceIds)");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine($\"Found device ID: {id}\");");
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("if (deviceIds.Any())");
            Console.WriteLine("{");
            Console.WriteLine("    var deviceDetail = deviceService.GetDeviceDetailsAsync(deviceIds.First()).GetAwaiter().GetResult();");
            Console.WriteLine("    if (deviceDetail != null)");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine($\"Hostname: {deviceDetail.Hostname}, OS: {deviceDetail.OSVersion}\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
// This code provides a detailed explanation of the CrowdStrike device service,
// including how to use the `CrowdStrikeDeviceService` to retrieve device information.