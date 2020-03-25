using Dominio;

namespace Infraestrutura.Repositorio.Interface
{
    public interface IContaCorrenteRepositorio
    {
        void AtualizarMovimento(ContaCorrenteDominio contaCorrente, ContaCorrenteMovimentacaoDominio contaCorrenteMovimentacao);
        ContaCorrenteDominio Buscar();
    }
}