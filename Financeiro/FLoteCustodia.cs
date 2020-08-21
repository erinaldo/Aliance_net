using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFLoteCustodia : Form
    {
        private CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia rlote;
        public CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia rLote
        {
            get
            {
                return bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia;
            }
            set
            {
                rlote = value;
            }
        }

        public TFLoteCustodia()
        {
            InitializeComponent();
            rlote = null;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("CUSTODIA", "C"));
            cbx.Add(new Utils.TDataCombo("DEPOSITO", "D"));
            tp_registro.DataSource = cbx;
            tp_registro.DisplayMember = "Display";
            tp_registro.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if(this.pLote.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            if (bsLoteCustodia.Current != null)
            {
                if (string.IsNullOrEmpty(cd_empresa.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresa.Focus();
                    return;
                }
                using (TFTitulosCustodia fCustodia = new TFTitulosCustodia())
                {
                    fCustodia.Cd_empresa = cd_empresa.Text;
                    if (fCustodia.ShowDialog() == DialogResult.OK)
                        if (fCustodia.lChCustodia != null)
                        {
                            fCustodia.lChCustodia.ForEach(p => (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodia.Add(p));
                            bsLoteCustodia.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirItem()
        {
            if (bsChequesCustodia.Current != null)
            {
                (bsLoteCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCustodia).lChCustodiaDel.Add(
                    (bsChequesCustodia.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo));
                bsChequesCustodia.RemoveCurrent();
            }
            else
                MessageBox.Show("Necessario selecionar cheque para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLoteCustodia_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pLote.set_FormatZero();
            if (rlote != null)
            {
                cd_empresa.Enabled = false;
                bb_empresabusca.Enabled = false;
                cd_contager.Enabled = rlote.St_registro.Trim().ToUpper().Equals("A");
                bb_contager.Enabled = rlote.St_registro.Trim().ToUpper().Equals("A");
                tp_registro.Enabled = rlote.St_registro.Trim().ToUpper().Equals("A");
                btn_Inserir_Item.Enabled = rlote.St_registro.Trim().ToUpper().Equals("A");
                btn_Deleta_Item.Enabled = rlote.St_registro.Trim().ToUpper().Equals("A");
                bsLoteCustodia.Add(rlote);
                bsLoteCustodia.ResetCurrentItem();
            }
            else
                bsLoteCustodia.AddNew();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLoteCustodia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && btn_Inserir_Item.Enabled)
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && btn_Deleta_Item.Enabled)
                this.ExcluirItem();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if(!string.IsNullOrEmpty(cd_contager.Text))
                vParam += ";|exists|(select 1 from tb_contager_x_empresa x "+
                          "         where x.cd_empresa = a.cd_empresa "+
                          "         and x.cd_contager = '" + cd_contager.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresabusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100";
            string vParam = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if(!string.IsNullOrEmpty(cd_contager.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x "+
                          "         where x.cd_empresa = a.cd_empresa "+
                          "         and x.cd_contager = '" + cd_contager.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Contager|Conta Gerencial|300;a.CD_ContaGer|Cd. Conta|100";
            string vParam = "|EXISTS|(select 1 from Tb_div_usuario_X_contager  x where x.cd_contager = A.cd_contager " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                          "isnull(a.cd_banco, '')|<>|'';" +
                          "isnull(a.st_contacompensacao, 'N')|<>|'S'";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "         where x.cd_contager = a.cd_contager " +
                          "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager }
                          , new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_contager  x where x.cd_contager = A.cd_contager " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                  "isnull(a.cd_banco, '')|<>|'';" +
                                  "isnull(a.st_contacompensacao, 'N')|<>|'S'";
            if(!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x "+
                          "         where x.cd_contager = a.cd_contager "+
                          "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void TFLoteCustodia_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
