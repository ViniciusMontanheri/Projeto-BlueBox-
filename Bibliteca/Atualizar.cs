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
    public partial class Atualizar : Form
    {
        DAOAutor dao;
        public Atualizar()
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
                textBox3.Text = this.dao.ConsultarGenero(codigo);
                textBox4.Text = this.dao.ConsultarEndereco(codigo);
            }
        }//Fim do botão buscar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox genero

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do textBox endereco

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            //Atualizar
            this.dao.Atualizar(codigo, "nome", textBox2.Text);
            this.dao.Atualizar(codigo, "genero", textBox3.Text);
            string atualizar = this.dao.Atualizar(codigo, "endereco", textBox4.Text);
            //Mandar uma mensagem de atualização
            MessageBox.Show(atualizar);
            //Limpar Campos
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }//fim do botão atualizar
    }//fim da classe
}//fim do projeto
