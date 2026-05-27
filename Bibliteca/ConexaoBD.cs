using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BlueBox
{
    internal class ConexaoBD
    {
        //Guardando uma conexão com o MySQL
        private MySqlConnection conexao;

        //Guardado as informações do MySQL / local do banco
        private string stringConexao = "server=localhost;DataBase=BlueBox_Logisticas;Uid=root;Password=;Convert Zero DateTime=True";

        //Abrindo uma conexão
        public MySqlConnection AbrirConexao()
        {
            try
            { 
                conexao = new MySqlConnection(stringConexao); //Criando uma conexão
                conexao.Open(); //Abrindo a conexão
                return conexao; //Entregando a conexão para quem pediu
            }
            //Caso algo de errado...
            catch (Exception erro)
            {
                throw new Exception("Erro ao conectar com o banco: " + erro.Message); 
            }
        }

    }
}
