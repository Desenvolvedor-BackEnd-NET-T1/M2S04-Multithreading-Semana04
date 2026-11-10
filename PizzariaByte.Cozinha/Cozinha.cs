using System.Diagnostics;

// Ferramentas usadas por todos os exemplos da semana.
static class Cozinha
{
    // Cronômetro: o tempo desde o início do exemplo
    public static readonly Stopwatch Relogio = new();

    // Escreve assim: 1,0s [T4] texto
    public static void Log(string texto)
    {
        double s = Relogio.Elapsed.TotalSeconds;
        int t = Environment.CurrentManagedThreadId;
        Console.WriteLine($"{s:0.0}s [T{t}] {texto}");
    }

    // 1 segundo no forno (o Sleep TRAVA a thread)
    public static void PrepararPizza(string sabor)
    {
        Log($"Começou {sabor}");
        Thread.Sleep(1000);
        Log($"Pronta {sabor}");
    }

    // Aula 2. async: o método pode usar await.
    // Task: avisa quando terminar.
    public static async Task AssarAsync(string sabor)
    {
        Log($"Forno: {sabor}");
        await Task.Delay(1000); // espera 1 s sem travar
        Log($"Pronta: {sabor}");
    }

    // Task<decimal>: avisa quando terminar e entrega um valor
    public static async Task<decimal> CalcularTotalAsync(
        int pizzas)
    {
        await Task.Delay(500);
        return pizzas * 45.90m;
    }

    // Sem gás, o forno lança uma exceção
    public static async Task AssarComGasAsync(
        string sabor, bool temGas)
    {
        Log($"Forno: {sabor}");
        await Task.Delay(500);
        if (!temGas)
            throw new InvalidOperationException("Forno sem gás");
        Log($"Pronta: {sabor}");
    }
}
