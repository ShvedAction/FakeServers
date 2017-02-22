using FakeServers.ReciverConditionals;
using System;

namespace FakeServers
{
    public interface IFakeServer : IDisposable
    {
        ConditionalProducer ShouldRecived(IReciverConditional conditionType = null);

        void StopServer();
        void CheckAllReciverConditional();
        string[] GetReciveHistory();
    }
}
