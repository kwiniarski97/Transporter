namespace Transporter.Core.Domain
{
    public class PassangerNode
    {
        public Node Node { get; protected set; }
        public Passanger Passanger { get; protected set; }

        public PassangerNode(Node node, Passanger passanger)
        {
            Node = node;
            Passanger = passanger;
        }

        protected PassangerNode()
        {
        }
    }
}