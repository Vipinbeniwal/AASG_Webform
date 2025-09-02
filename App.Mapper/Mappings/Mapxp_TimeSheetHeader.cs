using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  Mapxp_TimeSheetHeader
    {
        #region xp_TimeSheetHeader Mapping

        public App.BusinessModel.xp_TimeSheetHeader Getxp_TimeSheetHeaderBusinessObject(App.Data.xp_TimeSheetHeader xp_TimeSheetHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.xp_TimeSheetHeader, App.BusinessModel.xp_TimeSheetHeader>();
            var xp_TimeSheetHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.xp_TimeSheetHeader, App.BusinessModel.xp_TimeSheetHeader>(xp_TimeSheetHeaderDBObject);
            return xp_TimeSheetHeaderBusinessObject;
        }

        public App.Data.xp_TimeSheetHeader Getxp_TimeSheetHeaderDatabaseObject(App.BusinessModel.xp_TimeSheetHeader xp_TimeSheetHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.xp_TimeSheetHeader, App.Data.xp_TimeSheetHeader>();
            var xp_TimeSheetHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.xp_TimeSheetHeader, App.Data.xp_TimeSheetHeader>(xp_TimeSheetHeaderBusinessObject);
            return xp_TimeSheetHeaderDBObject;
        }

        #endregion
    }
}
