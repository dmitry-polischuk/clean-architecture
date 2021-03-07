using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
