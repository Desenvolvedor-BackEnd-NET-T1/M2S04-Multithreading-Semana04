// Várias tarefas de uma vez, esperando todas
static class A07_WaitAll
{
    public static void Executar()
    {
        Task[] tarefas =
        {
            Task.Run(() => PrepararPizza("Calabresa")),
            Task.Run(() => PrepararPizza("Margherita")),
            Task.Run(() => PrepararPizza("Portuguesa")),
        };

        Task.WaitAll(tarefas); // espera as três
        Log("Pedidos entregues");
    }
}
