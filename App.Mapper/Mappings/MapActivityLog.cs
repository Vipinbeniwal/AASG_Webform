using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapActivityLog
    {
        #region Activity Log Mapping

        public App.BusinessModel.ActivityLog GetActivityLogBusinessObject(App.Data.ActivityLog ActivityLogDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ActivityLog, App.BusinessModel.ActivityLog>();
            var ActivityLogBusinessObject = AutoMapper.Mapper.Map<App.Data.ActivityLog, App.BusinessModel.ActivityLog>(ActivityLogDBObject);
            return ActivityLogBusinessObject;
        }

        public App.Data.ActivityLog GetActivityLogDatabaseObject(App.BusinessModel.ActivityLog ActivityLogBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ActivityLog, App.Data.ActivityLog>();
            var ActivityLogDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ActivityLog, App.Data.ActivityLog>(ActivityLogBusinessObject);
            return ActivityLogDBObject;
        }

        #endregion
    }
}
