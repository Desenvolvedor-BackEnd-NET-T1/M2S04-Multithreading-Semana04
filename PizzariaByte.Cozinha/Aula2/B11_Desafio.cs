// Desafio da aula 2: a mesa espera no máximo 1,5 s.
// Duas pizzas levam 1 s e a especial leva 3 s.
// Rode com: dotnet run -- desafio2
static class B11_Desafio
{
    // Dica: para poder ser cancelado, este método precisa receber
    // um CancellationToken e repassar ao Task.Delay.
    static async Task AssarAsync(string sabor, int segundos)
    {
        await Task.Delay(segundos * 1000);
        Log($"Pronta: {sabor}");
    }

    public static async Task Executar()
    {
        // 1. Crie um CancellationTokenSource que cancela em 1,5 segundo.

        // 2. Em um try, asse ao mesmo tempo com Task.WhenAll:
        //    Calabresa (1 s), Margherita (1 s) e Especial da casa (3 s).
        //    Se tudo terminar, Log("Mesa servida").

        // 3. No catch (OperationCanceledException): Log("Tempo esgotado: a especial foi cancelada");

        // 4. No finally: Log("Forno desligado");

        await Task.CompletedTask; // pode apagar esta linha quando escrever o seu código
    }
}
