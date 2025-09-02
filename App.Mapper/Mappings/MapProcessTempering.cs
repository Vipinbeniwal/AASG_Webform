using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessTempering
    {
        #region ProcessTempering Mapping

        public App.BusinessModel.ProcessTempering GetProcessTemperingBusinessObject(App.Data.ProcessTempering ProcessTemperingDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessTempering, App.BusinessModel.ProcessTempering>();
            var ProcessTemperingBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessTempering, App.BusinessModel.ProcessTempering>(ProcessTemperingDBObject);
            return ProcessTemperingBusinessObject;
        }

        public App.Data.ProcessTempering GetProcessTemperingDatabaseObject(App.BusinessModel.ProcessTempering ProcessTemperingBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessTempering, App.Data.ProcessTempering>();
            var ProcessTemperingDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessTempering, App.Data.ProcessTempering>(ProcessTemperingBusinessObject);
            return ProcessTemperingDBObject;
        }

        #endregion
    }
}
