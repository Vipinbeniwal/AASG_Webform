using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessWashingOneBL
    {
        #region Properties/Variables
        ProcessWashingOneDL _ProcessWashingOneDAL = new ProcessWashingOneDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessWashingOneBL()
        {
            // this._ProcessWashingOneDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessWashingOne>();
        }

        public ProcessWashingOneBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessWashingOneDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessWashingOne>();
        }
        #endregion

        public BusinessModel.ProcessWashingOne CreateProcessWashingOne(BusinessModel.ProcessWashingOne ProcessWashingOneBusinessObject)
        {
            Mapper.Mappings.MapProcessWashingOne ProcessWashingOneMenu = new Mapper.Mappings.MapProcessWashingOne();

            var report = ProcessWashingOneMenu.GetProcessWashingOneDatabaseObject(ProcessWashingOneBusinessObject);

            report = this._ProcessWashingOneDAL.Create(report, this.LoggedInUser);

            ProcessWashingOneBusinessObject = ProcessWashingOneMenu.GetProcessWashingOneBusinessObject(report);

            return ProcessWashingOneBusinessObject;

        }

        public List<BusinessModel.ProcessWashingOne> GetAllProcessWashingOneItems()
        {
            Mapper.Mappings.MapProcessWashingOne ProcessWashingOneMenu = new Mapper.Mappings.MapProcessWashingOne();

            var ProcessWashingOneItemsDALList = this._ProcessWashingOneDAL.GetAll();

            List<BusinessModel.ProcessWashingOne> ProcessWashingOneItemsBusinessList = new List<BusinessModel.ProcessWashingOne>();
            foreach (App.Data.ProcessWashingOne ProcessWashingOneItem in ProcessWashingOneItemsDALList)
            {
                ProcessWashingOneItemsBusinessList.Add(ProcessWashingOneMenu.GetProcessWashingOneBusinessObject(ProcessWashingOneItem));
            }

            return ProcessWashingOneItemsBusinessList;
        }

        public List<BusinessModel.ProcessWashingOne> GetProcessWashingOneItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessWashingOne ProcessWashingOneMenu = new Mapper.Mappings.MapProcessWashingOne();

            var ProcessWashingOneItemsDALList = this._ProcessWashingOneDAL.GetbyId(Id);

            List<BusinessModel.ProcessWashingOne> ProcessWashingOneItemsBusinessList = new List<BusinessModel.ProcessWashingOne>();
            foreach (App.Data.ProcessWashingOne ProcessWashingOneItem in ProcessWashingOneItemsDALList)
            {
                ProcessWashingOneItemsBusinessList.Add(ProcessWashingOneMenu.GetProcessWashingOneBusinessObject(ProcessWashingOneItem));
            }

            return ProcessWashingOneItemsBusinessList;
        }

        public List<BusinessModel.ProcessWashingOne> GetProcessWashingOneByName(string term)
        {
            Mapper.Mappings.MapProcessWashingOne ProcessWashingOneMenu = new Mapper.Mappings.MapProcessWashingOne();

            var ProcessWashingOneItemsDALList = this._ProcessWashingOneDAL.GetByName(term);

            List<BusinessModel.ProcessWashingOne> ProcessWashingOneItemsBusinessList = new List<BusinessModel.ProcessWashingOne>();

            foreach (App.Data.ProcessWashingOne ProcessWashingOneItem in ProcessWashingOneItemsDALList)
            {
                ProcessWashingOneItemsBusinessList.Add(ProcessWashingOneMenu.GetProcessWashingOneBusinessObject(ProcessWashingOneItem));
            }

            return ProcessWashingOneItemsBusinessList;
        }

        public BusinessModel.ProcessWashingOne UpdateProcessWashingOne(BusinessModel.ProcessWashingOne ProcessWashingOneBusinessObject)
        {
            Mapper.Mappings.MapProcessWashingOne mapProcessWashingOne = new Mapper.Mappings.MapProcessWashingOne();

            var ProcessWashingOne = mapProcessWashingOne.GetProcessWashingOneDatabaseObject(ProcessWashingOneBusinessObject);

            ProcessWashingOne = this._ProcessWashingOneDAL.Update(ProcessWashingOne, this.LoggedInUser);

            ProcessWashingOneBusinessObject = mapProcessWashingOne.GetProcessWashingOneBusinessObject(ProcessWashingOne);

            return ProcessWashingOneBusinessObject;

        }

        public bool DeleteProcessWashingOne(BusinessModel.ProcessWashingOne ProcessWashingOneBusinessObject)
        {
            Mapper.Mappings.MapProcessWashingOne mapProcessWashingOne = new Mapper.Mappings.MapProcessWashingOne();

            var ProcessWashingOne = mapProcessWashingOne.GetProcessWashingOneDatabaseObject(ProcessWashingOneBusinessObject);

            bool status = this._ProcessWashingOneDAL.Delete(ProcessWashingOne, this.LoggedInUser);

            return status;
        }

    }
}
