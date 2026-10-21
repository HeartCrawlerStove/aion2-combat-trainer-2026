# Developer Notes

## Overview

AION 2 Combat Trainer is a single-player combat modification tool for AION 2. It reads and writes game process memory to apply trainer features such as God Mode, Infinite HP/MP, and damage scaling.

## Architecture

- `MainWindow.xaml` / `MainWindow.xaml.cs` — WPF UI and event handling.
- `MemoryReader.cs` — Win32 API wrapper for process memory access (ReadProcessMemory, WriteProcessMemory, OpenProcess).
- `HotkeyManager.cs` — Global hotkey registration via RegisterHotKey (F1–F8).
- `TrainerConfig.cs` — JSON configuration persistence.

## Memory Addresses

All memory addresses in `MemoryReader.cs` are placeholder stubs set to `0x00000000` with `// TODO: update offset for current patch` comments. They must be updated for each game patch before the trainer can locate the correct values.

## Known Limitations

- Designed for single-player use only.
- Not intended for online or multiplayer game modes.
- Memory offsets change with every game patch; addresses must be re-verified.
- Requires the game process to be running before the trainer can attach.

## Updating Offsets After Patches

1. Launch the game and attach a memory scanner.
2. Locate the current address for each feature (HP, MP, Kinah, etc.).
3. Update the corresponding constant in `MemoryReader.cs`.
4. Rebuild the project and test in single-player mode.