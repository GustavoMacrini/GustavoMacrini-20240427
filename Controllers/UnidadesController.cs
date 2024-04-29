using GestaoColaboradores.Models.Colaborador;
using GestaoColaboradores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GestaoColaboradores.Controllers
{
    public class UnidadesController : Controller
    {

        private readonly UnidadeService _unidadeService;
        private readonly ColaboradorService _colabService;

        public UnidadesController(UnidadeService unidadeService, ColaboradorService colabService)
        {
            _unidadeService = unidadeService;
            _colabService = colabService;
        }


        //GET: Unidades
        public async Task<IActionResult> Index()
        {
            var colaboradores = await _colabService.GetAllAsync();
            var unidades = await _unidadeService.GetAllAsync(null);

            List<UnidadeViewModel> unidadeViewModel = new List<UnidadeViewModel>();
            foreach(var unidade in unidades)
            {
                var colabFiltered = colaboradores.Where(c => c.Unidade.Id == unidade.Id).ToList();
                unidadeViewModel.Add(new UnidadeViewModel(unidade, colabFiltered));
            }

            return View(unidadeViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Code,Name")] Unidade unidade)
        {
            unidade.Active = true;
            if (ModelState.IsValid)
            {
                _unidadeService.Create(unidade);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> ToggleActive(Guid id, bool? currentstatus)
        {
            if (ModelState.IsValid)
            {
                _unidadeService.Update(id, !currentstatus.Value);
            }
            return RedirectToAction("Index");
        }
    }
}
