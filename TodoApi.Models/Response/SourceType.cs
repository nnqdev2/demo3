using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Request
{
    public class SourceType
    {
        public int ReleaseSourceId { get; set; }
        public string ReleaseSourceDescription { get; set; }
    }
}
