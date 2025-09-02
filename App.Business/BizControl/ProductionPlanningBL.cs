using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProductionPlanningBL
    {
        #region Properties/Variables
        ProductionPlanningDL _ProductionPlanningDAL = new ProductionPlanningDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProductionPlanningBL()
        {
            // this._ProductionPlanningDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProductionPlanning>();
        }

        public ProductionPlanningBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProductionPlanningDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProductionPlanning>();
        }
        #endregion

        public BusinessModel.ProductionPlanning CreateProductionPlanning(BusinessModel.ProductionPlanning ProductionPlanningBusinessObject)
        {
            Mapper.Mappings.MapProductionPlanning ProductionPlanningMenu = new Mapper.Mappings.MapProductionPlanning();

            var report = ProductionPlanningMenu.GetProductionPlanningDatabaseObject(ProductionPlanningBusinessObject);

            report = this._ProductionPlanningDAL.Create(report, this.LoggedInUser);

            ProductionPlanningBusinessObject = ProductionPlanningMenu.GetProductionPlanningBusinessObject(report);

            return ProductionPlanningBusinessObject;

        }

        public List<BusinessModel.ProductionPlanning> GetAllProductionPlanningItems()
        {
            Mapper.Mappings.MapProductionPlanning ProductionPlanningMenu = new Mapper.Mappings.MapProductionPlanning();

            var ProductionPlanningItemsDALList = this._ProductionPlanningDAL.GetAll();

            List<BusinessModel.ProductionPlanning> ProductionPlanningItemsBusinessList = new List<BusinessModel.ProductionPlanning>();
            foreach (App.Data.ProductionPlanning ProductionPlanningItem in ProductionPlanningItemsDALList)
            {
                ProductionPlanningItemsBusinessList.Add(ProductionPlanningMenu.GetProductionPlanningBusinessObject(ProductionPlanningItem));
            }

            return ProductionPlanningItemsBusinessList;
        }

        public List<BusinessModel.ProductionPlanning> GetProductionPlanningItemsByID(int Id)
        {
            Mapper.Mappings.MapProductionPlanning ProductionPlanningMenu = new Mapper.Mappings.MapProductionPlanning();

            var ProductionPlanningItemsDALList = this._ProductionPlanningDAL.GetbyId(Id);

            List<BusinessModel.ProductionPlanning> ProductionPlanningItemsBusinessList = new List<BusinessModel.ProductionPlanning>();
            foreach (App.Data.ProductionPlanning ProductionPlanningItem in ProductionPlanningItemsDALList)
            {
                ProductionPlanningItemsBusinessList.Add(ProductionPlanningMenu.GetProductionPlanningBusinessObject(ProductionPlanningItem));
            }

            return ProductionPlanningItemsBusinessList;
        }

        public List<BusinessModel.ProductionPlanning> GetProductionPlanningByName(string term)
        {
            Mapper.Mappings.MapProductionPlanning ProductionPlanningMenu = new Mapper.Mappings.MapProductionPlanning();

            var ProductionPlanningItemsDALList = this._ProductionPlanningDAL.GetByName(term);

            List<BusinessModel.ProductionPlanning> ProductionPlanningItemsBusinessList = new List<BusinessModel.ProductionPlanning>();

            foreach (App.Data.ProductionPlanning ProductionPlanningItem in ProductionPlanningItemsDALList)
            {
                ProductionPlanningItemsBusinessList.Add(ProductionPlanningMenu.GetProductionPlanningBusinessObject(ProductionPlanningItem));
            }

            return ProductionPlanningItemsBusinessList;
        }

        public BusinessModel.ProductionPlanning UpdateProductionPlanning(BusinessModel.ProductionPlanning ProductionPlanningBusinessObject)
        {
            Mapper.Mappings.MapProductionPlanning mapProductionPlanning = new Mapper.Mappings.MapProductionPlanning();

            var ProductionPlanning = mapProductionPlanning.GetProductionPlanningDatabaseObject(ProductionPlanningBusinessObject);

            ProductionPlanning = this._ProductionPlanningDAL.Update(ProductionPlanning, this.LoggedInUser);

            ProductionPlanningBusinessObject = mapProductionPlanning.GetProductionPlanningBusinessObject(ProductionPlanning);

            return ProductionPlanningBusinessObject;

        }

        public bool DeleteProductionPlanning(BusinessModel.ProductionPlanning ProductionPlanningBusinessObject)
        {
            Mapper.Mappings.MapProductionPlanning mapProductionPlanning = new Mapper.Mappings.MapProductionPlanning();

            var ProductionPlanning = mapProductionPlanning.GetProductionPlanningDatabaseObject(ProductionPlanningBusinessObject);

            bool status = this._ProductionPlanningDAL.Delete(ProductionPlanning, this.LoggedInUser);

            return status;
        }

    }
}
