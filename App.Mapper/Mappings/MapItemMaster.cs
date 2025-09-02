using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapItemMaster
    {
        #region Activity Log Mapping

        public App.BusinessModel.ItemMaster GetItemMasterBusinessObject(App.Data.ItemMaster ItemMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ItemMaster, App.BusinessModel.ItemMaster>();
            var ItemMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.ItemMaster, App.BusinessModel.ItemMaster>(ItemMasterDBObject);
            return ItemMasterBusinessObject;
        }

        public App.Data.ItemMaster GetItemMasterDatabaseObject(App.BusinessModel.ItemMaster ItemMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ItemMaster, App.Data.ItemMaster>();
            var ItemMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ItemMaster, App.Data.ItemMaster>(ItemMasterBusinessObject);
            return ItemMasterDBObject;
        }

        #endregion
    }
}
