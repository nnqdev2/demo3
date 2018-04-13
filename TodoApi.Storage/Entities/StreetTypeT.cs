using System.ComponentModel.DataAnnotations;

namespace TodoApi.Storage.Entities
{
    public class StreetTypeT
    {
        [Key]
        public string StreetType { get; set; }
        public int SortBy { get; set; }
    }
}
