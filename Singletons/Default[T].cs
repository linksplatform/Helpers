using System;

namespace Platform.Helpers.Singletons
{
    /// <summary>
    /// Представляет собой точку доступа к экземплярям типов по умолчанию (созданных с помощью конструктора без аргументов).
    /// </summary>
    /// <typeparam name="T">Тип экземпляра объекта.</typeparam>
    public static class Default<T>
        where T : new()
    {
        /// <summary>
        /// Default.GetOrCreateThreadInstance methods are recommended instead.
        /// Use direclty only if you understand what you are doing (see remarks for hint).
        /// </summary>
        /// <remarks>
        /// If you really need maximum performance, use this field together with Default.InitializeThreadInstance method.
        /// This method should be called only once per thread, but you can call multiple times if you need to replace the instance with new one.
        /// </remarks>
        [ThreadStatic]
        public static T ThreadInstance;

        public static readonly T Instance = new T();
    }
}
