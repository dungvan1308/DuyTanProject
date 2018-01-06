using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCommon.Jobs
{
    public class DummyJob : JobBase
    {
        private static ILog _log = LogManager.GetLogger(typeof(DummyJob));

        public override void Process()
        {
            _log.Debug(string.Format("{0}: ...", Guid));
        }
    }
}
