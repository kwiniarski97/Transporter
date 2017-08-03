using System;

namespace Transporter.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }

        public Route(Guid id, Node startNode, Node endNode)
        {
            Id = id;
            StartNode = startNode;
            EndNode = endNode;
        }

        protected Route()
        {
        }
    }
}