using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace ScheduleSvc.ScheduleEntity
{
    [Route("/cache/{Name}")]
    public class CacheObject
    {
        public string Name { get; set; }
    }
}
