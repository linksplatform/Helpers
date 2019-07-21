using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platform.Helpers
{
    public class Default
    {
        public static void InitializeThreadInstance<T>()
            where T : new() => Default<T>.ThreadInstance = new T();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrCreateThreadInstance<T>()
            where T : class, new() => Default<T>.ThreadInstance ?? (Default<T>.ThreadInstance = new T());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrCreateThreadInstance<T>(T nullValue)
            where T : struct => EqualityComparer<T>.Default.Equals(Default<T>.ThreadInstance, nullValue) ? (Default<T>.ThreadInstance = new T()) : Default<T>.ThreadInstance;
    }
}
