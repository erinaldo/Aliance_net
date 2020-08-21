using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Balanca;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Fazenda.Lancamento;
using System.Windows.Forms;

namespace CamadaNegocio.Balanca
{
    public class TCN_LanPesagemGraos
    {
        public static TList_RegLanPesagemGraos Busca(string vCD_Empresa,
                                                     string vID_Ticket,
                                                     string vPlacaCarreta,
                                                     string vNr_contrato,
                                                     string vCD_Produto,
                                                     string vCD_TabelaDesconto,
                                                     string vDT_Inicial,
                                                     string vDT_Final,
                                                     bool vTP_MovEntrada,
                                                     bool vTP_MovSaida,
                                                     bool vTP_PesagemAberta,
                                                     bool vTP_PesagemFechada,
                                                     bool vTP_Pesagemcancelada,
                                                     bool vTP_PesagemRefugada,
                                                     string vLogin,
                                                     string vCD_Local,
                                                     string vCd_contratante,
                                                     string vTP_Pesagem,
                                                     string vAnoSafra,
                                                     bool vST_SaldoAplicar,
                                                     bool vSt_saldoTransbordo,
                                                     bool vST_PesagemFazenda,
                                                     string vTp_transbordo,
                                                     int vTop,
                                                     string vNM_Campo,
                                                     TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vID_Ticket))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vPlacaCarreta))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.PlacaCarreta";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vPlacaCarreta + "%'";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vNr_contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNr_contrato;
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Produto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Produto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_TabelaDesconto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaDesconto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Local))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Local";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Local + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contratante))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contratante";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_contratante + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Pesagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vAnoSafra))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.anosafra";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vAnoSafra.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDT_Inicial)) && (vDT_Inicial.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_bruto)))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Inicial).ToString("yyyyMMdd")) + "'";
            }
            if ((!string.IsNullOrEmpty(vDT_Final)) && (vDT_Final.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_bruto)))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Final).ToString("yyyyMMdd")) + "'";
            }
            if ((vTP_MovEntrada)&&(!vTP_MovSaida))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'E'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if ((vTP_MovSaida)&&(!vTP_MovEntrada))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'S'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_PesagemAberta || vTP_Pesagemcancelada || vTP_PesagemFechada || vTP_PesagemRefugada)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + (vTP_PesagemAberta ? "'A'" : string.Empty) +
                                                      (vTP_Pesagemcancelada ? vTP_PesagemAberta ? ",'C'" : "'C'" : string.Empty) +
                                                      (vTP_PesagemFechada ? vTP_PesagemAberta || vTP_Pesagemcancelada ? ",'F'" : "'F'" : string.Empty) +
                                                      (vTP_PesagemRefugada ? vTP_PesagemAberta || vTP_Pesagemcancelada || vTP_PesagemFechada ? ",'R'" : "'R'" : string.Empty) + ")";
            }
            if (vST_SaldoAplicar)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ps_bruto, 0) - isnull(a.ps_tara, 0) - isnull(a.ps_desconto_pag, 0) - isnull(a.ps_desdobro, 0)";
                vBusca[vBusca.Length - 1].vVL_Busca = "a.ps_aplicado";
                vBusca[vBusca.Length - 1].vOperador = ">";
                
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "((not exists(select 1 from tb_bal_psFazenda ff " +
                                                      "where ff.cd_fazenda = a.cd_empresa " +
                                                      "and ff.id_ticket = a.id_ticket " +
                                                      "and ff.tp_pesagem = a.tp_pesagem)) " +
                                                      "or (a.tp_movimento = 'S'))";
                vBusca[vBusca.Length - 1].vOperador = string.Empty;
            }
            if (vST_PesagemFazenda)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_bal_psFazenda ff " +
                                                      "where ff.cd_fazenda = a.cd_empresa " +
                                                      "and ff.id_ticket = a.id_ticket " +
                                                      "and ff.tp_pesagem = a.tp_pesagem)";
            
            }
            if (vSt_saldoTransbordo)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "(a.ps_bruto - a.ps_tara - a.ps_desconto_pag - " +
                                                                        "(select isnull(sum(isnull(x.ps_transbordo, 0)), 0) from tb_bal_transbordo x " +
                                                                        "where " +
                                                                        "x.cd_empresaorig = a.cd_empresa " +
                                                                        "and x.id_ticketorig = a.id_ticket " +
                                                                        "and x.tp_pesagemorig = a.tp_pesagem)) > 0";
            }
            if (vTp_transbordo.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(d.tp_transbordo, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_transbordo.Trim() + "'";
            }

            return new TCD_LanPesagemGraos(banco).Select(vBusca, string.Empty, string.Empty, vTop, vNM_Campo);
        }
        
        public static TList_RegLanPesagemGraos Busca(string vCD_Empresa,
                                                     string vID_Ticket,
                                                     string vTP_Pesagem,
                                                     string vPlaca,
                                                     string vST_Registro,
                                                     string vCD_TabelaDesconto,                                         
                                                     string vLogin,
                                                     string vTP_Movimento,
                                                     decimal vNR_Pedido,
                                                     string Cd_amostra1,
                                                     string Cd_amostra2,
                                                     int vTop, 
                                                     string vNM_Campo, 
                                                     TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[1];
            vBusca[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            vBusca[0].vOperador = "<>";
            vBusca[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(vID_Ticket))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'"; 
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTP_Pesagem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vPlaca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.PlacaCarreta";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vPlaca.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vST_Registro + ")";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }
            if (!string.IsNullOrEmpty(vCD_TabelaDesconto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaDesconto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_Pedido > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";

                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 " +
                                                      "From TB_BAL_Aplicacao_Pedido ap " +
                                                      "Where ap.CD_Empresa = a.CD_Empresa " +
                                                      "and ap.ID_Ticket = a.ID_Ticket " +
                                                      "and ap.TP_Pesagem = a.TP_Pesagem " +
                                                      "and ap.nr_pedido = " + vNR_Pedido.ToString() + ")";
            }

            return new TCD_LanPesagemGraos(banco).Select(vBusca, Cd_amostra1, Cd_amostra2, 0, string.Empty);
        }
        
        public static void Gravar(TRegistro_LanPesagemGraos val, TObjetoBanco banco)
        {
            TCD_LanPesagemGraos qtb_psgraos = new TCD_LanPesagemGraos();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_psgraos.CriarBanco_Dados(true);
                else
                    qtb_psgraos.Banco_Dados = banco;
                //Gravar Pesagem
                if ((val.Ps_bruto > decimal.Zero) && 
                    (val.Ps_tara > decimal.Zero) && 
                    (!val.St_registro.Trim().ToUpper().Equals("R")))
                {
                    if (val.Tp_movimento.Trim().ToUpper().Equals("E") && (val.Dt_bruto.Value > val.Dt_tara.Value))
                        throw new Exception("Data Peso Bruto não pode ser maior que Data Peso Tara no Recebimento.");
                    if (val.Tp_movimento.Trim().ToUpper().Equals("S") && (val.Dt_tara.Value > val.Dt_bruto.Value))
                        throw new Exception("Data Peso Tara não pode ser maior que Data Peso Bruto na Expedição.");
                    if ((val.Qtd_embalagem > 0) && val.Ps_embalagem.Equals(0))
                        throw new Exception("Obrigatorio informar peso unitario da embalagem para fechar pesagem.");
                    if (TCN_LanClassificacao.produtoClassificavel(val.Cd_produto, val.Cd_tabeladesconto) && 
                        (string.IsNullOrEmpty(val.Tp_desdobro) || val.Tp_desdobro.Trim().ToUpper().Equals("B")))
                        if (val.Classificacao.Exists(p=> p.Pc_resultado_local > 0) ||
                            val.Tp_modo.Trim().ToUpper().Equals("F"))
                        {
                            if (val.Tp_modo.Trim().ToUpper().Equals("F") && 
                                val.Tp_movimento.Trim().ToUpper().Equals("E"))
                            {
                                val.St_registro = "F";
                                val.NM_Contratante = val.Nm_empresa;
                            }
                        }
                        else
                            throw new Exception("Obrigatorio Informar Classificacao.");
                    val.St_registro = "F";
                }
                if(val.Classificacao.Exists(p=> p.Pc_resultado_local > 0) &&
                    (string.IsNullOrEmpty(val.Tp_desdobro) || val.Tp_desdobro.Trim().ToUpper().Equals("B")))
                    //Verificar se a classificacao tem algum indice fora do intervalo aceitavel
                    val.Classificacao.ForEach(p=>
                    {
                        if(p.Menorque > decimal.Zero)
                            if (p.Pc_resultado_local >= p.Menorque)
                                if ((!Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", qtb_psgraos.Banco_Dados)) &&
                                    (!val.St_processarTicketRef))
                                    val.St_registro = "R";//Refugar pesagem
                        if (p.Maiorque > decimal.Zero)
                            if (p.Pc_resultado_local <= p.Maiorque)
                                if ((!Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CLASSIFICAR INDICE FORA INTERVALO", qtb_psgraos.Banco_Dados)) &&
                                    (!val.St_processarTicketRef))
                                    val.St_registro = "R";//Refugar pesagem
                    });
                if (val.Tp_modo.Trim().ToUpper().Equals("F") &&
                    val.Tp_movimento.Trim().ToUpper().Equals("E"))
                    val.NM_Contratante = val.Nm_empresa;
                //Gravar Pesagem de Graos
                val.Id_ticket = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_psgraos.Gravar(val), "@P_ID_TICKET"));
                //Gravar Classificação da Pesagem de Grãos
                val.Classificacao.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_ticket = val.Id_ticket.Value;
                        p.Tp_pesagem = val.Tp_pesagem;
                    });
                TCN_LanClassificacao.GravarClassificacao(val.Classificacao, qtb_psgraos.Banco_Dados);
                //Calcular descontos da classificacao e Realizar fechamento da pesagem
                if ((val.Ps_bruto > 0) && (val.Ps_tara > 0) &&
                    (val.St_registro.Trim().ToUpper() != "R"))
                {
                    //Devolver quantidade de embalagens
                    if ((val.rEstEmbalagem != null) &&
                        (val.NR_Contrato != null))
                        Graos.TCN_Contrato_X_EstoqueEmbalagem.DevolverEmbalagem(
                            new CamadaDados.Graos.TRegistro_CadContrato()
                            {
                                Nr_contrato = val.NR_Contrato
                            },
                            val.rEstEmbalagem,
                            qtb_psgraos.Banco_Dados);
                    if(string.IsNullOrEmpty(val.Tp_desdobro) || val.Tp_desdobro.Trim().ToUpper().Equals("B"))
                        val.Ps_desconto_pag = TCN_LanClassificacao.calcClassif(val.Cd_empresa, 
                                                                                val.Id_ticket.ToString(),
                                                                                val.Tp_pesagem, 
                                                                                qtb_psgraos.Banco_Dados);
                }
                //Excluir Desdobros
                val.lDesdobroDel.ForEach(p => TCN_ItensDesdobro.Excluir(p, qtb_psgraos.Banco_Dados));
                //Gravar Desdobros
                val.lDesdobro.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_ticket = val.Id_ticket;
                    p.Tp_pesagem = val.Tp_pesagem;
                    TCN_ItensDesdobro.Gravar(p, qtb_psgraos.Banco_Dados);
                });
                //SE CASO FOR PESAGEM DE FAZENDA GRAVA O LANÇAMENTO NO PESFAZENDA
                if (val.Tp_modo.Trim().ToUpper().Equals("F"))
                {
                    if (val.Tp_movimento.Trim().ToUpper().Equals("E") &&
                    (val.Ps_bruto > decimal.Zero) &&
                    (val.Ps_tara > decimal.Zero))
                    {
                        //LANÇA O ESTOQUE
                        TRegistro_LanEstoque reg_estoque = new TRegistro_LanEstoque();
                        reg_estoque.Cd_empresa = val.Cd_empresa;
                        reg_estoque.Cd_produto = val.Cd_produto;
                        reg_estoque.Cd_local = val.Cd_local;
                        reg_estoque.Qtd_entrada = ((val.Ps_bruto - val.Ps_tara) - val.Ps_desconto_pag);
                        reg_estoque.Qtd_saida = decimal.Zero;
                        reg_estoque.St_registro = "A";
                        reg_estoque.Vl_unitario = val.Vl_unitario;
                        reg_estoque.Vl_subtotal = (val.Ps_bruto - val.Ps_tara - val.Ps_desconto_pag) * val.Vl_unitario;
                        reg_estoque.Tp_movimento = "E";
                        reg_estoque.Ds_observacao = val.Ds_observacao;
                        reg_estoque.Tp_lancto = "N";

                        TCN_LanEstoque.GravarEstoque(reg_estoque, qtb_psgraos.Banco_Dados);
                        val.Id_lanctoestoque = reg_estoque.Id_lanctoestoque;
                    }
                    //Gravar Pesagem Fazenda
                    qtb_psgraos.GravaPesagemFazenda(val);
                }
                //Gravar Fotos Pesagem
                val.lFotosPesagem.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_ticket = val.Id_ticket;
                        p.Tp_pesagem = val.Tp_pesagem;
                        TCN_FotosPesagem.Gravar(p, qtb_psgraos.Banco_Dados);
                    });
                //Excluir Fotos Pesagem
                val.lFotosPesagemExcluir.ForEach(p => TCN_FotosPesagem.Excluir(p, qtb_psgraos.Banco_Dados));
                //Fechar pesagem
                if ((val.Ps_bruto > decimal.Zero) &&
                    (val.Ps_tara > decimal.Zero))
                {
                    List<TRegistro_LanPesagemGraos> lTicketDest = DesdobrarTicket(val,
                                                                                 val.lDesdobro,
                                                                                 qtb_psgraos.Banco_Dados);
                    //Recalcular Desconto Ticket Origem
                    if (val.lDesdobro.Count > 0)
                        val.Ps_desconto_pag = TCN_LanClassificacao.calcClassif(val.Cd_empresa,
                                                                                val.Id_ticket.ToString(),
                                                                                val.Tp_pesagem,
                                                                                qtb_psgraos.Banco_Dados);
                    qtb_psgraos.Gravar(val);
                }
                if (pode_liberar)
                    qtb_psgraos.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_psgraos.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_psgraos.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_LanPesagemGraos val, TObjetoBanco banco)
        {
            //Verificar se pesagem não tem aplicação 
            TList_LanAplicacaoPedido lAplicacao = TCN_LanAplicacaoPedido.Buscar(string.Empty, 
                                                                                string.Empty, 
                                                                                string.Empty, 
                                                                                val.Cd_empresa, 
                                                                                string.Empty, 
                                                                                val.Id_ticket.ToString(), 
                                                                                val.Tp_pesagem,banco);
            if (lAplicacao.Count > 0)
            {
                string msg = "";
                for (int i = 0; i < lAplicacao.Count; i++)
                    msg += "Aplicação...: " + lAplicacao[i].Id_aplicacao.ToString() + "\r\n" +
                           "Pedido......: " + lAplicacao[i].Nr_pedido.ToString() + "\r\n" +
                           "Nota Fiscal.: " + lAplicacao[i].Nr_notafiscalaplic.ToString() + "\r\n"+
                           "Serie NF....: " + lAplicacao[i].Nr_serieaplic.ToString() + "\r\n"+
                           "--------------------------------------\r\n";
                    

                
                throw new Exception("Não é possivel excluir pesagem porque existe aplicação.\r\n\r\n" +
                                "-------Dados da Pesagem-------\r\n" +
                                "Empresa.....: " + val.Cd_empresa + "\r\n" +
                                "Ticket......: " + val.Id_ticket.ToString() + "\r\n" +
                                "TP. Pesagem.: " + val.Tp_pesagem + "\r\n\r\n" +
                                "--------Dados Aplicação---------\r\n" + msg);
            }
            TCD_LanPesagemGraos qtb_psgraos = new TCD_LanPesagemGraos();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_psgraos.CriarBanco_Dados(true);
                else
                    qtb_psgraos.Banco_Dados = banco;
                //Setar ST_Registro para C, pois a exclusão é somente lógica.
                val.St_registro = "C";
                qtb_psgraos.Gravar(val);
                //Excluir Registros de Classificação
                val.Classificacao.ForEach(p =>
                    {
                        p.St_registro = "C";
                        TCN_LanClassificacao.GravarClassificacao(p, null);
                    });
                if (pode_liberar)
                    qtb_psgraos.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_psgraos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar pesagem: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_psgraos.deletarBanco_Dados();
            }
        }

        public static void ProcessarTicketRefugado(TRegistro_LanPesagemGraos val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPesagemGraos qtb_psgraos = new TCD_LanPesagemGraos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_psgraos.CriarBanco_Dados(true);
                else
                    qtb_psgraos.Banco_Dados = banco;
                //Verificar se o usuario tem permissao para processar ticket refugado
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROCESSAR TICKET REFUGADO", qtb_psgraos.Banco_Dados))
                    throw new Exception("Usuário nao tem permissão para processar ticket refugado.");
                val.St_registro = "A";//Voltar o status do ticket para ABERTO
                val.St_processarTicketRef = true;//Status controla se a pesagem podera ser processada mesmo com indices de classificacao fora do permitido
                Gravar(val, qtb_psgraos.Banco_Dados);
                if (st_transacao)
                    qtb_psgraos.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_psgraos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar ticket refugado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_psgraos.deletarBanco_Dados();
            }
        }

        public static void ImprimirTicket(TRegistro_LanPesagemGraos val)
        {
            //Buscar configuracao impressao ticket do terminal

            CamadaDados.Diversos.TList_CadTerminal lTerminal =
                CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Utils.Parametros.pubTerminal,
                                                             string.Empty,
                                                             null);
            //Buscar Configuracao para impressao do laudo
            bool st_laudo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("IMP_LAUDO_DESCARGA", val.Cd_empresa, null).Trim().ToUpper().Equals("S");
            if (lTerminal.Count.Equals(decimal.Zero))
                throw new Exception("Obrigatorio informar terminal para imprimir ticket pesagem.");
            if (lTerminal[0].Tp_imptick.Trim().ToUpper().Equals("T") && string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                throw new Exception("Obrigatorio configurar porta de impressão para utilizar tipo de impressão texto.");
            if (val.St_registro.Trim().ToUpper().Equals("A") && st_laudo)
            {
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Ticket.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(Estruturas.StrTam("EMPRESA: " + val.Nm_empresa.Trim() + " - FONE: " + val.Foneemp.Trim(), "", true, 70));
                    w.WriteLine(Estruturas.StrTam("CIDADE.: " + val.Cidadeemp.Trim() + " - " + val.Estadoemp.Trim() + " / " + val.Cd_empresa.Trim() + " - CNPJ: " + val.Nr_cgcemp.Trim(), "", true, 78));
                    w.WriteLine();
                    w.WriteLine("ROMANEIO...: " + val.Id_ticket.ToString() + (val.Ps_bruto > 0 ? "    -    LAUDO DE DESCARGA" : "    -    LAUDO DE CARREGAMENTO"));
                    w.WriteLine("PLACA......: " + Estruturas.StrTam(val.Placacarreta.Trim() + " - MOTORISTA.: " + val.Nm_motorista.Trim(), "", true, 55));
                    w.WriteLine();
                    w.WriteLine("CONTRATO...: " + Estruturas.StrTam(val.NR_ContratoStr, "", true, 10) + " - " + Estruturas.StrTam(val.NM_Contratante.Trim(), "", true, 35));
                    w.WriteLine("FAZENDA....: " + Estruturas.StrTam(val.CD_EndContratante.Trim() + " - " + val.DS_EndContratante.Trim(), "", true, 40));
                    w.WriteLine("LOCAL ARMAZ: " + Estruturas.StrTam(val.Cd_local.Trim() + " - " + val.Ds_local.Trim(), "", true, 40));
                    w.WriteLine("PRODUTO.: " + val.Cd_produto.Trim() + " - " + val.Ds_produto.Trim());
                    w.WriteLine("TABELA..: " + val.Cd_tabeladesconto.Trim() + " - " + val.Ds_tabeladesconto.Trim() + "     SAFRA: " + val.Anosafra.Trim() + " - " + val.Ds_safra.Trim());
                    string temp = "OBSERVACOES: " + val.Ds_observacao.Trim();
                    int vTam = temp.Length;
                    int vIni = 0;
                    while (vTam > 0)
                    {
                        w.WriteLine(temp.Substring(vIni, vTam < 75 ? vTam : 75));
                        vIni += 75;
                        vTam -= vIni;
                    }
                    temp = string.Empty;
                    w.WriteLine("Ano Safra...: " + Estruturas.StrTam(val.Ds_safra, string.Empty, true, 20));
                    w.WriteLine("-------------------------------------------------------------------------------");
                    if (val.Ps_bruto > 0)
                        w.WriteLine("DATA/PESO BRUTO.: " + Estruturas.StrTam(val.Dt_bruto != null ? Convert.ToDateTime(val.Dt_bruto.ToString()).ToString("dd/MM/yyyy") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_bruto.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (BRUTO) " + val.Tp_captura_bruto.Trim());
                    if (val.Ps_tara > 0)
                        w.WriteLine("DATA/PESO TARA..: " + Estruturas.StrTam(val.Dt_tara != null ? Convert.ToDateTime(val.Dt_tara.ToString()).ToString("dd/MM/yyyy") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_tara.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (TARA) " + val.Tp_captura_tara.Trim());
                    if (val.Classificacao.Count > 0)
                    {
                        w.WriteLine("-------------------------------------------------------------------------------");
                        w.WriteLine("                           CLASSIFICACAO DO PRODUTO                            ");
                        w.WriteLine("-------------------------------------------------------------------------------");
                        w.WriteLine();
                        int x = 0;
                        string amostra = string.Empty;
                        string campo_amostra = string.Empty;
                        while (x < val.Classificacao.Count)
                        {
                            amostra = val.Classificacao[x].Ds_amostra.Trim().FormatStringDireita(16, '-') + "%";
                            campo_amostra += "  " + amostra;
                            if (x.Equals(3) || x.Equals(val.Classificacao.Count - 1))
                            {
                                w.WriteLine(campo_amostra);
                                campo_amostra = string.Empty;
                            }
                            x++;
                        }
                        w.WriteLine(" -               -             -               -             -");
                        w.WriteLine("|" + (val.Tp_prodpesagem.Trim().ToUpper().Equals("CV") ? "X" : "_") + 
                            "|CONVENCIONAL |" + (val.Tp_prodpesagem.Trim().ToUpper().Equals("TR") ? "X" : "_") + 
                            "|TRANGENICA |" + (val.Tp_prodpesagem.Trim().ToUpper().Equals("ID") ? "X" : "_") + 
                            "|RR-DECLARADO |_|RR-TESTADA |_|RR-PARTICIPANTE");
                        w.WriteLine("------------------------------------------------------------------------------");
                        w.WriteLine(" CLASSIFICADO POR:   | CARREGADO POR:       | EMITIDO POR:       |     DATA   |");
                        w.WriteLine("                     |                      |                    |            |");
                        w.WriteLine("                     |                      |                    | " + DateTime.Now.ToString("dd/MM/yyyy") + " |");
                        w.WriteLine("                     |                      |                    |            |");
                        w.WriteLine("                     |                      |                    |            |");
                        w.WriteLine("                     |                      |                    |            |");
                        w.WriteLine("------------------------------------------------------------------------------");
                    }
                    w.WriteLine("------------------------------------------------------------------------------");
                    w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(lTerminal[0].Porta_imptick);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão Ticket: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
            else
            {
                FileInfo f = null;
                StreamWriter w = null;
                f = new FileInfo(Path.GetTempPath() + Path.DirectorySeparatorChar + "Ticket.txt");
                w = f.CreateText();
                try
                {
                    w.WriteLine(Estruturas.StrTam("EMPRESA: " + val.Nm_empresa.Trim() + " - FONE: " + val.Foneemp.Trim(), string.Empty, true, 70));
                    w.WriteLine(Estruturas.StrTam("CIDADE.: " + val.Cidadeemp.Trim() + " - " + val.Estadoemp.Trim() + " / " + val.Cd_empresa.Trim() + " - CNPJ: " + val.Nr_cgcemp.Trim(), "", true, 78));
                    w.WriteLine("ROMANEIO...: " + val.Id_ticket.ToString() + "    -    " +
                            (val.Tp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA"));
                    w.WriteLine("PLACA......: " + Estruturas.StrTam(val.Placacarreta.Trim() + " - MOTORISTA.: " + val.Nm_motorista, string.Empty, true, 55));
                    w.WriteLine("CONTRATO...: " + Estruturas.StrTam(val.NR_ContratoStr, string.Empty, true, 10) + " - " + Estruturas.StrTam(val.NM_Contratante.Trim(), string.Empty, true, 35));
                    w.WriteLine("FAZENDA....: " + Estruturas.StrTam(val.CD_EndContratante.Trim() + " - " + val.DS_EndContratante.Trim(), "", true, 45));
                    w.WriteLine("PRODUTO.: " + val.Cd_produto.Trim() + " - " + val.Ds_produto.Trim() + "  SAFRA: " + val.Anosafra.Trim());
                    string temp = "OBSERVACOES: " + val.Ds_observacao.Trim();
                    int vTam = temp.Length;
                    int vIni = 0;
                    while (vTam > 0)
                    {
                        w.WriteLine(temp.Substring(vIni, vTam < 75 ? vTam : 75));
                        vIni += 75;
                        vTam -= vIni;
                    }
                    temp = string.Empty;
                    w.WriteLine("-------------------------------------------------------------------------------");
                    w.WriteLine("DATA/PESO BRUTO.: " + Estruturas.StrTam(val.Dt_bruto.HasValue ? val.Dt_bruto.Value.ToString("dd/MM/yyyy HH:mm:ss") : "", "", true, 19) +
                            "         " + Estruturas.StrTam(val.Ps_bruto.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (BRUTO) " + val.Tp_captura_bruto.Trim());

                    w.WriteLine("DATA/PESO TARA..: " + Estruturas.StrTam(val.Dt_tara.HasValue ? val.Dt_tara.Value.ToString("dd/MM/yyyy HH:mm:ss") : "", "", true, 19) +
                            "         " + Estruturas.StrTam(val.Ps_tara.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (TARA) " + val.Tp_captura_tara.Trim());

                    w.WriteLine("TMP CAR/DESC/LIQ: " + Estruturas.StrTam(val.Dt_permanenciaveiculo.HasValue ? (val.Dt_permanenciaveiculo.Value.Days > 0 ? val.Dt_permanenciaveiculo.Value.Days.ToString() + " Dias" : string.Empty) +
                    (val.Dt_permanenciaveiculo.Value.Hours > 0 ? val.Dt_permanenciaveiculo.Value.Hours.ToString() + " Hr " : string.Empty) +
                    (val.Dt_permanenciaveiculo.Value.Minutes > 0 ? val.Dt_permanenciaveiculo.Value.Minutes.ToString() + " Mn " : string.Empty) +
                    (val.Dt_permanenciaveiculo.Value.Seconds > 0 ? val.Dt_permanenciaveiculo.Value.Seconds.ToString() + " Sg" : string.Empty) : "", "", true, 19) +
                            "         " + Estruturas.StrTam(Convert.ToDecimal(val.Ps_bruto - val.Ps_tara).ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (LIQUIDO)");

                    if (val.Qtd_embalagem == 0)
                        w.WriteLine("PESO EMBALAGEM..: " + Estruturas.StrTam(string.Empty, string.Empty, true, 19) + "     " + Estruturas.StrTam(Convert.ToDecimal((val.Ps_embalagem * val.Qtd_embalagem)).ToString("N0", new System.Globalization.CultureInfo("en-US", true)), string.Empty, false, 7) + " Kg (EMBALAGEM)");

                    if (val.Classificacao.Count > 0)
                    {
                        if (val.Tp_prodpesagem.Trim().ToUpper() != "CV")
                            w.WriteLine("PRODUTO GENETICAMENTE MODIFICADO <" + val.Tipo_prodpesagem + "> ");
                        w.WriteLine("------------------------------------------------------------------");
                        w.WriteLine("AMOSTRA              |   CLASSIF   |   DESCONTOS   |     PESO     ");
                        w.WriteLine("------------------------------------------------------------------");
                        val.Classificacao.ForEach(p =>
                            w.WriteLine(p.Ds_amostra.Trim().FormatStringDireita(21, ' ') + "|" +
                                      p.Pc_resultado_local.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(12, ' ') + "%|" +
                                      p.Pc_desc_pagto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' ') + "%|" +
                                      p.Ps_descontado_pgt.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' ')));
                        w.WriteLine("TOTAL DESCONTOS.:                                  |" + (val as TRegistro_LanPesagemGraos).Ps_desconto_pag.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(14, ' ') + "Kg");
                    }
                    if (val.Ps_desdobro > decimal.Zero)
                        w.WriteLine("PESO DESDOBRO....: " + val.Ps_desdobro.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(15, ' ') + "Kg");
                    w.WriteLine("TOTAL LIQUIDO....: " + val.Ps_liquido.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatStringEsquerda(15, ' ') + "Kg" +
                        "   " + val.Ps_liqSacas.Trim());
                    w.WriteLine();
                    w.WriteLine("---------------------    -----------------------    --------------------------");
                    w.WriteLine("      Motorista                 Balanca                    Classificacao      ");
                    w.WriteLine("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");


                    w.Write(Convert.ToChar(12));
                    w.Write(Convert.ToChar(27));
                    w.Write(Convert.ToChar(109));
                    w.Flush();
                    f.CopyTo(lTerminal[0].Porta_imptick);
                }
                catch (Exception ex)
                { MessageBox.Show("Erro impressão Ticket: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    w.Dispose();
                    f = null;
                }
            }
        }

        public static List<TRegistro_LanPesagemGraos> DesdobrarTicket(TRegistro_LanPesagemGraos rTicketOrig,
                                                                      List<TRegistro_ItensDesdobro> lDesdobro,
                                                                      BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPesagemGraos qtb_psgraos = new TCD_LanPesagemGraos();
            List<TRegistro_LanPesagemGraos> lRetorno = new List<TRegistro_LanPesagemGraos>();
            try
            {
                if(banco == null)
                    st_transacao = qtb_psgraos.CriarBanco_Dados(true);
                else
                    qtb_psgraos.Banco_Dados = banco;

                lDesdobro.ForEach(p =>
                    {
                        //Buscar contrato destino
                        CamadaDados.Graos.TRegistro_CadContrato rContratoDest = null;
                        if(p.Nr_contrato_dest.HasValue)
                            rContratoDest = CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                                               p.Nr_contrato_dest.Value.ToString(),
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
                                                                                               banco)[0];
                        //Criar ticket destino
                        TRegistro_LanPesagemGraos rTicketDest = new TRegistro_LanPesagemGraos();
                        rTicketDest.Anosafra = rContratoDest != null ? rContratoDest.Anosafra : rTicketOrig.Anosafra;
                        rTicketDest.CD_Contratante = rContratoDest != null ? rContratoDest.Cd_clifor : p.Cd_contratante_dest;
                        rTicketDest.Cd_empresa = rContratoDest != null ? rContratoDest.Cd_empresa : rTicketOrig.Cd_empresa;
                        rTicketDest.CD_EndContratante = rContratoDest != null ? rContratoDest.Cd_endereco : string.Empty;
                        rTicketDest.Cd_local = rContratoDest != null ? rContratoDest.Cd_local : rTicketOrig.Cd_local;
                        rTicketDest.Cd_moega = rTicketOrig.Cd_moega;
                        rTicketDest.Cd_origempesagem = rTicketOrig.Cd_origempesagem;
                        rTicketDest.Cd_produto = rContratoDest != null ? rContratoDest.Cd_produto : rTicketOrig.Cd_produto;
                        rTicketDest.Cd_tabeladesconto = rContratoDest != null ? rContratoDest.Cd_tabeladesconto : rTicketOrig.Cd_tabeladesconto;
                        rTicketDest.Cd_tpveiculo = rTicketOrig.Cd_tpveiculo;
                        rTicketDest.Cd_transp = rTicketOrig.Cd_transp;
                        rTicketDest.Cd_unid_contrato = rContratoDest != null ? rContratoDest.Cd_unidade : rTicketOrig.Cd_unid_contrato;
                        rTicketDest.Cd_unid_produto = rContratoDest != null ? rContratoDest.Cd_unid_produto : rTicketOrig.Cd_unid_produto;
                        rTicketDest.Ds_observacao = rTicketOrig.Ds_observacao;
                        rTicketDest.Dt_bruto = CamadaDados.UtilData.Data_Servidor(qtb_psgraos.Banco_Dados);
                        rTicketDest.Dt_emissaonfprodutor = p.Dt_emissaonfprodutor;
                        rTicketDest.Dt_tara = CamadaDados.UtilData.Data_Servidor(qtb_psgraos.Banco_Dados);
                        if(rContratoDest != null)
                            rTicketDest.Id_pedidoitem = rContratoDest.Id_pedidoitem;
                        rTicketDest.Id_ticketorig = rTicketOrig.Id_ticket;
                        rTicketDest.Login_psbruto = Utils.Parametros.pubLogin;
                        rTicketDest.Login_pstara = Utils.Parametros.pubLogin;
                        rTicketDest.NM_Contratante = rContratoDest != null ? rContratoDest.Nm_clifor : p.Nm_contratante_dest;
                        if(rContratoDest != null)
                            rTicketDest.NR_Contrato = rContratoDest.Nr_contrato;
                        rTicketDest.Nr_notaprodutor = p.Nr_notaprodutor;
                        if(rContratoDest != null)
                            rTicketDest.Nr_pedido = rContratoDest.Nr_pedido;
                        rTicketDest.Placacarreta = rTicketOrig.Placacarreta;
                        rTicketDest.Placacavalo = rTicketOrig.Placacavalo;
                        if (p.Tp_pesodesdobro.Trim().ToUpper().Equals("L"))//Peso Liquido
                            rTicketDest.Ps_bruto = rTicketOrig.Ps_tara +
                                (p.Tp_percvalor.Trim().ToUpper().Equals("Q") ? p.Qtd_desdobro :
                                Math.Round(decimal.Divide(decimal.Multiply(rTicketOrig.Ps_liquido, p.Qtd_desdobro), 100), 0));
                        else //Peso Liquido Balança
                            rTicketDest.Ps_bruto = rTicketOrig.Ps_tara +
                                (p.Tp_percvalor.Trim().ToUpper().Equals("Q") ? p.Qtd_desdobro :
                                Math.Round(decimal.Divide(decimal.Multiply(rTicketOrig.Ps_liquidobruto, p.Qtd_desdobro), 100), 0));
                        rTicketDest.Ps_tara = rTicketOrig.Ps_tara;
                        rTicketDest.Qt_nfprodutor = p.Qt_nfprodutor;
                        rTicketDest.St_registro = rTicketOrig.St_registro;
                        rTicketDest.Tp_captura_bruto = "M";
                        rTicketDest.Tp_captura_tara = "M";
                        rTicketDest.Tp_prodpesagem = rTicketOrig.Tp_prodpesagem;
                        rTicketDest.Tp_movimento = rContratoDest != null ? rContratoDest.Tp_movimento : rTicketOrig.Tp_movimento;
                        rTicketDest.Tp_pesagem = rTicketOrig.Tp_pesagem;
                        rTicketDest.Vl_nfprodutor = p.Vl_nfprodutor;
                        rTicketDest.Vl_unit_contrato = rContratoDest != null ? rContratoDest.Vl_unitario : rTicketOrig.Vl_unitario;
                        rTicketDest.Tp_desdobro = p.Tp_pesodesdobro;
                        //Classificacao
                        rTicketOrig.Classificacao.ForEach(v => rTicketDest.Classificacao.Add(new TRegistro_LanClassificacao()
                        {
                            Cd_tipoamostra = v.Cd_tipoamostra,
                            Ds_amostra = v.Ds_amostra,
                            Fator_conversao = v.Fator_conversao,
                            InformarR_P = v.InformarR_P,
                            Maiorque = v.Maiorque,
                            Menorque = v.Menorque,
                            Ps_referencia = v.Ps_referencia,
                            Login_cla = Parametros.pubLogin,
                            Capturapeso = v.Capturapeso,
                            Capturareferencia = v.Capturareferencia,
                            Cd_protocolopeso = v.Cd_protocolopeso,
                            Cd_protocoloreferencia = v.Cd_protocoloreferencia,
                            Ds_protocolopeso = v.Ds_protocolopeso,
                            Ds_protocoloreferencia = v.Ds_protocoloreferencia,
                            Dt_classif = CamadaDados.UtilData.Data_Servidor(qtb_psgraos.Banco_Dados),
                            Pc_resultado_local = v.Pc_resultado_local,
                            Pc_resultado_origdes = v.Pc_resultado_origdes
                        }));
                        //Gravar Pesagem Destino
                        Gravar(rTicketDest, qtb_psgraos.Banco_Dados);
                        //Gravar Desdobro pesagem
                        TCN_DesdobroPesagem.Gravar(new TRegistro_DesdobroPesagem()
                        {
                            Cd_empresa_orig = rTicketOrig.Cd_empresa,
                            Tp_pesagem_orig = rTicketOrig.Tp_pesagem,
                            Id_ticket_orig = rTicketOrig.Id_ticket,
                            Cd_empresa_dest = rTicketDest.Cd_empresa,
                            Tp_pesagem_dest = rTicketDest.Tp_pesagem,
                            Id_ticket_dest = rTicketDest.Id_ticket
                        }, qtb_psgraos.Banco_Dados);
                        //Alimentar lista de retorno
                        lRetorno.Add(rTicketDest);
                    });
                if (st_transacao)
                    qtb_psgraos.Banco_Dados.Commit_Tran();
                return lRetorno;
            }
            catch(Exception ex)
            {
                if(st_transacao)
                    qtb_psgraos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro desdobrar ticket: "+ ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_psgraos.deletarBanco_Dados();
            }
        }

        public static void TrocarContratoTicket(string Nr_contrato_dest,
                                                List<TRegistro_LanPesagemGraos> lTicket,
                                                BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPesagemGraos qtb_ps = new TCD_LanPesagemGraos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ps.CriarBanco_Dados(true);
                else qtb_ps.Banco_Dados = banco;
                //Buscar dados contrato destino
                CamadaDados.Graos.TRegistro_CadContrato rContrato =
                    CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato(string.Empty,
                                                                       Nr_contrato_dest,
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
                                                                       qtb_ps.Banco_Dados)[0];
                lTicket.ForEach(p =>
                    {
                        p.NR_Contrato = rContrato.Nr_contrato;
                        p.CD_Contratante = rContrato.Cd_clifor;
                        p.NM_Contratante = rContrato.Nm_clifor;
                        p.Anosafra = rContrato.Anosafra;
                        p.Cd_tabeladesconto = rContrato.Cd_tabeladesconto;
                        p.Cd_produto = rContrato.Cd_produto;
                        p.Cd_local = rContrato.Cd_local;
                        qtb_ps.Gravar(p);
                    });
                if (st_transacao)
                    qtb_ps.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ps.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ps.deletarBanco_Dados();
            }
        }
    }
}