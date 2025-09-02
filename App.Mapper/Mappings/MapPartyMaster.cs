using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapPartyMaster
    {
        #region PartyMaster Mapping

        public PartyMaster GetPartyMasterBusinessObject(App.Data.PartyMaster PartyMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.PartyMaster, PartyMaster>();
            var PartyMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.PartyMaster, PartyMaster>(PartyMasterDBObject);
            return PartyMasterBusinessObject;
        }

        public App.Data.PartyMaster GetPartyMasterDatabaseObject(PartyMaster PartyMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<PartyMaster, App.Data.PartyMaster>();
            var PartyMasterDBObject = AutoMapper.Mapper.Map<PartyMaster, App.Data.PartyMaster>(PartyMasterBusinessObject);
            return PartyMasterDBObject;
        }

        #endregion
    }
}
