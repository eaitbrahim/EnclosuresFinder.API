using EnclosuresFinder.API.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EnclosuresFinder.API.ViewModels
{
    public class EnclosureViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public double LengthIn { get; set; }
        public double WidthIn { get; set; }
        public double DepthIn { get; set; }
        public double LengthMm { get; set; }
        public double WidthMm { get; set; }
        public double DepthMm { get; set; }
        public string Material { get; set; }
        public string IngressProtection { get; set; }
        public bool OutdoorUse { get; set; }
        public bool UlApproval { get; set; }
        public bool Nema4X { get; set; }
        public string Series { get; set; }
        public string TypeNumber { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string DrawingUrl { get; set; }
        public string ModelUrl { get; set; }

        // Lookups
        public string[] MaterialList { get; set; }
        public string[] IngressList { get; set; }
        public string[] SeriesList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new EnclosureViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
