using AutoMapper;
using RhTech.Core.Application.Helpers;
using RhTech.Core.Application.Interfaces;
using RhTech.Core.Application.ViewModels;
using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;

namespace RhTech.Core.Application.Services
{
    public class CandidatosService : ICandidatosService
    {
        private readonly ICandidatosRepository _candidatosRepository;
        private readonly IMapper _mapper;

        public CandidatosService(ICandidatosRepository candidatosRepository, IMapper mapper)
        {
            _candidatosRepository = candidatosRepository;
            _mapper = mapper;
        }

        public async Task Alterar(CandidatoViewModel viewModel)
        {
            var candidato = await _candidatosRepository.ObterPorId(viewModel.Id);

            if (candidato == null)
                throw new Exception("Candidato não existe.");

            candidato.Cpf = viewModel.Cpf.Replace(".", "").Replace("-", "");

            candidato.DataNascimento = viewModel.DataNascimento;
            candidato.Nacionalidade = viewModel.Nacionalidade;
            candidato.Genero = viewModel.Genero;
            candidato.NomeCompleto = viewModel.NomeCompleto;

            await _candidatosRepository.Alterar(candidato);
        }

        public async Task<CandidatoViewModel> Cadastrar(CandidatoViewModel viewModel)
        {
            var candidato = _mapper.Map<Candidato>(viewModel);

            if (!ValidaCNPJ.CpfValido(candidato.Cpf))
                throw new Exception("Cpf inválido.");

            if (!candidato.Genero.Equals("M") || !candidato.Genero.Equals("F"))
                throw new Exception("Gênero Inválido.");

            await _candidatosRepository.Cadastrar(candidato);

            viewModel.Id = candidato.Id;

            return viewModel;
        }

        public async Task<List<CandidatoViewModel>> ObterLista()
        {
            var candidatos = await _candidatosRepository.ObterLista();

            var candidatosViewModel = _mapper.Map<List<CandidatoViewModel>>(candidatos);

            return candidatosViewModel;
        }

        public async Task<CandidatoViewModel> ObterPorId(int id)
        {
           var candidato = await _candidatosRepository.ObterPorId(id);

            return _mapper.Map<CandidatoViewModel>(candidato);
        }

        public async Task Remover(int id)
        {
            var candidato = await _candidatosRepository.ObterPorId(id);

            if (candidato == null)
                throw new Exception("Candidato não existe.");

            await _candidatosRepository.Remover(candidato);
        }
    }
}
