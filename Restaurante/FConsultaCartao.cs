using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante;
using System.IO;
using Utils;
using Restaurante.Impressao;

namespace Restaurante
{
    public partial class TFConsultaCartao : Form
    {
        public TFConsultaCartao()
        {
            InitializeComponent();
        }
        public string LoginPdv
        { get; set; }
        private CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa { get; set; }
        private bool Altera_Relatorio = false;
        private List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lAdiant
        { get; set; }

        private CamadaDados.Faturamento.PDV.TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private TList_CFG lcfg { get; set; } = new TList_CFG();
        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }
        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
        private void afterbusca()
        {

            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(lcfg[0].cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + lcfg[0].cd_empresa.Trim() + "'";
            }
            if (lcfg[0].Tp_cartao.Equals("0") || lcfg[0].Tp_cartao.Equals("2"))
            {
                if (!string.IsNullOrEmpty(nr_cartao.Text.SoNumero()))
                {
                    if (lcfg[0].Tp_cartao.Equals("0"))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_cartao";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = nr_cartao.Text.SoNumero();
                    }
                    else
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vOperador = "exists";
                        filtro[filtro.Length - 1].vVL_Busca = "( select 1 from tb_res_prevenda x where a.id_cartao = x.id_cartao and x.nr_senhafastfood = '" + nr_cartao.Text.SoNumero() + "'  )";
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(id_mesa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_mesa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_mesa.Text;
                }
                if (!string.IsNullOrEmpty(id_local.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_local";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_local.Text;
                }
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_nfce.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_nfce.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(DT_Inicial.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abertura)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(DT_Final.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abertura)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + " 23:59:59'";
            }
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                status += virg + "'F'";
                virg = ",";
            }
            if (string.IsNullOrEmpty(status))
                status = "'A','F' ";
            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
            filtro[filtro.Length - 1].vOperador = "in";
            filtro[filtro.Length - 1].vVL_Busca = "(" + status + ")";

            string st_nfce = "0";
            if (emetido.Checked && nemitido.Checked)
                st_nfce = "0";
            else if (emetido.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "is not null";
            }
            else if (nemitido.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "is null";
            }
            else
                st_nfce = "0";
            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
            filtro[filtro.Length - 1].vOperador = "in";
            filtro[filtro.Length - 1].vVL_Busca = "(" + status + ")";

            if (!string.IsNullOrEmpty(edtTelefone.Text.SoNumero().Trim()))
                Estruturas.CriarParametro(ref filtro, "dbo.fvalida_numeros(d.celular)", "'" + edtTelefone.Text.SoNumero().Trim() + "'");

            bsCartao.DataSource = new TCD_Cartao().Select(filtro, 0, string.Empty, "a.nr_senhafastfood asc");
            bsCartao_PositionChanged(this, new EventArgs());
            bsCartao.ResetCurrentItem();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bsCartao_PositionChanged(object sender, EventArgs e)
        {
            if (bsCartao.Current != null)
            {
                (bsCartao.Current as TRegistro_Cartao).lPreVenda = TCN_PreVenda.Buscar(cbEmpresa.SelectedValue.ToString(),
                    (bsCartao.Current as TRegistro_Cartao).id_cartao.ToString(), string.Empty, string.Empty, string.Empty, "A", null);

                bsCartao.ResetCurrentItem();
                bsPreVenda_PositionChanged(this, new EventArgs());
                bsItens_PositionChanged(this, new EventArgs());
                bsPreVenda.ResetCurrentItem();
            }
        }

        private void bsPreVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsCartao.Current != null)
                if ((bsCartao.Current as TRegistro_Cartao).lPreVenda.Count > 0)
                    (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(p =>
                    {
                        p.lItens = TCN_PreVenda_Item.Buscar(cbEmpresa.SelectedValue.ToString(), p.id_prevenda.ToString(), string.Empty, string.Empty, null);
                    });
            bsItens_PositionChanged(this, new EventArgs());
            bsPreVenda.ResetCurrentItem();
        }

        private void GerarNFCe()
        {
            if (bsCartao.Current == null ? false :
                MessageBox.Show("Gerar NFCe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TList_ItensPreVenda_X_ItensCupom it = new TList_ItensPreVenda_X_ItensCupom();
                it = TCN_ItensPreVenda_X_ItensCupom.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                           (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                                                           string.Empty, 
                                                           string.Empty, 
                                                           string.Empty, 
                                                           null);
                if (it.Count <= 0)
                    return;
                CamadaDados.Faturamento.PDV.TList_VendaRapida lVenda =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(it[0].Id_VendaRapida.ToString(),
                                                                         (bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         decimal.Zero,
                                                                         decimal.Zero,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         1,
                                                                         null);
                //Verificar se existe configuração para emitir NFC-e
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CfgNfe().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lVenda[0].Cd_empresa.Trim() + "'"
                                    }
                                }, "a.tp_ambiente_nfce");
                if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                {
                    MessageBox.Show("Empresa<" + lVenda[0].Cd_empresa.Trim() + "> não esta habilitada para emitir NFC-e.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui cupom
                if (new CamadaDados.Faturamento.PDV.TCD_NFCe().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_cupom " +
                                        "and x.cd_empresa = '" + lVenda[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + lVenda[0].Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui cupom fiscal/NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui nfe
                if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.cd_empresa = '" + lVenda[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + lVenda[0].Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui Faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {

                    lVenda[0].lItem =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(lVenda[0].Id_vendarapidastr,
                                                                              lVenda[0].Cd_empresa,
                                                                              false,
                                                                              string.Empty,
                                                                              null);
                    //Processar cupom fiscal
                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                    //Buscar dados PDV
                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                }
                            }, "a.id_pdv");
                    if (obj == null)
                    {
                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_pdv",
                                vOperador = "=",
                                vVL_Busca = obj.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                            }
                        }, "1") == null)
                        CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                            new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                            {
                                Id_pdvstr = obj.ToString(),
                                Login = Utils.Parametros.pubLogin
                            }, null);
                    //Buscar sessao aberta
                    dados.rSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(obj.ToString(),
                                                                                    string.Empty,
                                                                                    Utils.Parametros.pubLogin,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    "'A'",
                                                                                    1,
                                                                                    null)[0];
                    dados.lItens = lVenda[0].lItem;
                    dados.Cd_clifor = lVenda[0].Cd_clifor;
                    dados.Nm_clifor = lVenda[0].Nm_clifor;
                    dados.CpfCgc = string.Empty;
                    dados.Endereco = string.Empty;
                    dados.Mensagem = string.Empty;
                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                    dados.St_vendacombustivel = false;
                    dados.St_cupomavulso = true;
                    dados.St_agruparProduto = false;

                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                    if (rNFCe != null)
                        if (!rNFCe.St_contingencia)
                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                            {
                                fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                  rNFCe.Id_nfcestr,
                                                                                                  null);
                                fGerNfe.ShowDialog();
                            }
                        else
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            BindingSource dts = new BindingSource();
                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                            Rel.DTS_Relatorio = dts;// bsItens;
                            //DTS Cupom
                            BindingSource bsNFCe = new BindingSource();
                            bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                  rNFCe.Id_nfcestr,
                                                                                                  null);
                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                            //Buscar Empresa
                            BindingSource bsEmpresa = new BindingSource();
                            bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rEmpresa };
                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                            //Forma Pagamento
                            BindingSource bsPagto = new BindingSource();
                            List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                            new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from  x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_vendarapida = a.id_cupom " +
                                                    "and x.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                    "and x.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
                                    }
                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                    (aux, venda) =>
                                                        new
                                                        {
                                                            tp_portador = aux,
                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                        }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                        {
                                                            Tp_portador = x.tp_portador,
                                                            Vl_recebido = x.Vl_recebido,
                                                            Vl_troco_ch = x.Vl_troco_ch,
                                                            Vl_troco_dh = x.Vl_troco_dh
                                                        }));
                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.id_cupom = y.id_vendarapida " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                        "and y.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
                                        }
                                    }, 1, string.Empty);
                            if (lDup.Count > 0)
                                lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                {
                                    Tp_portador = "05",
                                    Vl_recebido = lDup[0].Vl_documento
                                });
                            bsPagto.DataSource = lPagto;
                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                            //Parametros
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                            obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_lote = a.id_lote " +
                                                        "and x.status = '100')"
                                        }
                                    }, "a.tp_ambiente");
                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                  (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                  null);
                            if (!string.IsNullOrEmpty(dadoscf))
                            {
                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                string placa = string.Empty;
                                string km = string.Empty;
                                string frota = string.Empty;
                                string requisicao = string.Empty;
                                string nm_motorista = string.Empty;
                                string cpf_motorista = string.Empty;
                                string media = string.Empty;
                                string virg = string.Empty;
                                foreach (string s in linhas)
                                {
                                    string[] colunas = s.Split(new char[] { '/' });
                                    placa += virg + colunas[0];
                                    km += virg + colunas[1];
                                    frota += virg + colunas[2];
                                    requisicao += virg + colunas[3];
                                    nm_motorista += virg + colunas[4];
                                    cpf_motorista += virg + colunas[5];
                                    media += virg + colunas[6];
                                    virg = ",";
                                }
                                if (!string.IsNullOrEmpty(placa))
                                    Rel.Parametros_Relatorio.Add("PLACA", placa);
                                if (!string.IsNullOrEmpty(km))
                                    Rel.Parametros_Relatorio.Add("KM", km);
                                if (!string.IsNullOrEmpty(media))
                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                if (!string.IsNullOrEmpty(frota))
                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                if (!string.IsNullOrEmpty(requisicao))
                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                if (!string.IsNullOrEmpty(nm_motorista))
                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                if (!string.IsNullOrEmpty(cpf_motorista))
                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                            }
                            Rel.Nome_Relatorio = "DANFE_NFCE";
                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "DANFE_NFCE";
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                            {
                                BindingSource bsItens = new BindingSource();
                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                Rel.DTS_Relatorio = bsItens;
                            }
                            if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                else
                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                            //Verificar se existe Impressora padrão para o PDV
                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.impressorapadrao");
                            string print = obj == null ? string.Empty : obj.ToString();
                            if (string.IsNullOrEmpty(print))
                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                {
                                    if (fLista.ShowDialog() == DialogResult.OK)
                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                            print = fLista.Impressora;
                                }
                            //Imprimir
                            if (!string.IsNullOrEmpty(print))
                            {
                                Rel.ImprimiGraficoReduzida(print,
                                                           true,
                                                           false,
                                                           null,
                                                           string.Empty,
                                                           string.Empty,
                                                           1);
                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                    rNFCe.rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                    Rel.ImprimiGraficoReduzida(print,
                                                               true,
                                                               false,
                                                               null,
                                                               string.Empty,
                                                               string.Empty,
                                                               1);
                            }
                        }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                {
                    fGerar.St_NFCe = true;
                    if (fGerar.ShowDialog() == DialogResult.OK)
                        if (fGerar.lItens != null)
                            if (fGerar.lItens.Count > 0)
                            {
                                try
                                {
                                    //Processar cupom fiscal
                                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                    //Buscar dados PDV
                                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.id_pdv");
                                    if (obj == null)
                                    {
                                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_pdv",
                                                vOperador = "=",
                                                vVL_Busca = obj.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                            }
                                        }, "1") == null)
                                        CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                                            new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                                            {
                                                Id_pdvstr = obj.ToString(),
                                                Login = Utils.Parametros.pubLogin
                                            }, null);
                                    //Buscar sessao aberta
                                    dados.rSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(obj.ToString(),
                                                                                                    string.Empty,
                                                                                                    Utils.Parametros.pubLogin,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    "'A'",
                                                                                                    1,
                                                                                                    null)[0];
                                    dados.lItens = fGerar.lItens;
                                    dados.Cd_clifor = string.Empty;
                                    dados.Nm_clifor = string.Empty;
                                    dados.CpfCgc = string.Empty;
                                    dados.Endereco = string.Empty;
                                    dados.Mensagem = string.Empty;
                                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                    dados.St_vendacombustivel = false;
                                    dados.St_cupomavulso = true;
                                    dados.St_agruparProduto = false;

                                    PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                    if (rNFCe != null)
                                        if (!rNFCe.St_contingencia)
                                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                            {
                                                fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                  null);
                                                fGerNfe.ShowDialog();
                                            }
                                        else
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource dts = new BindingSource();
                                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                            Rel.DTS_Relatorio = dts;// bsItens;
                                            //DTS Cupom
                                            BindingSource bsNFCe = new BindingSource();
                                            bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                              string.Empty,
                                                                                                              rNFCe.Cd_empresa,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              decimal.Zero,
                                                                                                              decimal.Zero,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              false,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              1,
                                                                                                              null);
                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                                CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                   (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                   string.Empty,
                                                                                                   null);
                                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                            //Buscar Empresa
                                            BindingSource bsEmpresa = new BindingSource();
                                            bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                null);
                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                            //Forma Pagamento
                                            BindingSource bsPagto = new BindingSource();
                                            List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                                            new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                    "and x.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
                                                    }
                                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                    (aux, venda) =>
                                                                        new
                                                                        {
                                                                            tp_portador = aux,
                                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                        }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = x.tp_portador,
                                                                            Vl_recebido = x.Vl_recebido,
                                                                            Vl_troco_ch = x.Vl_troco_ch,
                                                                            Vl_troco_dh = x.Vl_troco_dh
                                                                        }));
                                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr + ")"
                                                        }
                                                    }, 1, string.Empty);
                                            if (lDup.Count > 0)
                                                lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                {
                                                    Tp_portador = "05",
                                                    Vl_recebido = lDup[0].Vl_documento
                                                });
                                            bsPagto.DataSource = lPagto;
                                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                            //Parametros
                                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                            obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.id_lote = a.id_lote " +
                                                                        "and x.status = '100')"
                                                        }
                                                    }, "a.tp_ambiente");
                                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                  (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                  null);
                                            if (!string.IsNullOrEmpty(dadoscf))
                                            {
                                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                                string placa = string.Empty;
                                                string km = string.Empty;
                                                string frota = string.Empty;
                                                string requisicao = string.Empty;
                                                string nm_motorista = string.Empty;
                                                string cpf_motorista = string.Empty;
                                                string media = string.Empty;
                                                string virg = string.Empty;
                                                foreach (string s in linhas)
                                                {
                                                    string[] colunas = s.Split(new char[] { '/' });
                                                    placa += virg + colunas[0];
                                                    km += virg + colunas[1];
                                                    frota += virg + colunas[2];
                                                    requisicao += virg + colunas[3];
                                                    nm_motorista += virg + colunas[4];
                                                    cpf_motorista += virg + colunas[5];
                                                    media += virg + colunas[6];
                                                    virg = ",";
                                                }
                                                if (!string.IsNullOrEmpty(placa))
                                                    Rel.Parametros_Relatorio.Add("PLACA", placa);
                                                if (!string.IsNullOrEmpty(km))
                                                    Rel.Parametros_Relatorio.Add("KM", km);
                                                if (!string.IsNullOrEmpty(media))
                                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                if (!string.IsNullOrEmpty(frota))
                                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                if (!string.IsNullOrEmpty(requisicao))
                                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                if (!string.IsNullOrEmpty(nm_motorista))
                                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                if (!string.IsNullOrEmpty(cpf_motorista))
                                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                            }
                                            Rel.Nome_Relatorio = "DANFE_NFCE";
                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                            Rel.Modulo = "FAT";
                                            Rel.Ident = "DANFE_NFCE";
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                            {
                                                BindingSource bsItens = new BindingSource();
                                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                Rel.DTS_Relatorio = bsItens;
                                            }
                                            if (rNFCe.Id_contingencia.HasValue)
                                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                else
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                            //Verificar se existe Impressora padrão para o PDV
                                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.impressorapadrao");
                                            string print = obj == null ? string.Empty : obj.ToString();
                                            if (string.IsNullOrEmpty(print))
                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                {
                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                            print = fLista.Impressora;

                                                }
                                            //Imprimir
                                            if (!string.IsNullOrEmpty(print))
                                            {
                                                Rel.ImprimiGraficoReduzida(print,
                                                                           true,
                                                                           false,
                                                                           null,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           1);
                                                if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                    Rel.ImprimiGraficoReduzida(print,
                                                                               true,
                                                                               false,
                                                                               null,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               1);
                                            }
                                        }
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                                MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FConsultaCartao_Load(object sender, EventArgs e)
        {
            DT_Inicial.Text = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy")).ToString();
            DT_Final.Text = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")).ToString();
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";

            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);

            gplocalmesa.Visible = false;
            if (lcfg.Count <= 0)
            {
                MessageBox.Show("Não existe configuração cadastrada!", "Mensagem", MessageBoxButtons.OK);
                return;
            }
            if (lcfg[0].Tp_cartao.Equals("0"))
            {
                lblcartao.Text = "Cartão";
            }

            if (lcfg[0].Tp_cartao.Equals("1"))
            {
                nr_cartao.Visible = false;
                lblcartao.Visible = false;
            }
            else if (lcfg[0].Tp_cartao.Equals("1") || lcfg[0].bool_mesacartao)
            {
                lblcartao.Text = "Cartão:";
            }
            if (lcfg[0].bool_mesacartao)
                gplocalmesa.Visible = true;
            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                            string.Empty,
                                                                            Utils.Parametros.pubTerminal,
                                                                            string.Empty,
                                                                            null);
            if (lPdv.Count < 1)
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            else if (!string.IsNullOrEmpty(lPdv[0].Nm_empresa))
            {
                //Buscar Config Cupom
                lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
                if (lCfg.Count < 1)
                {
                    MessageBox.Show("Não existe configuração para emitir venda rapida na empresa " + lPdv[0].Cd_empresa,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            if (string.IsNullOrEmpty(LoginPdv))
                LoginPdv = Utils.Parametros.pubLogin;

            //Verificar sessao
            if (new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_pdv",
                                    vOperador = "=",
                                    vVL_Busca = lPdv[0].Id_pdvstr
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.login",
                                    vOperador = "=",
                                    vVL_Busca = "'" + LoginPdv + "'"
                                }
                            }, "1") == null)
                CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                    new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                    {
                        Id_pdvstr = lPdv[0].Id_pdvstr,
                        Login = LoginPdv
                    }, null);
            //Buscar sessao aberta
            lSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(lPdv[0].Id_pdvstr,
                                                                      string.Empty,
                                                                      LoginPdv,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'A'",
                                                                      1,
                                                                      null);
            if (lSessao.Count < 1)
            {
                MessageBox.Show("Não existe sessão aberta para o PDV " + lPdv[0].Id_pdvstr + " Login " + LoginPdv,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            //Busca caixa aberto
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + LoginPdv + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                        }, 1, string.Empty);
            if (lCaixa.Count > 0)
                rCaixa = lCaixa[0];
            else
            {
                MessageBox.Show("Não existe caixa aberto para iniciar movimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
            }
            if (lcfg[0].Tp_cartao.Equals("2"))
                lblcartao.Text = "Comanda:";
            tbprincipal.RowStyles[2] = new RowStyle(SizeType.Absolute, 0);

        }
        private void cadclifor()
        {
            using (Cadastro.TFCliforDetalhado a = new Cadastro.TFCliforDetalhado())
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar(a.rClifor, null);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void FConsultaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterbusca();
            else if (e.KeyCode.Equals(Keys.F1))
                cadclifor();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F10))
                toolStripButton2_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F8))
                toolStripButton1_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F9))
                toolStripButton3_Click(this, new EventArgs());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja reimprimir pedido?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                IMP_Cartao.Impressao_PEDIDOS((bsPreVenda.Current as TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao), false);
                IMP_Cartao.Impressao_FASTFOOD((bsPreVenda.Current as TRegistro_PreVenda), (bsCartao.Current as TRegistro_Cartao));
                MessageBox.Show("Impressoes enviadas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }




        }

        private decimal CalcularDescEspecial(CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg,
                                             string cd_produto,
                                             decimal Qtde,
                                             decimal Vl_unit)
        {
            //St_descEspecial = false;
            if (rProg != null)
            {
                if (rProg.Valor > decimal.Zero && rProg.Qtd_minVenda > 1)
                {
                    if ((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).lItens.
                        Where(p => p.Cd_produto.Equals(cd_produto)).Sum(p => p.Quantidade) >= rProg.Qtd_minVenda)
                    {
                        //   DesabilitarDescontos();
                        if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                            return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                        else
                            return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                    }
                    return decimal.Zero;
                }
                else if (rProg.Valor > decimal.Zero)
                {
                    //   DesabilitarDescontos();
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Math.Round(Qtde * rProg.Valor, 2, MidpointRounding.AwayFromZero);
                    else
                        return Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2, MidpointRounding.AwayFromZero);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (bsCartao.Current != null)
            {
                //buscar se tiver cupom nao pode carregar 
                TList_ItensPreVenda_X_ItensCupom cupom = new TList_ItensPreVenda_X_ItensCupom();
                cupom = TCN_ItensPreVenda_X_ItensCupom.Buscar((bsPreVenda.Current as TRegistro_PreVenda).Cd_empresa,
                                                              (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString(),
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
                if (cupom.Count > 0)
                {
                    MessageBox.Show("Não pode carregar esta venda, pois já possui cupom!", "mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (MessageBox.Show("Deseja Carregar venda FAST FOOD?", "Pegunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (TFLanPreVenda prevenda = new TFLanPreVenda())
                    {
                        prevenda.rCartao = (bsCartao.Current as TRegistro_Cartao);
                        prevenda.ShowDialog();
                        Close();
                    }

                }
            }
            else
                MessageBox.Show("Selecione um registro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void afterExclui()
        {
            if (bsCartao.Current != null)
            {
                bool st_excluir = true;
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR VENDA", null))
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR EXCLUIR VENDA";
                        if (fRegra.ShowDialog() != DialogResult.OK)
                            st_excluir = false;
                    }
                if (st_excluir)
                    if (MessageBox.Show("Confirma a exclusão do pedido selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_Cartao.Excluir(bsCartao.Current as TRegistro_Cartao, null);
                            MessageBox.Show("Pedido excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(x =>
                            {
                                x.st_ativo = "C";
                                x.lItens.ForEach(y => y.st_registro = "C");
                            });
                            //Imprimir cancelamentos dos produtos que tenham portas configuradas
                            (bsCartao.Current as TRegistro_Cartao).lPreVenda.ForEach(x => IMP_Cartao.Impressao_PEDIDOS(x, bsCartao.Current as TRegistro_Cartao, true));
                            afterbusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ExcluiCupom(CamadaDados.Faturamento.PDV.TRegistro_NFCe val)
        {
            if (val != null)
            {
                if (val.St_registro.Trim().ToUpper().Equals("C") &&
                    (!val.Id_contingencia.HasValue ||
                    (val.Id_contingencia.HasValue &&
                        val.St_transmitidocancnfce)))
                {
                    MessageBox.Show("NFCe ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (val.Id_contingencia.HasValue &&
                    !val.Nr_protocolo.HasValue)
                {
                    MessageBox.Show("Não é permitido CANCELAR NFC-e emitida em CONTINGÊNCIA OFFLINE sem antes transmitir a mesma para receita.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento NFCe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Verificar se NFCe não esta vinculada a NFe
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_ECFVinculadoNF().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = val.Id_nfcestr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and isnull(x.st_registro, 'A') <> 'C')"
                                }
                            }, "1") != null)
                        {
                            MessageBox.Show("Para cancelar NFCe vinculada a NFe, obrigatório antes cancelar a NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //aq
                        bool st_cancelar = true;
                        if (val.Nr_protocolo.HasValue ||
                            val.Id_contingencia.HasValue)
                        {
                            string motivo = string.Empty;
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg = null;
                            CamadaDados.Faturamento.Cadastros.TList_Evento lEv = null;
                            //Verificar evento
                            CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(val.Cd_empresa,
                                                                                    val.Id_nfcestr,
                                                                                    string.Empty,
                                                                                    null);
                            if (lEvento.Count.Equals(0))
                            {
                                if (string.IsNullOrEmpty(motivo))
                                {
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Motivo Cancelamento NFCe";
                                    motivo = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(motivo))
                                    {
                                        MessageBox.Show("Obrigatorio informar motivo de cancelamento da NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (motivo.Trim().Length < 15)
                                    {
                                        MessageBox.Show("Motivo de cancelamento deve ter mais que 15 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                //Buscar evento Cancelamento
                                if (lEv == null)
                                    lEv = CamadaNegocio.Faturamento.Cadastros.TCN_Evento.Buscar(string.Empty, string.Empty, "CA", null);
                                if (lEv.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe evento de CANCELAMENTO NFE cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Cancelar NFe Receita
                                CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe rEvento = new CamadaDados.Faturamento.PDV.TRegistro_EventoNFCe();
                                rEvento.Cd_empresa = val.Cd_empresa;
                                rEvento.Id_cupom = val.Id_nfce;
                                rEvento.Chave_acesso_nfce = val.Chave_acesso;
                                rEvento.Nr_protocoloNFCe = val.Nr_protocolo;
                                rEvento.Dt_evento = CamadaDados.UtilData.Data_Servidor();
                                rEvento.Justificativa = motivo;
                                rEvento.Cd_eventostr = lEv[0].Cd_eventostr;
                                rEvento.Tp_evento = lEv[0].Tp_evento;
                                rEvento.Ds_evento = lEv[0].Ds_evento;
                                rEvento.St_registro = "A";
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Gravar(rEvento, null);
                                lEvento.Add(rEvento);
                            }
                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T") &&
                                val.Nr_protocolo.HasValue)
                            {
                                //Buscar CfgNfe para a empresa
                                if (lCfg == null)
                                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(val.Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                                if (lCfg.Count.Equals(0))
                                    MessageBox.Show("Não existe configuração para envio de evento para a empresa " + val.Cd_empresa.Trim() + ".",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    string ret = NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lCfg[0]);
                                    if (!string.IsNullOrEmpty(ret))
                                    {
                                        MessageBox.Show("Erro ao enviar evento CANCELAMENTO para a receita.\r\n" +
                                                        "Aguarde um tempo e tente novamente.\r\n" +
                                                        "Erro: " + ret.Trim() + ".",
                                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        st_cancelar = false;
                                    }
                                }
                            }
                        }
                        if (st_cancelar)
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_NFCe.CancelarCF(val, null);
                            MessageBox.Show("NFCe cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!val.Nr_protocolo.HasValue &&
                                !val.Id_contingencia.HasValue)
                            {
                                CamadaDados.Faturamento.Cadastros.TList_CadSequenciaNF lSeq =
                                    CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Busca(val.Nr_serie,
                                                                                                    val.Cd_modelo,
                                                                                                    val.Cd_empresa,
                                                                                                    null);
                                if (lSeq.Count > 0)
                                    if (lSeq[0].Seq_NotaFiscal.Equals(val.NR_NFCe))
                                    {
                                        lSeq[0].Seq_NotaFiscal--;
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CadSequenciaNF.Gravar(lSeq[0], null);
                                        MessageBox.Show("Sequencia de numeração da serie voltada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Buscar configuracao nfe
                                        CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(val.Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    null);
                                        if (lCfgNfe.Count > 0)
                                        {
                                            try
                                            {
                                                //Inutilizar numero nota
                                                NFCe.InutilizaNFCe.TInutilizaNFCe.InutilizarNFCe(lCfgNfe[0].Cd_uf_empresa,
                                                                                                    lCfgNfe[0].Cnpj_empresa,
                                                                                                    val.Nr_serie,
                                                                                                    val.Cd_modelo,
                                                                                                    DateTime.Now.Year.ToString(),
                                                                                                    val.NR_NFCe.Value,
                                                                                                    val.NR_NFCe.Value,
                                                                                                    "NUMERO INUTILIZADO DEVIDO A ERRO NA EMISSAO DA NFCe",
                                                                                                    lCfgNfe[0]);
                                                MessageBox.Show("Numero INUTILIZADO com sucesso na receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ExcluirVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            if (MessageBox.Show("Confirma cancelamento venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    //Verificar se venda possui pontos resgatados
                    if (val.PontosFidRes > decimal.Zero)
                    {
                        string loginCanc = string.Empty;
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                loginCanc = fRegra.Login;
                            else
                            {
                                MessageBox.Show("Obrigatório informar LOGIN com permissão para CANCELAR venda com pontos resgatados.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        val.LoginCancPontos = loginCanc;
                    }
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(new List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida> { val }, null);
                    MessageBox.Show("Venda rapida excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void fechacartao()
        {
            //preenche objeto
            CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
            rVenda.st_restaurante = true;
            (bsPreVenda.Current as TRegistro_PreVenda).lItens.ForEach(p =>
            {
                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item item = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item();
                item.Cd_produto = p.cd_produto;
                item.Quantidade = p.quantidade;
                item.Vl_desconto = p.vl_desconto;
                item.Vl_unitario = p.vl_unitario;
                item.Vl_subtotal = p.vl_subtotal;
                item.Cd_local = lcfg[0].cd_local;
                item.id_item = Convert.ToDecimal(p.id_item);
                item.id_prevenda = Convert.ToDecimal(p.id_prevenda);
                item.Cd_condfiscal_produto = p.cd_condfiscal_produto;
                rVenda.lItem.Add(item);
            });
            rVenda.rCliente = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = (bsCartao.Current as TRegistro_Cartao).Cd_Clifor
                    }
                }, 1, string.Empty)[0];
            rVenda.rEndCli = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = lcfg[0].Cd_Clifor
                    }
                }, 1, string.Empty)[0];
            rVenda.Cd_clifor = rVenda.rCliente.Cd_clifor;
            rVenda.Cd_empresa = lcfg[0].cd_empresa;
            rVenda.Nm_clifor = rVenda.rCliente.Nm_clifor;
            rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
            rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
            // rVenda.nr
            object cd_end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = rVenda.Cd_clifor
                    }
                }, "a.cd_endereco");
            rVenda.Cd_endereco = cd_end != null ? cd_end.ToString() : string.Empty;


            //Verificar se cliente possui adiantamento 
            lAdiant = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rVenda.Cd_clifor.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_movimento",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.vl_receber - a.vl_pagar",
                                                    vOperador = ">",
                                                    vVL_Busca = "0"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_adto, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                }
                                            }, 0, string.Empty);

            CamadaDados.Financeiro.Cadastros.TList_CadPortador lDevolCred = new CamadaDados.Financeiro.Cadastros.TList_CadPortador();
            if (lAdiant.Count > 0)
            {
                //Buscar portador Dev Credito
                lDevolCred =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_cartaocredito",
                                vOperador = "=",
                                vVL_Busca = "1"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                                vOperador = "<>",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty, string.Empty);
                if (lDevolCred.Count > decimal.Zero)
                {
                    decimal tot_devolver = rVenda.Vl_devcred <
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido) ?
                        rVenda.Vl_devcred :
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                    List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lDev = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
                    foreach (CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rSaldo in lAdiant)
                    {
                        if (tot_devolver > decimal.Zero)
                        {
                            rSaldo.Vl_processar = rSaldo.Vl_total_devolver > tot_devolver ? tot_devolver : rSaldo.Vl_total_devolver;
                            lDev.Add(rSaldo);
                            tot_devolver -= rSaldo.Vl_processar;
                        }
                        else break;
                    }
                    //Lancar Devolução Credito
                    lDevolCred[0].lCred = lDev;
                    lDevolCred[0].Vl_pagtoPDV = rVenda.lItem.Sum(p => p.Vl_subtotalliquido) >
                                                lDev.Sum(v => v.Vl_processar) ? lDev.Sum(v => v.Vl_processar) :
                                                rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                    rVenda.lPortador = lDevolCred;
                    decimal tot_venda =
                        rVenda.lItem.Sum(p => p.Vl_subtotalliquido) - lDev.Sum(v => v.Vl_processar);
                    if (tot_venda <= decimal.Zero)
                    {
                        ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                        try
                        {

                            FecharVenda(rVenda, tEsperaDev);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        finally
                        {
                            tEsperaDev.Fechar();
                            tEsperaDev = null;
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não existe portador DEVOLUÇÃO DE CREDITO configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            using (PDV.TFFecharVendaPDV fFechar = new PDV.TFFecharVendaPDV())
            {
                fFechar.rCupom = rVenda;
                fFechar.pCd_empresa = rVenda.Cd_empresa;
                fFechar.pCd_clifor = rVenda.Cd_clifor;
                fFechar.pNm_clifor = rVenda.Nm_clifor;
                fFechar.rCfg = lCfg[0];
                if (fFechar.ShowDialog() == DialogResult.OK)

                    if (fFechar.lPortador != null)
                    {
                        rVenda.Cd_clifor = fFechar.pCd_clifor;
                        rVenda.Nm_clifor = fFechar.pNm_clifor;
                        rVenda.lPortador = fFechar.lPortador;
                        if (lDevolCred.Count > 0)
                            rVenda.lPortador.Add(lDevolCred[0]);
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                        return;
                    }
                else
                {
                    MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                    return;
                }
            }
            try
            {
                lbltroco.Text = rVenda.lPortador.Sum(p => p.Vl_trocoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                lblvalorpago.Text = rVenda.lPortador.Sum(p => p.Vl_pagtoPDV).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                FecharVenda(rVenda, null);
                //verifica para fechar cartao 
                if ((bsCartao.Current != null && bsPreVenda.Current != null))
                {
                    bool fa = true;
                    TList_PreVenda_Item itemcup = TCN_PreVenda_Item.Buscar((bsCartao.Current as TRegistro_Cartao).Cd_empresa,
                        (bsPreVenda.Current as TRegistro_PreVenda).id_prevenda.ToString(), string.Empty, string.Empty, null);
                    itemcup.ForEach(p =>
                    {
                        if (p.qtd_faturar > decimal.Zero)
                            fa = false;
                    });
                    if (!fa)
                    {
                        MessageBox.Show("Existe item sem cupom");

                        return;
                    }
                    else
                    {
                        (bsCartao.Current as TRegistro_Cartao).St_registro = "F";
                        TCN_Cartao.Gravar((bsCartao.Current as TRegistro_Cartao), null);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //valida para fechar cartaoint  
            int i = 0;
            bool limpa = false;

            limpa = true;
            if (limpa)
            {
                nr_cartao.Text = string.Empty;
                bsPreVenda.Clear();
                bsCartao.Clear();
            }
        }

        private void FecharVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda, ThreadEspera tEspera)
        {

            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda,
                                                                            null,
                                                                            null,
                                                                            null);
            //Busca cupom gravado
            CamadaDados.Faturamento.PDV.TList_VendaRapida lCupom =
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
                                                                             rVenda.Cd_empresa,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             decimal.Zero,
                                                                             decimal.Zero,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             0,
                                                                             null);
            lCupom.ForEach(p => p.lItem = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                                                                    p.Cd_empresa,
                                                                                                    false,
                                                                                                    string.Empty,
                                                                                                    null));

            bsCartao.ResetCurrentItem();

            lCupom[0].lPortador = rVenda.lPortador;

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
             new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, 1, string.Empty);


            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCredito =
                new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                    "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                    }
                }, 0, string.Empty);
            //Imprimir comprovante de credito
            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
            {

                if (lCredito.Count > 0)
                {
                    FileInfo f = null;
                    StreamWriter w = null;
                    f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Credito.txt");
                    w = f.CreateText();
                    try
                    {
                        w.WriteLine(" =========================================");
                        w.WriteLine("            COMPROVANTE CREDITO           ");
                        w.WriteLine(" =========================================");
                        w.WriteLine("NR. Venda Origem: ".FormatStringDireita(32, ' ') + lCupom[0].Id_vendarapidastr.FormatStringEsquerda(10, '0'));
                        lCredito.ForEach(p =>
                        {
                            w.WriteLine("NR. Credito: ".FormatStringDireita(32, ' ') + p.Id_adto.ToString().FormatStringEsquerda(10, '0'));
                            w.WriteLine("Data: ".FormatStringDireita(32, ' ') + p.Dt_lanctostring);
                            w.WriteLine("Valor: ".FormatStringEsquerda(32, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            //Imprimir observacao cupom
                            if (!string.IsNullOrEmpty(p.Ds_adto))
                            {
                                string obs = p.Ds_adto.Trim();
                                w.WriteLine("Observacoes".FormatStringDireita(42, '-'));
                                while (true)
                                {
                                    if (obs.Length <= 40)
                                    {
                                        w.WriteLine("  " + obs);
                                        break;
                                    }
                                    else
                                    {
                                        w.WriteLine("  " + obs.Substring(0, 40));
                                        obs = obs.Remove(0, 40);
                                    }
                                }
                            }
                            w.WriteLine();
                        });
                        w.Write(Convert.ToChar(12));
                        w.Write(Convert.ToChar(27));
                        w.Write(Convert.ToChar(109));
                        w.Flush();
                        f.CopyTo(lTerminal[0].Porta_imptick);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão comprovante credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                }
            }
            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
            {
                if (lCredito.Count > 0)
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.NM_Classe = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    BindingSource BinCredito = new BindingSource();
                    BinCredito.DataSource = lCredito;
                    Relatorio.Adiciona_DataSource("CREDITO", BinCredito);

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lCupom[0];
                    Relatorio.DTS_Relatorio = meu_bind;


                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "Comprovante de Crédito";
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(string.Empty,
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        "Comprovante de Crédito",
                                                        fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }
                }
            }
            if (lCupom[0].lPortador.Exists(p => p.lDup.Count > 0))
            {
                //Imprimir Boleto
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                        }
                    }, 0, string.Empty);
                if (lBloqueto.Count > 0)
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                        fImp.pMensagem = "BOLETO(S) VENDA RAPIDA Nº" + lCupom[0].Id_vendarapidastr;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                              lBloqueto,
                                                                              fImp.pSt_imprimir,
                                                                              fImp.pSt_visualizar,
                                                                              fImp.pSt_enviaremail,
                                                                              fImp.pSt_exportPdf,
                                                                              fImp.Path_exportPdf,
                                                                              fImp.pDestinatarios,
                                                                              "BOLETO(S) VENDA RAPIDA Nº " + lCupom[0].Id_vendarapidastr,
                                                                              fImp.pDs_mensagem,
                                                                              false);
                    }
                else
                {
                    //Se gerou duplicata imprimir confissão divida
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                            "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                            }
                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                    if (lParc.Count > 0)
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource bs = new BindingSource();
                        bs.DataSource = new CamadaDados.Faturamento.PDV.TList_VendaRapida() { lCupom[0] };
                        Rel.DTS_Relatorio = bs;
                        //DTS Cupom
                        BindingSource dts = new BindingSource();
                        dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(lCupom[0].Id_vendarapidastr,
                                                                                                   lCupom[0].Cd_empresa,
                                                                                                   false,
                                                                                                   string.Empty,
                                                                                                   null);
                        Rel.Adiciona_DataSource("DTS_ITENS", dts);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        //Buscar Cliente Cupom 
                        if (string.IsNullOrEmpty(lCupom[0].Cd_clifor))
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(lCupom[0].Cd_clifor, null);
                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                        }
                        else
                        {
                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", lCupom[0].Nm_clifor);
                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", lCupom[0].Nr_cgccpf);
                        }
                        if (string.IsNullOrEmpty(lCupom[0].Ds_endereco))
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lCupom[0].Cd_clifor,
                                                                                      lCupom[0].Cd_endereco,
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
                                                                                      1,
                                                                                      null);
                            Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                        }
                        else Rel.Parametros_Relatorio.Add("ENDERECO", lCupom[0].Ds_endereco.Trim());
                        //Buscar Valor Pago
                        decimal vl_pago = decimal.Zero;
                        List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPag = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                        new TpBusca[]
                                                                                        {
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = "a.cd_empresa",
                                                                                                vOperador = "=",
                                                                                                vVL_Busca = "'" + lCupom[0].Cd_empresa.Trim() + "'"
                                                                                            },
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = "a.id_cupom",
                                                                                                vOperador = "=",
                                                                                                vVL_Busca = lCupom[0].Id_vendarapidastr
                                                                                            }
                                                                                        }, string.Empty);
                        if (lPag.Count > 0)
                            vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                        vl_pago += lParc.Sum(p => p.Vl_liquidado);
                        Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                        Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                        BindingSource bsParc = new BindingSource();
                        bsParc.DataSource = lParc;
                        Rel.Adiciona_DataSource("PARC", bsParc);
                        Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_PDV";
                        Rel.NM_Classe = "TFVendaPDV";
                        Rel.Modulo = "FAT";
                        Rel.Ident = "CONFISSAO_DIVIDA_PDV";
                        //Verificar se existe Impressora padrão para o PDV
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                     new TpBusca[]
                                     {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                     }, "a.impressorapadrao");
                        string print = obj == null ? string.Empty : obj.ToString();
                        if (string.IsNullOrEmpty(print))
                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                            {
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                        print = fLista.Impressora;

                            }
                        //Imprimir
                        Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                    }
                }
            }

            using (PostoCombustivel.TFGerarDocFiscal fDoc = new PostoCombustivel.TFGerarDocFiscal())
            {
                if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                {
                    try
                    {
                        //Processar cupom fiscal
                        PDV.TDadosCupom dados = new PDV.TDadosCupom();
                        dados.lItens = rVenda.lItem;
                        dados.rSessao = lSessao[0];
                        dados.Cd_clifor = rVenda.Cd_clifor;
                        dados.Nm_clifor = rVenda.Nm_clifor;
                        dados.Cd_endereco = rVenda.Cd_endereco;
                        //Buscar CNPJ/CPF
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_clifor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + dados.Cd_clifor.Trim() + "'"
                                                }
                                    }, "isnull(a.nr_cgc, a.nr_cpf)");
                        if (obj != null)
                            dados.CpfCgc = obj.ToString();
                        dados.Mensagem = string.Empty;
                        dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                        dados.St_vendacombustivel = false;
                        dados.St_cupomavulso = true;
                        dados.St_agruparProduto = false;


                        PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                        CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true);
                        if (rNFCe != null)
                            if (!rNFCe.St_contingencia)
                            {
                                using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                {
                                    rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                              rNFCe.Id_nfcestr,
                                                                                              null);
                                    fGerNfe.rNFCe = rNFCe;
                                    fGerNfe.ShowDialog();
                                }
                                if (dados.St_faturardireto)
                                    if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_cupom",
                                                        vOperador = "=",
                                                        vVL_Busca = rNFCe.Id_nfcestr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.status",
                                                        vOperador = "=",
                                                        vVL_Busca = "'100'"
                                                    }
                                            }, "1") != null)
                                            ProcessarCFVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                }
                                else
                                {
                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                    Rel.Altera_Relatorio = Altera_Relatorio;
                                    BindingSource dts = new BindingSource();
                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                    Rel.DTS_Relatorio = dts;// bsItens;
                                                            //DTS Cupom
                                    BindingSource bsNFCe = new BindingSource();
                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                      string.Empty,
                                                                                                      rNFCe.Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      1,
                                                                                                      null);
                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                    //Buscar Empresa
                                    BindingSource bsEmpresa = new BindingSource();
                                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        null);
                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                    //Forma Pagamento
                                    BindingSource bsPagto = new BindingSource();
                                    List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>();
                                    new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                        {

                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                }
                                    }, string.Empty).GroupBy(v => v.Tp_portador,
                                                        (aux, venda) =>
                                                            new
                                                            {
                                                                tp_portador = aux,
                                                                Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                            }).ToList().ForEach(x => lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                            {
                                                                Tp_portador = x.tp_portador,
                                                                Vl_recebido = x.Vl_recebido,
                                                                Vl_troco_ch = x.Vl_troco_ch,
                                                                Vl_troco_dh = x.Vl_troco_dh
                                                            }));
                                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                        new TpBusca[]
                                        {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                    "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                    "on x.cd_empresa = y.cd_empresa " +
                                                                    "and x.id_cupom = y.id_vendarapida " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                    "and y.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                                                    "and y.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                                                    }
                                        }, 1, string.Empty);
                                if (lDup.Count > 0)
                                    lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                    {
                                        Tp_portador = "05",
                                        Vl_recebido = lDup[0].Vl_documento
                                    });
                                bsPagto.DataSource = lPagto;
                                Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                //Parametros
                                Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.id_lote = a.id_lote " +
                                                                            "and x.status = '100')"
                                                            }
                                                }, "a.tp_ambiente");
                                Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(rVenda.Cd_empresa,
                                                                                                             rVenda.Id_vendarapidastr,
                                                                                                             null);
                                if (!string.IsNullOrEmpty(dadoscf))
                                {
                                    string[] linhas = dadoscf.Split(new char[] { ':' });
                                    string placa = string.Empty;
                                    string km = string.Empty;
                                    string frota = string.Empty;
                                    string requisicao = string.Empty;
                                    string nm_motorista = string.Empty;
                                    string cpf_motorista = string.Empty;
                                    string media = string.Empty;
                                    string virg = string.Empty;
                                    foreach (string s in linhas)
                                    {
                                        string[] colunas = s.Split(new char[] { '/' });
                                        placa += virg + colunas[0];
                                        km += virg + colunas[1];
                                        frota += virg + colunas[2];
                                        requisicao += virg + colunas[3];
                                        nm_motorista += virg + colunas[4];
                                        cpf_motorista += virg + colunas[5];
                                        media += virg + colunas[6];
                                        virg = ",";
                                    }
                                    if (!string.IsNullOrEmpty(placa))
                                        Rel.Parametros_Relatorio.Add("PLACA", placa);
                                    if (!string.IsNullOrEmpty(km))
                                        Rel.Parametros_Relatorio.Add("KM", km);
                                    if (!string.IsNullOrEmpty(media))
                                        Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                    if (!string.IsNullOrEmpty(frota))
                                        Rel.Parametros_Relatorio.Add("FROTA", frota);
                                    if (!string.IsNullOrEmpty(requisicao))
                                        Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                    if (!string.IsNullOrEmpty(nm_motorista))
                                        Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                    if (!string.IsNullOrEmpty(cpf_motorista))
                                        Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                }
                                Rel.Nome_Relatorio = "DANFE_NFCE";
                                Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                Rel.Modulo = "FAT";
                                Rel.Ident = "DANFE_NFCE";
                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                {
                                    BindingSource bsItens = new BindingSource();
                                    bsItens.DataSource =
                                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rVenda.Id_vendarapidastr,
                                                                                                  rVenda.Cd_empresa,
                                                                                                  false,
                                                                                                  string.Empty,
                                                                                                  null);
                                    Rel.DTS_Relatorio = bsItens;
                                }
                                if (rNFCe.Id_contingencia.HasValue)
                                    if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                        Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                    else
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                //Verificar se existe Impressora padrão para o PDV
                                obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                        }, "a.impressorapadrao");
                                string print = obj == null ? string.Empty : obj.ToString();
                                if (string.IsNullOrEmpty(print))
                                    using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                    {
                                        if (fLista.ShowDialog() == DialogResult.OK)
                                            if (!string.IsNullOrEmpty(fLista.Impressora))
                                                print = fLista.Impressora;

                                    }
                                //Imprimir
                                if (!string.IsNullOrEmpty(print))
                                {
                                    Rel.ImprimiGraficoReduzida(print,
                                                               true,
                                                               false,
                                                               null,
                                                               string.Empty,
                                                               string.Empty,
                                                               1);
                                    if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                        (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                }
                            }
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                    MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (fDoc.DialogResult == DialogResult.Cancel)
                {
                    try
                    {
                        if (lCupom.Count > 0)
                        {
                            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                                return;
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                            {
                                if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                    throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirReduzido(lCupom[0], lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                                ImprimirGraficoReduzido(lCupom[0]);
                            else
                                ImprimirGrafico(lCupom[0]);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ImprimirGrafico(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                                                                                                   1,
                                                                                                   null);
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_clifor;
                    fImp.pMensagem = "ORÇAMENTO Nº " + val.Id_vendarapidastr;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(val.Id_vendarapidastr,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "ORÇAMENTO Nº " + val.Id_vendarapidastr,
                                                fImp.pDs_mensagem);
                }
            }
            else
            {
                Relatorio.Gera_Relatorio();
                Altera_Relatorio = false;
            }
        }
        private void ImprimirGraficoReduzido(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     1,
                                                                                                     null);
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                                                                                                   1,
                                                                                                   null);
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            if (!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
                                                 1);
            Altera_Relatorio = false;
        }

        private void ProcessarCFVincular(List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lCupom,
                                        string pCd_empresa,
                                        string pCd_cliente)
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(lCupom,
                                                                                pCd_empresa,
                                                                                pCd_cliente);
                //Gravar Pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                //Se o CMI do pedido gerar financeiro
                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                lCupom.ForEach(p =>
                {
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "in",
                                vVL_Busca = "('A', 'P')"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                            "inner join tb_pdv_cupom_x_movcaixa y " +
                                            "on x.cd_empresa = y.cd_empresa " +
                                            "and x.id_cupom = y.id_vendarapida " +
                                            "and x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and y.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                            "and y.id_cupom = " + p.Id_nfcestr + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                });
                //Gerar Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                //Vincular Cupom a Nota Fiscal
                string Obs = string.Empty;
                string virg = string.Empty;
                lCupom.ForEach(p =>
                {
                    rFat.lCupom.Add(p);
                    Obs += virg + p.NR_NFCestr.Trim() + "/" + p.Placa.Trim();
                    virg = ",";
                });
                //Vincular financeiro a Nota Fiscal
                rFat.lParcAgrupar = lParcVinculado;
                if (!string.IsNullOrEmpty(Obs))
                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. Cupom Fiscal/Placa " + Obs.Trim();
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                if (MessageBox.Show("NFe gravada com sucesso. Deseja enviar a mesma para a receita?",
                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                    {
                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                        rFat.Nr_lanctofiscalstr,
                                                                                                        null);
                        fGerNfe.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            GerarNFCe();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (Cadastro.TFCliforDetalhado s = new Cadastro.TFCliforDetalhado())
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar(s.rClifor, null);
                    MessageBox.Show("Cliente gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_PreVenda_Item).lSabores =
                    TCN_SaboresItens.Buscar(
                         (bsItens.Current as TRegistro_PreVenda_Item).Cd_empresa,
                          (bsItens.Current as TRegistro_PreVenda_Item).id_prevenda.ToString(),
                           (bsItens.Current as TRegistro_PreVenda_Item).id_item.ToString(),
                           string.Empty, null);
                bsSabores.ResetCurrentItem();
                bsItens.ResetCurrentItem();
            }
        }

        private void dataGridDefault1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridDefault1.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCartao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Cartao());
            TList_Cartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((dataGridDefault1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (dataGridDefault1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Cartao(lP.Find(dataGridDefault1.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in dataGridDefault1.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Cartao(lP.Find(dataGridDefault1.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in dataGridDefault1.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCartao.List as TList_Cartao).Sort(lComparer);
            bsCartao.ResetBindings(false);
            dataGridDefault1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_local|Local|150;a.id_local|Código|50",
                new Componentes.EditDefault[] { id_local },
                new TCD_Local(),
                string.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_mesa|Mesa|150;a.id_mesa|Código|50",
                new Componentes.EditDefault[] { id_mesa },
                new TCD_Mesa(),
                "a.id_local|=|'" + id_local.Text.Trim() + "'");
        }
    }
}
