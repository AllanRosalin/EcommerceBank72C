using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;   // Acesso ao PostgresSQL de forma nativa

namespace ExemploBancoEcommerce72C
{
    public partial class frmExemploBancoEcommerce : Form
    {
        private NpgsqlConnection cn = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private string stringConexao = "server = pgsql.projetoscti.com.br;" + "port = 5432; " +
            "database = projetoscti;" + "user id = projetoscti; password = gaspar";
        public frmExemploBancoEcommerce()
        {
            InitializeComponent();
        }

        private void frmExemploBancoEcommerce_Load(object sender, EventArgs e)
        {
            try
            {
                cn.ConnectionString = stringConexao;
                cn.Open();  // Abre a conexão com o Banco de Dados
                // MessageBox.Show("Conectado ao banco de dados da Kinghost !!!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar com o Banco de Dados !!!" +
                                    "\n\nMais detalhes" + ex.Message, 
                                    "Exemplo de Form de Pesquisa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarFabricante()
        {
            try
            {


                string sql = "select id_fabricante, nome from fabricante ";
                sql += "order by lower (nome)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dt.Clear();

                da.Fill(dt);

                cmbFabricante.DataSource = dt;
                cmbFabricante.DisplayMember = "nome";
                cmbFabricante.ValueMember = "id_fabricante";

                cmbFabricante.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar com o Banco de Dados !!!" +
                                    "\n\nMais detalhes" + ex.Message,
                                    "Exemplo de Form de Pesquisa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmExemploBancoEcommerce_FormClosing(object sender, FormClosingEventArgs e)
        {
            cn.Close(); // Fecha a conexão com o Banco de Dados
            cn.Dispose(); // Libera os recursos de memória ocupado pelo objeto
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {


                // string sql = "select * from ator" +
                // "where pais = 'EUA'" +
                // "order by nome";

                string sql = txtSQL.Text;

                // Criar e configurar um objeto Command - responsável por,
                // processar comandos SQL contra a fonte de dados.
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                // Criar um DataAdapter para processar o comando SQL contra o banco.
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                // Criar um objeto DataSet que receberá os dados do DataAdapter.
                    DataSet ds = new DataSet();
                // DataTable dt = new DataTable();

                    ds.Clear();

                // Carregar os dados do DataAdapter para o DataSet.
                da.Fill(ds);

                // Atribui o DataSet e carrega no Grid dgvPesquisa.
                dgvPesquisa.DataSource = ds.Tables[0];
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar com o Banco de Dados !!!" +
                                    "\n\nMais detalhes" + ex.Message,
                                    "Exemplo de Form de Pesquisa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmExemploBancoEcommerce_Activated(object sender, EventArgs e)
        {
            CarregarFabricante();
        }

        private void cmbFabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql;
            try
            {
                sql = "select id_parelho, modelo, preco, quantidade, desconto from aparelho ";
                sql += " where id_fabricante = " + cmbFabricante.SelectedValue;

                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                
                dgvPesquisa.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os aparelhos do fabricante selecionado !!!" +
                                    "\n\nMais detalhes" + ex.Message,
                                    "Exemplo de Form de Pesquisa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
