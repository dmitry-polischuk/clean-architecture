using System;
using System.Collections.Generic;
using System.Text;

namespace MyCqrs.Domain.Entities
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
