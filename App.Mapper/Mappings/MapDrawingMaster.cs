using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapDrawingMaster
    {
        #region DrawingMaster Mapping

        public App.BusinessModel.DrawingMaster GetDrawingMasterBusinessObject(App.Data.DrawingMaster DrawingMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.DrawingMaster, App.BusinessModel.DrawingMaster>();
            var DrawingMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.DrawingMaster, App.BusinessModel.DrawingMaster>(DrawingMasterDBObject);
            return DrawingMasterBusinessObject;
        }

        public App.Data.DrawingMaster GetDrawingMasterDatabaseObject(App.BusinessModel.DrawingMaster DrawingMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.DrawingMaster, App.Data.DrawingMaster>();
            var DrawingMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.DrawingMaster, App.Data.DrawingMaster>(DrawingMasterBusinessObject);
            return DrawingMasterDBObject;
        }

        #endregion
    }
}
