using FakeServers.ReciverConditionals;
using FakeServers.SoapServerManagerWebRef;

namespace FakeServers
{
    public class RemoteConditionalProducer : ConditionalProducer
    {
        private long remoteConditionalId;
        private long remoteServerId;
        private ServerManager soapRemoteServerManagerClient;

        public static int GetConditionalTypeCode(IReciverConditional conditionalType)
        {
            if (conditionalType is XMLWithIgnoreNodeRreciverConditional)
                return 2;
            if (conditionalType is XMLReciverConditional)
                return 1;
            return 0;
        }

        public static IReciverConditional CreateReciverConditionalByCode(int conditionalTypeCode)
        {
            switch (conditionalTypeCode)
            {
                case 2:
                    return new XMLWithIgnoreNodeRreciverConditional();
                case 1:
                    return new XMLReciverConditional();
                default:
                    return new ReciverConditional();
            }
        }

        public RemoteConditionalProducer(ServerManager soapRemoteServerManagerClient, long remoteServerId, IReciverConditional conditionalType)
        {
            this.soapRemoteServerManagerClient = soapRemoteServerManagerClient;
            this.remoteServerId = remoteServerId;
            remoteConditionalId = soapRemoteServerManagerClient.CreateRecivedConditional(remoteServerId, GetConditionalTypeCode(conditionalType));
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