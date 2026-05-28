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
    public partial class CadastrarCliente : Form
    {
        DAOCliente cliente;

        public CadastrarCliente()
        {
            InitializeComponent();
            //Inserir
            this.cliente = new DAOCliente();

            //Arredondar botão
            DesignAjustes.ArredondarBotao(button1, 20);
        }//fim do construtor

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (maskedTextBox1.Text == "") || (textBox3.Text == "")  || (maskedTextBox2.Text == ""))
            {
                MessageBox.Show("Preencha os campos");
            }
            else
            {
                // Removendo itens desnecessarios 
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                string nome = textBox1.Text;
                string cpf = maskedTextBox1.Text;
                string endereco = textBox3.Text;
                string telefone = maskedTextBox2.Text;

                if (!ValidaDados.ValidarCPF(cpf))
                {
                    MessageBox.Show("CPF inválido!");
                    return;
                }

                if (cliente.ClienteInativoExiste(cpf))
                {
                    DialogResult resposta = MessageBox.Show(
                        "Este CPF pertence a um cliente desativado.\n\n" +
                        "Deseja reativar o cadastro?",
                        "Reativar cliente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        cliente.ReativarCliente(
                            nome,
                            cpf,
                            telefone,
                            endereco);

                        DAOLog logCliente = new DAOLog();

                        logCliente.RegistrarLog(
                            Sessao.CodigoFuncionario,
                            "REATIVACAO",
                            "cliente",
                            0,
                            "Funcionário " +
                            Sessao.NomeFuncionario +
                            " reativou o cliente " +
                            nome);

                        LimparCampos();

                        return;
                    }
                }

                //Inserir dentro do banco
                int codigoNovoCliente = this.cliente.InserirCliente(nome, cpf, telefone, endereco);

                DAOLog log = new DAOLog();

                log.RegistrarLog(
                    Sessao.CodigoFuncionario,
                    "INSERT",
                    "cliente",
                    codigoNovoCliente,
                    "Funcionário " +
                    Sessao.NomeFuncionario +
                    " cadastrou o cliente " +
                    nome);
                //Limpar os campos
                LimparCampos();
            }
        }//fim do cadastrar

        //Limpar os campos
        public void LimparCampos()
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            maskedTextBox2.Text = "";
        }//fim do método


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo nome

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do campo CPF

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo endereço

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Fim do campo telefone

        private void Cadastrar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
