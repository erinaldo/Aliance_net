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
    public partial class TFCadCfgFolhaPagamento : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgFolhaPagamento()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Financeiro.Cadastros.TCN_CfgFolhaPagamento.Gravar(bsCfgFolhaPagamento.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CfgFolhaPagamento, null);
            else
                return string.Empty;

        }

        public override int buscarRegistros()
        {
            CamadaDados.Financeiro.Cadastros.TList_CfgFolhaPagamento lista =
                CamadaNegocio.Financeiro.Cadastros.TCN_CfgFolhaPagamento.Buscar(cd_empresa.Text,
                                                                                cd_historico.Text,
                                                                                cd_condpgto.Text,
                                                                                tp_duplicata.Text,
                                                                                tp_docto.Text,
                                                                                cd_contager.Text,
                                                                                cd_portador.Text,
                                                                                null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgFolhaPagamento.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsCfgFolhaPagamento.Clear();
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
                bsCfgFolhaPagamento.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            cd_historico.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgFolhaPagamento.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CfgFolhaPagamento.Excluir((bsCfgFolhaPagamento.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CfgFolhaPagamento), null);
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
            if (!string.IsNullOrEmpty(cd_contager.Text))
                vParamFixo += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                              "         where x.cd_empresa = a.cd_empresa " +
                              "         and x.cd_contager = '" + cd_contager.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_contager.Text))
                vColunas += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_contager = '" + cd_contager.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|200;" +
                              "a.CD_Historico|Cd. Histórico|80;" +
                              "a.tp_mov|Tipo Movimento|80";
            string vParamFixo = "a.TP_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico, tp_movhistorico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text.Trim() + "';" +
                              "a.TP_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico, tp_movhistorico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80;" +
                              "a.tp_mov|Tipo Movimento|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), "a.tp_mov|=|'P'");
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movduplicata },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|'" + tp_docto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Cd. Conta|80";
            string vParam = string.Empty;
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "         where x.cd_contager = a.cd_contager " +
                          "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_empresa.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "         where x.cd_contager = a.cd_contager " +
                          "         and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void TFCadCfgFolhaPagamento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
        }

        private void TFCadCfgFolhaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult.Text = fBusca.Cd_centro;
                        ds_centroresult.Text = fBusca.Ds_centro;
                    }
            }
        }
        private void cd_centroresult_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult.Text.Trim() + ";" +
                            "isnull(a.ST_Sintetico, 'N')|<>|'S';" +
                            "a.TP_Registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult, ds_centroresult },
                new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }
    }
}
