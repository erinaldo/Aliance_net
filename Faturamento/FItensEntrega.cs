using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.Entrega;
using CamadaDados.Faturamento.PDV;
using Utils;
using FormBusca;

namespace Faturamento
{
    public partial class TFItensEntrega : Form
    {
        public TRegistro_RomaneioEntrega rEntrega
        {
            get
            {
                if (bsEntrega.Current != null)
                    return bsEntrega.Current as TRegistro_RomaneioEntrega;
                else
                    return null;
            }
        }

        public TRegistro_PreVenda rPrevenda
        { get; set; }
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedido
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }

        public TFItensEntrega()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsEntrega.Current != null)
            {
                (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.FindAll(p => !p.St_processar).ForEach(p =>
                    (bsEntrega.Current as TRegistro_RomaneioEntrega).lItensDel.Add(p));
                (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.RemoveAll(p => !p.St_processar);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Não existe Entrega.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarEndEntrega()
        {
            //Busca Endereço 
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rPrevenda != null ? rPrevenda.Cd_clifor : rPedido != null ? rPedido.CD_Clifor : string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          0,
                                                                          null);
            if (List_Endereco.Count > 0)
            {
                if (List_Endereco.Count == 1)
                {
                    ds_endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                    Numero.Text = List_Endereco[0].Numero.Trim();
                    Bairro.Text = List_Endereco[0].Bairro.Trim();
                    Referencia.Text = List_Endereco[0].Proximo.Trim();
                    cidade.Text = List_Endereco[0].DS_Cidade.Trim();
                    uf.Text = List_Endereco[0].UF.Trim();
                    Fone.Text = List_Endereco[0].Fone.Trim();
                }
                else if (List_Endereco.Exists(p => p.St_enderecoentregabool))
                {
                    ds_endereco.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Ds_endereco.Trim();
                    Numero.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Numero.Trim();
                    Bairro.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Bairro.Trim();
                    Referencia.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Proximo.Trim();
                    cidade.Text = List_Endereco.Find(p => p.St_enderecoentregabool).DS_Cidade.Trim();
                    uf.Text = List_Endereco.Find(p => p.St_enderecoentregabool).UF.Trim();
                    Fone.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Fone.Trim();
                }
            }
        }

        private void afterEntrega()
        {

            //Verificar se existe Itens Entrega na Pre-Venda
            CamadaDados.Faturamento.Entrega.TList_ItensRomaneio rItensRomaneio = null;
            if (rPrevenda != null)
                rItensRomaneio = new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_itensprevenda x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_prevenda = a.id_prevenda " +
                                                        "and x.id_itemprevenda = a.id_itemprevenda " +
                                                        "and a.cd_empresa = '" + rPrevenda.Cd_empresa.Trim() + "' " +
                                                        "and a.id_prevenda = " + rPrevenda.Id_prevendastr.Trim() + ")"
                                        }
                                    }, 0, string.Empty);
            else if (rPedido != null)
                rItensRomaneio = new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                                        "where x.nr_pedido = a.nr_pedido " +
                                                        "and x.cd_produto = a.cd_produto " +
                                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                                        "and a.nr_pedido = " + rPedido.Nr_pedido.ToString() + ")"
                                        }
                                    }, 0, string.Empty);
            if (rItensRomaneio.Count.Equals(0))
            {
                bsEntrega.AddNew();
                (bsEntrega.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Cd_empresa = rPrevenda != null ? rPrevenda.Cd_empresa : rPedido.CD_Empresa;
                (bsEntrega.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Nm_cliente = rPrevenda != null ? rPrevenda.Nm_clifor : rPedido.NM_Clifor;
                //Buscar Endereço Entrega
                this.BuscarEndEntrega();
                if (rPrevenda != null)
                    //Buscar Itens PreVenda
                    rPrevenda.lItens.ForEach(p =>
                        (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.Add(
                            new TRegistro_ItensRomaneio()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Sigla_unidade = p.Sigla_unidade,
                                Id_prevenda = p.Id_prevenda,
                                Id_itemprevenda = p.Id_itemprevenda,
                                Cd_local = lCfg[0].Cd_local,
                                Qtd_venda = p.Quantidade
                            }));
                else if (rPedido != null)
                    rPedido.Pedido_Itens.ForEach(p =>
                        (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.Add(
                        new TRegistro_ItensRomaneio()
                        {
                            Cd_empresa = p.Cd_Empresa,
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Sigla_unidade = p.Sg_unidade_est,
                            Nr_pedido = p.Nr_pedido,
                            Id_pedidoitem = p.Id_pedidoitem,
                            Cd_local = p.Cd_local,
                            Qtd_venda = p.Quantidade
                        }));
            }
            else
            {
                //Buscar Entrega
                bsEntrega.DataSource = CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Buscar(rItensRomaneio[0].Cd_empresa,
                                                                                                    rItensRomaneio[0].Id_romaneiostr,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                //Adicionar itens entregues
                rItensRomaneio.ForEach(p =>
                    {
                        p.St_processar = true;
                        (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.Add(p);
                    });
                //Adicionar itens nao entregues
                if (rPrevenda != null)
                    new CamadaDados.Faturamento.PDV.TCD_ItensPreVenda().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                            "where x.id_itemprevenda = a.id_itemprevenda " +
                                            "and x.cd_empresa = a.cd_empresa " +
                                            "and x.id_prevenda = a.id_prevenda)"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rItensRomaneio[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_prevenda",
                                vOperador = "=",
                                vVL_Busca = "'" + rItensRomaneio[0].Id_prevenda.ToString() + "'"
                            }
                        }, 0, string.Empty).ForEach(p => (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.Add(
                            new TRegistro_ItensRomaneio()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Id_prevenda = p.Id_prevenda,
                                Id_itemprevenda = p.Id_itemprevenda,
                                Cd_local = lCfg[0].Cd_local,
                                Qtd_venda = p.Quantidade
                            }));
                else if (rPedido != null)
                    new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = rPedido.Nr_pedido.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from tb_fat_itensromaneio x " +
                                            "where x.nr_pedido = a.nr_pedido " +
                                            "and x.cd_produto = a.cd_produto " +
                                            "and x.id_pedidoitem = a.id_pedidoitem)"
                            }
                        }, 0, string.Empty, string.Empty, string.Empty).ForEach(p =>
                            (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.Add(
                            new TRegistro_ItensRomaneio()
                            {
                                Cd_empresa = p.Cd_Empresa,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Sigla_unidade = p.Sg_unidade_est,
                                Nr_pedido = p.Nr_pedido,
                                Id_pedidoitem = p.Id_pedidoitem,
                                Cd_local = p.Cd_local,
                                Qtd_venda = p.Quantidade
                            }));
                bsEntrega.ResetCurrentItem();
            }
        }

        private void TFItensEntrega_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            Utils.ShapeGrid.RestoreShape(this, gItensEntrega);
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rPrevenda != null ? rPrevenda.Cd_empresa : rPedido.CD_Empresa, null);
            //Itens Entrega
            this.afterEntrega();
            //Data romaneio
            Dt_romaneio.Text = CamadaDados.UtilData.Data_Servidor().ToString();        
        }

        private void TFItensEntrega_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensEntrega);
        }

        private void TFItensEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                                 "a.cd_endereco|Codigo|80";
          DataRowView linha =  UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ds_endereco },
              new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + (rPrevenda != null ? rPrevenda.Cd_clifor.Trim() : rPedido.CD_Clifor.Trim()) + "'");
          if (linha != null)
          {
              Numero.Text = linha["numero"].ToString();
              Bairro.Text = linha["bairro"].ToString();
              Referencia.Text = linha["proximo"].ToString();
              cidade.Text = linha["ds_cidade"].ToString();
              uf.Text =linha["uf"].ToString();
              Fone.Text = linha["fone"].ToString();
          }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensEntrega.Count > 0)
            {
                (bsEntrega.Current as TRegistro_RomaneioEntrega).lItens.ForEach(p => 
                    {
                        if (cbTodos.Checked)
                        {
                            p.St_processar = true;
                            p.Quantidade = p.Qtd_venda;
                        }
                        else if (p.Qtd_programada.Equals(decimal.Zero) &&
                            p.Qtd_entregue.Equals(decimal.Zero))
                        {
                            p.St_processar = false;
                            p.Quantidade = decimal.Zero;
                        }
                    });
                bsItensEntrega.ResetBindings(true);
            }
        }

        private void gItensEntrega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if ((bsItensEntrega.Current as TRegistro_ItensRomaneio).St_processar != true)
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Entrega";
                            fQtde.Casas_decimais = 2;
                            fQtde.Vl_default = (bsItensEntrega.Current as TRegistro_ItensRomaneio).Qtd_venda;
                            fQtde.Vl_saldo = (bsItensEntrega.Current as TRegistro_ItensRomaneio).Qtd_venda;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if ((bsItensEntrega.Current as TRegistro_ItensRomaneio).Qtd_venda >= fQtde.Quantidade)
                                {
                                    (bsItensEntrega.Current as TRegistro_ItensRomaneio).St_processar = true;
                                    (bsItensEntrega.Current as TRegistro_ItensRomaneio).Quantidade = fQtde.Quantidade;
                                }
                                else
                                {
                                    MessageBox.Show("Quantidade informada é maior que a QTD do Item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            bsItensEntrega.ResetCurrentItem();

                        }
                    }
                    else if((bsItensEntrega.Current as TRegistro_ItensRomaneio).Qtd_programada.Equals(decimal.Zero) &&
                        (bsItensEntrega.Current as TRegistro_ItensRomaneio).Qtd_entregue.Equals(decimal.Zero))
                    {
                        (bsItensEntrega.Current as TRegistro_ItensRomaneio).St_processar = false;
                        (bsItensEntrega.Current as TRegistro_ItensRomaneio).Quantidade = decimal.Zero;
                        bsItensEntrega.ResetCurrentItem();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }
    }
}
