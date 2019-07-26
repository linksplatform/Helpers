using System.Runtime.CompilerServices;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Helpers.Counters
{
    public class Counter<TValue, TDecision> : Counter
    {
        private readonly TDecision _trueValue;

        public Counter()
        {
        }

        public Counter(TDecision trueValue) => _trueValue = trueValue;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDecision IncrementAndReturnTrue()
        {
            _count++;
            return _trueValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDecision IncrementAndReturnTrue(TValue value)
        {
            _count++;
            return _trueValue;
        }
    }
}
