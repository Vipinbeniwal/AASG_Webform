using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessTemperingReportBL
    {
        #region Properties/Variables
        ProcessTemperingReportDL _ProcessTemperingReportDAL = new ProcessTemperingReportDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessTemperingReportBL()
        {
            // this._ProcessTemperingReportDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessTemperingReport>();
        }

        public ProcessTemperingReportBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessTemperingReportDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessTemperingReport>();
        }
        #endregion

        public BusinessModel.ProcessTemperingReport CreateProcessTemperingReport(BusinessModel.ProcessTemperingReport ProcessTemperingReportBusinessObject)
        {
            Mapper.Mappings.MapProcessTemperingReport ProcessTemperingReportMenu = new Mapper.Mappings.MapProcessTemperingReport();

            var report = ProcessTemperingReportMenu.GetProcessTemperingReportDatabaseObject(ProcessTemperingReportBusinessObject);

            report = this._ProcessTemperingReportDAL.Create(report, this.LoggedInUser);

            ProcessTemperingReportBusinessObject = ProcessTemperingReportMenu.GetProcessTemperingReportBusinessObject(report);

            return ProcessTemperingReportBusinessObject;

        }

        public List<BusinessModel.ProcessTemperingReport> GetAllProcessTemperingReportItems()
        {
            Mapper.Mappings.MapProcessTemperingReport ProcessTemperingReportMenu = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReportItemsDALList = this._ProcessTemperingReportDAL.GetAll();

            List<BusinessModel.ProcessTemperingReport> ProcessTemperingReportItemsBusinessList = new List<BusinessModel.ProcessTemperingReport>();
            foreach (App.Data.ProcessTemperingReport ProcessTemperingReportItem in ProcessTemperingReportItemsDALList)
            {
                ProcessTemperingReportItemsBusinessList.Add(ProcessTemperingReportMenu.GetProcessTemperingReportBusinessObject(ProcessTemperingReportItem));
            }

            return ProcessTemperingReportItemsBusinessList;
        }

        public List<BusinessModel.ProcessTemperingReport> GetProcessTemperingReportItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessTemperingReport ProcessTemperingReportMenu = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReportItemsDALList = this._ProcessTemperingReportDAL.GetbyId(Id);

            List<BusinessModel.ProcessTemperingReport> ProcessTemperingReportItemsBusinessList = new List<BusinessModel.ProcessTemperingReport>();
            foreach (App.Data.ProcessTemperingReport ProcessTemperingReportItem in ProcessTemperingReportItemsDALList)
            {
                ProcessTemperingReportItemsBusinessList.Add(ProcessTemperingReportMenu.GetProcessTemperingReportBusinessObject(ProcessTemperingReportItem));
            }

            return ProcessTemperingReportItemsBusinessList;
        }

        public List<BusinessModel.ProcessTemperingReport> GetProcessTemperingReportByName(string term)
        {
            Mapper.Mappings.MapProcessTemperingReport ProcessTemperingReportMenu = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReportItemsDALList = this._ProcessTemperingReportDAL.GetByName(term);

            List<BusinessModel.ProcessTemperingReport> ProcessTemperingReportItemsBusinessList = new List<BusinessModel.ProcessTemperingReport>();

            foreach (App.Data.ProcessTemperingReport ProcessTemperingReportItem in ProcessTemperingReportItemsDALList)
            {
                ProcessTemperingReportItemsBusinessList.Add(ProcessTemperingReportMenu.GetProcessTemperingReportBusinessObject(ProcessTemperingReportItem));
            }

            return ProcessTemperingReportItemsBusinessList;
        }

        public BusinessModel.ProcessTemperingReport UpdateProcessTemperingReport(BusinessModel.ProcessTemperingReport ProcessTemperingReportBusinessObject)
        {
            Mapper.Mappings.MapProcessTemperingReport mapProcessTemperingReport = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReport = mapProcessTemperingReport.GetProcessTemperingReportDatabaseObject(ProcessTemperingReportBusinessObject);

            ProcessTemperingReport = this._ProcessTemperingReportDAL.Update(ProcessTemperingReport, this.LoggedInUser);

            ProcessTemperingReportBusinessObject = mapProcessTemperingReport.GetProcessTemperingReportBusinessObject(ProcessTemperingReport);

            return ProcessTemperingReportBusinessObject;

        }

        public BusinessModel.ProcessTemperingReport UpdateProcessTemperingReportBYTemperingId(BusinessModel.ProcessTemperingReport ProcessTemperingReportBusinessObject)
        {
            Mapper.Mappings.MapProcessTemperingReport mapProcessTemperingReport = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReport = mapProcessTemperingReport.GetProcessTemperingReportDatabaseObject(ProcessTemperingReportBusinessObject);

            ProcessTemperingReport = this._ProcessTemperingReportDAL.UpdateByProcessTemperingId(ProcessTemperingReport, this.LoggedInUser);

            ProcessTemperingReportBusinessObject = mapProcessTemperingReport.GetProcessTemperingReportBusinessObject(ProcessTemperingReport);

            return ProcessTemperingReportBusinessObject;

        }

        //UpdateByProcessTemperingId

        public bool DeleteProcessTemperingReport(BusinessModel.ProcessTemperingReport ProcessTemperingReportBusinessObject)
        {
            Mapper.Mappings.MapProcessTemperingReport mapProcessTemperingReport = new Mapper.Mappings.MapProcessTemperingReport();

            var ProcessTemperingReport = mapProcessTemperingReport.GetProcessTemperingReportDatabaseObject(ProcessTemperingReportBusinessObject);

            bool status = this._ProcessTemperingReportDAL.Delete(ProcessTemperingReport, this.LoggedInUser);

            return status;
        }

    }
}
