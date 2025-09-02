using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessWashingOne
    {
        #region ProcessWashingOne Mapping

        public App.BusinessModel.ProcessWashingOne GetProcessWashingOneBusinessObject(App.Data.ProcessWashingOne ProcessWashingOneDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessWashingOne, App.BusinessModel.ProcessWashingOne>();
            var ProcessWashingOneBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessWashingOne, App.BusinessModel.ProcessWashingOne>(ProcessWashingOneDBObject);
            return ProcessWashingOneBusinessObject;
        }

        public App.Data.ProcessWashingOne GetProcessWashingOneDatabaseObject(App.BusinessModel.ProcessWashingOne ProcessWashingOneBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessWashingOne, App.Data.ProcessWashingOne>();
            var ProcessWashingOneDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessWashingOne, App.Data.ProcessWashingOne>(ProcessWashingOneBusinessObject);
            return ProcessWashingOneDBObject;
        }

        #endregion
    }
}
