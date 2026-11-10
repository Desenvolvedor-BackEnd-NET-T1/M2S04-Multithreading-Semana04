// Começa as três e só depois espera: Task.WhenAll
static class B03_WhenAll
{
    public static async Task Executar()
    {
        Task a = AssarAsync("Calabresa");
        Task b = AssarAsync("Margherita");
        Task c = AssarAsync("Portuguesa");

        await Task.WhenAll(a, b, c); // espera as três
        Log("Pedidos entregues");

        // Com valores: o WhenAll devolve um array
        decimal[] contas = await Task.WhenAll(
            CalcularTotalAsync(2), CalcularTotalAsync(1));
        Log($"Mesas: R$ {contas[0]} e R$ {contas[1]}");
    }
}
