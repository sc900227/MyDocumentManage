using Abp.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Web
{
    public class SecurityRequirementsOperationFilter: IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            var actionAttrs = context.ApiDescription.ActionAttributes();
            if (actionAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerAttrs = context.ApiDescription.ControllerAttributes();
            var actionAbpAuthorizeAttrs = actionAttrs.OfType<AbpAuthorizeAttribute>();

            if (!actionAbpAuthorizeAttrs.Any() && controllerAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerAbpAuthorizeAttrs = controllerAttrs.OfType<AbpAuthorizeAttribute>();
            if (controllerAbpAuthorizeAttrs.Any() || actionAbpAuthorizeAttrs.Any())
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });

                var permissions = controllerAbpAuthorizeAttrs.Union(actionAbpAuthorizeAttrs)
                    .SelectMany(p => p.Permissions)
                    .Distinct();

                if (permissions.Any())
                {
                    operation.Responses.Add("403", new Response { Description = "Forbidden" });
                }

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "bearerAuth", permissions }
                    }
                };
            }
        }
    }
}
