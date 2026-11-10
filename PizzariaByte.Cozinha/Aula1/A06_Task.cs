// Task: uma tarefa que roda em uma thread emprestada do pool
static class A06_Task
{
    static decimal CalcularTotal(int pizzas)
    {
        Log("Calculando a conta...");
        Thread.Sleep(500);
        return pizzas * 45.90m;
    }

    public static void Executar()
    {
        Task forno = Task.Run(() => PrepararPizza("Calabresa"));

        Task<decimal> conta = Task.Run(() => CalcularTotal(3));
        Log("Garçom anota a bebida");

        // Result: espera e pega o valor
        decimal total = conta.Result;
        Log($"Total: R$ {total}");

        forno.Wait(); // espera a pizza
        Log("Pedido entregue");
    }
}
