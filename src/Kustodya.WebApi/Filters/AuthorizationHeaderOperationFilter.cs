using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApi.Filters
{
    public class AuthorizationHeaderOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Adds an authorization header to the given operation in Swagger.
        /// </summary>
        /// <param name="operation">The Swashbuckle operation.</param>
        /// <param name="context">The Swashbuckle operation filter context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            context.ApiDescription.TryGetMethodInfo(out MethodInfo info);

            var allowAnonAttributes = info
                .GetCustomAttributes().OfType<AllowAnonymousAttribute>();

            if (context.ApiDescription.ActionDescriptor is Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor controller)
            {
                var authorizeAttributes = controller.ControllerTypeInfo.GetCustomAttributes().OfType<AuthorizeAttribute>();

                if (!authorizeAttributes.Any() || allowAnonAttributes.Any())
                {
                    return;
                }
            }


            //var token = _tokenGenerator.CreateJwtSecurityToken(new User
            //{
            //	Email = "superAdmin@proyectatsp.com",
            //	FirstName = "super",
            //	Id = 1,
            //	LastName = "admin"
            //}).Result;

            var parameter = new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "The bearer token",
                Required = true
            };

            //operation.Parameters.Add(parameter);
        }
    }
}