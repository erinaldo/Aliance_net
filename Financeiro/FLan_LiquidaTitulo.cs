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
    public partial class TFLan_LiquidaTitulo : Form
    {
        public string pTp_mov
        { get; set; }
        public string pCd_contager
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheques
        { get; set; }

        public TFLan_LiquidaTitulo()
        {
            InitializeComponent();
            lCheques = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }

        private void bb_contager_destino_Click(object sender, EventArgs e)
        {
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if(pTp_mov.Trim().ToUpper().Equals("P"))
                vCond += ";a.cd_contager_compensacao|=|'" + pCd_contager.Trim() + "'";
            if (pCd_empresa.Trim() != string.Empty)
                if (vCond.Trim() != string.Empty)
                    vCond += vCond.Trim().Equals(string.Empty) ? string.Empty : ";" + "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + pCd_empresa.Trim() + "' )";

            UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void cd_contager_destino_Leave(object sender, EventArgs e)
        {
            string vCond = "a.CD_CONTAGER|=|'" + cd_contager_destino.Text.Trim() + "';" +
                           "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if(pTp_mov.Trim().ToUpper().Equals("P"))
                vCond += ";a.cd_contager_compensacao|=|'" + pCd_contager.Trim() + "'";

            if (pCd_empresa.Trim() != string.Empty)
                vCond += ";|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + pCd_empresa.Trim() + "')";


            UtilPesquisa.EDIT_LEAVE(vCond
                , new Componentes.EditDefault[] { cd_contager_destino, ds_contager_destino }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((BS_Titulo.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Exists(p =>
                    p.Dt_emissao.Value.Date > Convert.ToDateTime(dt_compensacao.Text).Date))
                {
                    MessageBox.Show("Data de compensação não pode ser maior que data de emissão do cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (BS_Titulo.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).ForEach(p =>
                    {
                        p.Dt_compensacaostring = dt_compensacao.Text;
                        p.Observacao = Compl_Historico.Text.Trim();
                        p.Cd_contager_destino = cd_contager_destino.Text;
                    });
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFLan_LiquidaTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                BB_Gravar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFLan_LiquidaTitulo_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dG_Titulo);
            pDados.set_FormatZero();
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar conta gerencial de compensacao
            CamadaDados.Financeiro.Cadastros.TList_CadContaGer lContager = CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(string.Empty, 
                                                                                                                                     string.Empty, 
                                                                                                                                     null,
                                                                                                                                     string.Empty, 
                                                                                                                                     string.Empty, 
                                                                                                                                     "N",
                                                                                                                                     string.Empty, 
                                                                                                                                     decimal.Zero,
                                                                                                                                     this.pCd_contager,
                                                                                                                                     this.pCd_empresa, 
                                                                                                                                     string.Empty, 
                                                                                                                                     string.Empty,
                                                                                                                                     0,
                                                                                                                                     null);
            if (lContager.Count > 0)
            {
                cd_contager_destino.Text = lContager[0].Cd_contager;
                ds_contager_destino.Text = lContager[0].Ds_contager;
            }
            //Somar valor dos titulos a compensar
            if(lCheques != null)
                vl_titulo.Value = lCheques.Sum(p => p.Vl_titulo);
            BS_Titulo.DataSource = lCheques;
            dt_compensacao.Focus();
        }

        private void TFLan_LiquidaTitulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dG_Titulo);
        }
    }
}
