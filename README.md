# Chip-8 Emulator (Bare Bones, C#, .NET 8)

This project is a minimal, educational Chip-8 emulator written in C# targeting .NET 8. It demonstrates the core architecture and instruction cycle of a Chip-8 system, and is designed for clarity, simplicity, and easy extension.

## Features
- **Minimal implementation:** Only the essential components (CPU, memory, and a simple coordinator) are included.
- **Core instruction cycle:** Implements fetch-decode-execute for a subset of Chip-8 opcodes (6XNN, 7XNN, 8XY4).
- **Demonstration program:** Runs a hardcoded test program to show register and CPU state changes.
- **Separation of concerns:** Memory and CPU logic are cleanly separated.
- **Ready for extension:** The codebase is structured for easy addition of more opcodes, input, graphics, timers, and other Chip-8 features.

## Project Structure
- `Program.cs`: Entry point. Loads a test program, runs the CPU, and prints register state.
- `Chip8Cpu.cs`: Implements the CPU, registers, and instruction cycle.
- `Chip8Memory.cs`: Handles 4KB Chip-8 memory, with safe read/write and program loading.
- `Chip8Emulator.cs`: (Optional) Coordinator class for future expansion.

## How It Works
1. **Test Program:**
   - Loads values into V0 and V1, then adds them (V0 = V0 + V1).
   - Demonstrates opcode handling and register changes.
2. **Execution:**
   - The emulator fetches, decodes, and executes each instruction, printing state after each step.
   - Final register values are printed for verification.

## Example Output
```
Initial: V0=0, V1=0, VF=0, PC=0x200
Executing 0x6005 at PC=0x200
After: V0=5, V1=0, VF=0, PC=0x202
Executing 0x6107 at PC=0x202
After: V0=5, V1=7, VF=0, PC=0x204
Executing 0x8014 at PC=0x204
After: V0=12, V1=7, VF=0, PC=0x206
Final: V0=12, V1=7, VF=0, PC=0x206
Demo complete. Emulator ready for extension (add more opcodes, input, graphics, etc.).
```

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Building and Running
1. Clone the repository.
2. Build the project:
   ```sh
   dotnet build
   ```
3. Run the emulator:
   ```sh
   dotnet run
   ```

## Extending the Emulator
This project is intentionally minimal. You can extend it by:
- Implementing more Chip-8 opcodes in `Chip8Cpu.cs`.
- Adding input handling, graphics, and sound.
- Loading external ROM files.
- Implementing timers and more advanced features.

## Credits
- Developed using both **OpenAI Deep Research** and **GitHub Copilot** for code generation, research, and best practices.

## License
This project is provided for educational purposes. See LICENSE for details.
