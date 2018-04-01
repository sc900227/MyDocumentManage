using Abp.Data;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain
{
    public class LocalDbActiveTransactionProvider : IActiveTransactionProvider, ISingletonDependency, IDisposable
    {
        private IDbConnection conn;
        public LocalDbActiveTransactionProvider() {
            // 数据库连接串
            var connString = string.Format("data source={0};", @"D:\Document\ReportDB.db");
            conn = new SQLiteConnection(connString);
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void Dispose()
        {
            conn.Dispose();
        }

        public IDbConnection GetActiveConnection(ActiveTransactionProviderArgs args)
        {
            return conn;
        }

        public IDbTransaction GetActiveTransaction(ActiveTransactionProviderArgs args)
        {
            IDbTransaction dbTransaction = conn.BeginTransaction();
            return dbTransaction;
        }
    }
}
