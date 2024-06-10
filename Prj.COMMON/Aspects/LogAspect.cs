﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Prj.COMMON.Aspects.Interceptors;
using Prj.COMMON.Helpers;
using Prj.COMMON.Aspects.Logging.Serilog;
using Prj.COMMON.Aspects.Logging;

namespace Prj.COMMON.Aspects
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
              //  throw new ArgumentException(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)ServiceProviderHelper.ServiceProvider.GetService(loggerService);
            _httpContextAccessor = ServiceProviderHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase?.Info(GetLogDetail(invocation));
        }

        private string GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                string type11 = invocation.Arguments[i]?.GetType().Name;
                if (type11.Contains("Stream")) 
                {
                    continue;
                }

                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.GetConcreteMethod().GetParameters()[i].Name == "Password" ? "***" : invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                });
            }
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.DeclaringType.Name + "." + invocation.Method.Name,
                Parameters = logParameters
            };

            return JsonConvert.SerializeObject(logDetail);
        }
    }
}
