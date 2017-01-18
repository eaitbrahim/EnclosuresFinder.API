using FluentValidation;

namespace EnclosuresFinder.API.ViewModels.Validations
{
    public class EnclosureViewModelValidator : AbstractValidator<EnclosureViewModel>
    {
        public EnclosureViewModelValidator()
        {
            RuleFor(e => e.LengthIn).NotEmpty().WithMessage("Enclosure's Length In cannot be empty");
            RuleFor(e => e.WidthIn).NotEmpty().WithMessage("Enclosure's Width In cannot be empty");
            RuleFor(e => e.DepthIn).NotEmpty().WithMessage("Enclosure's Depth In cannot be empty");
            RuleFor(e => e.LengthMm).NotEmpty().WithMessage("Enclosure's Length Mm cannot be empty");
            RuleFor(e => e.WidthMm).NotEmpty().WithMessage("Enclosure's Width Mm cannot be empty");
            RuleFor(e => e.DepthMm).NotEmpty().WithMessage("Enclosure's Depth Mm cannot be empty");
            RuleFor(e => e.TypeNumber).NotEmpty().WithMessage("Enclosure's Type Number cannot be empty");
            RuleFor(e => e.PartNumber).NotEmpty().WithMessage("Enclosure's Part Number cannot be empty");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Enclosure's Description cannot be empty");
            RuleFor(e => e.ImageUrl).NotEmpty().WithMessage("Enclosure's Image Url cannot be empty");
            RuleFor(e => e.PdfUrl).NotEmpty().WithMessage("Enclosure's Pdf Url cannot be empty");
            RuleFor(e => e.DrawingUrl).NotEmpty().WithMessage("Enclosure's Drawing Url cannot be empty");
            RuleFor(e => e.ModelUrl).NotEmpty().WithMessage("Enclosure's Model Url cannot be empty");
        }
    }
}
