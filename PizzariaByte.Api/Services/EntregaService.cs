namespace PizzariaByte.Api.Services;

// Simulam serviços externos lentos (1 s cada), como uma API de mapas
// para o frete e outra de promoções. Na semana que vem, chamadas assim
// viram requisições de verdade com HttpClient.
public interface IEntregaService
{
    Task<decimal> CalcularFreteAsync(string bairro);
}

public interface IPromocaoService
{
    Task<string> BuscarPromocaoDoDiaAsync();
}

public class EntregaService : IEntregaService
{
    public async Task<decimal> CalcularFreteAsync(string bairro)
    {
        await Task.Delay(1000);
        return bairro == "Centro" ? 5m : 12m;
    }
}

public class PromocaoService : IPromocaoService
{
    public async Task<string> BuscarPromocaoDoDiaAsync()
    {
        await Task.Delay(1000);
        return "Terça da Calabresa: 20% de desconto";
    }
}
