using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessStore
    {
        #region ProcessStore Mapping

        public App.BusinessModel.ProcessStore GetProcessStoreBusinessObject(App.Data.ProcessStore ProcessStoreDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessStore, App.BusinessModel.ProcessStore>();
            var ProcessStoreBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessStore, App.BusinessModel.ProcessStore>(ProcessStoreDBObject);
            return ProcessStoreBusinessObject;
        }

        public App.Data.ProcessStore GetProcessStoreDatabaseObject(App.BusinessModel.ProcessStore ProcessStoreBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessStore, App.Data.ProcessStore>();
            var ProcessStoreDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessStore, App.Data.ProcessStore>(ProcessStoreBusinessObject);
            return ProcessStoreDBObject;
        }

        #endregion
    }
}
