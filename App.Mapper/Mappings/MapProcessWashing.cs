using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessWashing
    {
        #region ProcessWashing Mapping

        public App.BusinessModel.ProcessWashing GetProcessWashingBusinessObject(App.Data.ProcessWashing ProcessWashingDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessWashing, App.BusinessModel.ProcessWashing>();
            var ProcessWashingBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessWashing, App.BusinessModel.ProcessWashing>(ProcessWashingDBObject);
            return ProcessWashingBusinessObject;
        }

        public App.Data.ProcessWashing GetProcessWashingDatabaseObject(App.BusinessModel.ProcessWashing ProcessWashingBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessWashing, App.Data.ProcessWashing>();
            var ProcessWashingDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessWashing, App.Data.ProcessWashing>(ProcessWashingBusinessObject);
            return ProcessWashingDBObject;
        }

        #endregion
    }
}
