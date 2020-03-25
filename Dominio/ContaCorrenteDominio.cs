using System;
using System.Collections.Generic;
using Dominio.Enum;

namespace Dominio
{
    public class ContaCorrenteDominio
    {
        public int IdContaCorrente { get; private set; }
        public string NumeroConta { get; private set; }
        public string Agencia { get; private set; }
        public decimal Saldo { get; private set; }
        public List<ContaCorrenteMovimentacaoDominio> Movimentacoes { get; private set; }

        public ContaCorrenteDominio(int idContaCorrente, string numeroConta, string agencia, decimal saldo)
        {
            if (idContaCorrente < 0)
                throw new ArgumentException("Identificador da conta corrente não informado.");

            if (string.IsNullOrWhiteSpace(numeroConta))
                throw new ArgumentException("Número da conta corrente não informado.");

            if (string.IsNullOrWhiteSpace(agencia))
                throw new ArgumentException("Agência da conta corrente não informada.");

            if (saldo < 0)
                throw new ArgumentException("Saldo da conta corrente deve ser maior ou igual a zero.");

            IdContaCorrente = idContaCorrente;
            NumeroConta = numeroConta;
            Agencia = agencia;
            Saldo = saldo;
            Movimentacoes = new List<ContaCorrenteMovimentacaoDominio>();
        }

        public ContaCorrenteMovimentacaoDominio Retirar(decimal valor)
        {
            if (temLimite(valor))
                return new ContaCorrenteMovimentacaoDominio(IdContaCorrente, TipoMovimentacao.RETIRADA, valor, DateTime.Now);
            else
                throw new InvalidOperationException("Saldo indisponível para operação.");
        }

        public ContaCorrenteMovimentacaoDominio Pagar(decimal valor)
        {
            if (temLimite(valor))
                return new ContaCorrenteMovimentacaoDominio(IdContaCorrente, TipoMovimentacao.PAGAMENTO, valor, DateTime.Now);
            else
                throw new InvalidOperationException("Saldo indisponível para operação.");
        }

        public ContaCorrenteMovimentacaoDominio Depositar(decimal valor) => new ContaCorrenteMovimentacaoDominio(IdContaCorrente, TipoMovimentacao.DEPOSITO, valor, DateTime.Now);

        private bool temLimite(decimal valor) => Saldo - valor >= 0;
    }
}