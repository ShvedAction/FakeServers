using System;
using FakeServers.ReceiverConditionals;

namespace FakeServers
{
    public abstract class AFakeServer : IFakeServer
    {
        public static string DEFAULT_RESPONSE_BODY = "this is a value of default response body";
        protected string DefaultResponseBody = DEFAULT_RESPONSE_BODY;
        protected string[] DefaultHeaders;

        public abstract void CheckAllReceiverConditional();

        public virtual void Dispose()
        {
            StopServer();
        }

        public abstract string[] GetReceiveHistory();

        public void SetDefaultResponse(string defaultResponse, string[] headers)
        {
            DefaultResponseBody = defaultResponse;
            DefaultHeaders = headers;
        }

        public abstract ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null);
        public abstract void StopServer();
    }
}
