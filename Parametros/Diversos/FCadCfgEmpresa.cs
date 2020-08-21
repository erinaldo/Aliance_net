using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Parametros.Diversos
{
    public partial class TFCadCfgEmpresa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgEmpresa()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CfgEmpresa.Gravar(bsCadCfgEmpresa.Current as TRegistro_CfgEmpresa, null);
            else return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CfgEmpresa lista = TCN_CfgEmpresa.Buscar(cd_empresa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    Lista = lista;
                    bsCadCfgEmpresa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                    bsCadCfgEmpresa.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                bb_empresa.Enabled = false;
                CFG_PedRemCargaAvulsa.Focus();
            }
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                bsCadCfgEmpresa.AddNew();
            base.afterNovo();
            cd_empresa.Focus();

        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsCadCfgEmpresa.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
                {
                    TCN_CfgEmpresa.Excluir(bsCadCfgEmpresa.Current as TRegistro_CfgEmpresa, null);
                    bsCadCfgEmpresa.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
               new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void CFG_PedRemCargaAvulsa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + CFG_PedRemCargaAvulsa.Text.Trim() + "';a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_PedRemCargaAvulsa, Ds_PedRemCargaAvulsa },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_cfgpedidoRemessa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CFG_PedRemCargaAvulsa, Ds_PedRemCargaAvulsa },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S'");
        }

        private void CFG_PedVenda_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + CFG_PedVenda.Text.Trim() + "';a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_PedVenda, Ds_PedVenda },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_pedVenda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CFG_PedVenda, Ds_PedVenda },
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S'");
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                       , new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                       new CamadaDados.Diversos.TCD_CadTbPreco(),
                                       string.Empty);
        }

        private void Cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CD_Historico|=|'" + Cd_historico.Text.Trim() + "';" +
                            "a.TP_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_historico, Ds_historico },
             new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.Ds_historico|Descrição|300;a.CD_Historico|Código|80"
                                      , new Componentes.EditDefault[] { Cd_historico, Ds_historico },
                                      new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(),
                                      "a.TP_Mov|=|'R'");
        }
    }
}
