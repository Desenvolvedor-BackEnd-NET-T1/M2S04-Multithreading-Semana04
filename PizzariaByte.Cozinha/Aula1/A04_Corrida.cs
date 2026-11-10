// Dois caixas somando no mesmo contador, sem cuidado
static class A04_Corrida
{
    static int vendidas = 0;

    static void Vender()
    {
        for (int i = 0; i < 100_000; i++)
            vendidas++; // ler, somar 1, gravar
    }

    public static void Executar()
    {
        var caixa1 = new Thread(Vender);
        var caixa2 = new Thread(Vender);
        caixa1.Start();
        caixa2.Start();
        caixa1.Join();
        caixa2.Join();
        Log($"Vendidas: {vendidas} de 200000");
    }
}
