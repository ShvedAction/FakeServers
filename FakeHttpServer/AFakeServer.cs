using System;
using FakeServers.ReceiverConditionals;

namespace FakeServers
{
    public abstract class AFakeServer : IFakeServer
    {
        public static string DEFAULT_RESPONSE_BODY = "this is a value of default response body";
        protected string DefaultResponseBody = DEFAULT_RESPONSE_BODY;

        public abstract void CheckAllReceiverConditional();

        public virtual void Dispose()
        {
            StopServer();
        }

        public abstract string[] GetReceiveHistory();

        public void SetDefaultResponse(string defaultResponse)
        {
            DefaultResponseBody = defaultResponse;
        }

        public abstract ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null);
        public abstract void StopServer();
    }
}
