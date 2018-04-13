using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Storage.Entities;

namespace TodoApi.Storage.Repositories
{
    public interface IOLPRRRepository
    {
        Task<IEnumerable<ConfirmationType>> GetConfirmationTypes();
        Task<IEnumerable<County>> GetCounties();
        Task<IEnumerable<DiscoveryType>> GetDiscoveryTypes();
        Task<IEnumerable<QuadrantT>> GetQuadrants();
        Task<IEnumerable<ReleaseCauseType>> GetReleaseCauseTypes();
        Task<IEnumerable<SiteTypeT>> GetSiteTypes();
        Task<IEnumerable<SourceType>> GetSourceTypes();
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<StreetTypeT>> GetStreetTypes();
        Task<int> InsertOLPRRIncidentRecord(ApOLPRRInsertIncident apOLPRRInsertIncident);
    }
}

