using Transporter.Core.Domain;

namespace Transporter.Infrastructure.DTO
{
    public class RouteDto
    {
        public string Name { get;  set; }
        public Node StartNode { get;  set; }
        public Node EndNode { get;  set; }
        public double Distance { get;  set; }
    }
}