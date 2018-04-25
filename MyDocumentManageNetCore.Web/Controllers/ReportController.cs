using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyDocumentManageNetCore.Domain.Controllers;

namespace MyDocumentManageNetCore.Web.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ReportController : MyDocumentManageControllerBase
    {
        public IConfiguration Configuration { get; }
        public ReportController(IConfiguration configuration) {
            Configuration = configuration;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [EnableCors("AllowSameDomain")]
        public FileStreamResult Download() {
            try
            {
                var dbPath = "app/doc";//Configuration.GetSection("DbOption").GetValue<string>("DbPath");
                if (!Directory.Exists(dbPath))
                {
                    throw new Exception("服务器下载路径异常");
                }

                var filename = Configuration.GetSection("DbOption").GetValue<string>("DbName");
                var strPath = Path.Combine(dbPath, filename);
                if (!System.IO.File.Exists(strPath))
                {
                    throw new Exception("服务器未找到当前文件" + filename);
                }
                var copyPath = CopyAndEncryptDb(strPath);
                var stream = new FileStream(copyPath, FileMode.Open);
                
                FileStreamResult result = new FileStreamResult(stream,"application/octet-stream");
                result.FileDownloadName = filename;
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string CopyAndEncryptDb(string filePath)
        {
            string copyDir = Configuration.GetSection("CopyOption").GetValue<string>("CopyPath");
            string copyFileName = Configuration.GetSection("CopyOption").GetValue<string>("CopyDbName");
            string copyPath = Path.Combine(copyDir, copyFileName);
            if (!System.IO.Directory.Exists(copyDir))
            {
                Directory.CreateDirectory(copyDir);
            }
            if (System.IO.File.Exists(copyPath))
            {
                System.IO.File.Delete(copyPath);
            }
            //复制db文件到相关目录
            using (var stream = System.IO.File.Open(filePath, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                using (var fs = System.IO.File.Open(copyPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.SetLength(0);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                    fs.Close();
                }
                //加密db文件
                EncryptDb(copyPath);
            }
            return copyPath;
        }
        public void EncryptDb(string copyPath) {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = copyPath;
            builder.Pooling = true;
            builder.FailIfMissing = true;
            builder.JournalMode = SQLiteJournalModeEnum.Off;
            builder.Password = "";
            using (SQLiteConnection conn = new SQLiteConnection(builder.ConnectionString))
            {
                conn.Open();
                conn.ChangePassword("pv123*456");
                conn.Close();
            }
        }
        
    }
}