// async void: ninguém consegue esperar nem capturar o erro
static class B09_AsyncVoid
{
    static async void AvisarClienteAsync()
    {
        await Task.Delay(300);
        throw new Exception("SMS não enviado");
    }

    public static async Task Executar()
    {
        try
        {
            AvisarClienteAsync(); // não dá para usar await
            Log("Cliente avisado?");
        }
        catch (Exception ex)
        {
            Log($"Erro tratado: {ex.Message}");
        }

        await Task.Delay(1000);
        Log("Esta linha não aparece");
    }
}
