using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Request
{
    public class State
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public int SortBy { get; set; }
    }
}
