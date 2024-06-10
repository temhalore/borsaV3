using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OYS.COMMON.DTO.ServiceResponse.AppServiceResponse
{
    public class AppServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public int Code { get; set; } = 200;
        public string Message { get; set; }
        public object Data { get; set; }
        public AppServiceResponse() { }
        public AppServiceResponse(object entity) : this(true, "", entity,200)
        {
        }
        public AppServiceResponse(string message, object entity) : this(true, message, entity,200)
        {
        }
        public AppServiceResponse(bool isSuccess, string message,int code) : this(isSuccess, message, null, code)
        {
        }
        public AppServiceResponse(bool isSuccess, string message, object entity,int code)
        {
            this.Code= code;    
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Data = entity;
        }

    }
}
