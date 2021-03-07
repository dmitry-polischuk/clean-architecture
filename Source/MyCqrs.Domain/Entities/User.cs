using System;
using System.Collections.Generic;
using System.Text;

namespace MyCqrs.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get;set; }
        public List<Device> Devices { get; set; }
        public List<Desire> Desires { get; set; }
    }
}
