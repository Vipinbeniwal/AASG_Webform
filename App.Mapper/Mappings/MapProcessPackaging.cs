using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessPackaging
    {
        #region ProcessPackaging Mapping

        public App.BusinessModel.ProcessPackaging GetProcessPackagingBusinessObject(App.Data.ProcessPackaging ProcessPackagingDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessPackaging, App.BusinessModel.ProcessPackaging>();
            var ProcessPackagingBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessPackaging, App.BusinessModel.ProcessPackaging>(ProcessPackagingDBObject);
            return ProcessPackagingBusinessObject;
        }

        public App.Data.ProcessPackaging GetProcessPackagingDatabaseObject(App.BusinessModel.ProcessPackaging ProcessPackagingBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessPackaging, App.Data.ProcessPackaging>();
            var ProcessPackagingDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessPackaging, App.Data.ProcessPackaging>(ProcessPackagingBusinessObject);
            return ProcessPackagingDBObject;
        }

        #endregion
    }
}
