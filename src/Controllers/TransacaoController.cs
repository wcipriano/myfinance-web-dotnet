using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

// [ApiController]
[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;

    private readonly ITransacaoService _service;
    private readonly IPlanoContaService _planoContaService;

    public TransacaoController(ILogger<TransacaoController> logger,
                                ITransacaoService service,
                                IPlanoContaService planoContaService)
    {
        _logger = logger;
        _service = service;
        _planoContaService = planoContaService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var lista = _service.Listar();
        ViewBag.ListItems = lista;
        return View();
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(int? id)
    {
        var transacaoModel = new TransacaoModel();
        if (id != null)
        {
            transacaoModel = _service.RetornarRegistro((int)id);
        }
        transacaoModel.PlanocontaList = _planoContaService.Listar();
        var listaFops = _service.ListarFops();
        transacaoModel.FormaPagamentoSelectList = new SelectList(listaFops, "Id", "Descricao");
        var PlanoContasSelectItens = new SelectList(transacaoModel.PlanocontaList, "Id", "Descricao");
        transacaoModel.PlanoContaSelectList = PlanoContasSelectItens;
        return View(transacaoModel);
    }

    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(TransacaoModel model)
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
