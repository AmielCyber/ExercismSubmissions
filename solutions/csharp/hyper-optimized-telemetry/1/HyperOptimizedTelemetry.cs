using System;

public static class TelemetryBuffer
{
    private const int BufferLength = 9;
    private const int PrefixSignOffSet = 256;
    private const byte PrefixSignShort =  PrefixSignOffSet - 2;
    private const byte PrefixSignInt =  PrefixSignOffSet - 4;
    private const byte PrefixSignLong =  PrefixSignOffSet - 8;

    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[BufferLength];
        byte preFixByte;
        switch (reading)
        {
            case < int.MinValue:
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                preFixByte = PrefixSignLong;
                break;
            case < short.MinValue:
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                preFixByte = PrefixSignInt;
                break;
            case < 0:
                BitConverter.GetBytes((short)reading).CopyTo(buffer, 1);
                preFixByte = PrefixSignShort;
                break;
            case <= ushort.MaxValue:
                BitConverter.GetBytes((ushort)reading).CopyTo(buffer, 1);
                preFixByte = 2;
                break;
            case <= int.MaxValue:
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                preFixByte = PrefixSignInt;
                break;
            case <= uint.MaxValue:
                BitConverter.GetBytes((uint)reading).CopyTo(buffer, 1);
                preFixByte = 4;
                break;
            default:
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                preFixByte = PrefixSignLong;
                break;
        }

        buffer[0] = preFixByte;
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        PrefixSignShort  => BitConverter.ToInt16(buffer, 1),
        PrefixSignInt or 2 => BitConverter.ToInt32(buffer, 1),
        PrefixSignLong or 4 => BitConverter.ToInt64(buffer, 1),
        _ => 0
    };
}
