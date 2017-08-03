namespace Transporter.Core.Domain
{
    public class Node
    {
        public string Adress { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        public Node(string adress, double longitude, double latitude)
        {
            Adress = adress;
            Longitude = longitude;
            Latitude = latitude;
        }

        protected Node()
        {
        }
    }
}