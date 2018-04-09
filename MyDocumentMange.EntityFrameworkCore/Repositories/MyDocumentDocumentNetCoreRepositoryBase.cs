using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentMange.EntityFrameworkCore.Repositories
{
    public abstract class MyDocumentDocumentNetCoreRepositoryBase<TEntity,TPrimaryKey>: EfCoreRepositoryBase<LocalCoreDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyDocumentDocumentNetCoreRepositoryBase(IDbContextProvider<LocalCoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="MyDocumentRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class MyDocumentDocumentNetCoreRepositoryBase<TEntity> : MyDocumentDocumentNetCoreRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyDocumentDocumentNetCoreRepositoryBase(IDbContextProvider<LocalCoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
