using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class sp_tourdetail_ResultBL
    {
        #region Properties/Variables
        sp_tourdetail_ResultDL _sp_tourdetail_ResultDAL = new sp_tourdetail_ResultDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public sp_tourdetail_ResultBL()
        {
            // this._sp_tourdetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_tourdetail_Result>();
        }

        public sp_tourdetail_ResultBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._sp_tourdetail_ResultDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.sp_tourdetail_Result>();
        }
        #endregion

        public BusinessModel.sp_tourdetail_Result Createsp_tourdetail_Result(BusinessModel.sp_tourdetail_Result sp_tourdetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result sp_tourdetail_ResultMenu = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var report = sp_tourdetail_ResultMenu.Getsp_tourdetail_ResultDatabaseObject(sp_tourdetail_ResultBusinessObject);

            report = this._sp_tourdetail_ResultDAL.Create(report, this.LoggedInUser);

            sp_tourdetail_ResultBusinessObject = sp_tourdetail_ResultMenu.Getsp_tourdetail_ResultBusinessObject(report);

            return sp_tourdetail_ResultBusinessObject;

        }

        public List<BusinessModel.sp_tourdetail_Result> GetAllsp_tourdetail_ResultItems(int tour_master_id, int staff_master_id, string FromDate, string ToDate)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result sp_tourdetail_ResultMenu = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var sp_tourdetail_ResultItemsDALList = this._sp_tourdetail_ResultDAL.GetAll(tour_master_id,staff_master_id,FromDate,ToDate);

            List<BusinessModel.sp_tourdetail_Result> sp_tourdetail_ResultItemsBusinessList = new List<BusinessModel.sp_tourdetail_Result>();
            foreach (App.Data.sp_tourdetail_Result sp_tourdetail_ResultItem in sp_tourdetail_ResultItemsDALList)
            {
                sp_tourdetail_ResultItemsBusinessList.Add(sp_tourdetail_ResultMenu.Getsp_tourdetail_ResultBusinessObject(sp_tourdetail_ResultItem));
            }

            return sp_tourdetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_tourdetail_Result> Getsp_tourdetail_ResultItemsByID(int Id)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result sp_tourdetail_ResultMenu = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var sp_tourdetail_ResultItemsDALList = this._sp_tourdetail_ResultDAL.GetbyId(Id);

            List<BusinessModel.sp_tourdetail_Result> sp_tourdetail_ResultItemsBusinessList = new List<BusinessModel.sp_tourdetail_Result>();
            foreach (App.Data.sp_tourdetail_Result sp_tourdetail_ResultItem in sp_tourdetail_ResultItemsDALList)
            {
                sp_tourdetail_ResultItemsBusinessList.Add(sp_tourdetail_ResultMenu.Getsp_tourdetail_ResultBusinessObject(sp_tourdetail_ResultItem));
            }

            return sp_tourdetail_ResultItemsBusinessList;
        }

        public List<BusinessModel.sp_tourdetail_Result> Getsp_tourdetail_ResultByName(string term)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result sp_tourdetail_ResultMenu = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var sp_tourdetail_ResultItemsDALList = this._sp_tourdetail_ResultDAL.GetByName(term);

            List<BusinessModel.sp_tourdetail_Result> sp_tourdetail_ResultItemsBusinessList = new List<BusinessModel.sp_tourdetail_Result>();

            foreach (App.Data.sp_tourdetail_Result sp_tourdetail_ResultItem in sp_tourdetail_ResultItemsDALList)
            {
                sp_tourdetail_ResultItemsBusinessList.Add(sp_tourdetail_ResultMenu.Getsp_tourdetail_ResultBusinessObject(sp_tourdetail_ResultItem));
            }

            return sp_tourdetail_ResultItemsBusinessList;
        }

        public BusinessModel.sp_tourdetail_Result Updatesp_tourdetail_Result(BusinessModel.sp_tourdetail_Result sp_tourdetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result mapsp_tourdetail_Result = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var sp_tourdetail_Result = mapsp_tourdetail_Result.Getsp_tourdetail_ResultDatabaseObject(sp_tourdetail_ResultBusinessObject);

            sp_tourdetail_Result = this._sp_tourdetail_ResultDAL.Update(sp_tourdetail_Result, this.LoggedInUser);

            sp_tourdetail_ResultBusinessObject = mapsp_tourdetail_Result.Getsp_tourdetail_ResultBusinessObject(sp_tourdetail_Result);

            return sp_tourdetail_ResultBusinessObject;

        }

        public bool Deletesp_tourdetail_Result(BusinessModel.sp_tourdetail_Result sp_tourdetail_ResultBusinessObject)
        {
            Mapper.Mappings.Mapsp_tourdetail_Result mapsp_tourdetail_Result = new Mapper.Mappings.Mapsp_tourdetail_Result();

            var sp_tourdetail_Result = mapsp_tourdetail_Result.Getsp_tourdetail_ResultDatabaseObject(sp_tourdetail_ResultBusinessObject);

            bool status = this._sp_tourdetail_ResultDAL.Delete(sp_tourdetail_Result, this.LoggedInUser);

            return status;
        }

    }
}
