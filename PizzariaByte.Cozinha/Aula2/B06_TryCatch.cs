// try/catch com await: o erro chega no catch normalmente.
// AssarComGasAsync está no Cozinha.cs.
static class B06_TryCatch
{
    public static async Task Executar()
    {
        try
        {
            await AssarComGasAsync("Calabresa", temGas: false);
            Log("Pedido entregue");
        }
        catch (InvalidOperationException ex)
        {
            Log($"Erro: {ex.Message}. Avisar o cliente.");
        }
    }
}
