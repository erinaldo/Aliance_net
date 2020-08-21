using CamadaDados.Contabil;
using CamadaDados.Graos;
using FormBusca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFAuditarProdutor : Form
    {
        public TFAuditarProdutor()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            //Buscar Nfs
            bsNfs.DataSource =
            new TCD_LanAuditarProdutor().Select(
                new FiltroAuditar[]
                {
                    new FiltroAuditar()
                    {
                        Cd_empresa = cbEmpresa.SelectedValue.ToString(),
                        Cd_clifor = cd_clifor.Text,
                        Dt_ini = Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd 00:00:00"),
                        Dt_fin = Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd 23:59:59")
                    }
                });
            //Buscar Balancete
            DateTime? Dt_fin = null;
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
                Dt_fin = DateTime.Parse(dt_fin.Text);
            bsBalanco.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.GerarBalanco(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                       string.Empty,
                                                                                       cd_conta.Text,
                                                                                       DateTime.Parse(dt_ini.Text),
                                                                                       Dt_fin,
                                                                                       false,
                                                                                       false,
                                                                                       string.Empty,
                                                                                       false,
                                                                                       false);
            //Somar comercial
            decimal ptot_fixar = (bsNfs.List as TList_LanAuditarProdutor).Where(p => p.Mov.Trim().ToUpper().Equals("PAUTA")).Sum(p => p.Vl_subtotal);
            tot_fixar.Text = ptot_fixar.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            decimal ptot_fixacao = (bsNfs.List as TList_LanAuditarProdutor).Where(p => p.Mov.Trim().ToUpper().Equals("FIXAÇÃO")).Sum(p => p.Vl_subtotal);
            tot_fixacao.Text = ptot_fixacao.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_credito.Text = (ptot_fixacao + ptot_fixar).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            decimal ptot_devolucao = (bsNfs.List as TList_LanAuditarProdutor).Where(p => p.Mov.Trim().ToUpper().Equals("DEVOLUÇÃO")).Sum(p => p.Vl_subtotal);
            tot_devolucao.Text = ptot_devolucao.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            decimal ptot_imposto = (bsNfs.List as TList_LanAuditarProdutor).Where(p => p.Mov.Trim().ToUpper().Equals("IMPOSTOS")).Sum(p => p.Vl_subtotal);
            tot_imposto.Text = ptot_imposto.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            decimal ptot_pagamento = (bsNfs.List as TList_LanAuditarProdutor).Where(p => p.Mov.Trim().ToUpper().Equals("RECEBIMENTO")).Sum(p => p.Vl_subtotal);
            tot_pagamento.Text = ptot_pagamento.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_debito.Text = (ptot_devolucao + ptot_pagamento + ptot_imposto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_credcomercial.Text = (ptot_fixacao + ptot_fixar).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_debcomercial.Text = (ptot_devolucao + ptot_pagamento + ptot_imposto).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_credcontabil.Text = (bsBalanco.List as List<TRegistro_BalancoSintetico>).Sum(p => p.Vl_credito).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            tot_debcontabil.Text = (bsBalanco.List as List<TRegistro_BalancoSintetico>).Sum(p => p.Vl_debito).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            difcredito.Text = Math.Abs(ptot_fixacao + ptot_fixar - (bsBalanco.List as List<TRegistro_BalancoSintetico>).Sum(p => p.Vl_credito)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            difdebito.Text = Math.Abs(ptot_devolucao + ptot_pagamento + ptot_imposto - (bsBalanco.List as List<TRegistro_BalancoSintetico>).Sum(p => p.Vl_debito)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            //Saldo Fixar
            TList_SaldoFixar lSaldo = new TCD_SaldoFixar().Select_E(cbEmpresa.SelectedValue.ToString(),
                                                                    cd_clifor.Text,
                                                                    string.Empty,
                                                                    DateTime.Parse(dt_fin.Text));
            TList_SaldoFixar resumo = new TList_SaldoFixar();
            var query = from t in lSaldo
                        group t by new { t.Nm_clifor, t.Ds_produto }
                        into grp
                        select new
                        {
                            grp.Key.Nm_clifor,
                            grp.Key.Ds_produto,
                            Peso = grp.Sum(t=> t.Peso),
                            Ps_devolvido = grp.Sum(t => t.Ps_devolvido),
                            Ps_fixado = grp.Sum(t=> t.Ps_fixado),
                            Ps_transf_E = grp.Sum(t=> t.Ps_transf_E),
                            Ps_transf_S = grp.Sum(t=> t.Ps_transf_S),
                            Valor = grp.Sum(t => t.Valor),
                            Vl_devolvido = grp.Sum(t=> t.Vl_devolvido),
                            Vl_fixado = grp.Sum(t=> t.Vl_fixado),
                            Vl_transf_E = grp.Sum(t=> t.Vl_transf_E),
                            Vl_transf_S = grp.Sum(t=> t.Vl_transf_S)
                        };
            query.ToList().ForEach(p => resumo.Add(new TRegistro_SaldoFixar { Nm_clifor = p.Nm_clifor, Ds_produto = p.Ds_produto,
                                                                              Peso = (p.Peso + p.Ps_transf_E - p.Ps_transf_S - p.Ps_devolvido - p.Ps_fixado),
                                                                              Valor = (p.Valor + p.Vl_transf_E - p.Vl_transf_S - p.Vl_devolvido - p.Vl_fixado) }));
            bsSaldoFixar.DataSource = resumo;
            //Buscar Lancamento Avulso
            bsLanContabil.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.Buscar(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                     cd_conta.Text,
                                                                                     dt_ini.Text,
                                                                                     dt_fin.Text,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     decimal.Zero,
                                                                                     decimal.Zero,
                                                                                     "AV",
                                                                                     null);
        }

        private void TFAuditarProdutor_Load(object sender, EventArgs e)
        {
            pConsulta.set_FormatZero();
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cd_conta_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cd_conta.Text + ";a.tp_conta|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_conta, ds_contactb },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_conta_Click(object sender, EventArgs e)
        {
            CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rConta =
               UtilPesquisa.BTN_BuscaContaCTB(null);
            if (rConta != null)
            {
                cd_conta.Text = rConta.Cd_conta_ctbstr;
                ds_contactb.Text = rConta.Ds_contactb;
            }
        }

        private void gNfs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if ((bsNfs[e.RowIndex] as TRegistro_LanAuditarProdutor).id_lotectb_fat == null)
                {
                    gNfs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    gNfs.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
                }
                else
                {
                    gNfs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gNfs.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular);
                }

            }
        }

        private void TFAuditarProdutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void bbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbDelAvulso_Click(object sender, EventArgs e)
        {
            if(bsLanContabil.Current != null)
                if (MessageBox.Show("Confirma exclusão do lançamento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                         DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Contabil.TCN_LanContabil.ExcluirLanctoAvulso(bsLanContabil.Current as CamadaDados.Contabil.TRegistro_LanctosCTB, null);
                        MessageBox.Show("Lançamento contabil avulso excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLanContabil.DataSource = CamadaNegocio.Contabil.TCN_LanContabil.Buscar(cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                                 cd_conta.Text,
                                                                                                 dt_ini.Text,
                                                                                                 dt_fin.Text,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 decimal.Zero,
                                                                                                 decimal.Zero,
                                                                                                 "AV",
                                                                                                 null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
