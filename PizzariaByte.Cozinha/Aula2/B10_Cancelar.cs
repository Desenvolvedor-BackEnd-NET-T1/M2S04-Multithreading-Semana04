// CancellationToken: o cliente desistiu depois de 2 s
static class B10_Cancelar
{
    static async Task AssarAsync(string sabor,
        CancellationToken token)
    {
        Log($"Forno: {sabor}");
        await Task.Delay(5000, token); // para se cancelarem
        Log($"Pronta: {sabor}");
    }

    public static async Task Executar()
    {
        // cancela sozinho depois de 2 s
        using var cts = new CancellationTokenSource(
            TimeSpan.FromSeconds(2));
        try
        {
            await AssarAsync("Calabresa", cts.Token);
        }
        catch (OperationCanceledException)
        {
            Log("Cliente desistiu: pedido cancelado");
        }
        finally
        {
            Log("Forno desligado"); // roda sempre
        }
    }
}
