using FakeServers.ReceiverConditionals;
using System;

namespace FakeServers
{
    public interface IFakeServer : IDisposable
    {
        ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null);
        void StopServer();
        void CheckAllReceiverConditional();
        string[] GetReceiveHistory();
        void SetDefaultResponse(string defaultResponse);
    }
}
