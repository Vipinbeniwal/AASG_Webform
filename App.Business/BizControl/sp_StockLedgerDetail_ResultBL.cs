using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class sp_StockLedgerDetail_ResultBL
    {
        #region Properties/Variables
        sp_StockLedgerDetail_ResultDL _sp_StockLedgerDetail_ResultDAL = new sp_StockLedgerDetail_ResultDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public sp_StockLedgerDetail_ResultBL()
        {
            // this._sp_StockLedgerDetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_StockLedgerDetail_Result>();
        }

        public sp_StockLedgerDetail_ResultBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._sp_StockLedgerDetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_StockLedgerDetail_Result>();
        }
        #endregion

        public BusinessModel.sp_StockLedgerDetail_Result Createsp_StockLedgerDetail_Result(BusinessModel.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultMenu = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var report = sp_StockLedgerDetail_ResultMenu.Getsp_StockLedgerDetail_ResultDatabaseObject(sp_StockLedgerDetail_ResultBusinessObject);

            report = this._sp_StockLedgerDetail_ResultDAL.Create(report, this.LoggedInUser);

            sp_StockLedgerDetail_ResultBusinessObject = sp_StockLedgerDetail_ResultMenu.Getsp_StockLedgerDetail_ResultBusinessObject(report);

            return sp_StockLedgerDetail_ResultBusinessObject;

        }

        public List<BusinessModel.sp_StockLedgerDetail_Result> GetAllsp_StockLedgerDetail_ResultItems()
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultMenu = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var sp_StockLedgerDetail_ResultItemsDALList = this._sp_StockLedgerDetail_ResultDAL.GetAll();

            List<BusinessModel.sp_StockLedgerDetail_Result> sp_StockLedgerDetail_ResultItemsBusinessList = new List<BusinessModel.sp_StockLedgerDetail_Result>();
            foreach (App.Data.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultItem in sp_StockLedgerDetail_ResultItemsDALList)
            {
                sp_StockLedgerDetail_ResultItemsBusinessList.Add(sp_StockLedgerDetail_ResultMenu.Getsp_StockLedgerDetail_ResultBusinessObject(sp_StockLedgerDetail_ResultItem));
            }

            return sp_StockLedgerDetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_StockLedgerDetail_Result> Getsp_StockLedgerDetail_ResultItemsByID(int Id)
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultMenu = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var sp_StockLedgerDetail_ResultItemsDALList = this._sp_StockLedgerDetail_ResultDAL.GetbyId(Id);

            List<BusinessModel.sp_StockLedgerDetail_Result> sp_StockLedgerDetail_ResultItemsBusinessList = new List<BusinessModel.sp_StockLedgerDetail_Result>();
            foreach (App.Data.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultItem in sp_StockLedgerDetail_ResultItemsDALList)
            {
                sp_StockLedgerDetail_ResultItemsBusinessList.Add(sp_StockLedgerDetail_ResultMenu.Getsp_StockLedgerDetail_ResultBusinessObject(sp_StockLedgerDetail_ResultItem));
            }

            return sp_StockLedgerDetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_StockLedgerDetail_Result> Getsp_StockLedgerDetail_ResultByName(string term)
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultMenu = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var sp_StockLedgerDetail_ResultItemsDALList = this._sp_StockLedgerDetail_ResultDAL.GetByName(term);

            List<BusinessModel.sp_StockLedgerDetail_Result> sp_StockLedgerDetail_ResultItemsBusinessList = new List<BusinessModel.sp_StockLedgerDetail_Result>();

            foreach (App.Data.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultItem in sp_StockLedgerDetail_ResultItemsDALList)
            {
                sp_StockLedgerDetail_ResultItemsBusinessList.Add(sp_StockLedgerDetail_ResultMenu.Getsp_StockLedgerDetail_ResultBusinessObject(sp_StockLedgerDetail_ResultItem));
            }

            return sp_StockLedgerDetail_ResultItemsBusinessList;
        }

        public BusinessModel.sp_StockLedgerDetail_Result Updatesp_StockLedgerDetail_Result(BusinessModel.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result mapsp_StockLedgerDetail_Result = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var sp_StockLedgerDetail_Result = mapsp_StockLedgerDetail_Result.Getsp_StockLedgerDetail_ResultDatabaseObject(sp_StockLedgerDetail_ResultBusinessObject);

            sp_StockLedgerDetail_Result = this._sp_StockLedgerDetail_ResultDAL.Update(sp_StockLedgerDetail_Result, this.LoggedInUser);

            sp_StockLedgerDetail_ResultBusinessObject = mapsp_StockLedgerDetail_Result.Getsp_StockLedgerDetail_ResultBusinessObject(sp_StockLedgerDetail_Result);

            return sp_StockLedgerDetail_ResultBusinessObject;

        }

        public bool Deletesp_StockLedgerDetail_Result(BusinessModel.sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_StockLedgerDetail_Result mapsp_StockLedgerDetail_Result = new Mapper.Mappings.Mapsp_StockLedgerDetail_Result();

            var sp_StockLedgerDetail_Result = mapsp_StockLedgerDetail_Result.Getsp_StockLedgerDetail_ResultDatabaseObject(sp_StockLedgerDetail_ResultBusinessObject);

            bool status = this._sp_StockLedgerDetail_ResultDAL.Delete(sp_StockLedgerDetail_Result, this.LoggedInUser);

            return status;
        }

    }
}
