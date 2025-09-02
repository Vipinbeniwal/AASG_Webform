using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class MenuMasterBL
    {
        #region Properties/Variables
        MenuMasterDL _MenuMasterDAL = new MenuMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public MenuMasterBL()
        {
            // this._MenuMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.MenuMaster>();
        }

        public MenuMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._MenuMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.MenuMaster>();
        }
        #endregion

        public BusinessModel.MenuMaster CreateMenuMaster(BusinessModel.MenuMaster MenuMasterBusinessObject)
        {
            Mapper.Mappings.MapMenuMaster MenuMasterMenu = new Mapper.Mappings.MapMenuMaster();

            var report = MenuMasterMenu.GetMenuMasterDatabaseObject(MenuMasterBusinessObject);

            report = this._MenuMasterDAL.Create(report, this.LoggedInUser);

            MenuMasterBusinessObject = MenuMasterMenu.GetMenuMasterBusinessObject(report);

            return MenuMasterBusinessObject;

        }

        public List<BusinessModel.MenuMaster> GetAllMenuMasterItems()
        {
            Mapper.Mappings.MapMenuMaster MenuMasterMenu = new Mapper.Mappings.MapMenuMaster();

            var MenuMasterItemsDALList = this._MenuMasterDAL.GetAll();

            List<BusinessModel.MenuMaster> MenuMasterItemsBusinessList = new List<BusinessModel.MenuMaster>();
            foreach (App.Data.MenuMaster MenuMasterItem in MenuMasterItemsDALList)
            {
                MenuMasterItemsBusinessList.Add(MenuMasterMenu.GetMenuMasterBusinessObject(MenuMasterItem));
            }

            return MenuMasterItemsBusinessList;
        }

        public List<BusinessModel.MenuMaster> GetMenuMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapMenuMaster MenuMasterMenu = new Mapper.Mappings.MapMenuMaster();

            var MenuMasterItemsDALList = this._MenuMasterDAL.GetbyId(Id);

            List<BusinessModel.MenuMaster> MenuMasterItemsBusinessList = new List<BusinessModel.MenuMaster>();
            foreach (App.Data.MenuMaster MenuMasterItem in MenuMasterItemsDALList)
            {
                MenuMasterItemsBusinessList.Add(MenuMasterMenu.GetMenuMasterBusinessObject(MenuMasterItem));
            }

            return MenuMasterItemsBusinessList;
        }

        public List<BusinessModel.MenuMaster> GetMenuMasterByName(string term)
        {
            Mapper.Mappings.MapMenuMaster MenuMasterMenu = new Mapper.Mappings.MapMenuMaster();

            var MenuMasterItemsDALList = this._MenuMasterDAL.GetByName(term);

            List<BusinessModel.MenuMaster> MenuMasterItemsBusinessList = new List<BusinessModel.MenuMaster>();

            foreach (App.Data.MenuMaster MenuMasterItem in MenuMasterItemsDALList)
            {
                MenuMasterItemsBusinessList.Add(MenuMasterMenu.GetMenuMasterBusinessObject(MenuMasterItem));
            }

            return MenuMasterItemsBusinessList;
        }

        public BusinessModel.MenuMaster UpdateMenuMaster(BusinessModel.MenuMaster MenuMasterBusinessObject)
        {
            Mapper.Mappings.MapMenuMaster mapMenuMaster = new Mapper.Mappings.MapMenuMaster();

            var MenuMaster = mapMenuMaster.GetMenuMasterDatabaseObject(MenuMasterBusinessObject);

            MenuMaster = this._MenuMasterDAL.Update(MenuMaster, this.LoggedInUser);

            MenuMasterBusinessObject = mapMenuMaster.GetMenuMasterBusinessObject(MenuMaster);

            return MenuMasterBusinessObject;

        }

        public bool DeleteMenuMaster(BusinessModel.MenuMaster MenuMasterBusinessObject)
        {
            Mapper.Mappings.MapMenuMaster mapMenuMaster = new Mapper.Mappings.MapMenuMaster();

            var MenuMaster = mapMenuMaster.GetMenuMasterDatabaseObject(MenuMasterBusinessObject);

            bool status = this._MenuMasterDAL.Delete(MenuMaster, this.LoggedInUser);

            return status;
        }

    }
}
