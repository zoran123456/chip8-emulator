// Chip8Memory.cs
// Minimal Chip-8 interpreter component
// Handles all memory storage and retrieval for the Chip-8 system.

namespace Chip8Emulator
{
    /// <summary>
    /// Handles memory storage and retrieval for the Chip-8 system.
    /// Chip-8 has 4KB (4096 bytes) of memory, addressed from 0x000 to 0xFFF.
    /// Addresses 0x000–0x1FF are reserved; programs typically start at 0x200.
    /// </summary>
    public class Chip8Memory
    {
        /// <summary>
        /// Total memory size for Chip-8 (4KB).
        /// </summary>
        public const int MemorySize = 0x1000; // 4096 bytes

        // Internal memory array representing Chip-8 RAM
        private readonly byte[] memory = new byte[MemorySize];

        /// <summary>
        /// Reads a byte from the specified memory address.
        /// Throws ArgumentOutOfRangeException if address is not in 0x000–0xFFF.
        /// </summary>
        public byte ReadByte(ushort address)
        {
            if (address >= MemorySize)
                throw new ArgumentOutOfRangeException(nameof(address), $"Address 0x{address:X3} is out of bounds.");
            return memory[address];
        }

        /// <summary>
        /// Writes a byte to the specified memory address.
        /// Throws ArgumentOutOfRangeException if address is not in 0x000–0xFFF.
        /// </summary>
        public void WriteByte(ushort address, byte value)
        {
            if (address >= MemorySize)
                throw new ArgumentOutOfRangeException(nameof(address), $"Address 0x{address:X3} is out of bounds.");
            memory[address] = value;
        }

        /// <summary>
        /// Loads a byte array (program) into memory starting at the given address.
        /// Throws ArgumentOutOfRangeException if the data would exceed memory bounds.
        /// </summary>
        public void LoadBytes(ushort startAddress, byte[] data)
        {
            if (startAddress + data.Length > MemorySize)
                throw new ArgumentOutOfRangeException(nameof(data), "Program data exceeds memory bounds.");
            Array.Copy(data, 0, memory, startAddress, data.Length);
        }
    }
}
