using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProductionBL
    {
        #region Properties/Variables
        ProductionDL _ProductionDAL = new ProductionDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProductionBL()
        {
            // this._ProductionDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.Production>();
        }

        public ProductionBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProductionDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.Production>();
        }
        #endregion

        public BusinessModel.Production CreateProduction(BusinessModel.Production ProductionBusinessObject)
        {
            Mapper.Mappings.MapProduction ProductionMenu = new Mapper.Mappings.MapProduction();

            var report = ProductionMenu.GetProductionDatabaseObject(ProductionBusinessObject);

            report = this._ProductionDAL.Create(report, this.LoggedInUser);

            ProductionBusinessObject = ProductionMenu.GetProductionBusinessObject(report);

            return ProductionBusinessObject;

        }

        public List<BusinessModel.Production> GetAllProductionItems()
        {
            Mapper.Mappings.MapProduction ProductionMenu = new Mapper.Mappings.MapProduction();

            var ProductionItemsDALList = this._ProductionDAL.GetAll();

            List<BusinessModel.Production> ProductionItemsBusinessList = new List<BusinessModel.Production>();
            foreach (App.Data.Production ProductionItem in ProductionItemsDALList)
            {
                ProductionItemsBusinessList.Add(ProductionMenu.GetProductionBusinessObject(ProductionItem));
            }

            return ProductionItemsBusinessList;
        }

        public List<BusinessModel.Production> GetProductionItemsByID(int Id)
        {
            Mapper.Mappings.MapProduction ProductionMenu = new Mapper.Mappings.MapProduction();

            var ProductionItemsDALList = this._ProductionDAL.GetbyId(Id);

            List<BusinessModel.Production> ProductionItemsBusinessList = new List<BusinessModel.Production>();
            foreach (App.Data.Production ProductionItem in ProductionItemsDALList)
            {
                ProductionItemsBusinessList.Add(ProductionMenu.GetProductionBusinessObject(ProductionItem));
            }

            return ProductionItemsBusinessList;
        }

        public List<BusinessModel.Production> GetProductionByName(string term)
        {
            Mapper.Mappings.MapProduction ProductionMenu = new Mapper.Mappings.MapProduction();

            var ProductionItemsDALList = this._ProductionDAL.GetByName(term);

            List<BusinessModel.Production> ProductionItemsBusinessList = new List<BusinessModel.Production>();

            foreach (App.Data.Production ProductionItem in ProductionItemsDALList)
            {
                ProductionItemsBusinessList.Add(ProductionMenu.GetProductionBusinessObject(ProductionItem));
            }

            return ProductionItemsBusinessList;
        }

        public BusinessModel.Production UpdateProduction(BusinessModel.Production ProductionBusinessObject)
        {
            Mapper.Mappings.MapProduction mapProduction = new Mapper.Mappings.MapProduction();

            var Production = mapProduction.GetProductionDatabaseObject(ProductionBusinessObject);

            Production = this._ProductionDAL.Update(Production, this.LoggedInUser);

            ProductionBusinessObject = mapProduction.GetProductionBusinessObject(Production);

            return ProductionBusinessObject;

        }

        public bool DeleteProduction(BusinessModel.Production ProductionBusinessObject)
        {
            Mapper.Mappings.MapProduction mapProduction = new Mapper.Mappings.MapProduction();

            var Production = mapProduction.GetProductionDatabaseObject(ProductionBusinessObject);

            bool status = this._ProductionDAL.Delete(Production, this.LoggedInUser);

            return status;
        }

    }
}
