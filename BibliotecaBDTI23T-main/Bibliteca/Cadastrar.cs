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
    public partial class Cadastrar : Form
    {
        DAOAutor autor;

        public Cadastrar()
        {
            InitializeComponent();
            //Inserir
            this.autor = new DAOAutor();
        }//fim do construtor

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Preencha os campos");
            }
            else
            {
                string nome = textBox1.Text;
                string genero = textBox2.Text;
                string endereco = textBox3.Text;
                //Inserir dentro do banco
                this.autor.Inserir(nome, genero, endereco);
                //Limpar os campos
                LimparCampos();
            }
        }//fim do cadastrar

        //Limpar os campos
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }//fim do método


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo nome

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo gênero

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo endereço

        private void Cadastrar_Load(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
