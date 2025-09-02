using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProduction
    {
        #region Production Mapping

        public App.BusinessModel.Production GetProductionBusinessObject(App.Data.Production ProductionDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.Production, App.BusinessModel.Production>();
            var ProductionBusinessObject = AutoMapper.Mapper.Map<App.Data.Production, App.BusinessModel.Production>(ProductionDBObject);
            return ProductionBusinessObject;
        }

        public App.Data.Production GetProductionDatabaseObject(App.BusinessModel.Production ProductionBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.Production, App.Data.Production>();
            var ProductionDBObject = AutoMapper.Mapper.Map<App.BusinessModel.Production, App.Data.Production>(ProductionBusinessObject);
            return ProductionDBObject;
        }

        #endregion
    }
}
