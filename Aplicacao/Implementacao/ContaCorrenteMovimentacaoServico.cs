using System.Collections.Generic;
using Aplicacao.Interface;
using Dominio;
using Infraestrutura.Repositorio.Interface;

namespace Aplicacao.Implementacao
{
    public class ContaCorrenteMovimentacaoServico : IContaCorrenteMovimentacaoServico
    {
        private readonly IContaCorrenteMovimentacaoRepositorio _contaCorrenteMovimentacaoRepositorio;

        public ContaCorrenteMovimentacaoServico(IContaCorrenteMovimentacaoRepositorio contaCorrenteMovimentacaoRepositorio)
        {
            _contaCorrenteMovimentacaoRepositorio = contaCorrenteMovimentacaoRepositorio;
        }

        public IEnumerable<ContaCorrenteMovimentacaoDominio> Listar(int idContaCorrente) => _contaCorrenteMovimentacaoRepositorio.Listar(idContaCorrente);
    }
}