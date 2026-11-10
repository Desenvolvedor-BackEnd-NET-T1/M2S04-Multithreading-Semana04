// WhenAll com duas falhas: o catch recebe a primeira,
// a Task guarda todas
static class B08_WhenAllErro
{
    public static async Task Executar()
    {
        Task todas = Task.WhenAll(
            AssarComGasAsync("Calabresa", true),
            AssarComGasAsync("Margherita", false),
            AssarComGasAsync("Portuguesa", false));
        try
        {
            await todas;
        }
        catch (Exception ex)
        {
            Log($"catch: {ex.Message}");
            int falhas = todas.Exception!.InnerExceptions.Count;
            Log($"Falhas guardadas na Task: {falhas}");
        }
    }
}
