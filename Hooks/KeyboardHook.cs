using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Winhooks {
    public sealed class KeyboardHook : IWinHook {
        
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 0xD;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private IntPtr hookId;

        public event KeyHookEventHandler KeyDown;

        public KeyboardHook(KeyHookEventHandler handler) {
            this.KeyDown += handler;
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN) {
                KBDLLHOOKSTRUCT hkStr = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
                KeyDown?.Invoke(this, new KeyHookEventArgs(hkStr.vkCode));
            }
            return Util.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        public void Hook() {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                hookId = Util.SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, Util.GetModuleHandle(curModule.ModuleName), 0);
        }

        public void Unhook() {
            Util.UnhookWindowsHookEx(hookId);
        }
    }
}