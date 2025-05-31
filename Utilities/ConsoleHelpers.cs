namespace ZentrixLabs.FalconConsoleDemo.Utilities;

public static class ConsoleHelpers
{
    private static readonly bool _supportsEmoji = SupportsEmoji();

    static ConsoleHelpers()
    {
        // Attempt to set UTF-8 encoding for emoji support
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        catch
        {
            // Ignore — fallback will handle if console can't handle UTF-8
        }
    }

    public static bool ConfirmRun()
    {
        Console.Write($"{EmojiOrText("👉", "[>]")} Run this demo now? (Y/N): ");
        var input = Console.ReadLine() ?? "";
        return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
    }

    public static bool SupportsEmoji()
    {
        // Check Windows Terminal
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WT_SESSION")))
            return true;

        // Check VS Code's integrated terminal
        var termProgram = Environment.GetEnvironmentVariable("TERM_PROGRAM");
        if (!string.IsNullOrEmpty(termProgram) &&
            termProgram.Contains("vscode", StringComparison.OrdinalIgnoreCase))
            return true;

        // Check PowerShell 7+
        if (Environment.Version.Major >= 7)
            return true;

        return false;
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
        Console.Write($"{EmojiOrText("👉", "[>]")} Press Enter to return to the menu...");
        Console.ReadLine();
    }

    public static string EmojiOrText(string emoji, string fallbackText)
    {
        return _supportsEmoji ? emoji : fallbackText;
    }

    public static void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch
        {
            // Ignore errors in case the console doesn't support it
        }
    }

}
// This file is part of the ZentrixLabs Falcon Console Demo project.
// It provides utility methods for console interactions, including emoji support detection.