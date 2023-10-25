using DataLib.RequestModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class CRAContentModelMaker
    {
        public static HttpContent CRAPUTMAKER(CRAPUTMODEL cRAPUTMODEL)
        {

            var jsonpayload = JsonConvert.SerializeObject(cRAPUTMODEL);
            
            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }

        public static HttpContent CRAdataGeneric<T>(T inputModel) where T : class,new()
        {
            //var data = new T();
            var jsonpayload = JsonConvert.SerializeObject(inputModel);

            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }

        public static HttpContent CRACLOSE(CRACLOSEINPUTMODEL cRACLOSEINPUTMODEL)
        {

            var jsonpayload = JsonConvert.SerializeObject(cRACLOSEINPUTMODEL);

            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }

        public static HttpContent CRAQuery(CRAQueryInputModel cRAQueryInputModel)
        {

            var jsonpayload = JsonConvert.SerializeObject(cRAQueryInputModel);

            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }

        /* public static HttpContent CRASERVICEIDMATCHINGMAKER(string MSISDN)
        {
            var payload = new
            {
                requestId = /*cARSERVICEMATCHINGMODEL.requestId  CRASEQUENCE.SeqIDGenerator(),
                serviceType = 2,
                serviceNumber = '0'+ MSISDN,
                identificationNo="3240570327",
                identificationType = 0
            };
            var jsonpayload = JsonConvert.SerializeObject(payload);
            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        } */

        /*  public static HttpContent CRAMobileCountMaker(string certId)
        {
            var payload = new
            {
                requestId = /*cARSERVICEMATCHINGMODEL.requestId   CRASEQUENCE.SeqIDGenerator(),
                identificationNo = certId,
                identificationType = 0
            };
            var jsonpayload = JsonConvert.SerializeObject(payload);
            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        } */

        public static HttpContent CRAMobileCountMaker(MobileCountModel mobileCountModel)
        {

            var jsonpayload = JsonConvert.SerializeObject(mobileCountModel);

            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }

        public static HttpContent CRASERVICEIDMATCHINGMAKER(CARSERVICEMATCHINGMODEL cARSERVICEMATCHINGMODEL)
        {
            var jsonpayload = JsonConvert.SerializeObject(cARSERVICEMATCHINGMODEL);
            HttpContent Output = new StringContent(jsonpayload, Encoding.UTF8, "application/json");
            return Output;
        }
    }
}
