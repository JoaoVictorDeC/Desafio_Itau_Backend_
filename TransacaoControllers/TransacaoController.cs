using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Models;
using Desafio_Itau_backend_C_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


[ApiController]
[Route("api/Controller")]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _service;

    public TransacaoController(TransacaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CriarTransacao([FromBody] TransacaoDTO dTO)
    {
        var request = new TransacaoRequest(dTO.Valor, dTO.DataHora);
        await _service.CriarTransacao(request);
        return Ok("Transacao criada com sucesso");

    }
}

    

