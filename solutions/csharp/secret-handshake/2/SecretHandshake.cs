using System.Collections.Generic;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        List<string> commands = new();
        if ((commandValue & 0b_0001) != 0)
            commands.Add("wink");
        if ((commandValue & 0b_0010) != 0)
            commands.Add("double blink");
        if ((commandValue & 0b_0100) != 0)
            commands.Add("close your eyes");
        if ((commandValue & 0b_1000) != 0)
            commands.Add("jump");
        if ((commandValue & 0b_0001_0000) != 0)
            commands.Reverse();
        return commands.ToArray();
    }
}
