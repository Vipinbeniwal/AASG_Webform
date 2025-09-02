using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessDfgPrintBL
    {
        #region Properties/Variables
        ProcessDfgPrintDL _ProcessDfgPrintDAL = new ProcessDfgPrintDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessDfgPrintBL()
        {
            // this._ProcessDfgPrintDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessDfgPrint>();
        }

        public ProcessDfgPrintBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessDfgPrintDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessDfgPrint>();
        }
        #endregion

        public BusinessModel.ProcessDfgPrint CreateProcessDfgPrint(BusinessModel.ProcessDfgPrint ProcessDfgPrintBusinessObject)
        {
            Mapper.Mappings.MapProcessDfgPrint ProcessDfgPrintMenu = new Mapper.Mappings.MapProcessDfgPrint();

            var report = ProcessDfgPrintMenu.GetProcessDfgPrintDatabaseObject(ProcessDfgPrintBusinessObject);

            report = this._ProcessDfgPrintDAL.Create(report, this.LoggedInUser);

            ProcessDfgPrintBusinessObject = ProcessDfgPrintMenu.GetProcessDfgPrintBusinessObject(report);

            return ProcessDfgPrintBusinessObject;

        }

        public List<BusinessModel.ProcessDfgPrint> GetAllProcessDfgPrintItems()
        {
            Mapper.Mappings.MapProcessDfgPrint ProcessDfgPrintMenu = new Mapper.Mappings.MapProcessDfgPrint();

            var ProcessDfgPrintItemsDALList = this._ProcessDfgPrintDAL.GetAll();

            List<BusinessModel.ProcessDfgPrint> ProcessDfgPrintItemsBusinessList = new List<BusinessModel.ProcessDfgPrint>();
            foreach (App.Data.ProcessDfgPrint ProcessDfgPrintItem in ProcessDfgPrintItemsDALList)
            {
                ProcessDfgPrintItemsBusinessList.Add(ProcessDfgPrintMenu.GetProcessDfgPrintBusinessObject(ProcessDfgPrintItem));
            }

            return ProcessDfgPrintItemsBusinessList;
        }

        public List<BusinessModel.ProcessDfgPrint> GetProcessDfgPrintItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessDfgPrint ProcessDfgPrintMenu = new Mapper.Mappings.MapProcessDfgPrint();

            var ProcessDfgPrintItemsDALList = this._ProcessDfgPrintDAL.GetbyId(Id);

            List<BusinessModel.ProcessDfgPrint> ProcessDfgPrintItemsBusinessList = new List<BusinessModel.ProcessDfgPrint>();
            foreach (App.Data.ProcessDfgPrint ProcessDfgPrintItem in ProcessDfgPrintItemsDALList)
            {
                ProcessDfgPrintItemsBusinessList.Add(ProcessDfgPrintMenu.GetProcessDfgPrintBusinessObject(ProcessDfgPrintItem));
            }

            return ProcessDfgPrintItemsBusinessList;
        }

        public List<BusinessModel.ProcessDfgPrint> GetProcessDfgPrintByName(string term)
        {
            Mapper.Mappings.MapProcessDfgPrint ProcessDfgPrintMenu = new Mapper.Mappings.MapProcessDfgPrint();

            var ProcessDfgPrintItemsDALList = this._ProcessDfgPrintDAL.GetByName(term);

            List<BusinessModel.ProcessDfgPrint> ProcessDfgPrintItemsBusinessList = new List<BusinessModel.ProcessDfgPrint>();

            foreach (App.Data.ProcessDfgPrint ProcessDfgPrintItem in ProcessDfgPrintItemsDALList)
            {
                ProcessDfgPrintItemsBusinessList.Add(ProcessDfgPrintMenu.GetProcessDfgPrintBusinessObject(ProcessDfgPrintItem));
            }

            return ProcessDfgPrintItemsBusinessList;
        }

        public BusinessModel.ProcessDfgPrint UpdateProcessDfgPrint(BusinessModel.ProcessDfgPrint ProcessDfgPrintBusinessObject)
        {
            Mapper.Mappings.MapProcessDfgPrint mapProcessDfgPrint = new Mapper.Mappings.MapProcessDfgPrint();

            var ProcessDfgPrint = mapProcessDfgPrint.GetProcessDfgPrintDatabaseObject(ProcessDfgPrintBusinessObject);

            ProcessDfgPrint = this._ProcessDfgPrintDAL.Update(ProcessDfgPrint, this.LoggedInUser);

            ProcessDfgPrintBusinessObject = mapProcessDfgPrint.GetProcessDfgPrintBusinessObject(ProcessDfgPrint);

            return ProcessDfgPrintBusinessObject;

        }

        public bool DeleteProcessDfgPrint(BusinessModel.ProcessDfgPrint ProcessDfgPrintBusinessObject)
        {
            Mapper.Mappings.MapProcessDfgPrint mapProcessDfgPrint = new Mapper.Mappings.MapProcessDfgPrint();

            var ProcessDfgPrint = mapProcessDfgPrint.GetProcessDfgPrintDatabaseObject(ProcessDfgPrintBusinessObject);

            bool status = this._ProcessDfgPrintDAL.Delete(ProcessDfgPrint, this.LoggedInUser);

            return status;
        }

    }
}
