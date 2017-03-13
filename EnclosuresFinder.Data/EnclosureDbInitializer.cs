using EnclosuresFinder.Model;
using EnclosuresFinder.Model.Entities;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnclosuresFinder.Data
{
    public class EnclosureDbInitializer
    {
        private static EnclosureContext context;
        static private IConfigurationRoot Configuration { get; set; }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EnclosureContext)serviceProvider.GetService(typeof(EnclosureContext));
            InitializeEnclosures();
        }

        private static void InitializeEnclosures()
        {
            if (!context.Enclosures.Any())
            {
                try
                {
                    var builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json");

                    Configuration = builder.Build();
                    string filePath = $"{Configuration["EnclosureDbInitializer:FilePath"]}";
                    // Get the file we are going to process
                    var existingFile = new FileInfo(filePath);
                    // Open and read the XlSX file.
                    using (var package = new ExcelPackage(existingFile))
                    {
                        // Get the work book in the file
                        var workBook = package.Workbook;
                        if (workBook != null)
                        {
                            if (workBook.Worksheets.Count > 0)
                            {
                                // Get the first worksheet
                                var currentWorksheet = workBook.Worksheets.First();
                                int rowCount = currentWorksheet.Dimension.Rows;
                                int colCount = currentWorksheet.Dimension.Columns;
                                for (int i = 2; i <= rowCount; i++)
                                {
                                    var enclosure = new Enclosure
                                    {
                                        LengthIn = (double)currentWorksheet.Cells[i, 1].Value,
                                        WidthIn = (double)currentWorksheet.Cells[i, 2].Value,
                                        DepthIn = (double)currentWorksheet.Cells[i, 3].Value,
                                        LengthMm = (double)currentWorksheet.Cells[i, 4].Value,
                                        WidthMm = (double)currentWorksheet.Cells[i, 5].Value,
                                        DepthMm = (double)currentWorksheet.Cells[i, 6].Value,
                                        Material = (Material)Enum.Parse(typeof(Material), currentWorksheet.Cells[i, 7].Value.ToString()),
                                        IngressProtection = (Ingress)Enum.Parse(typeof(Ingress), currentWorksheet.Cells[i, 8].Value.ToString()),
                                        OutdoorUse = currentWorksheet.Cells[i, 9].Value.ToString().Trim() == "YES" ? true : false,
                                        UlApproval = currentWorksheet.Cells[i, 10].Value.ToString().Trim() == "YES" ? true : false,
                                        Nema4X = currentWorksheet.Cells[i, 11].Value.ToString().Trim() == "YES" ? true : false,
                                        Series = (Series)Enum.Parse(typeof(Series), currentWorksheet.Cells[i, 12].Value.ToString()),
                                        TypeNumber = currentWorksheet.Cells[i, 13].Value.ToString(),
                                        PartNumber = currentWorksheet.Cells[i, 14].Value.ToString(),
                                        Description = currentWorksheet.Cells[i, 15].Value.ToString(),
                                        ImageUrl = currentWorksheet.Cells[i, 16].Value.ToString(),
                                        PdfUrl = currentWorksheet.Cells[i, 17].Value.ToString(),
                                        DrawingUrl = currentWorksheet.Cells[i, 18].Value.ToString(),
                                        ModelUrl = currentWorksheet.Cells[i, 19].Value.ToString()
                                    };
                                    context.Enclosures.Add(enclosure);
                                }
                                context.SaveChanges();
                            }
                        }
                    }
                }
                catch(Exception Ex)
                {
                    throw new Exception(Ex.Message.ToString());
                }
            }
        }
    }
}
