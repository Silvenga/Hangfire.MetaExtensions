using System;

using Hangfire.Client;
using Hangfire.Common;

namespace Hangfire.MetaExtensions
{
    public class MetaClientFilterAttribute : JobFilterAttribute, IClientFilter
    {
        public void OnCreating(CreatingContext filterContext)
        {
            var contextActions = ThreadStorage<Action<CreatingContext>>.Collection;
            foreach (var action in contextActions)
            {
                action.Invoke(filterContext);
            }
        }

        public void OnCreated(CreatedContext filterContext)
        {
        }
    }
}