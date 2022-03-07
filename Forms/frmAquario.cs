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
    public partial class frmAquario : Form
    {
        #region "VARIABLES"

        //Instancia as classes
        clsMainFunctions oClsMainFunctions = new clsMainFunctions();
        clsfrmAquario oClsfrmAquario = new clsfrmAquario();
        enum TipoDetalhe
        {
            Acessorio, //0
            Parametro, //1
            Fauna, //2
            Flora, //3
            Arquivo, //4
            Observacao//5
        }

        string sOldForm = "";
        public string OldForm { get => sOldForm; set => sOldForm = value; }

        string sDataAcompanhamento = "";
        public string DataAcompanhamento { get => sDataAcompanhamento; set => sDataAcompanhamento = value; }
        public frmAquario()
        {
            InitializeComponent();
        }

        #endregion

        #region "CONTROLS"

        #region "AQUÁRIO"
        private void frmAquario_Load(object sender, EventArgs e)
        {
            FormConfiguration();
        }

        private void txtComprimento_TextChanged(object sender, EventArgs e)
        {
            Volume();
        }

        private void txtLargura_TextChanged(object sender, EventArgs e)
        {
            Volume();
        }

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            Volume();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateFields() == true)
            {

                double dCumprimento = 0;
                double dLargura = 0;
                double dAltura = 0;
                if (double.TryParse(txtComprimento.Text.Replace(",", "."), out dCumprimento) == false)
                {
                    txtComprimento.Text = "";
                }
                if (double.TryParse(txtLargura.Text.Replace(",", "."), out dLargura) == false)
                {
                    txtLargura.Text = "";
                }
                if (double.TryParse(txtAltura.Text.Replace(",", "."), out dAltura) == false)
                {
                    txtAltura.Text = "";
                }

                oClsfrmAquario.Descricao = txtDescricao.Text;
                oClsfrmAquario.Senha = txtSenha.Text;
                oClsfrmAquario.Comprimento = dCumprimento;
                oClsfrmAquario.Largura = dLargura;
                oClsfrmAquario.Altura = dAltura;
                oClsfrmAquario.DiaMontagem = txtDataMontagem.Text;
                oClsfrmAquario.Observacao = txtObservacao.Text;

                if (OldForm == "frmLogin")
                {
                    oClsfrmAquario.InsertAquario();
                    oClsMainFunctions.CleanFields(grpAquario);
                }
                if (OldForm == "frmMenu")
                {
                    oClsfrmAquario.UpdateAquario();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

            this.Hide();

            if (OldForm == "frmLogin")
            {
                frmLogin ofrmLogin = new frmLogin();
                ofrmLogin.ShowDialog();
            }
            if (OldForm == "frmMenu")
            {
                frmMenu ofrmMenu = new frmMenu();
                ofrmMenu.ShowDialog();
            }
            if (OldForm == "frmAcompanhamento")
            {
                frmAcompanhamento ofrmAcompanhamento = new frmAcompanhamento();
                ofrmAcompanhamento.ShowDialog();
            }
        }
        #endregion

        #region "ACESSÓRIO"
        private void btnAcessorioInserir_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsAcessorio() == true)
            {
                double dAcessorioQuantidade = 0;  
                if (double.TryParse(txtAcessorioQuantidade.Text.Replace(",", "."), out dAcessorioQuantidade) == false)
                {
                    txtAcessorioQuantidade.Text = "";
                }

                int iCodigoUnidadeMedida = -1;                
                if(cboAcessorioUnidadeMedida.SelectedIndex != -1)
                {
                    int.TryParse(cboAcessorioUnidadeMedida.SelectedValue.ToString(), out iCodigoUnidadeMedida);
                }
                oClsfrmAquario.CodigoUnidadeMedidaDetalhe = iCodigoUnidadeMedida;


                oClsfrmAquario.Detalhe = txtAcessorio.Text;
                oClsfrmAquario.DetalheDescricao = txtAcessorioDescricao.Text;
                oClsfrmAquario.DetalheQuantidade = dAcessorioQuantidade;
                oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Acessorio);
                oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnAcessorioInserir.Tag);
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                if (Convert.ToInt32(btnAcessorioInserir.Tag) == -1)
                {
                    oClsfrmAquario.InsertDetalhe();
                }
                else
                {
                    oClsfrmAquario.UpdateDetalhe();
                }
                oClsfrmAquario.LoadGridDetalhe(grdAcessorio, Convert.ToInt32(TipoDetalhe.Acessorio));
                oClsMainFunctions.CleanFields(grpAcessorio);
            }

        }

        private void btnAcessorioExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdAcessorio.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdAcessorio.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Acessorio);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdAcessorio.Rows[i].Cells[grdAcessorio.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdAcessorio, Convert.ToInt32(TipoDetalhe.Acessorio));
        }

        private void txtAcessorioQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtAcessorioQuantidade.Text.Replace(",", "."), out _) == false)
            {
                txtAcessorioQuantidade.Text = "";
            }
        }
        private void grdAcessorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAcessorio.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
            {
                txtAcessorio.Text = grdAcessorio.Rows[e.RowIndex].Cells[grdAcessorio.Columns["Identificação"].Index].Value.ToString();
                txtAcessorioDescricao.Text = grdAcessorio.Rows[e.RowIndex].Cells[grdAcessorio.Columns["Descrição"].Index].Value.ToString();
                txtAcessorioQuantidade.Text = grdAcessorio.Rows[e.RowIndex].Cells[grdAcessorio.Columns["Quantidade"].Index].Value.ToString();
                cboAcessorioUnidadeMedida.Text = grdAcessorio.Rows[e.RowIndex].Cells[grdAcessorio.Columns["Un. Medida"].Index].Value.ToString();
                btnAcessorioInserir.Tag = grdAcessorio.Rows[e.RowIndex].Cells[grdAcessorio.Columns["codigo"].Index].Value.ToString();
            }
        }

        private void grdAcessorio_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdAcessorio.EndEdit();
            }
        }

        private void grdAcessorio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdAcessorio.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdAcessorio.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdAcessorio.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion

        #region "PARÂMETROS"
        private void btnParametroInserir_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsParametro() == true)
            {
                double dParametroQuantidade = 0;

                if (double.TryParse(txtParametroQuantidade.Text.Replace(",", "."), out dParametroQuantidade) == false)
                {
                    txtParametroQuantidade.Text = "";
                }
                int iCodigoUnidadeMedida = -1;
                if (cboParametroUnidadeMedida.SelectedIndex != -1)
                {
                    int.TryParse(cboParametroUnidadeMedida.SelectedValue.ToString(), out iCodigoUnidadeMedida);
                }
                oClsfrmAquario.CodigoUnidadeMedidaDetalhe = iCodigoUnidadeMedida;
                oClsfrmAquario.Detalhe = txtParametro.Text;
                oClsfrmAquario.DetalheDescricao = txtParametroDescricao.Text;
                oClsfrmAquario.DetalheQuantidade = dParametroQuantidade;
                oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Parametro);
                oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnParametroInserir.Tag);
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                if (Convert.ToInt32(btnParametroInserir.Tag) == -1)
                {
                    oClsfrmAquario.InsertDetalhe();
                }
                else
                {
                    oClsfrmAquario.UpdateDetalhe();
                }
                oClsfrmAquario.LoadGridDetalhe(grdParametro, Convert.ToInt32(TipoDetalhe.Parametro));
                oClsMainFunctions.CleanFields(grpParametro);
            }
        }

        private void btnParametroExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdParametro.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdParametro.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Parametro);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdParametro.Rows[i].Cells[grdParametro.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdParametro, Convert.ToInt32(TipoDetalhe.Parametro));
        }
        private void txtParametroQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtParametroQuantidade.Text.Replace(",", "."), out _) == false)
            {
                txtParametroQuantidade.Text = "";
            }
        }
        private void grdParametro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdParametro.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
            {
                txtParametro.Text = grdParametro.Rows[e.RowIndex].Cells[grdParametro.Columns["Identificação"].Index].Value.ToString();
                txtParametroDescricao.Text = grdParametro.Rows[e.RowIndex].Cells[grdParametro.Columns["Descrição"].Index].Value.ToString();
                txtParametroQuantidade.Text = grdParametro.Rows[e.RowIndex].Cells[grdParametro.Columns["Quantidade"].Index].Value.ToString();
                cboParametroUnidadeMedida.Text = grdParametro.Rows[e.RowIndex].Cells[grdParametro.Columns["Un. Medida"].Index].Value.ToString();
                btnParametroInserir.Tag = grdParametro.Rows[e.RowIndex].Cells[grdParametro.Columns["codigo"].Index].Value.ToString();
            }
        }

        private void grdParametro_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdParametro.EndEdit();
            }
        }

        private void grdParametro_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdParametro.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdParametro.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdParametro.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        #endregion

        #region "FAUNA"
        private void txtFaunaQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtFaunaQuantidade.Text.Replace(",", "."), out _) == false)
            {
                txtFaunaQuantidade.Text = "";
            }
        }
        private void btnFaunaInserir_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsFauna() == true)
            {
                double dFaunaQuantidade = 0;

                if (double.TryParse(txtFaunaQuantidade.Text.Replace(",", "."), out dFaunaQuantidade) == false)
                {
                    txtFaunaQuantidade.Text = "";
                }
                int iCodigoUnidadeMedida = -1;
                if (cboFaunaUnidadeMedida.SelectedIndex != -1)
                {
                    int.TryParse(cboFaunaUnidadeMedida.SelectedValue.ToString(), out iCodigoUnidadeMedida);
                }
                oClsfrmAquario.CodigoUnidadeMedidaDetalhe = iCodigoUnidadeMedida;
                oClsfrmAquario.Detalhe = txtFauna.Text;
                oClsfrmAquario.DetalheDescricao = txtFaunaDescricao.Text;
                oClsfrmAquario.DetalheQuantidade = dFaunaQuantidade;
                oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Fauna);
                oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnFaunaInserir.Tag);
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                if (Convert.ToInt32(btnFaunaInserir.Tag) == -1)
                {
                    oClsfrmAquario.InsertDetalhe();
                }
                else
                {
                    oClsfrmAquario.UpdateDetalhe();
                }
                oClsfrmAquario.LoadGridDetalhe(grdFauna, Convert.ToInt32(TipoDetalhe.Fauna));
                oClsMainFunctions.CleanFields(grpFauna);
            }
        }

        private void btnFaunaExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdFauna.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdFauna.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Fauna);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdFauna.Rows[i].Cells[grdFauna.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdFauna, Convert.ToInt32(TipoDetalhe.Fauna));
        }
       
        private void grdFauna_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdFauna.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
            {
                txtFauna.Text = grdFauna.Rows[e.RowIndex].Cells[grdFauna.Columns["Identificação"].Index].Value.ToString();
                txtFaunaDescricao.Text = grdFauna.Rows[e.RowIndex].Cells[grdFauna.Columns["Descrição"].Index].Value.ToString();
                txtFaunaQuantidade.Text = grdFauna.Rows[e.RowIndex].Cells[grdFauna.Columns["Quantidade"].Index].Value.ToString();
                btnFaunaInserir.Tag = grdFauna.Rows[e.RowIndex].Cells[grdFauna.Columns["codigo"].Index].Value.ToString();
                cboFaunaUnidadeMedida.Text = grdFauna.Rows[e.RowIndex].Cells[grdFauna.Columns["Un. Medida"].Index].Value.ToString();
            }
        }

        private void grdFauna_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdFauna.EndEdit();
            }
        }

        private void grdFauna_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdFauna.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdFauna.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdFauna.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion

        #region "FLORA"
        private void txtFloraQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtFloraQuantidade.Text.Replace(",", "."), out _) == false)
            {
                txtFloraQuantidade.Text = "";
            }
        }
        private void btnFloraInserir_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsFlora() == true)
            {
                double dFloraQuantidade = 0;

                if (double.TryParse(txtFloraQuantidade.Text.Replace(",", "."), out dFloraQuantidade) == false)
                {
                    txtFloraQuantidade.Text = "";
                }
                int iCodigoUnidadeMedida = -1;
                if (cboFloraUnidadeMedida.SelectedIndex != -1)
                {
                    int.TryParse(cboFloraUnidadeMedida.SelectedValue.ToString(), out iCodigoUnidadeMedida);
                }
                oClsfrmAquario.CodigoUnidadeMedidaDetalhe = iCodigoUnidadeMedida;
                oClsfrmAquario.Detalhe = txtFlora.Text;
                oClsfrmAquario.DetalheDescricao = txtFloraDescricao.Text;
                oClsfrmAquario.DetalheQuantidade = dFloraQuantidade;
                oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Flora);
                oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnFloraInserir.Tag);
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                if (Convert.ToInt32(btnFloraInserir.Tag) == -1)
                {
                    oClsfrmAquario.InsertDetalhe();
                }
                else
                {
                    oClsfrmAquario.UpdateDetalhe();
                }
                oClsfrmAquario.LoadGridDetalhe(grdFlora, Convert.ToInt32(TipoDetalhe.Flora));
                oClsMainFunctions.CleanFields(grpFlora);
            }
        }

        private void btnFloraExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdFlora.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdFlora.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Flora);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdFlora.Rows[i].Cells[grdFlora.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdFlora, Convert.ToInt32(TipoDetalhe.Flora));
        }

        private void grdFlora_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdFlora.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
            {
                txtFlora.Text = grdFlora.Rows[e.RowIndex].Cells[grdFlora.Columns["Identificação"].Index].Value.ToString();
                txtFloraDescricao.Text = grdFlora.Rows[e.RowIndex].Cells[grdFlora.Columns["Descrição"].Index].Value.ToString();
                txtFloraQuantidade.Text = grdFlora.Rows[e.RowIndex].Cells[grdFlora.Columns["Quantidade"].Index].Value.ToString();
                cboFloraUnidadeMedida.Text = grdFlora.Rows[e.RowIndex].Cells[grdFlora.Columns["Un. Medida"].Index].Value.ToString();
                btnFloraInserir.Tag = grdFlora.Rows[e.RowIndex].Cells[grdFlora.Columns["codigo"].Index].Value.ToString();
            }
        }

        private void grdFlora_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdFlora.EndEdit();
            }
        }

        private void grdFlora_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdFlora.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdFlora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdFlora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion

        #region "OBSERVAÇÃO"
      
        private void btnObservacaoInserir_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsObservacao() == true)
            {
                
                oClsfrmAquario.CodigoUnidadeMedidaDetalhe = -1;
                oClsfrmAquario.Detalhe = "";
                oClsfrmAquario.DetalheDescricao = txtObservacaoDescricao.Text;
                oClsfrmAquario.DetalheQuantidade = 0;
                oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Observacao);
                oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnObservacaoInserir.Tag);
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                if (Convert.ToInt32(btnObservacaoInserir.Tag) == -1)
                {
                    oClsfrmAquario.InsertDetalhe();
                }
                else
                {
                    oClsfrmAquario.UpdateDetalhe();
                }
                oClsfrmAquario.LoadGridDetalhe(grdObservacao, Convert.ToInt32(TipoDetalhe.Observacao));
                oClsMainFunctions.CleanFields(grpObservacao);
            }
        }

        private void btnObservacaoExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdObservacao.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdObservacao.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Observacao);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdObservacao.Rows[i].Cells[grdObservacao.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdObservacao, Convert.ToInt32(TipoDetalhe.Observacao));
        }

        private void grdObservacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdObservacao.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
            {
                txtObservacaoDescricao.Text = grdObservacao.Rows[e.RowIndex].Cells[grdObservacao.Columns["Descrição"].Index].Value.ToString();
                btnObservacaoInserir.Tag = grdObservacao.Rows[e.RowIndex].Cells[grdObservacao.Columns["codigo"].Index].Value.ToString();
            }
        }

        private void grdObservacao_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdObservacao.EndEdit();
            }
        }

        private void grdObservacao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdObservacao.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdObservacao.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdObservacao.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion

        #region "ARQUIVO"
        private void btnArquivoInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsArquivo() == true)
                {
                    double dArquivoQuantidade = 0;

                    oClsfrmAquario.Detalhe = txtArquivo.Text;
                    oClsfrmAquario.DetalheDescricao = txtArquivoDescricao.Text;
                    oClsfrmAquario.DetalheQuantidade = dArquivoQuantidade;
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Arquivo);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(btnArquivoInserir.Tag);
                    oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;

                    Image img = pctFoto.Image;
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                    oClsfrmAquario.DetalheFoto = arr;
                    if (clsLoggedInfo.sCaminhoArquivo != "")
                    {
                        if (txtArquivo.Text.Contains(clsLoggedInfo.sCaminhoArquivo) == false)
                        {
                            string outputFileName = clsLoggedInfo.sCaminhoArquivo + txtArquivoNome.Text;
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    Bitmap bm = new Bitmap(pctFoto.Image);
                                    bm.Save(memory, ImageFormat.Jpeg);
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }

                        }
                        txtArquivo.Text = clsLoggedInfo.sCaminhoArquivo + txtArquivoNome.Text;
                    }
                    oClsfrmAquario.DetalheFotoUrl = txtArquivo.Text;
                    oClsfrmAquario.DetalheFotoNome = txtArquivoNome.Text;

                    if (Convert.ToInt32(btnArquivoInserir.Tag) == -1)
                    {
                        oClsfrmAquario.InsertDetalhe();
                    }
                    else
                    {
                        oClsfrmAquario.UpdateDetalhe();
                    }
                    oClsfrmAquario.LoadGridDetalhe(grdArquivo, Convert.ToInt32(TipoDetalhe.Arquivo));
                    oClsMainFunctions.CleanFields(grpArquivo);
                    pctFoto.Image = null;
                }

            }
            catch
            {
                MessageBox.Show("Verifique o caminho na aba 'configurações'.");
            }
            
        }

        private void btnArquivoExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdArquivo.Rows.Count; i++)
            {
                Boolean isCellChecked = Convert.ToBoolean(grdArquivo.Rows[i].Cells[0].Value);

                if (isCellChecked == true)
                {
                    oClsfrmAquario.CodigoTipoDetalhe = Convert.ToInt32(TipoDetalhe.Arquivo);
                    oClsfrmAquario.DetalheCodigo = Convert.ToInt32(grdArquivo.Rows[i].Cells[grdArquivo.Columns["codigo"].Index].Value);
                    oClsfrmAquario.DeleteDetalhe();
                }
            }

            oClsfrmAquario.LoadGridDetalhe(grdArquivo, Convert.ToInt32(TipoDetalhe.Arquivo));
        }

        private void grdArquivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdArquivo.Columns[e.ColumnIndex].Name.Contains("editar_") == true)
                {
                    txtArquivoNome.Text = grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["Arquivo"].Index].Value.ToString();
                    txtArquivo.Text = grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["URL"].Index].Value.ToString();
                    txtArquivoDescricao.Text = grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["Descrição"].Index].Value.ToString();
                    btnArquivoInserir.Tag = grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["codigo"].Index].Value.ToString();
                    byte[] byteFoto = (byte[])grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["foto"].Index].Value;
                    MemoryStream oMemoryStream = new MemoryStream(byteFoto);
                    pctFoto.Image = Image.FromStream(oMemoryStream);

                }
                if (grdArquivo.Columns[e.ColumnIndex].Name.Contains("visualizar_") == true)
                {
                    frmAquarioFoto oFrmAquarioFoto = new frmAquarioFoto();
                    oFrmAquarioFoto.ByteFoto = (byte[])grdArquivo.Rows[e.RowIndex].Cells[grdArquivo.Columns["foto"].Index].Value;
                    oFrmAquarioFoto.Show();
                }
            }
            catch 
            {

            }
           
        }

        private void grdArquivo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdArquivo.EndEdit();
            }
        }

        private void grdArquivo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(grdArquivo.Rows[e.RowIndex].Cells[0].Value) == true)
            {
                grdArquivo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                grdArquivo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnProcurarImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oOpenFileDialog = new OpenFileDialog())
            {
                oOpenFileDialog.Filter = "Imagens|*.jpg;*.jpeg;*.png";
                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtArquivo.Text = oOpenFileDialog.FileName;
                    txtArquivoNome.Text = oOpenFileDialog.SafeFileName;
                    pctFoto.Image = Image.FromFile(txtArquivo.Text);
                }
            }
        }
        #endregion 

        #endregion

        #region "FUNCTIONS"

        #region "AQUÁRIO"
        public void FormConfiguration()
        {
            oClsMainFunctions.CleanFields(grpAquario);
            oClsMainFunctions.CleanFields(grpAcessorio);
            oClsMainFunctions.CleanFields(grpParametro);
            oClsMainFunctions.CleanFields(grpFauna);
            oClsMainFunctions.CleanFields(grpFlora);
            oClsMainFunctions.CleanFields(grpArquivo);
            oClsMainFunctions.CleanFields(grpObservacao);
            lblAtualizacao.Text = "";

            tabMain.SelectTab("tabAquario");

            btnAcessorioInserir.Enabled = true;
            btnArquivoInserir.Enabled = true;
            btnFaunaInserir.Enabled = true;
            btnFloraInserir.Enabled = true;
            btnParametroInserir.Enabled = true;
            btnAcessorioExcluir.Enabled = true;
            btnArquivoExcluir.Enabled = true;
            btnFaunaExcluir.Enabled = true;
            btnFloraExcluir.Enabled = true;
            btnParametroExcluir.Enabled = true;
              
            oClsfrmAquario.DataAcompanhamento = "";

            if (OldForm == "frmLogin")
            {
                tabMain.TabPages.RemoveByKey("tabAcessorios");
                tabMain.TabPages.RemoveByKey("tabFauna");
                tabMain.TabPages.RemoveByKey("tabFlora");
                tabMain.TabPages.RemoveByKey("tabParametros");
                tabMain.TabPages.RemoveByKey("tabArquivo");
                tabMain.TabPages.RemoveByKey("tabObservacao");
            }
            else if (OldForm == "frmMenu")
            {
                btnSalvar.Enabled = true;
                btnAcessorioInserir.Enabled = false;
                btnArquivoInserir.Enabled = false;
                btnFaunaInserir.Enabled = false;
                btnFloraInserir.Enabled = false;
                btnParametroInserir.Enabled = false;
                btnAcessorioExcluir.Enabled = false;
                btnArquivoExcluir.Enabled = false;
                btnFaunaExcluir.Enabled = false;
                btnFloraExcluir.Enabled = false;
                btnParametroExcluir.Enabled = false;
            }
            else if (OldForm == "frmAcompanhamento")
            {
                oClsfrmAquario.DataAcompanhamento = sDataAcompanhamento;
                btnSalvar.Enabled = false;
                lblObservacao.Location = lblSenha.Location;
                txtObservacao.Location = txtSenha.Location;
                txtObservacao.MinimumSize = new Size(txtObservacao.Size.Width, 302);
                txtSenha.Visible = false;
                lblSenha.Visible = false;
                txtConfirmarSenha.Visible = false;
                lblConfirmarSenha.Visible = false;

            }

            oClsfrmAquario.LoadField(txtDescricao, txtDataMontagem, txtObservacao, txtComprimento, txtLargura, txtAltura, lblAtualizacao);
            oClsfrmAquario.LoadGridDetalhe(grdAcessorio, Convert.ToInt32(TipoDetalhe.Acessorio));
            oClsMainFunctions.LoadCombo(cboAcessorioUnidadeMedida, "sp_select_unidade_medida_combo");
            oClsfrmAquario.LoadGridDetalhe(grdArquivo, Convert.ToInt32(TipoDetalhe.Arquivo));
            oClsfrmAquario.LoadGridDetalhe(grdFauna, Convert.ToInt32(TipoDetalhe.Fauna));
            oClsMainFunctions.LoadCombo(cboFaunaUnidadeMedida, "sp_select_unidade_medida_combo");
            oClsfrmAquario.LoadGridDetalhe(grdFlora, Convert.ToInt32(TipoDetalhe.Flora));
            oClsMainFunctions.LoadCombo(cboFloraUnidadeMedida, "sp_select_unidade_medida_combo");
            oClsfrmAquario.LoadGridDetalhe(grdParametro, Convert.ToInt32(TipoDetalhe.Parametro));
            oClsMainFunctions.LoadCombo(cboParametroUnidadeMedida, "sp_select_unidade_medida_combo");
            oClsfrmAquario.LoadGridDetalhe(grdObservacao, Convert.ToInt32(TipoDetalhe.Observacao));
        }

        public Boolean ValidateFields()
        {
            if (oClsMainFunctions.ValidateTexto(txtDescricao, lblDescricao) == false)
            {
                return false;
            }
            if (OldForm == "frmLogin")
            {
                if (oClsMainFunctions.ValidateTexto(txtSenha, lblSenha) == false)
                {
                    return false;
                }
                if (oClsMainFunctions.ValidateTexto(txtConfirmarSenha, lblConfirmarSenha) == false)
                {
                    return false;
                }
            }
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas não coincidem!");
                txtSenha.Text = "";
                txtSenha.Focus();
                txtConfirmarSenha.Text = "";
                return false;
            }

            return true;

        }

        private void Volume()
        {

            double dCumprimento = 0;
            double dLargura = 0;
            double dAltura = 0;
            double dVolume = 0;

            if (double.TryParse(txtComprimento.Text.Replace(",", "."), out dCumprimento) == false)
            {
                txtComprimento.Text = "";
            }
            if (double.TryParse(txtLargura.Text.Replace(",", "."), out dLargura) == false)
            {
                txtLargura.Text = "";
            }
            if (double.TryParse(txtAltura.Text.Replace(",", "."), out dAltura) == false)
            {
                txtAltura.Text = "";
            }

            dVolume = ((dCumprimento * dLargura * dAltura) / 1000);
            if (dVolume == 0)
            {
                txtVolume.Text = "";
            }
            else
            {
                txtVolume.Text = ((dCumprimento * dLargura * dAltura) / 1000).ToString();
            }

        }
        #endregion

        #region "ACESSÓRIO"
        public Boolean ValidateFieldsAcessorio()
        {
            if (oClsMainFunctions.ValidateTexto(txtAcessorio, lblAcessorio) == false)
            {
                return false;
            }

            return true;

        }

        #endregion

        #region "PARÂMETROS"
        public Boolean ValidateFieldsParametro()
        {
            if (oClsMainFunctions.ValidateTexto(txtParametro, lblParametro) == false)
            {
                return false;
            }

            return true;

        }

        #endregion

        #region "FAUNA"
        public Boolean ValidateFieldsFauna()
        {
            if (oClsMainFunctions.ValidateTexto(txtFauna, lblFauna) == false)
            {
                return false;
            }

            return true;

        }

        #endregion

        #region "FLORA"
        public Boolean ValidateFieldsFlora()
        {
            if (oClsMainFunctions.ValidateTexto(txtFlora, lblFlora) == false)
            {
                return false;
            }

            return true;

        }

        #endregion

        #region "OBSERVAÇÃO"
        public Boolean ValidateFieldsObservacao()
        {
            if (oClsMainFunctions.ValidateTexto(txtObservacaoDescricao, lblObservacaoDescricao) == false)
            {
                return false;
            }

            return true;

        }

        #endregion
        #region "ARQUIVO"
        public Boolean ValidateFieldsArquivo()
        {
            if (oClsMainFunctions.ValidateTexto(txtArquivo, lblArquivo) == false)
            {
                return false;
            }
            if (oClsMainFunctions.ValidateTexto(txtArquivoNome, lblNomeArquivo) == false)
            {
                return false;
            }
            return true;

        }

        #endregion

        #endregion
    }
}
