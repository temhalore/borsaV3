﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Prj.COMMON.Middlewares;

namespace Prj.COMMON.Extensions
{
    /// <summary>
    /// bunu program.cs te göstermeliyiz buraya her eklenen eklenecektir sıra önemlilik arz ediyorsa dikkat edilmeli
    /// </summary>
    public static class CustomMiddlewareExtensions
    {
        public static void ConfigureCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<SerilogMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
