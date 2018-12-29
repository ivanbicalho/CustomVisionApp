using Dear;
using Dear.KeyboardControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CustomVisionApp.StreetFighter
{
    public static class SpecialAttacks
    {
        public static void Execute(string attack)
        {
            if (attack == Attacks.Hadouken)
            {
                Hadouken();
            }
            else if (attack == Attacks.Shoryuken)
            {
                Shoryuken();
            }
        }

        private static void Hadouken()
        {
            var k = new MrWindows().Keyboard;

            k.Press(VirtualKey.Down)
                .Wait(100)
                .Press(VirtualKey.Right)
                .Wait(20)
                .Release(VirtualKey.Down)
                .Press(VirtualKey.D)
                .Wait(100)
                .Release(VirtualKey.Right)
                .Release(VirtualKey.D);
        }

        private static void Shoryuken()
        {
            var k = new MrWindows().Keyboard;

            k.Press(VirtualKey.Right)
                .Wait(100)
                .Release(VirtualKey.Right)
                .Press(VirtualKey.Down)
                .Wait(100)
                .Press(VirtualKey.Right)
                .Wait(100)
                .Press(VirtualKey.D)
                .Wait(100)
                .Release(VirtualKey.Down)
                .Release(VirtualKey.Right)
                .Release(VirtualKey.D);
        }
    }
}
