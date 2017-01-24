using AutoMapper;
using EnclosuresFinder.API.Core;
using EnclosuresFinder.API.ViewModels;
using EnclosuresFinder.Data;
using EnclosuresFinder.Data.Abstract;
using EnclosuresFinder.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnclosuresFinder.API.Controllers
{
    [Route("api/[controller]")]
    public class EnclosuresController : Controller
    {
        private IEnclosureRepository _enclosureRepository;
        int page = 1;
        int pageSize = 4;
        public EnclosuresController(IEnclosureRepository enclosureRepository)
        {
            _enclosureRepository = enclosureRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalEnclosures = _enclosureRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalEnclosures / pageSize);
            IEnumerable<Enclosure> _enclosures = _enclosureRepository
                                .GetAll()
                                .OrderByDescending(s => s.Id)
                                .Skip((currentPage - 1) * currentPageSize)
                                .Take(currentPageSize)
                                .ToList();
            Response.AddPagination(page, pageSize, totalEnclosures, totalPages);

            IEnumerable<EnclosureViewModel> _enclosuresVM = Mapper.Map<IEnumerable<Enclosure>, IEnumerable<EnclosureViewModel>>(_enclosures);

            return new OkObjectResult(_enclosuresVM);
        }

        [HttpGet("{id}", Name = "GetEnclosure")]
        public IActionResult Get(int id)
        {
            Enclosure _enclosure = _enclosureRepository
                .GetSingle(e => e.Id == id);

            if (_enclosure != null)
            {
                EnclosureViewModel _enclosureVM = Mapper.Map<Enclosure, EnclosureViewModel>(_enclosure);
                return new OkObjectResult(_enclosureVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Search")]
        public IActionResult Search(string partNumber)
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            ISpecification<Enclosure> partNumExpSpec = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            if (!string.IsNullOrEmpty(partNumber))
            {
                partNumExpSpec = new ExpressionSpecification<Enclosure>(e => e.PartNumber.ToLower().Contains(partNumber.ToLower().Trim()));
            }
            int currentPage = page;
            int currentPageSize = pageSize;

            var totalEnclosures = _enclosureRepository.Count(partNumExpSpec);
            var totalPages = (int)Math.Ceiling((double)totalEnclosures / pageSize);

            if (currentPage > totalPages) currentPage = 1;

            IEnumerable<Enclosure> _enclosures = _enclosureRepository.Find(partNumExpSpec)
                            .OrderByDescending(s => s.Id)
                            .Skip((currentPage - 1) * currentPageSize)
                            .Take(currentPageSize)
                            .ToList();


            Response.AddPagination(page, pageSize, totalEnclosures, totalPages);

            IEnumerable<EnclosureViewModel> _enclosuresVM = Mapper.Map<IEnumerable<Enclosure>, IEnumerable<EnclosureViewModel>>(_enclosures);

            return new OkObjectResult(_enclosuresVM);
        }

        [HttpPost("Filter")]
        public IActionResult Filter([FromBody]FilterViewModel filterObj)
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }
            
            ISpecification<Enclosure> minLengthInExpSpec    = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxLengthInExpSpec    = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> minWidthInExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxWidthInExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> minDepthInExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxDepthInExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> minLengthMmExpSpec    = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxLengthMmExpSpec    = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> minWidthMmExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxWidthMmExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> minDepthMmExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> maxDepthMmExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> materialExpSpec       = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> ingressExpSpec        = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> seriesExpSpec         = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> outdoorUseExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> ulApprovalExpSpec     = new ExpressionSpecification<Enclosure>(e => 1 == 1);
            ISpecification<Enclosure> nema4XExpSpec         = new ExpressionSpecification<Enclosure>(e => 1 == 1);

            if (!string.IsNullOrEmpty(filterObj.DimensionUnit))
            {
                switch (filterObj.DimensionUnit)
                {
                    case "mm":
                        if (filterObj.MinLength != null)
                        {
                            minLengthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.LengthMm >= filterObj.MinLength.Value);
                        }

                        if (filterObj.MaxLength != null)
                        {
                            maxLengthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.LengthMm <= filterObj.MaxLength.Value);
                        }

                        if (filterObj.MinWidth != null)
                        {
                            minWidthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.WidthMm >= filterObj.MinWidth.Value);
                        }

                        if (filterObj.MaxWidth != null)
                        {
                            maxWidthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.WidthMm <= filterObj.MaxWidth.Value);
                        }

                        if (filterObj.MinDepth != null)
                        {
                            minDepthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.DepthMm >= filterObj.MinDepth.Value);
                        }

                        if (filterObj.MaxDepth != null)
                        {
                            maxDepthMmExpSpec = new ExpressionSpecification<Enclosure>(e => e.DepthMm <= filterObj.MaxDepth.Value);
                        }
                        break;
                    case "in":
                        if (filterObj.MinLength != null)
                        {
                            minLengthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.LengthIn >= filterObj.MinLength.Value);
                        }
                        if (filterObj.MaxLength != null)
                        {
                            maxLengthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.LengthIn <= filterObj.MaxLength.Value);
                        }
                        if (filterObj.MinWidth != null)
                        {
                            minWidthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.WidthIn >= filterObj.MinWidth.Value);
                        }
                        if (filterObj.MaxWidth != null)
                        {
                            maxWidthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.WidthIn <= filterObj.MaxWidth.Value);
                        }
                        if (filterObj.MinDepth != null)
                        {
                            minDepthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.DepthIn >= filterObj.MinDepth.Value);
                        }
                        if (filterObj.MaxDepth != null)
                        {
                            maxDepthInExpSpec = new ExpressionSpecification<Enclosure>(e => e.DepthIn <= filterObj.MaxDepth.Value);
                        }
                        break;
                }

            }
            
            if (filterObj.MaterialList != null && filterObj.MaterialList.Count() > 0)
            {
                materialExpSpec = new ExpressionSpecification<Enclosure>(e => filterObj.MaterialList.Contains(e.Material));
            }

            if (filterObj.IngressList != null && filterObj.IngressList.Count() > 0)
            {
                ingressExpSpec = new ExpressionSpecification<Enclosure>(e => filterObj.IngressList.Contains(e.IngressProtection));
            }

            if (filterObj.SeriesList != null && filterObj.SeriesList.Count() > 0)
            {
                seriesExpSpec = new ExpressionSpecification<Enclosure>(e => filterObj.SeriesList.Contains(e.Series));
            }

            if (filterObj.OutdoorUse != null)
            {
                outdoorUseExpSpec = new ExpressionSpecification<Enclosure>(e => e.OutdoorUse == filterObj.OutdoorUse);
            }

            if (filterObj.UlApproval != null)
            {
                ulApprovalExpSpec = new ExpressionSpecification<Enclosure>(e => e.UlApproval == filterObj.UlApproval);
            }

            if (filterObj.Nema4X != null)
            {
                nema4XExpSpec = new ExpressionSpecification<Enclosure>(e => e.Nema4X == filterObj.Nema4X);
            }

            ISpecification<Enclosure> complexSpec = minLengthInExpSpec.And(
                                                    maxLengthInExpSpec.And(
                                                    minWidthInExpSpec.And(
                                                    maxWidthInExpSpec.And(
                                                    minDepthInExpSpec.And(
                                                    maxDepthInExpSpec.And(
                                                    minLengthMmExpSpec.And(
                                                    maxLengthMmExpSpec.And(
                                                    minWidthMmExpSpec.And(
                                                    maxWidthMmExpSpec.And(
                                                    minDepthMmExpSpec.And(
                                                    maxDepthMmExpSpec.And(
                                                    materialExpSpec.And(
                                                    ingressExpSpec.And(
                                                    seriesExpSpec.And(
                                                    outdoorUseExpSpec.And(
                                                    ulApprovalExpSpec.And(
                                                    nema4XExpSpec)))))))))))))))));

            int currentPage = page;
            int currentPageSize = pageSize;

            var totalEnclosures = _enclosureRepository.Count(complexSpec);
            var totalPages = (int)Math.Ceiling((double)totalEnclosures / pageSize);

            if (currentPage > totalPages) currentPage = 1;

            IEnumerable<Enclosure> _enclosures = _enclosureRepository.Find(complexSpec)
                            .OrderByDescending(s => s.Id)
                            .Skip((currentPage - 1) * currentPageSize)
                            .Take(currentPageSize)
                            .ToList();

            
            Response.AddPagination(page, pageSize, totalEnclosures, totalPages);

            IEnumerable<EnclosureViewModel> _enclosuresVM = Mapper.Map<IEnumerable<Enclosure>, IEnumerable<EnclosureViewModel>>(_enclosures);

            return new OkObjectResult(_enclosuresVM);
        }

        [HttpPost]
        public IActionResult Create([FromBody]EnclosureViewModel enclosure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enclosure _newEnclosure = Mapper.Map<EnclosureViewModel, Enclosure>(enclosure);

            _enclosureRepository.Add(_newEnclosure);
            _enclosureRepository.Commit();

            _enclosureRepository.Commit();

            enclosure = Mapper.Map<Enclosure, EnclosureViewModel>(_newEnclosure);

            CreatedAtRouteResult result = CreatedAtRoute("GetEnclosure", new { controller = "Enclosures", id = enclosure.Id }, enclosure);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EnclosureViewModel enclosure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enclosure _enclosureDb = _enclosureRepository.GetSingle(id);

            if (_enclosureDb == null)
            {
                return NotFound();
            }
            else
            {
                _enclosureDb.LengthIn           = enclosure.LengthIn;
                _enclosureDb.WidthIn            = enclosure.WidthIn;
                _enclosureDb.DepthIn            = enclosure.DepthIn;
                _enclosureDb.LengthMm           = enclosure.LengthMm;
                _enclosureDb.WidthMm            = enclosure.WidthMm;
                _enclosureDb.DepthMm            = enclosure.DepthMm;
                _enclosureDb.Material           = (Material)Enum.Parse(typeof(Material), enclosure.Material);
                _enclosureDb.IngressProtection  = (Ingress)Enum.Parse(typeof(Ingress), enclosure.IngressProtection);
                _enclosureDb.OutdoorUse         = enclosure.OutdoorUse;
                _enclosureDb.UlApproval         = enclosure.UlApproval;
                _enclosureDb.Nema4X             = enclosure.Nema4X;
                _enclosureDb.Series             = (Series)Enum.Parse(typeof(Series), enclosure.Series);
                _enclosureDb.TypeNumber         = enclosure.TypeNumber;
                _enclosureDb.PartNumber         = enclosure.PartNumber;
                _enclosureDb.Description        = enclosure.Description;
                _enclosureDb.ImageUrl           = enclosure.ImageUrl;
                _enclosureDb.PdfUrl             = enclosure.PdfUrl;
                _enclosureDb.DrawingUrl         = enclosure.DrawingUrl;
                _enclosureDb.ModelUrl           = enclosure.ModelUrl;

                _enclosureRepository.Commit();
            }

            enclosure = Mapper.Map<Enclosure, EnclosureViewModel>(_enclosureDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "RemoveEnclosure")]
        public IActionResult Delete(int id)
        {
            Enclosure _enclosureDb = _enclosureRepository.GetSingle(id);

            if (_enclosureDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _enclosureRepository.Delete(_enclosureDb);

                _enclosureRepository.Commit();

                return new NoContentResult();
            }
        }
    }
}
