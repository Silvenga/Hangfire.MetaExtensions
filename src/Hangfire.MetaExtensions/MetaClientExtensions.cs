using System;

using Hangfire.Client;

namespace Hangfire.MetaExtensions
{
    public static class MetaClientExtensions
    {
        public static IBackgroundJobClient UseMeta<T>(IBackgroundJobClient client, string key, T value)
        {
            ThreadStorage<Action<CreatingContext>>.Add(context => context.SetJobParameter(key, value));
            return client;
        }
    }
}