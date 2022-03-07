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
    public partial class frmAquarioConfiguracao : Form
    {
        //Instancia as classes
        clsfrmAquario oClsfrmAquario = new clsfrmAquario();


        #region "CONTROLS"

        public frmAquarioConfiguracao()
        {
            InitializeComponent();
        }
        private void frmAquarioConfiguracao_Load(object sender, EventArgs e)
        {
            //Procedimento que carrega os componentes da tela
            FormConfiguration();
        }

        #endregion

        #region "FUNCTIONS"

        public void FormConfiguration()
        {
            oClsfrmAquario.LoadCaminhoArquivo();
            clsLoggedInfo.sCaminhoArquivo = oClsfrmAquario.CaminhoArquivo;
            txtCaminhoArquivo.Text = clsLoggedInfo.sCaminhoArquivo;
        }

       
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu ofrmMenu = new frmMenu();
            ofrmMenu.ShowDialog();
        }


        private void btnCaminho_Click(object sender, EventArgs e)
        {
            using (var oFolderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = oFolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(oFolderBrowserDialog.SelectedPath))
                {
                    txtCaminhoArquivo.Text = oFolderBrowserDialog.SelectedPath + "\\";
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            oClsfrmAquario.CaminhoArquivo = txtCaminhoArquivo.Text;
            oClsfrmAquario.UpdateAquarioCaminhoArquivo();
            clsLoggedInfo.sCaminhoArquivo = txtCaminhoArquivo.Text;
        }
    }
}
