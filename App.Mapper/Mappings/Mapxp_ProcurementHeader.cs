using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  Mapxp_ProcurementHeader
    {
        #region xp_ProcurementHeader Mapping

        public App.BusinessModel.xp_ProcurementHeader Getxp_ProcurementHeaderBusinessObject(App.Data.xp_ProcurementHeader xp_ProcurementHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.xp_ProcurementHeader, App.BusinessModel.xp_ProcurementHeader>();
            var xp_ProcurementHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.xp_ProcurementHeader, App.BusinessModel.xp_ProcurementHeader>(xp_ProcurementHeaderDBObject);
            return xp_ProcurementHeaderBusinessObject;
        }

        public App.Data.xp_ProcurementHeader Getxp_ProcurementHeaderDatabaseObject(App.BusinessModel.xp_ProcurementHeader xp_ProcurementHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.xp_ProcurementHeader, App.Data.xp_ProcurementHeader>();
            var xp_ProcurementHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.xp_ProcurementHeader, App.Data.xp_ProcurementHeader>(xp_ProcurementHeaderBusinessObject);
            return xp_ProcurementHeaderDBObject;
        }

        #endregion
    }
}
