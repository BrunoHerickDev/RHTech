//using AutoMapper;
//using RhTech.Core.Application.Interfaces;
//using RhTech.Core.Application.ViewModels;
//using RhTech.Core.Domain.Entities;
//using RhTech.Core.Domain.Interfaces;

//namespace RhTech.Core.Application.Services
//{
//    public class VagasService : IVagasService
//    {
//        private readonly IVagasRepository _vagasRepository;
//        private readonly IMapper _mapper;

//        public VagasService(IVagasRepository vagasRepository, IMapper mapper)
//        {
//            _vagasRepository = vagasRepository;
//            _mapper = mapper;
//        }

//        public async Task Alterar(VagaViewModel viewModel)
//        {
//            var vaga = await _vagasRepository.ObterPorId(viewModel.Id);

//            if (vaga == null)
//                throw new Exception("Vaga não existe.");

//            vaga.Titulo = viewModel.Titulo;
//            vaga.Descricao = viewModel.Descricao;
//            vaga.Requisitos = viewModel.Requisitos;
//            vaga.Localizacao = viewModel.Localizacao;
//            vaga.DataEncerramento = viewModel.DataEncerramento;
//            vaga.IdEmpresa = viewModel.IdEmpresa;

//            await _vagasRepository.Alterar(vaga);
//        }

//        public async Task<VagaViewModel> Cadastrar(VagaViewModel viewModel)
//        {
//            var vaga = _mapper.Map<Vaga>(viewModel);

//            await _vagasRepository.Cadastrar(vaga);

//            viewModel.Id = vaga.Id;

//            return viewModel;
//        }

//        public async Task<List<VagaViewModel>> ObterLista()
//        {
//            var vagas = await _vagasRepository.ObterLista();

//            var vagasViewModel = _mapper.Map<List<VagaViewModel>>(vagas);

//            return vagasViewModel;
//        }

//        public async Task<VagaViewModel> ObterPorId(int id)
//        {
//           var vaga = await _vagasRepository.ObterPorId(id);

//            return _mapper.Map<VagaViewModel>(vaga);
//        }

//        public async Task Remover(int id)
//        {
//            var vaga = await _vagasRepository.ObterPorId(id);

//            if (vaga == null)
//                throw new Exception("Vaga não existe.");

//            await _vagasRepository.Remover(vaga);
//        }
//    }
//}
