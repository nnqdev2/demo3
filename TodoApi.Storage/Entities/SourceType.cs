using System.ComponentModel.DataAnnotations;

namespace TodoApi.Storage.Entities
{
    public class SourceType
    {
        [Key]
        public int ReleaseSourceId { get; set; }
        public string ReleaseSourceDescription { get; set; }
    }
}
