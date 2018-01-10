using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;


namespace ScheduleSvc.Jobs
{
    public abstract class JobBase
    {
        private static ILog _log = LogManager.GetLogger(typeof(JobBase));
        protected string Guid;

        public void Execute()
        {
            Guid = System.Guid.NewGuid().ToString();

            if (PreProcess())
            {
                _log.Debug(string.Format("{0}: Begin {1}", Guid, GetType().Name));
                Process();
                _log.Debug(string.Format("{0} End {1}", Guid, GetType().Name));
            }
        }

        protected virtual bool PreProcess()
        {
            return true;
        }

        public abstract void Process();
    }
}
