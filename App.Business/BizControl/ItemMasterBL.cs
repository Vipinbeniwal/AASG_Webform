using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ItemMasterBL
    {
        #region Properties/Variables
        ItemMasterDL _ItemMasterDAL = new ItemMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ItemMasterBL()
        {
            // this._ItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ItemMaster>();
        }

        public ItemMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ItemMaster>();
        }
        #endregion

        public BusinessModel.ItemMaster CreateItemMaster(BusinessModel.ItemMaster ItemMasterBusinessObject)
        {
            Mapper.Mappings.MapItemMaster ItemMasterMenu = new Mapper.Mappings.MapItemMaster();

            var report = ItemMasterMenu.GetItemMasterDatabaseObject(ItemMasterBusinessObject);

            report = this._ItemMasterDAL.Create(report, this.LoggedInUser);

            ItemMasterBusinessObject = ItemMasterMenu.GetItemMasterBusinessObject(report);

            return ItemMasterBusinessObject;

        }

        public List<BusinessModel.ItemMaster> GetAllItemMasterItems()
        {
            Mapper.Mappings.MapItemMaster ItemMasterMenu = new Mapper.Mappings.MapItemMaster();

            var ItemMasterItemsDALList = this._ItemMasterDAL.GetAll();

            List<BusinessModel.ItemMaster> ItemMasterItemsBusinessList = new List<BusinessModel.ItemMaster>();
            foreach (App.Data.ItemMaster ItemMasterItem in ItemMasterItemsDALList)
            {
                ItemMasterItemsBusinessList.Add(ItemMasterMenu.GetItemMasterBusinessObject(ItemMasterItem));
            }

            return ItemMasterItemsBusinessList;
        }


        public List<BusinessModel.vwItemListWithModelAndGlassColor> GetVwItemListWithModelAndGlassColors()
        {
            Mapper.Mappings.MapvwItemListWithModelAndGlassColor ItemMasterMenu = new Mapper.Mappings.MapvwItemListWithModelAndGlassColor();

            var ItemMasterItemsDALList = this._ItemMasterDAL.GetAllItemListWithModelAndGlassColor();

            List<BusinessModel.vwItemListWithModelAndGlassColor> vwItemListWithModelAndGlassColorBusinessList = new List<BusinessModel.vwItemListWithModelAndGlassColor>();
            foreach (App.Data.vwItemListWithModelAndGlassColor vwItemMasterItem in ItemMasterItemsDALList)
            {
                vwItemListWithModelAndGlassColorBusinessList.Add(ItemMasterMenu.GetvwItemListWithModelAndGlassColorBusinessObject(vwItemMasterItem));
            }

            return vwItemListWithModelAndGlassColorBusinessList;
        }


        public List<BusinessModel.ItemMaster> GetItemMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapItemMaster ItemMasterMenu = new Mapper.Mappings.MapItemMaster();

            var ItemMasterItemsDALList = this._ItemMasterDAL.GetbyId(Id);

            List<BusinessModel.ItemMaster> ItemMasterItemsBusinessList = new List<BusinessModel.ItemMaster>();
            foreach (App.Data.ItemMaster ItemMasterItem in ItemMasterItemsDALList)
            {
                ItemMasterItemsBusinessList.Add(ItemMasterMenu.GetItemMasterBusinessObject(ItemMasterItem));
            }

            return ItemMasterItemsBusinessList;
        }

        public List<BusinessModel.ItemMaster> GetItemMasterByName(string term)
        {
            Mapper.Mappings.MapItemMaster ItemMasterMenu = new Mapper.Mappings.MapItemMaster();

            var ItemMasterItemsDALList = this._ItemMasterDAL.GetByName(term);

            List<BusinessModel.ItemMaster> ItemMasterItemsBusinessList = new List<BusinessModel.ItemMaster>();

            foreach (App.Data.ItemMaster ItemMasterItem in ItemMasterItemsDALList)
            {
                ItemMasterItemsBusinessList.Add(ItemMasterMenu.GetItemMasterBusinessObject(ItemMasterItem));
            }

            return ItemMasterItemsBusinessList;
        }

        public BusinessModel.ItemMaster UpdateItemMaster(BusinessModel.ItemMaster ItemMasterBusinessObject)
        {
            Mapper.Mappings.MapItemMaster mapItemMaster = new Mapper.Mappings.MapItemMaster();

            var ItemMaster = mapItemMaster.GetItemMasterDatabaseObject(ItemMasterBusinessObject);

            ItemMaster = this._ItemMasterDAL.Update(ItemMaster, this.LoggedInUser);

            ItemMasterBusinessObject = mapItemMaster.GetItemMasterBusinessObject(ItemMaster);

            return ItemMasterBusinessObject;

        }

        public bool DeleteItemMaster(BusinessModel.ItemMaster ItemMasterBusinessObject)
        {
            Mapper.Mappings.MapItemMaster mapItemMaster = new Mapper.Mappings.MapItemMaster();

            var ItemMaster = mapItemMaster.GetItemMasterDatabaseObject(ItemMasterBusinessObject);

            bool status = this._ItemMasterDAL.Delete(ItemMaster, this.LoggedInUser);

            return status;
        }

    }
}
