using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessDfgPrint
    {
        #region ProcessDfgPrint Mapping

        public App.BusinessModel.ProcessDfgPrint GetProcessDfgPrintBusinessObject(App.Data.ProcessDfgPrint ProcessDfgPrintDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessDfgPrint, App.BusinessModel.ProcessDfgPrint>();
            var ProcessDfgPrintBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessDfgPrint, App.BusinessModel.ProcessDfgPrint>(ProcessDfgPrintDBObject);
            return ProcessDfgPrintBusinessObject;
        }

        public App.Data.ProcessDfgPrint GetProcessDfgPrintDatabaseObject(App.BusinessModel.ProcessDfgPrint ProcessDfgPrintBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessDfgPrint, App.Data.ProcessDfgPrint>();
            var ProcessDfgPrintDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessDfgPrint, App.Data.ProcessDfgPrint>(ProcessDfgPrintBusinessObject);
            return ProcessDfgPrintDBObject;
        }

        #endregion
    }
}
