// Desafio da aula 1: três atendentes (Tasks) registram 1000 vendas
// cada um no mesmo contador. O total precisa dar 3000.
// Rode com: dotnet run -- desafio1
static class A09_Desafio
{
    static int vendidas = 0;

    static void Atender()
    {
        for (int i = 0; i < 1000; i++)
            vendidas++;
    }

    public static void Executar()
    {
        // 1. Crie três atendentes com Task.Run(Atender).

        // 2. Espere os três com Task.WaitAll.

        // 3. Mostre o total: Log($"Vendidas: {vendidas}");

        // 4. Rode várias vezes. O total é sempre 3000? Se não for, proteja o contador.
    }
}
