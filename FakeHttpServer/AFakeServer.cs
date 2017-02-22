using FakeServers.ReciverConditionals;

namespace FakeServers
{
    public abstract class AFakeServer : IFakeServer
    {
        public const string DEFAULT_RESPONSE_BODY = "this is a value of default response body";

        public abstract void CheckAllReciverConditional();

        public virtual void Dispose()
        {
            StopServer();
        }

        public abstract string[] GetReciveHistory();

        public abstract ConditionalProducer ShouldRecived(IReciverConditional conditionType = null);
        public abstract void StopServer();
    }
}
