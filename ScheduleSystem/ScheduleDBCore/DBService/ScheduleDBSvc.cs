using ScheduleDBCore.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ScheduleDBCore.DBService
{
    public class ScheduleDBSvc : SQLBaseService
    {        
        public ScheduleDBSvc(int userId) : base(userId) { }
        public ScheduleDBSvc(int userId, ConnectionType connectionType) : base(userId, connectionType) { }

        
        public DataTable GetSchedule()
        {
            try
            {
                ResetValue();
                return _sqlHelper.ExecuteSPDataTable("Schedule_GetSchedule");
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex, (MethodInfo)MethodBase.GetCurrentMethod());
                return null;
            }
        }


        public DataTable GetProperty()
        {
            try
            {
                ResetValue();
                return _sqlHelper.ExecuteSPDataTable("Schedule_GetProperty");
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex, (MethodInfo)MethodBase.GetCurrentMethod());
                return null;
            }
        }
    }
}
