using FakeHttpServFakeServers.Httper;
using FakeServers.ReciverConditionals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FakeServers.Http
{

    public class FakeHttpServer : AFakeServer
    {

        const string DEFFAULT_LISTNED_ADDRESS = "http://localhost:3000/";
        private HttpAsyncServer asyncServer;

        List<ConditionalProducer> recivers;

        private void onServerRecived(HttpListenerContext context)
        {
            foreach(var reciver in recivers)
            {
                if (reciver.Conditional.IsSatisfied())
                    continue;
                if (reciver.Conditional.CheckResponse(context))
                {
                    reciver.Conditional.WriteResponseToContext();
                    break;
                }
            }
        }

        public FakeHttpServer(string[] listnedAddresses)
        {
            asyncServer = new HttpAsyncServer(listnedAddresses, (context) => onServerRecived(context));
            asyncServer.RunServer();
            recivers = new List<ConditionalProducer>();
        }

        public FakeHttpServer(string listnedAddress): this(new string[] { listnedAddress})
        { }

        public FakeHttpServer(): this(DEFFAULT_LISTNED_ADDRESS)
        { }

        public override  ConditionalProducer ShouldRecived(IReciverConditional conditionType = null)
        {
            var newConditional = new ConditionalProducer(conditionType);
            recivers.Add(newConditional);
            return newConditional;
        }

        public override void CheckAllReciverConditional()
        {
            if (recivers.Count>0 && !recivers.Any(reciver => reciver.Conditional.IsSatisfied()))
            {
                Assert.Fail("Some reciver conditionals are not met.");
            }
        }

        public override void stopServer()
        {
            asyncServer.stop();
        }
    }
}
