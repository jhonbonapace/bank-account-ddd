using System.Collections.Generic;
using Dominio;

namespace Aplicacao.Interface
{
    public interface IContaCorrenteMovimentacaoServico
    {
         IEnumerable<ContaCorrenteMovimentacaoDominio> Listar(int idContaCorrente);
    }
}