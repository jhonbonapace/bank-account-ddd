namespace Aplicacao.Interface
{
    public interface IContaCorrenteServico
    {
         void Retirar(decimal valor);
         void Depositar(decimal valor);
         void Pagar(decimal valor);
    }
}