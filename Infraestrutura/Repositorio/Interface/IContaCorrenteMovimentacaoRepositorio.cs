using System.Collections.Generic;
using Dominio;

namespace Infraestrutura.Repositorio.Interface
{
    public interface IContaCorrenteMovimentacaoRepositorio
    {
        IEnumerable<ContaCorrenteMovimentacaoDominio> Listar(int idContaCorrente);
    }
}