using System;

namespace Transporter.Core.Domain
{
    public class Node
    {
        public string Adress { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        public Node(string adress, double longitude, double latitude)
        {
            SetAdress(adress);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        private void SetAdress(string adress)
        {
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new Exception("Adress cannot be empty");
            }
            if (Adress == adress)
            {
                return;
            }
            Adress = adress;
        }

        private void SetLongitude(double longitude)
        {
            if (longitude < -180 || longitude > 180)
            {
                throw new Exception("Invalid longitude.");
            }
            if (Math.Abs(longitude - Longitude) < 0.00001)
            {
                return;
            }
            Longitude = longitude;
        }

        private void SetLatitude(double latitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new Exception("Invalid latiude.");
            }
            if (Math.Abs(Latitude - latitude) < 0.00001)
            {
                return;
            }
            Latitude = latitude;
        }

        protected Node()
        {
        }
    }
}