using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapStaffMaster
    {
        #region StaffMaster Mapping

        public App.BusinessModel.StaffMaster GetStaffMasterBusinessObject(App.Data.StaffMaster StaffMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.StaffMaster, App.BusinessModel.StaffMaster>();
            var StaffMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.StaffMaster, App.BusinessModel.StaffMaster>(StaffMasterDBObject);
            return StaffMasterBusinessObject;
        }

        public App.Data.StaffMaster GetStaffMasterDatabaseObject(App.BusinessModel.StaffMaster StaffMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.StaffMaster, App.Data.StaffMaster>();
            var StaffMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.StaffMaster, App.Data.StaffMaster>(StaffMasterBusinessObject);
            return StaffMasterDBObject;
        }

        #endregion
    }
}
