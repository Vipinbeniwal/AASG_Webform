using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapSupplierMaster
    {
        #region SupplierMaster Mapping

        public SupplierMaster GetSupplierMasterBusinessObject(App.Data.SupplierMaster SupplierMasterDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.SupplierMaster, SupplierMaster>();
            var SupplierMasterBusinessObject = AutoMapper.Mapper.Map<App.Data.SupplierMaster, SupplierMaster>(SupplierMasterDBObject);
            return SupplierMasterBusinessObject;
        }

        public App.Data.SupplierMaster GetSupplierMasterDatabaseObject(SupplierMaster SupplierMasterBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<SupplierMaster, App.Data.SupplierMaster>();
            var SupplierMasterDBObject = AutoMapper.Mapper.Map<SupplierMaster, App.Data.SupplierMaster>(SupplierMasterBusinessObject);
            return SupplierMasterDBObject;
        }

        #endregion
    }
}
