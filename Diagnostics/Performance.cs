using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Platform.Helpers.Diagnostics
{
    public static class Performance
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Measure(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
