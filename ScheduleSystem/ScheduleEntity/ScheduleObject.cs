using System;
using System.Collections.Generic;

namespace ScheduleEntity
{
    public class ScheduleObject : CacheExpiration
    {
        public string JobName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IntervalTime { get; set; }
        public Dictionary<string, PropertyObject> Properties { get; set; }
        public DateTime CreatedAt { get; set; }
        public ScheduleObject()
        {
            CreatedAt = DateTime.Now;
            Properties = new Dictionary<string, PropertyObject>();
        }
    }
}
