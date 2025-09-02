using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessTemperingReport
    {
        #region ProcessTemperingReport Mapping

        public App.BusinessModel.ProcessTemperingReport GetProcessTemperingReportBusinessObject(App.Data.ProcessTemperingReport ProcessTemperingReportDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessTemperingReport, App.BusinessModel.ProcessTemperingReport>();
            var ProcessTemperingReportBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessTemperingReport, App.BusinessModel.ProcessTemperingReport>(ProcessTemperingReportDBObject);
            return ProcessTemperingReportBusinessObject;
        }

        public App.Data.ProcessTemperingReport GetProcessTemperingReportDatabaseObject(App.BusinessModel.ProcessTemperingReport ProcessTemperingReportBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessTemperingReport, App.Data.ProcessTemperingReport>();
            var ProcessTemperingReportDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessTemperingReport, App.Data.ProcessTemperingReport>(ProcessTemperingReportBusinessObject);
            return ProcessTemperingReportDBObject;
        }

        #endregion
    }
}
