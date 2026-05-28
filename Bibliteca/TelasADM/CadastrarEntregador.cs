using BlueBox;
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
    public partial class CadastrarEntregador : Form
    {
        DAOEntregador dao;

        public CadastrarEntregador()
        {
            InitializeComponent();

            dao = new DAOEntregador();

            //Arredondar botão
            DesignAjustes.ArredondarBotao(button1, 20);
        }//fim construtor

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                !maskedTextBox1.MaskFull ||
                textBox3.Text == "" ||
                !maskedTextBox3.MaskFull ||
                textBox4.Text == "" ||
                textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            string nome = textBox1.Text;

            maskedTextBox1.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            maskedTextBox3.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            string cpf = maskedTextBox1.Text;

            string veiculo = textBox3.Text;

            string cnh = maskedTextBox3.Text;

            string login = textBox4.Text;

            string senha = textBox2.Text;

            // validar CPF
            if (!ValidaDados.ValidarCPF(cpf))
            {
                MessageBox.Show("CPF inválido!");
                return;
            }

            // validar CNH
            if (!ValidaDados.ValidarCNH(cnh))
            {
                MessageBox.Show("CNH inválido!");
                return;
            }

            int codigoNovoEntregador = dao.InserirEntregador(nome, cpf, veiculo, cnh, login, senha);

            DAOLog log = new DAOLog();

            // verificar se entregador inativo existe
            if (dao.EntregadorInativoExiste(cpf))
            {
                DialogResult resposta = MessageBox.Show(
                    "Este CPF pertence a um entregador desativado.\n\n" +
                    "Deseja reativar o cadastro?",
                    "Reativar entregador",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    dao.ReativarEntregador(
                        nome,
                        cpf,
                        veiculo,
                        cnh,
                        login,
                        senha);

                    DAOLog logEntregador = new DAOLog();

                    logEntregador.RegistrarLog(
                        Sessao.CodigoFuncionario,
                        "REATIVACAO",
                        "entregador",
                        0,
                        "Funcionário " +
                        Sessao.NomeFuncionario +
                        " reativou o entregador " +
                        nome);

                    LimparCampos();
                    return;
                }
            }


            log.RegistrarLog(
                Sessao.CodigoFuncionario,
                "INSERT",
                "entregador",
                codigoNovoEntregador,
                "Funcionário " +
                Sessao.NomeFuncionario +
                " cadastrou o entregador " +
                nome);

            LimparCampos();
        }//fim botão cadastrar

        // limpar campos
        public void LimparCampos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox3.Clear();
            textBox4.Clear();
            textBox2.Clear();
        }//fim limpar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim nome

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//fim cpf

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim veículo

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//fim cnh

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim login

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }//fim senha

        private void Cadastrar_Load(object sender, EventArgs e)
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
