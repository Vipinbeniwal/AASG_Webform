using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class MapvwSaleOrderDashboardData
    {
        #region vwSaleOrderDashboardData Mapping

        public App.BusinessModel.vwSaleOrderDashboardData GetvwSaleOrderDashboardDataBusinessObject(App.Data.vwSaleOrderDashboardData vwSaleOrderDashboardDataDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwSaleOrderDashboardData, App.BusinessModel.vwSaleOrderDashboardData>();
            var vwSaleOrderDashboardDataBusinessObject = AutoMapper.Mapper.Map<App.Data.vwSaleOrderDashboardData, App.BusinessModel.vwSaleOrderDashboardData>(vwSaleOrderDashboardDataDBObject);
            return vwSaleOrderDashboardDataBusinessObject;
        }

        public App.Data.vwSaleOrderDashboardData GetvwSaleOrderDashboardDataDatabaseObject(App.BusinessModel.vwSaleOrderDashboardData vwSaleOrderDashboardDataBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwSaleOrderDashboardData, App.Data.vwSaleOrderDashboardData>();
            var vwSaleOrderDashboardDataDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwSaleOrderDashboardData, App.Data.vwSaleOrderDashboardData>(vwSaleOrderDashboardDataBusinessObject);
            return vwSaleOrderDashboardDataDBObject;
        }

        #endregion
    }
}
