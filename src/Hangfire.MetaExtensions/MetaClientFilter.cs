using System;

using Hangfire.Client;
using Hangfire.Common;

namespace Hangfire.MetaExtensions
{
    public class MetaClientFilterAttribute : JobFilterAttribute, IClientFilter
    {
        public void OnCreating(CreatingContext filterContext)
        {
            var lazyContextActions = ThreadStorage<Action<CreatingContext>>.Collection;
            foreach (var action in lazyContextActions)
            {
                action.Invoke(filterContext);
            }
        }

        public void OnCreated(CreatedContext filterContext)
        {
        }
    }
}