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
    public partial class AtualizarCliente : Form
    {
        DAOCliente dao;
        public AtualizarCliente()
        {
            InitializeComponent();
            dao = new DAOCliente();//Instanciando a classe
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox - Código

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o Código");
                return;
            }

            int codigo;

            if (!int.TryParse(textBox1.Text, out codigo))
            {
                MessageBox.Show("Digite um código válido");
                return;
            }

            DataTable tabela = dao.BuscarCliente(codigo);

            if (tabela.Rows.Count > 0)
            {
                textBox2.Text = tabela.Rows[0]["nome"].ToString();

                string cpf = tabela.Rows[0]["cpf"].ToString();
                string telefone = tabela.Rows[0]["telefone"].ToString();

                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";

                maskedTextBox1.Text = cpf;
                maskedTextBox2.Text = telefone;

                textBox4.Text = tabela.Rows[0]["endereco"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente não encontrado");
            }
        }//Fim do botão buscar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox nome

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//fim do MaskedTextBox CPf

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox endereço

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//fim do MaskedTextBox telefone

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Busque um cliente primeiro");
                return;
            }

            int codigo;

            if (!int.TryParse(textBox1.Text, out codigo))
            {
                MessageBox.Show("Código inválido");
                return;
            }

            if (textBox2.Text == "" ||
                !maskedTextBox1.MaskFull ||
                !maskedTextBox2.MaskFull ||
                textBox4.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            maskedTextBox1.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            maskedTextBox2.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            string cpf = maskedTextBox1.Text;
            string telefone = maskedTextBox2.Text;

            if (!ValidaDados.ValidarCPF(cpf))
            {
                MessageBox.Show("CPF inválido!");
                return;
            }

            string resultado = dao.AtualizarCliente(
                codigo,
                textBox2.Text,
                cpf,
                telefone,
                textBox4.Text);

            MessageBox.Show(resultado);

            if (resultado == "Cliente atualizado com sucesso!")
            {
                DAOLog log = new DAOLog();

                log.RegistrarLog(
                    Sessao.CodigoFuncionario,
                    "UPDATE",
                    "cliente",
                    codigo,
                    "Funcionário " +
                    Sessao.NomeFuncionario +
                    " atualizou o cliente " +
                    textBox2.Text);
            }

            // Limpar campos
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox4.Clear();
        }//fim do botão atualizar

        private void AtualizarCliente_Load(object sender, EventArgs e)
        {

        }


    }//fim da classe
}//fim do projeto
