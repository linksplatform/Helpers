using System;
using System.Collections.Concurrent;
using System.Reflection;
using Platform.Collections.Lists;
using Platform.Reflection;

namespace Platform.Helpers.Singletons
{
    public struct Singleton<T>
    {
        private static readonly ConcurrentDictionary<Func<T>, byte[]> Functions = new ConcurrentDictionary<Func<T>, byte[]>();
        private static readonly ConcurrentDictionary<byte[], T> Singletons = new ConcurrentDictionary<byte[], T>(Default<IListEqualityComparer<byte>>.Instance);

        private readonly Func<T> _creator;

        public Singleton(Func<T> creator) => _creator = creator;

        public T Instance
        {
            get
            {
                var creatorCopy = _creator;
                var bytes = Functions.GetOrAdd(creatorCopy, creatorCopy.GetMethodInfo().GetILBytes());
                return Singletons.GetOrAdd(bytes, key => creatorCopy());
            }
        }
    }
}
