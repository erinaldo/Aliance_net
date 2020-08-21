using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using System.Text.RegularExpressions;

namespace srvNFE.GerarArq
{
    public class TGerarArq2
    {
        private static CamadaDados.Faturamento.NFE.TList_LanLoteNFE BuscarLotesNfeContingencia(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            return new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_ambiente",
                        vOperador = "=",
                        vVL_Busca = "'3'" //Contingencia
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x "+
                                    "where x.id_lote = a.id_lote "+
                                    "and x.cd_empresa = '" + rCfgNfe.Cd_empresa + "')"
                    }
                }, 0, string.Empty);
        }

        public static void DeletarNfLotesProblemas(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            CamadaDados.Faturamento.NFE.TList_LanLoteNFE_X_NotaFiscal lNfe =
                new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rCfgNfe.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_lotenfe x "+
                                    "where x.id_lote = a.id_lote "+
                                    "and isnull(x.st_registro, 'A') = 'A' "+
                                    "and x.status is null "+
                                    "and x.tp_ambiente <> '3')"
                    }
                }, 0, string.Empty);
            lNfe.ForEach(p => CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE_X_NotaFiscal.Excluir(p, null));
        }

        public static void DeletarLotesProblemas(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            CamadaDados.Faturamento.NFE.TList_LanLoteNFE lLote =
                new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE().Select(
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
                        vNM_Campo = "a.status",
                        vOperador = "is",
                        vVL_Busca = "null"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_ambiente",
                        vOperador = "<>",
                        vVL_Busca = "'3'"
                    }
                }, 0, string.Empty);
            lLote.ForEach(p => CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE.Excluir(p, null));
        }

        private static bool existeImpostoLista(string vCd_imposto, TList_ImpostosNF val, TRegistro_ImpostosNF rImp)
        {
            for (int i = 0; i < val.Count; i++)
                if (val[i].Cd_impostostr.Trim().Equals(vCd_imposto.Trim()))
                {
                    rImp = val[i];
                    return true;
                }
            return false;
        }

        public static TList_RegLanFaturamento BuscarNfs(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            return TCN_LanFaturamento.Busca(rCfgNfe.Cd_empresa,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            decimal.Zero,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            true,
                                            string.Empty,
                                            "N",
                                            "N",
                                            string.Empty,
                                            "A",
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            decimal.Zero,
                                            decimal.Zero,
                                            "MASTER",
                                            "'P'",
                                            "'P', 'M'",
                                            true,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            50,
                                            string.Empty,
                                            null);
        }

        public static TList_RegLanFaturamento BuscarNfsXml(string Cd_empresa,
                                                           string Cd_clifor,
                                                           string Nr_notafiscal,
                                                           string Dt_inicial,
                                                           string Dt_final,
                                                           bool St_consulta)
        {
            return TCN_LanFaturamento.Busca(Cd_empresa,
                                            Nr_notafiscal,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            decimal.Zero,
                                            Cd_clifor,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            true,
                                            string.Empty,
                                            string.Empty,
                                            "S",
                                            string.Empty,
                                            string.Empty,
                                            (St_consulta ? "L" : "E"),
                                            Dt_inicial,
                                            Dt_final,
                                            decimal.Zero,
                                            decimal.Zero,
                                            "MASTER",
                                            "'P'",
                                            "'P', 'M'",
                                            true,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            0,
                                            string.Empty,
                                            null);
        }

        private static string MontarTagNfsReferenciadas(TRegistro_LanFaturamento val)
        {
            StringBuilder xml = new StringBuilder();
            //Buscar NF referenciada
            TList_RegLanFaturamento lFat =
            new TCD_LanFaturamento().Select(
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
                        vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lanctofiscal_origem = a.nr_lanctofiscal " +
                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    "and x.nr_lanctofiscal_destino = " + val.Nr_lanctofiscal.ToString() + ")"
                    }
                }, 0, string.Empty);
            //Buscar Cupom Referenciado
            CamadaDados.Faturamento.PDV.TList_NFCe lCupom =
                new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "exists(select 1 from TB_FAT_ECFVinculadoNF x " +
                                    "where x.id_cupom = a.id_nfce " +
                                    "and x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    "and x.nr_lanctofiscal = " + val.Nr_lanctofiscalstr + ") or " +
                                    "exists(select 1 from TB_PDV_DevolucaoCF x " +
                                    "where x.id_cupom = a.id_nfce " +
                                    "and x.cd_empresa = a.cd_empresa " +
                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                    "and x.nr_lanctofiscal = " + val.Nr_lanctofiscalstr + ")"
                    }
                }, 0, string.Empty, string.Empty);
            if ((lFat.Count > 0) ||
                (lCupom.Count > 0))
            {
                //NFe
                lFat.Where(p => p.Cd_modelo.Trim().Equals("55")).Select(p => new { chave_acesso = p.Chave_acesso_nfe }).Distinct().ToList().ForEach(p =>
                    {
                        xml.Append("<NFref>\n");

                        #region refNFe
                        if (string.IsNullOrEmpty(p.chave_acesso))
                            throw new Exception("Nota Fiscal Refenciada é modelo 55 (NFe) mas esta sem chave de acesso.");
                        xml.Append("<refNFe>");
                        xml.Append(p.chave_acesso.Trim().PadLeft(44, '0'));
                        xml.Append("</refNFe>\n");
                        #endregion

                        xml.Append("</NFref>\n");
                    });
                //NFCe
                lCupom.Where(p => p.Cd_modelo.Trim().Equals("65")).Select(p => new { chave_acesso = p.Chave_acesso }).Distinct().ToList().ForEach(p =>
                    {
                        xml.Append("<NFref>\n");

                        #region refNFe
                        if (string.IsNullOrEmpty(p.chave_acesso))
                            throw new Exception("NFCe Refenciada é modelo 65 mas esta sem chave de acesso.");
                        xml.Append("<refNFe>");
                        xml.Append(p.chave_acesso.Trim().PadLeft(44, '0'));
                        xml.Append("</refNFe>\n");
                        #endregion

                        xml.Append("</NFref>\n");
                    });
                //NF Modelo 01 ou 02
                lFat.Where(p => p.Cd_modelo.Trim().Equals("01") || p.Cd_modelo.Trim().Equals("02")).Select(p => new
                {
                    cd_empresa = p.Cd_empresa,
                    uf_empresa = p.Cd_uf_empresa,
                    cnpj_empresa = p.NR_CGC_Empresa,
                    cd_clifor = p.Cd_clifor,
                    uf_clifor = p.Cd_uf_clifor,
                    cnpj_clifor = p.Nr_cgc_cpf,
                    cd_endereco = p.Cd_endereco,
                    tp_movimento = p.Tp_movimento,
                    tp_nota = p.Tp_nota,
                    dt_emissao = p.Dt_emissao,
                    cd_modelo = p.Cd_modelo,
                    nr_serie = p.Nr_serie,
                    nr_notafiscal = p.Nr_notafiscal
                }).Distinct().ToList().ForEach(p =>
                                                {
                                                    xml.Append("<NFref>\n");

                                                    #region refNF
                                                    xml.Append("<refNF>");

                                                    #region cUF
                                                    xml.Append("<cUF>");
                                                    if (p.tp_movimento.Trim().ToUpper().Equals("E"))
                                                    {
                                                        if (p.tp_nota.Trim().ToUpper().Equals("P"))
                                                            xml.Append(p.uf_empresa.Trim().PadLeft(2, '0'));
                                                        else
                                                            xml.Append(p.uf_clifor.Trim().PadLeft(2, '0'));
                                                    }
                                                    else
                                                        xml.Append(p.uf_empresa.Trim().PadLeft(2, '0'));
                                                    xml.Append("</cUF>\n");
                                                    #endregion

                                                    #region AAMM
                                                    xml.Append("<AAMM>");
                                                    xml.Append(p.dt_emissao.Value.Year.ToString().Substring(2, 2) + p.dt_emissao.Value.Month.ToString().PadLeft(2, '0'));
                                                    xml.Append("</AAMM>\n");
                                                    #endregion

                                                    #region CNPJ
                                                    xml.Append("<CNPJ>");
                                                    if (p.tp_movimento.Trim().ToUpper().Equals("E"))
                                                        if (p.tp_nota.Trim().ToUpper().Equals("P"))
                                                            xml.Append(Regex.Replace(p.cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                                                        else
                                                            xml.Append(Regex.Replace(p.cnpj_clifor.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                                                    else
                                                        xml.Append(Regex.Replace(p.cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                                                    xml.Append("</CNPJ>\n");
                                                    #endregion

                                                    #region mod
                                                    xml.Append("<mod>");
                                                    xml.Append(p.cd_modelo.Trim().PadLeft(2, '0'));
                                                    xml.Append("</mod>\n");
                                                    #endregion

                                                    #region serie
                                                    xml.Append("<serie>");
                                                    xml.Append(p.nr_serie.Trim());
                                                    xml.Append("</serie>\n");
                                                    #endregion

                                                    #region nNF
                                                    xml.Append("<nNF>");
                                                    xml.Append(p.nr_notafiscal.ToString());
                                                    xml.Append("</nNF>\n");
                                                    #endregion

                                                    xml.Append("</refNF>\n");
                                                    #endregion

                                                    xml.Append("</NFref>\n");
                                                });
                //NF Produtor rural
                lFat.Where(p => p.Cd_modelo.Trim().Equals("04")).Select(p => new
                {
                    cd_empresa = p.Cd_empresa,
                    uf_empresa = p.Cd_uf_empresa,
                    cnpj_empresa = p.NR_CGC_Empresa,
                    cd_clifor = p.Cd_clifor,
                    uf_clifor = p.Cd_uf_clifor,
                    cnpj_clifor = p.Nr_cgc_cpf,
                    ie = p.Insc_estadualclifor,
                    cd_endereco = p.Cd_endereco,
                    tp_movimento = p.Tp_movimento,
                    tp_nota = p.Tp_nota,
                    dt_emissao = p.Dt_emissao,
                    cd_modelo = p.Cd_modelo,
                    nr_serie = p.Nr_serie,
                    nr_notafiscal = p.Nr_notafiscal
                }).Distinct().ToList().ForEach(p =>
                {
                    xml.Append("<NFref>\n");

                    #region refNFP 
                    xml.Append("<refNFP>\n");
                    #region cUF
                    xml.Append("<cUF>");
                    if (p.tp_movimento.Trim().ToUpper().Equals("E"))
                        if (p.tp_nota.Trim().ToUpper().Equals("P"))
                            xml.Append(p.uf_empresa.Trim().PadLeft(2, '0'));
                        else xml.Append(p.uf_clifor.Trim().PadLeft(2, '0'));
                    else xml.Append(p.uf_empresa.Trim().PadLeft(2, '0'));
                    xml.Append("</cUF>\n");
                    #endregion
                    #region AAMM
                    xml.Append("<AAMM>");
                    xml.Append(p.dt_emissao.Value.Year.ToString().Substring(2, 2) + p.dt_emissao.Value.Month.ToString().PadLeft(2, '0'));
                    xml.Append("</AAMM>\n");
                    #endregion
                    #region CNPJ
                    xml.Append("<CNPJ>");
                    if (p.tp_movimento.Trim().ToUpper().Equals("E"))
                        if (p.tp_nota.Trim().ToUpper().Equals("P"))
                            xml.Append(Regex.Replace(p.cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                        else xml.Append(Regex.Replace(p.cnpj_clifor.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                    else xml.Append(Regex.Replace(p.cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(14, '0'));
                    xml.Append("</CNPJ>\n");
                    #endregion
                    #region IE
                    xml.Append("<IE>");
                    if (!string.IsNullOrWhiteSpace(p.ie.SoNumero()))
                        xml.Append(p.ie.SoNumero());
                    else xml.Append("ISENTO");
                    xml.Append("</IE>\n");
                    #endregion
                    #region mod
                    xml.Append("<mod>");
                    xml.Append(p.cd_modelo.Trim().PadLeft(2, '0'));
                    xml.Append("</mod>\n");
                    #endregion
                    #region serie
                    xml.Append("<serie>");
                    xml.Append(p.nr_serie.Trim());
                    xml.Append("</serie>\n");
                    #endregion
                    #region nNF
                    xml.Append("<nNF>");
                    xml.Append(p.nr_notafiscal.ToString());
                    xml.Append("</nNF>\n");
                    #endregion
                    xml.Append("</refNFP>\n");
                    #endregion

                    xml.Append("</NFref>\n");
                });
            }
            return xml.ToString();
        }

        public static string CalcularDigitoChave(string vChave)
        {
            return Utils.Estruturas.Mod11(Regex.Replace(vChave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
        }

        public static string MontarChaveAcessoNfe(TRegistro_LanFaturamento val, CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            return val.rEmpresa.rEndereco.Cd_uf.FormatStringEsquerda(2, '0') + //UF Emitente
                    Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Year.ToString().FormatStringEsquerda(2, '0') + //Ano Emissao
                    Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Month.ToString().FormatStringEsquerda(2, '0') + //Mes Emissao
                    val.rEmpresa.rClifor.Nr_cgc.SoNumero() + //CNPJ Emitente
                    val.Cd_modelo.FormatStringEsquerda(2, '0') + //Modelo NFe
                    val.Nr_serie.FormatStringEsquerda(3, '0') + //Serie NFe
                    val.Nr_notafiscal.ToString().FormatStringEsquerda(9, '0') + //Numero Nota Fiscal
                    (rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1") + //Tipo Emissao 1 - Normal 6 - Contingencia SVC-AN 7 - Contingencia SVC-RS
                    val.Nr_lanctofiscal.ToString().FormatStringEsquerda(8, '0'); //Numero Lancto Fiscal
        }

        private static void CriarArquivoXml(List<TRegistro_LanFaturamento> lNf,
                                            bool St_consulta,
                                            CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            //Validar Certificado
            if (!St_consulta)
                ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            lNf.ForEach(p =>
            {
                string tp_ambiente = string.Empty;
                //Se for consulta, buscar tipo ambiente
                if (St_consulta)
                {
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_lotenfe_x_notafiscal x " +
                                                        "where x.id_lote = a.id_lote " +
                                                        "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                        "and x.nr_lanctofiscal = " + p.Nr_lanctofiscal.ToString() + ")"
                                        }
                                    }, "a.Tp_Ambiente");
                    if (obj != null)
                        tp_ambiente = obj.ToString();
                }
                string xmlassinado = string.Empty;
                if (string.IsNullOrEmpty(p.Xml_Nfe))
                {
                    //Buscar Itens da NFe com os impostos
                    p.ItensNota = TCN_LanFaturamento_Item.Busca(p.Cd_empresa, p.Nr_lanctofiscalstr, string.Empty, null);
                    StringBuilder xml = new StringBuilder();

                    #region NFe
                    xml.Append("<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">\n");

                    #region infNFe
                    xml.Append("<infNFe Id=\"NFe" + MontarChaveAcessoNfe(p, rCfgNfe) + CalcularDigitoChave(MontarChaveAcessoNfe(p, rCfgNfe)) + "\" versao=\"" + rCfgNfe.Cd_versao.Trim() + "\">\n");

                    #region ide
                    xml.Append("<ide>\n");

                    #region cUF
                    xml.Append("<cUF>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_uf.Trim());
                    xml.Append("</cUF>\n");
                    #endregion

                    #region cNF
                    xml.Append("<cNF>");
                    xml.Append(p.Nr_lanctofiscal.ToString().PadLeft(8, '0')); //Numero aleatorio gerado pelo emitente para cada NF-e
                    xml.Append("</cNF>\n");
                    #endregion

                    #region natOp
                    xml.Append("<natOp>");
                    xml.Append(p.Ds_movimentacao.Trim().RemoverCaracteres().SubstCaracteresEsp()); //Natureza da operação
                    xml.Append("</natOp>\n");
                    #endregion
                    
                    #region mod
                    xml.Append("<mod>");
                    xml.Append(p.Cd_modelo.Trim().PadLeft(2, '0')); //Modelo documento fiscal 
                    //utilizar codigo 55 para identificacao da NF-e
                    //utilizar codigo 65 para identificacao da NFC-e
                    xml.Append("</mod>\n");
                    #endregion

                    #region serie
                    xml.Append("<serie>");
                    xml.Append(p.Nr_serie.Trim()); //Série da nota fiscal
                    //Informar 0 (zero) para serie unica
                    xml.Append("</serie>\n");
                    #endregion

                    #region nNF
                    xml.Append("<nNF>");
                    xml.Append(p.Nr_notafiscal.ToString().Trim()); //Numero do documento fiscal
                    xml.Append("</nNF>\n");
                    #endregion

                    #region dEmi
                    xml.Append("<dhEmi>");
                    xml.Append(p.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de emissão da nota fiscal
                    xml.Append("</dhEmi>\n");
                    #endregion

                    #region dSaiEnt
                    if (p.Dt_saient.HasValue)
                    {
                        xml.Append("<dhSaiEnt>");
                        xml.Append(p.Dt_saient.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de entrada/saida da nf-e
                        xml.Append("</dhSaiEnt>\n");
                    }
                    #endregion

                    #region tpNF
                    xml.Append("<tpNF>");
                    xml.Append(p.Tp_movimento.Trim().ToUpper().Equals("E") ? "0" : "1"); //Tipo documento fiscal 
                    //0 - entrada
                    //1 - saida
                    xml.Append("</tpNF>\n");
                    #endregion

                    #region idDest
                    xml.Append("<idDest>");
                    string idDest = p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("E") ? "3" :
                                    p.St_vendaconsumidor || p.rEmpresa.rEndereco.Cd_uf.Equals(p.rEndereco.Cd_uf) ? "1" : "2";
                    xml.Append(idDest);
                    //1-Operação Interna 2-Operação Interestadual 3-Operação Exterior
                    xml.Append("</idDest>\n");
                    #endregion

                    #region cMunFG
                    xml.Append("<cMunFG>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_cidade.Trim().PadLeft(7, '0')); //Codigo do municipio gerador do icms
                    xml.Append("</cMunFG>\n");
                    #endregion

                    #region tpImp
                    xml.Append("<tpImp>");
                    xml.Append("1"); //Formato de impressão do DANFE 
                    //1 - Retrato
                    //2 - Paisagem
                    xml.Append("</tpImp>\n");
                    #endregion

                    #region tpEmis
                    xml.Append("<tpEmis>");
                    xml.Append(rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1"); //Forma de emissão da NF-e
                    //1-Normal, emissão normal com transmissão on-line da NF-e para a SEFAZ de origem
                    //6-Contingencia SVC-AN
                    //7-Contingencia SVC-RS
                    xml.Append("</tpEmis>\n");
                    #endregion

                    #region cDV
                    xml.Append("<cDV>");
                    xml.Append(CalcularDigitoChave(MontarChaveAcessoNfe(p, rCfgNfe)).Trim()); //Digito verificador da chave de acesso da NF-e
                    xml.Append("</cDV>\n");
                    #endregion

                    #region tpAmb
                    xml.Append("<tpAmb>");
                    xml.Append(St_consulta ? tp_ambiente : rCfgNfe.Tp_ambiente.Trim().ToUpper().Equals("P") ? "1" : "2");
                    //1-Produção 
                    //2-homologação
                    xml.Append("</tpAmb>\n");
                    #endregion

                    #region finNFe
                    xml.Append("<finNFe>");
                    if (p.rCmi.St_complementarbool)
                        xml.Append("2"); //Finalidade de emissão da NF-e 
                    else if (p.rCmi.St_devolucaobool ||
                        new CamadaDados.Faturamento.PDV.TCD_DevolucaoCF().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = p.Nr_lanctofiscalstr
                                    }
                                }, "1") != null)
                        xml.Append("4");
                    else
                        xml.Append("1");
                    //1 - Normal
                    //2 - Complementar 
                    //3 - Ajuste
                    //4 - Devolucao/Retorno
                    xml.Append("</finNFe>\n");
                    #endregion

                    #region indFinal
                    xml.Append("<indFinal>");
                    string indFinal = p.rEndereco.St_naocontribuintebool || p.St_vendaconsumidor ? "1" : "0";
                    xml.Append(indFinal);
                    //0-Normal 1-Consumidor Final
                    xml.Append("</indFinal>\n");
                    #endregion

                    #region indPres
                    xml.Append("<indPres>");
                    xml.Append("1");//Operacao presencial
                    xml.Append("</indPres>\n");
                    #endregion

                    #region procEmi
                    xml.Append("<procEmi>");
                    xml.Append("0"); //Processo de emissão da NF-e
                    //0-emissão de nf-e com aplicativo do contribuinte
                    //1-emissão de nf-e avulsa pelo fisco
                    //2-emissão de nf-e avulsa, pelo contribuinte com seu certificado digital atraves do site do fisco
                    //3-emissão de nf-e pelo contribuinte com aplicativo fornecido pelo fisco
                    xml.Append("</procEmi>\n");
                    #endregion

                    #region verProc
                    xml.Append("<verProc>");
                    xml.Append(rCfgNfe.Cd_versao.Trim()); //Versão do processo de emissão da NF-e
                    xml.Append("</verProc>\n");
                    #endregion

                    if (rCfgNfe.St_nfecontingencia)
                    {
                        #region dhCont
                        xml.Append("<dhCont>");
                        xml.Append(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                        xml.Append("</dhCont>");
                        #endregion

                        #region xJust
                        xml.Append("<xJust>");
                        xml.Append("Contingencia ativada pela receita de origem");
                        xml.Append("</xJust>");
                        #endregion
                    }

                    //Notas fiscais referenciadas
                    xml.Append(MontarTagNfsReferenciadas(p));
                    xml.Append("</ide>\n");
                    #endregion

                    #region emit
                    xml.Append("<emit>\n");

                    #region CNPJ
                    xml.Append("<CNPJ>");
                    xml.Append(p.rEmpresa.rClifor.Nr_cgc.SoNumero());
                    xml.Append("</CNPJ>\n");
                    #endregion

                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(p.rEmpresa.Nm_empresa.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Razão social ou nome do emitente
                    xml.Append("</xNome>\n");
                    #endregion

                    #region xFant
                    if (!string.IsNullOrEmpty(p.rEmpresa.rClifor.Nm_fantasia))
                    {
                        xml.Append("<xFant>");
                        xml.Append(p.rEmpresa.rClifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Nome fantasia
                        xml.Append("</xFant>\n");
                    }
                    #endregion

                    #region enderEmit
                    xml.Append("<enderEmit>\n");

                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(p.rEmpresa.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xLgr>\n");
                    #endregion

                    #region nro
                    xml.Append("<nro>");
                    xml.Append(p.rEmpresa.rEndereco.Numero.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</nro>\n");
                    #endregion

                    #region xCpl
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(p.rEmpresa.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xCpl>\n");
                    }
                    #endregion

                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(p.rEmpresa.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xBairro>\n");
                    #endregion

                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_cidade.Trim());
                    xml.Append("</cMun>\n");
                    #endregion

                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(p.rEmpresa.rEndereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMun>\n");
                    #endregion

                    #region UF
                    xml.Append("<UF>");
                    xml.Append(p.rEmpresa.rEndereco.UF.Trim());
                    xml.Append("</UF>\n");
                    #endregion

                    #region CEP
                    xml.Append("<CEP>");
                    xml.Append(p.rEmpresa.rEndereco.Cep.SoNumero());
                    xml.Append("</CEP>\n");
                    #endregion

                    #region cPais
                    xml.Append("<cPais>");
                    xml.Append(p.rEmpresa.rEndereco.CD_Pais.FormatStringEsquerda(4, '0')); //Codigo do pais, utilizar a tabela do BACEN
                    //1058 - Brasil
                    xml.Append("</cPais>\n");
                    #endregion

                    #region xPais
                    xml.Append("<xPais>");
                    xml.Append(p.rEmpresa.rEndereco.NM_Pais.Trim()); //Nome do pais
                    xml.Append("</xPais>\n");
                    #endregion

                    #region fone
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(p.rEmpresa.rEndereco.Fone.SoNumero());
                        xml.Append("</fone>\n");
                    }
                    #endregion

                    xml.Append("</enderEmit>\n");
                    #endregion

                    #region IE
                    xml.Append("<IE>");
                    xml.Append(Regex.Replace(p.rEmpresa.rEndereco.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                    xml.Append("</IE>\n");
                    #endregion

                    #region IEST
                    if ((!string.IsNullOrEmpty(Regex.Replace(p.rEmpresa.Insc_estadual_subst.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty))) &&
                        p.ItensNota.Exists(v => v.Pc_aliquotaSTICMS > decimal.Zero))
                    {
                        xml.Append("<IEST>");
                        xml.Append(Regex.Replace(p.rEmpresa.Insc_estadual_subst.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                        xml.Append("</IEST>");
                    }
                    #endregion

                    #region IM
                    if (!string.IsNullOrEmpty(Regex.Replace(p.rEmpresa.Insc_municipal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)))
                    {
                        xml.Append("<IM>");
                        xml.Append(Regex.Replace(p.rEmpresa.Insc_municipal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                        xml.Append("</IM>\n");
                    }
                    #endregion

                    #region CNAE
                    if (!string.IsNullOrEmpty(Regex.Replace(p.rEmpresa.Cnae_fiscal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)))
                    {
                        xml.Append("<CNAE>");
                        xml.Append(Regex.Replace(p.rEmpresa.Cnae_fiscal.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                        xml.Append("</CNAE>\n");
                    }
                    #endregion

                    #region CRT
                    xml.Append("<CRT>");
                    xml.Append(p.rEmpresa.Tp_regimetributario.Trim());
                    xml.Append("</CRT>\n");
                    #endregion
                    xml.Append("</emit>\n");
                    #endregion

                    #region dest
                    xml.Append("<dest>\n");
                    //Se não for venda para o estrangeiro
                    if (!p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("E"))
                    {
                        #region CNPJ
                        if (p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(p.rClifor.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>\n");
                        }
                        #endregion

                        #region CPF
                        if (p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(Regex.Replace(p.rClifor.Nr_cpf.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                            xml.Append("</CPF>\n");
                        }
                        #endregion
                    }
                    else
                    {
                        #region idEstrangeiro
                        xml.Append("<idEstrangeiro>");
                        xml.Append(p.rClifor.Id_estrangeiro.Trim());
                        xml.Append("</idEstrangeiro>\n");
                        #endregion
                    }

                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(p.rClifor.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xNome>\n");
                    #endregion

                    #region enderDest
                    xml.Append("<enderDest>\n");

                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(p.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xLgr>\n");
                    #endregion

                    #region nro
                    xml.Append("<nro>");
                    xml.Append(p.rEndereco.Numero.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</nro>\n");
                    #endregion

                    #region xCpl
                    if (!string.IsNullOrEmpty(p.rEndereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(p.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xCpl>\n");
                    }
                    #endregion

                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(p.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xBairro>\n");
                    #endregion

                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(p.rEndereco.rCidade.Cd_cidade.Trim()); // Codigo do municipio, utilizar tabela do IBGE
                    xml.Append("</cMun>\n");
                    #endregion

                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(p.rEndereco.rCidade.Ds_cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMun>\n");
                    #endregion

                    #region UF
                    xml.Append("<UF>");
                    xml.Append(p.rEndereco.rCidade.rUf.Uf.Trim());
                    xml.Append("</UF>\n");
                    #endregion

                    #region CEP
                    if (Regex.Replace(p.rEndereco.Cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Trim() != string.Empty)
                    {
                        xml.Append("<CEP>");
                        xml.Append(Regex.Replace(p.rEndereco.Cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(8, '0'));
                        xml.Append("</CEP>\n");
                    }
                    #endregion

                    #region cPais
                    xml.Append("<cPais>");
                    xml.Append(p.rEndereco.CD_Pais.Trim()); //Utilizar tabela do  BACEN
                    xml.Append("</cPais>\n");
                    #endregion

                    #region xPais
                    xml.Append("<xPais>");
                    xml.Append(p.rEndereco.NM_Pais.Trim());
                    xml.Append("</xPais>\n");
                    #endregion

                    #region fone
                    if (Regex.Replace(p.rEndereco.Fone.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Trim() != string.Empty)
                    {
                        xml.Append("<fone>");
                        string fone_dest = Regex.Replace(p.rEndereco.Fone.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                        if (fone_dest.Length > 10)
                            fone_dest = fone_dest.Remove(0, 1);
                        fone_dest = Regex.Replace(fone_dest, "[' ']", string.Empty);
                        xml.Append(fone_dest);
                        xml.Append("</fone>\n");
                    }
                    #endregion

                    xml.Append("</enderDest>\n");
                    #endregion

                    #region indIEDest
                    xml.Append("<indIEDest>");
                    string indIEDest = p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("E") || p.rEndereco.St_naocontribuintebool ? "9" :
                                string.IsNullOrEmpty(p.rEndereco.Insc_estadual.SoNumero()) ? "2" : "1";
                    xml.Append(indIEDest);
                    xml.Append("</indIEDest>\n");
                    #endregion

                    #region IE
                    if (!string.IsNullOrEmpty(p.rEndereco.Insc_estadual.SoNumero()))
                    {
                        xml.Append("<IE>");
                        if (!string.IsNullOrEmpty(p.rEndereco.Insc_estadual))
                            xml.Append(p.rEndereco.Insc_estadual.SoNumero());
                        //Informar a IE quando o destinatario for contribuinte do ICMS.
                        //Informar ISENTO quando o destinatario for contribuinte do ICMS,
                        //mas não estiver obrigado à inscrição no cadastro de contribuintes do ICMS.
                        //Não informar o conteudo da TAG se o destinatario não for contribuinte do ICMS
                        xml.Append("</IE>\n");
                    }
                    #endregion

                    #region ISUF
                    if (!string.IsNullOrEmpty(p.rClifor.Cod_suframa))
                    {
                        xml.Append("<ISUF>");
                        xml.Append(p.rClifor.Cod_suframa.Trim());
                        xml.Append("</ISUF>\n");
                    }
                    #endregion

                    #region email
                    if (!string.IsNullOrEmpty(p.rClifor.Email))
                    {
                        xml.Append("<email>");
                        xml.Append(p.rClifor.Email.Trim());
                        xml.Append("</email>\n");
                    }
                    #endregion

                    xml.Append("</dest>\n");
                    #endregion

                    #region Local Entrega
                    if (!string.IsNullOrEmpty(p.Logradouroent) &&
                        !string.IsNullOrEmpty(p.Numeroent) &&
                        !string.IsNullOrEmpty(p.Bairroent) &&
                        !string.IsNullOrEmpty(p.Cd_cidadeent))
                    {
                        xml.Append("<entrega>\n");
                        #region CNPJ
                        if (p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(p.rClifor.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>\n");
                        }
                        #endregion

                        #region CPF
                        if (p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(Regex.Replace(p.rClifor.Nr_cpf.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                            xml.Append("</CPF>\n");
                        }
                        #endregion

                        #region xLgr
                        xml.Append("<xLgr>");
                        xml.Append(p.Logradouroent.Trim());
                        xml.Append("</xLgr>\n");
                        #endregion

                        #region nro
                        xml.Append("<nro>");
                        xml.Append(p.Numeroent.Trim());
                        xml.Append("</nro>\n");
                        #endregion

                        #region xCpl
                        if (!string.IsNullOrEmpty(p.Complementoent))
                        {
                            xml.Append("<xCpl>");
                            xml.Append(p.Complementoent.Trim());
                            xml.Append("</xCpl>\n");
                        }
                        #endregion

                        #region xBairro
                        xml.Append("<xBairro>");
                        xml.Append(p.Bairroent.Trim());
                        xml.Append("</xBairro>\n");
                        #endregion

                        #region cMun
                        xml.Append("<cMun>");
                        xml.Append(p.Cd_cidadeent.Trim());
                        xml.Append("</cMun>\n");
                        #endregion

                        #region xMun
                        xml.Append("<xMun>");
                        xml.Append(p.Ds_cidadeent.Trim());
                        xml.Append("</xMun>\n");
                        #endregion

                        #region UF
                        xml.Append("<UF>");
                        xml.Append(p.Uf_ent.Trim());
                        xml.Append("</UF>\n");
                        #endregion
                        xml.Append("</entrega>\n");
                    }
                    #endregion

                    #region Autorização para obter XML
                    if (!string.IsNullOrWhiteSpace(rCfgNfe.Cnpj_contador.SoNumero()))
                    {
                        
                        #region autXML 
                        xml.Append("<autXML>\n");
                        #region CNPJ 
                        xml.Append("<CNPJ>");
                        xml.Append(rCfgNfe.Cnpj_contador.SoNumero());
                        xml.Append("</CNPJ>\n");
                        #endregion
                        xml.Append("</autXML>\n");
                        #endregion
                    }
                    #endregion

                    #region det - Grupo Detalhamento de Produtos e Serviços
                    int tot_item = 1;
                    decimal tot_imposto_aprox = decimal.Zero;
                    decimal tot_difal = decimal.Zero;
                    decimal tot_fcp = decimal.Zero;
                    decimal tot_desc = decimal.Zero;

                    //TODO srvNFE.GerarArq XML - Itens da nova fiscal
                    p.ItensNota.ForEach(v =>
                    {
                        xml.Append("<det nItem=\"" + tot_item.ToString() + "\">\n");

                        #region prod
                        xml.Append("<prod>");

                        #region cProd
                        xml.Append("<cProd>");
                        xml.Append(v.Cd_produto.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Preencher com CFOP, caso se trate de itens não relacionados com mercadorias/produtos
                        //e que o contribuinte não possua codificação própria.
                        xml.Append("</cProd>\n");
                        #endregion

                        #region cEAN
                        xml.Append("<cEAN>");
                        xml.Append("SEM GTIN");
                        //xml.Append(v.Cod_barra.Trim().Length.Equals(8) ||
                        //           v.Cod_barra.Trim().Length.Equals(12) ||
                        //           v.Cod_barra.Trim().Length.Equals(13) ||
                        //           v.Cod_barra.Trim().Length.Equals(14) ? v.Cod_barra : "SEM GTIN");//GTIN(Global Trade Item Number) do produto, antigo codigo EAN ou codigo de barras
                        //não informar o conteudo da tag caso o produto não possua este codigo
                        xml.Append("</cEAN>\n");
                        #endregion

                        #region xProd
                        xml.Append("<xProd>");
                        xml.Append(v.Ds_produto.Trim());
                        xml.Append("</xProd>\n");
                        #endregion

                        #region NCM
                        xml.Append("<NCM>");
                        xml.Append(v.St_servico.Trim().ToUpper().Equals("S") ? "00" : v.Cd_ncm.Trim());
                        xml.Append("</NCM>\n");
                        #endregion

                        #region CEST
                        if (!string.IsNullOrEmpty(v.Cest))
                        {
                            xml.Append("<CEST>");
                            xml.Append(v.Cest.Trim());
                            xml.Append("</CEST>\n");
                        }
                        #endregion

                        #region CFOP
                        xml.Append("<CFOP>");
                        xml.Append(v.Cd_cfop.Trim().PadLeft(4, '0'));
                        xml.Append("</CFOP>\n");
                        #endregion

                        #region uCom
                        xml.Append("<uCom>");
                        xml.Append(v.Sigla_unidade.Trim()); //Unidade de comercialização do produto
                        xml.Append("</uCom>\n");
                        #endregion

                        #region qCom
                        xml.Append("<qCom>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade de comercialização do produto
                        xml.Append("</qCom>\n");
                        #endregion

                        #region vUnCom
                        xml.Append("<vUnCom>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N10}", (v.Quantidade.Equals(decimal.Zero) ? decimal.Zero : v.Vl_subtotal / CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null)))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de comercialização do produto
                        xml.Append("</vUnCom>\n");
                        #endregion

                        #region vProd
                        xml.Append("<vProd>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_subtotal)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total bruto do produto e/ou serviços
                        xml.Append("</vProd>\n");
                        #endregion

                        #region cEANTrib
                        xml.Append("<cEANTrib>");
                        xml.Append("SEM GTIN");
                        //xml.Append(v.Cod_barra.Trim().Length.Equals(8) ||
                        //           v.Cod_barra.Trim().Length.Equals(12) ||
                        //           v.Cod_barra.Trim().Length.Equals(13) ||
                        //           v.Cod_barra.Trim().Length.Equals(14) ? v.Cod_barra : "SEM GTIN");
                        //antigo codigo EAN ou codigo de barras
                        xml.Append("</cEANTrib>\n");
                        #endregion

                        #region uTrib
                        xml.Append("<uTrib>");
                        xml.Append(v.Sigla_unidade.Trim());
                        xml.Append("</uTrib>\n");
                        #endregion

                        #region qTrib
                        xml.Append("<qTrib>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade tributavel
                        xml.Append("</qTrib>\n");
                        #endregion

                        #region vUnTrib
                        xml.Append("<vUnTrib>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N10}", (v.Quantidade.Equals(decimal.Zero) ? decimal.Zero : v.Vl_subtotal / CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null)))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                        xml.Append("</vUnTrib>\n");
                        #endregion

                        #region vFrete
                        if (v.Vl_freteitem > 0)
                        {
                            xml.Append("<vFrete>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_freteitem)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                            xml.Append("</vFrete>\n");
                        }
                        #endregion

                        #region vSeg
                        if (v.Vl_seguro > decimal.Zero)
                        {
                            xml.Append("<vSeg>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_seguro)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vSeg>\n");
                        }
                        #endregion

                        #region vDesc
                        if (v.Vl_desconto > 0)
                        {
                            xml.Append("<vDesc>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_desconto)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                            xml.Append("</vDesc>\n");
                            tot_desc += Convert.ToDecimal(string.Format("{0:N2}", v.Vl_desconto));
                        }
                        #endregion

                        #region vOutro
                        if ((v.Vl_outrasdesp + v.Vl_juro_fin) > decimal.Zero)
                        {
                            xml.Append("<vOutro>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_outrasdesp + v.Vl_juro_fin)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vOutro>");
                        }
                        #endregion

                        #region indTot
                        xml.Append("<indTot>");
                        xml.Append("1"); //Valor unitario de tributação
                        xml.Append("</indTot>\n");
                        #endregion
                        if (p.Tp_movimento.Trim().ToUpper().Equals("E") &&
                            !p.rCmi.St_devolucaobool &&
                            v.Cd_cfop.Trim().Substring(0, 1).Equals("3"))
                        {
                            //Buscar DI
                            new TCD_DeclaracaoImport().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + v.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = v.Nr_lanctofiscal.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_nfitem",
                                        vOperador = "=",
                                        vVL_Busca = v.Id_nfitem.ToString()
                                    }
                                }, 0, string.Empty).ForEach(x =>
                                {
                                    #region DI
                                    xml.Append("<DI>");
                                    #region nDI
                                    xml.Append("<nDI>");
                                    xml.Append(x.Nr_di.Trim());
                                    xml.Append("</nDI>");
                                    #endregion
                                    #region dDI
                                    xml.Append("<dDI>");
                                    xml.Append(x.Dt_di.Value.ToString("yyyy-MM-dd"));
                                    xml.Append("</dDI>");
                                    #endregion
                                    #region xLocDesemb
                                    xml.Append("<xLocDesemb>");
                                    xml.Append(x.xLocDesemb.Trim());
                                    xml.Append("</xLocDesemb>");
                                    #endregion
                                    #region UFDesemb
                                    xml.Append("<UFDesemb>");
                                    xml.Append(x.Sg_ufdesemb.Trim());
                                    xml.Append("</UFDesemb>");
                                    #endregion
                                    #region dDesemb
                                    xml.Append("<dDesemb>");
                                    xml.Append(x.Dt_desemb.Value.ToString("yyyy-MM-dd"));
                                    xml.Append("</dDesemb>");
                                    #endregion
                                    #region tpViaTransp
                                    xml.Append("<tpViaTransp>");
                                    xml.Append(x.Tp_viatransp.Trim());
                                    xml.Append("</tpViaTransp>");
                                    #endregion
                                    #region vAFRMM
                                    if (x.Vl_AFRMM > decimal.Zero)
                                    {
                                        xml.Append("<vAFRMM>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", x.Vl_AFRMM)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vAFRMM>");
                                    }
                                    #endregion
                                    #region tpIntermedio
                                    xml.Append("<tpIntermedio>");
                                    xml.Append(x.Tp_intermedio.Trim());
                                    xml.Append("</tpIntermedio>");
                                    #endregion
                                    #region cExportador
                                    xml.Append("<cExportador>");
                                    xml.Append(p.Cd_clifor.Trim());
                                    xml.Append("</cExportador>");
                                    #endregion
                                    if (!string.IsNullOrEmpty(x.Nr_adicao))
                                    {
                                        #region adi
                                        xml.Append("<adi>");
                                        #region nAdicao
                                        xml.Append("<nAdicao>");
                                        xml.Append(x.Nr_adicao.Trim());
                                        xml.Append("</nAdicao>");
                                        #endregion
                                        #region nSeqAdic
                                        xml.Append("<nSeqAdic>");
                                        xml.Append(x.nSeqAdic);
                                        xml.Append("</nSeqAdic>");
                                        #endregion
                                        #region cFabricante
                                        xml.Append("<cFabricante>");
                                        xml.Append(p.Cd_clifor.Trim());
                                        xml.Append("</cFabricante>");
                                        #endregion
                                        xml.Append("</adi>");
                                        #endregion
                                    }
                                    xml.Append("</DI>");
                                    #endregion
                                });
                        }
                        bool st_comb = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(v.Cd_produto);
                        if (st_comb ||
                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoLubrificante(v.Cd_produto))
                        {
                            #region Combustiveis e Lubrificantes
                            xml.Append("<comb>");

                            #region Codigo ANP
                            xml.Append("<cProdANP>");
                            xml.Append(v.Cd_anp.Trim());
                            xml.Append("</cProdANP>\n");
                            #endregion

                            #region descANP
                            xml.Append("<descANP>");
                            xml.Append(v.Ds_anp.Trim());
                            xml.Append("</descANP>");
                            #endregion

                            #region UF Consumidor
                            xml.Append("<UFCons>");
                            xml.Append(p.St_vendaconsumidor ? p.Uf_empresa.Trim() : p.Uf_clifor.Trim());
                            xml.Append("</UFCons>\n");
                            #endregion

                            if (st_comb &&
                                new CamadaDados.Fiscal.TCD_CadCFOP().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_cfop",
                                        vOperador = "=",
                                        vVL_Busca = "'" + v.Cd_cfop.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_combustivel, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "1") != null)
                            {
                                //Buscar Abastecida Cupom
                                CamadaDados.PostoCombustivel.TList_VendaCombustivel lVComp =
                                    new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_vendarapida = a.id_cupom " +
                                                        "and x.id_lanctovenda = a.id_lancto " +
                                                        "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                        "and x.nr_pedido = " + v.Nr_pedido.ToString() + " " +
                                                        "and x.cd_produto = '" + v.Cd_produto.Trim() + "' " +
                                                        "and x.id_pedidoitem = " + v.Id_pedidoitemstr.ToString() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
                                if (lVComp.Count.Equals(0))
                                    throw new Exception("Item combustivel não teve origem abastecimento [nItem:" + v.Id_nfitem.ToString() + "].");
                                #region encerrante
                                xml.Append("<encerrante>");

                                #region nBico
                                xml.Append("<nBico>");
                                xml.Append(lVComp[0].Ds_label.Trim());
                                xml.Append("</nBico>");
                                #endregion

                                #region nBomba
                                xml.Append("<nBomba>");
                                xml.Append(lVComp[0].Id_bombastr);
                                xml.Append("</nBomba>");
                                #endregion

                                #region nTanque
                                xml.Append("<nTanque>");
                                xml.Append(lVComp[0].Id_tanquestr);
                                xml.Append("</nTanque>");
                                #endregion

                                #region vEncIni
                                xml.Append("<vEncIni>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico - lVComp[0].Volumeabastecido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vEncIni>");
                                #endregion

                                #region vEncFin
                                xml.Append("<vEncFin>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vEncFin>");
                                #endregion

                                xml.Append("</encerrante>");
                                #endregion
                            }

                            xml.Append("</comb>\n");
                            #endregion
                        }

                        xml.Append("</prod>\n");
                        #endregion

                        //TODO Impostos do itens da nota fiscal 
                        #region imposto
                        xml.Append("<imposto>\n");
                        #region vTotTrib
                        if (v.Vl_imposto_Aprox > decimal.Zero)
                        {
                            xml.Append("<vTotTrib>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_imposto_Aprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vTotTrib>\n");
                            tot_imposto_aprox += v.Vl_imposto_Aprox;
                        }
                        #endregion
                        if (!string.IsNullOrWhiteSpace(v.Cd_ST_ICMS))
                        {
                            #region ICMS
                            xml.Append("<ICMS>\n");
                            if (!string.IsNullOrWhiteSpace(v.Cd_ST_ICMS))
                            {
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("000"))
                                {
                                    #region ICMS00
                                    xml.Append("<ICMS00>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim()); //Origem da mercadoria 
                                    //0 - Nacional 
                                    //1 - Estrangeira, importação direta 
                                    //2 - Estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("00"); //Tributação do ICMS 00-Tributada integralmente
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim()); //Modalidade de determinação da BC do ICMS
                                    //0 - Margem valor agregado (%)
                                    //1 - Pauta (valor)
                                    //2 - Preço tabelado Max. (valor)
                                    //3 - Valor da operação
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da BC do ICMS
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pICMS
                                    xml.Append("<pICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do imposto
                                    xml.Append("</pICMS>\n");
                                    #endregion

                                    #region vICMS
                                    xml.Append("<vICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                    xml.Append("</vICMS>\n");
                                    #endregion

                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }
                                    xml.Append("</ICMS00>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("010"))
                                {
                                    #region ICMS10
                                    xml.Append("<ICMS10>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    //0 - Nacional
                                    //1 - Estrangeira, importacao direta
                                    //2 - Estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("10");//Tributacao com cobranca do icms por substituicao tributaria
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim());//Modalidade de determinação da BC do ICMS
                                    //0 - Margem valor agregado (%)
                                    //1 - Pauta (valor)
                                    //2 - Preço tabelado Max. (valor)
                                    //3 - Valor da operação
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pICMS
                                    xml.Append("<pICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMS>\n");
                                    #endregion

                                    #region vICMS
                                    xml.Append("<vICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMS>\n");
                                    #endregion
                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCP>\n");

                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim());
                                    xml.Append("</modBCST>\n");
                                    #endregion

                                    #region pMVAST
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>\n");
                                    #endregion

                                    #region pRedBCST
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>\n");
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMSST>\n");
                                    #endregion
                                    if (v.Pc_FCPST > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCPST>\n");

                                        xml.Append("<pFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCPST>");

                                        xml.Append("<vFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCPST>");
                                    }
                                    xml.Append("</ICMS10>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("020"))
                                {
                                    #region ICMS20
                                    xml.Append("<ICMS20>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim()); //Origem da mercadoria
                                    //0 - Nacional
                                    //1 - Estrangeira, importação direta
                                    //2 - Estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("20"); //Tributação do ICMS 
                                    //20 - com redução de base de calculo
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim()); //Modalidade de determinação da BC do ICMS
                                    //0 - Margem valor agregado (%)
                                    //1 - Pauta (valor)
                                    //2 - Preço tabelado max. (valor)
                                    //3 - Valor operação
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region pRedBC
                                    xml.Append("<pRedBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Percentual da Redução de BC
                                    xml.Append("</pRedBC>\n");
                                    #endregion

                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da BC do ICMS
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pICMS
                                    xml.Append("<pICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do ICMS
                                    xml.Append("</pICMS>\n");
                                    #endregion

                                    #region vICMS
                                    xml.Append("<vICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                    xml.Append("</vICMS>\n");
                                    #endregion

                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCP>\n");

                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }

                                    xml.Append("</ICMS20>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("030"))
                                {
                                    #region ICMS30
                                    xml.Append("<ICMS30>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("30");
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim());
                                    xml.Append("</modBCST>\n");
                                    #endregion

                                    #region Tag pMVAST
                                    xml.Append("<pMVAST>");
                                    xml.Append("0");
                                    xml.Append("</pMVAST>\n");
                                    #endregion

                                    #region pRedBCST
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>\n");
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMSST>\n");
                                    #endregion

                                    if (v.Pc_FCPST > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCPST>\n");

                                        xml.Append("<pFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCPST>");

                                        xml.Append("<vFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCPST>");
                                    }

                                    xml.Append("</ICMS30>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("040") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("041") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("050"))
                                {
                                    #region ICMS40
                                    xml.Append("<ICMS40>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim()); //Origem da mercadoria
                                    //0 - Nacional
                                    //1 - Estrangeira, importação direta
                                    //2 - Estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().PadLeft(3, '0').Remove(0, 1)); //Tributação do ICMS
                                    //40 - isenta
                                    //41 - não tributada
                                    //50 - suspensão
                                    xml.Append("</CST>\n");
                                    #endregion

                                    xml.Append("</ICMS40>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("051"))
                                {
                                    #region ICMS51
                                    xml.Append("<ICMS51>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim()); //Origem da mercadoria
                                    //0 - nacional
                                    //1 - estrangeira, importação direta
                                    //2 - estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("51"); // Tributação do ICMS 51 - Diferimento
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim()); //Modalidade de determinação da BC do ICMS
                                    //0 - Margem valor agregado (%)
                                    //1 - Pauta (valor)
                                    //2 - Preço tabelado Máx. (valor)
                                    //3 - Valor da operação
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region pRedBC
                                    if (v.Pc_reducaobasecalcICMS > 0)
                                    {
                                        xml.Append("<pRedBC>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Percentual da redução de BC
                                        xml.Append("</pRedBC>\n");
                                    }
                                    #endregion

                                    #region vBC
                                    if (v.Vl_basecalcICMS > 0)
                                    {
                                        xml.Append("<vBC>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da BC do ICMS
                                        xml.Append("</vBC>\n");
                                    }
                                    #endregion

                                    #region pICMS
                                    if (v.Pc_aliquotaICMS > 0)
                                    {
                                        xml.Append("<pICMS>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do imposto
                                        xml.Append("</pICMS>\n");
                                    }
                                    #endregion

                                    if (v.Pc_diferidoICMS > decimal.Zero)
                                    {
                                        //decimal icms_op = decimal.Multiply(decimal.Subtract(v.Vl_basecalcICMS, decimal.Multiply(v.Pc_reducaobasecalcICMS, v.Vl_basecalcICMS)), decimal.Divide(v.Pc_aliquotaICMS, 100));
                                        #region vICMSOp
                                        xml.Append("<vICMSOp>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms + v.Vl_diferidoICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS sem diferimento
                                        xml.Append("</vICMSOp>\n");
                                        #endregion
                                        #region pDif
                                        xml.Append("<pDif>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_diferidoICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do imposto
                                        xml.Append("</pDif>\n");
                                        #endregion

                                        #region vICMSDif
                                        xml.Append("<vICMSDif>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_diferidoICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                        xml.Append("</vICMSDif>\n");
                                        #endregion

                                        #region vICMS
                                        xml.Append("<vICMS>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                        xml.Append("</vICMS>\n");
                                        #endregion
                                    }
                                    else
                                    #region vICMSOp
                                    if (v.Vl_icms > 0)
                                    {
                                        xml.Append("<vICMSOp>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                        xml.Append("</vICMSOp>\n");
                                    }
                                    #endregion

                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCP>\n");

                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }

                                    xml.Append("</ICMS51>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("060"))
                                {
                                    if (st_comb)
                                    {
                                        if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("060") && st_comb)
                                        {
                                            //Repasse ICMS Combustivel CST 60
                                            #region ICMSST
                                            xml.Append("<ICMSST>\n");
                                            #region orig
                                            xml.Append("<orig>");
                                            xml.Append("0");
                                            xml.Append("</orig>\n");
                                            #endregion
                                            #region CST
                                            xml.Append("<CST>");
                                            xml.Append(v.Cd_ST_ICMS.Trim());
                                            xml.Append("</CST>\n");
                                            #endregion
                                            #region vBCSTRet
                                            xml.Append("<vBCSTRet>");
                                            xml.Append("0.00");
                                            xml.Append("</vBCSTRet>\n");
                                            #endregion
                                            #region vICMSSTRet
                                            xml.Append("<vICMSSTRet>");
                                            xml.Append("0.00");
                                            xml.Append("</vICMSSTRet>\n");
                                            #endregion
                                            #region vBCSTDest
                                            xml.Append("<vBCSTDest>");
                                            xml.Append("0.00");
                                            xml.Append("</vBCSTDest>\n");
                                            #endregion
                                            #region vICMSSTDest
                                            xml.Append("<vICMSSTDest>");
                                            xml.Append("0.00");
                                            xml.Append("</vICMSSTDest>\n");
                                            #endregion
                                            xml.Append("</ICMSST>\n");
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        #region ICMS60
                                        xml.Append("<ICMS60>\n");

                                        #region orig
                                        xml.Append("<orig>");
                                        xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                        xml.Append("</orig>\n");
                                        #endregion

                                        #region CST
                                        xml.Append("<CST>");
                                        xml.Append("60");
                                        xml.Append("</CST>");
                                        #endregion
                                        xml.Append("</ICMS60>\n");
                                        #endregion
                                    }
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("070"))
                                {
                                    #region ICMS70
                                    xml.Append("<ICMS70>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("70");
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim());
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region pRedBC
                                    xml.Append("<pRedBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBC>\n");
                                    #endregion

                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pICMS
                                    xml.Append("<pICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMS>\n");
                                    #endregion

                                    #region vICMS
                                    xml.Append("<vICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMS>\n");
                                    #endregion

                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCP>\n");

                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim());
                                    xml.Append("</modBCST>\n");
                                    #endregion

                                    #region Tag pMVAST
                                    if (v.Pc_iva_st > decimal.Zero || v.Vl_pauta > decimal.Zero)
                                    {
                                        xml.Append("<pMVAST>");
                                        xml.Append(v.Pc_iva_st > decimal.Zero ? Convert.ToDecimal(string.Format("{0:N2}", v.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)) :
                                            v.Vl_pauta > decimal.Zero ? Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pauta)).ToString(new System.Globalization.CultureInfo("en-US", true)) : "0");
                                        xml.Append("</pMVAST>\n");
                                    }
                                    #endregion

                                    #region pRedBCST
                                    if (v.Pc_redbcstICMS > decimal.Zero)
                                    {
                                        xml.Append("<pRedBCST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pRedBCST>\n");
                                    }
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMSST>\n");
                                    #endregion
                                    if (v.Pc_FCPST > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCPST>\n");

                                        xml.Append("<pFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCPST>");

                                        xml.Append("<vFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCPST>");
                                    }
                                    xml.Append("</ICMS70>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("090"))
                                {
                                    #region ICMS90
                                    xml.Append("<ICMS90>\n");

                                    #region orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim()); //Origem da mercadoria
                                    //0 - Nacional
                                    //1 - Estrangeira, importação direta
                                    //2 - Estrangeira, adquirida no mercado interno
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CST
                                    xml.Append("<CST>");
                                    xml.Append("90"); //Tributação do ICMS 90 - Outros
                                    xml.Append("</CST>\n");
                                    #endregion

                                    #region modBC
                                    xml.Append("<modBC>");
                                    xml.Append(v.Tp_modbasecalc.Trim()); //Modalidade de determinação da BC do ICMS
                                    //0 - Margem valor agregado (%)
                                    //1 - Pauta (valor)
                                    //2 - Preço tabelado Max. (valor)
                                    //3 - Valor da operação
                                    xml.Append("</modBC>\n");
                                    #endregion

                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da BC do ICMS
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pRedBC
                                    if (v.Pc_reducaobasecalcICMS > 0)
                                    {
                                        xml.Append("<pRedBC>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Percentual da Redução de BC
                                        xml.Append("</pRedBC>\n");
                                    }
                                    #endregion

                                    #region pICMS
                                    xml.Append("<pICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do Imposto
                                    xml.Append("</pICMS>\n");
                                    #endregion

                                    #region vICMS
                                    xml.Append("<vICMS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS
                                    xml.Append("</vICMS>\n");
                                    #endregion

                                    if (v.Pc_FCP > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCP>\n");

                                        xml.Append("<pFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCP>");

                                        xml.Append("<vFCP>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCP>");
                                    }

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim()); //Modalidade de determinação da BC do ICMS ST
                                    //0 - Preço tabelado ou maximo sugerido
                                    //1 - Lista negativa (valor)
                                    //2 - Lista positiva (valor)
                                    //3 - Lista neutra (valor)
                                    //4 - Margem valor agregado (%)
                                    //5 - Pauta (valor)
                                    xml.Append("</modBCST>\n");
                                    #endregion

                                    if(v.Pc_iva_st > decimal.Zero || v.Vl_pauta > decimal.Zero)
                                    {
                                        #region Tag pMVAST
                                        xml.Append("<pMVAST>");
                                        xml.Append(v.Pc_iva_st > decimal.Zero ? Convert.ToDecimal(string.Format("{0:N2}", v.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)) :
                                            v.Vl_pauta > decimal.Zero ? Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pauta)).ToString(new System.Globalization.CultureInfo("en-US", true)) : "0");
                                        xml.Append("</pMVAST>\n");
                                        #endregion
                                    }

                                    #region pRedBCST
                                    if (v.Pc_redbcstICMS > 0)
                                    {
                                        xml.Append("<pRedBCST>");
                                        xml.Append(Convert.ToDecimal(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)))); //Valor do ICMS
                                        xml.Append("</pRedBCST>\n");
                                    }
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da BC do ICMS ST
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do imposto do ICMS ST
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do ICMS ST
                                    xml.Append("</vICMSST>\n");
                                    #endregion
                                    if (v.Pc_FCPST > decimal.Zero && !(idDest.Equals("2") && indFinal.Equals("1") && indIEDest.Equals("9")))
                                    {
                                        xml.Append("<vBCFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vBCFCPST>\n");

                                        xml.Append("<pFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pFCPST>");

                                        xml.Append("<vFCPST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCPST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vFCPST>");
                                    }
                                    xml.Append("</ICMS90>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("101"))
                                {
                                    #region ICMSSN101
                                    xml.Append("<ICMSSN101>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>\n");
                                    #endregion

                                    #region pCredSN
                                    xml.Append("<pCredSN>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</pCredSN>\n");
                                    #endregion

                                    #region vCredICMSSN
                                    xml.Append("<vCredICMSSN>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</vCredICMSSN>\n");
                                    #endregion

                                    xml.Append("</ICMSSN101>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("102") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("103") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("300") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("400"))
                                {
                                    #region ICMSSN102
                                    xml.Append("<ICMSSN102>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>\n");
                                    #endregion

                                    xml.Append("</ICMSSN102>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("201"))
                                {
                                    #region ICMSSN201
                                    xml.Append("<ICMSSN201>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>\n");
                                    #endregion

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim());
                                    xml.Append("</modBCST>\n");
                                    #endregion

                                    #region pMVAST
                                    //xml.Append("<pMVAST>");
                                    //xml.Append("0.00");
                                    //xml.Append("</pMVAST>\n");
                                    #endregion

                                    #region pRedBCST
                                    if (v.Pc_redbcstICMS > decimal.Zero)
                                    {
                                        xml.Append("<pRedBCST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</pRedBCST>\n");
                                    }
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vICMSST>\n");
                                    #endregion

                                    #region pCredSN
                                    xml.Append("<pCredSN>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pCredSN>\n");
                                    #endregion

                                    #region vCredICMSSN
                                    xml.Append("<vCredICMSSN>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</vCredICMSSN>\n");
                                    #endregion

                                    xml.Append("</ICMSSN201>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("202") ||
                                    v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("203"))
                                {
                                    #region ICMSSN202
                                    xml.Append("<ICMSSN202>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>");
                                    #endregion

                                    #region modBCST
                                    xml.Append("<modBCST>");
                                    xml.Append(v.Tp_modbasecalcST.Trim());
                                    xml.Append("</modBCST>");
                                    #endregion

                                    #region pMVAST
                                    if (v.Pc_iva_st > decimal.Zero)
                                    {
                                        xml.Append("<pMVAST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</pMVAST>");
                                    }
                                    #endregion

                                    #region pRedBCST
                                    if (v.Pc_redbcstICMS > decimal.Zero)
                                    {
                                        xml.Append("<pRedBCST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</pRedBCST>\n");
                                    }
                                    #endregion

                                    #region vBCST
                                    xml.Append("<vBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</vBCST>\n");
                                    #endregion

                                    #region pICMSST
                                    xml.Append("<pICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</pICMSST>\n");
                                    #endregion

                                    #region vICMSST
                                    xml.Append("<vICMSST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US")));
                                    xml.Append("</vICMSST>\n");
                                    #endregion

                                    xml.Append("</ICMSSN202>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("500"))
                                {
                                    #region ICMSSN500
                                    xml.Append("<ICMSSN500>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>\n");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>\n");
                                    #endregion

                                    xml.Append("</ICMSSN500>\n");
                                    #endregion
                                }
                                if (v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0').Equals("900"))
                                {
                                    #region ICMSSN900
                                    xml.Append("<ICMSSN900>\n");

                                    #region Orig
                                    xml.Append("<orig>");
                                    xml.Append(string.IsNullOrEmpty(v.Tp_origem) ? "0" : v.Tp_origem.Trim());
                                    xml.Append("</orig>");
                                    #endregion

                                    #region CSOSN
                                    xml.Append("<CSOSN>");
                                    xml.Append(v.Cd_ST_ICMS.Trim().FormatStringEsquerda(3, '0'));
                                    xml.Append("</CSOSN>");
                                    #endregion
                                    if (v.Vl_icms > decimal.Zero)
                                    {
                                        #region modBC
                                        xml.Append("<modBC>");
                                        xml.Append(v.Tp_modbasecalc.Trim());
                                        xml.Append("</modBC>\n");
                                        #endregion

                                        #region vBC
                                        xml.Append("<vBC>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</vBC>\n");
                                        #endregion

                                        #region pRedBC
                                        if (v.Pc_reducaobasecalcICMS > decimal.Zero)
                                        {
                                            xml.Append("<pRedBC>");
                                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                            xml.Append("</pRedBC>\n");
                                        }
                                        #endregion

                                        #region pICMS
                                        xml.Append("<pICMS>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</pICMS>\n");
                                        #endregion

                                        #region vICMS
                                        xml.Append("<vICMS>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</vICMS>\n");
                                        #endregion
                                    }
                                    if (v.Vl_ICMSST > decimal.Zero)
                                    {
                                        #region modBCST
                                        xml.Append("<modBCST>");
                                        xml.Append(v.Tp_modbasecalcST.Trim());
                                        xml.Append("</modBCST>\n");
                                        #endregion

                                        #region pMVAST
                                        //xml.Append("<pMVAST>");
                                        //xml.Append("0.00");
                                        //xml.Append("</pMVAST>\n");
                                        #endregion

                                        #region pRedBCST
                                        if (v.Pc_redbcstICMS > decimal.Zero)
                                        {
                                            xml.Append("<pRedBCST>");
                                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_redbcstICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                            xml.Append("</pRedBCST>\n");
                                        }
                                        #endregion

                                        #region vBCST
                                        xml.Append("<vBCST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcSTICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</vBCST>\n");
                                        #endregion

                                        #region pICMSST
                                        xml.Append("<pICMSST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaSTICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</pICMSST>\n");
                                        #endregion

                                        #region vICMSST
                                        xml.Append("<vICMSST>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ICMSST)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</vICMSST>\n");
                                        #endregion
                                    }
                                    if (v.Pc_aliquotaICMS > decimal.Zero)
                                    {
                                        #region pCredSN
                                        xml.Append("<pCredSN>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</pCredSN>\n");
                                        #endregion

                                        #region vCredICMSSN
                                        xml.Append("<vCredICMSSN>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US")));
                                        xml.Append("</vCredICMSSN>\n");
                                        #endregion
                                    }

                                    xml.Append("</ICMSSN900>\n");
                                    #endregion
                                }

                            }
                            else
                                throw new Exception("Obrigatorio informar ICMS para gerar NF-e.");
                            xml.Append("</ICMS>\n");
                            #endregion
                        }
                        if (!string.IsNullOrWhiteSpace(v.Cd_ST_IPI))
                        {
                            #region IPI
                            xml.Append("<IPI>\n");

                            #region cEnq
                            xml.Append("<cEnq>");
                            xml.Append("999"); //Valor unitario de tributação
                            xml.Append("</cEnq>\n");
                            #endregion

                            if (v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("000") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("049") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("050") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("099"))
                            {
                                #region IPITrib
                                xml.Append("<IPITrib>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Remove(0, 1)); //Valor unitario de tributação
                                xml.Append("</CST>\n");
                                #endregion

                                if (v.Vl_imposto_unit_ipi > 0)
                                {
                                    #region qUnid
                                    xml.Append("<qUnid>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                                    xml.Append("</qUnid>\n");
                                    #endregion

                                    #region vUnid
                                    xml.Append("<vUnid>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Vl_imposto_unit_ipi)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                                    xml.Append("</vUnid>\n");
                                    #endregion
                                }
                                else
                                {
                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcIPI)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pIPI
                                    xml.Append("<pIPI>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaIPI)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                                    xml.Append("</pIPI>\n");
                                    #endregion
                                }

                                #region vIPI
                                xml.Append("<vIPI>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_ipi)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                                xml.Append("</vIPI>\n");
                                #endregion

                                xml.Append("</IPITrib>\n");
                                #endregion
                            }
                            if (v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("001") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("002") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("003") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("004") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("005") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("051") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("052") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("053") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("054") ||
                                v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Equals("055"))
                            {
                                #region IPINT
                                xml.Append("<IPINT>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_IPI.Trim().FormatStringEsquerda(3, '0').Remove(0, 1)); //Valor unitario de tributação
                                xml.Append("</CST>\n");
                                #endregion

                                xml.Append("</IPINT>\n");
                                #endregion
                            }

                            xml.Append("</IPI>\n");
                            #endregion
                        }
                        if (v.Pc_aliquotaII > decimal.Zero)
                        {
                            #region II
                            xml.Append("<II>");
                            #region vBC
                            xml.Append("<vBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcII)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBC>");
                            #endregion
                            #region vDespAdu
                            xml.Append("<vDespAdu>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vDespAdu>");
                            #endregion
                            #region vII
                            xml.Append("<vII>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_II)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vII>");
                            #endregion
                            #region vIOF
                            xml.Append("<vIOF>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vIOF>");
                            #endregion
                            xml.Append("</II>");
                            #endregion
                        }
                        if (!string.IsNullOrWhiteSpace(v.Cd_ST_PIS))
                        {
                            #region PIS
                            xml.Append("<PIS>\n");

                            if (v.Cd_ST_PIS.Trim().Equals("01") ||
                                v.Cd_ST_PIS.Trim().Equals("02"))
                            {
                                #region PISAliq
                                xml.Append("<PISAliq>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_PIS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do PIS
                                //01 - Operação tributavel (base de calculo=valor da operação aliquota normal (cumulativo/não cumulativo));
                                //02 - Operação tributavel (base de calculo=valor da operação(aliquota diferenciada));
                                xml.Append("</CST>\n");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da base de calculo do PIS
                                xml.Append("</vBC>\n");
                                #endregion

                                #region pPIS
                                xml.Append("<pPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do PIS (%)
                                xml.Append("</pPIS>\n");
                                #endregion

                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do PIS
                                xml.Append("</vPIS>\n");
                                #endregion

                                xml.Append("</PISAliq>\n");
                                #endregion
                            }
                            if (v.Cd_ST_PIS.Trim().Equals("03"))
                            {
                                #region PISQtde
                                xml.Append("<PISQtde>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_PIS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do PIS
                                //03 - Operação tributavel (base de calculo=quantidade vendida x aliquota por unidade de produto);
                                xml.Append("</CST>\n");
                                #endregion

                                #region qBCProd
                                xml.Append("<qBCProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade vendida
                                xml.Append("</qBCProd>\n");
                                #endregion

                                #region vAliqProd
                                xml.Append("<vAliqProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Vl_imposto_unit_PIS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do PIS (em reais)
                                xml.Append("</vAliqProd>\n");
                                #endregion

                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do PIS
                                xml.Append("</vPIS>\n");
                                #endregion

                                xml.Append("</PISQtde>\n");
                                #endregion
                            }
                            if (v.Cd_ST_PIS.Trim().Equals("04") ||
                                v.Cd_ST_PIS.Trim().Equals("05") ||
                                v.Cd_ST_PIS.Trim().Equals("06") ||
                                v.Cd_ST_PIS.Trim().Equals("07") ||
                                v.Cd_ST_PIS.Trim().Equals("08") ||
                                v.Cd_ST_PIS.Trim().Equals("09"))
                            {
                                #region PISNT
                                xml.Append("<PISNT>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_PIS.Trim().PadLeft(2, '0'));
                                xml.Append("</CST>\n");
                                #endregion

                                xml.Append("</PISNT>\n");
                                #endregion
                            }
                            if (v.Cd_ST_PIS.Trim().Equals("49") ||
                                v.Cd_ST_PIS.Trim().Equals("50") ||
                                v.Cd_ST_PIS.Trim().Equals("51") ||
                                v.Cd_ST_PIS.Trim().Equals("52") ||
                                v.Cd_ST_PIS.Trim().Equals("53") ||
                                v.Cd_ST_PIS.Trim().Equals("54") ||
                                v.Cd_ST_PIS.Trim().Equals("55") ||
                                v.Cd_ST_PIS.Trim().Equals("56") ||
                                v.Cd_ST_PIS.Trim().Equals("60") ||
                                v.Cd_ST_PIS.Trim().Equals("61") ||
                                v.Cd_ST_PIS.Trim().Equals("62") ||
                                v.Cd_ST_PIS.Trim().Equals("63") ||
                                v.Cd_ST_PIS.Trim().Equals("64") ||
                                v.Cd_ST_PIS.Trim().Equals("65") ||
                                v.Cd_ST_PIS.Trim().Equals("66") ||
                                v.Cd_ST_PIS.Trim().Equals("67") ||
                                v.Cd_ST_PIS.Trim().Equals("70") ||
                                v.Cd_ST_PIS.Trim().Equals("71") ||
                                v.Cd_ST_PIS.Trim().Equals("72") ||
                                v.Cd_ST_PIS.Trim().Equals("73") ||
                                v.Cd_ST_PIS.Trim().Equals("74") ||
                                v.Cd_ST_PIS.Trim().Equals("75") ||
                                v.Cd_ST_PIS.Trim().Equals("98") ||
                                v.Cd_ST_PIS.Trim().Equals("99"))
                            {
                                #region PISOutr
                                xml.Append("<PISOutr>");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_PIS.Trim().PadLeft(2, '0'));
                                xml.Append("</CST>\n");
                                #endregion

                                if (v.Vl_imposto_unit_PIS <= 0)
                                {
                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pPIS
                                    xml.Append("<pPIS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pPIS>\n");
                                    #endregion
                                }
                                else
                                {
                                    #region qBCProd
                                    xml.Append("<qBCProd>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pBCProd>\n");
                                    #endregion

                                    #region vAliqProd
                                    xml.Append("<vAliqProd>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Vl_imposto_unit_PIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vAliqProd>\n");
                                    #endregion
                                }

                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPIS>\n");
                                #endregion

                                xml.Append("</PISOutr>");
                                #endregion
                            }

                            xml.Append("</PIS>\n");
                            #endregion

                            #region PIS Substituicao Tributaria
                            /*
                            if (rPIS.Vl_impostosubsttrib > decimal.Zero)
                            {
                                xml.Append("<PISST>");

                                #region Base Calculo
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>\n");
                                #endregion

                                #region Aliquota
                                xml.Append("<pPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pPIS>\n");
                                #endregion

                                #region Valor Imposto
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPIS>\n");
                                #endregion

                                xml.Append("</PISST>\n");
                            }
                            */
                            #endregion
                        }
                        if (!string.IsNullOrWhiteSpace(v.Cd_ST_COFINS))
                        {
                            #region COFINS
                            xml.Append("<COFINS>\n");

                            if (v.Cd_ST_COFINS.Trim().Equals("01") ||
                                v.Cd_ST_COFINS.Trim().Equals("02"))
                            {
                                #region COFINSAliq
                                xml.Append("<COFINSAliq>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_COFINS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do COFINS
                                xml.Append("</CST>\n");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da base de calculo
                                xml.Append("</vBC>\n");
                                #endregion

                                #region pCOFINS
                                xml.Append("<pCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota da cofins (%)
                                xml.Append("</pCOFINS>\n");
                                #endregion

                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do cofins
                                xml.Append("</vCOFINS>\n");
                                #endregion

                                xml.Append("</COFINSAliq>\n");
                                #endregion
                            }
                            if (v.Cd_ST_COFINS.Trim().Equals("03"))
                            {
                                #region COFINSQtde
                                xml.Append("<COFINSQtde>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_COFINS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do cofins
                                //03 - Operação tributavel (base de calculo = quantidade vendida x aliquota por unidade de produto);
                                xml.Append("</CST>\n");
                                #endregion

                                #region qBCProd
                                xml.Append("<qBCProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); // Quantidade vendida
                                xml.Append("</qBCProd>\n");
                                #endregion

                                #region vAliqProd
                                xml.Append("<vAliqProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Vl_imposto_unit_Cofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do cofins (valor)
                                xml.Append("</vAliqProd>\n");
                                #endregion

                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do cofins
                                xml.Append("</vCOFINS>\n");
                                #endregion

                                xml.Append("</COFINSQtde>\n");
                                #endregion
                            }
                            if (v.Cd_ST_COFINS.Trim().Equals("04") ||
                                v.Cd_ST_COFINS.Trim().Equals("05") ||
                                v.Cd_ST_COFINS.Trim().Equals("06") ||
                                v.Cd_ST_COFINS.Trim().Equals("07") ||
                                v.Cd_ST_COFINS.Trim().Equals("08") ||
                                v.Cd_ST_COFINS.Trim().Equals("09"))
                            {
                                #region COFINSNT
                                xml.Append("<COFINSNT>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_COFINS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do cofins
                                //04 - Operação tributavel (tributação monofasica(aliquota zero));
                                //06 - Operação tributavel (aliquota zero);
                                //07 - Operação isenta da contribuição
                                //08 - Operação sem incidencia da contribuição
                                //09 - Operação com suspenção da contribuição
                                xml.Append("</CST>\n");
                                #endregion

                                xml.Append("</COFINSNT>\n");
                                #endregion
                            }
                            if (v.Cd_ST_COFINS.Trim().Equals("49") ||
                                v.Cd_ST_COFINS.Trim().Equals("50") ||
                                v.Cd_ST_COFINS.Trim().Equals("51") ||
                                v.Cd_ST_COFINS.Trim().Equals("52") ||
                                v.Cd_ST_COFINS.Trim().Equals("53") ||
                                v.Cd_ST_COFINS.Trim().Equals("54") ||
                                v.Cd_ST_COFINS.Trim().Equals("55") ||
                                v.Cd_ST_COFINS.Trim().Equals("56") ||
                                v.Cd_ST_COFINS.Trim().Equals("60") ||
                                v.Cd_ST_COFINS.Trim().Equals("61") ||
                                v.Cd_ST_COFINS.Trim().Equals("62") ||
                                v.Cd_ST_COFINS.Trim().Equals("63") ||
                                v.Cd_ST_COFINS.Trim().Equals("64") ||
                                v.Cd_ST_COFINS.Trim().Equals("65") ||
                                v.Cd_ST_COFINS.Trim().Equals("66") ||
                                v.Cd_ST_COFINS.Trim().Equals("67") ||
                                v.Cd_ST_COFINS.Trim().Equals("70") ||
                                v.Cd_ST_COFINS.Trim().Equals("71") ||
                                v.Cd_ST_COFINS.Trim().Equals("72") ||
                                v.Cd_ST_COFINS.Trim().Equals("73") ||
                                v.Cd_ST_COFINS.Trim().Equals("74") ||
                                v.Cd_ST_COFINS.Trim().Equals("75") ||
                                v.Cd_ST_COFINS.Trim().Equals("98") ||
                                v.Cd_ST_COFINS.Trim().Equals("99"))
                            {
                                #region COFINSOutr
                                xml.Append("<COFINSOutr>\n");

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_ST_COFINS.Trim().PadLeft(2, '0')); //Codigo de situação tributaria do cofins
                                //99 - Outras Operações
                                xml.Append("</CST>\n");
                                #endregion

                                if (v.Vl_imposto_unit_Cofins <= 0)
                                {
                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da base de calculo da cofins
                                    xml.Append("</vBC>\n");
                                    #endregion

                                    #region pCOFINS
                                    xml.Append("<pCOFINS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota da cofins (%)
                                    xml.Append("</pCOFINS>\n");
                                    #endregion
                                }
                                else
                                {
                                    #region qBCProd
                                    xml.Append("<qBCProd>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade vendida
                                    xml.Append("</qBCProd>\n");
                                    #endregion

                                    #region vAliqProd
                                    xml.Append("<vAliqProd>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Vl_imposto_unit_Cofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do cofins (valor)
                                    xml.Append("</vAliqProd>\n");
                                    #endregion
                                }

                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true))); //valor do cofins
                                xml.Append("</vCOFINS>\n");
                                #endregion

                                xml.Append("</COFINSOutr>\n");
                                #endregion
                            }

                            xml.Append("</COFINS>\n");
                            #endregion

                            #region COFINS Substituicao Tributaria
                            /*
                            if (v.Vl_impostosubsttrib > decimal.Zero)
                            {
                                xml.Append("<COFINSST>");

                                #region Base Calculo
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCofins.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>\n");
                                #endregion

                                #region Aliquota
                                xml.Append("<pCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCofins.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pCOFINS>\n");
                                #endregion

                                #region Valor Imposto
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCofins.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCOFINS>\n");
                                #endregion

                                xml.Append("</COFINSST>\n");
                            }
                            */
                            #endregion
                        }

                        if (v.Pc_aliquotaISS > decimal.Zero)
                        {
                            #region ISSQN
                            xml.Append("<ISSQN>\n");

                            #region vBC
                            xml.Append("<vBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcISS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor da base de calculo do ISSQN
                            xml.Append("</vBC>\n");
                            #endregion

                            #region vAliq
                            xml.Append("<vAliq>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaISS)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Aliquota do ISSQN
                            xml.Append("</vAliq>\n");
                            #endregion

                            #region vISSQN
                            xml.Append("<vISSQN>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_iss)).ToString(new System.Globalization.CultureInfo("en-US"))); //Valor do ISSQN
                            xml.Append("</vISSQN>\n");
                            #endregion

                            #region cMunFG
                            xml.Append("<cMunFG>");
                            xml.Append(string.IsNullOrEmpty(p.Cd_municipioexecservico) ? p.rEndereco.rCidade.Cd_cidade.Trim() : p.Cd_municipioexecservico.Trim()); //Codigo do municipio de ocorrencia do fato gerador do ISSQN
                            xml.Append("</cMunFG>\n");
                            #endregion

                            #region cListServ
                            xml.Append("<cListServ>");
                            xml.Append(v.Id_tpservico); //Codigo da lista de serviços
                            //Informar o codigo da lista de serviços da LC 116/03 em que se classifica o serviço
                            xml.Append("</cListServ>\n");
                            #endregion

                            #region cSitTrib
                            xml.Append("<cSitTrib>");
                            xml.Append(v.Tp_tributISS.Trim());
                            xml.Append("</cSitTrib>\n");
                            #endregion

                            xml.Append("</ISSQN>\n");
                            #endregion
                        }
                        //ICMS para UF Destino
                        if (v.Pc_aliquotaICMSDest > decimal.Zero)
                        {
                            xml.Append("<ICMSUFDest>");
                            
                            xml.Append("<vBCUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true))); 
                            xml.Append("</vBCUFDest>\n");

                            xml.Append("<vBCFCPUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBCFCPUFDest>");

                            xml.Append("<pFCPUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pFCPUFDest>\n");

                            xml.Append("<pICMSUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMSDest)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMSUFDest>\n");

                            xml.Append("<pICMSInter>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMSInter>\n");

                            xml.Append("<pICMSInterPart>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", 100)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMSInterPart>\n");

                            xml.Append("<vFCPUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_FCP)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vFCPUFDest>\n");

                            xml.Append("<vICMSUFDest>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_difal)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMSUFDest>\n");

                            xml.Append("<vICMSUFRemet>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMSUFRemet>\n");
                            
                            xml.Append("</ICMSUFDest>\n");

                            tot_difal += v.Vl_difal;
                            tot_fcp += v.Vl_FCP;
                        }
                        xml.Append("</imposto>\n");
                        #endregion

                        #region infAdProd
                        if (!string.IsNullOrEmpty(v.Observacao_item))
                        {
                            string obsitem = Regex.Replace(v.Observacao_item.RemoverCaracteres().SubstCaracteresEsp().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                            xml.Append("<infAdProd>");
                            if (obsitem.Trim().Length <= 500)
                                xml.Append(obsitem.Trim()); //Informações adicionais do produto
                            else
                                xml.Append(obsitem.Trim().Substring(0, 500));
                            xml.Append("</infAdProd>\n");
                        }
                        #endregion

                        tot_item++;

                        xml.Append("</det>\n");
                    });
                    #endregion

                    #region total
                    xml.Append("<total>\n");

                    #region ICMSTot
                    xml.Append("<ICMSTot>\n");

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Where(v => v.Cd_ST_ICMS.Trim() != "201" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "202" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "203" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "500").Sum(z => z.Vl_basecalcICMS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Base de calculo do ICMS
                    xml.Append("</vBC>\n");
                    #endregion

                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Where(v => v.Cd_ST_ICMS.Trim() != "201" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "202" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "203" &&
                                                                                                v.Cd_ST_ICMS.Trim() != "500").Sum(z => z.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>\n");
                    #endregion

                    #region vICMSDeson
                    xml.Append("<vICMSDeson>");
                    xml.Append("0.00");
                    xml.Append("</vICMSDeson>\n");

                    #endregion

                    #region vFCPUFDest
                    if(tot_fcp > decimal.Zero)
                    {
                        xml.Append("<vFCPUFDest>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_fcp)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vFCPUFDest>");
                    }
                    #endregion

                    #region vICMSUFDest
                    if (tot_difal > decimal.Zero)
                    {
                        xml.Append("<vICMSUFDest>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_difal)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vICMSUFDest>\n");
                    }
                    #endregion

                    //#region vICMSUFRemet
                    //if (tot_icmsrem > decimal.Zero)
                    //{
                    //    xml.Append("<vICMSUFRemet>");
                    //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_icmsrem)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    //    xml.Append("</vICMSUFRemet>\n");
                    //}
                    //#endregion

                    #region vFCP 
                    xml.Append("<vFCP>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_fcp.Equals(decimal.Zero) ?
                        p.ItensNota.Where(v => v.Cd_ST_ICMS.Trim() != "201" &&
                                                v.Cd_ST_ICMS.Trim() != "202" &&
                                                v.Cd_ST_ICMS.Trim() != "203" &&
                                                v.Cd_ST_ICMS.Trim() != "500").Sum(z => z.Vl_FCP) : decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vFCP>");
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_basecalcSTICMS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Base de calculo do ICMS ST
                    xml.Append("</vBCST>\n");
                    #endregion

                    #region vST
                    xml.Append("<vST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_ICMSST))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vST>\n");
                    #endregion

                    xml.Append("<vFCPST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(z => z.Vl_FCPST))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vFCPST>");

                    xml.Append("<vFCPSTRet>");
                    xml.Append("0");
                    xml.Append("</vFCPSTRet>");

                    #region vProd
                    xml.Append("<vProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalProdutosServicos)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total dos produtos e serviços
                    xml.Append("</vProd>\n");
                    #endregion

                    #region vFrete
                    xml.Append("<vFrete>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_frete)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vFrete>\n");
                    #endregion

                    #region vSeg
                    xml.Append("<vSeg>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_seguro)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valot total do seguro
                    xml.Append("</vSeg>\n");
                    #endregion

                    #region vDesc
                    xml.Append("<vDesc>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_desc)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do desconto
                    xml.Append("</vDesc>\n");
                    #endregion

                    #region vII
                    xml.Append("<vII>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_II))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do II
                    xml.Append("</vII>\n");
                    #endregion

                    #region vIPI
                    xml.Append("<vIPI>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_ipi))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do IPI
                    xml.Append("</vIPI>\n");
                    #endregion

                    xml.Append("<vIPIDevol>");
                    xml.Append("0");
                    xml.Append("</vIPIDevol>");

                    #region vPIS
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_pis))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor PIS
                    xml.Append("</vPIS>\n");
                    #endregion

                    #region vCOFINS
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_cofins))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do cofins
                    xml.Append("</vCOFINS>\n");
                    #endregion

                    #region vOutro
                    xml.Append("<vOutro>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_outrasdesp + p.Vl_juro_fin)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Outras despesas acessorias
                    xml.Append("</vOutro>\n");
                    #endregion

                    #region vNF
                    xml.Append("<vNF>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalnota)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total da NF-e
                    xml.Append("</vNF>\n");
                    #endregion

                    if (tot_imposto_aprox > decimal.Zero)
                    {
                        xml.Append("<vTotTrib>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_imposto_aprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vTotTrib>\n");
                    }

                    xml.Append("</ICMSTot>\n");
                    #endregion

                    if (p.ItensNota.Sum(v => v.Vl_iss) > 0)
                    {
                        #region ISSQNtot
                        xml.Append("<ISSQNtot>\n");

                        #region vServ
                        if (p.Vl_totalservicos > 0)
                        {
                            xml.Append("<vServ>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalservicos)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vServ>\n");
                        }
                        #endregion

                        #region vBC
                        xml.Append("<vBC>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", (p.ItensNota.Sum(v => v.Vl_basecalcISS)))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vBC>\n");
                        #endregion

                        #region vISS
                        xml.Append("<vISS>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", (p.ItensNota.Sum(v => v.Vl_iss)))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vISS>\n");
                        #endregion

                        #region vPIS
                        if (p.ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_pis) > 0)
                        {
                            xml.Append("<vPIS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_pis))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vPIS>\n");
                        }
                        #endregion

                        #region vCOFINS
                        if (p.ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_cofins) > 0)
                        {
                            xml.Append("<vCOFINS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_cofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vCOFINS>\n");
                        }
                        #endregion

                        xml.Append("</ISSQNtot>\n");
                        #endregion
                    }

                    if ((p.ItensNota.Sum(v => v.Vl_retidoPIS) > 0) ||
                        (p.ItensNota.Sum(v => v.Vl_retidoCofins) > 0) ||
                        (p.ItensNota.Sum(v => v.Vl_retidoCSLL) > 0) ||
                        (p.ItensNota.Sum(v => v.Vl_retidoIRRF) > 0) ||
                        (p.ItensNota.Sum(v => v.Vl_retidoINSS) > 0))
                    {
                        #region retTrib
                        xml.Append("<retTrib>\n");

                        if (p.ItensNota.Sum(v => v.Vl_retidoPIS) > 0)
                        {
                            #region vRetPIS
                            xml.Append("<vRetPIS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_retidoPIS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido PIS
                            xml.Append("</vRetPIS>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_retidoCofins) > 0)
                        {
                            #region vRetCOFINS
                            xml.Append("<vRetCOFINS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_retidoCofins))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vRetCOFINS>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_retidoCSLL) > 0)
                        {
                            #region vRetCSLL
                            xml.Append("<vRetCSLL>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_retidoCSLL))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vRetCSLL>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_basecalcIRRF) > 0)
                        {
                            #region vBCIRRF
                            xml.Append("<vBCIRRF>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_basecalcIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vBCIRRF>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_retidoIRRF) > 0)
                        {
                            #region vIRRF
                            xml.Append("<vIRRF>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_retidoIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vIRRF>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_basecalcINSS) > 0)
                        {
                            #region vBCRetPrev
                            xml.Append("<vBCRetPrev>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_basecalcINSS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vBCRetPrev>\n");
                            #endregion
                        }

                        if (p.ItensNota.Sum(v => v.Vl_issretido) > 0)
                        {
                            #region vRetPrev
                            xml.Append("<vRetPrev>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v => v.Vl_issretido))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                            xml.Append("</vRetPrev>\n");
                            #endregion
                        }

                        xml.Append("</retTrib>\n");
                        #endregion
                    }
                    xml.Append("</total>\n");
                    #endregion

                    #region transp
                    xml.Append("<transp>\n");

                    #region modFrete
                    xml.Append("<modFrete>");
                    xml.Append(p.Freteporconta.Trim()); //Modalidade do frete
                    xml.Append("</modFrete>\n");
                    #endregion

                    if (!string.IsNullOrEmpty(p.Nm_razaosocialtransp))
                    {
                        #region transporta
                        xml.Append("<transporta>\n");

                        if (!string.IsNullOrEmpty(p.Cpf_transp))
                            if (p.Cpf_transp.SoNumero().Length.Equals(14))
                            {
                                #region CNPJ
                                xml.Append("<CNPJ>");
                                xml.Append(p.Cpf_transp.SoNumero().FormatStringEsquerda(14, '0')); //Valor do ISSQN
                                xml.Append("</CNPJ>\n");
                                #endregion
                            }
                            else
                            {
                                #region CPF
                                xml.Append("<CPF>");
                                xml.Append(p.Cpf_transp.SoNumero().FormatStringEsquerda(11, '0')); //Valor do ISSQN
                                xml.Append("</CPF>\n");
                                #endregion
                            }

                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(p.Nm_razaosocialtransp.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Valor do ISSQN
                        xml.Append("</xNome>\n");
                        #endregion

                        if (!string.IsNullOrEmpty(p.Uf_transp))
                        {
                            #region IE
                            xml.Append("<IE>");
                            xml.Append(string.IsNullOrEmpty(p.Insc_estadualtransp) ? "ISENTO" : Regex.Replace(p.Insc_estadualtransp.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)); //Valor do ISSQN
                            xml.Append("</IE>\n");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Ds_enderecotransp))
                        {
                            #region xEnder
                            xml.Append("<xEnder>");
                            xml.Append(p.Ds_enderecotransp.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Valor do ISSQN
                            xml.Append("</xEnder>\n");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Ds_cidadetransp))
                        {
                            #region xMun
                            xml.Append("<xMun>");
                            xml.Append(p.Ds_cidadetransp.RemoverCaracteres().SubstCaracteresEsp().Trim()); //Valor do ISSQN
                            xml.Append("</xMun>\n");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Uf_transp))
                        {
                            #region UF
                            xml.Append("<UF>");
                            xml.Append(p.Uf_transp.Trim()); //Valor do ISSQN
                            xml.Append("</UF>\n");
                            #endregion
                        }

                        xml.Append("</transporta>\n");
                        #endregion
                    }

                    if ((!string.IsNullOrEmpty(p.Placaveiculo)) &&
                        (!string.IsNullOrEmpty(p.Ufveiculo)))
                    {
                        #region veicTransp
                        xml.Append("<veicTransp>\n");

                        #region placa
                        xml.Append("<placa>");
                        xml.Append(p.Placaveiculo.Trim());
                        xml.Append("</placa>\n");
                        #endregion

                        #region UF
                        xml.Append("<UF>");
                        xml.Append(p.Ufveiculo.Trim());
                        xml.Append("</UF>\n");
                        #endregion

                        xml.Append("</veicTransp>\n");
                        #endregion
                    }

                    if (p.Quantidade > 0)
                    {
                        #region vol
                        xml.Append("<vol>\n");

                        #region qVol
                        xml.Append("<qVol>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N0}", p.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</qVol>\n");
                        #endregion

                        if (!string.IsNullOrEmpty(p.Especie))
                        {
                            #region esp
                            xml.Append("<esp>");
                            xml.Append(p.Especie.Trim());
                            xml.Append("</esp>\n");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Marca))
                        {
                            #region marca
                            xml.Append("<marca>");
                            xml.Append(p.Marca.Trim());
                            xml.Append("</marca>\n");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Numero))
                        {
                            #region nVol
                            xml.Append("<nVol>");
                            xml.Append(p.Numero.Trim());
                            xml.Append("</nVol>\n");
                            #endregion
                        }

                        if (p.Pesoliquido > 0)
                        {
                            #region pesoL
                            xml.Append("<pesoL>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N3}", p.Pesoliquido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pesoL>\n");
                            #endregion
                        }

                        if (p.Pesobruto > 0)
                        {
                            #region pesoB
                            xml.Append("<pesoB>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N3}", p.Pesobruto)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pesoB>\n");
                            #endregion
                        }

                        xml.Append("</vol>\n");
                        #endregion
                    }
                    xml.Append("</transp>\n");
                    #endregion

                    #region pag
                    xml.Append("<pag>");
                    xml.Append("<detPag>");
                    if (p.rCmi.St_devolucaobool ||
                        p.rCmi.St_complementarbool ||
                        new CamadaDados.Faturamento.PDV.TCD_DevolucaoCF().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lanctofiscal",
                                        vOperador = "=",
                                        vVL_Busca = p.Nr_lanctofiscalstr
                                    }
                                }, "1") != null ||
                        new TCD_ECFVinculadoNF().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_lanctofiscal",
                                    vOperador = "=",
                                    vVL_Busca = p.Nr_lanctofiscalstr
                                }
                            }, "1") != null)
                    {
                        xml.Append("<tPag>");
                        xml.Append("90");//Sem Pagamento
                        xml.Append("</tPag>");
                        xml.Append("<vPag>");
                        xml.Append("0");
                        xml.Append("</vPag>");
                    }
                    else
                    {
                        xml.Append("<tPag>");
                        xml.Append("99");//Outros
                        xml.Append("</tPag>");
                        xml.Append("<vPag>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalnota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vPag>");
                    }
                    xml.Append("</detPag>");
                    xml.Append("</pag>");
                    #endregion

                    if ((!string.IsNullOrEmpty(p.Obsfiscal)) ||
                        (!string.IsNullOrEmpty(p.Dadosadicionais)))
                    {
                        #region infAdic
                        xml.Append("<infAdic>");

                        if (!string.IsNullOrEmpty(p.Obsfiscal))
                        {
                            #region infAdFisco
                            string obsfiscal = Regex.Replace(p.Obsfiscal.RemoverCaracteres().SubstCaracteresEsp().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                            xml.Append("<infAdFisco>");
                            xml.Append(obsfiscal.Trim().Length > 2000 ? obsfiscal.Trim().Substring(0, 2000) : obsfiscal.Trim());
                            xml.Append("</infAdFisco>");
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(p.Dadosadicionais))
                        {
                            #region infCpl
                            string dadosadicionais = Regex.Replace(p.Dadosadicionais.RemoverCaracteres().SubstCaracteresEsp().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                            xml.Append("<infCpl>");
                            xml.Append(dadosadicionais.Trim().Length > 5000 ? dadosadicionais.Trim().Substring(0, 5000) : dadosadicionais.Trim());
                            xml.Append("</infCpl>");
                            #endregion
                        }

                        xml.Append("</infAdic>\n");
                        #endregion
                    }

                    if (p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("E") &&
                        p.Tp_movimento.Trim().ToUpper().Equals("S") &&
                        !p.rCmi.St_devolucaobool)
                    {
                        xml.Append("<exporta>");

                        xml.Append("<UFSaidaPais>");
                        xml.Append(p.Uf_saidaex.Trim());
                        xml.Append("</UFSaidaPais>\n");

                        xml.Append("<xLocExporta>");
                        xml.Append(p.Ds_localex.Trim());
                        xml.Append("</xLocExporta>\n");

                        xml.Append("</exporta>\n");
                    }

                    xml.Append("</infNFe>\n");
                    #endregion

                    xml.Append("</NFe>\n");
                    #endregion

                    //Assinar XML
                    xmlassinado = new Utils.Assinatura.TAssinatura2(rCfgNfe.Nr_certificado_nfe,
                                                                    Utils.Assinatura.TAssinatura2.TTpArq.tpEnviaNFE,
                                                                    xml.ToString()).Assinar();
                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "nfe_v" + rCfgNfe.Cd_versao + ".xsd",
                                                            "NFE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                }
                else
                    xmlassinado = p.Xml_Nfe.Trim();

                if (!St_consulta)
                {
                    try
                    {
                        //Chave de acesso
                        p.Chave_acesso_nfe = MontarChaveAcessoNfe(p, rCfgNfe) + CalcularDigitoChave(MontarChaveAcessoNfe(p, rCfgNfe));
                        p.tp_emissaonfe = rCfgNfe.St_nfecontingencia ? rCfgNfe.Tp_ambientecont.Trim().ToUpper().Equals("N") ? "6" : "7" : "1";
                        TCN_LanFaturamento.AlterarFaturamento(p, null);
                        p.Xml_Nfe = xmlassinado;
                    }
                    catch { }
                }
                else
                {
                    //Buscar registro Lote NFe X Nota Fiscal
                    CamadaDados.Faturamento.NFE.TList_LanLoteNFE_X_NotaFiscal lNfe =
                        CamadaNegocio.Faturamento.NFE.TCN_LanLoteNFE_X_NotaFiscal.Buscar(string.Empty,
                                                                                         p.Cd_empresa,
                                                                                         p.Nr_lanctofiscal.ToString(),
                                                                                         string.Empty,
                                                                                         null);
                    if (lNfe.Count > 0)
                    {
                        //Versao do xml
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xmlassinado);
                        string xmlLote = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
                        xmlLote += "<nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + doc.DocumentElement["infNFe"].Attributes["versao"].InnerText + "\">\n";
                        xmlLote += xmlassinado + "\n";
                        xmlLote += "<protNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + doc.DocumentElement["infNFe"].Attributes["versao"].InnerText + "\">\n";
                        xmlLote += "<infProt>\n";
                        xmlLote += "<tpAmb>" + tp_ambiente + "</tpAmb>\n";
                        xmlLote += "<verAplic>" + lNfe[0].Veraplic.Trim() + "</verAplic>\n";
                        xmlLote += "<chNFe>" + p.Chave_acesso_nfe.Trim() + "</chNFe>\n";
                        xmlLote += "<dhRecbto>" + (lNfe[0].Dt_processamento.HasValue ? lNfe[0].Dt_processamento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz") : string.Empty) + "</dhRecbto>\n";
                        xmlLote += "<nProt>" + (lNfe[0].Nr_protocolo.HasValue ? lNfe[0].Nr_protocolo.Value.ToString() : string.Empty) + "</nProt>\n";
                        xmlLote += "<digVal>" + lNfe[0].Digitoverificado.Trim() + "</digVal>\n";
                        xmlLote += "<cStat>" + (lNfe[0].Status.HasValue ? lNfe[0].Status.Value.ToString() : string.Empty) + "</cStat>\n";
                        xmlLote += "<xMotivo>" + lNfe[0].Ds_mensagem.Trim() + "</xMotivo>\n";
                        xmlLote += "</infProt>\n";
                        xmlLote += "</protNFe>\n";
                        xmlLote += "</nfeProc>";

                        p.Xml_Nfe = xmlLote;
                    }
                }
            });
        }

        //Gerar Arquivo XML das notas fiscais eletronicas para serem assinadas
        public static void GerarArqXML(ref List<TRegistro_LanFaturamento> lNf,
                                       CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            if (lNf == null)
                lNf = BuscarNfs(rCfgNfe);
            CriarArquivoXml(lNf, false, rCfgNfe);
        }

        //Metodo para gerar arquivo xml das notas que ja foram enviadas para a receita durante um certo periodo
        public static string GerarArqXmlPeriodo(string vPath_xml,
                                              string Cd_clifor,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string Cd_empresa,
                                              string Nr_notafiscal,
                                              CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            try
            {
                string retorno = string.Empty;
                //Criar arquivo xml
                TList_RegLanFaturamento lNfe = BuscarNfsXml(Cd_empresa,
                                                            Cd_clifor,
                                                            Nr_notafiscal,
                                                            Dt_ini,
                                                            Dt_fin,
                                                            true);
                CriarArquivoXml(lNfe,
                                true,
                                rCfgNfe);
                //Path XML
                if (vPath_xml.Trim().Substring(vPath_xml.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath_xml += System.IO.Path.DirectorySeparatorChar.ToString();
                lNfe.ForEach(p =>
                    {
                        //Versao do xml
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(p.Xml_Nfe);
                        Utils.ValidaSchema.ValidaXML2.validaXML(p.Xml_Nfe,
                                                        rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "procNFe_v" + doc["nfeProc"].Attributes["versao"].InnerText + ".xsd",
                                                        "NFE");
                        if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                            retorno += Utils.ValidaSchema.ValidaXML2.Retorno.Trim() + "\r\n";
                        else
                        {
                            //Salvar arquivo no Path indicado 
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() + doc["nfeProc"]["NFe"]["infNFe"].Attributes["Id"].InnerText.Trim().Remove(0, 3) + "-nfe.xml"))
                            {
                                sw.Write(p.Xml_Nfe.Trim());
                                sw.Flush();
                                sw.Close();
                            }
                            //Buscar Eventos NFe
                            CamadaNegocio.Faturamento.NFE.TCN_EventoNFe.Buscar(string.Empty,
                                                                               p.Cd_empresa,
                                                                               p.Nr_lanctofiscalstr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               "'T'",
                                                                                null).ForEach(v =>
                                                                                {
                                                                                    StringBuilder xml = new StringBuilder();
                                                                                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                                                                    xml.Append("<procEventoNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + rCfgNfe.Cd_versao.Trim() + "\">");
                                                                                    xml.Append(v.Xml_evento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty).Replace(" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", string.Empty));
                                                                                    xml.Append(v.Xml_retevento.Replace(" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", string.Empty));
                                                                                    xml.Append("</procEventoNFe>");
                                                                                    //Salvar arquivo no Path indicado 
                                                                                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() +
                                                                                                                                                  v.Cd_eventostr.Trim() + "-" +
                                                                                                                                                  p.Chave_acesso_nfe.Trim() + "-procEventoNFe.xml"))
                                                                                    {
                                                                                        sw.Write(xml.ToString());
                                                                                        sw.Flush();
                                                                                        sw.Close();
                                                                                    }
                                                                                });
                        }
                    });
                return retorno;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
    }
}
