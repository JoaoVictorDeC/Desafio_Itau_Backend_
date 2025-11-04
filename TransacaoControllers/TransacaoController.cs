using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Models;
using Desafio_Itau_backend_C_.Services;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[Controller]")]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _service;

    public TransacaoController(TransacaoService service)
    {
        _service = service;
    }

    [HttpPost("Transacao")]
    public async Task<IActionResult> CriarTransacao([FromBody] TransacaoDTO dto)
    {
        var request = new TransacaoRequest(
            dto.Valor,
            DateTimeOffset.UtcNow
            );
        try
        {
            await _service.CriarTransacao(request);
            return Created();
        }
        catch (ArgumentException ex) 
        {
           return BadRequest( ex.Message);
        }

    }
    [HttpGet("TodasTransacoes")]
    public IActionResult ObterTransacaoes() 
    {
        var transacoes = _service.ObterTransacoes();
        return Ok(transacoes);
    }


    [HttpGet("GetEstatistica")]
    public async Task<IActionResult> ReceberEstastistica()
    {
        var tempo = DateTimeOffset.UtcNow.AddMinutes(-60);
        var estasticas = await _service.ObterEstatisticas(tempo);

        return Ok(estasticas);

    }

    [HttpDelete]

    public IActionResult delete() 
    {
        _service.LimparService();

        return Ok("Transacoes removidas com sucesso.");
    }
}

    

