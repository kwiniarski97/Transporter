namespace Transporter.Core.Domain
{
    public class PassangerNode
    {
        public Passanger Passanger { get; protected set; }
        public Node Node { get; protected set; }

        public PassangerNode(Passanger passanger, Node node)
        {
            Passanger = passanger;
            Node = node;
        }

        protected PassangerNode()
        {
        }

        public static PassangerNode Create(Passanger passanger, Node node) =>
            new PassangerNode(passanger, node);
    }
}