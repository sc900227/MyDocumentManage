using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentMange.EntityFramework.Repositories
{
    public class MyDocumentManageRepositoryBase<TEntity,TPrimaryKey>: EfRepositoryBase<LocalDbContext,TEntity,TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public MyDocumentManageRepositoryBase(IDbContextProvider<LocalDbContext> dbContextProvider) :base(dbContextProvider) { }
    }
}
