using System.Runtime.CompilerServices;

namespace Platform.Helpers.Counters
{
    /// <remarks>
    /// Must be class, not struct (in order to persist access to Count field value).
    /// </remarks>
    public class Counter
    {
        protected ulong _count;
        public ulong Count => _count;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Increment() => _count++;
    }
}
