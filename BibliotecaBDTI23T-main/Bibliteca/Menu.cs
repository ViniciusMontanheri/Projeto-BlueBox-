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
    public partial class Menu : Form
    {
        Cadastrar cad;
        Consultar con;
        Atualizar atu;
        Excluir exc;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cad = new Cadastrar();
            cad.ShowDialog();
        }//Botão Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            con = new Consultar();
            con.ShowDialog();
        }//Botão Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            atu = new Atualizar();
            atu.ShowDialog();
        }//fim do botão atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            exc = new Excluir();
            exc.ShowDialog();
        }//fim do botão excluir
    }//Classe Menu
}//Projeto Biblioteca
