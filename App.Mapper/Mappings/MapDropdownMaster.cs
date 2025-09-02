using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapDropdownMaster
    {
        #region Activity Log Mapping

        public App.BusinessModel.DropdownMaster GetDropdownMasterBusinessObject(App.Data.DropdownMaster DropdownMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.DropdownMaster, App.BusinessModel.DropdownMaster>();
            var DropdownMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.DropdownMaster, App.BusinessModel.DropdownMaster>(DropdownMasterDBObject);
            return DropdownMasterBusinessObject;
        }

        public App.Data.DropdownMaster GetDropdownMasterDatabaseObject(App.BusinessModel.DropdownMaster DropdownMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.DropdownMaster, App.Data.DropdownMaster>();
            var DropdownMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.DropdownMaster, App.Data.DropdownMaster>(DropdownMasterBusinessObject);
            return DropdownMasterDBObject;
        }

        #endregion
    }
}
