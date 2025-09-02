using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapLeadHeader
    {
        #region LeadHeader Mapping

        public LeadHeader GetLeadHeaderBusinessObject(App.Data.LeadHeader LeadHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.LeadHeader, LeadHeader>();
            var LeadHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.LeadHeader, LeadHeader>(LeadHeaderDBObject);
            return LeadHeaderBusinessObject;
        }

        public App.Data.LeadHeader GetLeadHeaderDatabaseObject(LeadHeader LeadHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<LeadHeader, App.Data.LeadHeader>();
            var LeadHeaderDBObject = AutoMapper.Mapper.Map<LeadHeader, App.Data.LeadHeader>(LeadHeaderBusinessObject);
            return LeadHeaderDBObject;
        }

        #endregion
    }
}
