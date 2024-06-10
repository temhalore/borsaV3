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
using Prj.COMMON.Aspects.Logging;
using Prj.COMMON.Aspects.Logging.Serilog;
using Prj.COMMON.Extensions;
using Prj.COMMON.Helpers;
using Prj.COMMON.Models;

namespace Prj.COMMON.Aspects
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new ArgumentException("Wrong Logger Type");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceProviderHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            var logDetailWithException = GetLogDetail(invocation);

            //if (e is AggregateException)
            //    logDetailWithException.ExceptionMessage = string.Join(Environment.NewLine, (e as AggregateException).InnerExceptions.Select(x => x.Message));
            //else
            //    logDetailWithException.ExceptionMessage = e.Message;
            if (e.GetType() != typeof(AppException))
            {
                _loggerServiceBase.Error(e, JsonConvert.SerializeObject(logDetailWithException).RemoveMessageBase64ImageData());
            }

        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                string type11 = invocation.Arguments[i]?.GetType()?.Name??"";
                if (type11.Contains("Stream"))
                {
                    continue;
                }
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod()?.GetParameters()[i]?.Name??"Name empty",
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i]?.GetType()?.Name
                });
            }
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.DeclaringType.Name + "." + invocation.Method.Name,
                Parameters = logParameters
            };
            return logDetail;
        }
    }
}
