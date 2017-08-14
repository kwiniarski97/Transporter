using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter.Core.Domain
{
    public class DailyRoute
    {
        private ISet<PassangerNode> _passangerNodes = new HashSet<PassangerNode>();


        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassangerNode> PassangerNodes { get; protected set; }

        

        protected DailyRoute()
        {
            Id = Guid.NewGuid();
        }

        public void AddPassengerNode(Passanger passanger, Node node)
        {
            if (GetPassengerNode(passanger) == null)
            {
                throw new Exception($"Node already exist for passenger : {passanger}");
            }
            _passangerNodes.Add(PassangerNode.Create(passanger, node));
        }

        public void RemovePassengerNode(Passanger passanger)
        {
            var node = GetPassengerNode(passanger);
            if (node == null)
            {
                return;
            }
            _passangerNodes.Remove(node);
        }

        private PassangerNode GetPassengerNode(Passanger passanger) =>
            _passangerNodes.SingleOrDefault(x => x.Passanger.UserId == passanger.UserId);
            
        
    }
}