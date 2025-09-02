using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class UserRoleBL
    {
        #region Properties/Variables
        UserRoleDL _UserRoleDAL = new UserRoleDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public UserRoleBL()
        {
            // this._UserRoleDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.UserRole>();
        }

        public UserRoleBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._UserRoleDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.UserRole>();
        }
        #endregion

        public BusinessModel.UserRole CreateUserRole(BusinessModel.UserRole UserRoleBusinessObject)
        {
            Mapper.Mappings.MapUserRole UserRoleMenu = new Mapper.Mappings.MapUserRole();

            var report = UserRoleMenu.GetUserRoleDatabaseObject(UserRoleBusinessObject);

            report = this._UserRoleDAL.Create(report, this.LoggedInUser);

            UserRoleBusinessObject = UserRoleMenu.GetUserRoleBusinessObject(report);

            return UserRoleBusinessObject;

        }

        public List<BusinessModel.UserRole> GetAllUserRoleItems()
        {
            Mapper.Mappings.MapUserRole UserRoleMenu = new Mapper.Mappings.MapUserRole();

            var UserRoleItemsDALList = this._UserRoleDAL.GetAll();

            List<BusinessModel.UserRole> UserRoleItemsBusinessList = new List<BusinessModel.UserRole>();
            foreach (App.Data.UserRole UserRoleItem in UserRoleItemsDALList)
            {
                UserRoleItemsBusinessList.Add(UserRoleMenu.GetUserRoleBusinessObject(UserRoleItem));
            }

            return UserRoleItemsBusinessList;
        }

        public List<BusinessModel.UserRole> GetUserRoleItemsByID(int Id)
        {
            Mapper.Mappings.MapUserRole UserRoleMenu = new Mapper.Mappings.MapUserRole();

            var UserRoleItemsDALList = this._UserRoleDAL.GetbyId(Id);

            List<BusinessModel.UserRole> UserRoleItemsBusinessList = new List<BusinessModel.UserRole>();
            foreach (App.Data.UserRole UserRoleItem in UserRoleItemsDALList)
            {
                UserRoleItemsBusinessList.Add(UserRoleMenu.GetUserRoleBusinessObject(UserRoleItem));
            }

            return UserRoleItemsBusinessList;
        }

        public List<BusinessModel.UserRole> GetUserRoleByName(string term)
        {
            Mapper.Mappings.MapUserRole UserRoleMenu = new Mapper.Mappings.MapUserRole();

            var UserRoleItemsDALList = this._UserRoleDAL.GetByName(term);

            List<BusinessModel.UserRole> UserRoleItemsBusinessList = new List<BusinessModel.UserRole>();

            foreach (App.Data.UserRole UserRoleItem in UserRoleItemsDALList)
            {
                UserRoleItemsBusinessList.Add(UserRoleMenu.GetUserRoleBusinessObject(UserRoleItem));
            }

            return UserRoleItemsBusinessList;
        }

        public BusinessModel.UserRole UpdateUserRole(BusinessModel.UserRole UserRoleBusinessObject)
        {
            Mapper.Mappings.MapUserRole mapUserRole = new Mapper.Mappings.MapUserRole();

            var UserRole = mapUserRole.GetUserRoleDatabaseObject(UserRoleBusinessObject);

            UserRole = this._UserRoleDAL.Update(UserRole, this.LoggedInUser);

            UserRoleBusinessObject = mapUserRole.GetUserRoleBusinessObject(UserRole);

            return UserRoleBusinessObject;

        }

        public bool DeleteUserRole(BusinessModel.UserRole UserRoleBusinessObject)
        {
            Mapper.Mappings.MapUserRole mapUserRole = new Mapper.Mappings.MapUserRole();

            var UserRole = mapUserRole.GetUserRoleDatabaseObject(UserRoleBusinessObject);

            bool status = this._UserRoleDAL.Delete(UserRole, this.LoggedInUser);

            return status;
        }

    }
}
