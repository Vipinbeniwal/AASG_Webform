using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class sp_ItemProcessDetail_ResultBL
    {
        #region Properties/Variables
        sp_ItemProcessDetail_ResultDL _sp_ItemProcessDetail_ResultDAL = new sp_ItemProcessDetail_ResultDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public sp_ItemProcessDetail_ResultBL()
        {
            // this._sp_ItemProcessDetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_ItemProcessDetail_Result>();
        }

        public sp_ItemProcessDetail_ResultBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._sp_ItemProcessDetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_ItemProcessDetail_Result>();
        }
        #endregion

        public BusinessModel.sp_ItemProcessDetail_Result Createsp_ItemProcessDetail_Result(BusinessModel.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultMenu = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var report = sp_ItemProcessDetail_ResultMenu.Getsp_ItemProcessDetail_ResultDatabaseObject(sp_ItemProcessDetail_ResultBusinessObject);

            report = this._sp_ItemProcessDetail_ResultDAL.Create(report, this.LoggedInUser);

            sp_ItemProcessDetail_ResultBusinessObject = sp_ItemProcessDetail_ResultMenu.Getsp_ItemProcessDetail_ResultBusinessObject(report);

            return sp_ItemProcessDetail_ResultBusinessObject;

        }

        public List<BusinessModel.sp_ItemProcessDetail_Result> GetAllsp_ItemProcessDetail_ResultItems(string batch_number,string ItemMasterId)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultMenu = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var sp_ItemProcessDetail_ResultItemsDALList = this._sp_ItemProcessDetail_ResultDAL.GetAll(batch_number, ItemMasterId);

            List<BusinessModel.sp_ItemProcessDetail_Result> sp_ItemProcessDetail_ResultItemsBusinessList = new List<BusinessModel.sp_ItemProcessDetail_Result>();
            foreach (App.Data.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultItem in sp_ItemProcessDetail_ResultItemsDALList)
            {
                sp_ItemProcessDetail_ResultItemsBusinessList.Add(sp_ItemProcessDetail_ResultMenu.Getsp_ItemProcessDetail_ResultBusinessObject(sp_ItemProcessDetail_ResultItem));
            }

            return sp_ItemProcessDetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_ItemProcessDetail_Result> Getsp_ItemProcessDetail_ResultItemsByID(int Id)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultMenu = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var sp_ItemProcessDetail_ResultItemsDALList = this._sp_ItemProcessDetail_ResultDAL.GetbyId(Id);

            List<BusinessModel.sp_ItemProcessDetail_Result> sp_ItemProcessDetail_ResultItemsBusinessList = new List<BusinessModel.sp_ItemProcessDetail_Result>();
            foreach (App.Data.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultItem in sp_ItemProcessDetail_ResultItemsDALList)
            {
                sp_ItemProcessDetail_ResultItemsBusinessList.Add(sp_ItemProcessDetail_ResultMenu.Getsp_ItemProcessDetail_ResultBusinessObject(sp_ItemProcessDetail_ResultItem));
            }

            return sp_ItemProcessDetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_ItemProcessDetail_Result> Getsp_ItemProcessDetail_ResultByName(string term)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultMenu = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var sp_ItemProcessDetail_ResultItemsDALList = this._sp_ItemProcessDetail_ResultDAL.GetByName(term);

            List<BusinessModel.sp_ItemProcessDetail_Result> sp_ItemProcessDetail_ResultItemsBusinessList = new List<BusinessModel.sp_ItemProcessDetail_Result>();

            foreach (App.Data.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultItem in sp_ItemProcessDetail_ResultItemsDALList)
            {
                sp_ItemProcessDetail_ResultItemsBusinessList.Add(sp_ItemProcessDetail_ResultMenu.Getsp_ItemProcessDetail_ResultBusinessObject(sp_ItemProcessDetail_ResultItem));
            }

            return sp_ItemProcessDetail_ResultItemsBusinessList;
        }

        public BusinessModel.sp_ItemProcessDetail_Result Updatesp_ItemProcessDetail_Result(BusinessModel.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result mapsp_ItemProcessDetail_Result = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var sp_ItemProcessDetail_Result = mapsp_ItemProcessDetail_Result.Getsp_ItemProcessDetail_ResultDatabaseObject(sp_ItemProcessDetail_ResultBusinessObject);

            sp_ItemProcessDetail_Result = this._sp_ItemProcessDetail_ResultDAL.Update(sp_ItemProcessDetail_Result, this.LoggedInUser);

            sp_ItemProcessDetail_ResultBusinessObject = mapsp_ItemProcessDetail_Result.Getsp_ItemProcessDetail_ResultBusinessObject(sp_ItemProcessDetail_Result);

            return sp_ItemProcessDetail_ResultBusinessObject;

        }

        public bool Deletesp_ItemProcessDetail_Result(BusinessModel.sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_ItemProcessDetail_Result mapsp_ItemProcessDetail_Result = new Mapper.Mappings.Mapsp_ItemProcessDetail_Result();

            var sp_ItemProcessDetail_Result = mapsp_ItemProcessDetail_Result.Getsp_ItemProcessDetail_ResultDatabaseObject(sp_ItemProcessDetail_ResultBusinessObject);

            bool status = this._sp_ItemProcessDetail_ResultDAL.Delete(sp_ItemProcessDetail_Result, this.LoggedInUser);

            return status;
        }

    }
}
