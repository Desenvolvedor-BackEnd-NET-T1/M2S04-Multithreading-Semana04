// Pergunta: o que acontece sem o Join?
static class A03_SemJoin
{
    public static void Executar()
    {
        var t1 = new Thread(() => PrepararPizza("Calabresa"));
        var t2 = new Thread(() => PrepararPizza("Margherita"));
        t1.Start();
        t2.Start();
        Log("Pedidos entregues");
    }
}
