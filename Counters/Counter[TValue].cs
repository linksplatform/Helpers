using System.Runtime.CompilerServices;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Helpers.Counters
{
    public class Counter<TValue> : Counter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IncrementAndReturnTrue()
        {
            _count++;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IncrementAndReturnTrue(TValue value)
        {
            _count++;
            return true;
        }
    }
}
