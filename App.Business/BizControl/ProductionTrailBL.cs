using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProductionTrailBL
    {
        #region Properties/Variables
        ProductionTrailDL _ProductionTrailDAL = new ProductionTrailDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProductionTrailBL()
        {
            // this._ProductionTrailDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProductionTrail>();
        }

        public ProductionTrailBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProductionTrailDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProductionTrail>();
        }
        #endregion

        public BusinessModel.ProductionTrail CreateProductionTrail(BusinessModel.ProductionTrail ProductionTrailBusinessObject)
        {
            Mapper.Mappings.MapProductionTrail ProductionTrailMenu = new Mapper.Mappings.MapProductionTrail();

            var report = ProductionTrailMenu.GetProductionTrailDatabaseObject(ProductionTrailBusinessObject);

            report = this._ProductionTrailDAL.Create(report, this.LoggedInUser);

            ProductionTrailBusinessObject = ProductionTrailMenu.GetProductionTrailBusinessObject(report);

            return ProductionTrailBusinessObject;

        }

        public List<BusinessModel.ProductionTrail> GetAllProductionTrailItems()
        {
            Mapper.Mappings.MapProductionTrail ProductionTrailMenu = new Mapper.Mappings.MapProductionTrail();

            var ProductionTrailItemsDALList = this._ProductionTrailDAL.GetAll();

            List<BusinessModel.ProductionTrail> ProductionTrailItemsBusinessList = new List<BusinessModel.ProductionTrail>();
            foreach (App.Data.ProductionTrail ProductionTrailItem in ProductionTrailItemsDALList)
            {
                ProductionTrailItemsBusinessList.Add(ProductionTrailMenu.GetProductionTrailBusinessObject(ProductionTrailItem));
            }

            return ProductionTrailItemsBusinessList;
        }

        public List<BusinessModel.ProductionTrail> GetProductionTrailItemsByID(int Id)
        {
            Mapper.Mappings.MapProductionTrail ProductionTrailMenu = new Mapper.Mappings.MapProductionTrail();

            var ProductionTrailItemsDALList = this._ProductionTrailDAL.GetbyId(Id);

            List<BusinessModel.ProductionTrail> ProductionTrailItemsBusinessList = new List<BusinessModel.ProductionTrail>();
            foreach (App.Data.ProductionTrail ProductionTrailItem in ProductionTrailItemsDALList)
            {
                ProductionTrailItemsBusinessList.Add(ProductionTrailMenu.GetProductionTrailBusinessObject(ProductionTrailItem));
            }

            return ProductionTrailItemsBusinessList;
        }

        public List<BusinessModel.ProductionTrail> GetProductionTrailByName(string term)
        {
            Mapper.Mappings.MapProductionTrail ProductionTrailMenu = new Mapper.Mappings.MapProductionTrail();

            var ProductionTrailItemsDALList = this._ProductionTrailDAL.GetByName(term);

            List<BusinessModel.ProductionTrail> ProductionTrailItemsBusinessList = new List<BusinessModel.ProductionTrail>();

            foreach (App.Data.ProductionTrail ProductionTrailItem in ProductionTrailItemsDALList)
            {
                ProductionTrailItemsBusinessList.Add(ProductionTrailMenu.GetProductionTrailBusinessObject(ProductionTrailItem));
            }

            return ProductionTrailItemsBusinessList;
        }

        public BusinessModel.ProductionTrail UpdateProductionTrail(BusinessModel.ProductionTrail ProductionTrailBusinessObject)
        {
            Mapper.Mappings.MapProductionTrail mapProductionTrail = new Mapper.Mappings.MapProductionTrail();

            var ProductionTrail = mapProductionTrail.GetProductionTrailDatabaseObject(ProductionTrailBusinessObject);

            ProductionTrail = this._ProductionTrailDAL.Update(ProductionTrail, this.LoggedInUser);

            ProductionTrailBusinessObject = mapProductionTrail.GetProductionTrailBusinessObject(ProductionTrail);

            return ProductionTrailBusinessObject;

        }

        public bool DeleteProductionTrail(BusinessModel.ProductionTrail ProductionTrailBusinessObject)
        {
            Mapper.Mappings.MapProductionTrail mapProductionTrail = new Mapper.Mappings.MapProductionTrail();

            var ProductionTrail = mapProductionTrail.GetProductionTrailDatabaseObject(ProductionTrailBusinessObject);

            bool status = this._ProductionTrailDAL.Delete(ProductionTrail, this.LoggedInUser);

            return status;
        }

    }
}
