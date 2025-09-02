using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class MapvwPurchaseOrderDashboardData
    {
        #region vwPurchaseOrderDashboardData Mapping

        public App.BusinessModel.vwPurchaseOrderDashboardData GetvwPurchaseHeaderDetailBusinessObject(App.Data.vwPurchaseOrderDashboardData vwPurchaseHeaderDetailDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwPurchaseOrderDashboardData, App.BusinessModel.vwPurchaseOrderDashboardData>();
            var vwPurchaseHeaderDetailBusinessObject = AutoMapper.Mapper.Map<App.Data.vwPurchaseOrderDashboardData, App.BusinessModel.vwPurchaseOrderDashboardData > (vwPurchaseHeaderDetailDBObject);
            return vwPurchaseHeaderDetailBusinessObject;
        }

        public App.Data.vwPurchaseOrderDashboardData GetvwPurchaseHeaderDetailDatabaseObject(App.BusinessModel.vwPurchaseOrderDashboardData vwPurchaseHeaderDetailBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwPurchaseOrderDashboardData, App.Data.vwPurchaseOrderDashboardData>();
            var vwPurchaseHeaderDetailDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwPurchaseOrderDashboardData, App.Data.vwPurchaseOrderDashboardData>(vwPurchaseHeaderDetailBusinessObject);
            return vwPurchaseHeaderDetailDBObject;
        }

        #endregion
    }
}
