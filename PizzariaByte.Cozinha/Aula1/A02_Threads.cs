// Três pizzaiolos: uma thread para cada pizza
static class A02_Threads
{
    public static void Executar()
    {
        var t1 = new Thread(() => PrepararPizza("Calabresa"));
        var t2 = new Thread(() => PrepararPizza("Margherita"));
        var t3 = new Thread(() => PrepararPizza("Portuguesa"));

        t1.Start(); // começa a trabalhar
        t2.Start();
        t3.Start();

        t1.Join(); // espera essa thread terminar
        t2.Join();
        t3.Join();
        Log("Pedidos entregues");
    }
}
