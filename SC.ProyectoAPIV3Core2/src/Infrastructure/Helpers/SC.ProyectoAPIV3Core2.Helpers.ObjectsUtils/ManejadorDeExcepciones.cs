using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SC.ProyectoAPIV3Core2.Helpers.ObjectsUtils
{
    public class ManejadorDeExcepciones : IMiddleware

    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
