using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapDraftMaster
    {
        #region DraftMaster Mapping

        public App.BusinessModel.DraftMaster GetDraftMasterBusinessObject(App.Data.DraftMaster DraftMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.DraftMaster, App.BusinessModel.DraftMaster>();
            var DraftMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.DraftMaster, App.BusinessModel.DraftMaster>(DraftMasterDBObject);
            return DraftMasterBusinessObject;
        }

        public App.Data.DraftMaster GetDraftMasterDatabaseObject(App.BusinessModel.DraftMaster DraftMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.DraftMaster, App.Data.DraftMaster>();
            var DraftMasterDBObject = AutoMapper.Mapper.Map<App.BusinessModel.DraftMaster, App.Data.DraftMaster>(DraftMasterBusinessObject);
            return DraftMasterDBObject;
        }

        #endregion
    }
}
