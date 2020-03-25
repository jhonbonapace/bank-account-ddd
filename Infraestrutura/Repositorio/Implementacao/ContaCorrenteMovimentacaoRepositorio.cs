using Dominio;
using MySql.Data.MySqlClient;
using Infraestrutura.Repositorio.Interface;
using System.Data;
using System.Collections.Generic;
using Dominio.Enum;

namespace Infraestrutura.Repositorio.Implementacao
{
    public class ContaCorrenteMovimentacaoRepositorio : IContaCorrenteMovimentacaoRepositorio
    {

        public IEnumerable<ContaCorrenteMovimentacaoDominio> Listar(int idContaCorrente)
        {
            List<ContaCorrenteMovimentacaoDominio> movimentos = new List<ContaCorrenteMovimentacaoDominio>();
            using (var connection = new MySqlConnection("server=remotemysql.com;port=3306;database=sz8WcgIHZl;user=sz8WcgIHZl;password=BnEsnygbWH"))
            {
                var sql = "SELECT TOP 1 ID_CONTA_CORRENTE, NUMERO_CONTA, NUMERO_AGENCIA, SALDO FROM CONTA_CORRENTE";
                
                using (var command = new MySqlCommand(sql, connection) { CommandType = CommandType.Text })
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movimentos.Add(new ContaCorrenteMovimentacaoDominio(
                                reader.GetInt32("ID_CONTA_CORRENTE"),
                                (TipoMovimentacao)reader.GetInt32("TIPO_MOVIMENTACAO"),
                                reader.GetDecimal("VALOR"),
                                reader.GetDateTime("DATA_MOVIMENTACAO")
                            ));
                        }
                    }
                }
            }

            return movimentos;
        }
    }
}