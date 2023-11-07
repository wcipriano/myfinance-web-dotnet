using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

// [ApiController]
[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;

    private readonly IPlanoContaService _service;

    public PlanoContaController(ILogger<PlanoContaController> logger,
                                IPlanoContaService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        //var listaPlanoConta = _planoContaService.Listar();
        // List<PlanoContaModel> listaPlanoContaModel = new();
        // foreach (var item in _planoContaService.Listar())
        // {
        //     var planoConta = new PlanoContaModel()
        //     {
        //         Id = item.Id,
        //         Descricao = item.Descricao,
        //         Tipo = item.Tipo
        //     };
        //     listaPlanoContaModel.Add(planoConta);
        // }
        // ViewBag.ListaPlanoConta = listaPlanoContaModel

        var lista = _service.Listar();
        ViewBag.ListItems = lista;
        return View();
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(int? id)
    {
        if (id != null)
        {
            var registro = _service.RetornarRegistro((int)id);
            return View(registro);
        }
        return View();
    }

    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(PlanoContaModel model)
    {
        _service.Salvar(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _service.Excluir(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
