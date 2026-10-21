using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace Aion2Trainer
{
    /// <summary>
    /// Manages global hotkeys using Win32 RegisterHotKey.
    /// Supports F1 through F8 keys.
    /// </summary>
    public class HotkeyManager : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WM_HOTKEY = 0x0312;
        private readonly IntPtr _hwnd;
        private int _nextId;

        /// <summary>
        /// Occurs when a registered hotkey is pressed.
        /// </summary>
        public event Action<int> HotkeyPressed;

        public HotkeyManager(IntPtr hwnd)
        {
            _hwnd = hwnd;
            HwndSource.FromHwnd(hwnd)?.AddHook(WndProc);
        }

        /// <summary>
        /// Registers a function key hotkey (F1–F8).
        /// </summary>
        /// <param name="key">Function key number (1–8).</param>
        public void Register(int key)
        {
            if (key < 1 || key > 8)
                throw new ArgumentOutOfRangeException(nameof(key), "Only F1–F8 are supported.");

            var id = _nextId++;
            var vk = (uint)(0x70 + key - 1); // VK_F1 = 0x70
            RegisterHotKey(_hwnd, id, 0, vk);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                var id = wParam.ToInt32();
                HotkeyPressed?.Invoke(id);
                handled = true;
            }
            return IntPtr.Zero;
        }

        public void Dispose()
        {
            // Unregister all hotkeys on disposal
            for (var i = 0; i < _nextId; i++)
                UnregisterHotKey(_hwnd, i);
        }
    }
}