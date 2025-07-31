using System.Collections.Generic;

public static class SecretHandshake
{
    private enum Code
    {
        Wink = 1,
        DoubleBlink = 2,
        CloseEyes = 4,
        Jump = 8,
        Reverse = 16,
    }

    public static string[] Commands(int commandValue)
    {
        List<string> commands = new();
        for (int i = 1; i < 16; i *= 2)
        {
            string code = GetCodeWord(commandValue & i);
            if (!string.IsNullOrEmpty(code))
                commands.Add(code);
        }
        if ((commandValue & (int)Code.Reverse) == (int)Code.Reverse)
            commands.Reverse();

        return commands.ToArray();
    }

    private static string GetCodeWord(int num) =>
        num switch
        {
            (int)Code.Wink => "wink",
            (int)Code.DoubleBlink => "double blink",
            (int)Code.CloseEyes => "close your eyes",
            (int)Code.Jump => "jump",
            _ => string.Empty,
        };
}
