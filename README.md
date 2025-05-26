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

## TODO Features
Here are detailed features that could be implemented to extend this emulator:

### Opcode Implementation
- **Complete the instruction set**: Implement all standard CHIP-8 opcodes:
  - `0NNN`: Execute machine language subroutine
  - `00E0`: Clear the screen
  - `00EE`: Return from subroutine
  - `1NNN`: Jump to address NNN
  - `2NNN`: Execute subroutine at NNN
  - `3XNN`: Skip if VX equals NN
  - `4XNN`: Skip if VX doesn't equal NN
  - `5XY0`: Skip if VX equals VY
  - `8XY0`: Set VX to VY
  - `8XY1`: Set VX to VX OR VY
  - `8XY2`: Set VX to VX AND VY
  - `8XY3`: Set VX to VX XOR VY
  - `8XY5`: Subtract VY from VX
  - `8XY6`: Right shift VX
  - `8XY7`: Set VX to VY minus VX
  - `8XYE`: Left shift VX
  - `9XY0`: Skip if VX doesn't equal VY
  - `ANNN`: Set index register I
  - `BNNN`: Jump to address NNN + V0
  - `CXNN`: Set VX to random number AND NN
  - `DXYN`: Display/draw
  - `EX9E`: Skip if key VX pressed
  - `EXA1`: Skip if key VX not pressed
  - `FX07`: Set VX to delay timer
  - `FX0A`: Wait for key press
  - `FX15`: Set delay timer to VX
  - `FX18`: Set sound timer to VX
  - `FX1E`: Add VX to I
  - `FX29`: Set I to font sprite for character VX
  - `FX33`: Store BCD representation of VX
  - `FX55`: Store V0...VX in memory at I
  - `FX65`: Fill V0...VX from memory at I

### Graphics
- Implement the 64x32 monochrome pixel display
- Create a rendering system using a modern graphics library
- Add support for sprite drawing and collision detection
- Implement the font set (0-F hexadecimal characters)
- Add optional upscaling for better visibility on modern displays
- Implement configurable color schemes

### Input System
- Support for the 16-key hexadecimal keypad (0-9 and A-F)
- Configurable keyboard mapping
- Optional gamepad/controller support
- Key event handling for real-time input

### Timing and Sound
- Implement the 60Hz delay timer for timing game events
- Add the 60Hz sound timer for audio control
- Implement a basic sound system for the buzzer tone
- Add volume control and mute options
- Ensure consistent timing across different hardware

### Memory and Stack
- Implement the stack for subroutine calls (typically 12-16 levels deep)
- Add memory viewer/editor for debugging
- Implement memory protection for reserved areas (0x000-0x1FF)

### ROM Handling
- Add support for loading external ROM files
- Implement a ROM browser/selector
- Add ROM information display (size, CRC, etc.)
- Support for saving and loading emulator state

### User Interface
- Create a proper GUI with menus and controls
- Add pause/resume functionality
- Implement step-by-step execution for debugging
- Add speed control (faster/slower than original)
- Display register values and memory state in real-time

### Debugging Tools
- Implement a disassembler to view program code
- Add breakpoint support
- Provide register and memory inspection
- Add logging of opcode execution
- Visualization of the stack and program flow

### Extensions and Enhancements
- Support for Super CHIP-8 instructions
- XO-CHIP enhancements
- Custom instruction sets or extensions
- High-resolution graphics modes
- Multiple color support
- Additional sound capabilities

### Other Improvements
- Configuration saving/loading
- Performance optimizations
- Screenshot and recording capabilities
- Integration with CHIP-8 program repositories
- Automated testing framework for opcodes

## Credits
- Developed using both **OpenAI Deep Research** and **GitHub Copilot** for code generation, research, and best practices.

## License
This project is provided for educational purposes. See LICENSE for details.
