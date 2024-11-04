using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using DataAccess.DataContext;

namespace UnitOfWorkRepository.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        ChallengePPIContext Context { get; }
        void Commit();
        void DetectChanges();
        Task CommitAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ChallengePPIContext Context { get; }

        public UnitOfWork(ChallengePPIContext context)
        {
            Context = context;
        }

        #region Commit
        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }
        #endregion

        #region Detect Changes
        public void DetectChanges()
        {
            Context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Transactions
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            Context.Database.RollbackTransaction();
        }
        #endregion
        public void Dispose()
         {
            Context.Dispose();
        }
    }
}
