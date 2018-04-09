using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Domain.Controllers
{
    public class MyDocumentManageControllerBase: AbpController
    {
        protected MyDocumentManageControllerBase()
        {
            LocalizationSourceName = "MyDocumentMange";
        }

        //protected void CheckErrors(IdentityResult identityResult)
        //{
        //    identityResult.CheckErrors(LocalizationManager);
        //}
    }
}
