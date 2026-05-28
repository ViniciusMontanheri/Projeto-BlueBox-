using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBox
{
    internal class DAOEntregador
    {
        // conexão
        private ConexaoBD banco = new ConexaoBD();

        // CONSULTAR
        public DataTable ConsultarEntregadores()
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT codigo, nome, cpf,
                                   veiculo, cnh, login
                                   FROM entregador
                                   WHERE ativo = true";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, conexao);

                    adapter.Fill(tabela);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao consultar: " + erro.Message);
            }

            return tabela;
        }//fim consultar

        // BUSCAR
        public DataTable BuscarEntregador(int codigo)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT * FROM entregador
                                   WHERE codigo = @codigo
                                   AND ativo = true";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(comando);

                    adapter.Fill(tabela);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar: " + erro.Message);
            }

            return tabela;
        }//fim buscar

        // INSERIR
        public int InserirEntregador(
            string nome,
            string cpf,
            string veiculo,
            string cnh,
            string login,
            string senha)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    // Limpando CPF
                    cpf = cpf.Replace(".", "")
                             .Replace("-", "");

                    // Limpando CNH
                    cnh = cnh.Replace(".", "")
                             .Replace("-", "");

                    string sql = @"INSERT INTO entregador
                    (nome, cpf, veiculo, cnh, login, senha)
                    VALUES
                    (@nome, @cpf, @veiculo, @cnh, @login, @senha)";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@veiculo", veiculo);
                    comando.Parameters.AddWithValue("@cnh", cnh);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);

                    comando.ExecuteNonQuery();

                    int codigoGerado = Convert.ToInt32(comando.LastInsertedId);

                    MessageBox.Show("Entregador cadastrado com sucesso!");

                    return codigoGerado;
                }
            }
            catch (MySqlException erro)
            {
                if (erro.Number == 1062)
                {
                    MessageBox.Show("CPF, CNH ou login já cadastrado!");
                }
                else
                {
                    MessageBox.Show("Erro no banco: " + erro.Message);
                }

                return 0;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro geral: " + erro.Message);
            }

            return 0;
        }//fim inserir

        // ATUALIZAR
        public string AtualizarEntregador(
            int codigo,
            string nome,
            string cpf,
            string veiculo,
            string cnh,
            string login,
            string senha)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    // Limpando CPF
                    cpf = cpf.Replace(".", "")
                             .Replace("-", "");

                    // Limpando CNH
                    cnh = cnh.Replace(".", "")
                             .Replace("-", "");

                    string sql = @"UPDATE entregador
                    SET nome = @nome,
                        cpf = @cpf,
                        veiculo = @veiculo,
                        cnh = @cnh,
                        login = @login,
                        senha = @senha
                    WHERE codigo = @codigo
                    AND ativo = true";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@veiculo", veiculo);
                    comando.Parameters.AddWithValue("@cnh", cnh);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);

                    int linhasAfetadas =
                        comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Entregador atualizado com sucesso!";
                    }
                    else
                    {
                        return "Nenhuma alteração foi feita.";
                    }
                }
            }
            catch (Exception erro)
            {
                return "Erro ao atualizar: " + erro.Message;
            }
        }//fim atualizar

        // DELETAR
        public string DeletarEntregador(int codigo)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"UPDATE entregador
                                   SET ativo = false
                                   WHERE codigo = @codigo
                                   AND ativo = true";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);

                    int linhasAfetadas =
                        comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Entregador desativado com sucesso!";
                    }
                    else
                    {
                        return "Entregador não encontrado.";
                    }
                }
            }
            catch (Exception erro)
            {
                return "Erro ao excluir: " + erro.Message;
            }
        }//fim deletar

        // VERIFICAR SE EXISTE ENTREGADOR INATIVO
        public bool EntregadorInativoExiste(string cpf)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT COUNT(*) 
                           FROM entregador
                           WHERE cpf = @cpf
                           AND ativo = false";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@cpf", cpf);

                    int quantidade =
                        Convert.ToInt32(comando.ExecuteScalar());

                    return quantidade > 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao verificar entregador: " + erro.Message);
                return false;
            }
        }//fim verificar inativo


        // REATIVAR ENTREGADOR
        public void ReativarEntregador(
            string nome,
            string cpf,
            string veiculo,
            string cnh,
            string login,
            string senha)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"UPDATE entregador
                           SET nome = @nome,
                               veiculo = @veiculo,
                               cnh = @cnh,
                               login = @login,
                               senha = @senha,
                               ativo = true
                           WHERE cpf = @cpf";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@veiculo", veiculo);
                    comando.Parameters.AddWithValue("@cnh", cnh);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Entregador reativado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao reativar entregador: " + erro.Message);
            }
        }//fim reativar


    }
}
