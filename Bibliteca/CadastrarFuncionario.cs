using Bibliteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliteca
{
    public partial class CadastrarFuncionario : Form
    {
        DAOAutor autor;

        public CadastrarFuncionario()
        {
            InitializeComponent();
            //Inserir
            this.autor = new DAOAutor();

            //Arredondar botão
            DesignAjustes.ArredondarBotao(button1, 20);
        }//fim do construtor

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (maskedTextBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "")  || (maskedTextBox2.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("Preencha os campos");
            }
            else
            {
                string nome = textBox1.Text;
                string cpf = maskedTextBox1.Text;
                string endereco = textBox3.Text;
                //Inserir dentro do banco
                this.autor.Inserir(nome, cpf, endereco);
                //Limpar os campos
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

        }//Fim do campo email/telefone

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

        
    }//fim da classe
}//fim do projeto
