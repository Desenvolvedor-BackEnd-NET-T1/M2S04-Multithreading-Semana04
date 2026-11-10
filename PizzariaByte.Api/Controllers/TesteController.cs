using Microsoft.AspNetCore.Mvc;
using PizzariaByte.Api.Services;

namespace PizzariaByte.Api.Controllers;

// Comparação de carga: o mesmo serviço lento (1 s) chamado de dois jeitos.
// Use o projeto PizzariaByte.Carga para disparar várias requisições.
[ApiController]
[Route("api/teste")]
public class TesteController : ControllerBase
{
    private readonly CardapioService _cardapio;

    public TesteController(CardapioService cardapio)
    {
        _cardapio = cardapio;
    }

    // Sync over async: o .Result trava a thread enquanto espera
    [HttpGet("bloqueando")]
    public IActionResult Bloqueando()
    {
        var sabores = _cardapio.BuscarSaboresAsync().Result;
        return Ok(sabores);
    }

    // Async do começo ao fim: a thread fica livre enquanto espera
    [HttpGet("esperando")]
    public async Task<IActionResult> Esperando()
    {
        var sabores = await _cardapio.BuscarSaboresAsync();
        return Ok(sabores);
    }
}
