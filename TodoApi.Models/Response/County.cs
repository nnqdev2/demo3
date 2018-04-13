using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Request
{
    public class County
    {
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int SortBy { get; set; }
    }
}
