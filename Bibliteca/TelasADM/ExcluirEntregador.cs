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
    public partial class ExcluirEntregador : Form
    {
        DAOEntregador dao;
        public ExcluirEntregador()
        {
            InitializeComponent();
            this.dao = new DAOEntregador();
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

            DataTable tabela = dao.BuscarEntregador(codigo);

            if (tabela.Rows.Count > 0)
            {
                string nome = tabela.Rows[0]["nome"].ToString();
                string cpf = tabela.Rows[0]["cpf"].ToString();
                string veiculo = tabela.Rows[0]["veiculo"].ToString();

                DialogResult resposta = MessageBox.Show(
                    "Entregador encontrado:\n\n" +
                    "Nome: " + nome + "\n" +
                    "CPF: " + cpf + "\n" +
                    "Veículo: " + veiculo + "\n\n" +
                    "Deseja excluir este entregador?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resposta == DialogResult.Yes)
                {
                    string resultado = dao.DeletarEntregador(codigo);

                    MessageBox.Show(resultado);

                    // Registrar log somente se excluiu
                    if (resultado == "Entregador desativado com sucesso!")
                    {
                        DAOLog log = new DAOLog();

                        log.RegistrarLog(
                            Sessao.CodigoFuncionario,
                            "DELETE",
                            "entregador",
                            codigo,
                            "Funcionário " +
                            Sessao.NomeFuncionario +
                            " desativou o entregador " +
                            nome);
                    }

                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Entregador não encontrado");
            }
        }//fim do botão Excluir

        private void Excluir_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
