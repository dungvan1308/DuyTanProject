using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEntity
{
    public class FunctionObject
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public FunctionObject()
        {
            Parameters = new Dictionary<string, string>();
        }
    }
}
