namespace Chip8Emulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Minimal Chip-8 emulator demonstration.
            // This test program loads values into V0 and V1, then adds them (V0 = V0 + V1).
            // Normally, a full emulator would load a ROM and run continuously.

            var memory = new Chip8Memory();
            var cpu = new Chip8Cpu(memory);

            // Define a simple test program (3 instructions):
            // 0x6005: V0 = 0x05
            // 0x6107: V1 = 0x07
            // 0x8014: V0 = V0 + V1 (VF = carry)
            byte[] testProgram = {
                0x60, 0x05, // LD V0, 0x05
                0x61, 0x07, // LD V1, 0x07
                0x80, 0x14  // ADD V0, V1
            };

            // Load the program into memory at 0x200
            memory.LoadBytes(0x200, testProgram);

            // Ensure PC is set to 0x200
            cpu.PC = 0x200;

            // Print initial register values
            Console.WriteLine($"Initial: V0={cpu.V[0]}, V1={cpu.V[1]}, VF={cpu.V[0xF]}, PC=0x{cpu.PC:X3}");

            // Run the program (3 instructions)
            for (int i = 0; i < testProgram.Length / 2; i++)
            {
                ushort opcode = (ushort)((memory.ReadByte(cpu.PC) << 8) | memory.ReadByte((ushort)(cpu.PC + 1)));
                Console.WriteLine($"Executing 0x{opcode:X4} at PC=0x{cpu.PC:X3}");
                cpu.Cycle();
                Console.WriteLine($"After: V0={cpu.V[0]}, V1={cpu.V[1]}, VF={cpu.V[0xF]}, PC=0x{cpu.PC:X3}\n");
            }

            // Print final register values
            Console.WriteLine($"Final: V0={cpu.V[0]}, V1={cpu.V[1]}, VF={cpu.V[0xF]}, PC=0x{cpu.PC:X3}");
            Console.WriteLine("Demo complete. Emulator ready for extension (add more opcodes, input, graphics, etc.).");
        }
    }
}
