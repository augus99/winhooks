using System;

namespace Winhooks {
    public sealed class KeyHookEventArgs : EventArgs {
        public readonly VirtualKey KeyPressed;

        internal KeyHookEventArgs(uint vkCode) : base() {
            this.KeyPressed = (VirtualKey)vkCode;
        }
    }
}