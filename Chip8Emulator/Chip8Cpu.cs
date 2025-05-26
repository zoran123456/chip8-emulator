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
        /// Executes one CPU cycle (fetch-decode-execute). To be implemented.
        /// </summary>
        public void Cycle()
        {
            // Implementation will be added in a future task.
        }
    }
}
