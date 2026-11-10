using Microsoft.AspNetCore.Mvc;
using PizzariaByte.Api.Data;
using PizzariaByte.Api.Models;

namespace PizzariaByte.Api.Controllers;

// Ponto de partida da prática da aula 3: tudo síncrono.
// Os alunos convertem para a versão do PizzasController.
[ApiController]
[Route("api/pizzas-sincrono")]
public class PizzasSincronoController : ControllerBase
{
    private readonly PizzariaContext _contexto;

    public PizzasSincronoController(PizzariaContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> Listar()
    {
        return _contexto.Pizzas.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Buscar(int id)
    {
        Pizza? pizza = _contexto.Pizzas.Find(id);
        if (pizza is null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public ActionResult<Pizza> Criar(Pizza pizza)
    {
        _contexto.Pizzas.Add(pizza);
        _contexto.SaveChanges();
        return CreatedAtAction(nameof(Buscar),
            new { id = pizza.Id }, pizza);
    }
}
