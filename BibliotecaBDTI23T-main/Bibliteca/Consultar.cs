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
    public partial class Consultar : Form
    {
        DAOAutor dao;
        public Consultar()
        {
            InitializeComponent();
            this.dao = new DAOAutor();
            
            ChamarMetodo(dataGridView1);//Configurar toda a estrutura
        }//fim do construtor consultar

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Chamar Método
        public void ChamarMetodo(DataGridView datagrid)
        {
            
            ConfigurarDataGrid(datagrid);//Configuro a estrutura
            NomeColunas(datagrid);//Configuro os nomes
            AdicionarDados(datagrid);//Adiciono os dados
        }//fim do método

        //Nome Colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "Gênero";
            dataGrid.Columns[3].Name = "Endereço";
        }//fim do método

        //Definir a estrutura da tabela
        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;//Não permito que o usuário adicione linhas
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnCount = 4;
        }//fim do configurar

        public void AdicionarDados(DataGridView dataGrid)
        {
            //Primeira coisa será: PREENCHER O VETOR
            this.dao.PreencherVetor();
            for(int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(this.dao.codigo[i], this.dao.nome[i], this.dao.genero[i], this.dao.endereco[i]);
            }//fim do for
        }//fim do adicionarDados

        public DataGridView retornarData()
        {
            return dataGridView1;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
