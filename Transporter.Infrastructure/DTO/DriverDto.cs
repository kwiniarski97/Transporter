using System;
using System.Collections.Generic;
using Transporter.Core.Domain;

namespace Transporter.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}