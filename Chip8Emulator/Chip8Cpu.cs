// Chip8Cpu.cs
// Minimal Chip-8 interpreter component
// Handles registers, instruction cycle (fetch/decode/execute), and coordinates with memory.

namespace Chip8Emulator
{
    /// <summary>
    /// Handles registers, instruction cycle (fetch/decode/execute), and coordinates with memory.
    /// </summary>
    public class Chip8Cpu
    {
        /// <summary>
        /// 16 general-purpose 8-bit registers V0 through VF.
        /// VF (V[15]) is used as a flag for some instructions (carry, borrow, collision).
        /// </summary>
        public byte[] V { get; } = new byte[16];

        /// <summary>
        /// 16-bit Index register (I), typically used for memory addresses.
        /// </summary>
        public ushort I { get; set; }

        /// <summary>
        /// 16-bit Program Counter (PC). Starts at 0x200, where Chip-8 programs begin.
        /// </summary>
        public ushort PC { get; set; }

        /// <summary>
        /// Reference to the Chip-8 memory module.
        /// </summary>
        public Chip8Memory Memory { get; }

        // Note: A real Chip-8 would have a stack for subroutine calls (up to 12-16 levels),
        // but this minimal emulator omits it for simplicity.

        /// <summary>
        /// Initializes the CPU state and links to memory.
        /// </summary>
        public Chip8Cpu(Chip8Memory memory)
        {
            Memory = memory;
            Initialize();
        }

        /// <summary>
        /// Resets all registers and pointers to their initial state.
        /// </summary>
        public void Initialize()
        {
            for (int i = 0; i < V.Length; i++) V[i] = 0;
            I = 0;
            PC = 0x200; // Programs start at 0x200; 0x000-0x1FF is reserved.
        }

        /// <summary>
        /// Executes one CPU cycle: fetch, decode, and execute an instruction.
        /// </summary>
        public void Cycle()
        {
            // Fetch: Read two bytes from memory at PC and PC+1, combine into 16-bit opcode
            byte highByte = Memory.ReadByte(PC);
            byte lowByte = Memory.ReadByte((ushort)(PC + 1));
            ushort opcode = (ushort)((highByte << 8) | lowByte);

            // Advance PC by 2 (next instruction)
            PC += 2;

            // Decode: Extract opcode fields
            int opHigh = (opcode & 0xF000) >> 12; // high nibble
            int X = (opcode & 0x0F00) >> 8;       // second nibble
            int Y = (opcode & 0x00F0) >> 4;       // third nibble
            int NN = opcode & 0x00FF;             // lowest 8 bits
            int N = opcode & 0x000F;              // lowest 4 bits
            int NNN = opcode & 0x0FFF;            // lowest 12 bits

            // Execute: Switch on high nibble (only structure for now)
            switch (opHigh)
            {
                case 0x6:
                    // 6XNN: Set V[X] = NN (to be implemented in Task 5)
                    Console.WriteLine($"Opcode 6XNN detected: 0x{opcode:X4}");
                    break;
                case 0x7:
                    // 7XNN: Add NN to V[X] (to be implemented in Task 5)
                    Console.WriteLine($"Opcode 7XNN detected: 0x{opcode:X4}");
                    break;
                case 0x8:
                    // 8XYN: Arithmetic/logical ops (to be implemented in Task 6)
                    Console.WriteLine($"Opcode 8XYN detected: 0x{opcode:X4}");
                    break;
                default:
                    // Not implemented or unknown opcode
                    Console.WriteLine($"Unknown or unimplemented opcode: 0x{opcode:X4}");
                    break;
            }
        }
    }
}
