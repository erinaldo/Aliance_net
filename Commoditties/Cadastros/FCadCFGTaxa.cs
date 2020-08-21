using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Graos;
using CamadaNegocio.Graos;

namespace Commoditties.Cadastros
{
    public partial class TFCadCFGTaxa : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCFGTaxa()
        {
            InitializeComponent();
            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("P - % SOBRE SALDO PRODUTO", "P"));
            cbx.Add(new Utils.TDataCombo("V - VALOR MONETARIO", "V"));
            tp_taxa.DataSource = cbx;
            tp_taxa.DisplayMember = "Display";
            tp_taxa.ValueMember = "Value";

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO NORMAL", "NO"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE COMPLEMENTO", "CP"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE DEVOLUÇÃO", "DV"));
            cbx1.Add(new Utils.TDataCombo("LANÇAMENTO DE ENTREGA FUTURA", "FT"));
            cbx1.Add(new Utils.TDataCombo("TRANSFERENCIA ENTRE CONTRATOS", "TF"));
            cbx1.Add(new Utils.TDataCombo("COMPLEMENTO FISCAL", "CF"));
            cbx1.Add(new Utils.TDataCombo("DEVOLUÇÃO FISCAL", "DF"));

            tp_fiscal.DataSource = cbx1;
            tp_fiscal.DisplayMember = "Display";
            tp_fiscal.ValueMember = "Value";
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CFGTaxa.Gravar(bsCfgTaxa.Current as TRegistro_CFGTaxa, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CFGTaxa lista = TCN_CFGTaxa.Buscar(tp_taxa.SelectedValue != null ? tp_taxa.SelectedValue.ToString() : string.Empty,
                                                     CFG_Pedido.Text,
                                                     cd_produto.Text,
                                                     cd_moeda.Text,
                                                     null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgTaxa.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgTaxa.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo ==  Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCfgTaxa.AddNew();
            base.afterNovo();
            tp_taxa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            tp_taxa.Enabled = false;
            CFG_Pedido.Focus();
            if ((bsCfgTaxa.Current as TRegistro_CFGTaxa).Tp_taxa.Trim().ToUpper().Equals("P"))
            {
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgTaxa.RemoveCurrent();
        }

        private void BB_CFG_Pedido_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoPedido|Configuração Pedido|350;" +
                              "CFG_Pedido|Cód. Configuração Pedido|100";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CFG_Pedido, DS_TipoPedido },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "tp_movimento|=|'S'");
        }

        private void CFG_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "cfg_pedido|=|'" + CFG_Pedido.Text.Trim() + "';" +
                           "tp_movimento|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[]{CFG_Pedido, DS_TipoPedido},
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_produto, ds_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
        
        private void tp_taxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.vTP_Modo.Equals(Utils.TTpModo.tm_Insert) && (tp_taxa.SelectedValue != null))
            {
                //Verificar se ja existe configuracao
                object obj = new CamadaDados.Graos.TCD_CFGTaxa().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.tp_taxa",
                            vOperador = "=",
                            vVL_Busca = "'" + tp_taxa.SelectedValue.ToString() + "'"
                        }
                    }, "1");
                if (obj != null)
                    this.afterAltera();
                else if (tp_taxa.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                {
                    cd_produto.Enabled = false;
                    bb_produto.Enabled = false;
                    cd_produto.Clear();
                    ds_produto.Clear();
                }

            }
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_moeda_singular|Moeda|200;" +
                              "a.cd_moeda|Cd. Moeda|80;" +
                              "a.sigla|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), string.Empty);
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moeda, ds_moeda, sigla_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void TFCadCFGTaxa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCfgTaxa);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadCFGTaxa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCfgTaxa);
        }
    }
}
