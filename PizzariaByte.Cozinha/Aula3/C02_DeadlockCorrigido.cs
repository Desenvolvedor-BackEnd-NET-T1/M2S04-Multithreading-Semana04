// A correção: todo mundo pega na mesma ordem (forno, depois pá)
static class C02_DeadlockCorrigido
{
    static readonly object forno = new();
    static readonly object pa = new();

    static void Pizzaiolo(string nome)
    {
        lock (forno)
        {
            lock (pa)
            {
                Log($"{nome} assou a pizza");
                Thread.Sleep(100);
            }
        }
    }

    public static void Executar()
    {
        var a = new Thread(() => Pizzaiolo("A"));
        var b = new Thread(() => Pizzaiolo("B"));
        a.Start();
        b.Start();

        bool terminou = a.Join(3000) && b.Join(3000);
        Log(terminou ? "Tudo certo" : "Travou: deadlock!");
    }
}
