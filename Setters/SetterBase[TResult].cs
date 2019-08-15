using System.Runtime.CompilerServices;

namespace Platform.Helpers.Setters
{
    /// <remarks>
    /// Must be class, not struct (in order to persist access to Result field value).
    /// </remarks>
    public abstract class SetterBase<TResult>
    {
        protected TResult _result;
        public TResult Result => _result;
        protected SetterBase() { }
        protected SetterBase(TResult defaultValue) => _result = defaultValue;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(TResult value) => _result = value;
    }
}
