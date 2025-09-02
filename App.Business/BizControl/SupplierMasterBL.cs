using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class SupplierMasterBL
    {
        #region Properties/Variables
        SupplierMasterDL _SupplierMasterDAL = new SupplierMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public SupplierMasterBL()
        {
            // this._SupplierMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SupplierMaster>();
        }

        public SupplierMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._SupplierMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SupplierMaster>();
        }
        #endregion

        public BusinessModel.SupplierMaster CreateSupplierMaster(BusinessModel.SupplierMaster SupplierMasterBusinessObject)
        {
            Mapper.Mappings.MapSupplierMaster SupplierMasterMenu = new Mapper.Mappings.MapSupplierMaster();

            var report = SupplierMasterMenu.GetSupplierMasterDatabaseObject(SupplierMasterBusinessObject);

            report = this._SupplierMasterDAL.Create(report, this.LoggedInUser);

            SupplierMasterBusinessObject = SupplierMasterMenu.GetSupplierMasterBusinessObject(report);

            return SupplierMasterBusinessObject;

        }

        public List<BusinessModel.SupplierMaster> GetAllSupplierMasterItems()
        {
            Mapper.Mappings.MapSupplierMaster SupplierMasterMenu = new Mapper.Mappings.MapSupplierMaster();

            var SupplierMasterItemsDALList = this._SupplierMasterDAL.GetAll();

            List<BusinessModel.SupplierMaster> SupplierMasterItemsBusinessList = new List<BusinessModel.SupplierMaster>();
            foreach (App.Data.SupplierMaster SupplierMasterItem in SupplierMasterItemsDALList)
            {
                SupplierMasterItemsBusinessList.Add(SupplierMasterMenu.GetSupplierMasterBusinessObject(SupplierMasterItem));
            }

            return SupplierMasterItemsBusinessList;
        }

        public List<BusinessModel.SupplierMaster> GetSupplierMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapSupplierMaster SupplierMasterMenu = new Mapper.Mappings.MapSupplierMaster();

            var SupplierMasterItemsDALList = this._SupplierMasterDAL.GetbyId(Id);

            List<BusinessModel.SupplierMaster> SupplierMasterItemsBusinessList = new List<BusinessModel.SupplierMaster>();
            foreach (App.Data.SupplierMaster SupplierMasterItem in SupplierMasterItemsDALList)
            {
                SupplierMasterItemsBusinessList.Add(SupplierMasterMenu.GetSupplierMasterBusinessObject(SupplierMasterItem));
            }

            return SupplierMasterItemsBusinessList;
        }

        public List<BusinessModel.SupplierMaster> GetSupplierMasterByName(string term)
        {
            Mapper.Mappings.MapSupplierMaster SupplierMasterMenu = new Mapper.Mappings.MapSupplierMaster();

            var SupplierMasterItemsDALList = this._SupplierMasterDAL.GetByName(term);

            List<BusinessModel.SupplierMaster> SupplierMasterItemsBusinessList = new List<BusinessModel.SupplierMaster>();

            foreach (App.Data.SupplierMaster SupplierMasterItem in SupplierMasterItemsDALList)
            {
                SupplierMasterItemsBusinessList.Add(SupplierMasterMenu.GetSupplierMasterBusinessObject(SupplierMasterItem));
            }

            return SupplierMasterItemsBusinessList;
        }

        public BusinessModel.SupplierMaster UpdateSupplierMaster(BusinessModel.SupplierMaster SupplierMasterBusinessObject)
        {
            Mapper.Mappings.MapSupplierMaster mapSupplierMaster = new Mapper.Mappings.MapSupplierMaster();

            var SupplierMaster = mapSupplierMaster.GetSupplierMasterDatabaseObject(SupplierMasterBusinessObject);

            SupplierMaster = this._SupplierMasterDAL.Update(SupplierMaster, this.LoggedInUser);

            SupplierMasterBusinessObject = mapSupplierMaster.GetSupplierMasterBusinessObject(SupplierMaster);

            return SupplierMasterBusinessObject;

        }

        public bool DeleteSupplierMaster(BusinessModel.SupplierMaster SupplierMasterBusinessObject)
        {
            Mapper.Mappings.MapSupplierMaster mapSupplierMaster = new Mapper.Mappings.MapSupplierMaster();

            var SupplierMaster = mapSupplierMaster.GetSupplierMasterDatabaseObject(SupplierMasterBusinessObject);

            bool status = this._SupplierMasterDAL.Delete(SupplierMaster, this.LoggedInUser);

            return status;
        }

    }
}
