using System;
using ZentrixLabs.FalconConsoleDemo.Utilities;

namespace ZentrixLabs.FalconConsoleDemo.Models
{
    public static class ExplainAuthentication
    {
        public static void DisplayAuthenticationInfo()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("🔑", "[Auth]")} CrowdStrikeAuthService");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("This service handles OAuth2 authentication with the CrowdStrike API.");
            Console.WriteLine("It retrieves and caches an access token, refreshing it when needed.");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("📦", "[Class]")} SDK Class: ZentrixLabs.FalconSdk.Services.CrowdStrikeAuthService");
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("👉", "[Method]")} Method: GetAccessTokenAsync()");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("💡", "[Usage]")} Usage:");
            Console.WriteLine("Call this method before making other API calls to ensure you have a valid token.");
            Console.WriteLine("It handles caching and expiry behind the scenes.");
            Console.WriteLine();
            Console.WriteLine($"{ConsoleHelpers.EmojiOrText("📄", "[Code]")} Code Snippet:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("// using statements");
            Console.WriteLine("using ZentrixLabs.FalconSdk.Services;");
            Console.WriteLine("using ZentrixLabs.FalconSdk.Configuration;");
            Console.WriteLine("using Microsoft.Extensions.Options;");
            Console.WriteLine();
            Console.WriteLine("// Setup your CrowdStrikeOptions");
            Console.WriteLine("var options = new CrowdStrikeOptions");
            Console.WriteLine("{");
            Console.WriteLine("    BaseUrl = \"https://api.crowdstrike.com\",");
            Console.WriteLine("    ClientId = \"<your-client-id>\",");
            Console.WriteLine("    ClientSecret = \"<your-client-secret>\"");
            Console.WriteLine("};");
            Console.WriteLine();
            Console.WriteLine("// Create the HTTP client and authentication service");
            Console.WriteLine("var httpClient = new HttpClient();");
            Console.WriteLine("var authService = new CrowdStrikeAuthService(httpClient, Options.Create(options));");
            Console.WriteLine();
            Console.WriteLine("// Option 1: Async context (recommended)");
            Console.WriteLine("public static async Task AuthenticateAsync()");
            Console.WriteLine("{");
            Console.WriteLine("    var token = await authService.GetAccessTokenAsync();");
            Console.WriteLine("    Console.WriteLine($\"Access Token: {token}\");");
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("// Option 2: Synchronous context (e.g. in Main)");
            Console.WriteLine("var token = authService.GetAccessTokenAsync().GetAwaiter().GetResult();");
            Console.WriteLine("Console.WriteLine($\"Access Token: {token}\");");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
// This code provides a detailed explanation of the CrowdStrike authentication process,
// including how to use the `CrowdStrikeAuthService` to obtain an access token.