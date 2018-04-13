using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApi.Storage.Entities
{
    public class ConfirmationType
    {
        [Key]
        public string ConfirmationCode { get; set; }
        public string ConfirmationDescription { get; set; }
        public int SortBy { get; set; }
    }
}
