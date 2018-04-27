using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MyDocumentMange.EntityFrameworkCore
{
    public class AppConfigurtaionServices
    {
        //public static IConfiguration Configuration { get; set; }
        //static AppConfigurtaionServices()
        //{
        //    //ReloadOnChange = true 当appsettings.json被修改时重新加载            
        //    IConfiguration Configuration = new ConfigurationBuilder()
        //    .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
        //    .Build();
        //}
        public static IConfiguration GetAppSettings() {
            IConfiguration Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();

            return Configuration;
        }
    }
}
