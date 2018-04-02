using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Abp.NHibernate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys
{
    public class BaseDapperRepository<TEntity, TPrimaryKey>: EfRepositoryBase<LocalDbContext, TEntity, TPrimaryKey>, IBaseDapperRepository<TEntity, TPrimaryKey> where TEntity:class, IEntity<TPrimaryKey>
    {
        public BaseDapperRepository(LocalDbContextProvider<LocalDbContext> dbContextProvider) : base(dbContextProvider) { }
        //public BaseDapperRepository(LocalDbActiveTransactionProvider DbActive) : base(DbActive) { }
    }
}
