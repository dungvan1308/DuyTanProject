using log4net;
using ScheduleDBCore.DBService;
using ScheduleEntity;
using System;
using System.Data;

namespace ScheduleCommon.Caches
{
    public class ScheduleCache : CacheBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ScheduleCache));

        public ScheduleCache()
        {
            Name = "ScheduleCache";
            IsFactory = true;
            IsSync = false;
            IsAbsolute = true;
            Duration = int.MaxValue;
        }

        public override bool Add<T>(string key, T value)
        {
            bool result = Dictionary.TryAdd(key, value);
            ScheduleObject schedule = value as ScheduleObject;
            if (result)
            {
                _log.Info("Add Schedule with ID " + key);
            }
            else
            {
                object comparison;
                if (Dictionary.TryGetValue(key, out comparison))
                {
                    result = Dictionary.TryUpdate(key, value, comparison);
                    if (result)
                    {
                        _log.Info("Update Schedule with ID " + key);
                    }
                }
            }
            return result;
        }

        public override bool Remove(string key)
        {
            object value;
            bool result = Dictionary.TryRemove(key, out value);
            if (result)
            {
                _log.Info("Remove Schedule with ID " + key);
            }
            return result;
        }

        public override T Get<T>(string key)
        {
            object value;
            if (Dictionary.TryGetValue(key, out value))
            {
                return value as T;
            }
            return default(T);
        }

        public override bool GetAll()
        {
            try
            {
                Dictionary.Clear();
                using (ScheduleDBSvc scheduleSvc = new ScheduleDBSvc(0, ScheduleDBCore.Enum.ConnectionType.ScheduleDB))
                {
                    DataTable dtSchedule = scheduleSvc.GetSchedule();
                    DataTable dtProperty = scheduleSvc.GetProperty();
                    foreach (DataRow dr in dtSchedule.Rows)
                    {
                        ScheduleObject schedule = new ScheduleObject();
                        schedule.JobName = dr["JobName"].ToString();
                        schedule.StartTime = DateTime.Parse(dr["StartTime"].ToString());
                        schedule.EndTime = DateTime.Parse(dr["EndTime"].ToString());
                        schedule.IntervalTime = int.Parse(dr["IntervalTime"].ToString());
                        foreach (DataRow drProperty in dtProperty.Select(string.Format("JobName='{0}'", dr["JobName"].ToString())))
                        {
                            PropertyObject property = new PropertyObject();
                            property.PropertyName = drProperty["PropertyName"].ToString();
                            property.PropertyValue = drProperty["PropertyValue"].ToString();
                            schedule.Properties.Add(property.PropertyValue, property);
                        }
                        Add(schedule.JobName, schedule);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return false;
        }
    }
}
