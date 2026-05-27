using BlueBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BlueBox
{
    public partial class CadastrarFuncionario : Form
    {
        DAOFuncionario funcionario;

        public CadastrarFuncionario()
        {
            InitializeComponent();
            //Inserir
            this.funcionario = new DAOFuncionario();

            //Arredondar botão
            DesignAjustes.ArredondarBotao(button1, 20);
        }//fim do construtor

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || !maskedTextBox1.MaskCompleted || !maskedTextBox2.MaskCompleted || textBox3.Text == "" || textBox4.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                // Removendo itens desnecessarios 
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                string nome = textBox1.Text;
                string cpf = maskedTextBox1.Text;
                string telefone = maskedTextBox2.Text;
                string endereco = textBox3.Text;
                string login = textBox4.Text;
                string senha = textBox2.Text;

                // TRUE = ADM
                // FALSE = funcionário comum
                bool adm = checkBox1.Checked;

                if (!ValidaDados.ValidarCPF(cpf))
                {
                    MessageBox.Show("CPF inválido!");
                    return;
                }

                if (maskedTextBox1.Text.Length < 11)
                {
                    MessageBox.Show("CPF incompleto");
                    return;
                }

                if (maskedTextBox2.Text.Length < 11)
                {
                    MessageBox.Show("Telefone incompleto");
                    return;
                }

                // Inserir no banco
                funcionario.InserirFuncionario(
                    nome, cpf, telefone, endereco, login, senha, adm);

                // Limpar os campos
                LimparCampos();
            }
        }//fim do cadastrar

        //Limpar os campos
        public void LimparCampos()
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            maskedTextBox2.Text = "";
            checkBox1.Checked = false;
        }//fim do método


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo nome

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do campo CPF

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo endereço

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do campo telefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Fim do campo email

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }//fim do campo senha

        private void Cadastrar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        //colocanddo o efeito nós botões 
        //colocando o efeito quando o mouse está em cima do botão
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(37, 99, 235);
        }
        //tirando o efeito quando o mouse sai de cima do botão
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 130, 246); //colocando a cor que eu quero
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }//Fim do checkBox para administrador
    }//fim da classe
}//fim do projeto
