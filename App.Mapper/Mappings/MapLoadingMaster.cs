using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapLoadingMaster
    {
        #region Activity Log Mapping

        public App.BusinessModel.LoadingMaster GetLoadingMasterBusinessObject(App.Data.LoadingMaster LoadingMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.LoadingMaster, App.BusinessModel.LoadingMaster>();
            var LoadingMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.LoadingMaster, App.BusinessModel.LoadingMaster>(LoadingMasterDBObject);
            return LoadingMasterBusinessObject;
        }

        public App.Data.LoadingMaster GetLoadingMasterDatabaseObject(App.BusinessModel.LoadingMaster LoadingMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.LoadingMaster, App.Data.LoadingMaster>();
            var LoadingMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.LoadingMaster, App.Data.LoadingMaster>(LoadingMasterBusinessObject);
            return LoadingMasterDBObject;
        }

        #endregion
    }
}
