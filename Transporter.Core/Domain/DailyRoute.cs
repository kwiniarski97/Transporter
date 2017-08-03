using System;
using System.Collections.Generic;

namespace Transporter.Core.Domain
{
    public class DailyRoute
    {
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassangerNode> PassangerNodes { get; protected set; }

        public DailyRoute(Guid id, Route route, IEnumerable<PassangerNode> passangerNodes)
        {
            Id = id;
            Route = route;
            PassangerNodes = passangerNodes;
        }

        protected DailyRoute()
        {
        }
    }
}