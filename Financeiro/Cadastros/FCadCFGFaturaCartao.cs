using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFCadCFGFaturaCartao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGFaturaCartao()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Financeiro.Cadastros.TCN_CFGFaturaCartao.Gravar(bsCfgFaturaCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGFaturaCartao, null);
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            CamadaDados.Financeiro.Cadastros.TList_CFGFaturaCartao lista =
                CamadaNegocio.Financeiro.Cadastros.TCN_CFGFaturaCartao.Buscar(cd_empresa.Text,
                                                                              cd_historico_rec.Text,
                                                                              cd_historico_pag.Text,
                                                                              cd_historico_juro.Text,
                                                                              cd_historico_taxa.Text,
                                                                              null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgFaturaCartao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsCfgFaturaCartao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCfgFaturaCartao.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgFaturaCartao.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CFGFaturaCartao.Excluir(bsCfgFaturaCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGFaturaCartao, null);
                    pDados.LimparRegistro();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_rec, ds_historico_rec },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_rec.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_rec, ds_historico_rec },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_juro, ds_historico_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_juro_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_rec.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_juro, ds_historico_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_pag_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_pag, ds_historico_pag },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_pag_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_rec.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_pag, ds_historico_pag },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_taxa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_taxa, ds_historico_taxa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_taxa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_taxa.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_taxa, ds_historico_taxa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void TFCadCFGFaturaCartao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCadCFGFaturaCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
