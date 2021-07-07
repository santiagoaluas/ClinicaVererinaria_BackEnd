using clinicaveterinariaBackEnd.Dtos.Respuestas;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Helps
{
    public class ManagerException : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ManagerException(IWebHostEnvironment webHostEnvironment,
                                IModelMetadataProvider modelMetadataProvider)
        {
            _hostEnviroment = webHostEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            String msn = $"Tipo: {context.Exception.GetType()}, {(context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message)}";
            context.Result = new JsonResult(new Respuesta()
            {
                exito = false,
                mensaje = msn
            });
        }
    }
}
