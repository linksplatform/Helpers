using System.Runtime.CompilerServices;

namespace Platform.Helpers.Setters
{
    public class Setter<TResult> : SetterBase<TResult>
    {
        public Setter(TResult defaultValue) : base(defaultValue) { }

        public Setter() { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetAndReturnTrue(TResult value)
        {
            _result = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetAndReturnFalse(TResult value)
        {
            _result = value;
            return false;
        }
    }
}
