using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class SaleItemBL
    {
        #region Properties/Variables
        SaleItemDL _SaleItemDAL = new SaleItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public SaleItemBL()
        {
            // this._SaleItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SaleItem>();
        }

        public SaleItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._SaleItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SaleItem>();
        }
        #endregion

        public BusinessModel.SaleItem CreateSaleItem(BusinessModel.SaleItem SaleItemBusinessObject)
        {
            Mapper.Mappings.MapSaleItem SaleItemMenu = new Mapper.Mappings.MapSaleItem();

            var report = SaleItemMenu.GetSaleItemDatabaseObject(SaleItemBusinessObject);

            report = this._SaleItemDAL.Create(report, this.LoggedInUser);

            SaleItemBusinessObject = SaleItemMenu.GetSaleItemBusinessObject(report);

            return SaleItemBusinessObject;

        }

        public List<BusinessModel.SaleItem> GetAllSaleItemItems()
        {
            Mapper.Mappings.MapSaleItem SaleItemMenu = new Mapper.Mappings.MapSaleItem();

            var SaleItemItemsDALList = this._SaleItemDAL.GetAll();

            List<BusinessModel.SaleItem> SaleItemItemsBusinessList = new List<BusinessModel.SaleItem>();
            foreach (App.Data.SaleItem SaleItemItem in SaleItemItemsDALList)
            {
                SaleItemItemsBusinessList.Add(SaleItemMenu.GetSaleItemBusinessObject(SaleItemItem));
            }

            return SaleItemItemsBusinessList;
        }

        public List<BusinessModel.SaleItem> GetSaleItemItemsByID(int Id)
        {
            Mapper.Mappings.MapSaleItem SaleItemMenu = new Mapper.Mappings.MapSaleItem();

            var SaleItemItemsDALList = this._SaleItemDAL.GetbyId(Id);

            List<BusinessModel.SaleItem> SaleItemItemsBusinessList = new List<BusinessModel.SaleItem>();
            foreach (App.Data.SaleItem SaleItemItem in SaleItemItemsDALList)
            {
                SaleItemItemsBusinessList.Add(SaleItemMenu.GetSaleItemBusinessObject(SaleItemItem));
            }

            return SaleItemItemsBusinessList;
        }

        public List<BusinessModel.SaleItem> GetSaleItemByName(string term)
        {
            Mapper.Mappings.MapSaleItem SaleItemMenu = new Mapper.Mappings.MapSaleItem();

            var SaleItemItemsDALList = this._SaleItemDAL.GetByName(term);

            List<BusinessModel.SaleItem> SaleItemItemsBusinessList = new List<BusinessModel.SaleItem>();

            foreach (App.Data.SaleItem SaleItemItem in SaleItemItemsDALList)
            {
                SaleItemItemsBusinessList.Add(SaleItemMenu.GetSaleItemBusinessObject(SaleItemItem));
            }

            return SaleItemItemsBusinessList;
        }

        public BusinessModel.SaleItem UpdateSaleItem(BusinessModel.SaleItem SaleItemBusinessObject)
        {
            Mapper.Mappings.MapSaleItem mapSaleItem = new Mapper.Mappings.MapSaleItem();

            var SaleItem = mapSaleItem.GetSaleItemDatabaseObject(SaleItemBusinessObject);

            SaleItem = this._SaleItemDAL.Update(SaleItem, this.LoggedInUser);

            SaleItemBusinessObject = mapSaleItem.GetSaleItemBusinessObject(SaleItem);

            return SaleItemBusinessObject;

        }

        public bool DeleteSaleItem(BusinessModel.SaleItem SaleItemBusinessObject)
        {
            Mapper.Mappings.MapSaleItem mapSaleItem = new Mapper.Mappings.MapSaleItem();

            var SaleItem = mapSaleItem.GetSaleItemDatabaseObject(SaleItemBusinessObject);

            bool status = this._SaleItemDAL.Delete(SaleItem, this.LoggedInUser);

            return status;
        }

    }
}
