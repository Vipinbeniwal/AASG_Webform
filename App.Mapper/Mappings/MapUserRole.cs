using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapUserRole
    {
        #region Activity Log Mapping

        public App.BusinessModel.UserRole GetUserRoleBusinessObject(App.Data.UserRole UserRoleDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.UserRole, App.BusinessModel.UserRole>();
            var UserRoleBusinessObject = AutoMapper.Mapper.Map<App.Data.UserRole, App.BusinessModel.UserRole>(UserRoleDBObject);
            return UserRoleBusinessObject;
        }

        public App.Data.UserRole GetUserRoleDatabaseObject(App.BusinessModel.UserRole UserRoleBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.UserRole, App.Data.UserRole>();
            var UserRoleDBObject = AutoMapper.Mapper.Map<App.BusinessModel.UserRole, App.Data.UserRole>(UserRoleBusinessObject);
            return UserRoleDBObject;
        }

        #endregion
    }
}
