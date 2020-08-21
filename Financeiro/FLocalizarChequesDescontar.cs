using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Titulo;
using FormBusca;

namespace Financeiro
{
    public partial class TFLocalizarChequesDescontar : Form
    {
        public List<TRegistro_LanTitulo> lCheques
        {
            get
            {
                return (bsCheques.DataSource as TList_RegLanTitulo).FindAll(p => p.St_conciliar);
            }
        }

        public TFLocalizarChequesDescontar()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (cd_empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[3];
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            filtro[1].vNM_Campo = "a.tp_titulo";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'R'";
            filtro[2].vNM_Campo = "isnull(a.status_compensado, 'N')";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'N'";
            if (!string.IsNullOrEmpty(CD_Banco.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_banco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Banco.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(NR_Cheque.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cheque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_Cheque.Text.Trim() + "'";
            }
            if (DT_Inic.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rG_FiltroData.NM_Valor.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if(DT_Final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rG_FiltroData.NM_Valor.Trim().ToUpper().Equals("E") ? "a.dt_emissao" : "a.dt_vencto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (Vl_Titulo_Inic.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_titulo";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), Vl_Titulo_Inic.Value.ToString());
            }
            if (Vl_Titulo_Final.Value > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_titulo";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = string.Format(new System.Globalization.CultureInfo("en-US", true), Vl_Titulo_Final.Value.ToString());
            }
            bsCheques.DataSource = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(filtro, 0, string.Empty, "a.nr_cheque");
            if (bsCheques.DataSource != null)
                Vl_TotalTitulo.Value = (bsCheques.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
        }

        private void gCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCheques.Current as TRegistro_LanTitulo).St_conciliar = !(bsCheques.Current as TRegistro_LanTitulo).St_conciliar;
                bsCheques.ResetCurrentItem();
                if(bsCheques.DataSource != null)
                    Vl_TotalTitulo.Value = (bsCheques.DataSource as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo).Where(p => p.St_conciliar).Sum(p => p.Vl_titulo);
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome|150;a.CD_EMPRESA|Código|80"
                            , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("ds_banco|Descrição|150;CD_banco|Código|80|nr_agencia|Agencia|80"
                , new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), string.Empty);
        }

        private void CD_Banco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_banco|=|'" + CD_Banco.Text.Trim() + "'"
                , new Componentes.EditDefault[] { CD_Banco }, new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLocalizarChequesDescontar_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheques);
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pTotal.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void TFLocalizarChequesDescontar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFLocalizarChequesDescontar_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utils.ShapeGrid.SaveShape(this, gCheques);
        }
    }
}
