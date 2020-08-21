using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFBuscarCheque : Form
    {
        private CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rtitulo;
        public CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rTitulo
        {
            get
            {
                if (BS_Titulo.Current != null)
                    return BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo;
                else
                    return null;
            }
            set { rtitulo = value; }
        }

        public TFBuscarCheque()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (BS_Titulo.Current != null)
                this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] vBusca = new Utils.TpBusca[3];
            //PAGAR
            vBusca[0].vNM_Campo = "a.TP_Titulo";
            vBusca[0].vOperador = "=";
            vBusca[0].vVL_Busca = "'P'";
            //COMPENSAR
            vBusca[1].vNM_Campo = "isNull(a.Status_Compensado, 'N')";
            vBusca[1].vOperador = "=";
            vBusca[1].vVL_Busca = "'N'";
            //Buscar cheques que não foram liquidados  
            vBusca[2].vNM_Campo = string.Empty;
            vBusca[2].vOperador = "not exists";
            vBusca[2].vVL_Busca = "(select 1 from TB_FIN_Titulo_X_Liquidacao x " +
                                   "where x.cd_empresa = a.cd_empresa " +
                                   "and x.Nr_LanctoCheque = a.Nr_LanctoCheque " +
                                   "and  x.CD_Banco = a.CD_Banco ) ";
            if (!string.IsNullOrEmpty(cd_empresabusca.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_empresabusca.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(cd_bancobusca.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Banco";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_bancobusca.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(nr_chequebusca.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Cheque";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nr_chequebusca.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (Vl_Titulo_Inic.Value > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), Vl_Titulo_Inic.Value.ToString("."));
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (Vl_Titulo_Final.Value > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Titulo";
                vBusca[vBusca.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), Vl_Titulo_Final.Value.ToString("."));
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }

            BS_Titulo.DataSource =  new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(vBusca, 0, string.Empty, string.Empty);
            BS_Titulo.ResetCurrentItem();
        }

        private void TFBuscarCheque_Load(object sender, EventArgs e)
        {
            pTitulo.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.ShapeGrid.RestoreShape(this, dG_Titulo);
        }

        private void cd_empresabusca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresabusca.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresabusca});
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresabusca }, string.Empty);
        }

        private void cd_bancobusca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("CD_banco|=|'" + cd_bancobusca.Text + "'"
                , new Componentes.EditDefault[] { cd_bancobusca }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("ds_banco|Descrição|150;CD_banco|Código|80|nr_agencia|Agencia|80"
                , new Componentes.EditDefault[] { cd_bancobusca }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
           
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFBuscarCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFBuscarCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dG_Titulo);
        }
    }
}
