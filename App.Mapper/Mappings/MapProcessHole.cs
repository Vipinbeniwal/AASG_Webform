using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapProcessHole
    {
        #region ProcessHole Mapping

        public App.BusinessModel.ProcessHole GetProcessHoleBusinessObject(App.Data.ProcessHole ProcessHoleDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.ProcessHole, App.BusinessModel.ProcessHole>();
            var ProcessHoleBusinessObject = AutoMapper.Mapper.Map<App.Data.ProcessHole, App.BusinessModel.ProcessHole>(ProcessHoleDBObject);
            return ProcessHoleBusinessObject;
        }

        public App.Data.ProcessHole GetProcessHoleDatabaseObject(App.BusinessModel.ProcessHole ProcessHoleBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<App.BusinessModel.ProcessHole, App.Data.ProcessHole>();
            var ProcessHoleDBObject = AutoMapper.Mapper.Map<App.BusinessModel.ProcessHole, App.Data.ProcessHole>(ProcessHoleBusinessObject);
            return ProcessHoleDBObject;
        }

        #endregion
    }
}
