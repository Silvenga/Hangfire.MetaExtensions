using Hangfire.Common;
using Hangfire.States;

namespace Hangfire.MetaExtensions
{
    public class MetaClient : IBackgroundJobClient
    {
        private readonly IBackgroundJobClient _jobClient;

        public MetaClient(IBackgroundJobClient jobClient)
        {
            _jobClient = jobClient;
        }

        public string Create(Job job, IState state)
        {
            return _jobClient.Create(job, state);
        }

        public bool ChangeState(string jobId, IState state, string expectedState)
        {
            return _jobClient.ChangeState(jobId, state, expectedState);
        }
    }
}