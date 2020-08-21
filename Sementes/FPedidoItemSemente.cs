using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using CamadaDados.Graos;

namespace Sementes
{
    public partial class TFPedidoItemSemente : Form
    {
        public decimal Qtd_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Cd_amostra
        { get; set; }

        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lNfItem
        {
            get
            {
                if (bsNfLote.Count > 0)
                {
                    CamadaDados.Sementes.TList_LoteSemente_X_NFItem aux = new CamadaDados.Sementes.TList_LoteSemente_X_NFItem();
                    for (int i = 0; i < bsNfLote.Count; i++)
                        aux.Add((bsNfLote[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem));
                    return aux;
                }
                else
                    return null;
            }
        }

        public TFPedidoItemSemente()
        {
            InitializeComponent();
            this.Qtd_lote = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Cd_amostra = string.Empty;
        }

        private void afterGrava()
        {
            if (qtd_saldo.Value > 0)
            {
                MessageBox.Show("Ainda existe saldo para baixar lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[6];
            //Empresa
            filtro[0].vNM_Campo = "nf.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            //Pedidos de entrada
            filtro[1].vNM_Campo = "nf.tp_movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'E'";
            //Tem que ser commoditties
            //e nao pode ser nota de deposito
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "exists";
            filtro[2].vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                  "inner join tb_fat_cfgpedido y " +
                                  "on x.cfg_pedido = y.cfg_pedido " +
                                  "where x.nr_pedido = a.nr_pedido " +
                                  "and isnull(y.st_commoditties, 'N') = 'S' " +
                                  "and isnull(y.st_deposito, 'N') <> 'S')";
            //Contenha o produto materia prima
            filtro[3].vNM_Campo = "a.cd_produto";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'" + Cd_amostra.Trim() + "'";
            //Somente itens de nota com saldo para amarrar ao lote
            filtro[4].vNM_Campo = "(a.quantidade - isnull((select sum(isnull(x.quantidade, 0)) " +
                                  "                            from tb_sem_lotesemente_x_nfitem x " +
                                  "                            inner join tb_sem_lotesemente y " +
                                  "                            on x.id_lote = y.id_lote " +
                                  "                            where x.cd_empresa = a.cd_empresa " +
                                  "                            and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                  "                            and x.id_nfitem = a.id_nfitem " +
                                  "                            and isnull(y.st_registro, 'A') <> 'C'), 0)) ";
            filtro[4].vOperador = ">";
            filtro[4].vVL_Busca = "0";
            //Nota Fiscal nao pode estar cancelada
            filtro[5].vNM_Campo = "isnull(nf.st_registro, 'A')";
            filtro[5].vOperador = "<>";
            filtro[5].vVL_Busca = "'C'";
            if (cd_fornecedor.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "nf.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_fornecedor.Text.Trim() + "'";
            }
            if (nr_pedido.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedido.Text;
            }
            if (nr_contrato.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from vtb_gro_contrato x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_produto = a.cd_produto " +
                                                      "and x.id_pedidoitem = a.id_pedidoitem " +
                                                      "and x.nr_contrato = " + nr_contrato.Text + ")";
            }
            bsItensNf.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(filtro, 0, string.Empty, string.Empty, "a.id_nfitem");
        }

        private int ItenExiste()
        {
            if (bsNfLote.Count > 0)
            {
                for (int i = 0; i < bsNfLote.Count; i++)
                    if ((bsNfLote[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Cd_empresa.Trim().Equals((bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa.Trim()) &&
                        (bsNfLote[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Nr_lanctofiscal.Equals((bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_lanctofiscal) &&
                        (bsNfLote[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Id_nfitem.Equals((bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem))
                        return i;
                return -1;
            }
            else
                return -1;
        }

        private decimal TotalizarItens()
        {
            if (bsNfLote.Count > 0)
            {
                decimal total = decimal.Zero;
                for (int i = 0; i < bsNfLote.Count; i++)
                    total += (bsNfLote[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Quantidade;
                return total;
            }
            else
                return decimal.Zero;
        }

        private void Adicionar(bool st_autocompletar)
        {
            if (bsItensNf.Current != null)
            {
                if ((quantidade.Value > 0) || st_autocompletar)
                {
                    if (bsNfLote.Count > 0)
                    {
                        //Verificar se o item ja existe na lista
                        int index = this.ItenExiste();
                        if (index >= 0)
                        {
                            //Alterar a quantidade do registro existente
                            (bsNfLote[index] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Quantidade = quantidade.Value;
                            bsNfLote.ResetItem(index);
                        }
                        else
                        {
                            bsNfLote.Add(
                            new CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem()
                            {
                                Cd_empresa = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa,
                                Cd_produto = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_produto,
                                Ds_produto = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Ds_produto,
                                Id_nfitem = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem,
                                Nr_lanctofiscal = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_lanctofiscal,
                                Nr_notafiscal = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_notafiscal,
                                Nr_serie = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_serie,
                                Quantidade = quantidade.Value,
                                Sigla_unidade = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Sigla_unidade_estoque,
                                Tp_movimento = "O"//Origem
                            });
                        }
                    }
                    else
                        bsNfLote.Add(new CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem()
                        {
                            Cd_empresa = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_empresa,
                            Cd_produto = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Cd_produto,
                            Ds_produto = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Ds_produto,
                            Id_nfitem = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Id_nfitem,
                            Nr_lanctofiscal = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_lanctofiscal,
                            Nr_notafiscal = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_notafiscal,
                            Nr_serie = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Nr_serie,
                            Quantidade = quantidade.Value,
                            Sigla_unidade = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Sigla_unidade_estoque,
                            Tp_movimento = "O"//Origem
                        });
                    qtd_totallote.Value = this.TotalizarItens();
                    bsItensNf.MoveNext();
                }
                else
                    MessageBox.Show("Necessario informar quantidade para adicionar a lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Necessario selecionar nota fiscal para adicionar a lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Excluir()
        {
            if (bsNfLote.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    bsNfLote.RemoveCurrent();
                    qtd_totallote.Value = this.TotalizarItens();
                }
            }
            else
                MessageBox.Show("Necessario selecionar item na lista para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AutoCompletar()
        {
            bsNfLote.Clear();
            qtd_totallote.Value = 0;
            bsItensNf.MoveFirst();
            int i = 0;
            do
            {
                if (qtd_saldo.Value <= 0)
                    break;
                this.Adicionar(true);
            } while (i++ < (bsItensNf.Count - 1));
        }
        
        private void TFPedidoItemSemente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gNfLote);
            Utils.ShapeGrid.RestoreShape(this, gItensNf);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pSoma.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltro.set_FormatZero();
            qtd_lote.Value = this.Qtd_lote;
        }

        private void qtd_lote_ValueChanged(object sender, EventArgs e)
        {
            qtd_saldo.Value = qtd_lote.Value - qtd_totallote.Value;
        }

        private void qtd_totallote_ValueChanged(object sender, EventArgs e)
        {
            qtd_saldo.Value = qtd_lote.Value - qtd_totallote.Value;
        }

        private void quantidade_ValueChanged(object sender, EventArgs e)
        {
            if(quantidade.Value > 0)
            {
                if (bsItensNf.Current != null)
                {
                    if ((bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_saldosemente < quantidade.Value)
                        quantidade.Value = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_saldosemente;
                    if (quantidade.Value > qtd_saldo.Value)
                        quantidade.Value = qtd_saldo.Value;
                }
                else
                    quantidade.Value = quantidade.Minimum;
            }
        }

        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            this.Adicionar(false);
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            this.Excluir();
        }

        private void bb_autocompletar_Click(object sender, EventArgs e)
        {
            this.AutoCompletar();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFPedidoItemSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F10))
                this.Adicionar(false);
            else if (e.KeyCode.Equals(Keys.F11))
                this.Excluir();
            else if (e.KeyCode.Equals(Keys.F12))
                this.AutoCompletar();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { cd_fornecedor }, new TCD_CadClifor());
        }

        private void bb_contrato_Click(object sender, EventArgs e)
        {
            string vBusca = "a.nr_contrato|Número do Contrato|80;" +
                            "a.cd_clifor|Cód. Clifor|80;" +
                            "d.nm_clifor|Nome do Contrato|150;" +
                            "a.cd_empresa|Cód. Empresa|80;" +
                            "f.nm_empresa|Nome Empresa|150;" +
                            "a.dt_abertura|Data Abertura|80";
            string vParam = "a.cd_empresa|=|'" + this.Cd_empresa.Trim() + "'";

            UtilPesquisa.BTN_BUSCA(vBusca,
                                   new Componentes.EditDefault[] { nr_contrato },
                                   new TCD_CadContrato(), vParam);
        }

        private void nr_contrato_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                            "a.cd_empresa|=|'" + this.Cd_empresa.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato },
                new TCD_CadContrato());
        }

        private void bb_pedido_Click(object sender, EventArgs e)
        {
            string vParam = "||(isnull(a.st_pedido, 'A') in ('F', 'P'));" +
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
                              "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                              "where x.cfg_pedido = a.cfg_pedido " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas,
               new Componentes.EditDefault[] { nr_pedido }, new CamadaDados.Faturamento.Pedido.TCD_Pedido());
        }

        private void bsItensNf_PositionChanged(object sender, EventArgs e)
        {
            quantidade.Value = (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).Qtd_saldosemente;
        }

        private void TFPedidoItemSemente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gNfLote);
            Utils.ShapeGrid.SaveShape(this, gItensNf);
        }
    }
}
