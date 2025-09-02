using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class DrawingMasterBL
    {
        #region Properties/Variables
        DrawingMasterDL _DrawingMasterDAL = new DrawingMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public DrawingMasterBL()
        {
            // this._DrawingMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DrawingMaster>();
        }

        public DrawingMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._DrawingMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DrawingMaster>();
        }
        #endregion

        public BusinessModel.DrawingMaster CreateDrawingMaster(BusinessModel.DrawingMaster DrawingMasterBusinessObject)
        {
            Mapper.Mappings.MapDrawingMaster DrawingMasterMenu = new Mapper.Mappings.MapDrawingMaster();

            var report = DrawingMasterMenu.GetDrawingMasterDatabaseObject(DrawingMasterBusinessObject);

            report = this._DrawingMasterDAL.Create(report, this.LoggedInUser);

            DrawingMasterBusinessObject = DrawingMasterMenu.GetDrawingMasterBusinessObject(report);

            return DrawingMasterBusinessObject;

        }

        public List<BusinessModel.DrawingMaster> GetAllDrawingMasterItems()
        {
            Mapper.Mappings.MapDrawingMaster DrawingMasterMenu = new Mapper.Mappings.MapDrawingMaster();

            var DrawingMasterItemsDALList = this._DrawingMasterDAL.GetAll();

            List<BusinessModel.DrawingMaster> DrawingMasterItemsBusinessList = new List<BusinessModel.DrawingMaster>();
            foreach (App.Data.DrawingMaster DrawingMasterItem in DrawingMasterItemsDALList)
            {
                DrawingMasterItemsBusinessList.Add(DrawingMasterMenu.GetDrawingMasterBusinessObject(DrawingMasterItem));
            }

            return DrawingMasterItemsBusinessList;
        }

        public List<BusinessModel.DrawingMaster> GetDrawingMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapDrawingMaster DrawingMasterMenu = new Mapper.Mappings.MapDrawingMaster();

            var DrawingMasterItemsDALList = this._DrawingMasterDAL.GetbyId(Id);

            List<BusinessModel.DrawingMaster> DrawingMasterItemsBusinessList = new List<BusinessModel.DrawingMaster>();
            foreach (App.Data.DrawingMaster DrawingMasterItem in DrawingMasterItemsDALList)
            {
                DrawingMasterItemsBusinessList.Add(DrawingMasterMenu.GetDrawingMasterBusinessObject(DrawingMasterItem));
            }

            return DrawingMasterItemsBusinessList;
        }

        public List<BusinessModel.DrawingMaster> GetDrawingMasterByName(string term)
        {
            Mapper.Mappings.MapDrawingMaster DrawingMasterMenu = new Mapper.Mappings.MapDrawingMaster();

            var DrawingMasterItemsDALList = this._DrawingMasterDAL.GetByName(term);

            List<BusinessModel.DrawingMaster> DrawingMasterItemsBusinessList = new List<BusinessModel.DrawingMaster>();

            foreach (App.Data.DrawingMaster DrawingMasterItem in DrawingMasterItemsDALList)
            {
                DrawingMasterItemsBusinessList.Add(DrawingMasterMenu.GetDrawingMasterBusinessObject(DrawingMasterItem));
            }

            return DrawingMasterItemsBusinessList;
        }

        public BusinessModel.DrawingMaster UpdateDrawingMaster(BusinessModel.DrawingMaster DrawingMasterBusinessObject)
        {
            Mapper.Mappings.MapDrawingMaster mapDrawingMaster = new Mapper.Mappings.MapDrawingMaster();

            var DrawingMaster = mapDrawingMaster.GetDrawingMasterDatabaseObject(DrawingMasterBusinessObject);

            DrawingMaster = this._DrawingMasterDAL.Update(DrawingMaster, this.LoggedInUser);

            DrawingMasterBusinessObject = mapDrawingMaster.GetDrawingMasterBusinessObject(DrawingMaster);

            return DrawingMasterBusinessObject;

        }

        public bool DeleteDrawingMaster(BusinessModel.DrawingMaster DrawingMasterBusinessObject)
        {
            Mapper.Mappings.MapDrawingMaster mapDrawingMaster = new Mapper.Mappings.MapDrawingMaster();

            var DrawingMaster = mapDrawingMaster.GetDrawingMasterDatabaseObject(DrawingMasterBusinessObject);

            bool status = this._DrawingMasterDAL.Delete(DrawingMaster, this.LoggedInUser);

            return status;
        }

    }
}
