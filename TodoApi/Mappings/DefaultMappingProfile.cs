using AutoMapper;
using TodoApi.Models;

namespace TodoApi.Mappings
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Storage.Entities.ConfirmationType, Models.Request.ConfirmationType>();
            CreateMap<Storage.Entities.County, Models.Request.County>();
            CreateMap<Storage.Entities.DiscoveryType, Models.Request.DiscoveryType>();
            CreateMap<Storage.Entities.QuadrantT, Models.Request.QuadrantT>();
            CreateMap<Storage.Entities.ReleaseCauseType, Models.Request.ReleaseCauseType>();
            CreateMap<Storage.Entities.SiteTypeT, Models.Request.SiteTypeT>();
            CreateMap<Storage.Entities.SourceType, Models.Request.SourceType>();
            CreateMap<Storage.Entities.State, Models.Request.State>();
            CreateMap<Storage.Entities.SiteTypeT, Models.Request.SiteTypeT>();
            CreateMap<Storage.Entities.StreetTypeT, Models.Request.StreetTypeT>();
            CreateMap<Models.Request.ApOLPRRInsertIncident, Storage.Entities.ApOLPRRInsertIncident>();
        }
    }
}
