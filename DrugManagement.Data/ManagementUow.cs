using System;
using DrugManagement.Data.Contracts;
using DrugManagement.Data.Helper;
using DrugManagement.Model;

namespace DrugManagement.Data
{
    public class ManagementUow : IManagementUow, IDisposable
    {
        private ManagementDbContext DbContext { get; set; }

        public ManagementUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Drug> Drugs { get { return GetStandardRepo<Drug>(); } }


        public int Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new ManagementDbContext();

            // Do NOT enable proxied entities, else serialization fails
            //DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            //DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            //DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
        #endregion
    }
}
