// Um pedido de verdade: algumas etapas dependem de outras
static class B04_Pedido
{
    static async Task<string> PrepararPizzaAsync(
        string sabor)
    {
        Log($"Abrindo a massa: {sabor}");
        await Task.Delay(1000);
        Log($"No forno: {sabor}");
        await Task.Delay(2000); // só assa depois da massa
        return $"Pizza de {sabor}";
    }

    static async Task<string> GelarBebidaAsync(string bebida)
    {
        Log($"Gelando: {bebida}");
        await Task.Delay(1000);
        return bebida;
    }

    public static async Task Executar()
    {
        // pizza e bebida não dependem uma da outra
        Task<string> pizza =
            PrepararPizzaAsync("Calabresa");
        Task<string> bebida = GelarBebidaAsync("Guaraná");

        string p = await pizza;
        string b = await bebida;
        Log($"Saiu para entrega: {p} e {b}");
    }
}
