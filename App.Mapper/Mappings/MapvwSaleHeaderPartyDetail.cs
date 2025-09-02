using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class MapvwSaleHeaderPartyDetail
    {
        #region vwSaleHeaderPartyDetail Mapping

        public App.BusinessModel.vwSaleHeaderPartyDetail GetvwSaleHeaderPartyDetailBusinessObject(App.Data.vwSaleHeaderPartyDetail vwSaleHeaderPartyDetailDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwSaleHeaderPartyDetail, App.BusinessModel.vwSaleHeaderPartyDetail>();
            var vwSaleHeaderPartyDetailBusinessObject = AutoMapper.Mapper.Map<App.Data.vwSaleHeaderPartyDetail, App.BusinessModel.vwSaleHeaderPartyDetail>(vwSaleHeaderPartyDetailDBObject);
            return vwSaleHeaderPartyDetailBusinessObject;
        }

        public App.Data.vwSaleHeaderPartyDetail GetvwSaleHeaderPartyDetailDatabaseObject(App.BusinessModel.vwSaleHeaderPartyDetail vwSaleHeaderPartyDetailBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwSaleHeaderPartyDetail, App.Data.vwSaleHeaderPartyDetail>();
            var vwSaleHeaderPartyDetailDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwSaleHeaderPartyDetail, App.Data.vwSaleHeaderPartyDetail>(vwSaleHeaderPartyDetailBusinessObject);
            return vwSaleHeaderPartyDetailDBObject;
        }

        #endregion
    }
}
