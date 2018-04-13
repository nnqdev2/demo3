using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApi.Models.Request
{ 
    public class ConfirmationType
    {
        public string ConfirmationCode { get; set; }
        public string ConfirmationDescription { get; set; }
        public int SortBy { get; set; }
    }
}
