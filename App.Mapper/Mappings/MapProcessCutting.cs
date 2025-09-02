using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessCutting
    {
        #region ProcessCutting Mapping

        public App.BusinessModel.ProcessCutting GetProcessCuttingBusinessObject(App.Data.ProcessCutting ProcessCuttingDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessCutting, App.BusinessModel.ProcessCutting>();
            var ProcessCuttingBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessCutting, App.BusinessModel.ProcessCutting>(ProcessCuttingDBObject);
            return ProcessCuttingBusinessObject;
        }

        public App.Data.ProcessCutting GetProcessCuttingDatabaseObject(App.BusinessModel.ProcessCutting ProcessCuttingBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessCutting, App.Data.ProcessCutting>();
            var ProcessCuttingDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessCutting, App.Data.ProcessCutting>(ProcessCuttingBusinessObject);
            return ProcessCuttingDBObject;
        }

        #endregion
    }
}
