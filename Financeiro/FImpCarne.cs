using System;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Bloqueto;
using FormRelPadrao;
using CamadaNegocio.Financeiro.Bloqueto;

namespace Financeiro
{
    public partial class TFImpCarne : Form
    {
        private bool Altera_Relatorio = false;
        public TFImpCarne()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if(cbEmpresa.SelectedItem != null &&
                !string.IsNullOrEmpty(cd_clifor_sacado.Text))
                dsBloqueto.DataSource = TCN_Titulo.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                          decimal.Zero,
                                                          decimal.Zero,
                                                          decimal.Zero,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          cd_clifor_sacado.Text,
                                                          string.Empty,
                                                          decimal.Zero,
                                                          decimal.Zero,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          "'A'",
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          false,
                                                          0,
                                                          null);
        }

        private void TFImpCarne_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
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
            if (cbEmpresa.Items.Count > 0)
                cbEmpresa.SelectedIndex = 0;
        }

        private void bb_clifor_sacado_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_sacado, nm_clifor }, string.Empty);
            afterBusca();
        }

        private void cd_clifor_sacado_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor_sacado.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor_sacado, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            afterBusca();
        }
        
        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if(dsBloqueto.Count > 0)
                if((dsBloqueto.List as blListaTitulo).Exists(p=> p.St_processar))
                {
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de impressao para o bloqueto
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                            fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                    (dsBloqueto.List as blListaTitulo).Where(p=> p.St_processar).OrderBy(p => p.Dt_vencimento).ToList(),
                                                                    fImp.pSt_imprimir,
                                                                    fImp.pSt_visualizar,
                                                                    fImp.pSt_enviaremail,
                                                                    fImp.pSt_exportPdf,
                                                                    fImp.Path_exportPdf,
                                                                    fImp.pDestinatarios,
                                                                    "BLOQUETO Nº " + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim(),
                                                                    fImp.pDs_mensagem,
                                                                    true);
                        }
                    }
                    else
                        TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                            (dsBloqueto.List as blListaTitulo).Where(p=> p.St_processar).OrderBy(p => p.Dt_vencimento).ToList(),
                                                            false,
                                                            false,
                                                            false,
                                                            false,
                                                            string.Empty,
                                                            null,
                                                            string.Empty,
                                                            string.Empty,
                                                            true);

                    Altera_Relatorio = false;
                    (dsBloqueto.List as blListaTitulo).ForEach(p => p.St_processar = false);
                    dsBloqueto.ResetBindings(true);
                }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gBloquetos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (dsBloqueto.Current as blTitulo).St_processar =
                    !(dsBloqueto.Current as blTitulo).St_processar;
                dsBloqueto.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (dsBloqueto.Count > 0)
            {
                (dsBloqueto.List as blListaTitulo).ForEach(p => p.St_processar = cbTodos.Checked);
                dsBloqueto.ResetBindings(true);
            }
        }
    }
}
