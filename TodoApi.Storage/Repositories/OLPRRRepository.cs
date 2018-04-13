using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace TodoApi.Storage.Repositories
{
    public class OLPRRRepository : IOLPRRRepository
    {
        public const string ExecuteApGetOLPRRLookupTables = "execute dbo.apGetOLPRRLookupTables {0}";
        public const string ConfirmationTypeTable = "ConfirmationType";
        public const string CountiesTable = "Counties";
        public const string DiscoveryTypeTable = "DiscoveryType";
        public const string QuadrantTable = "Quadrant";
        public const string ReleaseCauseTypeTable = "ReleaseCauseType";
        public const string SiteTypeTable = "SiteType";
        public const string SourceTypeTable = "SourceType";
        public const string StatesTable = "States";
        public const string StreetTypeTable = "StreetType";

        private LustDbContext _dbContext;
        private ILogger<OLPRRRepository> _logger;
        public OLPRRRepository(ILogger<OLPRRRepository> logger, LustDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<ConfirmationType>> GetConfirmationTypes()
        {
            return await _dbContext.Set<ConfirmationType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ConfirmationTypeTable).ToListAsync();
        }

        public async Task<IEnumerable<County>> GetCounties()
        {
            return await _dbContext.Set<County>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, CountiesTable).ToListAsync();
        }

        public async Task<IEnumerable<DiscoveryType>> GetDiscoveryTypes()
        {
            return await _dbContext.Set<DiscoveryType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, DiscoveryTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<QuadrantT>> GetQuadrants()
        {
            return await _dbContext.Set<QuadrantT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, QuadrantTable).ToListAsync();
        }
        public async Task<IEnumerable<ReleaseCauseType>> GetReleaseCauseTypes()
        {
            return await _dbContext.Set<ReleaseCauseType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ReleaseCauseTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<SiteTypeT>> GetSiteTypes()
        {
            return await _dbContext.Set<SiteTypeT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, SiteTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<SourceType>> GetSourceTypes()
        {
            return await _dbContext.Set<SourceType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, SourceTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<State>> GetStates()
        {
            return await _dbContext.Set<State>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, StatesTable).ToListAsync();
        }
        public async Task<IEnumerable<StreetTypeT>> GetStreetTypes()
        {
            return await _dbContext.Set<StreetTypeT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, StreetTypeTable).ToListAsync();
        }
        public async Task<int> InsertOLPRRIncidentRecord(ApOLPRRInsertIncident apOLPRRInsertIncident)
        {
            var result = await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOLPRRInsertIncident " +
            "  @ErrNum ,@CONTRACTOR_UID, @CONTRACTOR_PWD, @REPORTED_BY, @REPORTED_BY_PHONE,  @REPORTED_BY_EMAIL, @RELEASE_TYPE, @DATE_RECEIVED,@FACILITY_ID, @SITE_NAME,@SITE_COUNTY" +
            ", @STREET_NBR, @STREET_QUAD,@STREET_NAME,@STREET_TYPE,@SITE_ADDRESS,@SITE_CITY,@SITE_ZIPCODE,@SITE_PHONE, @INITIAL_COMMENT, @DISCOVERY_DATE, @CONFIRMATION_CODE" +
            ", @DISCOVERY_CODE,@CAUSE_CODE,@SOURCEID,@RP_FIRSTNAME,@RP_LASTNAME,@RP_ORGANIZATION,@RP_ADDRESS,@RP_ADDRESS2,@RP_CITY,@RP_STATE,@RP_ZIPCODE,@RP_PHONE,@RP_EMAIL" +
            ", @IC_FIRSTNAME,@IC_LASTNAME,@IC_ORGANIZATION,@IC_ADDRESS,@IC_ADDRESS2,@IC_CITY,@IC_STATE,@IC_ZIPCODE,@IC_PHONE,@IC_EMAIL" +
            ", @GROUNDWATER,@SURFACEWATER,@DRINKINGWATER,@SOIL,@VAPOR,@FREEPRODUCT,@UNLEADEDGAS,@LEADEDGAS,@MISGAS,@DIESEL,@WASTEOIL,@HEATINGOIL,@LUBRICANT,@SOLVENT" +
            ", @OTHERPET,@CHEMICAL,@UNKNOWN,@MTBE,@SUBMIT_DATETIME,@DEQ_OFFICE", BuildSqlParams(apOLPRRInsertIncident));
            return result;
        }

        private IEnumerable<SqlParameter> BuildSqlParams (ApOLPRRInsertIncident apOLPRRInsertIncident)
        {
            IList<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter { ParameterName = "@ErrNum", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            list.Add(new SqlParameter("@CONTRACTOR_UID", apOLPRRInsertIncident.ContractorUid));
            list.Add(new SqlParameter("@CONTRACTOR_PWD", apOLPRRInsertIncident.ContractorPwd));
            list.Add(new SqlParameter("@REPORTED_BY", apOLPRRInsertIncident.ReportedBy));
            list.Add(new SqlParameter("@REPORTED_BY_PHONE", apOLPRRInsertIncident.ReportedByPhone));
            list.Add(new SqlParameter("@REPORTED_BY_EMAIL", apOLPRRInsertIncident.ReportedByEmail));
            list.Add(new SqlParameter("@RELEASE_TYPE", apOLPRRInsertIncident.ReleaseType));
            list.Add(new SqlParameter("@DATE_RECEIVED", apOLPRRInsertIncident.DateReceived));
            list.Add(new SqlParameter("@FACILITY_ID", apOLPRRInsertIncident.FacilityId));
            list.Add(new SqlParameter("@SITE_NAME", apOLPRRInsertIncident.SiteName));
            list.Add(new SqlParameter("@SITE_COUNTY", apOLPRRInsertIncident.SiteCounty));
            list.Add(new SqlParameter("@STREET_NBR", apOLPRRInsertIncident.StreetNbr));
            list.Add(new SqlParameter("@STREET_QUAD", apOLPRRInsertIncident.StreetQuad));
            list.Add(new SqlParameter("@STREET_NAME", apOLPRRInsertIncident.StreetName));
            list.Add(new SqlParameter("@STREET_TYPE", apOLPRRInsertIncident.StreetType));
            list.Add(new SqlParameter("@SITE_ADDRESS", apOLPRRInsertIncident.SiteAddress));
            list.Add(new SqlParameter("@SITE_CITY", apOLPRRInsertIncident.SiteCity));
            list.Add(new SqlParameter("@SITE_ZIPCODE", apOLPRRInsertIncident.SiteZipcode));
            list.Add(new SqlParameter("@SITE_PHONE", apOLPRRInsertIncident.SitePhone));
            list.Add(new SqlParameter("@INITIAL_COMMENT", apOLPRRInsertIncident.InitialComment));
            list.Add(new SqlParameter("@DISCOVERY_DATE", apOLPRRInsertIncident.DiscoveryDate));
            list.Add(new SqlParameter("@CONFIRMATION_CODE", apOLPRRInsertIncident.ConfirmationCode));
            list.Add(new SqlParameter("@DISCOVERY_CODE", apOLPRRInsertIncident.DiscoveryCode));
            list.Add(new SqlParameter("@CAUSE_CODE", apOLPRRInsertIncident.CauseCode));
            list.Add(new SqlParameter("@SOURCEID", apOLPRRInsertIncident.SourceId));
            list.Add(new SqlParameter("@RP_FIRSTNAME", apOLPRRInsertIncident.RpFirstName));
            list.Add(new SqlParameter("@RP_LASTNAME", apOLPRRInsertIncident.RpLastName));
            list.Add(new SqlParameter("@RP_ORGANIZATION", apOLPRRInsertIncident.RpOrganization));
            list.Add(new SqlParameter("@RP_ADDRESS", apOLPRRInsertIncident.RpAddress));
            list.Add(new SqlParameter("@RP_ADDRESS2", apOLPRRInsertIncident.RpAddress2));
            list.Add(new SqlParameter("@RP_CITY", apOLPRRInsertIncident.RpCity));
            list.Add(new SqlParameter("@RP_STATE", apOLPRRInsertIncident.RpState));
            list.Add(new SqlParameter("@RP_ZIPCODE", apOLPRRInsertIncident.RpZipcode));
            list.Add(new SqlParameter("@RP_PHONE", apOLPRRInsertIncident.RpPhone));
            list.Add(new SqlParameter("@RP_EMAIL", apOLPRRInsertIncident.RpEmail));
            list.Add(new SqlParameter("@IC_FIRSTNAME", apOLPRRInsertIncident.IcFirstName));
            list.Add(new SqlParameter("@IC_LASTNAME", apOLPRRInsertIncident.IcLastName));
            list.Add(new SqlParameter("@IC_ORGANIZATION", apOLPRRInsertIncident.IcOrganization));
            list.Add(new SqlParameter("@IC_ADDRESS", apOLPRRInsertIncident.IcAddress));
            list.Add(new SqlParameter("@IC_ADDRESS2", apOLPRRInsertIncident.IcAddress2));
            list.Add(new SqlParameter("@IC_CITY", apOLPRRInsertIncident.IcCity));
            list.Add(new SqlParameter("@IC_STATE", apOLPRRInsertIncident.IcState));
            list.Add(new SqlParameter("@IC_ZIPCODE", apOLPRRInsertIncident.IcZipcode));
            list.Add(new SqlParameter("@IC_PHONE", apOLPRRInsertIncident.IcPhone));
            list.Add(new SqlParameter("@IC_EMAIL", apOLPRRInsertIncident.IcEmail));
            list.Add(new SqlParameter("@GROUNDWATER", apOLPRRInsertIncident.GroundWater));
            list.Add(new SqlParameter("@SURFACEWATER", apOLPRRInsertIncident.SurfaceWater));
            list.Add(new SqlParameter("@DRINKINGWATER", apOLPRRInsertIncident.DringkingWater));
            list.Add(new SqlParameter("@SOIL", apOLPRRInsertIncident.Soil));
            list.Add(new SqlParameter("@VAPOR", apOLPRRInsertIncident.Vapor));
            list.Add(new SqlParameter("@FREEPRODUCT", apOLPRRInsertIncident.FreeProduct));
            list.Add(new SqlParameter("@UNLEADEDGAS", apOLPRRInsertIncident.UnleadedGas));
            list.Add(new SqlParameter("@LEADEDGAS", apOLPRRInsertIncident.LeadedGas));
            list.Add(new SqlParameter("@MISGAS", apOLPRRInsertIncident.MisGas));
            list.Add(new SqlParameter("@DIESEL", apOLPRRInsertIncident.Diesel));
            list.Add(new SqlParameter("@WASTEOIL", apOLPRRInsertIncident.WasteOil));
            list.Add(new SqlParameter("@HEATINGOIL", apOLPRRInsertIncident.HeatingOil));
            list.Add(new SqlParameter("@LUBRICANT", apOLPRRInsertIncident.Lubricant));
            list.Add(new SqlParameter("@SOLVENT", apOLPRRInsertIncident.Solvent));
            list.Add(new SqlParameter("@OTHERPET", apOLPRRInsertIncident.OtherPet));
            list.Add(new SqlParameter("@CHEMICAL", apOLPRRInsertIncident.Chemical));
            list.Add(new SqlParameter("@UNKNOWN", apOLPRRInsertIncident.Unknown));
            list.Add(new SqlParameter("@MTBE", apOLPRRInsertIncident.Mtbe));
            list.Add(new SqlParameter("@SUBMIT_DATETIME", apOLPRRInsertIncident.SubmitDateTime));
            list.Add(new SqlParameter("@DEQ_OFFICE", apOLPRRInsertIncident.DeqOffice));
            IEnumerable<SqlParameter> myParams = list;
            return myParams;
        }

        public async Task<int> InsertOLPRRIncidentRecord_SAVE1(ApOLPRRInsertIncident apOLPRRInsertIncident)
        {

            object[] parameters = {
                new SqlParameter
                {
                    ParameterName = "@ErrNum",
                    SqlDbType = SqlDbType.SmallInt,
                    Direction = ParameterDirection.Output
                }
            ,new SqlParameter ( "@CONTRACTOR_UID", apOLPRRInsertIncident.ContractorUid )
            ,new SqlParameter("@CONTRACTOR_PWD", apOLPRRInsertIncident.ContractorPwd)
            ,new SqlParameter("@REPORTED_BY", apOLPRRInsertIncident.ReportedBy)
            ,new SqlParameter("@REPORTED_BY_PHONE", apOLPRRInsertIncident.ReportedByPhone)
            ,new SqlParameter("@REPORTED_BY_EMAIL", apOLPRRInsertIncident.ReportedByEmail)
            ,new SqlParameter("@RELEASE_TYPE", apOLPRRInsertIncident.ReleaseType)
            ,new SqlParameter("@DATE_RECEIVED", apOLPRRInsertIncident.DateReceived)
            ,new SqlParameter("@FACILITY_ID", apOLPRRInsertIncident.FacilityId)
            ,new SqlParameter("@SITE_NAME", apOLPRRInsertIncident.SiteName)
            ,new SqlParameter("@SITE_COUNTY", apOLPRRInsertIncident.SiteCounty)
            ,new SqlParameter("@STREET_NBR", apOLPRRInsertIncident.StreetNbr)
            ,new SqlParameter("@STREET_QUAD", apOLPRRInsertIncident.StreetQuad)
            ,new SqlParameter("@STREET_NAME", apOLPRRInsertIncident.StreetName)
            ,new SqlParameter("@STREET_TYPE", apOLPRRInsertIncident.StreetType)
            ,new SqlParameter("@SITE_ADDRESS", apOLPRRInsertIncident.SiteAddress)
            ,new SqlParameter("@SITE_CITY", apOLPRRInsertIncident.SiteCity)
            ,new SqlParameter("@SITE_ZIPCODE", apOLPRRInsertIncident.SiteZipcode)
            ,new SqlParameter("@SITE_PHONE", apOLPRRInsertIncident.SitePhone)
            ,new SqlParameter("@INITIAL_COMMENT", apOLPRRInsertIncident.InitialComment)
            ,new SqlParameter("@DISCOVERY_DATE", apOLPRRInsertIncident.DiscoveryDate)
            ,new SqlParameter("@CONFIRMATION_CODE", apOLPRRInsertIncident.ConfirmationCode)
            ,new SqlParameter("@DISCOVERY_CODE", apOLPRRInsertIncident.DiscoveryCode)
            ,new SqlParameter("@CAUSE_CODE", apOLPRRInsertIncident.CauseCode)
            ,new SqlParameter("@SOURCEID", apOLPRRInsertIncident.SourceId)
            ,new SqlParameter("@RP_FIRSTNAME", apOLPRRInsertIncident.RpFirstName)
            ,new SqlParameter("@RP_LASTNAME", apOLPRRInsertIncident.RpLastName)
            ,new SqlParameter("@RP_ORGANIZATION", apOLPRRInsertIncident.RpOrganization)
            ,new SqlParameter("@RP_ADDRESS", apOLPRRInsertIncident.RpAddress)
            ,new SqlParameter("@RP_ADDRESS2", apOLPRRInsertIncident.RpAddress2)
            ,new SqlParameter("@RP_CITY", apOLPRRInsertIncident.RpCity)
            ,new SqlParameter("@RP_STATE", apOLPRRInsertIncident.RpState)
            ,new SqlParameter("@RP_ZIPCODE", apOLPRRInsertIncident.RpZipcode)
            ,new SqlParameter("@RP_PHONE", apOLPRRInsertIncident.RpPhone)
            ,new SqlParameter("@RP_EMAIL", apOLPRRInsertIncident.RpEmail)
            ,new SqlParameter("@IC_FIRSTNAME", apOLPRRInsertIncident.IcFirstName)
            ,new SqlParameter("@IC_LASTNAME", apOLPRRInsertIncident.IcLastName)
            ,new SqlParameter("@IC_ORGANIZATION", apOLPRRInsertIncident.IcOrganization)
            ,new SqlParameter("@IC_ADDRESS", apOLPRRInsertIncident.IcAddress)
            ,new SqlParameter("@IC_ADDRESS2", apOLPRRInsertIncident.IcAddress2)
            ,new SqlParameter("@IC_CITY", apOLPRRInsertIncident.IcCity)
            ,new SqlParameter("@IC_STATE", apOLPRRInsertIncident.IcState)
            ,new SqlParameter("@IC_ZIPCODE", apOLPRRInsertIncident.IcZipcode)
            ,new SqlParameter("@IC_PHONE", apOLPRRInsertIncident.IcPhone)
            ,new SqlParameter("@IC_EMAIL", apOLPRRInsertIncident.IcEmail)
            ,new SqlParameter("@GROUNDWATER", apOLPRRInsertIncident.GroundWater)
            ,new SqlParameter("@SURFACEWATER", apOLPRRInsertIncident.SurfaceWater)
            ,new SqlParameter("@DRINKINGWATER", apOLPRRInsertIncident.DringkingWater)
            ,new SqlParameter("@SOIL", apOLPRRInsertIncident.Soil)
            ,new SqlParameter("@VAPOR", apOLPRRInsertIncident.Vapor)
            ,new SqlParameter("@FREEPRODUCT", apOLPRRInsertIncident.FreeProduct)
            ,new SqlParameter("@UNLEADEDGAS", apOLPRRInsertIncident.UnleadedGas)
            ,new SqlParameter("@LEADEDGAS", apOLPRRInsertIncident.LeadedGas)
            ,new SqlParameter("@MISGAS", apOLPRRInsertIncident.MisGas)
            ,new SqlParameter("@DIESEL", apOLPRRInsertIncident.Diesel)
            ,new SqlParameter("@WASTEOIL", apOLPRRInsertIncident.WasteOil)
            ,new SqlParameter("@HEATINGOIL", apOLPRRInsertIncident.HeatingOil)
            ,new SqlParameter("@LUBRICANT", apOLPRRInsertIncident.Lubricant)
            ,new SqlParameter("@SOLVENT", apOLPRRInsertIncident.Solvent)
            ,new SqlParameter("@OTHERPET", apOLPRRInsertIncident.OtherPet)
            ,new SqlParameter("@CHEMICAL", apOLPRRInsertIncident.Chemical)
            ,new SqlParameter("@UNKNOWN", apOLPRRInsertIncident.Unknown)
            ,new SqlParameter("@MTBE", apOLPRRInsertIncident.Mtbe)
            ,new SqlParameter("@SUBMIT_DATETIME", apOLPRRInsertIncident.SubmitDateTime)
            ,new SqlParameter("@DEQ_OFFICE", apOLPRRInsertIncident.DeqOffice)
            };
            var pErrNum = new SqlParameter
            {
                ParameterName = "@ErrNum",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Output
                //SqlValue = 0
                //Value = 0
            }
            ;
            var pContractorUid = new SqlParameter("@CONTRACTOR_UID", apOLPRRInsertIncident.ContractorUid);
            var pContractorPwd = new SqlParameter("@CONTRACTOR_PWD", apOLPRRInsertIncident.ContractorPwd);
            var pReportedBy = new SqlParameter("@REPORTED_BY", apOLPRRInsertIncident.ReportedBy);
            var pReportedByPhone = new SqlParameter("@REPORTED_BY_PHONE", apOLPRRInsertIncident.ReportedByPhone);
            var pReportedByEmail = new SqlParameter("@REPORTED_BY_EMAIL", apOLPRRInsertIncident.ReportedByEmail);
            var pReleaseType = new SqlParameter("@RELEASE_TYPE", apOLPRRInsertIncident.ReleaseType);
            var pDateReceived = new SqlParameter("@DATE_RECEIVED", apOLPRRInsertIncident.DateReceived);
            var pFacilityId = new SqlParameter("@FACILITY_ID", apOLPRRInsertIncident.FacilityId);
            var pSiteName = new SqlParameter("@SITE_NAME", apOLPRRInsertIncident.SiteName);
            var pSiteCounty = new SqlParameter("@SITE_COUNTY", apOLPRRInsertIncident.SiteCounty);
            var pStreetNbr = new SqlParameter("@STREET_NBR", apOLPRRInsertIncident.StreetNbr);
            var pStreetQuad = new SqlParameter("@STREET_QUAD", apOLPRRInsertIncident.StreetQuad);
            var pStreetName = new SqlParameter("@STREET_NAME", apOLPRRInsertIncident.StreetName);
            var pStreetType = new SqlParameter("@STREET_TYPE", apOLPRRInsertIncident.StreetType);
            var pSiteAddress = new SqlParameter("@SITE_ADDRESS", apOLPRRInsertIncident.SiteAddress);
            var pSiteCity = new SqlParameter("@SITE_CITY", apOLPRRInsertIncident.SiteCity);
            var pSiteZipcode = new SqlParameter("@SITE_ZIPCODE", apOLPRRInsertIncident.SiteZipcode);
            var pSitePhone = new SqlParameter("@SITE_PHONE", apOLPRRInsertIncident.SitePhone);
            var pInitialComment = new SqlParameter("@INITIAL_COMMENT", apOLPRRInsertIncident.InitialComment);
            var pDiscoveryDate = new SqlParameter("@DISCOVERY_DATE", apOLPRRInsertIncident.DiscoveryDate);
            var pConfirmationCode = new SqlParameter("@CONFIRMATION_CODE", apOLPRRInsertIncident.ConfirmationCode);
            var pDiscoveryCode = new SqlParameter("@DISCOVERY_CODE", apOLPRRInsertIncident.DiscoveryCode);
            var pCauseCode = new SqlParameter("@CAUSE_CODE", apOLPRRInsertIncident.CauseCode);
            var pSourceId = new SqlParameter("@SOURCEID", apOLPRRInsertIncident.SourceId);


            var pRpFirstName = new SqlParameter("@RP_FIRSTNAME", apOLPRRInsertIncident.RpFirstName);
            var pRpLastName = new SqlParameter("@RP_LASTNAME", apOLPRRInsertIncident.RpLastName);
            var pRpOrganization = new SqlParameter("@RP_ORGANIZATION", apOLPRRInsertIncident.RpOrganization);
            var pRpAddress = new SqlParameter("@RP_ADDRESS", apOLPRRInsertIncident.RpAddress);
            var pRpAddress2 = new SqlParameter("@RP_ADDRESS2", apOLPRRInsertIncident.RpAddress2);
            var pRpCity = new SqlParameter("@RP_CITY", apOLPRRInsertIncident.RpCity);
            var pRpState = new SqlParameter("@RP_STATE", apOLPRRInsertIncident.RpState);
            var pRpZipcode = new SqlParameter("@RP_ZIPCODE", apOLPRRInsertIncident.RpZipcode);
            var pRpPhone = new SqlParameter("@RP_PHONE", apOLPRRInsertIncident.RpPhone);
            var pRpEmail = new SqlParameter("@RP_EMAIL", apOLPRRInsertIncident.RpEmail);
            var pIcFirstName = new SqlParameter("@IC_FIRSTNAME", apOLPRRInsertIncident.IcFirstName);
            var pIcLastName = new SqlParameter("@IC_LASTNAME", apOLPRRInsertIncident.IcLastName);
            var pIcOrganization = new SqlParameter("@IC_ORGANIZATION", apOLPRRInsertIncident.IcOrganization);
            var pIcAddress = new SqlParameter("@IC_ADDRESS", apOLPRRInsertIncident.IcAddress);
            var pIcAddress2 = new SqlParameter("@IC_ADDRESS2", apOLPRRInsertIncident.IcAddress2);
            var pIcCity = new SqlParameter("@IC_CITY", apOLPRRInsertIncident.IcCity);
            var pIcState = new SqlParameter("@IC_STATE", apOLPRRInsertIncident.IcState);
            var pIcZipcode = new SqlParameter("@IC_ZIPCODE", apOLPRRInsertIncident.IcZipcode);
            var pIcPhone = new SqlParameter("@IC_PHONE", apOLPRRInsertIncident.IcPhone);
            var pIcEmail = new SqlParameter("@IC_EMAIL", apOLPRRInsertIncident.IcEmail);
            var pGroundWater = new SqlParameter("@GROUNDWATER", apOLPRRInsertIncident.GroundWater);
            var pSurfaceWater = new SqlParameter("@SURFACEWATER", apOLPRRInsertIncident.SurfaceWater);
            var pDringkingWater = new SqlParameter("@DRINKINGWATER", apOLPRRInsertIncident.DringkingWater);
            var pSoil = new SqlParameter("@SOIL", apOLPRRInsertIncident.Soil);
            var pVapor = new SqlParameter("@VAPOR", apOLPRRInsertIncident.Vapor);
            var pFreeProduct = new SqlParameter("@FREEPRODUCT", apOLPRRInsertIncident.FreeProduct);
            var pUnleadedGas = new SqlParameter("@UNLEADEDGAS", apOLPRRInsertIncident.UnleadedGas);
            var pLeadedGas = new SqlParameter("@LEADEDGAS", apOLPRRInsertIncident.LeadedGas);
            var pMisGas = new SqlParameter("@MISGAS", apOLPRRInsertIncident.MisGas);
            var pDiesel = new SqlParameter("@DIESEL", apOLPRRInsertIncident.Diesel);
            var pWasteOil = new SqlParameter("@WASTEOIL", apOLPRRInsertIncident.WasteOil);
            var pHeatingOil = new SqlParameter("@HEATINGOIL", apOLPRRInsertIncident.HeatingOil);
            var pLubricant = new SqlParameter("@LUBRICANT", apOLPRRInsertIncident.Lubricant);
            var pSolvent = new SqlParameter("@SOLVENT", apOLPRRInsertIncident.Solvent);
            var pOtherPet = new SqlParameter("@OTHERPET", apOLPRRInsertIncident.OtherPet);
            var pChemical = new SqlParameter("@CHEMICAL", apOLPRRInsertIncident.Chemical);
            var pUnknown = new SqlParameter("@UNKNOWN", apOLPRRInsertIncident.Unknown);
            var pMtbe = new SqlParameter("@MTBE", apOLPRRInsertIncident.Mtbe);
            var pSubmitDateTime = new SqlParameter("@SUBMIT_DATETIME", apOLPRRInsertIncident.SubmitDateTime);
            var pDeqOffice = new SqlParameter("@DEQ_OFFICE", apOLPRRInsertIncident.DeqOffice);

            //var result = await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOLPRRInsertIncident {0} @ErrNum OUTPUT", apOLPRRInsertIncident, outParameter);

            //var result = await _dbContext.Set<OutParam>().AsNoTracking().FromSql("execute dbo.apOLPRRInsertIncident  @CONTRACTOR_UID ",  pContractorUid).FirstOrDefaultAsync();

            //var result = await _dbContext.Set<OutParam>().AsNoTracking().FromSql("execute dbo.apOLPRRInsertIncident @ErrNum OUTPUT, @CONTRACTOR_UID, @CONTRACTOR_PWD, @ "
            //        , outParameter, pContractorUid).FirstOrDefaultAsync();

            //var result = await _dbContext.Set<OutParam>().AsNoTracking().FromSql("execute dbo.apOLPRRInsertIncident " +
            //    "  @ErrNum OUTPUT, @CONTRACTOR_UID, @CONTRACTOR_PWD, @REPORTED_BY, @REPORTED_BY_PHONE,  @REPORTED_BY_EMAIL, @RELEASE_TYPE, @DATE_RECEIVED,@FACILITY_ID, @SITE_NAME,@SITE_COUNTY" +
            //    ", @STREET_NBR, @STREET_QUAD,@STREET_NAME,@STREET_TYPE,@SITE_ADDRESS,@SITE_CITY,@SITE_ZIPCODE,@SITE_PHONE, @INITIAL_COMMENT, @DISCOVERY_DATE, @CONFIRMATION_CODE" +
            //    ", @DISCOVERY_CODE,@CAUSE_CODE,@SOURCEID,@RP_FIRSTNAME,@RP_LASTNAME,@RP_ORGANIZATION,@RP_ADDRESS,@RP_CITY,@RP_STATE,@RP_ZIPCODE,@RP_PHONE,@RP_EMAIL" +
            //    ", @IC_FIRSTNAME,@IC_LASTNAME,@IC_ORGANIZATION,@IC_ADDRESS,@IC_CITY,@IC_STATE,@IC_ZIPCODE,@IC_PHONE,@IC_EMAIL" +
            //    ", @GROUNDWATER,@SURFACEWATER,@DRINKINGWATER,@SOIL,@VAPOR,@FREEPRODUCT,@UNLEADEDGAS,@LEADEDGAS,@MISGAS,@DIESEL,@WASTEOIL,@HEATINGOIL,@LUBRICANT,@SOLVENT" +
            //    ", @OTHERPET,@CHEMICAL,@UNKNOWN,@MTBE,@SUBMIT_DATETIME,@DEQ_OFFICE"
            //, outParameter, pContractorUid, pContractorPwd, pReportedBy, pReportedByPhone, pReportedByEmail, pReleaseType, pDateReceived, pFacilityId, pSiteName, pSiteCounty
            //, pStreetNbr , pStreetQuad, pStreetName, pStreetType, pSiteAddress, pSiteCity, pSiteZipcode, pSitePhone, pInitialComment, pDiscoveryDate, pConfirmationCode
            //, pDiscoveryCode, pCauseCode, pSourceId, pRpFirstName, pRpLastName, pRpOrganization, pRpAddress, pRpAddress2, pRpCity, pRpState, pRpZipcode, pRpPhone, pRpEmail
            //, pIcFirstName, pIcLastName, pIcOrganization, pIcAddress, pIcAddress2, pIcCity, pIcState, pIcZipcode, pIcPhone, pIcEmail
            //, pGroundWater, pSurfaceWater, pDringkingWater, pSoil, pVapor, pFreeProduct, pUnleadedGas, pLeadedGas, pMisGas, pDiesel, pWasteOil, pHeatingOil, pLubricant, pSolvent
            //, pOtherPet, pChemical, pUnknown, pMtbe, pSubmitDateTime, pDeqOffice).FirstOrDefaultAsync();


            var result = await _dbContext.Set<OutParam>().AsNoTracking().FromSql("execute dbo.apOLPRRInsertIncident " +
                        "  @ErrNum,  @CONTRACTOR_UID, @CONTRACTOR_PWD, @REPORTED_BY, @REPORTED_BY_PHONE,  @REPORTED_BY_EMAIL, @RELEASE_TYPE, @DATE_RECEIVED,@FACILITY_ID, @SITE_NAME,@SITE_COUNTY" +
                        ", @STREET_NBR, @STREET_QUAD,@STREET_NAME,@STREET_TYPE,@SITE_ADDRESS,@SITE_CITY,@SITE_ZIPCODE,@SITE_PHONE, @INITIAL_COMMENT, @DISCOVERY_DATE, @CONFIRMATION_CODE" +
                        ", @DISCOVERY_CODE,@CAUSE_CODE,@SOURCEID,@RP_FIRSTNAME,@RP_LASTNAME,@RP_ORGANIZATION,@RP_ADDRESS,@RP_ADDRESS2,@RP_CITY,@RP_STATE,@RP_ZIPCODE,@RP_PHONE,@RP_EMAIL" +
                        ", @IC_FIRSTNAME,@IC_LASTNAME,@IC_ORGANIZATION,@IC_ADDRESS,@IC_ADDRESS2,@IC_CITY,@IC_STATE,@IC_ZIPCODE,@IC_PHONE,@IC_EMAIL" +
                        ", @GROUNDWATER,@SURFACEWATER,@DRINKINGWATER,@SOIL,@VAPOR,@FREEPRODUCT,@UNLEADEDGAS,@LEADEDGAS,@MISGAS,@DIESEL,@WASTEOIL,@HEATINGOIL,@LUBRICANT,@SOLVENT" +
                        ", @OTHERPET,@CHEMICAL,@UNKNOWN,@MTBE,@SUBMIT_DATETIME,@DEQ_OFFICE"
                    , pErrNum, pContractorUid, pContractorPwd, pReportedBy, pReportedByPhone, pReportedByEmail, pReleaseType, pDateReceived, pFacilityId, pSiteName, pSiteCounty
                    , pStreetNbr, pStreetQuad, pStreetName, pStreetType, pSiteAddress, pSiteCity, pSiteZipcode, pSitePhone, pInitialComment, pDiscoveryDate, pConfirmationCode
                    , pDiscoveryCode, pCauseCode, pSourceId, pRpFirstName, pRpLastName, pRpOrganization, pRpAddress, pRpAddress2, pRpCity, pRpState, pRpZipcode, pRpPhone, pRpEmail
                    , pIcFirstName, pIcLastName, pIcOrganization, pIcAddress, pIcAddress2, pIcCity, pIcState, pIcZipcode, pIcPhone, pIcEmail
                    , pGroundWater, pSurfaceWater, pDringkingWater, pSoil, pVapor, pFreeProduct, pUnleadedGas, pLeadedGas, pMisGas, pDiesel, pWasteOil, pHeatingOil, pLubricant, pSolvent
                    , pOtherPet, pChemical, pUnknown, pMtbe, pSubmitDateTime, pDeqOffice).FirstOrDefaultAsync();


            //int test = 0;
            //var result = await _dbContext.Set<OutParam>().AsNoTracking().FromSql($"execute dbo.apOLPRRInsertIncident " +
            //"  {'0'} ,  {apOLPRRInsertIncident.ContractorUid}, {apOLPRRInsertIncident.ContractorPwd}, {apOLPRRInsertIncident.ReportedBy},  {apOLPRRInsertIncident.ReportedByEmail},{apOLPRRInsertIncident.ReleaseType}, {apOLPRRInsertIncident.DateReceived},{apOLPRRInsertIncident.FacilityId}, {apOLPRRInsertIncident.SiteName},{apOLPRRInsertIncident.SiteCounty}" +
            //", {apOLPRRInsertIncident.StreetNbr}, {apOLPRRInsertIncident.StreetQuad},{apOLPRRInsertIncident.StreetName},{apOLPRRInsertIncident.StreetType},{apOLPRRInsertIncident.SiteAddress},{apOLPRRInsertIncident.SiteCity},{apOLPRRInsertIncident.SiteZipcode},{apOLPRRInsertIncident.SitePhone}, {apOLPRRInsertIncident.InitialComment},{ apOLPRRInsertIncident.DiscoveryDate},{ apOLPRRInsertIncident.ConfirmationCode)" +
            //", {apOLPRRInsertIncident.DiscoveryCode},{apOLPRRInsertIncident.CauseCode},{apOLPRRInsertIncident.SourceId},{apOLPRRInsertIncident.RpFirstName},{apOLPRRInsertIncident.RpLastName},{apOLPRRInsertIncident.RpOrganization},{apOLPRRInsertIncident.RpAddress},{apOLPRRInsertIncident.RpCity},{apOLPRRInsertIncident.RpState},{apOLPRRInsertIncident.RpZipcode},{apOLPRRInsertIncident.RpPhone},{apOLPRRInsertIncident.RpEmail}" +
            //", {apOLPRRInsertIncident.IcFirstName},{apOLPRRInsertIncident.IcLastName},{apOLPRRInsertIncident.IcOrganization},{apOLPRRInsertIncident.IcAddress},{apOLPRRInsertIncident.IcAddress2},{apOLPRRInsertIncident.IcCity},{apOLPRRInsertIncident.IcState},{apOLPRRInsertIncident.IcZipcode},{apOLPRRInsertIncident.IcPhone},{apOLPRRInsertIncident.IcEmail}" +
            //", {apOLPRRInsertIncident.GroundWater},{apOLPRRInsertIncident.SurfaceWater},{apOLPRRInsertIncident.DringkingWater},{apOLPRRInsertIncident.Soil},{apOLPRRInsertIncident.Vapor},{apOLPRRInsertIncident.FreeProduct},{apOLPRRInsertIncident.UnleadedGas},{apOLPRRInsertIncident.LeadedGas},{apOLPRRInsertIncident.MisGas},{apOLPRRInsertIncident.Diesel},{apOLPRRInsertIncident.WasteOil},{apOLPRRInsertIncident.HeatingOil},{apOLPRRInsertIncident.Lubricant},{apOLPRRInsertIncident.Solvent}" +
            //", [apOLPRRInsertIncident.OtherPet},{apOLPRRInsertIncident.Chemical},{apOLPRRInsertIncident.Unknown},{apOLPRRInsertIncident.Mtbe},{apOLPRRInsertIncident.SubmitDateTime},{apOLPRRInsertIncident.DeqOffice").FirstOrDefaultAsync();

            return 1;
        }
        public async Task<int> GetSiteTypes_SAVE(string name)
        {

            //name = "SiteTypeT";
            //var result = await _dbContext.Set<LookupThreeCols>().FromSql("execute dbo.apGetOLPRRLookupTables {0}", name).ToListAsync();

            var outParameter = new SqlParameter("@outParameter", value: DbType.Int16)
            {
                Direction = ParameterDirection.Output
            };

            name = "SiteTypeT";
            var result = await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOLPRRInsertIncident @outParameter OUT", outParameter);

            return result;
        }

    }
}
