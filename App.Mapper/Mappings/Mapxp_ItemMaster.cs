using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  Mapxp_ItemMaster
    {
        #region xp_ItemMaster Mapping

        public App.BusinessModel.xp_ItemMaster Getxp_ItemMasterBusinessObject(App.Data.xp_ItemMaster xp_ItemMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.xp_ItemMaster, App.BusinessModel.xp_ItemMaster>();
            var xp_ItemMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.xp_ItemMaster, App.BusinessModel.xp_ItemMaster>(xp_ItemMasterDBObject);
            return xp_ItemMasterBusinessObject;
        }

        public App.Data.xp_ItemMaster Getxp_ItemMasterDatabaseObject(App.BusinessModel.xp_ItemMaster xp_ItemMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.xp_ItemMaster, App.Data.xp_ItemMaster>();
            var xp_ItemMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.xp_ItemMaster, App.Data.xp_ItemMaster>(xp_ItemMasterBusinessObject);
            return xp_ItemMasterDBObject;
        }

        #endregion
    }
}
