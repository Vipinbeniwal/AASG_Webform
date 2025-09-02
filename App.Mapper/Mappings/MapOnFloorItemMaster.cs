using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapOnFloorItemMaster
    {
        #region OnFloorItemMaster Mapping

        public App.BusinessModel.OnFloorItemMaster GetOnFloorItemMasterBusinessObject(App.Data.OnFloorItemMaster OnFloorItemMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.OnFloorItemMaster, App.BusinessModel.OnFloorItemMaster>();
            var OnFloorItemMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.OnFloorItemMaster, App.BusinessModel.OnFloorItemMaster>(OnFloorItemMasterDBObject);
            return OnFloorItemMasterBusinessObject;
        }

        public App.Data.OnFloorItemMaster GetOnFloorItemMasterDatabaseObject(App.BusinessModel.OnFloorItemMaster OnFloorItemMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.OnFloorItemMaster, App.Data.OnFloorItemMaster>();
            var OnFloorItemMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.OnFloorItemMaster, App.Data.OnFloorItemMaster>(OnFloorItemMasterBusinessObject);
            return OnFloorItemMasterDBObject;
        }

        #endregion
    }
}
