using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapTourGradeMaster
    {
        #region TourGradeMaster Mapping

        public TourGradeMaster GetTourGradeMasterBusinessObject(App.Data.TourGradeMaster TourGradeMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.TourGradeMaster, TourGradeMaster>();
            var TourGradeMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.TourGradeMaster, TourGradeMaster>(TourGradeMasterDBObject);
            return TourGradeMasterBusinessObject;
        }

        public App.Data.TourGradeMaster GetTourGradeMasterDatabaseObject(TourGradeMaster TourGradeMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<TourGradeMaster, App.Data.TourGradeMaster>();
            var TourGradeMasterDBObject = AutoMapper.Mapper.Map<TourGradeMaster, App.Data.TourGradeMaster>(TourGradeMasterBusinessObject);
            return TourGradeMasterDBObject;
        }

        #endregion
    }
}
