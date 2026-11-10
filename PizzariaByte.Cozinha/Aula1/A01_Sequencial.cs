// Um pizzaiolo só: uma pizza depois da outra
static class A01_Sequencial
{
    public static void Executar()
    {
        PrepararPizza("Calabresa");
        PrepararPizza("Margherita");
        PrepararPizza("Portuguesa");
        Log("Pedidos entregues");
    }
}
