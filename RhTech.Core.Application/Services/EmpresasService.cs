using AutoMapper;
using RhTech.Core.Application.Helpers;
using RhTech.Core.Application.Interfaces;
using RhTech.Core.Application.ViewModels;
using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;

namespace RhTech.Core.Application.Services
{
    public class EmpresasService : IEmpresasService
    {
        private readonly IEmpresasRepository _empresasRepository;
        private readonly IMapper _mapper;

        public EmpresasService(IEmpresasRepository empresasRepository, IMapper mapper)
        {
            _empresasRepository = empresasRepository;
            _mapper = mapper;
        }

        public async Task Alterar(EmpresaViewModel viewModel)
        {
            var empresa = await _empresasRepository.ObterPorId(viewModel.Id);

            if (empresa == null)
                throw new Exception("Empresa não existe.");

            empresa.Cnpj = viewModel.Cnpj;
            empresa.NomeFantasia = viewModel.NomeFantasia;

            await _empresasRepository.Alterar(empresa);
        }

        public async Task<EmpresaViewModel> Cadastrar(EmpresaViewModel viewModel)
        {
            var empresa = _mapper.Map<Empresa>(viewModel);

            if (!ValidaCNPJ.CnpjValido(empresa.Cnpj))
                throw new Exception("Cnpj inválido.");

            await _empresasRepository.Cadastrar(empresa);

            viewModel.Id = empresa.Id;

            return viewModel;
        }

        public async Task<List<EmpresaViewModel>> ObterLista()
        {
            var empresas = await _empresasRepository.ObterLista();

            var empresasViewModel = _mapper.Map<List<EmpresaViewModel>>(empresas);

            return empresasViewModel;
        }

        public async Task<EmpresaViewModel> ObterPorId(int id)
        {
           var empresa = await _empresasRepository.ObterPorId(id);

            return _mapper.Map<EmpresaViewModel>(empresa);
        }

        public async Task Remover(int id)
        {
            var empresa = await _empresasRepository.ObterPorId(id);

            if (empresa == null)
                throw new Exception("Empresa não existe.");

            await _empresasRepository.Remover(empresa);
        }
    }
}
