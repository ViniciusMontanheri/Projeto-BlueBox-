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
    public partial class Excluir : Form
    {
        DAOAutor dao;
        public Excluir()
        {
            InitializeComponent();
            this.dao = new DAOAutor();
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Entrada código

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o código para excluir");
            }
            else
            {
                int codigo = Convert.ToInt32(textBox1.Text);
                string excluir = this.dao.Deletar(codigo);
                //Mostrar o resultado na tela
                MessageBox.Show(excluir);
                //Limpar o campo
                textBox1.Text = "";
            }
        }//fim do botão Excluir
    }//fim da classe
}//fim do projeto
