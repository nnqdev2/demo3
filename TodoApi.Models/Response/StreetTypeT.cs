using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Request
{
    public class StreetTypeT
    {
        public string StreetType { get; set; }
        public int SortBy { get; set; }
    }
}
