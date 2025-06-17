using Newtonsoft.Json;
using RestSharp;//这个库装的是106.15.0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DailyApp.Wpf.HttpClients
{
    /// <summary>
    /// 调用api的工具类
    /// </summary>
    public class HttpRestClient
    {
        /// <summary>
        /// 客户端
        /// </summary>
        private readonly RestClient restClient;

        /// <summary>
        /// 请求地址（公共部分）
        /// </summary>
        //private readonly string baseUrl = "https://192.168.1.9:7174/api/";//https://192.168.1.9:7174 这是笔记本网络的IP地址
        private readonly string baseUrl = "http://localhost:5192/api/";

        public HttpRestClient()
        {
            //restClient = new RestClient(baseUrl+ "Account/Register");//这种方式可以连接上

            // 忽略所有证书错误（全局生效）没效果
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, errors) => true;
            // 强制使用 TLS 1.2（适用于 .NET Framework 4.5+ 和 .NET Core）没效果
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            restClient = new RestClient();
        }
        /// <summary>
        /// 请求api
        /// </summary>
        /// <param name="apiRequest">请求数据</param>
        /// <returns>接收数据</returns>
        public ApiResponse? Execute(ApiRequest apiRequest)
        {
            try
            {
                var request = new RestRequest();
                request.Method = apiRequest.Method;//请求方式
                request.AddHeader("Content-Type", apiRequest.ContentType);//内容类型
                
                if (apiRequest.Parameters != null)//参数
                {
                    request.AddParameter("param", JsonConvert.SerializeObject(apiRequest.Parameters), ParameterType.RequestBody);
                }
                //var uri = restClient.BuildUri(request);//这个方法只会返回Uri，并不会给内部BaseUrl赋值
                restClient.BaseUrl = new Uri(baseUrl + apiRequest.Route);

                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                IRestResponse response = restClient.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(response.Content ?? "");
                }
                else
                {
                    return new ApiResponse
                    {
                        ResultCode = -99,
                        Msg = "服务器忙，请稍等",//具体报错写在服务端的log里，防止被别人看到
                        ResultData = ""
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    ResultCode = -99,
                    Msg = "服务器忙，请稍等",//具体报错写在服务端的log里，防止被别人看到
                    ResultData = ""
                };
                //throw;
            }
           
        }
    }
}
