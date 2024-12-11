using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ExemploBancoEcommerce72C
{
    public partial class frmCadFabricante : Form
    {
        private NpgsqlConnection cn = new NpgsqlConnection();
        private string stringConexao = "server = pgsql.projetoscti.com.br;" + "port = 5432; " +
            "database = projetoscti;" + "user id = projetoscti; password = gaspar";

        private bool novo = false;

        public frmCadFabricante()
        {
            InitializeComponent();
        }

        private void frmCadFabricante_Load(object sender, EventArgs e)
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
                                    "Cadastro de Fabricantes",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCadFabricante_FormClosing(object sender, FormClosingEventArgs e)
        {
            cn.Close();
            cn.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string sql;

            try
            {
                if (novo)
                {
                    sql = "insert into fabricante (id_fabricante, nome, observacao)";
                    sql += " values (@id_fabricante, @nome, @observacao)";
                }

                else
                {
                    sql = "update fabricante set";
                    sql += "    nome = @nome,";
                    sql += "    observacao = @observacao,";
                    sql += "    where id_fabricante = @id_fabricante";
                }

                // Testes de Consistências e de Regras de Negócios do Projeto

                if (String.IsNullOrEmpty(txtidfabri.Text))
                {
                    MessageBox.Show("Você deve preencher o Id do fabricante !!!",
                                    "Cadastro de Fabricantes",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtidfabri.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Você deve preencher o nome do fabricante !!!",
                                    "Cadastro de Fabricantes",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNome.Focus();
                    return;
                }


                // Preparar o comando SQL, adicionar os parâmetros e executar
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id_fabricante", Convert.ToInt64(txtidfabri.Text));
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@observacao", txtObservacao.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados do fabricante salvos com sucesso !!!",
                                    "Cadastro de Fabricantes",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpaForm(true);
                txtidfabri.Focus();
                novo = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o Fabricante !!!" +
                                    "\n\nMais detalhes" + ex.Message,
                                    "Cadastro de Fabricantes",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtidfabri_Validating(object sender, CancelEventArgs e)
        {
            string sql;

            novo = false;

            try
            {
                if (!String.IsNullOrEmpty(txtidfabri.Text))
                {
                    // Pesquisar o Id_Fabricante (idfabri) e se encontrar,
                    // carregar os dados do Fabricante na tela (consulta)
                    // Se não encontrar, limpar o Form e permitir o cadastro desse novo Fabricante.

                    sql = "select * from fabricante";
                    sql += "    where id_fabricante = @id_fabricante";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@id_fabricante", Convert.ToInt64(txtidfabri.Text));

                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtNome.Text = dr["nome"].ToString();
                        txtObservacao.Text = dr["observacao"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("Fabricante não encontrado !!!",
                                    "Cadastro de Fabricantes",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpaForm(true);
                        e.Cancel = true;
                    }

                    dr.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao pesquisar o Fabricante !!!" +
                                    "\n\nMais detalhes" + ex.Message,
                                    "Cadastro de Fabricantes",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpaForm(bool limparCampoPesquisa = true)
        {
            if (limparCampoPesquisa)
                txtidfabri.Clear();

            txtNome.Clear();
            txtObservacao.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            LimpaForm(true);
            txtidfabri.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            novo = false;
            LimpaForm(true);
            txtidfabri.Focus();
        }
    }
}
