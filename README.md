# Pizzaria Byte, semana 04 (M2S04)

Projeto da turma para as aulas de multithreading e programação assíncrona.

Requisitos: .NET 10 SDK e SQL Server (LocalDB ou Express).

```
dotnet build PizzariaByte.slnx
```

## PizzariaByte.Cozinha (aulas 1, 2 e 3)

Cada exemplo roda pelo nome. Sem nome, aparece a lista:

```
cd PizzariaByte.Cozinha
dotnet run -- threads
```

Os exercícios estão vazios, com o passo a passo em comentários:

| Exercício | Arquivo | Como rodar |
|---|---|---|
| Prática da aula 1 | Aula1/A08_Pratica.cs | `dotnet run -- pratica1` |
| Desafio da aula 1 | Aula1/A09_Desafio.cs | `dotnet run -- desafio1` |
| Prática da aula 2 | Aula2/B05_Pratica.cs | `dotnet run -- pratica2` |
| Desafio da aula 2 | Aula2/B11_Desafio.cs | `dotnet run -- desafio2` |

## PizzariaByte.Api (aula 3)

```
cd PizzariaByte.Api
dotnet run
```

Abra http://localhost:5227/swagger. O banco é criado na primeira execução.

Se você usa o SQL Server Express em vez do LocalDB, troque o `Server` da
connection string em `appsettings.json` por `.\\SQLEXPRESS`.

Na Mão na massa 3 você vai converter o `PizzasSincronoController` (ou um
controller da sua API do módulo 1) para async.
