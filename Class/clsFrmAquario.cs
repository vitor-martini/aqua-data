using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQUA_DATA.Class
{
    class clsfrmAquario
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
        private string sDataAcompanhamento;
        private string sCaminhoArquivo;

        public string Descricao { get => sDescricao; set => sDescricao = value; }
        public string Senha { get => sSenha; set => sSenha = value; }
        public double Comprimento { get => dComprimento; set => dComprimento = value; }
        public double Largura { get => dLargura; set => dLargura = value; }
        public double Altura { get => dAltura; set => dAltura = value; }
        public string DiaMontagem { get => sDiaMontagem; set => sDiaMontagem = value; }
        public string Observacao { get => sObservacao; set => sObservacao = value; }
        public string DataAcompanhamento { get => sDataAcompanhamento; set => sDataAcompanhamento = value; }
        public string CaminhoArquivo { get => sCaminhoArquivo; set => sCaminhoArquivo = value; }

        //Detalhe
        private string sDetalhe;
        private double dDetalheQuantidade;
        private string sDetalheDescricao;
        private int iDetalheCodigo;
        private int iCodigoTipoDetalhe;
        private int iCodigoUnidadeMedidaDetalhe;
        private byte[] byteDetalheFoto;
        private string sDetalheFotoUrl;
        private string sDetalheFotoNome;

        public string Detalhe { get => sDetalhe; set => sDetalhe = value; }
        public double DetalheQuantidade { get => dDetalheQuantidade; set => dDetalheQuantidade = value; }
        public string DetalheDescricao { get => sDetalheDescricao; set => sDetalheDescricao = value; }
        public int DetalheCodigo { get => iDetalheCodigo; set => iDetalheCodigo = value; }
        public int CodigoTipoDetalhe { get => iCodigoTipoDetalhe; set => iCodigoTipoDetalhe = value; }
        public int CodigoUnidadeMedidaDetalhe { get => iCodigoUnidadeMedidaDetalhe; set => iCodigoUnidadeMedidaDetalhe = value; }

        public byte[] DetalheFoto { get => byteDetalheFoto; set => byteDetalheFoto = value; }
        public string DetalheFotoUrl { get => sDetalheFotoUrl; set => sDetalheFotoUrl = value; }
        public string DetalheFotoNome { get => sDetalheFotoNome; set => sDetalheFotoNome = value; }
        #endregion

        #region "FUNÇÕES"

        #region "AQUÁRIO"
        public void InsertAquario()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_insert_aquario");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@descricao", SqlDbType.VarChar).Value = sDescricao;
                oSqlCmd.Parameters.AddWithValue("@senha", SqlDbType.VarChar).Value = sSenha;
                oSqlCmd.Parameters.AddWithValue("@comprimento", SqlDbType.Float).Value = dComprimento;
                oSqlCmd.Parameters.AddWithValue("@largura", SqlDbType.Float).Value = dLargura;
                oSqlCmd.Parameters.AddWithValue("@altura", SqlDbType.Float).Value = dAltura;

                DateTime dtDiaMontagem;
                if (DateTime.TryParseExact(sDiaMontagem, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDiaMontagem) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_montagem", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_montagem", SqlDbType.Date).Value = dtDiaMontagem;
                }

                oSqlCmd.Parameters.AddWithValue("@observacao", SqlDbType.VarChar).Value = sObservacao;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();
                //Monstrar mensagens de retorno
                MessageBox.Show("Cadastrado com sucesso!");

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void UpdateAquario()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_update_aquario");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@descricao", SqlDbType.VarChar).Value = sDescricao;

                if (sSenha == "")
                {
                    oSqlCmd.Parameters.AddWithValue("@senha", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@senha", SqlDbType.VarChar).Value = sSenha;
                }

                oSqlCmd.Parameters.AddWithValue("@comprimento", SqlDbType.Float).Value = dComprimento;
                oSqlCmd.Parameters.AddWithValue("@largura", SqlDbType.Float).Value = dLargura;
                oSqlCmd.Parameters.AddWithValue("@altura", SqlDbType.Float).Value = dAltura;

                DateTime dtDiaMontagem;
                if (DateTime.TryParseExact(sDiaMontagem, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDiaMontagem) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_montagem", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_montagem", SqlDbType.Date).Value = dtDiaMontagem;
                }

                oSqlCmd.Parameters.AddWithValue("@observacao", SqlDbType.VarChar).Value = sObservacao;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();
                //Monstrar mensagens de retorno
                MessageBox.Show("Atualizado com sucesso!");

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void LoadField(TextBox txtDescricao, MaskedTextBox txtDataMontagem, TextBox txtObservacao, TextBox txtComprimento, TextBox txtLargura, TextBox txtAltura, Label lblAtualizacao)
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_aquario_fields");
                SqlDataReader oSqlDataReader;
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.VarChar).Value = clsLoggedInfo.iCodigoAquario;
                DateTime dtDataAcompanhamento;
                if (DateTime.TryParseExact(sDataAcompanhamento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDataAcompanhamento) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = dtDataAcompanhamento;
                }

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlDataReader = oSqlCmd.ExecuteReader();
                while (oSqlDataReader.Read())
                {
                    txtDescricao.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("descricao")).ToString();
                    txtDataMontagem.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("data_montagem")).ToString();
                    txtObservacao.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("observacao")).ToString();
                    txtComprimento.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("comprimento")).ToString();
                    txtLargura.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("largura")).ToString();
                    txtAltura.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("altura")).ToString();
                    lblAtualizacao.Text = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("atualizacao")).ToString();
                }


                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void LoadCaminhoArquivo()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_aquario_fields");
                SqlDataReader oSqlDataReader;
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.VarChar).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlDataReader = oSqlCmd.ExecuteReader();
                while (oSqlDataReader.Read())
                {
                    sCaminhoArquivo = oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("caminho_arquivo")).ToString();
                }


                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }


        public void UpdateAquarioCaminhoArquivo()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_update_aquario_caminho_arquivo");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@caminho_arquivo", SqlDbType.VarChar).Value = CaminhoArquivo;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();
                //Monstrar mensagens de retorno
                MessageBox.Show("Atualizado com sucesso!");

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        #endregion

        #region "DETALHE"
        public void InsertDetalhe()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_insert_aquario_detalhe_acompanhamento");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@codigo_tipo_detalhe", SqlDbType.Int).Value = iCodigoTipoDetalhe;
                oSqlCmd.Parameters.AddWithValue("@detalhe", SqlDbType.VarChar).Value = sDetalhe;
                oSqlCmd.Parameters.AddWithValue("@detalhe_descricao", SqlDbType.VarChar).Value = sDetalheDescricao;
                oSqlCmd.Parameters.AddWithValue("@detalhe_quantidade", SqlDbType.Float).Value = dDetalheQuantidade;
                DateTime dtDataAcompanhamento;
                if (DateTime.TryParseExact(sDataAcompanhamento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDataAcompanhamento) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = dtDataAcompanhamento;
                }
                if (CodigoUnidadeMedidaDetalhe == -1)
                {
                    oSqlCmd.Parameters.AddWithValue("@codigo_unidade_medida", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@codigo_unidade_medida", SqlDbType.Date).Value = CodigoUnidadeMedidaDetalhe;
                }

                if (iCodigoTipoDetalhe == 4)
                {
                    oSqlCmd.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = DetalheFoto;
                    oSqlCmd.Parameters.AddWithValue("@foto_url", SqlDbType.VarChar).Value = DetalheFotoUrl;
                    oSqlCmd.Parameters.AddWithValue("@foto_nome_arquivo", SqlDbType.VarChar).Value = DetalheFotoNome;
                }
             
                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void UpdateDetalhe()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_update_aquario_detalhe_acompanhamento");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@codigo_tipo_detalhe", SqlDbType.Int).Value = iCodigoTipoDetalhe;
                oSqlCmd.Parameters.AddWithValue("@detalhe", SqlDbType.VarChar).Value = sDetalhe;
                oSqlCmd.Parameters.AddWithValue("@detalhe_descricao", SqlDbType.VarChar).Value = sDetalheDescricao;
                oSqlCmd.Parameters.AddWithValue("@detalhe_quantidade", SqlDbType.Float).Value = dDetalheQuantidade;
                oSqlCmd.Parameters.AddWithValue("@detalhe_codigo", SqlDbType.Int).Value = iDetalheCodigo;
                DateTime dtDataAcompanhamento;
                if (DateTime.TryParseExact(sDataAcompanhamento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDataAcompanhamento) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = dtDataAcompanhamento;
                }
                if (CodigoUnidadeMedidaDetalhe == -1)
                {
                    oSqlCmd.Parameters.AddWithValue("@codigo_unidade_medida", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@codigo_unidade_medida", SqlDbType.Date).Value = CodigoUnidadeMedidaDetalhe;
                }

                if (iCodigoTipoDetalhe == 4)
                {
                    oSqlCmd.Parameters.AddWithValue("@foto", SqlDbType.Image).Value = DetalheFoto;
                    oSqlCmd.Parameters.AddWithValue("@foto_url", SqlDbType.VarChar).Value = DetalheFotoUrl;
                    oSqlCmd.Parameters.AddWithValue("@foto_nome_arquivo", SqlDbType.VarChar).Value = DetalheFotoNome;                     
                }

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void DeleteDetalhe()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_delete_aquario_detalhe_acompanhamento");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@codigo_tipo_detalhe", SqlDbType.Int).Value = iCodigoTipoDetalhe;
                oSqlCmd.Parameters.AddWithValue("@codigo", SqlDbType.VarChar).Value = iDetalheCodigo;
                DateTime dtDataAcompanhamento;
                if (DateTime.TryParseExact(sDataAcompanhamento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDataAcompanhamento) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = dtDataAcompanhamento;
                }

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlCmd.ExecuteNonQuery();
                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        public void LoadGridDetalhe(DataGridView grdDetalhe, int iCodigoTipoDetalhe)
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_aquario_detalhe_acompanhamento");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.Int).Value = clsLoggedInfo.iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@codigo_tipo_detalhe", SqlDbType.Int).Value = iCodigoTipoDetalhe;
                DateTime dtDataAcompanhamento;
                if (DateTime.TryParseExact(sDataAcompanhamento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtDataAcompanhamento) == false)
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@data_acompanhamento", SqlDbType.Date).Value = dtDataAcompanhamento;
                }

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                DataTable oDataTable = new DataTable();
                oDataTable.Load(oSqlCmd.ExecuteReader());
                grdDetalhe.DataSource = oDataTable;

                //Configura Grid
                oClsMainFunctions.GridConfig(grdDetalhe);

                //Desconectar
                oClsConexao.Desconectar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }
        #endregion

        #endregion

    }
}
