using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapProductionTrail
    {
        #region Activity Log Mapping

        public App.BusinessModel.ProductionTrail GetProductionTrailBusinessObject(App.Data.ProductionTrail ProductionTrailDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProductionTrail, App.BusinessModel.ProductionTrail>();
            var ProductionTrailBusinessObject = AutoMapper.Mapper.Map<App.Data.ProductionTrail, App.BusinessModel.ProductionTrail>(ProductionTrailDBObject);
            return ProductionTrailBusinessObject;
        }

        public App.Data.ProductionTrail GetProductionTrailDatabaseObject(App.BusinessModel.ProductionTrail ProductionTrailBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProductionTrail, App.Data.ProductionTrail>();
            var ProductionTrailDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProductionTrail, App.Data.ProductionTrail>(ProductionTrailBusinessObject);
            return ProductionTrailDBObject;
        }

        #endregion
    }
}
