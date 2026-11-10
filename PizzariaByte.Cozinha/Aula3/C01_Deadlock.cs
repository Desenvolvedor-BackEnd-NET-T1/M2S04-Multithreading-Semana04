// Deadlock: cada pizzaiolo segura uma coisa e espera a outra
static class C01_Deadlock
{
    static readonly object forno = new();
    static readonly object pa = new();

    static void PizzaioloA()
    {
        lock (forno)
        {
            Log("A pegou o forno, quer a pá");
            Thread.Sleep(100);
            lock (pa) { Log("A assou a pizza"); }
        }
    }

    static void PizzaioloB()
    {
        lock (pa)
        {
            Log("B pegou a pá, quer o forno");
            Thread.Sleep(100);
            lock (forno) { Log("B assou a pizza"); }
        }
    }

    public static void Executar()
    {
        var a = new Thread(PizzaioloA) { IsBackground = true };
        var b = new Thread(PizzaioloB) { IsBackground = true };
        a.Start();
        b.Start();

        // Join com limite: espera no máximo 3 s
        bool terminou = a.Join(3000) && b.Join(3000);
        Log(terminou ? "Tudo certo" : "Travou: deadlock!");
    }
}
