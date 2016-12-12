using Hangfire.Common;
using Hangfire.States;

namespace Hangfire.MetaExtensions.Plugins
{
    public class DynamicQueue : JobFilterAttribute, IElectStateFilter
    {
        public const string DynamicQueueKey = nameof(DynamicQueue);

        public void OnStateElection(ElectStateContext context)
        {
            var enqueuedState = context.CandidateState as EnqueuedState;
            if (enqueuedState == null)
            {
                return;
            }

            var queueName = context.GetJobParameter<string>(DynamicQueueKey);
            if (queueName != null)
            {
                enqueuedState.Queue = queueName;
            }
        }
    }
}