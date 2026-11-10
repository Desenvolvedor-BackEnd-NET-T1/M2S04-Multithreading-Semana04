// O mesmo contador, agora com lock: um caixa por vez
static class A05_CorridaLock
{
    static int vendidas = 0;
    static readonly object trava = new();

    static void Vender()
    {
        for (int i = 0; i < 100_000; i++)
        {
            lock (trava) // só uma thread entra aqui
            {
                vendidas++;
            }
        }
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
