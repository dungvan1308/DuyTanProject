using log4net;
using ScheduleCommon.Caches;
using ScheduleEntity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ScheduleCommon.Factories
{
    public class CacheFactory : CacheBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CacheFactory));
        private static readonly Lazy<CacheFactory> _lazy = new Lazy<CacheFactory>(() => new CacheFactory());
        private Timer _timer = null;
        private int _intervalTimerChecking = int.Parse(ConfigurationManager.AppSettings["IntervalTimerChecking"]);

        public static CacheFactory Instance
        {
            get { return _lazy.Value; }
        }

        private CacheFactory()
        {
            foreach (Type type in Assembly.GetAssembly(typeof(CacheBase)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CacheBase)) && myType.Name.EndsWith("Cache")))
            {
                CacheBase cache = (CacheBase)Activator.CreateInstance(type);
                if (cache.IsFactory)
                {
                    if (Add(type.Name, (CacheBase)Activator.CreateInstance(type)))
                    {
                        _log.Info("Add new cache with name " + type.Name);
                    }
                }
            }

            #region Initialize timer removes expired cache
            _timer = new Timer((state) =>
            {
                try
                {
                    ICollection<string> keys = null;
                    foreach (KeyValuePair<string, object> pair in Dictionary)
                    {
                        CacheBase cache = pair.Value as CacheBase;

                        #region Expire
                        if (cache.Count > 0)
                        {
                            keys = cache.GetAll<ConcurrentDictionary<string, object>>()
                                    .Where(p => DateTime.Now.Subtract((p.Value as CacheExpiration).CreatedAt).TotalSeconds > cache.Duration)
                                    .ToDictionary(p => p.Key, p => p.Value).Keys;

                            if (keys != null && keys.Count > 0)
                            {
                                foreach (string key in keys)
                                {
                                    cache.Remove(key);
                                }
                            }
                        }
                        #endregion

                        #region Reload
                        if (DateTime.Now.Hour == 4 && DateTime.Now.Minute == 0 && DateTime.Now.Second < _intervalTimerChecking)
                        {
                            if (!cache.IsSync)
                            {
                                if (cache.GetAll())
                                {
                                    _log.Info(string.Format("Reload {0}: {1}", cache.Name, cache.Count));
                                }
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }, null, Timeout.Infinite, Timeout.Infinite);
            _timer.Change(0, 100 * _intervalTimerChecking);
            #endregion
        }

        public void Init()
        {
        }

        public override bool Add<T>(string key, T value)
        {
            bool result = Dictionary.TryAdd(key, value);

            if (result)
            {
                CacheBase cache = value as CacheBase;
                if (cache.GetAll())
                {
                    _log.Info(string.Format("Load {0}: {1}", cache.GetType().Name, cache.Count));
                }
            }

            return result;
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
