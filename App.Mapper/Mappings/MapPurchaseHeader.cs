using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;

namespace App.Mapper.Mappings
{
    public class  MapPurchaseHeader
    {
        #region PurchaseHeader Mapping

        public App.BusinessModel.PurchaseHeader GetPurchaseHeaderBusinessObject(App.Data.PurchaseHeader PurchaseHeaderDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.PurchaseHeader, App.BusinessModel.PurchaseHeader>();
            var PurchaseHeaderBusinessObject = AutoMapper.Mapper.Map<App.Data.PurchaseHeader, App.BusinessModel.PurchaseHeader>(PurchaseHeaderDBObject);
            return PurchaseHeaderBusinessObject;
        }

        public App.Data.PurchaseHeader GetPurchaseHeaderDatabaseObject(App.BusinessModel.PurchaseHeader PurchaseHeaderBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.PurchaseHeader, App.Data.PurchaseHeader>();
            var PurchaseHeaderDBObject = AutoMapper.Mapper.Map<App.BusinessModel.PurchaseHeader, App.Data.PurchaseHeader>(PurchaseHeaderBusinessObject);
            return PurchaseHeaderDBObject;
        }

        #endregion
    }
}
