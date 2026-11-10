// await um depois do outro: cada pizza espera a anterior
static class B02_EmFila
{
    public static async Task Executar()
    {
        await AssarAsync("Calabresa");
        await AssarAsync("Margherita");
        await AssarAsync("Portuguesa");
        Log("Pedidos entregues");
    }
}
