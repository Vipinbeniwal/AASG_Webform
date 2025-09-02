using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class UserRoleDL : IUserRole, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<UserRole> queryable;

        public IQueryable<UserRole> GetAll()
        {
            queryable = context.UserRoles;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.UserRoles.Where(x => x.user_role_id == Id);
            return queryable;
        }

        public IQueryable<UserRole> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public UserRole Create(UserRole UserRoleEntity, string loggedInUser)
        {
            if (validate(UserRoleEntity))
            {
                try
                {
                    UserRoleEntity.modified_on = DateTime.Now;
                    UserRoleEntity.created_on = DateTime.Now;
                    UserRoleEntity.created_by = 0;
                    UserRoleEntity.modified_by = 0;
                    UserRoleEntity.user_ip = "";
                    UserRoleEntity.is_active = true;

                    UserRoleEntity = context.UserRoles.Add(UserRoleEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return UserRoleEntity;
        }

        public UserRole Update(UserRole UserRoleEntity, string loggedInUser)
        {
            UserRole objUserRole = null;
            if (validate(UserRoleEntity))
            {
                objUserRole = context.UserRoles.Find(UserRoleEntity.user_role_id);

                context.Entry(objUserRole).CurrentValues.SetValues(UserRoleEntity);

                context.SaveChanges();
            }
            return objUserRole;
        }

        public bool Delete(UserRole UserRoleEntity, string loggedInUser)
        {
            if (validate(UserRoleEntity))
            {
                try
                {
                    UserRole _UserRole = context.UserRoles.First(x => x.user_role_id == UserRoleEntity.user_role_id);
                    context.UserRoles.Remove(_UserRole);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(UserRole UserRoleEntity)
        {
            if (UserRoleEntity != null)
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
