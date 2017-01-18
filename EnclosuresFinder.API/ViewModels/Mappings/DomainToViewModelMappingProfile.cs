using AutoMapper;
using EnclosuresFinder.Model.Entities;
using System;
using System.Linq;

namespace EnclosuresFinder.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Enclosure, EnclosureViewModel>()
                .ForMember(vm => vm.Material, map =>
                    map.MapFrom(e => ((Material)e.Material).ToString()))
                .ForMember(vm => vm.IngressProtection, map =>
                    map.MapFrom(e => ((Ingress)e.IngressProtection).ToString()))
                .ForMember(vm => vm.Series, map =>
                    map.MapFrom(e => ((Series)e.Series).ToString()))
                .ForMember(vm => vm.MaterialList, map =>
                    map.UseValue(Enum.GetNames(typeof(Material)).ToArray()))
                .ForMember(vm => vm.IngressList, map =>
                    map.UseValue(Enum.GetNames(typeof(Ingress)).ToArray()))
                .ForMember(vm => vm.SeriesList, map =>
                    map.UseValue(Enum.GetNames(typeof(Series)).ToArray()));
        }
    }
}
