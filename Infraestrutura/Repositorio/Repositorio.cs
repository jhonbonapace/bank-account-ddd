using System.Data;
using MySql.Data.MySqlClient;

namespace Infraestrutura.Repositorio
{
    public class Repositorio
    {
        public static void Setup()
        {
            using (var connection = new MySqlConnection("server=remotemysql.com;port=3306;database=sz8WcgIHZl;user=sz8WcgIHZl;password=BnEsnygbWH"))
            {
                var sql = @"
                    DROP TABLE IF EXISTS CONTA_CORRENTE;
                    DROP TABLE IF EXISTS CONTA_CORRENTE_MOVIMENTO;

                    CREATE TABLE CONTA_CORRENTE
                    (
                        ID_CONTA_CORRENTE INT NOT NULL AUTO_INCREMENT,
                        NUMERO_CONTA NVARCHAR(20) NOT NULL,
                        NUMERO_AGENCIA NVARCHAR(5) NOT NULL,
                        SALDO DECIMAL(18,2) NOT NULL
                    );

                    ALTER TABLE CONTA_CORRENTE
                    ADD CONSTRAINT PK_CONTA_CORRENTE PRIMARY KEY (ID_CONTA_CORRENTE);
                    
                    CREATE TABLE CONTA_CORRENTE_MOVIMENTO
                    (
                        ID_CONTA_CORRENTE_MOVIMENTO INT NOT NULL AUTO_INCREMENT,
                        ID_CONTA_CORRENTE INT NOT NULL,
                        TIPO_MOVIMENTACAO INT NOT NULL,
                        VALOR DECIMAL(18,2) NOT NULL,
                        DATA_MOVIMENTACAO DATETIME NOT NULL
                    );

                    ALTER TABLE CONTA_CORRENTE_MOVIMENTO
                    ADD 
                        CONSTRAINT PK_CONTA_CORRENTE_MOVIMENTO PRIMARY KEY (ID_CONTA_CORRENTE_MOVIMENTO),
                        CONSTRAINT FK_CONTA_CORRENT_CONTA_CORRENTE_MOVIMENTO FOREIGN KEY (ID_CONTA_CORRENTE) REFERENCES CONTA_CORRENTE (ID_CONTA_CORRENTE);

                    INSERT INTO CONTA_CORRENTE
                    (NUMERO_CONTA, NUMERO_AGENCIA, SALDO)
                    VALUES
                    ('123456', '1234', 0);
                    ";
                
                using (var command = new MySqlCommand(sql, connection) { CommandType = CommandType.Text })
                {
                    command.ExecuteNonQuery();
                }
            }
        } 
    }
}