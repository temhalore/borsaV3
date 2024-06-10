﻿using Microsoft.AspNetCore.Http;
using Prj.BAL.Managers.Helper.Interfaces;
using Prj.COMMON.Configuration;
using System.Net;


namespace Prj.BAL.Managers.Helper
{
    public class HelperManager : IHelperManager
    {

        static List<string> directAccessList = new List<string>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperManager(IHttpContextAccessor httpContextAccessor)
        {
            //_modelDtoConverterHelper = modelDtoConverterHelper;
            _httpContextAccessor = httpContextAccessor;
            directAccessList = CoreConfig.directAccessList;

        }



        //////public KisiDTO GetKisiDto()
        //////{
        //////    string token = GetToken();

        //////    var kt = GetKisiTokenDtoByToken(token);

        //////    return kt.kisiDto;

        //////}

        //////public KisiTokenDTO GetKisiTokenDto()
        //////{



        //////    bool isDirectAccess = false;

        //////    //_helperManager.SetDirectAccess(false);
        //////    var rd = _httpContextAccessor.HttpContext.Request.Path.Value;

        //////    var split = rd.Split("/");

        //////    var name = split[split.Length - 1];


        //////    if (directAccessList != null && directAccessList.Contains(name))
        //////    {
        //////        isDirectAccess = true;
        //////    }

        //////    //dirextaccesli gelenlerde bu şekilde dönsün
        //////    if (isDirectAccess)
        //////    {
        //////        var ktdirect = new KisiTokenDTO();
        //////        ktdirect.kisiDto = new KisiDTO() { id = -999 };
        //////        ktdirect.ip = GetIPAddress();
        //////        return ktdirect;
        //////    }

        //////    string token = GetToken();

        //////    var kt = GetKisiTokenDtoByToken(token);

        //////    return kt;

        //////}

        //////public KisiTokenDTO GetKisiTokenDtoByToken(string token)
        //////{

        //////    var repoKisiToken = new GenericRepository<T_oys_KisiToken>();
        //////    var repoKisiTokenClob = new GenericRepository<T_oys_KisiTokenClob>();

        //////    var kisiToken = repoKisiToken.Get("OYS_TOKEN =@token", new { token });

        //////    if (kisiToken == null || kisiToken.ID == 0)
        //////    {
        //////        throw new OYSException(MessageCode.ERROR_501, "login bilgilerinizde problem tespit edildi lütfen yeniden login olunuz.");
        //////    }

        //////    var tokenClobData = kisiToken == null ? null : repoKisiTokenClob.Get((long)kisiToken.LOGIN_DTO_JSON_CLOB_ID);

        //////    KisiTokenDTO kisiTokenDto = JsonConvert.DeserializeObject<KisiTokenDTO>(tokenClobData.LOGIN_DTO_JSON);

        //////    if (kisiTokenDto == null || kisiTokenDto.id == 0)
        //////    {
        //////        throw new OYSException(MessageCode.ERROR_501, "login bilgilerinizde problem tespit edildi lütfen yeniden login olnuz.");
        //////    }

        //////    return kisiTokenDto;
        //////}

        public string GetToken()
        {
            string tokenName = CoreConfig.TokenKeyName;

            if (null != _httpContextAccessor.HttpContext)
            {
                try
                {
                    string deger = "";
                    string token = _httpContextAccessor.HttpContext.Request.Headers[tokenName].SingleOrDefault();
                    if (token != null || token == "")
                    {
                        deger = token;
                    }
                    else
                    {
                        //Servis için bearer token kontrolü yapsın
                        token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                        if (token != null || token == "")
                        {
                            deger = token;
                        }
                        else
                        {

                            deger = null;
                        }
                    }
                    return deger;

                }
                catch (Exception ex)
                {

                    return null;
                }

            }

            return null;
        }

        public string GetIPAddress()
        {
            try
            {


                string adres = "";
                IPAddress ip;
                var headers = _httpContextAccessor.HttpContext.Request.Headers.ToList();
                if (headers.Exists((kvp) => kvp.Key == "X-Forwarded-For"))
                {
                    // when running behind a load balancer you can expect this header
                    var header = headers.First((kvp) => kvp.Key == "X-Forwarded-For").Value.ToString();
                    ip = IPAddress.Parse(header);
                }
                else
                {
                    // this will always have a value (running locally in development won't have the header)
                    ip = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
                }
                try
                {
                    adres = ip?.ToString();
                }
                catch (Exception ex)
                {

                    // throw;
                }

                adres = adres.Replace("::1", "127.0.0.1");

                return adres;

            }
            catch (Exception)
            {

                return "";
            }
        }

        public string GetUserAgent()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
                deger += " Platform:" + GetPlatform();
                deger += " Device:" + GetDevice();
                deger += " Browser:" + GetBrowser();
                return deger;
            }

            return "";
        }

        public string GetPlatform()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = _httpContextAccessor.HttpContext.Request.Headers["sec-ch-ua-platform"].ToString();
                return deger;
            }
            return "";
        }

        public string GetDevice()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = GetPlatform();
                deger += " MobileDevice:" + GetMobileDevice();
                return deger;
            }
            return "";
        }

        public string GetHost()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = _httpContextAccessor.HttpContext.Request.Headers["Host"].ToString();

                return deger;
            }
            return "";
        }

        public string GetBrowser()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = _httpContextAccessor.HttpContext.Request.Headers["sec-ch-ua"].ToString();
                //    deger += " Device:" + GetDevice();
                //deger += " Platform:" + GetPlatform();
                //deger += " Browser:" + GetBrowser();
                return deger;
            }
            return "";
        }

        public string GetMobileDevice()
        {
            if (null != _httpContextAccessor.HttpContext)
            {
                string deger = _httpContextAccessor.HttpContext.Request.Headers["sec-ch-ua-mobile"].ToString();
                return deger;
            }
            return "";
        }


    }
}
