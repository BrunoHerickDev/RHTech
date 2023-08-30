using AutoMapper;
using RhTech.Core.Application.ViewModels;
using RhTech.Core.Domain.Entities;

namespace RhTech.Core.Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            //CreateMap<Vaga, VagaViewModel>().ReverseMap();
            CreateMap<Candidato, CandidatoViewModel>().ReverseMap();
        }
    }
}
