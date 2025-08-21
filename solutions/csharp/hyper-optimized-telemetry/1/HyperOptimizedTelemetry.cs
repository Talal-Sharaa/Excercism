public static class TelemetryBuffer
{
    /// <summary>
    /// Creates a byte array with a prefix byte followed by a specified number of bytes from a source array.
    /// </summary>
    private static byte[] CreateBuffer(byte prefix, byte[] sourceBytes, int count)
    {
        // Create a buffer of the EXACT required size (1 for prefix + count for data)
        byte[] buffer = new byte[9];
        buffer[0] = prefix;
        // Copy the relevant bytes from the source.
        Array.Copy(sourceBytes, 0, buffer, 1, count);
        return buffer;
    }

    public static byte[] ToBuffer(long reading)
    {
        // Get the full 8 bytes of the long once.
        byte[] numberBytes = BitConverter.GetBytes(reading);

        // Check against standard integer type boundaries, which is much clearer.
        // We start with the smallest types and work our way up.

        // Fits in an unsigned 16-bit integer (ushort)?
        if (reading >= ushort.MinValue && reading <= ushort.MaxValue) // 0 to 65,535
        {
            // The original code used prefix 2 for this range.
            return CreateBuffer(2, numberBytes, 2); // 2 bytes for ushort
        }
        // Fits in a signed 16-bit integer (short)?
        else if (reading >= short.MinValue && reading <= short.MaxValue) // -32,768 to 32,767
        {
            // The original code used prefix 254 for negative shorts.
            return CreateBuffer(254, numberBytes, 2); // 2 bytes for short
        }
        // Fits in an unsigned 32-bit integer (uint)?
        else if (reading >= uint.MinValue && reading <= uint.MaxValue) // 0 to 4,294,967,295
        {
            // The original code split this range, but we can combine the logic.
            // Prefix 4 was for the upper half, 252 for the lower half (as part of a signed int).
            // Assuming we can unify the prefix for any 4-byte number.
            // Let's stick to the original logic: check if it's in the signed int positive range first.
             if (reading <= int.MaxValue)
             {
                return CreateBuffer(252, numberBytes, 4);
             }
             else // The rest of the uint range
             {
                return CreateBuffer(4, numberBytes, 4);
             }
        }
        // Fits in a signed 32-bit integer (int)?
        else if (reading >= int.MinValue && reading <= int.MaxValue) // -2,147,483,648 to 2,147,483,647
        {
            // The original code used prefix 252 for this range.
            return CreateBuffer(252, numberBytes, 4); // 4 bytes for int
        }
        // If it doesn't fit in anything smaller, it must be a full long.
        else
        {
            // The original code used prefix 248 for a full long.
            return CreateBuffer(248, numberBytes, 8); // 8 bytes for long
        }
    }


    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length == 0)
        {
            throw new ArgumentException("Buffer cannot be null or empty.");
        }

        // The first byte is the prefix that tells us the data type and length.
        byte prefix = buffer[0];

        switch (prefix)
        {
            // Case for a full 8-byte long
            case 248:
                return BitConverter.ToInt64(buffer, 1);

            // Case for a 4-byte unsigned int (stored in a long)
            case 4:
                 return BitConverter.ToUInt32(buffer, 1);

            // Case for a 4-byte signed int
            case 252:
                return BitConverter.ToInt32(buffer, 1);

            // Case for a 2-byte signed short
            case 254:
                return BitConverter.ToInt16(buffer, 1);

            // Case for a 2-byte unsigned short
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
        }
        return 0;
    }
}
