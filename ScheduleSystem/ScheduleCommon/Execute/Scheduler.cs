using log4net;
using ScheduleCommon.Caches;
using ScheduleCommon.Factories;
using ScheduleCommon.Jobs;
using ScheduleEntity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleCommon.Execute
{
    public class Scheduler : IDisposable
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Scheduler));
        private List<Task> _tasks = new List<Task>();
        private Timer _timerScheduler;
        private int _intervalTimerScheduler = int.Parse(ConfigurationManager.AppSettings["IntervalTimerScheduler"]) * 100;

        public Scheduler()
        {
            _timerScheduler = new Timer((state) =>
            {
                try
                {
                    DateTime now = DateTime.Parse(DateTime.Now.ToString());
                    ICollection<string> keys = CacheFactory.Instance.Get<CacheBase>("ScheduleCache").GetAll<ConcurrentDictionary<string, object>>()
                        .Where(x => (int)now.Subtract(((ScheduleObject)x.Value).StartTime).TotalSeconds >= 0 && (int)now.Subtract(((ScheduleObject)x.Value).EndTime).TotalSeconds <= 0
                                && (((ScheduleObject)x.Value).StartTime == ((ScheduleObject)x.Value).EndTime || (int)now.Subtract(((ScheduleObject)x.Value).StartTime).TotalSeconds % ((ScheduleObject)x.Value).IntervalTime == 0))
                        .ToDictionary(p => p.Key, p => p.Value)
                        //.Where(x => true)
                        //.ToDictionary(p => p.Key, p => p.Value)
                        .Keys;
                    foreach (string key in keys)
                    {
                        JobBase job = JobFactory.Instance.Get<JobBase>(key);
                        if (job != null)
                        {
                            _tasks.Add(Task.Factory.StartNew(() => job.Execute()));
                        }
                        else
                        {
                            _log.Debug(string.Format("Cannot get {0}", key));
                        }
                    }

                    _tasks.RemoveAll(x => x.IsCompleted);
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }, null, 0, _intervalTimerScheduler);

            _log.Info("The scheduler: started");
        }

        public void Dispose()
        {
            _timerScheduler.Dispose();
            while (_tasks.Count > 0)
            {
                Thread.Sleep(1000);
                _tasks.RemoveAll(x => x.IsCompleted);
            }
        }
    }
}
