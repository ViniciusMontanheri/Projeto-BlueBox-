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
    public partial class ConsultarFuncionario : Form
    {
        DAOFuncionario dao;

        public ConsultarFuncionario()
        {
            InitializeComponent();

            dao = new DAOFuncionario();

            CarregarFuncionarios();
        }

        public void CarregarFuncionarios()
        {
            DataTable tabela = dao.ConsultarFuncionarios();

            dataGridView1.DataSource = tabela;

            // Ajustes visuais
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Consultar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}