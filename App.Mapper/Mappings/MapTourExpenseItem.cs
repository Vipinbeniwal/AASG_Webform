using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mapper;
using App.BusinessModel;

namespace App.Mapper.Mappings
{
    public class  MapTourExpenseItem
    {
        #region TourExpenseItem Mapping

        public TourExpenseItem GetTourExpenseItemBusinessObject(App.Data.TourExpenseItem TourExpenseItemDBObject)
        {
            AutoMapper.Mapper.CreateMap<App.Data.TourExpenseItem, TourExpenseItem>();
            var TourExpenseItemBusinessObject = AutoMapper.Mapper.Map<App.Data.TourExpenseItem, TourExpenseItem>(TourExpenseItemDBObject);
            return TourExpenseItemBusinessObject;
        }

        public App.Data.TourExpenseItem GetTourExpenseItemDatabaseObject(TourExpenseItem TourExpenseItemBusinessObject)
        {
            AutoMapper.Mapper.CreateMap<TourExpenseItem, App.Data.TourExpenseItem>();
            var TourExpenseItemDBObject = AutoMapper.Mapper.Map<TourExpenseItem, App.Data.TourExpenseItem>(TourExpenseItemBusinessObject);
            return TourExpenseItemDBObject;
        }

        #endregion
    }
}
