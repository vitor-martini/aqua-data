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
    class clsFrmLogin
    {
        //Instancia a classe de conexão
        clsConnection oClsConexao = new clsConnection();
        //Cria mensagem pública
        public string sMensagem = "";

        //Método LoadCombo
        public void LoadComboAquario(ComboBox oCombo)
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_combo_teste");
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                DataTable oDataTable = new DataTable();
                oDataTable.Load(oSqlCmd.ExecuteReader());
                oCombo.ValueMember = "codigo";
                oCombo.DisplayMember = "valor";
                oCombo.DataSource = oDataTable;
                //Desconectar
                oClsConexao.Desconectar();
                //Monstrar mensagens de retorno
                this.sMensagem = "Cadastrado com sucesso!";

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
            }
        }

        //Método LoadField
        public bool ValidateLogin(int iCodigoAquario, string sSenha)
        {
            try
            {
                Boolean bResult = false;

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand("sp_select_validade_login");
                SqlDataReader oSqlDataReader;
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                oSqlCmd.Parameters.AddWithValue("@codigo_aquario", SqlDbType.VarChar).Value = iCodigoAquario;
                oSqlCmd.Parameters.AddWithValue("@senha", SqlDbType.VarChar).Value = sSenha;


                //Conectar com banco
                oSqlCmd.Connection = oClsConexao.Conectar();
                //Executar Comando
                oSqlDataReader = oSqlCmd.ExecuteReader();
                while (oSqlDataReader.Read())
                {
                    bResult = Convert.ToBoolean(oSqlDataReader.GetValue(oSqlDataReader.GetOrdinal("return")));
                }

                //Desconectar
                oClsConexao.Desconectar();

                return bResult;

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro: " + erro.ToString());
                return false;
            }
        }

    }
}
