
using Microsoft.AspNetCore.Mvc;
using Prj.COMMON.Models.ServiceResponce.Interfaces;


namespace Prj.COMMON.Models.ServiceResponce
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        //Taumlamalar//
        //Mesaj Tipi
        string _messageType;
        string _messageTypeCode;
        string _messageAppCode;
        string _messageHeader;
        string _message;

        AppExceptionModel _AppException;
        //Data
        public T data { get; set; }
        //Others
        public int pageNumber { get; set; }
        public int itemsPerPage { get; set; }
        public int totalItems { get; set; }
        ////////
        public ServiceResponse()
        {
        }

        public ServiceResponse(T entity)
        {
            _messageType = ServiceResponseMessageType.Success;
        }

        public ServiceResponse(AppException appEx)
        {
            _messageType = ServiceResponseMessageType.Error;
            _AppException = new AppExceptionModel()
            {
                code = appEx.code,
                errorCode = appEx.errorCode,
                messageHeader = appEx.messageHeader,
                appMessage = appEx.appMessage
            };
        }

        public string messageHeader { get { return _messageHeader; }
            set
            {
                _messageHeader = value;
            }
        }
        public string message
        {
            get
            {
                return _message;
            }
            set
            {
                _messageType = ServiceResponseMessageType.Success;
                _message = value;
            }
        }

        //Nessage Type Setter
        public string messageType
        {
            get
            {
                return _messageType;

            }
            set
            {
                _messageType = value;
                if (this.messageType == ServiceResponseMessageType.Success)
                {
                    _messageHeader = "Başarılı İşlem";
                }
                if (this.messageType == ServiceResponseMessageType.Error)
                {
                    _messageHeader = "Hatalı İşlem";
                }
                if (this.messageType == ServiceResponseMessageType.Warning)
                {
                    _messageHeader = "Uyarı Mesajı";
                }
            }
        }


        // projeye özel  EXCEPTION
        public AppExceptionModel AppException
        {
            get
            {
                return _AppException;
            }
            set
            {
                _messageType = ServiceResponseMessageType.Error;
                _AppException = value;
            }
        }

        public  IActionResult OkResult(T data,string message= "İşlem tamamlandı")
        {
            this.data = data;
            this.message = message;
            return new OkObjectResult(this);
        }
       

    }


    public static class ServiceResponseMessageType
    {
        public static string Error = "error";
        public static string Success = "success";
        public static string Warning = "warning";
        public static string Info = "info";
    }

    public static class ServiceResponseMessage
    {
        public static string Save = "Kaydedildi";
        public static string Delete = "Silindi";
        public static string List = "Liste çekildi";
    }
    public class AppExceptionModel
    {
        public string messageHeader { get; set; }
        public int code { get; set; }
        public string appMessage { get; set; }
        public string errorCode { get; set; }

    }

}
