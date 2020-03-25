using Aplicacao.Interface;
using Dominio;
using Infraestrutura.Repositorio.Interface;

namespace Aplicacao.Implementacao
{
    public class ContaCorrenteServico : IContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly ContaCorrenteDominio _contaCorrente;

        public ContaCorrenteServico(IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;

            _contaCorrente = _contaCorrenteRepositorio.Buscar();
        }

        public void Depositar(decimal valor)
        {
            var contaCorrenteMovimentacao = _contaCorrente.Depositar(valor);
            _contaCorrenteRepositorio.AtualizarMovimento(_contaCorrente, contaCorrenteMovimentacao);
        }

        public void Pagar(decimal valor)
        {
            var contaCorrenteMovimentacao = _contaCorrente.Pagar(valor);
            _contaCorrenteRepositorio.AtualizarMovimento(_contaCorrente, contaCorrenteMovimentacao);
        }

        public void Retirar(decimal valor)
        {
            var contaCorrenteMovimentacao = _contaCorrente.Retirar(valor);
            _contaCorrenteRepositorio.AtualizarMovimento(_contaCorrente, contaCorrenteMovimentacao);
        }
    }
}