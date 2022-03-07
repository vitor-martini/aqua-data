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
    public partial class frmMenu : Form
    {
        //Instancia as classes
        clsMainFunctions oClsMainFunctions = new clsMainFunctions();
        clsFrmMenu oClsFrmMenu = new clsFrmMenu();


        #region "CONTROLS"

        public frmMenu ()
        {
            InitializeComponent();
        }
             

        #endregion

        #region "FUNCTIONS"

        public Boolean ValidateFields()
        {
            //if (oClsMainFunctions.ValidateTexto(txtDescricao, lblDescricao) == false)
            //{
            //    return false;
            //}
            //if (oClsMainFunctions.ValidateTexto(txtSenha, lblSenha) == false)
            //{
            //    return false;
            //}
            //if (oClsMainFunctions.ValidateTexto(txtConfirmarSenha, lblConfirmarSenha) == false)
            //{
            //    return false;
            //}
            //if (txtSenha.Text != txtConfirmarSenha.Text)
            //{
            //    MessageBox.Show("As senhas não coincidem!");
            //    txtSenha.Text = "";
            //    txtSenha.Focus();
            //    txtConfirmarSenha.Text = "";
            //    return false;
            //}

            return true;

        }

        #endregion

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAquario ofrmAquario = new frmAquario();
            ofrmAquario.OldForm = this.Name;
            ofrmAquario.ShowDialog();
        }

        private void acompanhamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAcompanhamento ofrmAcompanhamento = new frmAcompanhamento();
            ofrmAcompanhamento.ShowDialog();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAquarioConfiguracao oFrmAquarioConfiguracao = new frmAquarioConfiguracao();
            oFrmAquarioConfiguracao.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLoggedInfo.iCodigoAquario = -1;
            clsLoggedInfo.sCaminhoArquivo = "";
            this.Hide();
            frmLogin ofrmLogin = new frmLogin();
            ofrmLogin.ShowDialog();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
