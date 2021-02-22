using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Winhooks {
    public sealed class MouseHook: IWinHook {

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private const int WH_MOUSE_LL = 0xE;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private IntPtr hookId;

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && (wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_RBUTTONDOWN)) {
                MSLLHOOKSTRUCT hkStr = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
            }

            return Util.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        public void Hook() { 
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                hookId = Util.SetWindowsHookEx(WH_MOUSE_LL, HookCallback, Util.GetModuleHandle(curModule.ModuleName), 0);
        }

        public void Unhook() { 
            Util.UnhookWindowsHookEx(hookId);
        }
    }
}