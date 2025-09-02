using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapMenuMaster
    {
        #region MenuMaster Mapping

        public MenuMaster GetMenuMasterBusinessObject(App.Data.MenuMaster MenuMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.MenuMaster, MenuMaster>();
            var MenuMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.MenuMaster, MenuMaster>(MenuMasterDBObject);
            return MenuMasterBusinessObject;
        }

        public App.Data.MenuMaster GetMenuMasterDatabaseObject(MenuMaster MenuMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<MenuMaster, App.Data.MenuMaster>();
            var MenuMasterDBObject = AutoMapper.Mapper.Map<MenuMaster, App.Data.MenuMaster>(MenuMasterBusinessObject);
            return MenuMasterDBObject;
        }

        #endregion
    }
}
