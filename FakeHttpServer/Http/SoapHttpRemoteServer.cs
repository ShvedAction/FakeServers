using FakeServers.ReceiverConditionals;
using System.Collections.Generic;
using System.Web.Services.Protocols;

namespace FakeServers.Http
{
    public class SoapHttpRemoteServer : AFakeServer
    {
        private SoapServerManagerWebRef.ServerManager SoapRemoteServerManagerClient;
        private long RemoteServerId;


        private List<RemoteConditionalProducer> receivers;
        private bool allreadyShoutDown;

        public SoapHttpRemoteServer(string fakeServerListenedUrl, string hostOfRemoteServerManager)
        {
            SoapRemoteServerManagerClient = new SoapServerManagerWebRef.ServerManager()
            {
                Url = hostOfRemoteServerManager
            };
            RemoteServerId = SoapRemoteServerManagerClient.TryUpServer(fakeServerListenedUrl);
            allreadyShoutDown = false;
            receivers = new List<RemoteConditionalProducer>();
        }

        public override void CheckAllReceiverConditional()
        {
            try
            {
                allreadyShoutDown = true;
                SoapRemoteServerManagerClient.ShutDownServer(RemoteServerId);
            }
            catch(SoapException e)
            {
                throw new System.Exception("Maybe Some receiver conditionals are not met. Detail: "+e.Message);
            }
        }

        public override ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null)
        {
            RemoteConditionalProducer conditionaProcedure = new RemoteConditionalProducer(SoapRemoteServerManagerClient, RemoteServerId, conditionType);
            receivers.Add(conditionaProcedure);
            return conditionaProcedure;
        }

        public override void StopServer()
        {
            if (allreadyShoutDown)
                return;
            allreadyShoutDown = true;
            SoapRemoteServerManagerClient.ShutDownServer(RemoteServerId);
        }

        public static IFakeServer TakeListenHost(string fakeServerLListenedUrl, string hostOfRemoteServerManager)
        {
            return new SoapHttpRemoteServer(fakeServerLListenedUrl, hostOfRemoteServerManager);
        }

        public override string[] GetReceiveHistory()
        {
            return SoapRemoteServerManagerClient.GetReceiveHistoryForFakeServer(RemoteServerId);
        }
    }
}
