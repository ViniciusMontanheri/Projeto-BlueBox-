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
    internal class DAOFuncionario
    {

        // Criando o acesso com o motor da conexão
        private ConexaoBD banco = new ConexaoBD();

        //organizando os dados para consulta
        public DataTable ConsultarFuncionarios()
        {
            DataTable tabela = new DataTable();//Criando uma tela em memoria vazia

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())//abrindo a conexao
                {
                    string sql = @"SELECT codigo, nome, cpf, telefone, endereco, login, adm FROM funcionario WHERE ativo = true"; //fazendo o select no banco

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao); //Criando um adaptador de dados

                    adapter.Fill(tabela); //Preenchendo a tabela com os dados do banco
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao consultar: " + erro.Message);
            }
            return tabela;
        }//Fim do consultar

        // Buscar funcionário pelo código
        public DataTable BuscarFuncionario(int codigo)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT * FROM funcionario WHERE codigo = @codigo AND ativo = true";

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
        }//Fim do Buscar

        // Atualizar funcionário
        public string AtualizarFuncionario(
            int codigo,
            string nome,
            string cpf,
            string telefone,
            string endereco,
            string login,
            string senha,
            bool adm)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    // LIMPAR CPF E TELEFONE
                    cpf = cpf.Replace(".", "").Replace("-", "");
                    telefone = telefone.Replace("(", "")
                                 .Replace(")", "")
                                 .Replace("-", "")
                                 .Replace(" ", "");

                    DataTable tabelaAtual = BuscarFuncionario(codigo);

                    if (tabelaAtual.Rows.Count > 0)
                    {
                        DataRow linha = tabelaAtual.Rows[0];

                        bool igual =
                            linha["nome"].ToString() == nome &&
                            linha["cpf"].ToString() == cpf &&
                            linha["telefone"].ToString() == telefone &&
                            linha["endereco"].ToString() == endereco &&
                            linha["login"].ToString() == login &&
                            linha["senha"].ToString() == senha &&
                            Convert.ToBoolean(linha["adm"]) == adm;

                        if (igual)
                        {
                            return "Nenhuma alteração foi feita.";
                        }
                    }

                    string sql = @"UPDATE funcionario
                   SET nome = @nome,
                       cpf = @cpf,
                       telefone = @telefone,
                       endereco = @endereco,
                       login = @login,
                       senha = @senha,
                       adm = @adm
                   WHERE codigo = @codigo AND ativo = true";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@endereco", endereco);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@adm", adm);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Funcionário atualizado com sucesso!";
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
        }//Fim do Atualizar

        // Mandando os dados para o banco atraves do ConexaoBD
        public int InserirFuncionario(
            string nome,
            string cpf,
            string telefone,
            string endereco,
            string login,
            string senha,
            bool adm)
        {
            try // Tentando fazer a conexao
            {
                // Guardando uma conexão com o MySQL
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"INSERT INTO funcionario
                    (nome, cpf, telefone, endereco, login, senha, adm)
                    VALUES
                    (@nome, @cpf, @telefone, @endereco, @login, @senha, @adm)";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@endereco", endereco);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@adm", adm);

                    comando.ExecuteNonQuery(); //Executando o comando de fato

                    int codigoGerado =
                        Convert.ToInt32(comando.LastInsertedId);

                    MessageBox.Show("Funcionário cadastrado com sucesso!");

                    return codigoGerado;

                }
            }
            catch (MySqlException erro)// Capitura apenas erros na biblioteca MySQL
            {
                //Verifica se o cadastro já foi realizado 
                if (erro.Number == 1062)
                {
                    MessageBox.Show("CPF ou login já cadastrado!");
                }
                else//Se não for um cadastro de alguém já existente ele mostra qual erro é
                {
                    MessageBox.Show("Erro no banco: " + erro.Message);
                }
            }
            catch (Exception erro)//Se não for um erro do MySQL ele ira mostrar qualquer outro erro
            {
                MessageBox.Show("Erro geral: " + erro.Message);
            }

            return 0;
        }
                    // Deletar funcionário
        public string DeletarFuncionario(int codigo)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"UPDATE funcionario SET ativo = false WHERE codigo = @codigo AND ativo = true";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@codigo", codigo);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        return "Funcionário desativado com sucesso!";
                    }
                    else
                    {
                        return "Funcionário não encontrado.";
                    }
                }
            }
            catch (Exception erro)
            {
                return "Erro ao excluir: " + erro.Message;
            }
        }//Fim do Deletar

        // Verificar login
        public DataTable VerificarLogin(string login, string senha)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT * FROM funcionario WHERE login = @login AND senha = @senha AND ativo = true";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(comando);

                    adapter.Fill(tabela);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no login: " + erro.Message);
            }

            return tabela;


        }//Fim do verificar login

        //Verificar se a conta está inativa
        public bool FuncionarioInativoExiste(string cpf)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"SELECT * FROM funcionario
                           WHERE cpf = @cpf
                           AND ativo = false";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@cpf", cpf);

                    MySqlDataReader reader =
                        comando.ExecuteReader();

                    return reader.HasRows;
                }
            }
            catch
            {
                return false;
            }
        }

        //reativando a conta
        public void ReativarFuncionario(
    string nome,
    string cpf,
    string telefone,
    string endereco,
    string login,
    string senha,
    bool adm)
        {
            try
            {
                using (MySqlConnection conexao = banco.AbrirConexao())
                {
                    string sql = @"UPDATE funcionario
                           SET nome = @nome,
                               telefone = @telefone,
                               endereco = @endereco,
                               login = @login,
                               senha = @senha,
                               adm = @adm,
                               ativo = true
                           WHERE cpf = @cpf";

                    MySqlCommand comando =
                        new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@endereco", endereco);
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@adm", adm);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Funcionário reativado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }
    }
}
