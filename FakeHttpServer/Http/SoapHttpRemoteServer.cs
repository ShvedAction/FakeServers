using System;
using FakeServers.ReciverConditionals;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakeServers.Http
{
    public class SoapHttpRemoteServer : AFakeServer
    {
        private SoapServerManagerWebRef.ServerManager SoapRemoteServerManagerClient;
        private long RemoteServerId;


        private List<RemoteConditionalProducer> recivers;
        private bool allreadyShoutDown;

        public SoapHttpRemoteServer(string fakeServerListenedUrl, string hostOfRemoteServerManager)
        {
            SoapRemoteServerManagerClient = new SoapServerManagerWebRef.ServerManager()
            {
                Url = hostOfRemoteServerManager
            };
            RemoteServerId = SoapRemoteServerManagerClient.TryUpServer(fakeServerListenedUrl);
            allreadyShoutDown = false;
            recivers = new List<RemoteConditionalProducer>();
        }

        public override void CheckAllReciverConditional()
        {
            try
            {
                allreadyShoutDown = true;
                SoapRemoteServerManagerClient.ShutDownServer(RemoteServerId);
            }
            catch(SoapException e)
            {
                Assert.Fail("Maybe Some reciver conditionals are not met. Detail: "+e.Message);
            }
        }

        public override ConditionalProducer ShouldRecived(IReciverConditional conditionType = null)
        {
            RemoteConditionalProducer conditionaProcedure = new RemoteConditionalProducer(SoapRemoteServerManagerClient, RemoteServerId, conditionType);
            recivers.Add(conditionaProcedure);
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

        public override string[] GetReciveHistory()
        {
            return SoapRemoteServerManagerClient.GetReciveHistoryForFakeServer(RemoteServerId);
        }
    }
}