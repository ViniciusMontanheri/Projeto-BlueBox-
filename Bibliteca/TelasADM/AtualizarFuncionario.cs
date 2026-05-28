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
    public partial class AtualizarFuncionario : Form
    {
        DAOFuncionario dao;
        public AtualizarFuncionario()
        {
            InitializeComponent();
            dao = new DAOFuncionario();//Instanciando a classe
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

            DataTable tabela = dao.BuscarFuncionario(codigo);

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
                textBox3.Text = tabela.Rows[0]["login"].ToString();
                textBox5.Text = tabela.Rows[0]["senha"].ToString();
                checkBox1.Checked = Convert.ToBoolean(tabela.Rows[0]["adm"]);
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado");
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

        }//fim do textBox endereco

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
            if (textBox1.Text == "")
            {
                MessageBox.Show("Busque um funcionário primeiro");
                return;
            }

            int codigo;

            if (!int.TryParse(textBox1.Text, out codigo))
            {
                MessageBox.Show("Código inválido");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Nenhum funcionário carregado");
                return;
            }

            if (textBox2.Text == "" || !maskedTextBox1.MaskFull || !maskedTextBox2.MaskFull || textBox4.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            string cpf = maskedTextBox1.Text;
            string telefone = maskedTextBox2.Text;

            if (!ValidaDados.ValidarCPF(cpf))
            {
                MessageBox.Show("CPF inválido!");
                return;
            }

            string resultado = dao.AtualizarFuncionario(
                    codigo, textBox2.Text, cpf, telefone, textBox4.Text, textBox3.Text, textBox5.Text, checkBox1.Checked);

            MessageBox.Show(resultado);

            // Registrar log SOMENTE se atualizou
            if (resultado == "Funcionário atualizado com sucesso!")
            {
                DAOLog log = new DAOLog();

                log.RegistrarLog(
                    Sessao.CodigoFuncionario,
                    "UPDATE",
                    "funcionario",
                    codigo,
                    "Funcionário " +
                    Sessao.NomeFuncionario +
                    " atualizou o cadastro de " +
                    textBox2.Text);
            }

            // Limpar campos
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }//fim do botão atualizar



        private void AtualizarFuncionario_Load(object sender, EventArgs e)
        {

        }


    }//fim da classe
}//fim do projeto
