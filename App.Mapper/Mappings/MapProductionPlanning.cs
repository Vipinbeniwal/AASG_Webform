using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProductionPlanning
    {
        #region ProductionPlanning Mapping

        public ProductionPlanning GetProductionPlanningBusinessObject(App.Data.ProductionPlanning ProductionPlanningDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProductionPlanning, ProductionPlanning>();
            var ProductionPlanningBusinessObject = AutoMapper.Mapper.Map<App.Data.ProductionPlanning, ProductionPlanning>(ProductionPlanningDBObject);
            return ProductionPlanningBusinessObject;
        }

        public App.Data.ProductionPlanning GetProductionPlanningDatabaseObject(ProductionPlanning ProductionPlanningBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<ProductionPlanning, App.Data.ProductionPlanning>();
            var ProductionPlanningDBObject = AutoMapper.Mapper.Map<ProductionPlanning, App.Data.ProductionPlanning>(ProductionPlanningBusinessObject);
            return ProductionPlanningDBObject;
        }

        #endregion
    }
}
