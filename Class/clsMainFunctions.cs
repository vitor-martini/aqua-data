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
    class clsMainFunctions
    {
        #region "VARIABLES"

        //Instancia a classe de conexão
        clsConnection oClsConnection = new clsConnection();
        //Cria mensagem pública
        public string sMensagem = "";
       

        #endregion

        //Método LoadCombo
        public void LoadCombo(ComboBox oCombo, string sProcedure)
        {
            try
            {

                //Comando SQL 
                SqlCommand oSqlCmd = new SqlCommand(sProcedure);
                oSqlCmd.CommandType = CommandType.StoredProcedure;

                //Conectar com banco
                oSqlCmd.Connection = oClsConnection.Conectar();
                //Executar Comando
                DataTable oDataTable = new DataTable();
                oDataTable.Load(oSqlCmd.ExecuteReader());
                oCombo.ValueMember = "codigo";
                oCombo.DisplayMember = "descricao";
                oCombo.DataSource = oDataTable;
                oCombo.SelectedIndex = -1;
                oCombo.Text = "";
                //Desconectar
                oClsConnection.Desconectar();               

            }
            catch (SqlException erro)
            {
                this.sMensagem = "Erro. " + erro.ToString();
                MessageBox.Show(this.sMensagem);
            }
        }

        public Boolean ValidateCombo(ComboBox oCombo, Control oControl) 
        {
            if (oCombo.SelectedIndex == -1) 
            {
                oControl.ForeColor = Color.Firebrick;
                oCombo.Focus();
                MessageBox.Show("O campo [" + oControl.Text.Replace(":", "") + "] é obrigatório. Digite um valor para ele.");
                return false;
            }
            else
            {
                oControl.ForeColor = Color.Black;
                return true;
            }
        }

        public Boolean ValidateTexto(TextBox oTextBox, Control oControl)
        {
            if (oTextBox.Text == "")
            {
                oControl.ForeColor = Color.Firebrick;
                oTextBox.Focus();
                MessageBox.Show("O campo [" + oControl.Text.Replace(":","") + "] é obrigatório. Digite um valor para ele.");
                return false;
            }
            else
            {
                oControl.ForeColor = Color.Black;
                return true;
            }
        }

        public void CleanFields(Control oGroupBox)
        {
            foreach (Control oControl in oGroupBox.Controls)
            {
                if (oControl.GetType() == typeof(TextBox) || oControl.GetType() == typeof(MaskedTextBox) || oControl.GetType() == typeof(ComboBox))
                {
                    oControl.Text = "";
                }
                if (oControl.GetType() == typeof(Button))
                {
                    oControl.Tag = -1;
                }
                if (oControl.GetType() == typeof(GroupBox))
                {
                    CleanFields(oControl);
                }
            }
        }

        public void GridConfig(DataGridView oGrid)
        {
            
            for (int i = 0; i < oGrid.Columns.Count; i++)
            {
                if (oGrid.Columns[i].Name.Contains("check_") == false && oGrid.Columns[i].Name.Contains("editar_") == false && oGrid.Columns[i].Name.Contains("visualizar_") == false)
                {
                    oGrid.Columns[i].ReadOnly = true;
                }
                if (oGrid.Columns[i].Name.Contains("codigo") == true)
                {
                    oGrid.Columns[i].Visible = false;
                }
                if (oGrid.Columns[i].Name == "foto")
                {
                    oGrid.Columns[i].Visible = false;
                }
            }
        }

    }
}
