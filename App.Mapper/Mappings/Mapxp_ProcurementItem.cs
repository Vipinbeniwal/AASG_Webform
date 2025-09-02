using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  Mapxp_ProcurementItem
    {
        #region xp_ProcurementItem Mapping

        public App.BusinessModel.xp_ProcurementItem Getxp_ProcurementItemBusinessObject(App.Data.xp_ProcurementItem xp_ProcurementItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.xp_ProcurementItem, App.BusinessModel.xp_ProcurementItem>();
            var xp_ProcurementItemBusinessObject = AutoMapper.Mapper.Map<App.Data.xp_ProcurementItem, App.BusinessModel.xp_ProcurementItem>(xp_ProcurementItemDBObject);
            return xp_ProcurementItemBusinessObject;
        }

        public App.Data.xp_ProcurementItem Getxp_ProcurementItemDatabaseObject(App.BusinessModel.xp_ProcurementItem xp_ProcurementItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.xp_ProcurementItem, App.Data.xp_ProcurementItem>();
            var xp_ProcurementItemDBObject = AutoMapper.Mapper.Map<App.BusinessModel.xp_ProcurementItem, App.Data.xp_ProcurementItem>(xp_ProcurementItemBusinessObject);
            return xp_ProcurementItemDBObject;
        }

        #endregion
    }
}
