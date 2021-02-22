using System;

namespace Winhooks {
    public sealed class MouseHookEventArgs : EventArgs {
        public readonly MouseButton Button;
        public readonly int X;
        public readonly int Y;

        internal MouseHookEventArgs(int x, int y, MouseButton button) : base() {
            this.X = x;
            this.Y = y;
            this.Button = button;
        }
    }
}
