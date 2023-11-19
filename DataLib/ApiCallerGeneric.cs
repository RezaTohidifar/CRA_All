using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class ApiCallerGeneric
    {
        private readonly IDBConHellper _dBConHellper;
        public ApiCallerGeneric(IDBConHellper dBConHellper)
        {
            _dBConHellper = dBConHellper;
        }
        public async Task<U> CRACallerGenericAsync<T, U>(T data, string url) where T : class, new() where U : class, new()
        {
            string reqDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff");
            Stopwatch stopWatch = new();
            stopWatch.Start();
            using HttpResponseMessage response = await APIClient.ApiClient.PostAsync(url, CRAContentModelMaker.CRAdataGeneric(data));
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    U responseContent = await response.Content.ReadAsAsync<U>();
                    stopWatch.Stop();
                    int ts = (int)stopWatch.ElapsedMilliseconds;
                    DBLOG dbInfo = new()
                    {
                        elapsedTime = ts,
                        request = JsonConvert.SerializeObject(data),
                        response = JsonConvert.SerializeObject(responseContent),
                        requestTime = reqDate,
                        responseTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff"),
                        target = url,
                        exceptions = null
                    };
                    _dBConHellper.LogDBForAll(dbInfo);
                    if (typeof(T) != typeof(MobileCountModel) && typeof(T) != typeof(CRAPUTMODEL))
                    {
                        object val = typeof(T).GetProperty("serviceNumber").GetValue(data);
                        responseContent.GetType().GetProperty("servicenumber").SetValue(responseContent, val);
                    }
                    return responseContent;
                }
                else
                {
                    stopWatch.Stop();
                    return new U();
                }
            }
            catch (Exception e)
            {
                DBLOG logers = new DBLOG()
                {
                    elapsedTime = null,
                    request = JsonConvert.SerializeObject(data),
                    response = null,
                    requestTime = reqDate,
                    responseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff"),
                    target = url,
                    exceptions = e.Message
                };
                _dBConHellper.LogDBForAll(logers);
                return new U();
            }
        }
    }
}