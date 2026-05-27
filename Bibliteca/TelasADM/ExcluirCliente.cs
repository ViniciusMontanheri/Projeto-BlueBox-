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
    public partial class ExcluirCliente : Form
    {
        DAOCliente dao;
        public ExcluirCliente()
        {
            InitializeComponent();
            this.dao = new DAOCliente();
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Entrada código

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite um código");
                return;
            }

            int codigo;

            if (!int.TryParse(textBox1.Text, out codigo))
            {
                MessageBox.Show("Código inválido");
                return;
            }

            DataTable tabela = dao.BuscarCliente(codigo);

            if (tabela.Rows.Count > 0)
            {
                string nome = tabela.Rows[0]["nome"].ToString();
                string cpf = tabela.Rows[0]["cpf"].ToString();
                string telefone = tabela.Rows[0]["telefone"].ToString();

                DialogResult resposta = MessageBox.Show(
                    "Cliente encontrado:\n\n" +
                    "Nome: " + nome + "\n" +
                    "CPF: " + cpf + "\n" +
                    "Telefone: " + telefone + "\n\n" +
                    "Deseja excluir este cliente?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resposta == DialogResult.Yes)
                {
                    string resultado = dao.DeletarCliente(codigo);

                    MessageBox.Show(resultado);

                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado");
            }
        }//fim do botão Excluir

        private void ExcluirCliente_Load(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
