using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models.Request
{
    public class DiscoveryType
    {
        public string DiscoveryCode { get; set; }
        public string DiscoveryDescription { get; set; }
        public int SortBy { get; set; }
    }
}
