using Dominio;
using MySql.Data.MySqlClient;
using Infraestrutura.Repositorio.Interface;
using System.Data;

namespace Infraestrutura.Repositorio.Implementacao
{
    public partial class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {

        public void AtualizarMovimento(ContaCorrenteDominio contaCorrente, ContaCorrenteMovimentacaoDominio contaCorrenteMovimentacao)
        {
            using (var connection = new MySqlConnection("server=remotemysql.com;port=3306;database=sz8WcgIHZl;user=sz8WcgIHZl;password=BnEsnygbWH"))
            {
                var sql = @"
                ALTER TABLE CONTA_CORRENTE SET SALDO = @SALDO WHERE ID_CONTA_CORRENTE = @ID_CONTA_CORRENTE;

                INSERT INTO CONTA_CORRENTE_MOVIMENTACAO (ID_CONTA_CORRENTE, TIPO_MOVIMENTACAO, VALOR, DATA_MOVIMENTACAO)
                VALUES
                (@ID_CONTA_CORRENTE, @TIPO_MOVIMENTACAO, @VALOR, @DATA_MOVIMENTACAO);";
                
                using (var command = new MySqlCommand(sql, connection) { CommandType = CommandType.Text })
                {
                    command.Parameters.Add("@SALDO", MySqlDbType.Decimal).Value = contaCorrente.Saldo;
                    command.Parameters.Add("@ID_CONTA_CORRENTE", MySqlDbType.Int32).Value = contaCorrente.IdContaCorrente;
                    command.Parameters.Add("@TIPO_MOVIMENTACAO", MySqlDbType.Int32).Value = (int)contaCorrenteMovimentacao.TipoMovimentacao;
                    command.Parameters.Add("@VALOR", MySqlDbType.Decimal).Value = contaCorrenteMovimentacao.Valor;
                    command.Parameters.Add("@DATA_MOVIMENTACAO", MySqlDbType.DateTime).Value = contaCorrenteMovimentacao.DataMovimentacao;
                }
            }
        }

        public ContaCorrenteDominio Buscar()
        {
            ContaCorrenteDominio contaCorrente = null;
            using (var connection = new MySqlConnection("server=remotemysql.com;port=3306;database=sz8WcgIHZl;user=sz8WcgIHZl;password=BnEsnygbWH"))
            {
                var sql = "SELECT TOP 1 ID_CONTA_CORRENTE, NUMERO_CONTA, NUMERO_AGENCIA, SALDO FROM CONTA_CORRENTE";
                
                using (var command = new MySqlCommand(sql, connection) { CommandType = CommandType.Text })
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contaCorrente = new ContaCorrenteDominio(
                                reader.GetInt32("ID_CONTA_CORRENTE"),
                                reader.GetString("NUMERO_CONTA"),
                                reader.GetString("NUMERO_AGENCIA"),
                                reader.GetDecimal("SALDO")
                            );
                        }
                    }
                }
            }

            return contaCorrente;
        }
    }
}