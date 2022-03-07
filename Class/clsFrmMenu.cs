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
    class clsFrmMenu
    {
        //Instancia a classe de conexão
        clsConnection oClsConexao = new clsConnection();

        #region "VARIABLES"

        private string sDescricao;
        private string sSenha = "";
        private double dComprimento = 0;
        private double dLargura = 0;
        private double dAltura = 0;
        private string sDiaMontagem;
        private string sObservacao = "";

        public string Descricao { get => sDescricao; set => sDescricao = value; }
        public string Senha { get => sSenha; set => sSenha = value; }
        public double Comprimento { get => dComprimento; set => dComprimento = value; }
        public double Largura { get => dLargura; set => dLargura = value; }
        public double Altura { get => dAltura; set => dAltura = value; }
        public string DiaMontagem { get => sDiaMontagem; set => sDiaMontagem = value; }
        public string Observacao { get => sObservacao; set => sObservacao = value; }

        #endregion

        //Método de inserir
        public void Insert()
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_insert_aquario_cadastro");
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
                    oSqlCmd.Parameters.AddWithValue("@dia_montagem", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    oSqlCmd.Parameters.AddWithValue("@dia_montagem", SqlDbType.Date).Value = dtDiaMontagem;
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

    }
}
