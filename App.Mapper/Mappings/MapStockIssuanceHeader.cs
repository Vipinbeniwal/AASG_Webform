using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapStockIssuanceHeader
    {
        #region StockIssuanceHeader Mapping

        public App.BusinessModel.StockIssuanceHeader GetStockIssuanceHeaderBusinessObject(App.Data.StockIssuanceHeader StockIssuanceHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.StockIssuanceHeader, App.BusinessModel.StockIssuanceHeader>();
            var StockIssuanceHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.StockIssuanceHeader, App.BusinessModel.StockIssuanceHeader>(StockIssuanceHeaderDBObject);
            return StockIssuanceHeaderBusinessObject;
        }

        public App.Data.StockIssuanceHeader GetStockIssuanceHeaderDatabaseObject(App.BusinessModel.StockIssuanceHeader StockIssuanceHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.StockIssuanceHeader, App.Data.StockIssuanceHeader>();
            var StockIssuanceHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.StockIssuanceHeader, App.Data.StockIssuanceHeader>(StockIssuanceHeaderBusinessObject);
            return StockIssuanceHeaderDBObject;
        }

        #endregion
    }
}
