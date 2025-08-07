public static class VariableLengthQuantity
{
    private const uint SevenBitMask = 0x7Fu;
    private const uint ByteMask = 0xFFu;
    private const uint LastBit = 0x80u;
    private const int Bits = 7;

    public static uint[] Encode(uint[] numbers)
    {
        List<uint> bytes = new();
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            uint number = numbers[i];
            uint _byte = number & SevenBitMask;
            bytes.Add(_byte);
            number >>= Bits;
            while (number > 0)
            {
                _byte = (number & SevenBitMask) | LastBit;
                bytes.Add(_byte);
                number >>= Bits;
            }
        }
        bytes.Reverse();
        return bytes.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        List<uint> numbers = new();
        int index = 0;
        while (index < bytes.Length)
        {
            uint number = 0;
            while (index < bytes.Length)
            {
                number |= bytes[index] & SevenBitMask;
                if (IsLastByte(bytes[index]))
                {
                    if ((bytes[index] & ByteMask) == ByteMask)
                        number >>= 1;
                    break;
                }
                if(index + 1 == bytes.Length)
                    throw new InvalidOperationException("Last byte in the list is not marked as last byte.");
                number <<= Bits;
                index++;
            }
            numbers.Add(number);
            index++;
        }
        return numbers.ToArray();
    }
    
    private static bool IsLastByte(uint _byte) => (_byte & LastBit) == 0;
}
