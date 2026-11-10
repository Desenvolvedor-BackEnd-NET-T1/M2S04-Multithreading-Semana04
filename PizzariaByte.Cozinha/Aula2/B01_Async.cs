// async/await: esperar sem travar a thread.
// AssarAsync e CalcularTotalAsync estão no Cozinha.cs.
static class B01_Async
{
    public static async Task Executar()
    {
        await AssarAsync("Calabresa");
        decimal total = await CalcularTotalAsync(3);
        Log($"Total: R$ {total}");
    }
}
