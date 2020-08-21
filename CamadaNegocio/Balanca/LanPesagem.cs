using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Utils;
using BancoDados;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_LanPesagem
    {
        public virtual string GravarPesagem(TRegistro_LanPesagem val, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TCD_LanPesagem qtb_pesagem = new TCD_LanPesagem();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                retorno = qtb_pesagem.GravaPesagem(val);
                val.Id_ticket = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_TICKET"));
                //Gravar transbordo pesagem
                if (val.Tp_transbordobool)
                    val.lTransbordo.ForEach(p=> TCN_LanTransbordo.GravarTransbordo(p, qtb_pesagem.Banco_Dados));
                if (pode_liberar)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public virtual string DeletarPesagem(TRegistro_LanPesagem val, TObjetoBanco banco)
        {
            string retorno = string.Empty;
            TCD_LanPesagem qtb_pesagem = new TCD_LanPesagem();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_pesagem.CriarBanco_Dados(true);
                else
                    qtb_pesagem.Banco_Dados = banco;
                //Setar ST_Registro para C, pois a exclusão é somente lógica
                val.St_registro = "C";
                retorno = qtb_pesagem.GravaPesagem(val);
                if (pode_liberar)
                    qtb_pesagem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_pesagem.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (pode_liberar)
                    qtb_pesagem.deletarBanco_Dados();
            }
        }

        public static void ImprimirTicket(TRegistro_LanPesagem val)
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
            if (val is TRegistro_LanPesagemGraos)
            {
                if (val.St_registro.Trim().ToUpper().Equals("A") && st_laudo)
                {
                    CDSSoftware.ImprimeTexto imp = new CDSSoftware.ImprimeTexto();
                    imp.Inicio(lTerminal[0].Porta_imptick);
                    imp.ImpLF(Estruturas.StrTam("EMPRESA: " + val.Nm_empresa.Trim() + " - FONE: " + (val as TRegistro_LanPesagemGraos).Foneemp.Trim(), "", true, 70));
                    imp.ImpLF(Estruturas.StrTam("CIDADE.: " + (val as TRegistro_LanPesagemGraos).Cidadeemp.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Estadoemp.Trim() + " / " + val.Cd_empresa.Trim() + " - CNPJ: " + (val as TRegistro_LanPesagemGraos).Nr_cgcemp.Trim(), "", true, 78));
                    imp.Pula(1);
                    imp.ImpLF("ROMANEIO...: " + val.Id_ticket.ToString() + (val.Ps_bruto > 0 ? "    -    LAUDO DE DESCARGA" : "    -    LAUDO DE CARREGAMENTO"));
                    imp.ImpLF("PLACA......: " + Estruturas.StrTam(val.Placacarreta.Trim() + " - MOTORISTA.: " + val.Nm_motorista.Trim(), "", true, 55));
                    imp.Pula(1);
                    if ((val as TRegistro_LanPesagemGraos).NR_PedidoUnicoStr.Trim() != string.Empty)
                        imp.ImpLF("NR. PEDIDO.: " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).NR_PedidoUnicoStr, "", true, 10) + " - " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).NM_Contratante.Trim(), "", true, 35));
                    imp.ImpLF("LOCAL ARMAZ: " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).Cd_local.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Ds_local.Trim(), "", true, 40));
                    imp.ImpLF("PRODUTO.: " + (val as TRegistro_LanPesagemGraos).Cd_produto.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Ds_produto.Trim());
                    imp.ImpLF("TABELA..: " + (val as TRegistro_LanPesagemGraos).Cd_tabeladesconto.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Ds_tabeladesconto.Trim() + "     SAFRA: " + (val as TRegistro_LanPesagemGraos).Anosafra.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Ds_safra.Trim());
                    string temp = "OBSERVACOES: " + val.Ds_observacao.Trim();
                    int vTam = temp.Length;
                    int vIni = 0;
                    while (vTam > 0)
                    {
                        imp.ImpLF(temp.Substring(vIni, vTam < 75 ? vTam : 75));
                        vIni += 75;
                        vTam -= vIni;
                    }
                    temp = string.Empty;
                    imp.ImpLF("Ano Safra...: " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).Ds_safra, "", true, 20));
                    imp.ImpLF("-------------------------------------------------------------------------------");
                    if (val.Ps_bruto > 0)
                        imp.ImpLF("DATA/PESO BRUTO.: " + Estruturas.StrTam(val.Dt_bruto != null ? Convert.ToDateTime(val.Dt_bruto.ToString()).ToString("dd/MM/yyyy") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_bruto.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (BRUTO) " + val.Tp_captura_bruto.Trim());
                    if (val.Ps_tara > 0)
                        imp.ImpLF("DATA/PESO TARA..: " + Estruturas.StrTam(val.Dt_tara != null ? Convert.ToDateTime(val.Dt_tara.ToString()).ToString("dd/MM/yyyy") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_tara.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (TARA) " + val.Tp_captura_tara.Trim());
                    if ((val as TRegistro_LanPesagemGraos).Classificacao.Count > 0)
                    {
                        imp.ImpLF("-------------------------------------------------------------------------------");
                        imp.ImpLF("                           CLASSIFICACAO DO PRODUTO                            ");
                        imp.ImpLF("-------------------------------------------------------------------------------");
                        imp.Pula(1);
                        int x = 0;
                        string amostra = string.Empty;
                        string campo_amostra = string.Empty;
                        while (x < (val as TRegistro_LanPesagemGraos).Classificacao.Count)
                        {
                            amostra = (val as TRegistro_LanPesagemGraos).Classificacao[x].Ds_amostra.Trim().FormatStringDireita(16, '-') + "%";
                            campo_amostra += "  " + amostra;
                            if (x.Equals(3) || x.Equals((val as TRegistro_LanPesagemGraos).Classificacao.Count - 1))
                            {
                                imp.ImpLF(campo_amostra);
                                campo_amostra = string.Empty;
                            }
                            x++;
                        }
                        imp.ImpLF(" -                  -                  -                -");
                        imp.ImpLF("|_|CONVENCIONAL    |" + ((val as TRegistro_LanPesagemGraos).St_gmodeclarado.Trim().ToUpper().Equals("S") ? "X" : "_") + "|RR-DECLARADO    |_|RR-TESTADA    |_|PARTICIPANTE");

                        imp.ImpLF("------------------------------------------------------------------------------");
                        imp.ImpLF(" CLASSIFICADO POR:   | CARREGADO POR:       | EMITIDO POR:       |     DATA   |");
                        imp.ImpLF("                     |                      |                    |            |");
                        imp.ImpLF("                     |                      |                    | " + DateTime.Now.ToString("dd/MM/yyyy") + " |");
                        imp.ImpLF("                     |                      |                    |            |");
                        imp.ImpLF("                     |                      |                    |            |");
                        imp.ImpLF("                     |                      |                    |            |");
                        imp.ImpLF("------------------------------------------------------------------------------");
                    }
                    imp.ImpLF("------------------------------------------------------------------------------");
                    imp.ImpLF("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                    imp.Fim();
                }
                else
                {
                    CDSSoftware.ImprimeTexto imp = new CDSSoftware.ImprimeTexto();
                    imp.Inicio(lTerminal[0].Porta_imptick);

                    imp.ImpLF(Estruturas.StrTam("EMPRESA: " + val.Nm_empresa.Trim() + " - FONE: " + (val as TRegistro_LanPesagemGraos).Foneemp.Trim(), "", true, 70));
                    imp.ImpLF(Estruturas.StrTam("CIDADE.: " + (val as TRegistro_LanPesagemGraos).Cidadeemp.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Estadoemp.Trim() + " / " + val.Cd_empresa.Trim() + " - CNPJ: " + (val as TRegistro_LanPesagemGraos).Nr_cgcemp.Trim(), "", true, 78));
                    imp.ImpLF("ROMANEIO...: " + val.Id_ticket.ToString() + "    -    " + 
                                (val.Tp_movimento.Trim().ToUpper().Equals("E") ? "ENTRADA" : "SAIDA"));
                    imp.ImpLF("PLACA......: " + Estruturas.StrTam(val.Placacarreta.Trim() + " - MOTORISTA.: " + val.Nm_motorista, "", true, 55));
                    if ((val as TRegistro_LanPesagemGraos).NR_PedidoUnicoStr.Trim() != string.Empty)
                        imp.ImpLF("NR. PEDIDO.: " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).NR_PedidoUnicoStr, "", true, 10) + " - " + Estruturas.StrTam((val as TRegistro_LanPesagemGraos).NM_Contratante.Trim(), "", true, 35));
                    imp.ImpLF("PRODUTO.: " + (val as TRegistro_LanPesagemGraos).Cd_produto.Trim() + " - " + (val as TRegistro_LanPesagemGraos).Ds_produto.Trim() + "  SAFRA: " + (val as TRegistro_LanPesagemGraos).Anosafra.Trim());
                    string temp = "OBSERVACOES: " + val.Ds_observacao.Trim();
                    int vTam = temp.Length;
                    int vIni = 0;
                    while (vTam > 0)
                    {
                        imp.ImpLF(temp.Substring(vIni, vTam < 75 ? vTam : 75));
                        vIni += 75;
                        vTam -= vIni;
                    }
                    temp = string.Empty;
                    imp.ImpLF("-------------------------------------------------------------------------------");
                    imp.ImpLF("DATA/PESO BRUTO.: " + Estruturas.StrTam(val.Dt_bruto.HasValue ? val.Dt_bruto.Value.ToString("dd/MM/yyyy HH:mm:ss") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_bruto.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (BRUTO) " + val.Tp_captura_bruto.Trim());

                    imp.ImpLF("DATA/PESO TARA..: " + Estruturas.StrTam(val.Dt_tara.HasValue ? val.Dt_tara.Value.ToString("dd/MM/yyyy HH:mm:ss") : "", "", true, 19) +
                                "         " + Estruturas.StrTam(val.Ps_tara.ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (TARA) " + val.Tp_captura_tara.Trim());

                    imp.ImpLF("TMP CAR/DESC/LIQ: " + Estruturas.StrTam(val.Dt_permanenciaveiculo.HasValue ? (val.Dt_permanenciaveiculo.Value.Days > 0 ? val.Dt_permanenciaveiculo.Value.Days.ToString() + " Dias" : string.Empty) +
                        (val.Dt_permanenciaveiculo.Value.Hours > 0 ? val.Dt_permanenciaveiculo.Value.Hours.ToString() + " Hr " : string.Empty) +
                        (val.Dt_permanenciaveiculo.Value.Minutes > 0 ? val.Dt_permanenciaveiculo.Value.Minutes.ToString() + " Mn " : string.Empty) +
                        (val.Dt_permanenciaveiculo.Value.Seconds > 0 ? val.Dt_permanenciaveiculo.Value.Seconds.ToString() + " Sg" : string.Empty) : "", "", true, 19) +
                                "         " + Estruturas.StrTam(Convert.ToDecimal(val.Ps_bruto - val.Ps_tara).ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (LIQUIDO)");
                    if (val.Qtd_embalagem == 0)
                        imp.ImpLF("PESO EMBALAGEM..: " + Estruturas.StrTam("", "", true, 19) + "     " + Estruturas.StrTam(Convert.ToDecimal((val.Ps_embalagem * val.Qtd_embalagem)).ToString("N0", new System.Globalization.CultureInfo("en-US", true)), "", false, 7) + " Kg (EMBALAGEM)");
                    if ((val as TRegistro_LanPesagemGraos).Classificacao.Count > 0)
                    {
                        string trans = string.Empty;
                        if ((val as TRegistro_LanPesagemGraos).St_transgenico)
                            trans = "PRODUTO GENETICAMENTE MODIFICADO <TESTADO> ";
                        else if ((val as TRegistro_LanPesagemGraos).St_transgenicodeclarado)
                            trans = "PRODUTO GENETICAMENTE MODIFICADO <DECLARADO> ";
                        if (!string.IsNullOrEmpty(trans))
                            imp.ImpLF(trans);
                        imp.ImpLF("------------------------------------------------------------------");
                        imp.ImpLF("AMOSTRA              |   CLASSIF   |   DESCONTOS   |     PESO     ");
                        imp.ImpLF("------------------------------------------------------------------");
                        (val as TRegistro_LanPesagemGraos).Classificacao.ForEach(p=>
                            imp.ImpLF(p.Ds_amostra.Trim().FormatStringDireita(21, ' ') + "|" +
                                      p.Pc_resultado_local.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(12, ' ') + "%|" +
                                      p.Pc_desc_pagto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(14, ' ') + "%|" +
                                      p.Ps_descontado_pgt.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(14, ' ')));
                        imp.ImpLF("TOTAL DESCONTOS.:                                  |" + (val as TRegistro_LanPesagemGraos).Ps_desconto_pag.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(14, ' ') + "Kg");
                    }
                    imp.ImpLF("TOTAL LIQUIDO....: " + val.Ps_liquido.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(13, ' ') + "Kg" + 
                        "   " + val.Ps_liqSacas.Trim());
                    imp.ImpLF("-------------------------------------------------------------------------------");
                    imp.ImpLF("CONTRATANTE/FORNECEDOR ENDERECO        CIDADE      NF     PS.NOTA    PS.LIQUIDO");
                    imp.ImpLF("-------------------------------------------------------------------------------");
                    //(val as TRegistro_LanPesagemGraos).Desdobroclifor.ForEach(p=>
                    //    {
                    //        temp = string.Empty;
                    //        if(p.Nome_clifor.Trim() != p.Nome_cliforpedido.Trim())
                    //            imp.ImpLF(p.Nome_cliforpedido.FormatSringEsquerda(32, ' '));
                    //        temp = p.Nome_clifor.Trim().FormatStringDireita(22, ' ') + " " +
                    //               p.Ds_enderecofornecedor.Trim().FormatStringDireita(15, ' ') + " " +
                    //               p.Ds_cidadefornecedor.Trim().FormatStringDireita(11, ' ') + " ";
                    //        p.Desdobroprodutos.ForEach(v=>
                    //            imp.ImpLF(temp.Trim() + 
                    //                      v.Nr_notafiscal.Trim().FormatStringDireita(6, ' ') + " " +
                    //                      v.Qtd_nota.ToString("N0", new System.Globalization.CultureInfo("en-US", true)).Trim().FormatStringDireita(10, ' ') + " " +
                    //                      v.Qtd_notaliquido.ToString("N0", new System.Globalization.CultureInfo("en-US", true))));
                    //    });
                    imp.Pula(1);
                    imp.ImpLF("---------------------    -----------------------    --------------------------");
                    imp.ImpLF(" Portaria/Motorista             Balanca                    Classificacao      ");
                    imp.ImpLF("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");
                    
                    imp.Fim();
                }
            }
            else if (val is TRegistro_PesagemAvulsa)
            {
                CDSSoftware.ImprimeTexto imp = new CDSSoftware.ImprimeTexto();
                imp.Inicio(lTerminal[0].Porta_imptick);
                imp.ImpLF("EMPRESA:  " + val.Nm_empresa.Trim().ToUpper().FormatStringDireita(60, ' ') + "CNPJ: " + (val as TRegistro_PesagemAvulsa).Cnpjempresa.Trim());
                imp.ImpLF("ENDEREÇO: " + (val as TRegistro_PesagemAvulsa).Ds_enderecoempresa.Trim() +
                                            ", " + (val as TRegistro_PesagemAvulsa).Numeroempresa.Trim() +
                                            " - " + (val as TRegistro_PesagemAvulsa).Bairroempresa.Trim() +
                                            " - " + (val as TRegistro_PesagemAvulsa).Ds_cidadeempresa.Trim() +
                                            ", " + (val as TRegistro_PesagemAvulsa).Ufempresa.Trim());
                imp.Pula(2);
                imp.ImpColLF(25, imp.NegritoOn + imp.Expandido + "PESAGEM AVULSA" + imp.NegritoOff + imp.Normal);
                imp.ImpLF("".FormatStringDireita(94, '-'));
                imp.Pula(1);
                imp.ImpLF("  ROMANEIO: " + val.Id_ticket.ToString().FormatStringDireita(50, ' ') + "Data Ticket: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy"));
                imp.ImpLF("  PLACA:    " + val.Placacarreta.Trim().FormatStringDireita(10, ' ') + "Cliente: " + (val as TRegistro_PesagemAvulsa).Nm_clifor.Trim());
                imp.ImpLF("  PRODUTO:  " + (val as TRegistro_PesagemAvulsa).Ds_carga.Trim());
                imp.Pula(3);
                imp.ImpLF("  PESO BRUTO:                              " + val.Ps_bruto.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(10, ' ') +
                    "     " + (val.Dt_bruto.HasValue ? val.Dt_bruto.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty) + "  " + val.Tp_captura_bruto.Trim().ToUpper());
                imp.ImpLF("  PESO TARA:                               " + val.Ps_tara.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(10, ' ') +
                    "     " + (val.Dt_tara.HasValue ? val.Dt_tara.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty) + "  " + val.Tp_captura_tara.Trim().ToUpper());
                imp.ImpLF("  PESO LIQUIDO:                            " + val.Ps_liquido.ToString("N2", new System.Globalization.CultureInfo("en-US", true)).FormatSringEsquerda(10, ' '));
                imp.Pula(2);
                imp.ImpLF("  TAXA PESAGEM: " + (val as TRegistro_PesagemAvulsa).Vl_taxa.ToString("N2", new System.Globalization.CultureInfo("en-US", true)));
                imp.ImpLF("  OBSERVACAO: " + (val as TRegistro_PesagemAvulsa).Ds_observacao.Trim() + "\r\n  Atencao: Esta pesagem nao tem nenhuma relacao com o movimento interno.");
                imp.Pula(1);
                imp.ImpLF("TecnoAliance Software - www.tecnoaliance.com.br - (0xx45)3421 5050 / Toledo-PR");

                imp.Fim();
            }
        }
    }
}
