using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Servicos.Cadastros
{
    public partial class TFCadCfgContrato : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgContrato()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCfgContrato.AddNew();
            base.afterNovo();
            cd_empresa.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo.Equals(Utils.TTpModo.tm_Edit))
                bb_empresa.Enabled = false;
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return CamadaNegocio.Servicos.Cadastros.TCN_CfgContrato.Gravar(bsCfgContrato.Current as CamadaDados.Servicos.Cadastros.TRegistro_CfgContrato, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro gravar config. " + ex.Message.Trim());
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Servicos.Cadastros.TCN_CfgContrato.Excluir(bsCfgContrato.Current as CamadaDados.Servicos.Cadastros.TRegistro_CfgContrato, null);
                    bsCfgContrato.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override int buscarRegistros()
        {
            CamadaDados.Servicos.Cadastros.TList_CfgContrato lista =
                CamadaNegocio.Servicos.Cadastros.TCN_CfgContrato.Buscar(cd_empresa.Text,
                                                                        cd_condpgto.Text,
                                                                        tp_docto.Text,
                                                                        tp_duplicata.Text,
                                                                        cd_historico.Text,
                                                                        null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgContrato.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgContrato.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            string vParam = "a.qt_parcelas|<|2";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(),
                                            vParam);
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "';" +
                            "a.qt_parcelas|<|2";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|TP. Docto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(),
                                            string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            string vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operações|200;" +
                              "a.cd_historico|Cd. Historico|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(),
                                            "a.tp_mov|=|'R'");
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco }, 
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
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
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult, ds_centroresult },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }
    }
}
