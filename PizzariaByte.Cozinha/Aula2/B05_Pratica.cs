// Prática da aula 2: a prática da aula 1 em versão async.
// Quatro sabores em um laço, sem criar threads. Cerca de 1 s.
// Rode com: dotnet run -- pratica2
static class B05_Pratica
{
    public static async Task Executar()
    {
        // 1. Crie o array com quatro sabores e uma List<Task> vazia.

        // 2. Em um foreach, adicione na lista AssarAsync(sabor).
        //    Não use await dentro do laço.

        // 3. Depois do laço: await Task.WhenAll(tarefas);
        //    e Log("Pedidos entregues");

        await Task.CompletedTask; // pode apagar esta linha quando escrever o seu código
    }
}
