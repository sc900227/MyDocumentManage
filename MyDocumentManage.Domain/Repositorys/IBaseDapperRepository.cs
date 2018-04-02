using Abp.Dapper.Repositories;
using Abp.Dependency;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys
{
    public interface IBaseDapperRepository<TEntity,TPrimaryKey>: IDapperRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}
