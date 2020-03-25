using System;
using Dominio.Enum;

namespace Dominio
{
    public class ContaCorrenteMovimentacaoDominio
    {
        public int IdContaCorrenteMovimentacao { get; private set; }
        public int IdContaCorrente { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataMovimentacao { get; private set; }

        public ContaCorrenteMovimentacaoDominio(int idContaCorrente, TipoMovimentacao tipoMovimentacao, decimal valor, DateTime dataMovimentacao)
        {
            if (idContaCorrente < 0)
                throw new ArgumentException("Identificador da conta corrente não informado.");

            if (tipoMovimentacao == TipoMovimentacao.NAO_INFORMADO)
                throw new ArgumentException("Tipo da movimentação não informado.");

            if (valor <= 0)
                throw new ArgumentException("Valor da movimentação deve ser maior que zero.");

            if (dataMovimentacao == DateTime.MinValue)
                throw new ArgumentException("Data da movimentação não informada.");

            IdContaCorrente = idContaCorrente;
            TipoMovimentacao = tipoMovimentacao;
            Valor = valor;
            DataMovimentacao = dataMovimentacao;
        }
    }
}