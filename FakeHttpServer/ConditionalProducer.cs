
using FakeServers.ReciverConditionals;

namespace FakeServers
{

    public class ConditionalProducer
    {
        private IReciverConditional _conditional;

        public IReciverConditional Conditional { get { return _conditional; } }

        public ConditionalProducer(IReciverConditional conditionalType = null)
        {
            _conditional = conditionalType?? new ReciverConditional();
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
