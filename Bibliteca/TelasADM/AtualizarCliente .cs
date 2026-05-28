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
        DAOAutor dao;
        public AtualizarCliente()
        {
            InitializeComponent();
            dao = new DAOAutor();//Instanciando a classe
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox - Código

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o Código");
            }
            else
            {
                int codigo = Convert.ToInt32(textBox1.Text);
                textBox2.Text = this.dao.ConsultarNome(codigo);
                textBox4.Text = this.dao.ConsultarEndereco(codigo);
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
            int codigo = Convert.ToInt32(textBox1.Text);
            //Atualizar
            this.dao.Atualizar(codigo, "nome", textBox2.Text);
            string atualizar = this.dao.Atualizar(codigo, "endereco", textBox4.Text);
            //Mandar uma mensagem de atualização
            MessageBox.Show(atualizar);
            //Limpar Campos
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            maskedTextBox2.Text = ""; //maskedTextBox2 é um objeto do tipo MaskedTextBox, não uma string por isso precisa especificar com .Text
        }//fim do botão atualizar

        private void AtualizarCliente_Load(object sender, EventArgs e)
        {

        }


    }//fim da classe
}//fim do projeto
