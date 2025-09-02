using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapTourMaster
    {
        #region TourMaster Mapping

        public TourMaster GetTourMasterBusinessObject(App.Data.TourMaster TourMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.TourMaster, TourMaster>();
            var TourMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.TourMaster, TourMaster>(TourMasterDBObject);
            return TourMasterBusinessObject;
        }

        public App.Data.TourMaster GetTourMasterDatabaseObject(TourMaster TourMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<TourMaster, App.Data.TourMaster>();
            var TourMasterDBObject = AutoMapper.Mapper.Map<TourMaster, App.Data.TourMaster>(TourMasterBusinessObject);
            return TourMasterDBObject;
        }

        #endregion
    }
}
