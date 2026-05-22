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
    public partial class MenuCadastro : Form
    {
        CadastrarFuncionario cad;
        Consultar con;
        Atualizar atu;
        Excluir exc;
        public MenuCadastro()
        {
            InitializeComponent();

            //chamando o metodo para arredondar os cantos dos botões
            DesignAjustes.ArredondarBotao(button1, 20);
            DesignAjustes.ArredondarBotao(button2, 20);
            DesignAjustes.ArredondarBotao(button3, 20);
            DesignAjustes.ArredondarBotao(button4, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cad = new CadastrarFuncionario();
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

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        //colocanddo o efeito nós botões 
        //colocando o efeito quando o mouse está em cima do botão
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(37, 99, 235);//colocando a cor que eu quero
        }
        //tirando o efeito quando o mouse sai de cima do botão
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 130, 246); //colocando a cor que eu quero
        }
    }//Classe Menu
}//Projeto Biblioteca
