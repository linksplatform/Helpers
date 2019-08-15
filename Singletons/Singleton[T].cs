﻿using System;
using System.Collections.Concurrent;
using System.Reflection;
using Platform.Collections.Lists;
using Platform.Reflection;

namespace Platform.Helpers.Singletons
{
    public struct Singleton<T>
    {
        private static readonly ConcurrentDictionary<Func<T>, byte[]> _functions = new ConcurrentDictionary<Func<T>, byte[]>();
        private static readonly ConcurrentDictionary<byte[], T> _singletons = new ConcurrentDictionary<byte[], T>(Default<IListEqualityComparer<byte>>.Instance);
        public T Instance { get; }
        public Singleton(Func<T> creator) => Instance = _singletons.GetOrAdd(_functions.GetOrAdd(creator, creator.GetMethodInfo().GetILBytes()), key => creator());
    }
}
