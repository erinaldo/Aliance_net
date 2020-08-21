using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento
{
    public partial class TFLanNotasFrete : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }

        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNf
        {
            get
            {
                if (bsNotaFiscal.Count > 0)
                    return (bsNotaFiscal.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento).FindAll(p => p.St_formarlotectrc);
                else
                    return null;
            }
        }

        public TFLanNotasFrete()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Tp_movimento = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'"+Cd_empresa.Trim()+"'";
            //Tipo de Movimento
            filtro[1].vNM_Campo = "a.tp_movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'"+Tp_movimento.Trim().ToUpper()+"'";
            //Clifor
            filtro[2].vNM_Campo = "a.cd_clifor";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'"+Cd_clifor.Trim()+"'";
            //Nota nao cancelada
            filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'A'";
            //Nao pode estar amarrado a um conhecimento de frete diferente de cancelado
            filtro[4].vNM_Campo = string.Empty;
            filtro[4].vOperador = "not exists";
            filtro[4].vVL_Busca = "(select 1 from tb_ctr_notafiscal x " +
                                  "inner join tb_ctr_conhecimentofrete y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.nr_lanctoctr = y.nr_lanctoctr " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                  "and isnull(y.st_registro, 'A') in('A', 'P'))";
            if(nr_notafiscal.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_notafiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_notafiscal.Text;
            }
            if (nr_serie.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_serie.Text;
            }
            if (nr_pedido.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedido.Text;
            }
            if ((DT_Inicial.Text.Trim() != string.Empty) &&
                (DT_Inicial.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rbEmissao.Checked ? "a.dt_emissao":"a.dt_saient";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((DT_Final.Text.Trim() != string.Empty) &&
                (DT_Final.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rbEmissao.Checked ? "a.dt_emissao" : "a.dt_saient";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            bsNotaFiscal.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(filtro, 0, string.Empty);
        }

        private void TFLanNotasFrete_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gNotaFiscal);
            panelDados3.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados8.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_empresa.Text = Cd_empresa;
            nm_empresa.Text = Nm_empresa;
            cd_clifor.Text = Cd_clifor;
            nm_clifor.Text = Nm_clifor;
            tp_movimento.Text = Tp_movimento.Trim().Equals("E") ? "ENTRADA" : "SAIDA";
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.nr_serie|Nº Série|80;a.DS_SerieNF|Descrição|150"
                , new Componentes.EditDefault[] { nr_serie }, new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), string.Empty);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.nr_serie|=|'" + nr_serie.Text.Trim() + "'",
                new Componentes.EditDefault[] { nr_serie }, new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_pedido_Click(object sender, EventArgs e)
        {
            string vParam = "||(isnull(a.st_pedido, 'A') in ('F', 'P'));" +
                            "a.cd_clifor|=|'" + Cd_clifor.Trim() + "';" +
                            "a.tp_movimento|=|'" + Tp_movimento.Trim().ToUpper() + "';" +
                            "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                            "where x.cfg_pedido = a.cfg_pedido " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NR_Pedido|Nº Pedido|100;f.NM_Clifor|Nome|120;a.CD_Clifor|CódClifor|80"
                , new Componentes.EditDefault[] { nr_pedido }
                , new CamadaDados.Faturamento.Pedido.TCD_Pedido(), vParam);
        }

        private void nr_pedido_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_pedido|=|" + nr_pedido.Text + ";" +
                              "||(isnull(a.st_pedido, 'A') in ('F', 'P'));" +
                              "a.cd_clifor|=|'" + Cd_clifor.Trim() + "';" +
                              "a.tp_movimento|=|'" + Tp_movimento.Trim().ToUpper() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                              "where x.cfg_pedido = a.cfg_pedido " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas,
               new Componentes.EditDefault[] { nr_pedido }, new CamadaDados.Faturamento.Pedido.TCD_Pedido());
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
            if (bsNotaFiscal.Current != null)
            {
                if (!(bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).St_formarlotectrc)
                {
                    MessageBox.Show("Obrigatório selecionar Lote CTRC para gravar nota!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Obrigatório efetuar busca para gravar nota!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                this.DialogResult = DialogResult.OK;
        }

        private void TFLanNotasFrete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gNotaFiscal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).St_formarlotectrc =
                    !(bsNotaFiscal.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento).St_formarlotectrc;
                bsNotaFiscal.ResetBindings(true);
            }
        }

        private void TFLanNotasFrete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gNotaFiscal);
        }
    }
}
