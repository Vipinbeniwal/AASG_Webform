using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessTemperingBL
    {
        #region Properties/Variables
        ProcessTemperingDL _ProcessTemperingDAL = new ProcessTemperingDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessTemperingBL()
        {
            // this._ProcessTemperingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessTempering>();
        }

        public ProcessTemperingBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessTemperingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessTempering>();
        }
        #endregion

        public BusinessModel.ProcessTempering CreateProcessTempering(BusinessModel.ProcessTempering ProcessTemperingBusinessObject)
        {
            Mapper.Mappings.MapProcessTempering ProcessTemperingMenu = new Mapper.Mappings.MapProcessTempering();

            var report = ProcessTemperingMenu.GetProcessTemperingDatabaseObject(ProcessTemperingBusinessObject);

            report = this._ProcessTemperingDAL.Create(report, this.LoggedInUser);

            ProcessTemperingBusinessObject = ProcessTemperingMenu.GetProcessTemperingBusinessObject(report);

            return ProcessTemperingBusinessObject;

        }

        public List<BusinessModel.ProcessTempering> GetAllProcessTemperingItems()
        {
            Mapper.Mappings.MapProcessTempering ProcessTemperingMenu = new Mapper.Mappings.MapProcessTempering();

            var ProcessTemperingItemsDALList = this._ProcessTemperingDAL.GetAll();

            List<BusinessModel.ProcessTempering> ProcessTemperingItemsBusinessList = new List<BusinessModel.ProcessTempering>();
            foreach (App.Data.ProcessTempering ProcessTemperingItem in ProcessTemperingItemsDALList)
            {
                ProcessTemperingItemsBusinessList.Add(ProcessTemperingMenu.GetProcessTemperingBusinessObject(ProcessTemperingItem));
            }

            return ProcessTemperingItemsBusinessList;
        }

        public List<BusinessModel.ProcessTempering> GetProcessTemperingItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessTempering ProcessTemperingMenu = new Mapper.Mappings.MapProcessTempering();

            var ProcessTemperingItemsDALList = this._ProcessTemperingDAL.GetbyId(Id);

            List<BusinessModel.ProcessTempering> ProcessTemperingItemsBusinessList = new List<BusinessModel.ProcessTempering>();
            foreach (App.Data.ProcessTempering ProcessTemperingItem in ProcessTemperingItemsDALList)
            {
                ProcessTemperingItemsBusinessList.Add(ProcessTemperingMenu.GetProcessTemperingBusinessObject(ProcessTemperingItem));
            }

            return ProcessTemperingItemsBusinessList;
        }

        public List<BusinessModel.ProcessTempering> GetProcessTemperingByName(string term)
        {
            Mapper.Mappings.MapProcessTempering ProcessTemperingMenu = new Mapper.Mappings.MapProcessTempering();

            var ProcessTemperingItemsDALList = this._ProcessTemperingDAL.GetByName(term);

            List<BusinessModel.ProcessTempering> ProcessTemperingItemsBusinessList = new List<BusinessModel.ProcessTempering>();

            foreach (App.Data.ProcessTempering ProcessTemperingItem in ProcessTemperingItemsDALList)
            {
                ProcessTemperingItemsBusinessList.Add(ProcessTemperingMenu.GetProcessTemperingBusinessObject(ProcessTemperingItem));
            }

            return ProcessTemperingItemsBusinessList;
        }

        public BusinessModel.ProcessTempering UpdateProcessTempering(BusinessModel.ProcessTempering ProcessTemperingBusinessObject)
        {
            Mapper.Mappings.MapProcessTempering mapProcessTempering = new Mapper.Mappings.MapProcessTempering();

            var ProcessTempering = mapProcessTempering.GetProcessTemperingDatabaseObject(ProcessTemperingBusinessObject);

            ProcessTempering = this._ProcessTemperingDAL.Update(ProcessTempering, this.LoggedInUser);

            ProcessTemperingBusinessObject = mapProcessTempering.GetProcessTemperingBusinessObject(ProcessTempering);

            return ProcessTemperingBusinessObject;

        }

        public bool DeleteProcessTempering(BusinessModel.ProcessTempering ProcessTemperingBusinessObject)
        {
            Mapper.Mappings.MapProcessTempering mapProcessTempering = new Mapper.Mappings.MapProcessTempering();

            var ProcessTempering = mapProcessTempering.GetProcessTemperingDatabaseObject(ProcessTemperingBusinessObject);

            bool status = this._ProcessTemperingDAL.Delete(ProcessTempering, this.LoggedInUser);

            return status;
        }

    }
}
