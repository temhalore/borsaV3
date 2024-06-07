using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Minio.DataModel;
using Nest;
using Prj.COMMON.DTO.Base;
using Prj.COMMON.Models;
using Prj.COMMON.Models.ServiceResponce;
using Prj.Service.Filters;

namespace OYS.API.Controllers
{
    [Route("Api/Deneme")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
     //   private readonly IDenemeManager _denemeManager;

        public DenemeController()
        {
    //        _denemeManager = denemeManager;
        }


        [HttpPost]
        [Route("getSingleValuePost")]
        public IActionResult getSingleValuePost(SingleValueDTO<String> request)
        {

            var response = new ServiceResponse<object>();
            try
            {
                response.data = request.Value;
                return Ok(response);
            }
            catch (AppException appEx)
            {
                response = new ServiceResponse<object>(appEx);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.messageType = MessageType.Error.ToString();
                return Ok(response);
            }
        }


        [HttpGet]
        [Route("GetValue")]
        public IActionResult GetValue()
        {
            var response = new ServiceResponse<object>();
            try
            {
                response.data = "selam canımmm!!!";
                return Ok(response);
            }
            catch (AppException appEx)
            {
                response = new ServiceResponse<object>(appEx);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.messageType = MessageType.Error.ToString();
                return Ok(response);
            }
        }
    }
}
