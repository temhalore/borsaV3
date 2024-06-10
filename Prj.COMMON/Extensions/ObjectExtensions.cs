using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Prj.COMMON.Helpers;

namespace Prj.COMMON.Extensions
{
    public static class ObjectExtensions
    {
        public static T Map<T>(this object value)
        {
            var _mapper = ServiceProviderHelper.ServiceProvider.GetService<IMapper>();
            return _mapper.Map<T>(value);
        }



    }
}
