using AQUA_DATA.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AQUA_DATA
{
    public partial class frmAquarioFoto : Form
    {
        //Instancia as classes

        byte[] byteFoto;
       public byte[] ByteFoto { get => byteFoto; set => byteFoto = value; }

        #region "CONTROLS"

        public frmAquarioFoto()
        {
            InitializeComponent();
        }
        private void frmAquarioFoto_Load(object sender, EventArgs e)
        {
            //Procedimento que carrega os componentes da tela
            FormConfiguration();
        }

        #endregion

        #region "FUNCTIONS"

        public void FormConfiguration()
        {
            MemoryStream oMemoryStream = new MemoryStream(byteFoto);
            pctFoto.Image = Image.FromStream(oMemoryStream);
        }

       
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
