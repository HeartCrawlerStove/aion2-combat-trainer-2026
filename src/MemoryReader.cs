using System;
using System.Runtime.InteropServices;

namespace Aion2Trainer
{
    /// <summary>
    /// Provides read and write access to another process memory using Win32 API.
    /// All memory addresses are placeholder stubs and must be updated for the current game patch.
    /// </summary>
    public class MemoryReader : IDisposable
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint dwSize, out uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten);

        private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        private IntPtr _processHandle = IntPtr.Zero;
        private int _processId;

        /// <summary>
        /// Gets whether a process is currently attached.
        /// </summary>
        public bool IsConnected => _processHandle != IntPtr.Zero;

        /// <summary>
        /// Opens the target process by name.
        /// </summary>
        /// <param name="processName">Process name without extension, e.g. "AION2".</param>
        /// <returns>True if the process was opened successfully.</returns>
        public bool OpenProcess(string processName)
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(processName);
            if (processes.Length == 0)
                return false;

            _processId = processes[0].Id;
            _processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, _processId);
            return _processHandle != IntPtr.Zero;
        }

        /// <summary>
        /// Reads a 32-bit integer from the target process.
        /// </summary>
        /// <param name="address">Memory address to read from.</param>
        /// <returns>The read integer value.</returns>
        public int ReadInt(IntPtr address)
        {
            var buffer = new byte[4];
            if (!ReadProcessMemory(_processHandle, address, buffer, 4, out _))
                return 0;
            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// Writes a 32-bit integer to the target process.
        /// </summary>
        /// <param name="address">Memory address to write to.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>True if the write succeeded.</returns>
        public bool WriteInt(IntPtr address, int value)
        {
            var buffer = BitConverter.GetBytes(value);
            return WriteProcessMemory(_processHandle, address, buffer, (uint)buffer.Length, out _);
        }

        /// <summary>
        /// Scans process memory for a byte pattern.
        /// </summary>
        /// <param name="pattern">Byte pattern to search for.</param>
        /// <param name="mask">Mask where 'x' means check byte, '?' means skip.</param>
        /// <returns>Address of the first match, or IntPtr.Zero if not found.</returns>
        public IntPtr FindPattern(byte[] pattern, string mask)
        {
            // TODO: implement full memory scanning across process regions
            return IntPtr.Zero;
        }

        /// <summary>
        /// Placeholder address for God Mode. Update offset for current patch.
        /// </summary>
        public IntPtr GodModeAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for Infinite HP. Update offset for current patch.
        /// </summary>
        public IntPtr InfiniteHPAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for Infinite MP. Update offset for current patch.
        /// </summary>
        public IntPtr InfiniteMPAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for One Hit Kill. Update offset for current patch.
        /// </summary>
        public IntPtr OneHitKillAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for Damage Multiplier. Update offset for current patch.
        /// </summary>
        public IntPtr DamageMultiplierAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for Infinite Kinah. Update offset for current patch.
        /// </summary>
        public IntPtr InfiniteKinahAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for No Cooldown. Update offset for current patch.
        /// </summary>
        public IntPtr NoCooldownAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        /// <summary>
        /// Placeholder address for Super Speed. Update offset for current patch.
        /// </summary>
        public IntPtr SuperSpeedAddress => new IntPtr(0x00000000); // TODO: update offset for current patch

        public void Dispose()
        {
            if (_processHandle != IntPtr.Zero)
            {
                CloseHandle(_processHandle);
                _processHandle = IntPtr.Zero;
            }
        }
    }
}