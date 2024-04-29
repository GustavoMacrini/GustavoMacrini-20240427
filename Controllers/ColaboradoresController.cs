using GestaoColaboradores.Models.User;
using GestaoColaboradores.Services;
using Microsoft.AspNetCore.Mvc;
using GestaoColaboradores.Models.Colaborador;

namespace GestaoColaboradores.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly ColaboradorService _colabService;
        private readonly UnidadeService _unidadeService;
        private readonly UserService _userService;

        public ColaboradoresController(ColaboradorService colabService, UnidadeService unidadeService, UserService userService)
        {
            _colabService = colabService;
            _unidadeService = unidadeService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _colabService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            var unidades = await _unidadeService.GetAllAsync(true);
            var usuarios = await _userService.GetAllAsync(null);

            ColaboradorViewModel viewModel = new ColaboradorViewModel(usuarios, unidades);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Unidade,Usuario")] ColaboradorViewModel colaboradorViewModel)
        {
            var usuario = await _userService.GetByIdAsync(colaboradorViewModel.Usuario);
            var unidade = await _unidadeService.GetByIdAsync(colaboradorViewModel.Unidade);

            Colaborador colaborador = new Colaborador(colaboradorViewModel.Name, unidade, usuario);           
            _colabService.Create(colaborador);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(string name, Guid unidadeId)
        {
            var unidades = await _unidadeService.GetAllAsync(true);
            var usuarios = await _userService.GetAllAsync(null);
            var unidadePlaceHolder = await _unidadeService.GetByIdAsync(unidadeId);

            ColaboradorViewModel viewModel = new ColaboradorViewModel(usuarios, unidades);
            viewModel.Name = name;
            viewModel.Colaborador = new Colaborador(null, unidadePlaceHolder, null);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Name,Unidade")] ColaboradorViewModel colabViewModel, Guid id)
        {
            var unidade = await _unidadeService.GetByIdAsync(colabViewModel.Unidade);
            _colabService.Edit(id, colabViewModel.Name, unidade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            _colabService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
