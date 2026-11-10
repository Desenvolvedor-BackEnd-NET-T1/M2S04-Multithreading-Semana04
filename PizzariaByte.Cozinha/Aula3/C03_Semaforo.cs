// SemaphoreSlim: o forno só tem 2 vagas
static class C03_Semaforo
{
    static readonly SemaphoreSlim forno = new(2); // 2 vagas

    static async Task AssarAsync(string sabor)
    {
        await forno.WaitAsync(); // espera uma vaga
        try
        {
            Log($"Entrou: {sabor}");
            await Task.Delay(1000);
            Log($"Saiu: {sabor}");
        }
        finally
        {
            forno.Release(); // libera a vaga
        }
    }

    public static async Task Executar()
    {
        string[] sabores = { "Calabresa", "Margherita",
            "Portuguesa", "Atum", "Frango" };

        var tarefas = new List<Task>();
        foreach (string sabor in sabores)
            tarefas.Add(AssarAsync(sabor));

        await Task.WhenAll(tarefas);
        Log("Pedidos entregues");
    }
}
