using EnclosuresFinder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnclosuresFinder.API.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            this.MaterialList = new List<Material>();
            this.IngressList = new List<Ingress>();
            this.SeriesList = new List<Series>();
        }
        public double? MinLength { get; set; }
        public double? MaxLength { get; set; }
        public double? MinWidth { get; set; }
        public double? MaxWidth { get; set; }
        public double? MinDepth { get; set; }
        public double? MaxDepth { get; set; }
        public string DimensionUnit { get; set; }
        public string PartNumber { get; set; }
        public List<Material> MaterialList { get; set; }
        public List<Ingress> IngressList { get; set; }
        public List<Series> SeriesList { get; set; }
        public bool? OutdoorUse { get; set; }
        public bool? UlApproval { get; set; }
        public bool? Nema4X { get; set; }
    }
}
