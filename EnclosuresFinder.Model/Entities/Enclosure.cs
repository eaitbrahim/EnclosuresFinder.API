namespace EnclosuresFinder.Model.Entities
{
    public class Enclosure: IEntityBase
    {
        public int Id { get; set; }
        public double LengthIn { get; set; }
        public double WidthIn { get; set; }
        public double DepthIn { get; set; }
        public double LengthMm { get; set; }
        public double WidthMm { get; set; }
        public double DepthMm { get; set; }
        public Material Material { get; set; }
        public Ingress IngressProtection { get; set; }
        public bool OutdoorUse { get; set; }
        public bool UlApproval { get; set; }
        public bool Nema4X { get; set; }
        public Series Series { get; set; }
        public string TypeNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string DrawingUrl { get; set; }
        public string ModelUrl { get; set; }
    }
}
