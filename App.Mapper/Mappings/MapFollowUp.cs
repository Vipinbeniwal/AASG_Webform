using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapFollowUp
    { 
        #region FollowUp Mapping

        public FollowUp GetFollowUpBusinessObject(App.Data.FollowUp FollowUpDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.FollowUp, FollowUp>();
            var FollowUpBusinessObject = AutoMapper.Mapper.Map<App.Data.FollowUp, FollowUp>(FollowUpDBObject);
            return FollowUpBusinessObject;
        }

        public App.Data.FollowUp GetFollowUpDatabaseObject(FollowUp FollowUpBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<FollowUp, App.Data.FollowUp>();
            var FollowUpDBObject = AutoMapper.Mapper.Map<FollowUp, App.Data.FollowUp>(FollowUpBusinessObject);
            return FollowUpDBObject;
        }

        #endregion
    }
}
