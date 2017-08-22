using System;
using System.Collections.Generic;
using Transporter.Core.Domain;

namespace Transporter.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Vehicle Vehicle { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}