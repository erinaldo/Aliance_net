using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Cadastros
{
    public partial class TFCadQtdEstoque : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque rqtdestoque;
        public CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque rQtdEstoque
        {
            get
            {
                if (bsQtdEstoque.Current != null)
                    return bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque;
                else
                    return null;
            }
            set { rqtdestoque = value; }
        }

        public string Sigla_unidade
        { get; set; }

        public TFCadQtdEstoque()
        {
            InitializeComponent();
            this.Sigla_unidade = string.Empty;
        }

        private void afterGrava()
        {
            if (this.pDados.validarCampoObrigatorio())
            {
                if (qtd_max_estoque.Value.Equals(0) && qtd_min_estoque.Value.Equals(0))
                {
                    MessageBox.Show("Obrigatorio informar quantidade minima ou quantidade maxima.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (qtd_min_estoque.Focused)
                    (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_min_estoque = qtd_min_estoque.Value;
                if (qtd_max_estoque.Focused)
                    (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_max_estoque = qtd_max_estoque.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadQtdEstoque_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rqtdestoque != null)
            {
                bsQtdEstoque.DataSource = new CamadaDados.Estoque.Cadastros.TList_Produto_QtdEstoque() { rqtdestoque };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                qtd_min_estoque.Focus();
            }
            else
            {
                bsQtdEstoque.AddNew();
                (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Sigla_unidade = Sigla_unidade;
                bsQtdEstoque.ResetCurrentItem();
                cd_empresa.Focus();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFCadQtdEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
