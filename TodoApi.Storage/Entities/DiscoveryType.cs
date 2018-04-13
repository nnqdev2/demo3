﻿using System.ComponentModel.DataAnnotations;
namespace TodoApi.Storage.Entities
{
    public class DiscoveryType
    {
        [Key]
        public string DiscoveryCode { get; set; }
        public string DiscoveryDescription { get; set; }
        public int SortBy { get; set; }
    }
}
