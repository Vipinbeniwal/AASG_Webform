using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  Mapxp_TimeSheetChild
    {
        #region xp_TimeSheetChild Mapping

        public App.BusinessModel.xp_TimeSheetChild Getxp_TimeSheetChildBusinessObject(App.Data.xp_TimeSheetChild xp_TimeSheetChildDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.xp_TimeSheetChild, App.BusinessModel.xp_TimeSheetChild>();
            var xp_TimeSheetChildBusinessObject = AutoMapper.Mapper.Map<App.Data.xp_TimeSheetChild, App.BusinessModel.xp_TimeSheetChild>(xp_TimeSheetChildDBObject);
            return xp_TimeSheetChildBusinessObject;
        }

        public App.Data.xp_TimeSheetChild Getxp_TimeSheetChildDatabaseObject(App.BusinessModel.xp_TimeSheetChild xp_TimeSheetChildBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.xp_TimeSheetChild, App.Data.xp_TimeSheetChild>();
            var xp_TimeSheetChildDBObject = AutoMapper.Mapper.Map<App.BusinessModel.xp_TimeSheetChild, App.Data.xp_TimeSheetChild>(xp_TimeSheetChildBusinessObject);
            return xp_TimeSheetChildDBObject;
        }

        #endregion
    }
}
