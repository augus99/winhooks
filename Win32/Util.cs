using System;
using System.Runtime.InteropServices;

namespace Winhooks {
    internal static class Util {
        internal delegate IntPtr HookCallback(
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(
            int idHook, 
            HookCallback lpfn, 
            IntPtr hMod, 
            uint dwThreadId
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(
            IntPtr hhk
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk, 
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(
            string lpModuleName
        );
    }
}