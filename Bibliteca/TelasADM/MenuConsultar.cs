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
    public partial class MenuConsultar : Form
    {
        ConsultarFuncionario fun;
        ConsultarEntregador ent;
        ConsultarCliente cli;
        public MenuConsultar()
        {
            InitializeComponent();

            //chamando o metodo para arredondar os cantos dos botões
            DesignAjustes.ArredondarBotao(button2, 20);
            DesignAjustes.ArredondarBotao(button3, 20);
            DesignAjustes.ArredondarBotao(button4, 20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fun = new ConsultarFuncionario();
            fun.ShowDialog();
        }//Botão Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            ent = new ConsultarEntregador();
            ent.ShowDialog();
        }//fim do botão atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            cli = new ConsultarCliente();
            cli.ShowDialog();
        }//fim do botão excluir

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        //colocanddo o efeito nós botões 
        //colocando o efeito quando o mouse está em cima do botão
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(37, 99, 235);//colocando a cor que eu quero
        }
        //tirando o efeito quando o mouse sai de cima do botão
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(59, 130, 246); //colocando a cor que eu quero
        }
    }//Classe Menu
}//Projeto Biblioteca
