namespace Chip8Emulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate Chip-8 memory and CPU, wiring them together.
            var memory = new Chip8Memory();
            var cpu = new Chip8Cpu(memory);
            
            Console.WriteLine("Chip-8 CPU and memory initialized.");

            // Run a few CPU cycles (no program loaded yet, just for demonstration)
            for (int i = 0; i < 3; i++)
            {
                cpu.Cycle();
            }
        }
    }
}
