using System;

using Hangfire.Client;

using JetBrains.Annotations;

namespace Hangfire.MetaExtensions
{
    public static class MetaClientExtensions
    {
        public static IBackgroundJobClient AddOrUpdateMeta<T>([NotNull] this IBackgroundJobClient client, [NotNull] string key, [NotNull] T value)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ThreadStorage<Action<CreatingContext>>.Add(context => context.SetJobParameter(key, value));

            return client;
        }
    }
}