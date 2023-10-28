using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using Newtonsoft.Json;

namespace APIForCRA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CRAController : ControllerBase
    {
        
        private readonly ILogger<CRAController> _logger;

        public CRAController(ILogger<CRAController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("queryCRA")]
        public async Task<CRAQueryResponseModel> CRAQueryAsyncPost(QueryService queryService)
        {
            CRAQueryInputModel queryData = new() { 
            serviceNumber = "0"+queryService.serviceNumber,
            requestId = CRASEQUENCE.SeqIDGenerator(),
            serviceType = "2"
            };
            var output = await ApiCallerGeneric.CRACallerGenericAsync<CRAQueryInputModel, CRAQueryResponseModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("Query"));
            return output;

        }

        [HttpPost]
        [Route("mobileCount")]
        public async Task<CRAMobileCountOutModel> CRAMobileCountAsyncPost(MobileCount data)
        {
            MobileCountModel queryData = new()
            {
                identificationNo = data.identificationNo,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                identificationType = data.identificationType
            };
            var output = await ApiCallerGeneric.CRACallerGenericAsync<MobileCountModel, CRAMobileCountOutModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("MobileCount"));
            return output;
        }

        [HttpPost]
        [Route("serviceMatching")]
        public async Task<CRAServiceOutModel> CRAServiceMatchingAsyncPost(ServiceMatchingModel data)
        {
            CARSERVICEMATCHINGMODEL queryData = new()
            {
                identificationNo = data.identificationNo,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                identificationType = data.identificationType,
                serviceNumber = "0" + data.serviceNumber
            };
            var output = await ApiCallerGeneric.CRACallerGenericAsync<CARSERVICEMATCHINGMODEL, CRAServiceOutModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("Matching"));
            return output;
        }
    }
}
