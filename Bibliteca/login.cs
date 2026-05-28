using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBox
{
    public partial class login : Form
    {
        DAOFuncionario dao;
        MenuADM adm;
        MenuFuncionario fun;

        // definindo mostrar a senha como falso no começo
        // bool é verdadeiro ou falso
        bool mostrarSenha = false;

        public login()
        {
            InitializeComponent();

            dao = new DAOFuncionario();

            //chamando o metodo para arredondar os cantos dos botões
            DesignAjustes.ArredondarBotao(button1, 20);
            DesignAjustes.ArredondarBotao(button2, 20);
            DesignAjustes.ArredondarBotao(button3, 20);
            DesignAjustes.ArredondarBotao(button4, 20);
        }

        private void picOlho_Click(object sender, EventArgs e)
        {
            //Quando clicar no botão, se a senha estiver escondida ela vai aparecer
            if (mostrarSenha == false)
            {
                textBox2.UseSystemPasswordChar = false;
                mostrarSenha = true;
                picOlho.Image = Properties.Resources.olhoaberto;
            }
            //Se a senha estiver visivel, agora ela vai esconder 
            else
            {
                textBox2.UseSystemPasswordChar = true;
                mostrarSenha = false;

                picOlho.Image = Properties.Resources.olhofechado;
            }

        }

        private void login_Load(object sender, EventArgs e)
        {
            // Colocando esconder senha como verdadeiro no começo
            textBox2.UseSystemPasswordChar = true;
            picOlho.Image = Properties.Resources.olhofechado;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Fim do campo Senha

        //colocanddo o efeito nós botões 
        //colocando o efeito quando o mouse está em cima do botão
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(37, 99, 235);//colocando a cor que eu quero
        }
        //tirando o efeito quando o mouse sai de cima do botão
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 130, 246); //colocando a cor que eu quero
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adm = new MenuADM();
            adm.ShowDialog();
        }//Botão temporario ADM

        private void button3_Click(object sender, EventArgs e)
        {
            fun = new MenuFuncionario();
            fun.ShowDialog();
        }//Botão temporario Funcionario

        private void button4_Click(object sender, EventArgs e)
        {

        }//Botão temporario Funcionario

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha login e senha");
                return;
            }

            string login = textBox1.Text;
            string senha = textBox2.Text;

            DataTable tabela = dao.VerificarLogin(login, senha);

            if (tabela.Rows.Count > 0)
            {
                Sessao.CodigoFuncionario =
                    Convert.ToInt32(tabela.Rows[0]["codigo"]);

                Sessao.NomeFuncionario =
                    tabela.Rows[0]["nome"].ToString();

                Sessao.LoginFuncionario =
                    tabela.Rows[0]["login"].ToString();

                DAOLog daoLog = new DAOLog();

                daoLog.RegistrarLog(
                    Sessao.CodigoFuncionario,
                    "LOGIN",
                    "funcionario",
                    Sessao.CodigoFuncionario,
                    "Funcionário realizou login");

                bool adm =
                    Convert.ToBoolean(tabela.Rows[0]["adm"]);

                if (adm == true)
                {
                    MenuADM tela = new MenuADM();

                    tela.Show();

                    this.Hide();
                }
                else
                {
                    MenuFuncionario tela =
                        new MenuFuncionario();

                    tela.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos");
            }
        }
    }
}
