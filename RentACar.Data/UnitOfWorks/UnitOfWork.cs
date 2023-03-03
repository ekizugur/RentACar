using Microsoft.EntityFrameworkCore;
using RentACar.Data.Context;
using RentACar.Data.Repository.Abstracts;
using RentACar.Data.Repository.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Dispose()
        {
            dbContext.DisposeAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

       
        public int Save()
        {
            return dbContext.SaveChanges();
        }
      

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }
    }
}
