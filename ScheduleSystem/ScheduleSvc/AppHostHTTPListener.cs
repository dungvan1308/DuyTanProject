using log4net;
using System;
using ServiceStack;
using ScheduleEntity;
using ScheduleCommon.Caches;
using ScheduleCommon.Factories;

namespace ScheduleSvc
{
    public class AppHostHTTPListener : AppHostHttpListenerSmartPoolBase
    {
        public AppHostHTTPListener() : base("ScheduleSystem", typeof(AppHostHTTPListener).Assembly) { }

        public AppHostHTTPListener(int poolSite) : base("ScheduleSystem", poolSite, typeof(AppHostHTTPListener).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            #region Plugins
            RegisterService(typeof(HTTPService), null);
            #endregion
        }

        private class HTTPService : Service
        {
            private readonly ILog _log = LogManager.GetLogger(typeof(HTTPService));
            
            public void Get(CacheObject request)
            {
                try
                {
                    CacheBase cache = CacheFactory.Instance.Get<CacheBase>(request.Name);
                    if (cache != null)
                    {
                        if (!cache.IsSync)
                        {
                            if (cache.GetAll())
                            {
                                _log.Info(string.Format("Reload {0}: {1}", cache.Name, cache.Count));
                            }
                        }
                    }
                    else
                    {
                        _log.Debug(string.Format("Cannot get cache: {0}", request.Name));
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
        }        
    }
}
