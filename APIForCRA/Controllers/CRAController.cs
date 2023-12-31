﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using DataLib.RequestModel;
using DataLib.ResponseModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace APIForCRA.Controllers
{
    [RequireHttps]
    [ApiController]
    [Route("[controller]")]
    public class CRAController : ControllerBase
    {
        private readonly IApiCallerGeneric _API;
        private readonly ILogger<CRAController> _logger;

        public CRAController(ILogger<CRAController> logger, IApiCallerGeneric API)
        {
            _logger = logger;
            _API = API;
        }

        [HttpPost]
        [Route("queryCRA")]
        public async Task<CRAQueryResponseModel> CRAQueryAsyncPost(QueryServiceModel queryService)
        {
            CRAQueryInputModel queryData = new()
            {
                serviceNumber = "0" + queryService.serviceNum,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                serviceType = "2"
            };
            var output = await _API.CRACallerGenericAsync<CRAQueryInputModel, CRAQueryResponseModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("Query"));
            return output;

        }

        [HttpPost]
        [Route("mobileCount")]
        public async Task<CRAMobileCountOutModel> CRAMobileCountAsyncPost(MobileCountModel data)
        {
            DataLib.MobileCountModel queryData = new()
            {
                identificationNo = data.identificationNom,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                identificationType = data.idType
            };
            var output = await _API.CRACallerGenericAsync<DataLib.MobileCountModel, CRAMobileCountOutModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("MobileCount"));
            return output;
        }

        [HttpPost]
        [Route("serviceMatching")]
        public async Task<CRAServiceOutModel> CRAServiceMatchingAsyncPost(ServiceMatchingM data)
        {
            if (data.idType == null)
            {
                data.idType = 0;
            }
            CARSERVICEMATCHINGMODEL queryData = new()
            {
                identificationNo = data.identificationNom,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                identificationType = data.idType,
                serviceNumber = "0" + data.serviceNum
            };
            var output = await _API.CRACallerGenericAsync<CARSERVICEMATCHINGMODEL, CRAServiceOutModel>(queryData, URLDictionary.AllURL.GetValueOrDefault("Matching"));
            return output;
        }

        [HttpPost]
        [Route("deleteCRA")]
        public async Task<CRACLOSEOUTMODEL> CRADeleteAsyncPost(CRADelete data)
        {
            CRACLOSEINPUTMODEL queryData = new()
            {
                id = data.id,
                requestId = CRASEQUENCE.SeqIDGenerator(),
                serviceNumber = "0" + data.serviceNumber
            };
            var output = await _API.CRACallerGenericAsync<CRACLOSEINPUTMODEL, CRACLOSEOUTMODEL>(queryData, URLDictionary.AllURL.GetValueOrDefault("Close"));
            return output;
        }

        [HttpPost]
        [Route("putCRA")]
        public async Task<CRAPUTOUTMODEL> CRAPutAsyncPost(CRAPut data)
        {
            CRAPUTMODEL queryData = new()
            {
                requestId = CRASEQUENCE.SeqIDGenerator(),
                resellerCode = "41",
                identificationType = data.identificationType,
                identificationNo = data.identificationNo,
                certificateNo = data.certificateNo,
                birthDate = data.birthDate,
                name = data.name,
                family = data.family,
                fatherName = data.fatherName,
                gender = data.gender,
                birthPlace = data.birthPlace,
                mobile = data.mobile,
                email = data.email,
                person = data.person,
                iranian = data.iranian,
                isUnderLegalAge = data.isUnderLegalAge,
                address = new Address()
                {
                    provinceName = data.address.provinceName,
                    townshipName = data.address.townshipName,
                    address = data.address.address,
                    street2 = data.address.street2,
                    houseNumber = data.address.houseNumber,
                    postalCode = data.address.postalCode,
                    tel = data.address.tel
                },
                service = new Service()
                {
                    type = data.service.type,
                    mobileNumber = data.service.mobileNumber,
                    mobileType = data.service.mobileType,
                    dataSim = data.service.dataSim,
                    serial = data.service.serial,
                    sms = data.service.sms,
                    gprs = data.service.gprs,
                    mms = data.service.mms,
                    wap = data.service.wap,
                    threeG = data.service.threeG,
                    fourG = data.service.fourG,
                    videoCall = data.service.videoCall,
                    ipStatic = data.service.ipStatic,
                    province = data.service.province,
                    networkName = data.service.networkName,
                    apn = data.service.apn,
                    privateNumber = data.service.privateNumber,
                    privateNumberDetection = data.service.privateNumberDetection
                }
            };
            var output = await _API.CRACallerGenericAsync<CRAPUTMODEL, CRAPUTOUTMODEL>(queryData, URLDictionary.AllURL.GetValueOrDefault("Put"));
            return output;
        }
    }
}
