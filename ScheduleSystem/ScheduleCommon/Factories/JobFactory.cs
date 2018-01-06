using log4net;
using ScheduleCommon.Caches;
using ScheduleCommon.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCommon.Factories
{
    public class JobFactory : CacheBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(JobFactory));
        private static readonly Lazy<JobFactory> _lazy = new Lazy<JobFactory>(() => new JobFactory());

        public static JobFactory Instance
        {
            get { return _lazy.Value; }
        }

        private JobFactory()
        {
            foreach (Type type in Assembly.GetAssembly(typeof(JobBase)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(JobBase))))
            {
                if (Add(type.Name, (JobBase)Activator.CreateInstance(type)))
                {
                    _log.Info("Add new job with name " + type.Name);
                }
            }
        }

        public override bool Add<T>(string key, T value)
        {
            return Dictionary.TryAdd(key, value);
        }

        public override bool Remove(string key)
        {
            object value;
            if (Dictionary.TryRemove(key, out value))
            {
                return true;
            }
            return false;
        }

        public override T Get<T>(string key)
        {
            object value;
            if (Dictionary.TryGetValue(key, out value))
            {
                return value as T;
            }
            return null;
        }
    }
}