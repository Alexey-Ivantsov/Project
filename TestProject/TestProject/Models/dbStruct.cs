using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class DbStruct
    {
        [Display(Name = "Site")]
        public string _siteName { get; set; }
        [Display(Name = "URL")]
        public string _url { get; set; }
        [Display(Name = "Time")]
        public int _time { get; set; }
    }
}