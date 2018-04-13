using System.ComponentModel.DataAnnotations;

namespace TodoApi.Storage.Entities
{
    public class SiteTypeT
    {
        [Key]
        public string SiteTypeCode { get; set; }

        public string SiteType { get; set; }
    }
}
