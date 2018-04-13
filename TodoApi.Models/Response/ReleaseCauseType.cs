using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Request
{
    public class ReleaseCauseType
    {
        public string ReleaseCauseCode { get; set; }
        public string ReleaseCauseDescription { get; set; }
        public int SortBy { get; set; }
    }
}
