namespace PizzariaByte.Api.Services;

// Usado na comparação de carga (TesteController)
public class CardapioService
{
    public async Task<List<string>> BuscarSaboresAsync()
    {
        await Task.Delay(1000); // como uma consulta lenta
        return new List<string> { "Calabresa", "Margherita" };
    }
}
