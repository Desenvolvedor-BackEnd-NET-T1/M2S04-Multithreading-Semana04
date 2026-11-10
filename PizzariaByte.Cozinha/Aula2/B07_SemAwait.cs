// Pergunta: e se esquecer o await?
static class B07_SemAwait
{
    public static async Task Executar()
    {
        Task forno = Task.CompletedTask;
        try
        {
            forno = AssarComGasAsync("Calabresa", false);
            Log("Pedido entregue");
        }
        catch (InvalidOperationException ex)
        {
            Log($"Erro: {ex.Message}");
        }

        await Task.Delay(1000);
        Log($"Situação da tarefa: {forno.Status}");
    }
}
