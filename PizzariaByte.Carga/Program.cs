using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Ferramenta do instrutor: dispara N requisições ao mesmo tempo
// e mede quanto tempo a API leva para responder todas.
// Uso: dotnet run -- http://localhost:5227/api/teste/esperando 200
string url = args.Length > 0 ? args[0]
    : "http://localhost:5227/api/teste/esperando";
int quantidade = args.Length > 1 ? int.Parse(args[1]) : 100;

using var http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
await http.GetAsync(url); // aquece a API antes de medir

var relogio = Stopwatch.StartNew();
var pedidos = new List<Task<HttpResponseMessage>>();
for (int i = 0; i < quantidade; i++)
    pedidos.Add(http.GetAsync(url));

HttpResponseMessage[] respostas = await Task.WhenAll(pedidos);
relogio.Stop();

int ok = respostas.Count(r => r.IsSuccessStatusCode);
Console.WriteLine($"{quantidade} requisições, {ok} com sucesso");
Console.WriteLine($"Tempo total: {relogio.Elapsed.TotalSeconds:0.0} s");
