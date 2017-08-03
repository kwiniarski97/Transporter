using System;

namespace Transporter.Core.Domain
{
    public class Passanger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Node Adress { get; protected set; }
        
        public Passanger(Guid userId, Node adress)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Adress = adress;
        }

        protected Passanger()
        {
        }
    }
}