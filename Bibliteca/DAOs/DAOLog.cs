using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BlueBox
{
    internal class DAOLog
    {
        // conexão
        private ConexaoBD banco = new ConexaoBD();

        // REGISTRAR LOG
        public void RegistrarLog(
            int funcionarioCodigo,
            string acao,
            string tabelaAfetada,
            int registroAfetado,
            string descricao)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"INSERT INTO log_sistema
                    (
                        funcionario_codigo,
                        acao,
                        tabela_afetada,
                        registro_afetado_codigo,
                        descricao
                    )
                    VALUES
                    (
                        @funcionario_codigo,
                        @acao,
                        @tabela_afetada,
                        @registro_afetado_codigo,
                        @descricao
                    )";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue(
                        "@funcionario_codigo",
                        funcionarioCodigo);

                    comando.Parameters.AddWithValue(
                        "@acao",
                        acao);

                    comando.Parameters.AddWithValue(
                        "@tabela_afetada",
                        tabelaAfetada);

                    comando.Parameters.AddWithValue(
                        "@registro_afetado_codigo",
                        registroAfetado);

                    comando.Parameters.AddWithValue(
                        "@descricao",
                        descricao);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao registrar log: "
                    + erro.Message);
            }
        }//fim registrar log

        //Consultar 
        public DataTable ConsultarLogs()
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao =
                    banco.AbrirConexao())
                {
                    string sql = @"
            SELECT
                codigo,
                funcionario_codigo,
                acao,
                tabela_afetada,
                registro_afetado_codigo,
                descricao,
                data_hora
            FROM log_sistema
            ORDER BY data_hora DESC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, conexao);

                    adapter.Fill(tabela);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao consultar logs: "
                    + erro.Message);
            }

            return tabela;
        }
    }
}
