using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ChallanHeaderBL
    {
        #region Properties/Variables
        ChallanHeaderDL _ChallanHeaderDAL = new ChallanHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ChallanHeaderBL()
        {
            // this._ChallanHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ChallanHeader>();
        }

        public ChallanHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ChallanHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ChallanHeader>();
        }
        #endregion

        public BusinessModel.ChallanHeader CreateChallanHeader(BusinessModel.ChallanHeader ChallanHeaderBusinessObject)
        {
            Mapper.Mappings.MapChallanHeader ChallanHeaderMenu = new Mapper.Mappings.MapChallanHeader();

            var report = ChallanHeaderMenu.GetChallanHeaderDatabaseObject(ChallanHeaderBusinessObject);

            report = this._ChallanHeaderDAL.Create(report, this.LoggedInUser);

            ChallanHeaderBusinessObject = ChallanHeaderMenu.GetChallanHeaderBusinessObject(report);

            return ChallanHeaderBusinessObject;

        }

        public List<BusinessModel.ChallanHeader> GetAllChallanHeaderItems()
        {
            Mapper.Mappings.MapChallanHeader ChallanHeaderMenu = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeaderItemsDALList = this._ChallanHeaderDAL.GetAll();

            List<BusinessModel.ChallanHeader> ChallanHeaderItemsBusinessList = new List<BusinessModel.ChallanHeader>();
            foreach (App.Data.ChallanHeader ChallanHeaderItem in ChallanHeaderItemsDALList)
            {
                ChallanHeaderItemsBusinessList.Add(ChallanHeaderMenu.GetChallanHeaderBusinessObject(ChallanHeaderItem));
            }

            return ChallanHeaderItemsBusinessList;
        }

        public List<BusinessModel.ChallanHeader> GetChallanHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapChallanHeader ChallanHeaderMenu = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeaderItemsDALList = this._ChallanHeaderDAL.GetbyId(Id);

            List<BusinessModel.ChallanHeader> ChallanHeaderItemsBusinessList = new List<BusinessModel.ChallanHeader>();
            foreach (App.Data.ChallanHeader ChallanHeaderItem in ChallanHeaderItemsDALList)
            {
                ChallanHeaderItemsBusinessList.Add(ChallanHeaderMenu.GetChallanHeaderBusinessObject(ChallanHeaderItem));
            }

            return ChallanHeaderItemsBusinessList;
        }


        public List<BusinessModel.ChallanHeader> GetChallanHeaderItemsByOrderNumber(string Id)
        {
            Mapper.Mappings.MapChallanHeader ChallanHeaderMenu = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeaderItemsDALList = this._ChallanHeaderDAL.GetbyOrderNumber(Id);

            List<BusinessModel.ChallanHeader> ChallanHeaderItemsBusinessList = new List<BusinessModel.ChallanHeader>();
            foreach (App.Data.ChallanHeader ChallanHeaderItem in ChallanHeaderItemsDALList)
            {
                ChallanHeaderItemsBusinessList.Add(ChallanHeaderMenu.GetChallanHeaderBusinessObject(ChallanHeaderItem));
            }

            return ChallanHeaderItemsBusinessList;
        }

        public List<BusinessModel.ChallanHeader> GetChallanHeaderByName(string term)
        {
            Mapper.Mappings.MapChallanHeader ChallanHeaderMenu = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeaderItemsDALList = this._ChallanHeaderDAL.GetByName(term);

            List<BusinessModel.ChallanHeader> ChallanHeaderItemsBusinessList = new List<BusinessModel.ChallanHeader>();

            foreach (App.Data.ChallanHeader ChallanHeaderItem in ChallanHeaderItemsDALList)
            {
                ChallanHeaderItemsBusinessList.Add(ChallanHeaderMenu.GetChallanHeaderBusinessObject(ChallanHeaderItem));
            }

            return ChallanHeaderItemsBusinessList;
        }

        public BusinessModel.ChallanHeader UpdateChallanHeader(BusinessModel.ChallanHeader ChallanHeaderBusinessObject)
        {
            Mapper.Mappings.MapChallanHeader mapChallanHeader = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeader = mapChallanHeader.GetChallanHeaderDatabaseObject(ChallanHeaderBusinessObject);

            ChallanHeader = this._ChallanHeaderDAL.Update(ChallanHeader, this.LoggedInUser);

            ChallanHeaderBusinessObject = mapChallanHeader.GetChallanHeaderBusinessObject(ChallanHeader);

            return ChallanHeaderBusinessObject;

        }

        public bool DeleteChallanHeader(BusinessModel.ChallanHeader ChallanHeaderBusinessObject)
        {
            Mapper.Mappings.MapChallanHeader mapChallanHeader = new Mapper.Mappings.MapChallanHeader();

            var ChallanHeader = mapChallanHeader.GetChallanHeaderDatabaseObject(ChallanHeaderBusinessObject);

            bool status = this._ChallanHeaderDAL.Delete(ChallanHeader, this.LoggedInUser);

            return status;
        }

    }
}
