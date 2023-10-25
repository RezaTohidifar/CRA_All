using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataLib;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using Newtonsoft.Json;

namespace DataLib
{
    public class ApiCaller
    {
        public async static Task<CRAPUTOUTMODEL> CRRPutCaller(CRAPUTMODEL cRAPUTMODEL )
        {
            var URL = @"http://172.22.7.16:8280/Shahkar/1.4/put";
            var reqDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff");
            using (HttpResponseMessage response = await APIClient.ApiClient.PostAsync(URL, CRAContentModelMaker.CRAPUTMAKER(cRAPUTMODEL)))
            {
                try
                {
                    Stopwatch stopWatch = new();
                    stopWatch.Start();
                    CRAPUTOUTMODEL responseContent = await response.Content.ReadAsAsync<CRAPUTOUTMODEL>();
                    responseContent.mobileNumber = cRAPUTMODEL.service.mobileNumber;
                    stopWatch.Stop();
                    int ts = (int)stopWatch.ElapsedMilliseconds;
                    return responseContent;
               
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    var returnFalse = new CRAPUTOUTMODEL()
                    {
                        comment = e.Message,
                        requestId = null,
                        result = "failed",
                        response = 1000
                    };
                    return returnFalse;
                }
                
            }
        }

        public async static Task<CRAServiceOutModel> CRAServiceMatchingAsync(CARSERVICEMATCHINGMODEL cARSERVICEMATCHINGMODEL)
        {
            var URL = @"http://172.22.7.16:8280/Shahkar/1.4/serviceID-matching";
            string reqDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (HttpResponseMessage response = await APIClient.ApiClient.PostAsync(URL, CRAContentModelMaker.CRASERVICEIDMATCHINGMAKER(cARSERVICEMATCHINGMODEL)))
            {
                if (response.IsSuccessStatusCode)
                {
                    CRAServiceOutModel responseContent = await response.Content.ReadAsAsync<CRAServiceOutModel>();
                    stopWatch.Stop();
                    int ts = (int)stopWatch.ElapsedMilliseconds;
                    DBLOG dbInfo = new DBLOG()
                    {
                        elapsedTime = ts,
                        request = JsonConvert.SerializeObject(cARSERVICEMATCHINGMODEL),
                        response = JsonConvert.SerializeObject(responseContent),
                        requestTime = reqDate,
                        responseTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff"),
                        target = URL
                    };
                    DBConHellper.LogDBForAll(dbInfo);
                    return responseContent;
                }
                else
                {
                    stopWatch.Stop();
                    throw new Exception("no data found");
                }
            }
        }

        public async static Task<CRAMobileCountOutModel> CRAMobileCountAsync(MobileCountModel mobileCountModel)
        {
            var URL = @"http://172.22.7.16:8280/Shahkar/1.4/mobileCount";
            string reqDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (HttpResponseMessage response = await APIClient.ApiClient.PostAsync(URL, CRAContentModelMaker.CRAMobileCountMaker(mobileCountModel)))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                    CRAMobileCountOutModel responseContent = await response.Content.ReadAsAsync<CRAMobileCountOutModel>();
                    stopWatch.Stop();
                    int ts = (int)stopWatch.ElapsedMilliseconds;
                    DBLOG dbInfo = new DBLOG()
                    {
                        elapsedTime=ts,
                    request = JsonConvert.SerializeObject(mobileCountModel),
                    response = JsonConvert.SerializeObject(responseContent),
                    requestTime = reqDate,
                    responseTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff"),
                    target = URL
                    };
                    DBConHellper.LogDBForAll(dbInfo);
                    return responseContent;
                }
                else
                {
                    throw new Exception("no data found");
                    stopWatch.Stop();
                }
            }
        }
        public async static Task<CRACLOSEOUTMODEL> CRACloseAsync(CRACLOSEINPUTMODEL cRACLOSEINPUTMODEL)
        {
            var URL = @"http://172.22.7.16:8280/Shahkar/1.4/delete";

            using (HttpResponseMessage response = await APIClient.ApiClient.PostAsync(URL, CRAContentModelMaker.CRACLOSE(cRACLOSEINPUTMODEL)))
            {
                try
                {

                    CRACLOSEOUTMODEL responseContent = await response.Content.ReadAsAsync<CRACLOSEOUTMODEL>();
                    responseContent.servicenumber = cRACLOSEINPUTMODEL.serviceNumber;
                    return responseContent;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message,e.StackTrace);
                    var returnFalse = new CRACLOSEOUTMODEL()
                    {
                        comment = e.Message,
                        requestId = null,
                        result = null,
                        response = 1000,
                        id=null,
                        servicenumber = cRACLOSEINPUTMODEL.serviceNumber
                    };
                    return returnFalse;
                }

            }
        }

        public async static Task<CRAQueryResponseModel> CRAQueryAsync(CRAQueryInputModel cRAQueryInputModel)
        {
            string URL = @"http://172.22.7.16:8280/Shahkar/1.4/provider-enquiry";
            string reqDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using HttpResponseMessage response = await APIClient.ApiClient.PostAsync(URL, CRAContentModelMaker.CRAQuery(cRAQueryInputModel));

            try
            {
                
                CRAQueryResponseModel responseContent = await response.Content.ReadAsAsync<CRAQueryResponseModel>();
                stopWatch.Stop();
                int ts = (int)stopWatch.ElapsedMilliseconds;
                DBLOG dbInfo = new DBLOG()
                {
                    elapsedTime = ts,
                    request = JsonConvert.SerializeObject(cRAQueryInputModel),
                    response = JsonConvert.SerializeObject(responseContent),
                    requestTime = reqDate,
                    responseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssfff"),
                    target = URL
                };
                DBConHellper.LogDBForAll(dbInfo);
                responseContent.servicenumber = cRAQueryInputModel.serviceNumber;
                return responseContent;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.StackTrace);
                var returnFalse = new CRAQueryResponseModel()
                {
                    comment = e.Message,
                    requestId = null,
                    result = "failed",
                    response = 1000,
                    classifier = null,
                    providerName = null,
                    servicenumber = cRAQueryInputModel.serviceNumber
                };
                stopWatch.Stop();
                return returnFalse;
            }
        }
    }
}
