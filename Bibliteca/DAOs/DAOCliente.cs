using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace BlueBox
{
    internal class DAOCliente
    {
        // Conexão com o banco
        private ConexaoBD banco = new ConexaoBD();

        // Inserir cliente
        public void InserirCliente(
            string nome,
            string cpf,
            string telefone,
            string endereco)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    // Limpando CPF e telefone
                    cpf = cpf.Replace(".", "").Replace("-", "");

                    telefone = telefone.Replace("(", "")
                                         .Replace(")", "")
                                         .Replace("-", "")
                                         .Replace(" ", "");

                    string sql = @"INSERT INTO cliente
                    (nome, cpf, telefone, endereco)
                    VALUES
                    (@nome, @cpf, @telefone, @endereco)";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@endereco", endereco);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!");
                }
            }
            catch (MySqlException erro)
            {
                if (erro.Number == 1062)
                {
                    MessageBox.Show("CPF já cadastrado!");
                }
                else
                {
                    MessageBox.Show("Erro no banco: " + erro.Message);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro geral: " + erro.Message);
            }
        }//fim do inserir

        // Consultar clientes
        public DataTable ConsultarClientes()
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT codigo, nome, cpf,
                                   telefone, endereco
                                   FROM cliente";

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

        // Buscar cliente
        public DataTable BuscarCliente(int codigo)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT * FROM cliente
                                   WHERE codigo = @codigo";

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

        // Deletar cliente
        public string DeletarCliente(int codigo)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"DELETE FROM cliente
                                   WHERE codigo = @codigo";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);

                    int linhasAfetadas =
                        comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Cliente excluído com sucesso!";
                    }
                    else
                    {
                        return "Cliente não encontrado.";
                    }
                }
            }
            catch (Exception erro)
            {
                return "Erro ao excluir: " + erro.Message;
            }
        }//fim deletar

        // Atualizar cliente
        public string AtualizarCliente(
            int codigo,
            string nome,
            string cpf,
            string telefone,
            string endereco)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"UPDATE cliente
                           SET nome = @nome,
                               cpf = @cpf,
                               telefone = @telefone,
                               endereco = @endereco
                           WHERE codigo = @codigo";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@endereco", endereco);

                    int linhasAfetadas =
                        comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Cliente atualizado com sucesso!";
                    }
                    else
                    {
                        return "Cliente não encontrado.";
                    }
                }
            }
            catch (Exception erro)
            {
                return "Erro ao atualizar: " + erro.Message;
            }
        }
    }
}
