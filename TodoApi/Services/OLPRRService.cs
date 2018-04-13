using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityDto = TodoApi.Storage.Entities;
using ApiDto = TodoApi.Models;
using TodoApi.Storage.Repositories;
using AutoMapper;
using TodoApi.Models.Request;
using Newtonsoft.Json;

namespace TodoApi.Services
{
    public class OLPRRService : IOLPRRService
    {
        private ILogger<OLPRRService> _logger;
        private IOLPRRRepository _lustRepository;
        private readonly IMapper _mapper;
        public OLPRRService(ILogger<OLPRRService> logger, IOLPRRRepository lustRepository, IMapper mapper)
        {
            _logger = logger;
            _lustRepository = lustRepository;
            _mapper = mapper;
        }



        //public async Task<int> InsertOLPRRIncidentRecord(ApOLPRRInsertIncident apOLPRRInsertIncident)
        public async Task<int> InsertOLPRRIncidentRecord(ApiDto.Request.ApOLPRRInsertIncident apOLPRRInsertIncident)
        {
            var incident = _mapper.Map<ApiDto.Request.ApOLPRRInsertIncident, EntityDto.ApOLPRRInsertIncident>(apOLPRRInsertIncident);
            var result = await _lustRepository.InsertOLPRRIncidentRecord(incident);
            return result;
        }

        private EntityDto.ApOLPRRInsertIncident BuildApOLPRRInsertIncident ()
        {
            return new EntityDto.ApOLPRRInsertIncident
            {
                ErrNum = 99,
                ContractorUid = "DENNIS",
                ContractorPwd = "TERZIAN",
                ReportedBy = "Reported By",
                ReportedByPhone = "9991118888",
                ReportedByEmail ="test@test.com",
                ReleaseType = "H",
                DateReceived = DateTime.Now,
                FacilityId = 0,
                SiteName = "sitename",
                SiteCounty = "Washington",
                StreetNbr = "9999",
                StreetQuad = "Portland",
                StreetName = "Portland",
                StreetType = "Portland",
                SiteAddress = "Portland",
                SiteCity = "Portland",
                SiteZipcode = "11133",
                SitePhone = "1112223333",
                InitialComment = "test comment",
                DiscoveryDate = DateTime.Now,
                ConfirmationCode = "OT",
                DiscoveryCode = "OT",
                CauseCode = "OT",
                SourceId = 6,
                RpFirstName = "PORTLAND",
                RpLastName = "PORTLAND",
                RpOrganization = "PORTLAND",
                RpAddress = "PORTLAND",
                RpAddress2 = "PORTLAND",
                RpCity = "PORTLAND",
                RpState = "OR",
                RpZipcode = "97070",
                RpPhone = "1112223333",
                RpEmail = "test@gmail.com",
                IcFirstName = "11",
                IcLastName = "11",
                IcOrganization = "11",
                IcAddress = "11",
                IcAddress2 = "11",
                IcCity = "11",
                IcState = "or",
                IcZipcode = "97070",
                IcPhone = "1111111111",
                IcEmail = "t@t.com",
                GroundWater = 1,
                SurfaceWater = 1,
                DringkingWater = 1,
                Soil = 1,
                Vapor = 1,
                FreeProduct = 0,
                UnleadedGas = 1,
                LeadedGas = 1,
                MisGas = 1,
                Diesel = 1,
                WasteOil = 1,
                HeatingOil = 1,
                Lubricant = 1,
                Solvent = 1,
                OtherPet = 0,
                Chemical = 0,
                Unknown = 0,
                Mtbe = 0,
                SubmitDateTime = DateTime.Now.ToLocalTime().ToString(),
                DeqOffice = "NWR"
            };
        }

        public async Task<IEnumerable<ConfirmationType>> GetConfirmationTypes()
        {
            IList<ApiDto.Request.ConfirmationType> resultList = new List<ApiDto.Request.ConfirmationType>();
            foreach (var result in await _lustRepository.GetConfirmationTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.ConfirmationType, ApiDto.Request.ConfirmationType>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<County>> GetCounties()
        {
            IList<ApiDto.Request.County> resultList = new List<ApiDto.Request.County>();
            foreach (var result in await _lustRepository.GetCounties())
            {
                resultList.Add(_mapper.Map<EntityDto.County, ApiDto.Request.County>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<DiscoveryType>> GetDiscoveryTypes()
        {
            IList<ApiDto.Request.DiscoveryType> resultList = new List<ApiDto.Request.DiscoveryType>();
            foreach (var result in await _lustRepository.GetDiscoveryTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.DiscoveryType, ApiDto.Request.DiscoveryType>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<QuadrantT>> GetQuadrants()
        {
            IList<ApiDto.Request.QuadrantT> resultList = new List<ApiDto.Request.QuadrantT>();
            foreach (var result in await _lustRepository.GetQuadrants())
            {
                resultList.Add(_mapper.Map<EntityDto.QuadrantT, ApiDto.Request.QuadrantT>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<ReleaseCauseType>> GetReleaseCauseTypes()
        {
            IList<ApiDto.Request.ReleaseCauseType> resultList = new List<ApiDto.Request.ReleaseCauseType>();
            foreach (var result in await _lustRepository.GetReleaseCauseTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.ReleaseCauseType, ApiDto.Request.ReleaseCauseType>(result));
            }
            return resultList;
        }
        public async Task<IEnumerable<ApiDto.Request.SiteTypeT>> GetSiteTypes()
        {
            IList<ApiDto.Request.SiteTypeT> resultList = new List<ApiDto.Request.SiteTypeT>();
            foreach (var result in await _lustRepository.GetSiteTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.SiteTypeT, ApiDto.Request.SiteTypeT>(result));
            }
            return resultList;
        }
        public async Task<IEnumerable<SourceType>> GetSourceTypes()
        {
            IList<ApiDto.Request.SourceType> resultList = new List<ApiDto.Request.SourceType>();
            foreach (var result in await _lustRepository.GetSourceTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.SourceType, ApiDto.Request.SourceType>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            IList<ApiDto.Request.State> resultList = new List<ApiDto.Request.State>();
            foreach (var result in await _lustRepository.GetStates())
            {
                resultList.Add(_mapper.Map<EntityDto.State, ApiDto.Request.State>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<StreetTypeT>> GetStreetTypes()
        {
            IList<ApiDto.Request.StreetTypeT> resultList = new List<ApiDto.Request.StreetTypeT>();
            foreach (var result in await _lustRepository.GetStreetTypes())
            {
                resultList.Add(_mapper.Map<EntityDto.StreetTypeT, ApiDto.Request.StreetTypeT>(result));
            }
            return resultList;
        }
    }
}
