﻿using FakeHttpServFakeServers.Httper;
using FakeServers.ReceiverConditionals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FakeServers.Http
{

    public class FakeHttpServer : AFakeServer
    {

        const string DEFFAULT_LISTNED_ADDRESS = "http://localhost:3000/";
        private HttpAsyncServer asyncServer;

        private List<ConditionalProducer> receivers;
        private List<string> receiveMessages;
        private ConditionalProducer deffaultAnswer = new ConditionalProducer();

        private void onServerReceived(HttpListenerContext context)
        {
            string body;
            using (StreamReader receiveBodyStream = new StreamReader(context.Request.InputStream))
            {
                body = receiveBodyStream.ReadToEnd();
            }
            receiveMessages.Add(body);

            bool anyRiceveConditionalStatisvied = false;
            foreach (var receiver in receivers)
            {
                if (receiver.Conditional.IsSatisfied())
                    continue;
                if (receiver.Conditional.CheckResponse(context, body))
                {
                    receiver.Conditional.WriteResponseToContext();
                    anyRiceveConditionalStatisvied = true;
                    break;
                }
            }
            if (!anyRiceveConditionalStatisvied)
                WriteResponseDeffultAnswer(context);
        }

        private void WriteResponseDeffultAnswer(HttpListenerContext context)
        {
            HttpSender.WriteResponse(context.Response, DEFAULT_RESPONSE_BODY);
        }

        public FakeHttpServer(string[] listnedAddresses)
        {
            asyncServer = new HttpAsyncServer(listnedAddresses, (context) => onServerReceived(context));
            receiveMessages = new List<string>();
            asyncServer.RunServer();
            receivers = new List<ConditionalProducer>();
            deffaultAnswer.Response(DEFAULT_RESPONSE_BODY);
        }

        public FakeHttpServer(string listnedAddress): this(new string[] { listnedAddress})
        { }

        public FakeHttpServer(): this(DEFFAULT_LISTNED_ADDRESS)
        { }

        public override  ConditionalProducer ShouldReceived(IReceiverConditional conditionType = null)
        {
            var newConditional = new ConditionalProducer(conditionType);
            receivers.Add(newConditional);
            return newConditional;
        }

        public override void CheckAllReceiverConditional()
        {
            if (receivers.Count>0 && !receivers.Any(receiver => receiver.Conditional.IsSatisfied()))
            {
                Assert.Fail("Some receiver conditionals are not met.");
            }
        }

        public override void StopServer()
        {
            asyncServer.stop();
        }

        public override string[] GetReceiveHistory()
        {
            return receiveMessages.ToArray();
        }
    }
}
