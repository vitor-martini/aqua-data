using AQUA_DATA.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQUA_DATA
{
    public partial class frmAcompanhamento : Form
    {
        #region "VARIABLES"

        //Instancia as classes
        clsMainFunctions oClsMainFunctions = new clsMainFunctions();
        clsFrmAcompanhamento oClsFrmAcompanhamento = new clsFrmAcompanhamento();

        public frmAcompanhamento()
        {
            InitializeComponent();
        }

        #endregion

        #region "CONTROLS"

        #region "AQUÁRIO"
        private void frmAcompanhamento_Load(object sender, EventArgs e)
        {
            FormConfiguration();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu ofrmMenu = new frmMenu();
            ofrmMenu.ShowDialog();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (oClsMainFunctions.ValidateCombo(cboData, lblData) == true)
            {
                oClsFrmAcompanhamento.LoadGridAcompanhamento(grdAcompanhamento, cboData.Text);
                grdAcompanhamento.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void grdAcompanhamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAcompanhamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
            {
                string sDay = Convert.ToInt32(grdAcompanhamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString();
                string sMonth = Convert.ToDateTime(cboData.SelectedValue).Month.ToString();

                if (sMonth.Length == 1)
                {
                    sMonth = "0" + sMonth;
                }

                string sYear = Convert.ToDateTime(cboData.SelectedValue).Year.ToString();
                string sDate = sDay + "/" + sMonth + "/" + sYear;

                this.Hide();
                frmAquario oFrmAquario = new frmAquario();
                oFrmAquario.DataAcompanhamento = sDate;
                oFrmAquario.OldForm = "frmAcompanhamento";
                oFrmAquario.Show();

            }
        }

        #endregion      

        #endregion

        #region "FUNCTIONS"

        #region "ACOMPANHAMENTO"
        public void FormConfiguration()
        {
            //Carrega combo
            oClsMainFunctions.LoadCombo(cboData, "sp_select_data_combo");   
            cboData.SelectedValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            if (oClsMainFunctions.ValidateCombo(cboData, lblData) == true)
            {
                oClsFrmAcompanhamento.LoadGridAcompanhamento(grdAcompanhamento, cboData.Text);
                grdAcompanhamento.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public Boolean ValidateFields()
        {
            if (oClsMainFunctions.ValidateCombo(cboData, lblData) == false)
            {
                return false;
            }          

            return true;

        }

        #endregion

        #endregion
             
    }
}
