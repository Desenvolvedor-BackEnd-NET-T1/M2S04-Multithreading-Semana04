using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaByte.Api.Data;
using PizzariaByte.Api.Services;

namespace PizzariaByte.Api.Controllers;

// A tela inicial do app: frete e promoção do dia
[ApiController]
[Route("api/vitrine")]
public class VitrineController : ControllerBase
{
    private readonly IEntregaService _entrega;
    private readonly IPromocaoService _promocao;
    private readonly PizzariaContext _contexto;

    public VitrineController(IEntregaService entrega,
        IPromocaoService promocao, PizzariaContext contexto)
    {
        _entrega = entrega;
        _promocao = promocao;
        _contexto = contexto;
    }

    // Um await depois do outro: cerca de 2 s
    [HttpGet("em-fila")]
    public async Task<IActionResult> EmFila()
    {
        var relogio = Stopwatch.StartNew();
        decimal frete =
            await _entrega.CalcularFreteAsync("Centro");
        string promo =
            await _promocao.BuscarPromocaoDoDiaAsync();
        long ms = relogio.ElapsedMilliseconds;
        return Ok(new { frete, promo, ms });
    }

    // As duas ao mesmo tempo: cerca de 1 s
    [HttpGet("juntas")]
    public async Task<IActionResult> Juntas()
    {
        var relogio = Stopwatch.StartNew();
        Task<decimal> tFrete =
            _entrega.CalcularFreteAsync("Centro");
        Task<string> tPromo =
            _promocao.BuscarPromocaoDoDiaAsync();
        await Task.WhenAll(tFrete, tPromo);
        decimal frete = await tFrete; // já terminou: não espera
        string promo = await tPromo;
        long ms = relogio.ElapsedMilliseconds;
        return Ok(new { frete, promo, ms });
    }

    // Cuidado: duas consultas ao mesmo tempo no MESMO DbContext dão erro
    [HttpGet("mesmo-contexto")]
    public async Task<IActionResult> MesmoContexto()
    {
        Task<int> total = _contexto.Pizzas.CountAsync();
        Task<decimal> maior =
            _contexto.Pizzas.MaxAsync(p => p.Preco);
        await Task.WhenAll(total, maior);
        return Ok(new { total = await total, maior = await maior });
    }
}
