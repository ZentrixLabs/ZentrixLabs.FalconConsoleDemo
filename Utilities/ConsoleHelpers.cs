namespace ZentrixLabs.FalconConsoleDemo.Utilities;

public static class ConsoleHelpers
{
    private static readonly bool _isWindowsTerminal = IsWindowsTerminal();
    public static bool ConfirmRun()
    {
        Console.Write("👉 Run this demo now? (Y/N): ");
        var input = Console.ReadLine() ?? "";
        return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsWindowsTerminal()
    {
        return Environment.GetEnvironmentVariable("WT_SESSION") != null;
    }

    public static void DisplayHeader(string title)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(title);
        Console.WriteLine("========================================");
    }
    public static void WaitForUser()
    {
        Console.WriteLine();
        Console.Write("👉 Press Enter to return to the menu...");
        Console.ReadLine();
    }

    public static string EmojiOrText(string emoji, string fallbackText)
    {
        return _isWindowsTerminal ? emoji : fallbackText;
    }

}
