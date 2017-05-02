using FakeServers.ReceiverConditionals;
using FakeServers.SoapServerManagerWebRef;

namespace FakeServers
{
    public class RemoteConditionalProducer : ConditionalProducer
    {
        private long remoteConditionalId;
        private long remoteServerId;
        private ServerManager soapRemoteServerManagerClient;

        public static int GetConditionalTypeCode(IReceiverConditional conditionalType)
        {
            if (conditionalType is XMLWithIgnoreNodeRreceiverConditional)
                return 2;
            if (conditionalType is XMLReceiverConditional)
                return 1;
            return 0;
        }

        public static IReceiverConditional CreateReceiverConditionalByCode(int conditionalTypeCode)
        {
            switch (conditionalTypeCode)
            {
                case 2:
                    return new XMLWithIgnoreNodeRreceiverConditional();
                case 1:
                    return new XMLReceiverConditional();
                default:
                    return new ReceiverConditional();
            }
        }

        public RemoteConditionalProducer(ServerManager soapRemoteServerManagerClient, long remoteServerId, IReceiverConditional conditionalType)
        {
            this.soapRemoteServerManagerClient = soapRemoteServerManagerClient;
            this.remoteServerId = remoteServerId;
            remoteConditionalId = soapRemoteServerManagerClient.CreateReceivedConditional(remoteServerId, GetConditionalTypeCode(conditionalType));
        }

        public override ConditionalProducer Post(string body)
        {
            soapRemoteServerManagerClient.TheConditionalShouldBeExpectPostWithRquestBody( remoteServerId, remoteConditionalId, body);
            return this;
        }

        public override ConditionalProducer Response(string body, string[] headers = null)
        {
            soapRemoteServerManagerClient.ForTheConditionalResponseBodyShouldBe(remoteServerId, remoteConditionalId, body, headers);
            return this;
        }
    }
}
