using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class Mapvwxp_ProcurementHeaderSupplierDetail
    {
        #region vwxp_ProcurementHeaderSupplierDetail Mapping

        public App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail GetvwPurchaseHeaderDetailBusinessObject(App.Data.vwxp_ProcurementHeaderSupplierDetail vwPurchaseHeaderDetailDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.vwxp_ProcurementHeaderSupplierDetail, App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail>();
            var vwPurchaseHeaderDetailBusinessObject = AutoMapper.Mapper.Map<App.Data.vwxp_ProcurementHeaderSupplierDetail, App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail > (vwPurchaseHeaderDetailDBObject);
            return vwPurchaseHeaderDetailBusinessObject;
        }

        public App.Data.vwxp_ProcurementHeaderSupplierDetail GetvwPurchaseHeaderDetailDatabaseObject(App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail vwPurchaseHeaderDetailBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail, App.Data.vwxp_ProcurementHeaderSupplierDetail>();
            var vwPurchaseHeaderDetailDBObject = AutoMapper.Mapper.Map<App.BusinessModel.vwxp_ProcurementHeaderSupplierDetail, App.Data.vwxp_ProcurementHeaderSupplierDetail>(vwPurchaseHeaderDetailBusinessObject);
            return vwPurchaseHeaderDetailDBObject;
        }

        #endregion
    }
}
