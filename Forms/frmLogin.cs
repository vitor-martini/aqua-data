using AQUA_DATA.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQUA_DATA
{
    public partial class frmLogin : Form
    {
        //Instancia as classes
        clsMainFunctions oclsMainFunctions = new clsMainFunctions();
        clsFrmLogin oClsFrmLogin = new clsFrmLogin();
        clsfrmAquario oClsfrmAquario = new clsfrmAquario();


        #region "CONTROLS"

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Procedimento que carrega os componentes da tela
            FormConfiguration();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAquario ofrmAquario = new frmAquario();
            ofrmAquario.OldForm = this.Name;
            ofrmAquario.ShowDialog();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
           if (ValidateFields() == true)
           {
                if(oClsFrmLogin.ValidateLogin(Convert.ToInt32(cboAquario.SelectedValue), txtSenha.Text) == true)
                {
                    this.Hide();
                    frmMenu frmMenu = new frmMenu();
                    clsLoggedInfo.iCodigoAquario = Convert.ToInt32(cboAquario.SelectedValue);

                    oClsfrmAquario.LoadCaminhoArquivo();
                    clsLoggedInfo.sCaminhoArquivo = oClsfrmAquario.CaminhoArquivo;

                    frmMenu.ShowDialog();
                }
                else
                {                   
                    txtSenha.Text = "";
                    txtSenha.Focus();
                    MessageBox.Show("Senha inválida!");
                }              
            }
        }

        #endregion

        #region "FUNCTIONS"

        public void FormConfiguration()
        {
            //Carrega combo
            oclsMainFunctions.LoadCombo(cboAquario, "sp_select_aquario_combo");
        }

        public Boolean ValidateFields()
        {      
            if (oclsMainFunctions.ValidateCombo(cboAquario, lblAquario) == false)
            {
                return false;
            }
            if (oclsMainFunctions.ValidateTexto(txtSenha, lblSenha) == false)
            {
                return false;
            }
            return true;

        }
        #endregion
    }
}
