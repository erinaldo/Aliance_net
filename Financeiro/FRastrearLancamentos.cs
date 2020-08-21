using System;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Caixa;
using CamadaDados.Financeiro.Titulo;
using CamadaDados.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Financeiro.Adiantamento;
using CamadaDados.Contabil;
using CamadaDados.Estoque;
using FormRelPadrao;
using System.Linq;
using System.Collections.Generic;
using CamadaNegocio.Faturamento.NotaFiscal;

namespace Financeiro
{
    public enum TP_Rastrear { tm_nf, tm_pedido, tm_estoque, tm_duplicata, tm_parcela, tm_liquidacao, tm_bloqueto, tm_caixa, tm_cheque, tm_contabil, tm_adiantamento, tm_transfcaixa };

    public partial class TFRastrearLancamentos : Form
    {
        public TP_Rastrear TRastrear
        { get; set; }
        public TP_Rastrear PontoCentralOld
        { get; set; }

        public TFRastrearLancamentos()
        {
            InitializeComponent();
        }

        private void AtivarAba()
        {
            switch (TRastrear)
            {
                case TP_Rastrear.tm_bloqueto:
                    {
                        tcCentral.SelectedTab = tpBloquetos;
                        break;
                    }
                case TP_Rastrear.tm_caixa:
                    {
                        tcCentral.SelectedTab = tpCaixa;
                        tcCaixa.SelectedTab = tpDetCaixa;
                        break;
                    }
                case TP_Rastrear.tm_cheque:
                    {
                        tcCentral.SelectedTab = tpCheque;
                        break;
                    }
                case TP_Rastrear.tm_contabil:
                    {
                        tcCentral.SelectedTab = tpContabil;
                        break;
                    }
                case TP_Rastrear.tm_duplicata:
                    {
                        tcCentral.SelectedTab = tpDuplicata;
                        break;
                    }
                case TP_Rastrear.tm_estoque:
                    {
                        tcCentral.SelectedTab = tpFaturamento;
                        tcFaturamento.SelectedTab = tpEstoque;
                        break;
                    }
                case TP_Rastrear.tm_nf:
                    {
                        tcCentral.SelectedTab = tpFaturamento;
                        tcFaturamento.SelectedTab = tpNf;
                        break;
                    }
                case TP_Rastrear.tm_pedido:
                    {
                        tcCentral.SelectedTab = tpFaturamento;
                        tcFaturamento.SelectedTab = tpPedido;
                        break;
                    }
                case TP_Rastrear.tm_adiantamento:
                    {
                        tcCentral.SelectedTab = tpAdiantamentos;
                        break;
                    }
                case TP_Rastrear.tm_transfcaixa:
                    {
                        tcCentral.SelectedTab = tpCaixa;
                        tcCaixa.SelectedTab = tpTransf;
                        break;
                    }
                case TP_Rastrear.tm_parcela:
                    {
                        tcCentral.SelectedTab = tpParcela;
                        break;
                    }
                case TP_Rastrear.tm_liquidacao:
                    {
                        tcCentral.SelectedTab = tpLiquidacao;
                        break;
                    }
            }
        }

        private void BuscarItensNf()
        {
            if (bsNotaFiscal.Current != null)
            {
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Count <= 0)
                {
                    // Buscar itens da nf
                    TpBusca[] filtro = new TpBusca[2];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'";
                    filtro[1].vNM_Campo = "a.nr_lanctofiscal";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString();
                    bsItensNota.DataSource = new TCD_LanFaturamento_Item().Select(filtro, 0, string.Empty, string.Empty, "a.id_nfitem");
                }
            }
        }

        private void BuscarItensPedido()
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Count <= 0)
                {
                    //Buscar itens do pedido
                    TpBusca[] filtro = new TpBusca[1];
                    filtro[0].vNM_Campo = "a.nr_pedido";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                    BS_Itens.DataSource = new TCD_LanPedido_Item().Select(filtro, 0, string.Empty, string.Empty, "b.ds_produto asc");
                }
        }

        private void PontoCentral(bool st_atual)
        {
            switch (tcCentral.SelectedIndex)
            {
                case 0://Faturamento
                    {
                        switch (tcFaturamento.SelectedIndex)
                        {
                            case 0://Nota Fiscal
                                {
                                    if (st_atual)
                                        TRastrear = TP_Rastrear.tm_nf;
                                    else
                                        if (bsNotaFiscal.Current != null)
                                            PontoCentralOld = TP_Rastrear.tm_nf;
                                    break;
                                }
                            case 1://Pedido
                                {
                                    if (st_atual)
                                        TRastrear = TP_Rastrear.tm_pedido;
                                    else
                                        if (BS_Pedido.Current != null)
                                            PontoCentralOld = TP_Rastrear.tm_pedido;
                                    break;
                                }
                            case 2://Estoque
                                {
                                    if (st_atual)
                                        TRastrear = TP_Rastrear.tm_estoque;
                                    else
                                        if (BS_Estoque.Current != null)
                                            PontoCentralOld = TP_Rastrear.tm_estoque;
                                    break;
                                }
                        }
                        break;
                    }
                case 1://Duplicata
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_duplicata;
                        else
                            if (bsDuplicata.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_duplicata;
                        break;
                    }
                case 2://Parcela
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_parcela;
                        else
                            if (bsParcelas.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_parcela;
                        break;
                    }
                case 3://Liquidacao
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_liquidacao;
                        else
                            if (bsLiquidacoes.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_liquidacao;
                        break;
                    }
                case 4://Bloquetos
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_bloqueto;
                        else
                            if (dsBloqueto.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_bloqueto;
                        break;
                    }
                case 5://Caixa
                    {
                        switch (tcCaixa.SelectedIndex)
                        {
                            case 0: //Caixa
                                {
                                    if (st_atual)
                                        TRastrear = TP_Rastrear.tm_caixa;
                                    else
                                        if (bindingSourceCaixa.Current != null)
                                            PontoCentralOld = TP_Rastrear.tm_caixa;
                                    break;
                                }
                            case 1: //Transferencias
                                {
                                    if (st_atual)
                                        TRastrear = TP_Rastrear.tm_transfcaixa;
                                    else
                                        if (bsTransfCaixa.Current != null)
                                            PontoCentralOld = TP_Rastrear.tm_transfcaixa;
                                    break;
                                }
                        }
                        break;
                    }
                case 6://Cheque
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_cheque;
                        else
                            if (BS_Titulo.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_cheque;
                        break;
                    }
                case 7: //Adiantamentos
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_adiantamento;
                        else
                            if (BS_Consulta_Adiantamento.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_adiantamento;
                        break;
                    }
                case 8://Contabil
                    {
                        if (st_atual)
                            TRastrear = TP_Rastrear.tm_contabil;
                        else
                            if (bsContabil.Current != null)
                                PontoCentralOld = TP_Rastrear.tm_contabil;
                        break;
                    }
            }
        }

        private void Rastrear()
        {
            TpBusca[] filtro = new TpBusca[1];
            switch (TRastrear)
            {
                case TP_Rastrear.tm_bloqueto:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and a.cd_parcela = x.cd_parcela " +
                                                              "and z.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and z.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "inner join tb_fin_titulo_x_caixa w " +
                                                              "on z.cd_contager = w.cd_contager " +
                                                              "and z.cd_lanctocaixa = w.cd_lanctocaixa " +
                                                              "inner join tb_fin_titulo ch " +
                                                              "on w.cd_empresa = ch.cd_empresa " +
                                                              "and w.nr_lanctocheque = ch.nr_lanctocheque " +
                                                              "and w.cd_banco = ch.cd_banco " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and a.cd_parcela = x.cd_parcela " +
                                                              "and ch.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and ch.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and ch.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on z.cd_empresa = nf.cd_empresa " +
                                                              "and z.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and a.cd_parcela = x.cd_parcela " +
                                                              "and nf.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and nf.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on z.cd_empresa = nf.cd_empresa " +
                                                              "and z.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and a.cd_parcela = x.cd_parcela " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString() + ")";


                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa w " +
                                                              "on z.cd_contager = w.cd_contager " +
                                                              "and z.cd_lanctocaixa = w.cd_lanctocaixa " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and a.cd_parcela = x.cd_parcela " +
                                                              "and w.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 2);
                                        filtro[filtro.Length - 2].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 2].vOperador = "=";
                                        filtro[filtro.Length - 2].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString();
                                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and x.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and x.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on y.cd_contager = caixa.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and caixa.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and caixa.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            dsBloqueto.DataSource = new TCD_Titulo().Select(filtro, 0, "");
                        break;
                    }
                case TP_Rastrear.tm_caixa:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_parcela y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_cob_titulo z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "and y.cd_parcela = z.cd_parcela " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and z.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and z.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and z.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_titulo y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctocheque = y.nr_lanctocheque " +
                                                              "and x.cd_banco = y.cd_banco " +
                                                              "where a.cd_contager = x.cd_contager " +
                                                              "and a.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                              "and y.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and y.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and y.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_ctb_lanctosCTB x " +
                                                              "where x.id_lotectb = a.id_lotectb " +
                                                              "and x.cd_empresa = '" + (bsContabil.Current as TRegistro_LanctosCTB).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctoctb = " + (bsContabil.Current as TRegistro_LanctosCTB).Nr_lanctoctb.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_parcela y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and z.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lancto = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_parcela y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata w " +
                                                              "on z.cd_empresa = w.cd_empresa " +
                                                              "and z.nr_lancto = w.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on w.cd_empresa = nf.cd_empresa " +
                                                              "and w.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and nf.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and nf.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_parcela y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata w " +
                                                              "on z.cd_empresa = w.cd_empresa " +
                                                              "and z.nr_lancto = w.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on w.cd_empresa = nf.cd_empresa " +
                                                              "and w.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "  or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "where a.cd_contager = x.cd_contager " +
                                                              "and a.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                              "and x.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and x.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = a.cd_lanctocaixa)) " +
                                                              "and x.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and x.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_contager";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString();
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bindingSourceCaixa.DataSource = new TCD_LanCaixa().Select(filtro, 0, "");
                        break;
                    }
                case TP_Rastrear.tm_cheque:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "inner join tb_fin_liquidacao w " +
                                                              "on y.cd_contager = w.cd_contager " +
                                                              "and y.cd_lanctocaixa = w.cd_lanctocaixa " +
                                                              "inner join tb_fin_parcela z " +
                                                              "on w.cd_empresa = z.cd_empresa " +
                                                              "and w.nr_lancto = z.nr_lancto " +
                                                              "and w.cd_parcela = z.cd_parcela " +
                                                              "inner join tb_cob_titulo cob " +
                                                              "on z.cd_empresa = cob.cd_empresa " +
                                                              "and z.nr_lancto = cob.nr_lancto " +
                                                              "and z.cd_parcela = cob.cd_parcela " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and cob.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and cob.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and cob.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and cob.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and x.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_ctb_lanctosctb z " +
                                                              "on y.id_lotectb = z.id_lotectb " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and z.cd_empresa = '" + (bsContabil.Current as TRegistro_LanctosCTB).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lanctoctb = " + (bsContabil.Current as TRegistro_LanctosCTB).Nr_lanctoctb.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on z.cd_empresa = parc.cd_empresa " +
                                                              "and z.nr_lancto = parc.nr_lancto " +
                                                              "and z.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and dup.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and dup.nr_lancto = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on z.cd_empresa = parc.cd_empresa " +
                                                              "and z.nr_lancto = parc.nr_lancto " +
                                                              "and z.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on dup.cd_empresa = nfdup.cd_empresa " +
                                                              "and dup.nr_lancto = nfdup.nr_lanctoduplicata " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and nfdup.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and nfdup.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on z.cd_empresa = parc.cd_empresa " +
                                                              "and z.nr_lancto = parc.nr_lancto " +
                                                              "and z.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on dup.cd_empresa = nfdup.cd_empresa " +
                                                              "and dup.nr_lancto = nfdup.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on nfdup.cd_empresa = nf.cd_empresa " +
                                                              "and nfdup.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_titulo_x_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "where a.cd_empresa = z.cd_empresa " +
                                                              "and a.nr_lanctocheque = z.nr_lanctocheque " +
                                                              "and a.cd_banco = z.cd_banco " +
                                                              "and x.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = z.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = z.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = z.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = z.cd_lanctocaixa_dcamb_pa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and z.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + " " +
                                                              "and z.cd_parcela = " + (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = ("(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and y.cd_contager = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_contager.Trim() + "' " +
                                                              "and ((y.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa ?? "null" + ") " +
                                                              "   or(y.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_Juro ?? "null" + ") " +
                                                              "   or(y.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_Desc ?? "null" + ") " +
                                                              "   or(y.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_dcamb_at ?? "null" + ") " +
                                                              "   or(y.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_dcamb_pa ?? "null") + ")))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                                              "and x.cd_banco = a.cd_banco " +
                                                              "and x.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            BS_Titulo.DataSource = new TCD_LanTitulo().Select(filtro, 0, "", "");
                        break;
                    }
                case TP_Rastrear.tm_contabil:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where y.id_lotectb = a.id_lotectb " +
                                                              "and x.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_cob_titulo cob " +
                                                              "inner join tb_fin_parcela x " +
                                                              "on cob.cd_empresa = x.cd_empresa " +
                                                              "and cob.nr_lancto = x.nr_lancto " +
                                                              "and cob.cd_parcela = x.cd_parcela " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "where y.id_lotectb = a.id_lotectb " +
                                                              "and cob.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and cob.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and cob.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and cob.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null &&
                                        (bindingSourceCaixa.Current as TRegistro_LanCaixa).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = "a.id_lotectb";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (bindingSourceCaixa.Current as TRegistro_LanCaixa).ID_LoteCTB.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where y.id_lotectb = a.id_lotectb " +
                                                              "and x.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and x.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null &&
                                        (bsDuplicata.Current as TRegistro_LanDuplicata).Id_lotectb != null)
                                    {
                                        filtro[0].vNM_Campo = "a.id_lotectb";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (bsDuplicata.Current as TRegistro_LanDuplicata).Id_lotectb.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null &&
                                        (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_lotectb != null)
                                    {
                                        filtro[0].vNM_Campo = "a.id_lotectb";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_lotectb.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                              "where ((x.id_lotectb_fat = a.id_lotectb) " +
                                                              "     or(x.id_lotectb_cmv = a.id_lotectb)) " +
                                                              "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                              "where x.id_lotectb = a.id_lotectb " +
                                                              "and x.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_item y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "where ((y.id_lotectb_fat = a.id_lotectb) " +
                                                              "     or(y.id_lotectb_cmv = a.id_lotectb)) " +
                                                              "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                              "where x.id_lotectb = a.id_lotectb " +
                                                              "and x.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bsContabil.DataSource = new CamadaDados.Contabil.TCD_LanctosCTB().Select(filtro, 0, string.Empty, string.Empty);
                        break;
                    }
                case TP_Rastrear.tm_duplicata:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_cob_titulo y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and y.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and y.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and y.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and y.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and z.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and z.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_titulo_x_caixa w " +
                                                              "on z.cd_contager = w.cd_contager " +
                                                              "and z.cd_lanctocaixa = w.cd_lanctocaixa " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and w.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and w.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and w.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null &&
                                        (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = "a.id_lotectb";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                              "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fat_notafiscal y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = a.nr_lancto " +
                                                              "and y.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on y.cd_contager = caixa.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa ad " +
                                                              "on caixa.cd_contager = ad.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = ad.cd_lanctocaixa " +
                                                              "where a.cd_empresa = x.cd_empresa " +
                                                              "and a.nr_lancto = x.nr_lancto " +
                                                              "and ad.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and x.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and z.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and z.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bsDuplicata.DataSource = new TCD_LanDuplicata().Select(filtro, 0, "");
                        break;
                    }
                case TP_Rastrear.tm_estoque:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.cd_produto = a.cd_produto " +
                                                              "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                              "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_pedido_x_estoque x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.cd_produto = a.cd_produto " +
                                                              "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                              "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case TP_Rastrear.tm_nf:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                              "inner join tb_fin_parcela z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "inner join tb_cob_titulo w " +
                                                              "on z.cd_empresa = w.cd_empresa " +
                                                              "and z.nr_lancto = w.nr_lancto " +
                                                              "and z.cd_parcela = w.cd_parcela " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and w.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and w.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and w.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and w.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                              "inner join tb_fin_parcela z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on z.cd_empresa = liq.cd_empresa " +
                                                              "and z.nr_lancto = liq.nr_lancto " +
                                                              "and z.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and caixa.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and caixa.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                              "inner join tb_fin_parcela z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on z.cd_empresa = liq.cd_empresa " +
                                                              "and z.nr_lancto = liq.nr_lancto " +
                                                              "and z.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_titulo_x_caixa tc " +
                                                              "on caixa.cd_contager = tc.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = tc.cd_lanctocaixa " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and tc.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and tc.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and tc.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null &&
                                        (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_notafiscal_item x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and ((x.id_lotectb_fat = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ") " +
                                                              "   or(x.id_lotectb_cmv = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ")))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and x.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctoduplicata = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_estoque:
                                {
                                    if (BS_Estoque.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and x.cd_empresa = '" + (BS_Estoque.Current as TRegistro_LanEstoque).Cd_empresa.Trim() + "' " +
                                                              "and x.cd_produto = '" + (BS_Estoque.Current as TRegistro_LanEstoque).Cd_produto.Trim() + "' " +
                                                              "and x.id_lanctoestoque = " + (BS_Estoque.Current as TRegistro_LanEstoque).Id_lanctoestoque.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.nr_pedido";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on y.cd_empresa = parc.cd_empresa " +
                                                              "and y.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa ad " +
                                                              "on ad.cd_contager = caixa.cd_contager " +
                                                              "and ad.cd_lanctocaixa = caixa.cd_lanctocaixa " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and ad.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and x.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctoduplicata = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + ")";

                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on x.cd_empresa = liq.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = liq.nr_lancto " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and liq.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and liq.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and liq.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and liq.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = y.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on y.cd_empresa = parc.cd_empresa " +
                                                              "and y.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                              "and caixa.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and caixa.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                        {
                            bsNotaFiscal.DataSource = new TCD_LanFaturamento().Select(filtro, 0, "");
                            BuscarItensNf();
                        }
                        break;
                    }
                case TP_Rastrear.tm_pedido:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal nf " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on nf.cd_empresa = nfdup.cd_empresa " +
                                                              "and nf.nr_lanctofiscal = nfdup.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on nfdup.cd_empresa = dup.cd_empresa " +
                                                              "and nfdup.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_cob_titulo cob " +
                                                              "on parc.cd_empresa = cob.cd_empresa " +
                                                              "and parc.nr_lancto = cob.nr_lancto " +
                                                              "and parc.cd_parcela = cob.cd_parcela " +
                                                              "where nf.nr_pedido = a.nr_pedido " +
                                                              "and cob.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and cob.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and cob.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and cob.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal nf " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on nf.cd_empresa = nfdup.cd_empresa " +
                                                              "and nf.nr_lanctofiscal = nfdup.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata  dup " +
                                                              "on nfdup.cd_empresa = dup.cd_empresa " +
                                                              "and nfdup.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "where nf.nr_pedido = a.nr_pedido " +
                                                              "and caixa.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and caixa.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal nf " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on nf.cd_empresa = nfdup.cd_empresa " +
                                                              "and nf.nr_lanctofiscal = nfdup.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata  dup " +
                                                              "on nfdup.cd_empresa = dup.cd_empresa " +
                                                              "and nfdup.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_titulo_x_caixa tc " +
                                                              "on caixa.cd_contager = tc.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = tc.cd_lanctocaixa " +
                                                              "where nf.nr_pedido = a.nr_pedido " +
                                                              "and tc.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and tc.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "nad tc.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_fat_notafiscal_item x " +
                                                              "inner join tb_fat_notafiscal y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "where y.nr_pedido = a.nr_pedido " +
                                                              "and ((x.id_lotectb_fat = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ") " +
                                                              "   or(x.id_lotectb_cmv = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ")))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal nf " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on nf.cd_empresa = nfdup.cd_empresa " +
                                                              "and nf.nr_lanctofiscal = nfdup.nr_lanctofiscal " +
                                                              "where nf.nr_pedido = a.nr_pedido " +
                                                              "and nfdup.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and nfdup.nr_lanctoduplicata = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_estoque:
                                {
                                    if (BS_Estoque.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_pedido_x_estoque x " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and x.cd_empresa = '" + (BS_Estoque.Current as TRegistro_LanEstoque).Cd_empresa.Trim() + "' " +
                                                              "and x.cd_produto = '" + (BS_Estoque.Current as TRegistro_LanEstoque).Cd_produto.Trim() + "' " +
                                                              "and x.id_lanctoestoque = " + (BS_Estoque.Current as TRegistro_LanEstoque).Id_lanctoestoque.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal nf " +
                                                              "where nf.nr_pedido = a.nr_pedido " +
                                                              "and nf.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and nf.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on dup.cd_empresa = y.cd_empresa " +
                                                              "and dup.nr_lancto = y.nr_lanctoduplicata " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on liq.cd_empresa = parc.cd_empresa " +
                                                              "and liq.nr_lancto = parc.nr_lancto " +
                                                              "and liq.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on caixa.cd_contager = liq.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa ad " +
                                                              "on caixa.cd_contager = ad.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = ad.cd_lanctocaixa " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and ad.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on y.cd_empresa = dup.cd_empresa " +
                                                              "and y.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and parc.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and parc.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + " " +
                                                              "and parc.cd_parcela = " + (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "inner join tb_fin_liquidacao z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lanctoduplicata = z.nr_lancto " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and z.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and z.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and z.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on y.cd_empresa = dup.cd_empresa " +
                                                              "and y.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "where x.nr_pedido = a.nr_pedido " +
                                                              "and caixa.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and caixa.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                        {
                            BS_Pedido.DataSource = new TCD_Pedido().Select(filtro, 0, "");
                            BuscarItensPedido();
                        }
                        break;
                    }
                case TP_Rastrear.tm_adiantamento:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_cob_titulo cob " +
                                                              "inner join tb_fin_parcela x " +
                                                              "on cob.cd_empresa = x.cd_empresa " +
                                                              "and cob.nr_lancto = x.nr_lancto " +
                                                              "and cob.cd_parcela = x.cd_parcela " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on y.cd_contager = caixa.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa ad " +
                                                              "on caixa.cd_contager = ad.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = ad.cd_lanctocaixa " +
                                                              "where ad.id_adto = a.id_adto " +
                                                              "and cob.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and cob.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and cob.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and cob.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and x.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_titulo_x_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and z.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and z.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null &&
                                        (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and y.id_lotectb = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa  " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on y.cd_contager = liq.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = liq.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_pa)) " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and liq.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and liq.nr_lancto = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on y.cd_contager = liq.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = liq.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_pa)) " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on liq.cd_empresa = parc.cd_empresa " +
                                                              "and liq.nr_lancto = parc.nr_lancto " +
                                                              "and liq.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nf " +
                                                              "on dup.cd_empresa = nf.cd_empresa " +
                                                              "and dup.nr_lancto = nf.nr_lanctoduplicata " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and nf.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and nf.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on y.cd_contager = liq.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = liq.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_pa)) " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on liq.cd_empresa = parc.cd_empresa " +
                                                              "and liq.nr_lancto = parc.nr_lancto " +
                                                              "and liq.cd_parcela = parc.cd_parcela " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on parc.cd_empresa = dup.cd_empresa " +
                                                              "and parc.nr_lancto = dup.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata nfdup " +
                                                              "on dup.cd_empresa = nfdup.cd_empresa " +
                                                              "and dup.nr_lancto = nfdup.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on nfdup.cd_empresa = nf.cd_empresa " +
                                                              "and nfdup.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on y.cd_contager = liq.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = liq.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_pa)) " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and liq.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and liq.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + " " +
                                                              "and liq.cd_parcela = " + (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on y.cd_contager = liq.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = liq.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_juro) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_desc) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(y.cd_lanctocaixa = liq.cd_lanctocaixa_dcamb_pa)) " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and liq.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and liq.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and liq.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and liq.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "where x.id_adto = a.id_adto " +
                                                              "and x.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            BS_Consulta_Adiantamento.DataSource = new TCD_LanAdiantamento().Select(filtro, 0, "");
                        break;
                    }
                case TP_Rastrear.tm_parcela:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = y.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_adiantamento_x_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and y.cd_lanctocaixa = z.cd_lanctocaixa " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and z.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 2);
                                        filtro[filtro.Length - 2].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 2].vOperador = "=";
                                        filtro[filtro.Length - 2].vVL_Busca = (dsBloqueto.Current as blTitulo).Nr_lancto.ToString();

                                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (dsBloqueto.Current as blTitulo).Cd_parcela.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = y.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and y.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and y.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and x.cd_empresa = '" + (BS_Titulo.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (BS_Titulo.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (BS_Titulo.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and x.id_cobranca = " + (BS_Titulo.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.id_lotectb = " + (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and x.cd_empresa = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString() + " " +
                                                              "and x.id_liquid = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Id_liquid.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and y.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and y.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on y.cd_empresa = nf.cd_empresa " +
                                                              "and y.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = y.cd_lanctocaixa)) " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and y.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and y.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bsParcelas.DataSource = new TCD_LanParcela().Select(filtro, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                        break;
                    }
                case TP_Rastrear.tm_liquidacao:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                              "inner join tb_fin_adiantamento_x_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_juro) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_desc) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_dcamb_pa)) " +
                                                              "and y.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_cob_titulo y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "Where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and y.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and y.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and y.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and y.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_contager";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                                        filtro[filtro.Length - 1].vOperador = string.Empty;
                                        filtro[filtro.Length - 1].vVL_Busca = "((a.cd_lanctocaixa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")or " +
                                                                              " (a.cd_lanctocaixa_juro = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")or " +
                                                                              " (a.cd_lanctocaixa_desc = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")or " +
                                                                              " (a.cd_lanctocaixa_dcamb_at = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")or " +
                                                                              " (a.cd_lanctocaixa_dcamb_pa = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + "))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                              "inner join tb_fin_titulo_x_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_juro) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_desc) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lancto_caixa_dcamb_pa)) " +
                                                              "and y.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and y.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and y.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null &&
                                        (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = "a.id_lotectb";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'";
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lanctoduplicata " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = "a.cd_empresa";
                                        filtro[0].vOperador = "=";
                                        filtro[0].vVL_Busca = "'" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "'";

                                        Array.Resize(ref filtro, filtro.Length + 2);
                                        filtro[filtro.Length - 2].vNM_Campo = "a.nr_lancto";
                                        filtro[filtro.Length - 2].vOperador = "=";
                                        filtro[filtro.Length - 2].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString();

                                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "inner join tb_fat_notafiscal_x_duplicata z " +
                                                              "on y.cd_empresa = z.cd_empresa " +
                                                              "and y.nr_lancto = z.nr_lanctoduplicata " +
                                                              "inner join tb_fat_notafiscal nf " +
                                                              "on z.cd_empresa = nf.cd_empresa " +
                                                              "and z.nr_lanctofiscal = nf.nr_lanctofiscal " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.nr_lancto = a.nr_lancto " +
                                                              "and x.cd_parcela = a.cd_parcela " +
                                                              "and nf.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_transfcaixa:
                                {
                                    if (bsTransfCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = a.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_juro) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_desc) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_dcamb_at) " +
                                                              "   or(x.cd_lanctocaixa = a.cd_lanctocaixa_dcamb_pa)) " +
                                                              "and x.cd_contager = '" + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' " +
                                                              "and x.cd_lanctocaixa = " + (bsTransfCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bsLiquidacoes.DataSource = new TCD_LanLiquidacao().Select(filtro, 0, "");
                        break;
                    }
                case TP_Rastrear.tm_transfcaixa:
                    {
                        switch (PontoCentralOld)
                        {
                            case TP_Rastrear.tm_adiantamento:
                                {
                                    if (BS_Consulta_Adiantamento.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_adiantamento_x_caixa x " +
                                                              "inner join tb_fin_transfcaixa y " +
                                                              "on (((x.cd_contager = y.cd_conta_ent) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_ent)) " +
                                                              "  or((x.cd_contager = y.cd_conta_sai) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_sai))) " +
                                                              "where x.cd_contager = a.cd_contager " +
                                                              "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                              "and x.id_adto = " + (BS_Consulta_Adiantamento.Current as TRegistro_LanAdiantamento).Id_adto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_bloqueto:
                                {
                                    if (dsBloqueto.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_cob_titulo cob " +
                                                              "inner join tb_fin_parcela x " +
                                                              "on cob.cd_empresa = x.cd_empresa " +
                                                              "and cob.nr_lancto = x.nr_lancto " +
                                                              "and cob.cd_parcela = x.cd_parcela " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_transfcaixa trans " +
                                                              "on (((z.cd_contager = trans.cd_conta_ent) " +
                                                              "  and(z.cd_lanctocaixa = trans.cd_lanctocaixa_ent)) " +
                                                              "  or((z.cd_contager = trans.cd_conta_sai) " +
                                                              "  and(z.cd_lanctocaixa = trans.cd_lanctocaixa_sai))) " +
                                                              "where z.cd_contager = a.cd_contager " +
                                                              "and z.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                              "and cob.cd_empresa = '" + (dsBloqueto.Current as blTitulo).Cd_empresa.Trim() + "' " +
                                                              "and cob.nr_lancto = " + (dsBloqueto.Current as blTitulo).Nr_lancto.ToString() + " " +
                                                              "and cob.cd_parcela = " + (dsBloqueto.Current as blTitulo).Cd_parcela.ToString() + " " +
                                                              "and cob.id_cobranca = " + (dsBloqueto.Current as blTitulo).Id_cobranca.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_caixa:
                                {
                                    if (bindingSourceCaixa.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_transfcaixa x " +
                                                              "where (((x.cd_conta_ent = a.cd_contager) " +
                                                              "     and(x.cd_lanctocaixa_ent = a.cd_lanctocaixa)) " +
                                                              "     or((x.cd_conta_sai = a.cd_contager) " +
                                                              "     and(x.cd_lanctocaixa_sai = a.cd_lanctocaixa))) " +
                                                              "and (((x.cd_conta_ent = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "') " +
                                                              "   and(x.cd_lanctocaixa_ent = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")) " +
                                                              "   or((x.cd_conta_sai = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "') " +
                                                              "   and(x.cd_lanctocaixa_sai = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + "))))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_cheque:
                                {
                                    if (BS_Titulo.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                                              "inner join tb_fin_transfcaixa y " +
                                                              "on (((x.cd_contager = y.cd_conta_ent) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_ent)) " +
                                                              "  or((x.cd_contager = y.cd_conta_sai) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_sai))) " +
                                                              "where (((a.cd_contager = y.cd_conta_ent) " +
                                                              "     and(a.cd_lanctocaixa = y.cd_lanctocaixa_ent)) " +
                                                              "     or((a.cd_contager = y.cd_conta_sai) " +
                                                              "     and(a.cd_lanctocaixa = y.cd_lanctocaixa_sai))) " +
                                                              "and x.cd_empresa = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctocheque = " + (BS_Titulo.Current as TRegistro_LanTitulo).Nr_lanctocheque.ToString() + " " +
                                                              "and x.cd_banco = '" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco.Trim() + "')";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_contabil:
                                {
                                    if (bsContabil.Current != null &&
                                        (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_transfcaixa x " +
                                                              "where (((x.cd_conta_ent = a.cd_contager) " +
                                                              "     and(x.cd_lanctocaixa_ent = a.cd_lanctocaixa)) " +
                                                              "     or((x.cd_conta_sai = a.cd_contager) " +
                                                              "     and(x.cd_lanctocaixa_sai = a.cd_lanctocaixa))))";

                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                                        filtro[filtro.Length - 1].vOperador = "=";
                                        filtro[filtro.Length - 1].vVL_Busca = (bsContabil.Current as TRegistro_LanctosCTB).ID_LoteCTB.ToString();
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_duplicata:
                                {
                                    if (bsDuplicata.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_parcela x " +
                                                              "inner join tb_fin_liquidacao y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lancto = y.nr_lancto " +
                                                              "and x.cd_parcela = y.cd_parcela " +
                                                              "inner join tb_fin_caixa z " +
                                                              "on y.cd_contager = z.cd_contager " +
                                                              "and ((y.cd_lanctocaixa = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_juro = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_desc = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_at = z.cd_lanctocaixa) " +
                                                              "   or(y.cd_lanctocaixa_dcamb_pa = z.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_transfcaixa trans " +
                                                              "on (((z.cd_contager = trans.cd_conta_ent) " +
                                                              "  and(z.cd_lanctocaixa = trans.cd_lanctocaixa_ent)) " +
                                                              "  or((z.cd_contager = trans.cd_conta_sai) " +
                                                              "  and(z.cd_lanctocaixa = trans.cd_lanctocaixa_sai))) " +
                                                              "where (((trans.cd_conta_ent = a.cd_contager) " +
                                                              "     and(trans.cd_lanctocaixa_ent = a.cd_lanctocaixa)) " +
                                                              "     or((trans.cd_conta_sai = a.cd_contager) " +
                                                              "     and(trans.cd_lanctocaixa_sai = a.cd_lanctocaixa))) " +
                                                              "and x.cd_empresa = '" + (bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_liquidacao:
                                {
                                    if (bsLiquidacoes.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_caixa x " +
                                                              "inner join tb_fin_transfcaixa y " +
                                                              "on (((x.cd_contager = y.cd_conta_ent) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_ent)) " +
                                                              "  or((x.cd_contager = y.cd_conta_sai) " +
                                                              "  and(x.cd_lanctocaixa = y.cd_lanctocaixa_sai))) " +
                                                              "where (((y.cd_conta_ent = a.cd_contager) " +
                                                              "     and(y.cd_lanctocaixa_ent = a.cd_lanctocaixa)) " +
                                                              "     or((y.cd_conta_sai = a.cd_contager) " +
                                                              "     and(y.cd_lanctocaixa_sai = a.cd_lanctocaixa))) " +
                                                              "and x.cd_contager = '" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_contager.Trim() + "' " +
                                                              "and ((x.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa.ToString() + ") " +
                                                              "   or(x.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_Juro.ToString() + ") " +
                                                              "   or(x.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_Desc.ToString() + ") " +
                                                              "   or(x.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_dcamb_at.ToString() + ") " +
                                                              "   or(x.cd_lanctocaixa = " + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_lanctocaixa_dcamb_pa.ToString() + ")))";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_nf:
                                {
                                    if (bsNotaFiscal.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on x.cd_empresa = dup.cd_empresa " +
                                                              "and x.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaica_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_transfcaixa trans " +
                                                              "on (((caixa.cd_contager = trans.cd_conta_ent) " +
                                                              "  and(caixa.cd_lanctocaixa = trans.cd_lanctocaixa_ent)) " +
                                                              "  or((caixa.cd_contager = trans.cd_conta_sai) " +
                                                              "  and(caixa.cd_lanctocaixa = trans.cd_lanctocaixa_sai))) " +
                                                              "where caixa.cd_contager = a.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                              "and x.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_parcela:
                                {
                                    if (bsParcelas.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                              "inner join tb_fin_caixa y " +
                                                              "on x.cd_contager = y.cd_contager " +
                                                              "and ((x.cd_lanctocaixa = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_juro = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_desc = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_at = y.cd_lanctocaixa) " +
                                                              "   or(x.cd_lanctocaixa_dcamb_pa = y.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_transfcaixa trans " +
                                                              "on (((y.cd_contager = trans.cd_conta_ent) " +
                                                              "  and(y.cd_lanctocaixa = trans.cd_lanctocaixa_ent)) " +
                                                              "  or((y.cd_contager = trans.cd_conta_sai) " +
                                                              "  and(y.cd_lanctocaixa = trans.cd_lanctocaixa_sai))) " +
                                                              "where y.cd_contager = a.cd_contager " +
                                                              "and y.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                              "and x.cd_empresa = '" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "' " +
                                                              "and x.nr_lancto = " + (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.ToString() + " " +
                                                              "and x.cd_parcela = " + (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.ToString() + ")";
                                    }
                                    break;
                                }
                            case TP_Rastrear.tm_pedido:
                                {
                                    if (BS_Pedido.Current != null)
                                    {
                                        filtro[0].vNM_Campo = string.Empty;
                                        filtro[0].vOperador = "EXISTS";
                                        filtro[0].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                              "inner join tb_fat_notafiscal_x_duplicata y " +
                                                              "on x.cd_empresa = y.cd_empresa " +
                                                              "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                              "inner join tb_fin_duplicata dup " +
                                                              "on y.cd_empresa = dup.cd_empresa " +
                                                              "and y.nr_lanctoduplicata = dup.nr_lancto " +
                                                              "inner join tb_fin_parcela parc " +
                                                              "on dup.cd_empresa = parc.cd_empresa " +
                                                              "and dup.nr_lancto = parc.nr_lancto " +
                                                              "inner join tb_fin_liquidacao liq " +
                                                              "on parc.cd_empresa = liq.cd_empresa " +
                                                              "and parc.nr_lancto = liq.nr_lancto " +
                                                              "and parc.cd_parcela = liq.cd_parcela " +
                                                              "inner join tb_fin_caixa caixa " +
                                                              "on liq.cd_contager = caixa.cd_contager " +
                                                              "and ((liq.cd_lanctocaixa = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_juro = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_desc = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_at = caixa.cd_lanctocaixa) " +
                                                              "   or(liq.cd_lanctocaixa_dcamb_pa = caixa.cd_lanctocaixa)) " +
                                                              "inner join tb_fin_transfcaixa trans " +
                                                              "on (((caixa.cd_contager = trans.cd_conta_ent) " +
                                                              "  and(caixa.cd_lanctocaixa = trans.cd_lanctocaixa_ent)) " +
                                                              "  or((caixa.cd_contager = trans.cd_conta_sai) " +
                                                              "  and(caixa.cd_lanctocaixa = trans.cd_lanctocaixa_sai))) " +
                                                              "where caixa.cd_contager = a.cd_contager " +
                                                              "and caixa.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                              "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")";
                                    }
                                    break;
                                }
                        }
                        if (filtro[0].vVL_Busca != null)
                            bsTransfCaixa.DataSource = new TCD_LanCaixa().Select(filtro, 0, "");
                        break;
                    }
            }
        }

        private void TFRastrearLancamentos_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, g_Consulta);
            ShapeGrid.RestoreShape(this, g_Consulta_Pedido);
            ShapeGrid.RestoreShape(this, g_Itens);
            ShapeGrid.RestoreShape(this, gBloquetos);
            ShapeGrid.RestoreShape(this, gContabil);
            ShapeGrid.RestoreShape(this, gEstoque);
            ShapeGrid.RestoreShape(this, gLiquidacoes);
            ShapeGrid.RestoreShape(this, tList_RegLanFaturamentoDataGridDefault);
            ShapeGrid.RestoreShape(this, dataGridcaixa);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, duplicataDataGridDefault);
            ShapeGrid.RestoreShape(this, dG_Titulo);
            ShapeGrid.RestoreShape(this, itensNotaDataGridDefault);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            AtivarAba();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PontoCentral(true);
            Rastrear();
        }

        private void tcFaturamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            PontoCentral(true);
            Rastrear();
        }

        private void tcCentral_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            PontoCentral(false);
        }

        private void tcFaturamento_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            PontoCentral(false);
        }

        private void bsNotaFiscal_PositionChanged(object sender, EventArgs e)
        {
            BuscarItensNf();
        }

        private void tcCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PontoCentral(true);
            Rastrear();
        }

        private void tcCaixa_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            PontoCentral(false);
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            BuscarItensPedido();
        }

        private void TFRastrearLancamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, g_Consulta);
            ShapeGrid.SaveShape(this, g_Consulta_Pedido);
            ShapeGrid.SaveShape(this, g_Itens);
            ShapeGrid.SaveShape(this, gBloquetos);
            ShapeGrid.SaveShape(this, gContabil);
            ShapeGrid.SaveShape(this, gEstoque);
            ShapeGrid.SaveShape(this, gLiquidacoes);
            ShapeGrid.SaveShape(this, tList_RegLanFaturamentoDataGridDefault);
            ShapeGrid.SaveShape(this, dataGridcaixa);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, duplicataDataGridDefault);
            ShapeGrid.SaveShape(this, dG_Titulo);
            ShapeGrid.SaveShape(this, itensNotaDataGridDefault);
        }

        private void bbImpBoleto_Click(object sender, EventArgs e)
        {
            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Bloqueto encontra-se cancelado. Não sera possivel realizar a compensação do mesmo!", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido reimprimir bloqueto COMPENSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Chamar tela de impressao para o bloqueto
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                    fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                            new blListaTitulo() { dsBloqueto.Current as blTitulo },
                                                            fImp.pSt_imprimir,
                                                            fImp.pSt_visualizar,
                                                            fImp.pSt_enviaremail,
                                                            fImp.pSt_exportPdf,
                                                            fImp.Path_exportPdf,
                                                            fImp.pDestinatarios,
                                                            "BLOQUETO Nº " + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim(),
                                                            fImp.pDs_mensagem,
                                                            false);
                }
            }
        }

        private void bbEnvEmail_Click(object sender, EventArgs e)
        {
            if(bsNotaFiscal.Current != null)
            {
                TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                            (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                            null);
                //Buscar Itens NFe
                rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                               rNfe.Nr_lanctofiscalstr,
                                                               string.Empty,
                                                               null);
                if (rNfe.Tp_nota.Trim().ToUpper().Equals("P") && rNfe.Cd_modelo.Trim().Equals("55"))
                {
                    #region DANFE
                    if (!System.IO.File.Exists(System.IO.Path.GetTempPath() + "NFe" + rNfe.Chave_acesso_nfe.Trim() + ".pdf"))
                    {
                        FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
                        Danfe.Altera_Relatorio = false;
                        Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
                        Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
                        Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
                        Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
                        Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST));

                        BindingSource Bin = new BindingSource();
                        Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
                        Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
                        Danfe.NM_Classe = "TFLanConsultaNFe";
                        Danfe.Modulo = "FAT";
                        Danfe.Ident = "TFLanFaturamento_Danfe";
                        Danfe.DTS_Relatorio = Bin;
                        //Buscar financeiro da DANFE
                        TList_RegLanParcela lParc =
                            new TCD_LanParcela().Select(
                                            new TpBusca[]
                                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                        }
                                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                        if (lParc.Count == 0)
                        {
                            //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                            lParc =
                                new TCD_LanParcela().Select(
                                                new TpBusca[]
                                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                            }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            if (lParc.Count == 0)
                            {
                                //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                                lParc =
                                    new TCD_LanParcela().Select(
                                        new TpBusca[]
                                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                            }
                                                   }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                            }
                        }
                        if (lParc.Count > 0)
                        {
                            for (int i = 0; i < lParc.Count; i++)
                            {
                                if (i < 12)
                                {
                                    Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                    Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                                }
                                else
                                    break;
                            }
                        }
                        //Verificar se existe logo configurada para a empresa
                        object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                            }
                                                    }, "a.logoEmpresa");
                        if (log != null)
                            Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
                        Danfe.Gera_Relatorio(string.Empty,
                                             false,
                                             false,
                                             false,
                                             true,
                                             System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar.ToString() + "NFe" + rNfe.Chave_acesso_nfe.Trim() + ".pdf",
                                             null,
                                             null,
                                             string.Empty,
                                             string.Empty);
                    }
                    #endregion
                    #region 
                    if (!System.IO.File.Exists(System.IO.Path.GetTempPath() + rNfe.Chave_acesso_nfe.Trim() + "-nfe.xml"))
                    {
                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                      CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rNfe.Cd_empresa,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
                        if (lCfg.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe configuração para emitir NF-e na empresa " + (bsNotaFiscal.Current as TRegistro_LanAdiantamento).Cd_empresa, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        try
                        {
                            srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar.ToString(),
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          rNfe.Cd_empresa,
                                                                          rNfe.Nr_notafiscalstr,
                                                                          lCfg[0]);

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    #endregion
                    //Enviar Email
                    using (TFMsgEmail fEmail = new TFMsgEmail())
                    {
                        fEmail.lAnexos.Add(System.IO.Path.GetTempPath() + "NFe" + rNfe.Chave_acesso_nfe.Trim() + ".pdf");
                        fEmail.lAnexos.Add(System.IO.Path.GetTempPath() + rNfe.Chave_acesso_nfe.Trim() + "-nfe.xml");
                        //Verificar se cliente possui email
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + rNfe.Cd_clifor.Trim() + "'"}}, "a.email");
                        if (obj == null ? false : !string.IsNullOrWhiteSpace(obj.ToString()))
                            fEmail.pDs_destinatario = obj.ToString();
                        if (fEmail.ShowDialog() == DialogResult.OK)
                        {
                            List<string> lDest = new List<string>();
                            string[] aux = fEmail.pDs_destinatario.Split(new char[] { ';' });
                            foreach (string s in aux) lDest.Add(s);
                            new Email(lDest, fEmail.pTitulo, fEmail.Mensagem, fEmail.lAnexos).EnviarEmail();
                        }
                    }
                }
            }
        }
    }
}
