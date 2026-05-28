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
    public partial class AtualizarEntregador : Form
    {
        DAOEntregador dao;
        public AtualizarEntregador()
        {
            InitializeComponent();
            dao = new DAOEntregador();//Instanciando a classe
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox - Código

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(textBox1.Text);

                DataTable tabela = dao.BuscarEntregador(codigo);

                if (tabela.Rows.Count > 0)
                {
                    textBox2.Text = tabela.Rows[0]["nome"].ToString();

                    maskedTextBox1.Text =
                        tabela.Rows[0]["cpf"].ToString();

                    textBox4.Text =
                        tabela.Rows[0]["veiculo"].ToString();

                    maskedTextBox2.Text =
                        tabela.Rows[0]["cnh"].ToString();

                    textBox3.Text =
                        tabela.Rows[0]["login"].ToString();

                    textBox5.Text =
                        tabela.Rows[0]["senha"].ToString();
                }
                else
                {
                    MessageBox.Show("Entregador não encontrado!");
                }
            }
        }//Fim do botão buscar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox nome

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do MaskedTextBox CPF

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox veículo

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//FIm do MaskedTextBox telefone

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Fim do textBox Email

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }//Fim do textBox Senha

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);

            string resultado =
                dao.AtualizarEntregador(
                    codigo,
                    textBox2.Text,
                    maskedTextBox1.Text,
                    textBox4.Text,
                    maskedTextBox2.Text,
                    textBox3.Text,
                    textBox5.Text
                );

            MessageBox.Show(resultado);

            if (resultado == "Entregador atualizado com sucesso!")
            {
                DAOLog log = new DAOLog();

                log.RegistrarLog(
                    Sessao.CodigoFuncionario,
                    "UPDATE",
                    "entregador",
                    codigo,
                    "Funcionário " +
                    Sessao.NomeFuncionario +
                    " atualizou o entregador " +
                    textBox2.Text);
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }//fim do botão atualizar



        private void AtualizarEntregador_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }//Fim do textBox veículo

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
