using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacNCap_V2.Models
{
    public class TrucksViewModels
    {
        [Key]
        public int TrucksViewModelsId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}