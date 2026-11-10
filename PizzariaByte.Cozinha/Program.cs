// Escolha o exemplo pelo nome: dotnet run -- sequencial
// Sem nome, mostra a lista.
Console.OutputEncoding = System.Text.Encoding.UTF8; // acentos no terminal

var exemplos = new Dictionary<string, Func<Task>>
{
    // Aula 1: threads e tasks
    ["sequencial"] = () => Rodar(A01_Sequencial.Executar),
    ["threads"] = () => Rodar(A02_Threads.Executar),
    ["sem-join"] = () => Rodar(A03_SemJoin.Executar),
    ["corrida"] = () => Rodar(A04_Corrida.Executar),
    ["corrida-lock"] = () => Rodar(A05_CorridaLock.Executar),
    ["task"] = () => Rodar(A06_Task.Executar),
    ["waitall"] = () => Rodar(A07_WaitAll.Executar),
    ["pratica1"] = () => Rodar(A08_Pratica.Executar),
    ["desafio1"] = () => Rodar(A09_Desafio.Executar),

    // Aula 2: async/await e exceções
    ["async"] = B01_Async.Executar,
    ["em-fila"] = B02_EmFila.Executar,
    ["whenall"] = B03_WhenAll.Executar,
    ["pedido"] = B04_Pedido.Executar,
    ["pratica2"] = B05_Pratica.Executar,
    ["try-catch"] = B06_TryCatch.Executar,
    ["sem-await"] = B07_SemAwait.Executar,
    ["whenall-erro"] = B08_WhenAllErro.Executar,
    ["async-void"] = B09_AsyncVoid.Executar,
    ["cancelar"] = B10_Cancelar.Executar,
    ["desafio2"] = B11_Desafio.Executar,

    // Aula 3: deadlock e boas práticas
    ["deadlock"] = () => Rodar(C01_Deadlock.Executar),
    ["deadlock-corrigido"] = () => Rodar(C02_DeadlockCorrigido.Executar),
    ["semaforo"] = C03_Semaforo.Executar,
};

if (args.Length == 0 || !exemplos.ContainsKey(args[0]))
{
    Console.WriteLine("Use: dotnet run -- <exemplo>");
    foreach (string nome in exemplos.Keys)
        Console.WriteLine("  " + nome);
    return;
}

Relogio.Restart();
await exemplos[args[0]]();

// Transforma um exemplo síncrono (void) em Task, para caber no dicionário
static Task Rodar(Action exemplo)
{
    exemplo();
    return Task.CompletedTask;
}
