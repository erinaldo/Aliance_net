using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using Utils;

namespace Faturamento
{
    public partial class TFDevolverNF : Form
    {
        public TRegistro_LanFaturamento rNf
        { get; set; }
        public TFDevolverNF()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {

        }

        private void TFDevolverNF_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsNotaFiscal.DataSource = new TList_RegLanFaturamento() { rNf };
            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota =
                            TCN_LanFaturamento_Item.Busca((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                          string.Empty,
                                                          null);
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {

        }

        private void gItensNota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar =
                    !(bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar;
                //Informar quantidade a devolver
                if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar)
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        if (fQtd.ShowDialog() == DialogResult.OK)
                        {
                            fQtd.Vl_default = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade;
                            fQtd.Ds_label = "QTD.Devolver";
                            if (fQtd.Quantidade > 0)
                            {
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade =
                                    fQtd.Quantidade;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Quantidade a Devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Quantidade a Devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                            return;
                        }

                   }
                if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar)
                {
                    string vObsFiscal = string.Empty;
                    TList_ImpostosNF lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor,
                                                                                         (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                          ref vObsFiscal,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                          null);
                    if (lImpostos.Count > 0)
                    {
                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens.Concat(lImpostos);
                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                    }
                    else
                    {
                        //Verificar se existe imposto icms configurado para o item
                        if (TCN_LanFaturamento_Item.ObrigImformarICMS((bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto, (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie, null))
                        {
                            CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondFiscalICMS");
                            if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                            {
                                //Buscar codigo imposto ICMS
                                object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.st_icms",
                                                vOperador = "=",
                                                vVL_Busca = "0"
                                            }
                                                }, "a.cd_imposto");
                                //Abrir cadastro de configuracao icms
                                using (Fiscal.Cadastros.TFCondFiscalICMS fCondICMS = new Fiscal.Cadastros.TFCondFiscalICMS())
                                {
                                    fCondICMS.pCd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                    fCondICMS.pCd_condfiscal_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                                    fCondICMS.pCd_condfiscal_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                                    fCondICMS.pCd_movto = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring;
                                    fCondICMS.pCd_UfDest = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor;
                                    fCondICMS.pCd_UfOrig = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa;
                                    fCondICMS.pTp_movimento = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().ToUpper();
                                    fCondICMS.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                                    if (fCondICMS.ShowDialog() == DialogResult.OK)
                                        if ((fCondICMS.rCond != null) &&
                                            (fCondICMS.lMov != null) &&
                                            (fCondICMS.lUfOrigem != null) &&
                                            (fCondICMS.lUfDestino != null))
                                            try
                                            {
                                                CamadaNegocio.Fiscal.TCN_CadCondFiscalICMS.Gravar(fCondICMS.rCond,
                                                                                                  fCondICMS.lMov,
                                                                                                  fCondICMS.lUfOrigem,
                                                                                                  fCondICMS.lUfDestino,
                                                                                                  null);
                                            }
                                            catch { }
                                    vObsFiscal = string.Empty;
                                    lImpostos = TCN_LanFaturamento_Item.procuraImpostosPorUf((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                              (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                              (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                              (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                              ref vObsFiscal,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                              (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                              (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                              null);
                                    if (lImpostos.Count > 0)
                                    {
                                        (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens.Concat(lImpostos);
                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal += string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Obsfiscal) ? vObsFiscal.Trim() : "\r\n" + vObsFiscal.Trim();
                                    }
                                    bsNotaFiscal.ResetCurrentItem();
                                    bsItensNota.ResetCurrentItem();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não existe condição fiscal para: \r\n" +
                                                "Tipo Movimento: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tipo_movimento.Trim() + "\r\n" +
                                                "Movimentação Comercial: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring.Trim() + " - " +
                                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Ds_movimentacao.Trim() + "\r\n" +
                                                "Condição Fiscal Clifor: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor.Trim() + "\r\n" +
                                                "Condição Fiscal Produto: " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto.Trim() + "\r\n" +
                                                "UF Origem: " + ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa) + "\r\n" +
                                                "UF Destino: " + ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.Trim().Equals("E") ? (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_empresa : (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_uf_clifor), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                                bsNotaFiscal.ResetCurrentItem();
                                bsItensNota.ResetCurrentItem();
                            }
                        }
                    }
            //Procurar impostos sobre os itens da nota fiscal de destino
            (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens.Concat(
                TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidade,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                      (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                      (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_municipioexecservico,
                                                                      null));
                    //Verificar obrigatoriedade PIS
                    if (TCN_LanFaturamento_Item.ObrigInformarPIS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens, null))
                    {
                        //Verificar se o usuario tem acesso a tela de configuracao do imposto
                        CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                        if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                        {
                            //Buscar codigo imposto PIS
                            object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_pis",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                            }, "a.cd_imposto");
                            //Abrir cadastro de configuracao icms
                            using (Fiscal.Cadastros.TFCondFiscalImposto fCondImposto = new Fiscal.Cadastros.TFCondFiscalImposto())
                            {
                                fCondImposto.pCd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                fCondImposto.pCd_condfiscal_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                                fCondImposto.pCd_condfiscal_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                                fCondImposto.pCd_movimentacao = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring;
                                fCondImposto.pTp_faturamento = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento;
                                fCondImposto.pSt_juridica = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("J");
                                fCondImposto.pSt_fisica = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("F");
                                fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                                if (fCondImposto.ShowDialog() == DialogResult.OK)
                                    if ((fCondImposto.rCond != null) &&
                                    (fCondImposto.lMov != null) &&
                                    (fCondImposto.lCondClifor != null) &&
                                    (fCondImposto.lCondProd != null))
                                        try
                                        {
                                            CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                             fCondImposto.lMov,
                                                                                                             fCondImposto.lCondClifor,
                                                                                                             fCondImposto.lCondProd,
                                                                                                             fCondImposto.pSt_fisica,
                                                                                                             fCondImposto.pSt_juridica,
                                                                                                             fCondImposto.pSt_estrangeiro,
                                                                                                             null);
                                        }
                                        catch { }
                                //Procurar impostos sobre os itens da nota fiscal de destino
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens.Concat(
                                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidade,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_basecalcImposto,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_municipioexecservico,
                                                                                          null));
                                bsNotaFiscal.ResetCurrentItem();
                                bsItensNota.ResetCurrentItem();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta configuração fiscal do imposto PIS para emitir NFE.\r\n" +
                                            "Imposto: PIS\r\n" +
                                            "Cond. Fiscal Clifor: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Cd. Movimentação: " + (string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring) ? decimal.Zero : Convert.ToDecimal((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring)) + "\r\n" +
                                            "TP. Pessoa: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                            "TP. Movimento: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.ToString().Trim().ToUpper() + "\r\n" +
                                            "Cd. Empresa: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "\r\n" +
                                            "Nº Serie: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim() + "\r\n\r\n" +
                                            "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                            "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                            bsNotaFiscal.ResetCurrentItem();
                            bsItensNota.ResetCurrentItem();
                        }
                    }
                    //Verificar obrigatoriedade COFINS
                    if (TCN_LanFaturamento_Item.ObrigInformarCOFINS((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                   (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"),
                                                                   (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_produto,
                                                                   (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens, null))
                    {
                        //Verificar se o usuario tem acesso a tela de configuracao do imposto
                        CamadaDados.Diversos.TRegistro_CadAcesso rAcesso = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Fiscal.Cadastros.TFCadCondicaoFiscal_Imposto");
                        if ((rAcesso != null) || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV"))
                        {
                            //Buscar codigo imposto PIS
                            object obj = new CamadaDados.Fiscal.TCD_CadImposto().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_cofins",
                                            vOperador = "=",
                                            vVL_Busca = "0"
                                        }
                                            }, "a.cd_imposto");
                            //Abrir cadastro de configuracao icms
                            using (Fiscal.Cadastros.TFCondFiscalImposto fCondImposto = new Fiscal.Cadastros.TFCondFiscalImposto())
                            {
                                fCondImposto.pCd_empresa = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa;
                                fCondImposto.pCd_condfiscal_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor;
                                fCondImposto.pCd_condfiscal_produto = (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto;
                                fCondImposto.pCd_movimentacao = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring;
                                fCondImposto.pTp_faturamento = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.ToString().Trim().ToUpper();
                                fCondImposto.pSt_juridica = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("J");
                                fCondImposto.pSt_fisica = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper().Equals("F");
                                fCondImposto.pCd_imposto = obj == null ? string.Empty : obj.ToString();
                                if (fCondImposto.ShowDialog() == DialogResult.OK)
                                    if ((fCondImposto.rCond != null) &&
                                    (fCondImposto.lMov != null) &&
                                    (fCondImposto.lCondClifor != null) &&
                                    (fCondImposto.lCondProd != null))
                                        try
                                        {
                                            CamadaNegocio.Fiscal.TCN_CondicaoFiscalImposto.gravarFiscImposto(fCondImposto.rCond,
                                                                                                             fCondImposto.lMov,
                                                                                                             fCondImposto.lCondClifor,
                                                                                                             fCondImposto.lCondProd,
                                                                                                             fCondImposto.pSt_fisica,
                                                                                                             fCondImposto.pSt_juridica,
                                                                                                             fCondImposto.pSt_estrangeiro,
                                                                                                             null);
                                        }
                                        catch { }
                                //Procurar impostos sobre os itens da nota fiscal de destino
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).ImpostosItens.Concat(
                                    TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_unidade,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Dt_emissao,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Quantidade,
                                                                                          (bsItensNota.Current as TRegistro_LanFaturamento_Item).Vl_subtotal,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota,
                                                                                          (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_municipioexecservico,
                                                                                          null));
                                bsNotaFiscal.ResetCurrentItem();
                                bsItensNota.ResetCurrentItem();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta configuração fiscal do imposto COFINS para emitir NFE.\r\n" +
                                            "Imposto: COFINS\r\n" +
                                            "Cond. Fiscal Clifor: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_condfiscal_clifor.Trim() + "\r\n" +
                                            "Cond. Fiscal Produto: " + (bsItensNota.Current as TRegistro_LanFaturamento_Item).Cd_condfiscal_produto.Trim() + "\r\n" +
                                            "Cd. Movimentação: " + (string.IsNullOrEmpty((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring) ? decimal.Zero : Convert.ToDecimal((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_movimentacaostring)) + "\r\n" +
                                            "TP. Pessoa: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_pessoa.Trim().ToUpper() + "\r\n" +
                                            "TP. Movimento: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_movimento.ToString().Trim().ToUpper() + "\r\n" +
                                            "Cd. Empresa: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "\r\n" +
                                            "Nº Serie: " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_serie.Trim() + "\r\n\r\n" +
                                            "Grave as configurações acima no cadastro de Parametro Geral de Impostos.\r\n" +
                                            "Possivel caminho: FISCAL->CADASTROS->PARAMETO GERAL DE IMPOSTOS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                            bsNotaFiscal.ResetCurrentItem();
                            bsItensNota.ResetCurrentItem();
                        }
                    }
                    bsItensNota.ResetCurrentItem();
                }
            }
        }
    }
}
