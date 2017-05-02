
using FakeServers.ReceiverConditionals;

namespace FakeServers
{

    public class ConditionalProducer
    {
        private IReceiverConditional _conditional;

        public IReceiverConditional Conditional { get { return _conditional; } }

        public ConditionalProducer(IReceiverConditional conditionalType = null)
        {
            _conditional = conditionalType?? new ReceiverConditional();
        }

        public virtual ConditionalProducer Post(string body)
        {
            _conditional.SetExceptedRrequest(body);
            return this;
        }
        public virtual ConditionalProducer Response(string body, string[] headers = null)
        {
            _conditional.SetResponse(body, headers);
            return this;
        }
    }
}
