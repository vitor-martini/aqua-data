using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQUA_DATA.Class
{
    class clsFrmAcompanhamento
    {
        #region "VARIABLES"
        //Instancia a classe de conexão
        clsConnection oClsConexao = new clsConnection();
        clsMainFunctions oClsMainFunctions = new clsMainFunctions();

        //Aquário
        private string sDescricao;
        private string sSenha = "";
        private double dComprimento = 0;
        private double dLargura = 0;
        private double dAltura = 0;
        private string sDiaMontagem;
        private string sObservacao = "";
        private string sDataAtualizacao;

        public string Descricao { get => sDescricao; set => sDescricao = value; }
        public string Senha { get => sSenha; set => sSenha = value; }
        public double Comprimento { get => dComprimento; set => dComprimento = value; }
        public double Largura { get => dLargura; set => dLargura = value; }
        public double Altura { get => dAltura; set => dAltura = value; }
        public string DiaMontagem { get => sDiaMontagem; set => sDiaMontagem = value; }
        public string Observacao { get => sObservacao; set => sObservacao = value; }
        public string DataAtualizacao { get => sDataAtualizacao; set => sDataAtualizacao = value; }
        //Detalhe
        private string sDetalhe;
        private double dDetalheQuantidade;
        private string sDetalheDescricao;
        private int iDetalheCodigo;
        private int iCodigoTipoDetalhe;
        public string Detalhe { get => sDetalhe; set => sDetalhe = value; }
        public double DetalheQuantidade { get => dDetalheQuantidade; set => dDetalheQuantidade = value; }
        public string DetalheDescricao { get => sDetalheDescricao; set => sDetalheDescricao = value; }
        public int DetalheCodigo { get => iDetalheCodigo; set => iDetalheCodigo = value; }
        public int CodigoTipoDetalhe { get => iCodigoTipoDetalhe; set => iCodigoTipoDetalhe = value; }

        //Arquivo
        private string sArquivo;
        private string sArquivoDescricao;
        private int iArquivoCodigo;
        public string Arquivo { get => sArquivo; set => sArquivo = value; }
        public string ArquivoDescricao { get => sArquivoDescricao; set => sArquivoDescricao = value; }
        public int ArquivoCodigo { get => iArquivoCodigo; set => iArquivoCodigo = value; }

        #endregion

      
        //Método LoadGrid
        public void LoadGridAcompanhamento(DataGridView grdAcompanhamento, string dtFiltro)
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_acompanhamento");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@data_filtro", SqlDbType.VarChar).Value = dtFiltro;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                DataTable oDataTable = new DataTable();
                oDataTable.Load(oSqlCmd.ExecuteReader());
                grdAcompanhamento.DataSource = oDataTable;

                //Configura Grid
                oClsMainFunctions.GridConfig(grdAcompanhamento);
                for (int i = 0; i < grdAcompanhamento.Rows.Count; i++)
                {
                    for (int j = 0; j < grdAcompanhamento.Columns.Count; j++)
                    {
                        if (grdAcompanhamento.Rows[i].Cells[j].Value == DBNull.Value)
                        {
                            grdAcompanhamento.Rows[i].Cells[j].Style.BackColor = Color.Silver;

                        }
                        else if(Convert.ToInt32(grdAcompanhamento.Rows[i].Cells[j].Value) < DateTime.Today.Day)
                        {
                            //grdAcompanhamento.CurrentCell = grdAcompanhamento.Rows[i].Cells[j];
                            grdAcompanhamento.Rows[i].Cells[j].Style.BackColor = Color.LightSkyBlue;
                        }
                        else if(Convert.ToInt32(grdAcompanhamento.Rows[i].Cells[j].Value) == DateTime.Today.Day)
                        {
                            grdAcompanhamento.CurrentCell = grdAcompanhamento.Rows[i].Cells[j];
                           
                        }                       
                    }
                }

                //Desconectar
                oClsConexao.Desconectar();               

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }


    }
}
