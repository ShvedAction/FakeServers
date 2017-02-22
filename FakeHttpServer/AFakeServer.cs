using FakeServers.ReciverConditionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeServers
{
    public abstract class AFakeServer : IFakeServer
    {
        public abstract void CheckAllReciverConditional();

        public virtual void Dispose()
        {
            stopServer();
        }

        public abstract string[] GetReciveHistory();

        public abstract ConditionalProducer ShouldRecived(IReciverConditional conditionType = null);
        public abstract void stopServer();
    }
}
