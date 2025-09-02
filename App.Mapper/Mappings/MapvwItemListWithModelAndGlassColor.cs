using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class MapvwItemListWithModelAndGlassColor
    {
        #region vwItemListWithModelAndGlassColor Mapping

        public App.BusinessModel.vwItemListWithModelAndGlassColor GetvwItemListWithModelAndGlassColorBusinessObject(App.Data.vwItemListWithModelAndGlassColor vwItemListWithModelAndGlassColorDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwItemListWithModelAndGlassColor, App.BusinessModel.vwItemListWithModelAndGlassColor>();
            var vwItemListWithModelAndGlassColorBusinessObject = AutoMapper.Mapper.Map<App.Data.vwItemListWithModelAndGlassColor, App.BusinessModel.vwItemListWithModelAndGlassColor > (vwItemListWithModelAndGlassColorDBObject);
            return vwItemListWithModelAndGlassColorBusinessObject;
        }

        public App.Data.vwItemListWithModelAndGlassColor GetvwItemListWithModelAndGlassColorDatabaseObject(App.BusinessModel.vwItemListWithModelAndGlassColor vwItemListWithModelAndGlassColorBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwItemListWithModelAndGlassColor, App.Data.vwItemListWithModelAndGlassColor>();
            var vwItemListWithModelAndGlassColorDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwItemListWithModelAndGlassColor, App.Data.vwItemListWithModelAndGlassColor>(vwItemListWithModelAndGlassColorBusinessObject);
            return vwItemListWithModelAndGlassColorDBObject;
        }

        #endregion
    }
}
