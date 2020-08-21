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
    public partial class TFCadCFGDescCheque : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGDescCheque()
        {
            InitializeComponent();
            this.DTS = bsCfgCheque;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.GravarCFGCheque(bsCfgCheque.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGCheque, null);
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            CamadaDados.Financeiro.Cadastros.TList_CFGCheque lista = 
                CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.Buscar(cd_empresa.Text,
                                                                        cd_historico_desconto.Text,
                                                                        cd_historico_taxa.Text,
                                                                        cd_historico_creddesconto.Text,
                                                                        cd_histdev_chemitidos.Text,
                                                                        cd_histreap_chemitidos.Text,
                                                                        cd_contadevolucao.Text,
                                                                        cd_histdev_chrecebidos.Text,
                                                                        cd_histreap_chrecebidos.Text,
                                                                        cd_contadev_chrecebidos.Text,
                                                                        0,
                                                                        string.Empty,
                                                                        null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgCheque.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsCfgCheque.Clear();
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
                bsCfgCheque.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            cd_historico_creddesconto.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgCheque.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CFGCheque.DeletarCFGCheque((bsCfgCheque.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGCheque), null);
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

        private void bb_historico_creddesconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_creddesconto, ds_historico_creddesconto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_creddesconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_creddesconto.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_creddesconto, ds_historico_creddesconto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_desconto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_desconto, ds_historico_desconto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_desconto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_desconto.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_desconto, ds_historico_desconto },
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

        private void bb_historico_devolucao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_histdev_chemitidos, ds_histdev_chemitidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_devolucao_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_histdev_chemitidos.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_histdev_chemitidos, ds_histdev_chemitidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = "isnull(a.st_contacompensacao, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contadevolucao, ds_contadevolucao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contadevolucao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contadevolucao.Text.Trim() + "';" +
                            "isnull(a.st_contacompensacao, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contadevolucao, ds_contadevolucao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_histreap_chemitidos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_histreap_chemitidos, ds_histreap_chemitidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_histreap_chemitidos_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_histreap_chemitidos.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_histreap_chemitidos, ds_histreap_chemitidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_histdev_chrecebidos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_histdev_chrecebidos, ds_histdev_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_histdev_chrecebidos_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_histdev_chrecebidos.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_histdev_chrecebidos, ds_histdev_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_histreap_chrecebidos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80";
            string vParamFixo = "a.TP_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_histreap_chrecebidos, ds_histreap_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_histreap_chrecebidos_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_histreap_chrecebidos.Text.Trim() + "';" +
                              "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_histreap_chrecebidos, ds_histreap_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_contadev_chrecebidos_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contadev_chrecebidos, ds_contadev_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), string.Empty);
        }

        private void cd_contadev_chrecebidos_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contadev_chrecebidos.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contadev_chrecebidos, ds_contadev_chrecebidos },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void TFCadCFGDescCheque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCFGDescCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
