using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Graos;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Estoque.Cadastros;

namespace Commoditties
{
    public partial class TFFixacao : Form
    {
        public decimal Qtd_fixar
        { get; set; }
        public string Tp_movimento
        { get; set; }

        public TFFixacao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsFixacao.Current != null)
            {
                if (pCentral.validarCampoObrigatorio())
                {
                    //Montar lista de notas fiscais a serem complementadas/devolvidas
                    decimal saldo_fixar = ps_fixado_total.Value;
                    if (!(bsItensNota.DataSource as TList_RegLanFaturamento_Item).Exists(p => p.St_processar))
                    {
                        for (int i = 0; i < bsItensNota.Count; i++)
                        {
                            if (saldo_fixar > 0)
                            {
                                (bsFixacao.Current as TRegistro_LanFixacao).lFixacaonf.Add(
                                    new TRegistro_Fixacao_NF()
                                    {
                                        Cd_empresa = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Cd_empresa,
                                        Nr_notafiscal = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Nr_notafiscal,
                                        Nr_serie = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Nr_serie,
                                        Nr_lanctofiscal = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Nr_lanctofiscal,
                                        Id_nfitem = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Id_nfitem,
                                        Id_variedade = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Id_variedade,
                                        Qtd_fixacao = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                        (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar : saldo_fixar,
                                        Vl_pauta = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario,
                                        Vl_fixacao = (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                        TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                        TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null),
                                        Vl_complemento = vl_unitario.Value > (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario ? 
                                                            ((bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                                TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                                TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null)) -
                                                         ((bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                         TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar * (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario, 2, null) :
                                                         TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario, 2, null)) : decimal.Zero,
                                        Vl_devolucao = vl_unitario.Value < (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario ?
                                                         ((bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                         TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar * (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario, 2, null) :
                                                         TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (bsItensNota[i] as TRegistro_LanFaturamento_Item).Vl_unitario, 2, null)) -
                                                         ((bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ?
                                                            TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                         TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null)) : decimal.Zero
                                    });
                                saldo_fixar -= (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar < saldo_fixar ? (bsItensNota[i] as TRegistro_LanFaturamento_Item).Saldo_fixar : saldo_fixar;
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        if (saldo_fixar > 0)
                        {
                            (bsItensNota.DataSource as TList_RegLanFaturamento_Item).FindAll(p => p.St_processar).ForEach(p =>
                                {
                                    (bsFixacao.Current as TRegistro_LanFixacao).lFixacaonf.Add(
                                        new TRegistro_Fixacao_NF()
                                        {
                                            Cd_empresa = p.Cd_empresa,
                                            Nr_notafiscal = p.Nr_notafiscal,
                                            Nr_serie = p.Nr_serie,
                                            Nr_lanctofiscal = p.Nr_lanctofiscal,
                                            Id_nfitem = p.Id_nfitem,
                                            Id_variedade = p.Id_variedade,
                                            Qtd_fixacao = p.Saldo_fixar < saldo_fixar ?
                                                            p.Saldo_fixar : saldo_fixar,
                                            Vl_pauta = p.Vl_unitario,
                                            Vl_fixacao = p.Saldo_fixar < saldo_fixar ?
                                                            TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, p.Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                            TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null),
                                            Vl_complemento = vl_unitario.Value > p.Vl_unitario ? (p.Saldo_fixar < saldo_fixar ?
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, p.Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null)) -
                                                             (p.Saldo_fixar < saldo_fixar ?
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, p.Saldo_fixar * p.Vl_unitario, 2, null) :
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * p.Vl_unitario, 2, null)) : decimal.Zero,
                                            Vl_devolucao = vl_unitario.Value < p.Vl_unitario ?
                                                             (p.Saldo_fixar < saldo_fixar ?
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, p.Saldo_fixar * p.Vl_unitario, 2, null) :
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * p.Vl_unitario, 2, null)) -
                                                             (p.Saldo_fixar < saldo_fixar ?
                                                                TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, p.Saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null) :
                                                             TCN_CadConvUnidade.ConvertUnid(cd_unidestoque.Text, cd_unidvalorEditDefault.Text, saldo_fixar * (vl_unitario.Value + vl_bonificacao.Value), 2, null)) : decimal.Zero
                                        });
                                    saldo_fixar -= p.Saldo_fixar < saldo_fixar ? p.Saldo_fixar : saldo_fixar;
                                });
                        }
                    }
                    if (saldo_fixar > 0)
                    {
                        (bsFixacao.Current as TRegistro_LanFixacao).Ps_fixado_total = (bsFixacao.Current as TRegistro_LanFixacao).Ps_fixado_total - saldo_fixar;
                        (bsFixacao.Current as TRegistro_LanFixacao).Vl_fixacao = (bsFixacao.Current as TRegistro_LanFixacao).Ps_fixado_total *
                                                                                      ((bsFixacao.Current as TRegistro_LanFixacao).Vl_unitario + (bsFixacao.Current as TRegistro_LanFixacao).Vl_bonificacao);
                    }
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void TFFixacao_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, gItensNota);
            if (!string.IsNullOrEmpty(Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar notas fiscais de pauta com saldo para fixar
            if(bsFixacao.Current != null)
                bsItensNota.DataSource = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.BuscarNfFixacao((bsFixacao.Current as TRegistro_LanFixacao).Nr_contratostr,
                                                                                                                      Tp_movimento,
                                                                                                                      true,
                                                                                                                      true,
                                                                                                                      false,
                                                                                                                      decimal.Zero);
            tot_quantidade.Value = (bsItensNota.List as TList_RegLanFaturamento_Item).Sum(p => p.Quantidade);
            tot_fixada.Value = (bsItensNota.List as TList_RegLanFaturamento_Item).Sum(p => p.Qtd_fixacao);
            tot_saldo_fixar.Value = (bsItensNota.List as TList_RegLanFaturamento_Item).Sum(p=> p.Saldo_fixar);
            tot_subtotal.Value = (bsItensNota.List as TList_RegLanFaturamento_Item).Sum(p=> p.Vl_subtotal);
            tot_fixado.Value = (bsItensNota.List as TList_RegLanFaturamento_Item).Sum(p=> p.Vl_fixacao);
            ps_fixado_total.Value = (Qtd_fixar > tot_saldo_fixar.Value ? tot_saldo_fixar.Value : Qtd_fixar);
            //Buscar Impostos Reter Configurados no Contrato
            bsImpReter.DataSource = Proc_Commoditties.TProcessaFixacao.CalcularImpostoReter((bsFixacao.Current as TRegistro_LanFixacao).Nr_contrato.Value.ToString(), vl_totalliquido.Value);
            vl_retencao.Value = (bsImpReter.DataSource as List<TRegistro_ImpostosReter>).Sum(p => p.Vl_rentecao);
        }

        private void ps_fixado_total_Leave(object sender, EventArgs e)
        {
            if (!(bsItensNota.DataSource as TList_RegLanFaturamento_Item).Exists(p => p.St_processar))
            {
                if (ps_fixado_total.Value > tot_saldo_fixar.Value)
                    ps_fixado_total.Value = tot_saldo_fixar.Value;
            }
            else
            {
                if (ps_fixado_total.Value > (bsItensNota.DataSource as TList_RegLanFaturamento_Item).FindAll(p => p.St_processar).Sum(p => p.Saldo_fixar))
                    ps_fixado_total.Value = (bsItensNota.DataSource as TList_RegLanFaturamento_Item).FindAll(p => p.St_processar).Sum(p => p.Saldo_fixar);
            }

                if (bsFixacao.Current != null)
                {
                    (bsFixacao.Current as TRegistro_LanFixacao).Vl_fixacao = TCN_CadConvUnidade.ConvertUnid(
                                                                                    cd_unidestoque.Text,
                                                                                    cd_unidvalorEditDefault.Text,
                                                                                    ps_fixado_total.Value * (vl_unitario.Value + vl_bonificacao.Value),
                                                                                    2, null);

                    bsFixacao.ResetCurrentItem();
                }
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            if (bsFixacao.Current != null)
            {
                (bsFixacao.Current as TRegistro_LanFixacao).Vl_fixacao = TCN_CadConvUnidade.ConvertUnid(
                                                                                cd_unidestoque.Text,
                                                                                cd_unidvalorEditDefault.Text,
                                                                                ps_fixado_total.Value * (vl_unitario.Value + vl_bonificacao.Value),
                                                                                2, null);

                bsFixacao.ResetCurrentItem();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFFixacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void vl_totalliquido_ValueChanged(object sender, EventArgs e)
        {
            bsImpReter.DataSource = Proc_Commoditties.TProcessaFixacao.CalcularImpostoReter((bsFixacao.Current as TRegistro_LanFixacao).Nr_contrato.Value.ToString(), vl_totalliquido.Value);
            vl_retencao.Value = (bsImpReter.DataSource as List<TRegistro_ImpostosReter>).Sum(p => p.Vl_rentecao);
        }

        private void TFFixacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, gItensNota);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gItensNota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar =
                    !(bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar;
                bsItensNota.ResetCurrentItem();

                ps_fixado_total.Value = (bsItensNota.DataSource as TList_RegLanFaturamento_Item).FindAll(p=> p.St_processar).Sum(p=> p.Saldo_fixar);
                if (ps_fixado_total.Value == decimal.Zero)
                    ps_fixado_total.Value = tot_saldo_fixar.Value;
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                (bsItensNota.DataSource as TList_RegLanFaturamento_Item).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItensNota.ResetBindings(true);
                ps_fixado_total.Value = (bsItensNota.DataSource as TList_RegLanFaturamento_Item).FindAll(p => p.St_processar).Sum(p => p.Saldo_fixar);
                if (ps_fixado_total.Value == decimal.Zero)
                    ps_fixado_total.Value = tot_saldo_fixar.Value;
            }
        }

        private void dt_fixacao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_fixacao.Text.SoNumero()))
            {
                //Buscar Cotação do Produto no Dia
                TList_PrecoCommodities lCotacao = new TCD_PrecoCommodities().SelectProdCotacao((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                                                               DateTime.Parse(dt_fixacao.Text));
                if (lCotacao.Count > 0)
                    vl_unitario.Value = Tp_movimento.Trim().ToUpper().Equals("E") ? lCotacao[0].Vl_precocompra : lCotacao[0].Vl_precovenda;
            }
        }
    }
}
