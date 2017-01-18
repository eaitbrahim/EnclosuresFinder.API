using EnclosuresFinder.Model;
using EnclosuresFinder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnclosuresFinder.Data
{
    public class EnclosureDbInitializer
    {
        private static EnclosureContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EnclosureContext)serviceProvider.GetService(typeof(EnclosureContext));

            InitializeEnclosures();
        }

        private static void InitializeEnclosures()
        {
            if (!context.Enclosures.Any())
            {
                Enclosure enclosure_01 = new Enclosure
                {
                    LengthIn            = 1.77,
                    WidthIn             = 2.05,
                    DepthIn             = 1.38,
                    LengthMm            = 45,
                    WidthMm             = 52,
                    DepthMm             = 35,
                    Material            = Material.Polycarbonate,
                    IngressProtection   = Ingress.IP66,
                    OutdoorUse          = true,
                    UlApproval          = true,
                    Nema4X              = true,
                    Series              = Series.TK,
                    TypeNumber          = "PC55-4-o",
                    PartNumber          = "120-455",
                    Description         = "Enclosure, Polycarbonate, Gray, Smooth Sides",
                    ImageUrl            = "http://www.altechcorp.com/ImageBank/Enclosures/120455.jpg",
                    PdfUrl              = "http://www.altechcorp.com/PDFS/Splits/IndEnclo2011-12.pdf",
                    DrawingUrl          = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TK/TK55.DWG",
                    ModelUrl            = "http://www.altechcorp.com/enclosures/STEP-FILES/TK55/120-455.stp"
                };

                Enclosure enclosure_02 = new Enclosure
                {
                    LengthIn            = 4.33,
                    WidthIn             = 4.33,
                    DepthIn             = 2.6,
                    LengthMm            = 110,
                    WidthMm             = 110,
                    DepthMm             = 66,
                    Material            = Material.Polystyrene,
                    IngressProtection   = Ingress.IP66,
                    OutdoorUse          = false,
                    UlApproval          = false,
                    Nema4X              = false,
                    Series              = Series.TK,
                    TypeNumber          = "PS1111-7-m",
                    PartNumber          = "105-404",
                    Description         = "Enclosure, Polystyrene, Gray, Metric knockouts",
                    ImageUrl            = "http://www.altechcorp.com/ImageBank/Enclosures/105404.jpg",
                    PdfUrl              = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-20.pdf",
                    DrawingUrl          = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TK/TK1111.DWG",
                    ModelUrl            = "http://www.altechcorp.com/enclosures/STEP-FILES/TK1111/105-404_and_127-404.stp"
                };

                Enclosure enclosure_03 = new Enclosure
                {
                    LengthIn           = 7.95,
                    WidthIn            = 4.8,
                    DepthIn            = 2.95,
                    LengthMm           = 202,
                    WidthMm            = 122,
                    DepthMm            = 75,
                    Material           = Material.ABS,
                    IngressProtection  = Ingress.IP67,
                    OutdoorUse         = false,
                    UlApproval         = false,
                    Nema4X             = false,
                    Series             =  Series.TG,
                    TypeNumber         = "TGABS2012-8-to",
                    PartNumber         = "101-008-01",
                    Description        = "Enclosure, ABS, Gray with transparent cover, quick turn screws, smooth walls",
                    ImageUrl           = "http://www.altechcorp.com/ImageBank/Enclosures/101008.jpg",
                    PdfUrl             = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-57.pdf",
                    DrawingUrl         = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TG/TG2012-8.dwg",
                    ModelUrl           = "http://www.altechcorp.com/enclosures/STEP-FILES/TG_StepFiles/TG2012-8/10100801.stp"
                };

                Enclosure enclosure_04 = new Enclosure
                {
                    LengthIn           = 11.89,
                    WidthIn            = 9.13,
                    DepthIn            = 4.33,
                    LengthMm           = 302,
                    WidthMm            = 232,
                    DepthMm            = 110,
                    Material           = Material.Polycarbonate,
                    IngressProtection  = Ingress.IP67,
                    OutdoorUse         = true,
                    UlApproval         = true,
                    Nema4X             = false,
                    Series             = Series.TG,
                    TypeNumber         = "TGPC3023-11-to",
                    PartNumber         = "201-513-01",
                    Description        = "Enclosure, Polycarbonate, Gray with transparent cover, quick turn screws, smooth walls",
                    ImageUrl           = "http://www.altechcorp.com/ImageBank/Enclosures/20151301.jpg",
                    PdfUrl             = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-63.pdf",
                    DrawingUrl         = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TG/TG3023-11.dwg",
                    ModelUrl           = "http://www.altechcorp.com/enclosures/STEP-FILES/TG_StepFiles/TG3023-11/20151301.stp"
                };

                Enclosure enclosure_05 = new Enclosure
                {
                    LengthIn           = 11.89,
                    WidthIn            = 9.13,
                    DepthIn            = 4.33,
                    LengthMm           = 302,
                    WidthMm            = 232,
                    DepthMm            = 110,
                    Material           = Material.Polycarbonate,
                    IngressProtection  = Ingress.IP67,
                    OutdoorUse         = true,
                    UlApproval         = true,
                    Nema4X             = true,
                    Series             = Series.TG,
                    TypeNumber         = "TGPC3023-11-to",
                    PartNumber         = "201-513-91",
                    Description        = "Enclosure, Polycarbonate, Gray with transparent cover, smooth walls",
                    ImageUrl           = "http://www.altechcorp.com/ImageBank/Enclosures/20151391.jpg",
                    PdfUrl             = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-63.pdf",
                    DrawingUrl         = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TG/TG3023-11.dwg",
                    ModelUrl           = "http://www.altechcorp.com/enclosures/STEP-FILES/TG_StepFiles/TG3023-11/20151301.stp"
                };

                Enclosure enclosure_06 = new Enclosure
                {
                    LengthIn = 4.8,
                    WidthIn = 4.72,
                    DepthIn = 3.15,
                    LengthMm = 122,
                    WidthMm = 120,
                    DepthMm = 80,
                    Material = Material.Aluminum,
                    IngressProtection = Ingress.IP66,
                    OutdoorUse = true,
                    UlApproval = false,
                    Nema4X = false,
                    Series = Series.AL,
                    TypeNumber = "AL1212-8",
                    PartNumber = "150-009",
                    Description = "Enclosure, Cast Aluminum, Dark Gray",
                    ImageUrl = "http://www.altechcorp.com/ImageBank/Enclosures/150009.jpg",
                    PdfUrl = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-76.pdf",
                    DrawingUrl = "http://www.altechcorp.com/enclosures/EnclosureDwgs/AL/AL1212-8.dwg",
                    ModelUrl = "TBD"
                };

                Enclosure enclosure_07 = new Enclosure
                {
                    LengthIn           = 7.09,
                    WidthIn            = 4.33,
                    DepthIn            = 4.33,
                    LengthMm           = 180,
                    WidthMm            = 110,
                    DepthMm            = 110,
                    Material           = Material.Polycarbonate,
                    IngressProtection  = Ingress.IP65,
                    OutdoorUse         = true,
                    UlApproval         = true,
                    Nema4X             = true,
                    Series             = Series.EK,
                    TypeNumber         = "EK004",
                    PartNumber         = "542-504",
                    Description        = "Enclosure with access door for up to 4 poles DIN Circuit breakers, Polycarbonate, Gray, smooth walls",
                    ImageUrl           = "http://www.altechcorp.com/ImageBank/Enclosures/542504.jpg",
                    PdfUrl             = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-117.pdf",
                    DrawingUrl         = "http://www.altechcorp.com/enclosures/EnclosureDwgs/EK/EK004.dwg",
                    ModelUrl           = "TBD"
                };

                Enclosure enclosure_08 = new Enclosure
                {
                    LengthIn = 7.09,
                    WidthIn = 4.33,
                    DepthIn = 4.37,
                    LengthMm = 180,
                    WidthMm = 110,
                    DepthMm = 111,
                    Material = Material.Polycarbonate,
                    IngressProtection = Ingress.IP66,
                    OutdoorUse = true,
                    UlApproval = true,
                    Nema4X = true,
                    Series = Series.TK,
                    TypeNumber = "PC1811-11-o",
                    PartNumber = "120-906",
                    Description = "Enclosure, Polycarbonate, Gray, Smooth Sides",
                    ImageUrl = "http://www.altechcorp.com/ImageBank/Enclosures/120906.jpg",
                    PdfUrl = "http://www.altechcorp.com/PDFS/Splits/IndEnclo-30.pdf",
                    DrawingUrl = "http://www.altechcorp.com/enclosures/EnclosureDwgs/TK/TK1811.DWG",
                    ModelUrl = "http://www.altechcorp.com/enclosures/STEP-FILES/TK1811/110-906_and_120-906.stp"
                };

                context.Enclosures.Add(enclosure_01); context.Enclosures.Add(enclosure_02);
                context.Enclosures.Add(enclosure_03); context.Enclosures.Add(enclosure_04);
                context.Enclosures.Add(enclosure_05); context.Enclosures.Add(enclosure_06);
                context.Enclosures.Add(enclosure_07); context.Enclosures.Add(enclosure_08);
            }
            context.SaveChanges();
        }
    }
}
