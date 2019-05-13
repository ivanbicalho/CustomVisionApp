using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionApp.StreetFighter
{
    public static class ExecuteWhen
    {
        private static string _current = "";
        private static int _count = 0;

        public static void SameValueNTimes(int n, string value, Action action)
        {
            if (_current != value)
            {
                _count = 0;
                _current = value;
            }

            _count++;

            if (_count == n)
            {
                action.Invoke();
                _count = 0;
            }
        }

        public static void SameValueTwoTimes(string value, Action action)
        {
            SameValueNTimes(2, value, action);
        }
    }
}

