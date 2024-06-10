using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Minio.DataModel;
using Nest;
using Prj.BAL.Managers.Deneme.Interfaces;
using Prj.BAL.Managers.Uygulama.Interfaces;
using Prj.COMMON.DTO.Base;
using Prj.COMMON.Models;
using Prj.COMMON.Models.ServiceResponce;
using Prj.COMMON.Models.ServiceResponce.Interfaces;
using Prj.Service.Filters;

namespace OYS.API.Controllers
{
    [Route("Api/Deneme")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
       private readonly IDenemeManager _denemeManager;
       private readonly IKodManager _kodManager;

        public DenemeController(IDenemeManager denemeManager, IKodManager kodManager)
        {
          _denemeManager = denemeManager;
            _kodManager = kodManager;
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

        /// <summary>
        /// örnek bir get vlue lu metod çağrılması :https://localhost:7104/Api/Deneme/getMetodDeneme?request=adasdas
        /// 
        /// call get metod da buna benzer bir metod isteyeceğiz bunu kendileri yazacak biz sadece odemeKey göndereceğiz.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getMetodDeneme")]
        // public IActionResult getMetodDeneme([FromUri] SingleValueDTO<long> request)
        public IActionResult getMetodDeneme(string key,long keyTipId)
        {
            var response = new ServiceResponse<object>();
            try
            {
                response.data = key + " " + keyTipId;
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
        [Route("GetCodeByTipId")]
        public IActionResult GetCodeByTipId()
        {
            var response = new ServiceResponse<object>();
            try
            {
                var aa = _kodManager.GetKodDtoListByKodTipId(103);
                response.data = aa;
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
