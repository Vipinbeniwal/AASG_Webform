using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ActivityLogDL : IActivityLog, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ActivityLog> queryable;

        public IQueryable<ActivityLog> GetAll()
        {
            queryable = context.ActivityLogs;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ActivityLogs.Where(x => x.activity_log_id == Id);
            return queryable;
        }

        public IQueryable<ActivityLog> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ActivityLog Create(ActivityLog ActivityLogEntity, string loggedInUser)
        {
            if (validate(ActivityLogEntity))
            {
                try
                {
                    ActivityLogEntity = context.ActivityLogs.Add(ActivityLogEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return ActivityLogEntity;
        }

        public ActivityLog Update(ActivityLog ActivityLogEntity, string loggedInUser)
        {
            ActivityLog objActivityLog = null;
            if (validate(ActivityLogEntity))
            {
                objActivityLog = context.ActivityLogs.Find(ActivityLogEntity.activity_log_id);

                context.Entry(objActivityLog).CurrentValues.SetValues(ActivityLogEntity);

                context.SaveChanges();
            }
            return objActivityLog;
        }

        public bool Delete(ActivityLog ActivityLogEntity, string loggedInUser)
        {
            if (validate(ActivityLogEntity))
            {
                try
                {
                    ActivityLog _ActivityLog = context.ActivityLogs.First(x => x.activity_log_id == ActivityLogEntity.activity_log_id);
                    context.ActivityLogs.Remove(_ActivityLog);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ActivityLog ActivityLogEntity)
        {
            if (ActivityLogEntity != null)
            {
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }


    }
}
