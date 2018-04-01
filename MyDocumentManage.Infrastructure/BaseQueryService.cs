﻿using Abp.Dependency;
using Abp.NHibernate;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Infrastructure
{
    public class BaseQueryService: ITransientDependency
    {
        private ISessionProvider _sessionProvider;

        protected BaseQueryService(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            var conn = _sessionProvider.Session.Connection;
            return conn.Query<T>(sql, param);
        }
    }
}
