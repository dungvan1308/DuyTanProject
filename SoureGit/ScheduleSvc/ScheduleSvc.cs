using System;
using System.ServiceProcess;
using System.Configuration;
using System.Threading;
using log4net;
using System.IO;
//using ScheduleCommon;
//using ScheduleCommon.Execute;
//using ScheduleCommon.Factories;

using ScheduleSvc.ScheduleEntity;
using ScheduleSvc.Factories;
using ScheduleSvc.Caches;
using ScheduleSvc.Execute;


namespace ScheduleSvc
{
    public partial class ScheduleSvc : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ScheduleSvc));
        private AppHostHTTPListener _appHostHTTP;

        public ScheduleSvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                #region Init Log4Net
                GlobalContext.Properties["AppFolder"] = ConfigurationManager.AppSettings["AppFolder"];
                GlobalContext.Properties["AppName"] = ConfigurationManager.AppSettings["AppName"];
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigurationManager.AppSettings["Log4NetConfigurationPath"]));
                #endregion

                #region Init Schedule
                GlobalObject.Scheduler = new Scheduler();
                #endregion

                #region Init HTTP Listener
                _appHostHTTP = new AppHostHTTPListener();
                _appHostHTTP.Init().Start( ConfigurationManager.AppSettings["HTTPUrl"] );
                #endregion
                
                CacheFactory.Instance.Init();

                _log.Info(string.Format(ConfigurationManager.AppSettings["AppName"] + " started ok with user interactive ({0})", Environment.UserInteractive.ToString()));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                _log.Info(ConfigurationManager.AppSettings["AppName"] + " started failed");
            }
        }

        protected override void OnStop()
        {
            try
            {
                _appHostHTTP.Stop();
                _appHostHTTP.Dispose();
                GlobalObject.Scheduler.Dispose();
                _log.Info(string.Format("{0} stopped ok", ConfigurationManager.AppSettings["AppName"]));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            LogManager.Shutdown();
        }

        static void Main()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsRunAsService"]))
            {
                Run(new ScheduleSvc());
            }
            else
            {
                ScheduleSvc service = new ScheduleSvc();
                service.OnStart(null);
                Console.ReadLine();
                Thread.Sleep(1000000);
            }
        }
    }
}
