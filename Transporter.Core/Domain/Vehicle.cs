using System;
using System.Security.Cryptography.X509Certificates;

namespace Transporter.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public uint Seats { get; protected set; }

        public Vehicle(string name, string brand, uint seats)
        {
            SetName(name);
            SetBrand(brand);
            SetSeats(seats);
        }
        
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty");
            }
            if (string.Equals(name, Name))
            {
                return;
            }
            Name = name;
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Brand cannot be empty");
            }
            if (string.Equals(brand, Brand))
            {
                return;
            }
            Brand = brand;
        }

        private void SetSeats(uint seats)
        {
            if (seats < 2)
            {
                throw new Exception("Car should have more than 1 seat");
            }
            if (Seats == seats)
            {
                return;
            }
            Seats = seats;
        }


        protected Vehicle()
        {
        }
        
        
        
    }
}