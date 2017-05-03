using FakeServers.ReceiverConditionals;

namespace FakeServers
{
    public abstract class AFakeServer : IFakeServer
    {
        public const string DEFAULT_RESPONSE_BODY = "this is a value of default response body";

        public abstract void CheckAllReceiverConditional();

        public virtual void Dispose()
        {
            StopServer();
        }

        public abstract string[] GetReceiveHistory();

        public abstract ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null);
        public abstract void StopServer();
    }
}
