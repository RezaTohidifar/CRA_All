using DataLib;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRA_Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            APIClient.ApiHelper();
            URLDictionary.URLMETHOD();
            //CRAServiceOutModel x =await ApiCaller.CRAServiceMatchingAsync("9214011472");
            //CRAMobileCountOutModel y = await ApiCaller.CRAMobileCountAsync("3240570327");
            //Console.WriteLine( x.result);
            //Console.WriteLine(y.result);
            /* var listOfPutModel = DBConHellper.QueryCustomerInfo();
             foreach (var singleRow in listOfPutModel)
             {
                CRAPUTOUTMODEL putResponse =await ApiCaller.CRRPutCaller(singleRow);
                 string putResponseJson= JsonConvert.SerializeObject(putResponse);
                 Console.WriteLine(putResponseJson);
             } */
            /* var close = new CRACLOSEINPUTMODEL()
             {
                 id = "tw_VAEQOp7riqioo6D9Dec-tvHjlKDtebqTt9QgK0GM",
                 requestId = CRASEQUENCE.SeqIDGenerator(),
                 serviceNumber = "09200400200",
                 resellerCode = "41"
             };

             var closeResponse = await ApiCaller.CRACloseAsync(close);
             string closeResponseJson = JsonConvert.SerializeObject(closeResponse); */
            /*var close = new CRACLOSEINPUTMODEL()
            {
                serviceNumber = "09210411472",
                id = "13513",
                resellerCode = "41",
                requestId = CRASEQUENCE.SeqIDGenerator()
             };
            DBConHellper.InsertCloseRequestToDB(close);
             var queryResponse = await ApiCaller.CRACloseAsync(close);
             DBConHellper.InsertCloseResponseToDB(queryResponse);
            /*var x = new ServiceNumber();
            DBConHellper.InsertDataToPRC(x); */

            ////var x =DBConHellper.QueryCustomerInfo();
            ////foreach (var item in x)
            ////{
            ////   var y = await ApiCaller.CRRPutCaller(item);
            ////    DBConHellper.InsertPutResponseToDB(y);
            ////}
            var x = new CRAQueryInputModel()
            {
                serviceNumber = "09209201551"
            };
            Console.WriteLine(URLDictionary.AllURL);
            var url =URLDictionary.AllURL.GetValueOrDefault("Query");
            var t =await ApiCallerGeneric.CRACallerGenericAsync<CRAQueryInputModel,CRAQueryResponseModel>(x, url);
            Console.WriteLine(t.classifier);
        }
    }
}
