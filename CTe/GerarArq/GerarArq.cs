using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Frota.Cadastros;
using CamadaDados.Faturamento.CTRC;
using System.Xml;

namespace CTe.GerarArq
{
    public class TGerarArq
    {
        public static string MontarChaveAcessoCte(TRegistro_ConhecimentoFrete val,
                                                  CamadaDados.Diversos.TRegistro_CadEmpresa Empresa,
                                                  TRegistro_CfgFrota rCfgCte)
        {
            return Empresa.rEndereco.Cd_uf.Trim() + //Codigo UF Empresa
                   Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Year.ToString().FormatStringEsquerda(2, '0') + //Ano Emissao
                   Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Month.ToString().FormatStringEsquerda(2, '0') + //Mes Emissao
                   Empresa.rClifor.Nr_cgc.SoNumero() + //CNPJ Empresa
                   val.Cd_modelo.Trim() + //Modelo
                   val.Nr_serie.FormatStringEsquerda(3, '0') + //Serie
                   val.Nr_ctrc.FormatStringEsquerda(9, '0') + //Numero CTe
                   (rCfgCte.St_ctecontingencia ? rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS") ? "7" : "8" : "1") + //Tipo Emissao CTe
                   val.Nr_lanctoCTRC.FormatStringEsquerda(8, '0');
        }

        public static string CalcularDigitoChave(string vChave)
        {
            return Utils.Estruturas.Mod11(System.Text.RegularExpressions.Regex.Replace(vChave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
        }

        private static void CriarArquivoXml(List<TRegistro_ConhecimentoFrete> lCte,
                                            TRegistro_CfgFrota rCfg)
        {
            //Validar Certificado
            lCte.ForEach(p =>
            {
                if (p.Status_cte != null && !string.IsNullOrWhiteSpace(p.Xml_cte))
                    if (p.Cd_empresa == rCfg.Cd_empresa && p.Status_cte.Value.Equals(100))
                    {

                        string tp_ambiente = string.Empty;
                        //Se for consulta, buscar tipo ambiente
                        object obj = new TCD_LoteCTe().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_CTR_Lote_X_CTe x " +
                                                        "where x.id_lote = a.id_lote " +
                                                        "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                        "and x.nr_lanctoCTR = " + p.Nr_lanctoCTRC.ToString() + ")"
                                        }
                                    }, "a.Tp_Ambiente");
                        if (obj != null)
                            tp_ambiente = obj.ToString();
                        //Buscar Empresa CTe
                        CamadaDados.Diversos.TRegistro_CadEmpresa Empresa =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(p.Cd_empresa, string.Empty, string.Empty, null)[0];
                        string xmlassinado = p.Xml_cte.Trim();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(p.Xml_cte);
                        string versao = doc.LastChild.FirstChild.Attributes.GetNamedItem("versao").InnerText;
                        //Buscar registro Lote CTe X Nota Fiscal
                        TList_Lote_X_CTe lCTE =
                            CamadaNegocio.Faturamento.CTRC.TCN_Lote_X_CTe.Buscar(p.Cd_empresa,
                                                                                 string.Empty,
                                                                                 p.Nr_lanctoCTRC.ToString(),
                                                                                 null);
                        if (lCTE.Count > 0)
                        {
                            string xmlLote = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
                            xmlLote += "<cteProc xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + versao.Trim() + "\">\n";
                            xmlLote += xmlassinado + "\n";
                            xmlLote += "<protCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + versao.Trim() + "\">\n";
                            xmlLote += "<infProt Id=\"ID" + lCTE[0].Nr_protocolostr + "\">\n";
                            xmlLote += "<tpAmb>" + tp_ambiente + "</tpAmb>\n";
                            xmlLote += "<verAplic>" + lCTE[0].VerAplic.Trim() + "</verAplic>\n";
                            xmlLote += "<chCTe>" + p.Chaveacesso.Trim() + "</chCTe>\n";
                            xmlLote += "<dhRecbto>" + (lCTE[0].Dt_processamento.HasValue ? lCTE[0].Dt_processamento.Value.ToString("yyyy-MM-ddTHH:MM:ss") : string.Empty) + "</dhRecbto>\n";
                            xmlLote += "<nProt>" + (lCTE[0].Nr_protocolo.HasValue ? lCTE[0].Nr_protocolo.Value.ToString() : string.Empty) + "</nProt>\n";
                            xmlLote += "<digVal>" + lCTE[0].Digval.Trim() + "</digVal>\n";
                            xmlLote += "<cStat>" + (lCTE[0].Status.HasValue ? lCTE[0].Status.Value.ToString() : string.Empty) + "</cStat>\n";
                            xmlLote += "<xMotivo>" + lCTE[0].Ds_mensagem.Trim() + "</xMotivo>\n";
                            xmlLote += "</infProt>\n";
                            xmlLote += "</protCTe>\n";
                            xmlLote += "</cteProc>";

                            p.Xml_cte = xmlLote;

                            //Validar Schema XML
                            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                                    rCfg.Path_schemas.SeparadorDiretorio() + "cte_v" + versao.Trim() + ".xsd",
                                                                    "CTE");
                        }
                    }
            });
        }

        public static void GerarArquivoXml(List<TRegistro_ConhecimentoFrete> lCte,
                                           TRegistro_CfgFrota rCfgCte)
        {
            lCte.ForEach(p =>
                {
                    //Buscar componentes valor frete
                    p.lCompValorFrete = CamadaNegocio.Faturamento.CTRC.TCN_CTRCompValorFrete.Buscar(p.Cd_empresa,
                                                                                                    p.Nr_lanctoCTRC.Value.ToString(),
                                                                                                    null);
                    //Buscar quantidade carga
                    p.lQtdeCarga = CamadaNegocio.Faturamento.CTRC.TCN_CTRQtdeCarga.Buscar(p.Cd_empresa,
                                                                                          p.Nr_lanctoCTRC.Value.ToString(),
                                                                                          null);
                    //Buscar Empresa CTe
                    CamadaDados.Diversos.TRegistro_CadEmpresa Empresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(p.Cd_empresa, string.Empty, string.Empty, null)[0];
                    string xmlassinado = string.Empty;
                    StringBuilder xml = new StringBuilder();
                    #region Cte
                    xml.Append("<CTe xmlns=\"http://www.portalfiscal.inf.br/cte\">");
                    #region infCte
                    xml.Append("<infCte Id=\"CTe" + MontarChaveAcessoCte(p, Empresa, rCfgCte) + CalcularDigitoChave(MontarChaveAcessoCte(p, Empresa, rCfgCte)) + "\" versao=\"" + rCfgCte.Cd_versaolayout.Trim() + "\">");
                    #region ide
                    xml.Append("<ide>");
                    #region UF Emitente
                    xml.Append("<cUF>");
                    xml.Append(Empresa.rEndereco.Cd_uf.Trim());
                    xml.Append("</cUF>");
                    #endregion
                    #region cCT
                    xml.Append("<cCT>");
                    xml.Append(p.Nr_lanctoCTRC.Value.FormatStringEsquerda(8, '0'));
                    xml.Append("</cCT>");
                    #endregion
                    #region CFOP
                    xml.Append("<CFOP>");
                    xml.Append(p.Cd_cfop.Trim());
                    xml.Append("</CFOP>");
                    #endregion
                    #region natOp
                    xml.Append("<natOp>");
                    xml.Append(p.Ds_movimentacao.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</natOp>");
                    #endregion
                    #region mod
                    xml.Append("<mod>");
                    xml.Append(p.Cd_modelo.Trim());
                    xml.Append("</mod>");
                    #endregion
                    #region serie
                    xml.Append("<serie>");
                    xml.Append(p.Nr_serie.Trim());
                    xml.Append("</serie>");
                    #endregion
                    #region nCT
                    xml.Append("<nCT>");
                    xml.Append(p.Nr_ctrc.Value.ToString());
                    xml.Append("</nCT>");
                    #endregion
                    #region dhEmi
                    xml.Append("<dhEmi>");
                    xml.Append(p.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    xml.Append("</dhEmi>");
                    #endregion
                    #region tpImp
                    xml.Append("<tpImp>");
                    xml.Append("1");//Retrato
                    xml.Append("</tpImp>");

                    #endregion
                    #region tpEmis
                    xml.Append("<tpEmis>");
                    xml.Append(rCfgCte.St_ctecontingencia ? rCfgCte.Tp_ambientecont.Trim().ToUpper().Equals("RS") ? "7" : "8" : "1");//Normal
                    xml.Append("</tpEmis>");

                    #endregion
                    #region cDV
                    xml.Append("<cDV>");
                    xml.Append(CalcularDigitoChave(MontarChaveAcessoCte(p, Empresa, rCfgCte)));
                    xml.Append("</cDV>");
                    #endregion
                    #region tpAmb
                    xml.Append("<tpAmb>");
                    xml.Append(rCfgCte.Tp_ambiente.Trim());
                    xml.Append("</tpAmb>");
                    #endregion
                    #region tpCTe
                    xml.Append("<tpCTe>");
                    xml.Append(p.Tp_cte.Trim());
                    xml.Append("</tpCTe>");
                    #endregion
                    #region procEmi
                    xml.Append("<procEmi>");
                    xml.Append("0");//Aplicativo contribuinte
                    xml.Append("</procEmi>");
                    #endregion
                    #region verProc
                    xml.Append("<verProc>");
                    xml.Append(rCfgCte.Cd_versaolayout);
                    xml.Append("</verProc>");
                    #endregion
                    #region cMunEnv
                    xml.Append("<cMunEnv>");
                    xml.Append(Empresa.rEndereco.Cd_cidade.Trim());
                    xml.Append("</cMunEnv>");
                    #endregion
                    #region xMunEnv
                    xml.Append("<xMunEnv>");
                    xml.Append(Empresa.rEndereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMunEnv>");
                    #endregion
                    #region UFEnv
                    xml.Append("<UFEnv>");
                    xml.Append(Empresa.rEndereco.UF.Trim());
                    xml.Append("</UFEnv>");
                    #endregion
                    #region modal
                    xml.Append("<modal>");
                    xml.Append(p.Tp_modalidade.Trim());
                    xml.Append("</modal>");
                    #endregion
                    #region tpServ
                    xml.Append("<tpServ>");
                    xml.Append(p.Tp_servico.Trim());
                    xml.Append("</tpServ>");
                    #endregion
                    #region cMunIni
                    xml.Append("<cMunIni>");
                    xml.Append(p.Cd_cidade_ini.Trim());
                    xml.Append("</cMunIni>");
                    #endregion
                    #region xMunIni
                    xml.Append("<xMunIni>");
                    xml.Append(p.Ds_cidade_ini.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMunIni>");
                    #endregion
                    #region UFIni
                    xml.Append("<UFIni>");
                    xml.Append(p.Uf_ini.Trim());
                    xml.Append("</UFIni>");
                    #endregion
                    #region cMunFim
                    xml.Append("<cMunFim>");
                    xml.Append(p.Cd_cidade_fin.Trim());
                    xml.Append("</cMunFim>");
                    #endregion
                    #region xMunFim
                    xml.Append("<xMunFim>");
                    xml.Append(p.Ds_cidade_fin.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMunFim>");
                    #endregion
                    #region UFFim
                    xml.Append("<UFFim>");
                    xml.Append(p.Uf_fin.Trim());
                    xml.Append("</UFFim>");
                    #endregion
                    #region retira
                    xml.Append("<retira>");
                    xml.Append(p.St_receberretira.Trim());
                    xml.Append("</retira>");
                    #endregion
                    #region xDetRetira
                    if (!string.IsNullOrEmpty(p.Ds_retira))
                    {
                        xml.Append("<xDetRetira>");
                        xml.Append(p.Ds_retira.Trim().SubstCaracteresEsp());
                        xml.Append("</xDetRetira>");
                    }
                    #endregion
                    //Buscar dados Tomador
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rTomador =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_tomador, null);
                    //Buscar endereco Tomador
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco rEndTomador =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_tomador,
                                                                                  p.Cd_endtomador,
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
                                                                                  null)[0];
                    #region indIEToma
                    xml.Append("<indIEToma>");
                    xml.Append(rEndTomador.St_naocontribuintebool ? "9" : "1"); 
                    xml.Append("</indIEToma>");
                    #endregion
                    #region toma3
                    if (!p.Tp_tomador.Trim().Equals("4"))
                    {
                        xml.Append("<toma3>");
                        #region toma
                        xml.Append("<toma>");
                        xml.Append(p.Tp_tomador.Trim());
                        xml.Append("</toma>");
                        #endregion
                        xml.Append("</toma3>");
                    }
                    #endregion
                    #region toma4
                    if (p.Tp_tomador.Trim().Equals("4"))
                    {
                        xml.Append("<toma4>");
                        #region toma
                        xml.Append("<toma>");
                        xml.Append(p.Tp_tomador.Trim());
                        xml.Append("</toma>");
                        #endregion
                        #region CNPJ
                        if (rTomador.Tp_pessoa.Trim().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(rTomador.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion
                        #region CPF
                        if (rTomador.Tp_pessoa.Trim().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(rTomador.Nr_cpf.SoNumero());
                            xml.Append("</CPF>");
                        }
                        #endregion
                        #region IE
                        if (!string.IsNullOrEmpty(rEndTomador.Insc_estadual))
                        {
                            xml.Append("<IE>");
                            xml.Append(rEndTomador.Insc_estadual);
                            xml.Append("</IE>");
                        }
                        #endregion
                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(rTomador.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xNome>");
                        #endregion
                        #region xFant
                        if (!string.IsNullOrEmpty(rTomador.Nm_fantasia))
                        {
                            xml.Append("<xFant>");
                            xml.Append(rTomador.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xFant>");
                        }
                        #endregion
                        #region fone
                        if (!string.IsNullOrEmpty(rEndTomador.Fone.SoNumero()))
                        {
                            xml.Append("<fone>");
                            xml.Append(rEndTomador.Fone.SoNumero());
                            xml.Append("</fone>");
                        }
                        #endregion
                        #region enderToma
                        xml.Append("<enderToma>");
                        #region xLgr
                        xml.Append("<xLgr>");
                        xml.Append(rEndTomador.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xLgr>");
                        #endregion
                        #region nro
                        xml.Append("<nro>");
                        xml.Append(rEndTomador.Numero.RemoverCaracteres().SubstCaracteresEsp());
                        xml.Append("</nro>");
                        #endregion
                        #region xCpl
                        if (!string.IsNullOrEmpty(rEndTomador.Ds_complemento))
                        {
                            xml.Append("<xCpl>");
                            xml.Append(rEndTomador.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xCpl>");
                        }
                        #endregion
                        #region xBairro
                        xml.Append("<xBairro>");
                        xml.Append(rEndTomador.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xBairro>");
                        #endregion
                        #region cMun
                        xml.Append("<cMun>");
                        xml.Append(rEndTomador.Cd_cidade.Trim());
                        xml.Append("</cMun>");
                        #endregion
                        #region xMun
                        xml.Append("<xMun>");
                        xml.Append(rEndTomador.DS_Cidade.Trim());
                        xml.Append("</xMun>");
                        #endregion
                        #region CEP
                        if (!string.IsNullOrEmpty(rEndTomador.Cep.SoNumero()))
                        {
                            xml.Append("<CEP>");
                            xml.Append(rEndTomador.Cep.SoNumero());
                            xml.Append("</CEP>");
                        }
                        #endregion
                        #region UF
                        xml.Append("<UF>");
                        xml.Append(rEndTomador.UF.Trim());
                        xml.Append("</UF>");
                        #endregion
                        #region cPais
                        if (!string.IsNullOrEmpty(rEndTomador.CD_Pais))
                        {
                            xml.Append("<cPais>");
                            xml.Append(rEndTomador.CD_Pais.Trim());
                            xml.Append("</cPais>");
                        }
                        #endregion
                        #region xPais
                        if (!string.IsNullOrEmpty(rEndTomador.NM_Pais))
                        {
                            xml.Append("<xPais>");
                            xml.Append(rEndTomador.NM_Pais.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xPais>");
                        }
                        #endregion
                        xml.Append("</enderToma>");
                        #endregion
                        #region email
                        if (!string.IsNullOrEmpty(rTomador.Email))
                        {
                            xml.Append("<email>");
                            xml.Append(rTomador.Email.Trim());
                            xml.Append("</email>");
                        }
                        #endregion
                        xml.Append("</toma4>");
                    }
                    #endregion
                    xml.Append("</ide>");
                    #endregion

                    #region compl
                    if (!string.IsNullOrEmpty(p.Ds_observacoes))
                    {
                        xml.Append("<compl>");
                        #region xObs
                        xml.Append("<xObs>");
                        xml.Append(p.Ds_observacoes.Trim());
                        xml.Append("</xObs>");
                        #endregion
                        xml.Append("</compl>");
                    }
                    #endregion

                    #region emit
                    //Buscar dados Transportadora
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor clifor =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_transportadora, null);
                    //Buscar endereco Transportadora
                    CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco endereco =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_transportadora,
                                                                                  p.Cd_endtransportadora,
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
                                                                                  null)[0];
                    xml.Append("<emit>");
                    #region CNPJ
                    xml.Append("<CNPJ>");
                    xml.Append(clifor.Nr_cgc.SoNumero());
                    xml.Append("</CNPJ>");
                    #endregion
                    #region IE
                    xml.Append("<IE>");
                    xml.Append(endereco.Insc_estadual.SoNumero());
                    xml.Append("</IE>");
                    #endregion
                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(clifor.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xNome>");
                    #endregion
                    #region xFant
                    if (!string.IsNullOrEmpty(clifor.Nm_fantasia))
                    {
                        xml.Append("<xFant>");
                        xml.Append(clifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xFant>");
                    }
                    #endregion
                    #region enderEmit
                    xml.Append("<enderEmit>");
                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(endereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xLgr>");
                    #endregion
                    #region nro
                    xml.Append("<nro>");
                    xml.Append(endereco.Numero.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</nro>");
                    #endregion
                    #region xCpl
                    if (!string.IsNullOrEmpty(endereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(endereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xCpl>");
                    }
                    #endregion
                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(endereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xBairro>");
                    #endregion
                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(endereco.Cd_cidade.Trim());
                    xml.Append("</cMun>");
                    #endregion
                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(endereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMun>");
                    #endregion
                    #region CEP
                    if (!string.IsNullOrEmpty(endereco.Cep.SoNumero()))
                    {
                        xml.Append("<CEP>");
                        xml.Append(endereco.Cep.SoNumero().FormatStringEsquerda(8, '0'));
                        xml.Append("</CEP>");
                    }
                    #endregion
                    #region UF
                    xml.Append("<UF>");
                    xml.Append(endereco.UF.Trim());
                    xml.Append("</UF>");
                    #endregion
                    #region fone
                    if (!string.IsNullOrEmpty(endereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(endereco.Fone.SoNumero());
                        xml.Append("</fone>");
                    }
                    #endregion
                    xml.Append("</enderEmit>");
                    #endregion
                    xml.Append("</emit>");
                    #endregion

                    #region rem
                    //Buscar clifor do remetente
                    clifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_remetente, null);
                    //Buscar endereco remetente
                    endereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_remetente,
                                                                                         p.Cd_endremetente,
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
                                                                                         null)[0];
                    xml.Append("<rem>");
                    #region CNPJ
                    if (clifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        xml.Append("<CNPJ>");
                        xml.Append(clifor.Nr_cgc.SoNumero());
                        xml.Append("</CNPJ>");
                    }
                    #endregion
                    #region CPF
                    if (clifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        xml.Append("<CPF>");
                        xml.Append(clifor.Nr_cpf.SoNumero());
                        xml.Append("</CPF>");
                    }
                    #endregion
                    #region IE
                    xml.Append("<IE>");
                    xml.Append(endereco.Insc_estadual.Trim());
                    xml.Append("</IE>");
                    #endregion
                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(clifor.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xNome>");
                    #endregion
                    #region xFant
                    if (!string.IsNullOrEmpty(clifor.Nm_fantasia))
                    {
                        xml.Append("<xFant>");
                        xml.Append(clifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xFant>");
                    }
                    #endregion
                    #region fone
                    if (!string.IsNullOrEmpty(endereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(endereco.Fone.SoNumero());
                        xml.Append("</fone>");
                    }
                    #endregion
                    #region enderReme
                    xml.Append("<enderReme>");
                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(endereco.Ds_endereco.RemoverCaracteres().Trim());
                    xml.Append("</xLgr>");
                    #endregion
                    #region nro
                    xml.Append("<nro>");
                    xml.Append(endereco.Numero.RemoverCaracteres().Trim());
                    xml.Append("</nro>");
                    #endregion
                    #region xCpl
                    if (!string.IsNullOrEmpty(endereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(endereco.Ds_complemento.RemoverCaracteres().Trim());
                        xml.Append("</xCpl>");
                    }
                    #endregion
                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(endereco.Bairro.RemoverCaracteres().Trim());
                    xml.Append("</xBairro>");
                    #endregion
                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(endereco.Cd_cidade.Trim());
                    xml.Append("</cMun>");
                    #endregion
                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(endereco.DS_Cidade.RemoverCaracteres().Trim());
                    xml.Append("</xMun>");
                    #endregion
                    #region CEP
                    if (!string.IsNullOrEmpty(endereco.Cep.SoNumero()))
                    {
                        xml.Append("<CEP>");
                        xml.Append(endereco.Cep.SoNumero().FormatStringEsquerda(8, '0'));
                        xml.Append("</CEP>");
                    }
                    #endregion
                    #region UF
                    xml.Append("<UF>");
                    xml.Append(endereco.UF.Trim());
                    xml.Append("</UF>");
                    #endregion
                    #region cPais
                    if (!string.IsNullOrEmpty(endereco.CD_Pais))
                    {
                        xml.Append("<cPais>");
                        xml.Append(endereco.CD_Pais.Trim());
                        xml.Append("</cPais>");
                    }
                    #endregion
                    #region xPais
                    if (!string.IsNullOrEmpty(endereco.NM_Pais))
                    {
                        xml.Append("<xPais>");
                        xml.Append(endereco.NM_Pais.RemoverCaracteres().Trim());
                        xml.Append("</xPais>");
                    }
                    #endregion
                    xml.Append("</enderReme>");
                    #endregion
                    #region email
                    if (!string.IsNullOrEmpty(clifor.Email))
                    {
                        xml.Append("<email>");
                        xml.Append(clifor.Email.Trim());
                        xml.Append("</email>");
                    }
                    #endregion
                    xml.Append("</rem>");
                    #endregion

                    #region exped
                    if (!string.IsNullOrEmpty(p.Cd_expedidor))
                    {
                        //Clifor expedidor
                        clifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_expedidor, null);
                        //Endereco expedidor
                        endereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_expedidor,
                                                                                             p.Cd_endexpedidor,
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
                                                                                             null)[0];
                        xml.Append("<exped>");
                        #region CNPJ
                        if (clifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(clifor.Nr_cgc.SoNumero().Trim());
                            xml.Append("</CNPJ>");
                        }
                        #endregion
                        #region CPF
                        if (clifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(clifor.Nr_cpf.SoNumero().Trim());
                            xml.Append("</CPF>");
                        }
                        #endregion
                        #region IE
                        xml.Append("<IE>");
                        xml.Append(endereco.Insc_estadual.Trim());
                        xml.Append("</IE>");
                        #endregion
                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(clifor.Nm_clifor.RemoverCaracteres().Trim());
                        xml.Append("</xNome>");
                        #endregion
                        #region fone
                        if (!string.IsNullOrEmpty(endereco.Fone.SoNumero()))
                        {
                            xml.Append("<fone>");
                            xml.Append(endereco.Fone.SoNumero().Trim());
                            xml.Append("</fone>");
                        }
                        #endregion
                        #region enderExped
                        xml.Append("<enderExped>");
                        #region xLgr
                        xml.Append("<xLgr>");
                        xml.Append(endereco.Ds_endereco.RemoverCaracteres().Trim());
                        xml.Append("</xLgr>");
                        #endregion
                        #region nro
                        xml.Append("<nro>");
                        xml.Append(endereco.Numero.RemoverCaracteres().Trim());
                        xml.Append("</nro>");
                        #endregion
                        #region xCpl
                        if (!string.IsNullOrEmpty(endereco.Ds_complemento))
                        {
                            xml.Append("<xCpl>");
                            xml.Append(endereco.Ds_complemento.RemoverCaracteres().Trim());
                            xml.Append("</xCpl>");
                        }
                        #endregion
                        #region xBairro
                        xml.Append("<xBairro>");
                        xml.Append(endereco.Bairro.RemoverCaracteres().Trim());
                        xml.Append("</xBairro>");
                        #endregion
                        #region cMun
                        xml.Append("<cMun>");
                        xml.Append(endereco.Cd_cidade.Trim());
                        xml.Append("</cMun>");
                        #endregion
                        #region xMun
                        xml.Append("<xMun>");
                        xml.Append(endereco.DS_Cidade.RemoverCaracteres().Trim());
                        xml.Append("</xMun>");
                        #endregion
                        #region CEP
                        if (!string.IsNullOrEmpty(endereco.Cep.SoNumero()))
                        {
                            xml.Append("<CEP>");
                            xml.Append(endereco.Cep.SoNumero().FormatStringEsquerda(8, '0'));
                            xml.Append("</CEP>");
                        }
                        #endregion
                        #region UF
                        xml.Append("<UF>");
                        xml.Append(endereco.UF.Trim());
                        xml.Append("</UF>");
                        #endregion
                        #region cPais
                        if (!string.IsNullOrEmpty(endereco.CD_Pais))
                        {
                            xml.Append("<cPais>");
                            xml.Append(endereco.CD_Pais.Trim());
                            xml.Append("</cPais>");
                        }
                        #endregion
                        #region xPais
                        if (!string.IsNullOrEmpty(endereco.NM_Pais))
                        {
                            xml.Append("<xPais>");
                            xml.Append(endereco.NM_Pais.RemoverCaracteres().Trim());
                            xml.Append("</xPais>");
                        }
                        #endregion
                        xml.Append("</enderExped>");
                        #endregion
                        #region email
                        if (!string.IsNullOrEmpty(clifor.Email))
                        {
                            xml.Append("<email>");
                            xml.Append(clifor.Email.Trim());
                            xml.Append("</email>");
                        }
                        #endregion
                        xml.Append("</exped>");
                    }
                    #endregion
                    
                    #region receb
                    if (!string.IsNullOrEmpty(p.Cd_recebedor))
                    {
                        //Clifor recebedor
                        clifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_recebedor, null);
                        //Endereco recebedor
                        endereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_recebedor,
                                                                                             p.Cd_endrecebedor,
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
                                                                                             null)[0];
                        xml.Append("<receb>");
                        #region CNPJ
                        if (clifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(clifor.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion
                        #region CPF
                        if (clifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(clifor.Nr_cpf.SoNumero());
                            xml.Append("</CPF>");
                        }
                        #endregion
                        #region IE
                        xml.Append("<IE>");
                        xml.Append(endereco.Insc_estadual.Trim());
                        xml.Append("</IE>");
                        #endregion
                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(clifor.Nm_clifor.RemoverCaracteres().Trim());
                        xml.Append("</xNome>");
                        #endregion
                        #region fone
                        if (!string.IsNullOrEmpty(endereco.Fone.SoNumero()))
                        {
                            xml.Append("<fone>");
                            xml.Append(endereco.Fone.SoNumero());
                            xml.Append("</fone>");
                        }
                        #endregion
                        #region enderReceb
                        xml.Append("<enderReceb>");
                        #region xLgr
                        xml.Append("<xLgr>");
                        xml.Append(endereco.Ds_endereco.RemoverCaracteres().Trim());
                        xml.Append("</xLgr>");
                        #endregion
                        #region nro
                        xml.Append("<nro>");
                        xml.Append(endereco.Numero.RemoverCaracteres().Trim());
                        xml.Append("</nro>");
                        #endregion
                        #region xCpl
                        if (!string.IsNullOrEmpty(endereco.Ds_complemento))
                        {
                            xml.Append("<xCpl>");
                            xml.Append(endereco.Ds_complemento.RemoverCaracteres().Trim());
                            xml.Append("</xCpl>");
                        }
                        #endregion
                        #region xBairro
                        xml.Append("<xBairro>");
                        xml.Append(endereco.Bairro.RemoverCaracteres().Trim());
                        xml.Append("</xBairro>");
                        #endregion
                        #region cMun
                        xml.Append("<cMun>");
                        xml.Append(endereco.Cd_cidade.Trim());
                        xml.Append("</cMun>");
                        #endregion
                        #region xMun
                        xml.Append("<xMun>");
                        xml.Append(endereco.DS_Cidade.RemoverCaracteres().Trim());
                        xml.Append("</xMun>");
                        #endregion
                        #region CEP
                        if (!string.IsNullOrEmpty(endereco.Cep.SoNumero()))
                        {
                            xml.Append("<CEP>");
                            xml.Append(endereco.Cep.SoNumero().FormatStringEsquerda(8, '0'));
                            xml.Append("</CEP>");
                        }
                        #endregion
                        #region UF
                        xml.Append("<UF>");
                        xml.Append(endereco.UF.Trim());
                        xml.Append("</UF>");
                        #endregion
                        #region cPais
                        if (!string.IsNullOrEmpty(endereco.CD_Pais))
                        {
                            xml.Append("<cPais>");
                            xml.Append(endereco.CD_Pais.Trim());
                            xml.Append("</cPais>");
                        }
                        #endregion
                        #region xPais
                        if (!string.IsNullOrEmpty(endereco.NM_Pais))
                        {
                            xml.Append("<xPais>");
                            xml.Append(endereco.NM_Pais.RemoverCaracteres().Trim());
                            xml.Append("</xPais>");
                        }
                        #endregion
                        xml.Append("</enderReceb>");
                        #endregion
                        #region email
                        if (!string.IsNullOrEmpty(clifor.Email))
                        {
                            xml.Append("<email>");
                            xml.Append(clifor.Email.Trim());
                            xml.Append("</email>");
                        }
                        #endregion
                        xml.Append("</receb>");
                    }
                    #endregion

                    #region dest
                    //Clifor destinatario
                    clifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(p.Cd_destinatario, null);
                    //Endereco destinatario
                    endereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(p.Cd_destinatario,
                                                                                         p.Cd_enddestinatario,
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
                                                                                         null)[0];
                    xml.Append("<dest>");
                    #region CNPJ
                    if (clifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        xml.Append("<CNPJ>");
                        xml.Append(clifor.Nr_cgc.SoNumero());
                        xml.Append("</CNPJ>");
                    }
                    #endregion
                    #region CPF
                    if (clifor.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        xml.Append("<CPF>");
                        xml.Append(clifor.Nr_cpf.SoNumero());
                        xml.Append("</CPF>");
                    }
                    #endregion
                    #region IE
                    xml.Append("<IE>");
                    xml.Append(endereco.Insc_estadual.Trim());
                    xml.Append("</IE>");
                    #endregion
                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(clifor.Nm_clifor.RemoverCaracteres().Trim().SubstCaracteresEsp());
                    xml.Append("</xNome>");
                    #endregion
                    #region fone
                    if (!string.IsNullOrEmpty(endereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(endereco.Fone.SoNumero());
                        xml.Append("</fone>");
                    }
                    #endregion
                    #region enderDest
                    xml.Append("<enderDest>");
                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(endereco.Ds_endereco.RemoverCaracteres().Trim().SubstCaracteresEsp());
                    xml.Append("</xLgr>");
                    #endregion
                    #region nro
                    xml.Append("<nro>");
                    xml.Append(endereco.Numero.RemoverCaracteres().Trim().SubstCaracteresEsp());
                    xml.Append("</nro>");
                    #endregion
                    #region xCpl
                    if (!string.IsNullOrEmpty(endereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(endereco.Ds_complemento.RemoverCaracteres().Trim().SubstCaracteresEsp());
                        xml.Append("</xCpl>");
                    }
                    #endregion
                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(endereco.Bairro.RemoverCaracteres().Trim().SubstCaracteresEsp());
                    xml.Append("</xBairro>");
                    #endregion
                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(endereco.Cd_cidade.Trim());
                    xml.Append("</cMun>");
                    #endregion
                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(endereco.DS_Cidade.RemoverCaracteres().Trim().SubstCaracteresEsp());
                    xml.Append("</xMun>");
                    #endregion
                    #region CEP
                    if (!string.IsNullOrEmpty(endereco.Cep.SoNumero()))
                    {
                        xml.Append("<CEP>");
                        xml.Append(endereco.Cep.SoNumero().FormatStringEsquerda(8, '0'));
                        xml.Append("</CEP>");
                    }
                    #endregion
                    #region UF
                    xml.Append("<UF>");
                    xml.Append(endereco.UF.Trim());
                    xml.Append("</UF>");
                    #endregion
                    #region cPais
                    if (!string.IsNullOrEmpty(endereco.CD_Pais))
                    {
                        xml.Append("<cPais>");
                        xml.Append(endereco.CD_Pais.Trim());
                        xml.Append("</cPais>");
                    }
                    #endregion
                    #region xPais
                    if (!string.IsNullOrEmpty(endereco.NM_Pais))
                    {
                        xml.Append("<xPais>");
                        xml.Append(endereco.NM_Pais.RemoverCaracteres().Trim().SubstCaracteresEsp());
                        xml.Append("</xPais>");
                    }
                    #endregion
                    xml.Append("</enderDest>");
                    #endregion
                    #region email
                    if (!string.IsNullOrEmpty(clifor.Email))
                    {
                        xml.Append("<email>");
                        xml.Append(clifor.Email.Trim());
                        xml.Append("</email>");
                    }
                    #endregion
                    xml.Append("</dest>");
                    #endregion

                    #region vPrest
                    xml.Append("<vPrest>");
                    #region vTPrest
                    xml.Append("<vTPrest>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_frete)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vTPrest>");
                    #endregion
                    #region vRec
                    xml.Append("<vRec>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_receber)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vRec>");
                    #endregion
                    if (p.lCompValorFrete.Count > 0)
                    {
                        p.lCompValorFrete.ForEach(v =>
                        {
                            #region Comp
                            xml.Append("<Comp>");
                            #region xNome
                            xml.Append("<xNome>");
                            xml.Append(v.Nm_componente.Trim());
                            xml.Append("</xNome>");
                            #endregion
                            #region vComp
                            xml.Append("<vComp>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_componente)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vComp>");
                            #endregion
                            xml.Append("</Comp>");
                            #endregion
                        });
                    }
                    xml.Append("</vPrest>");
                    #endregion

                    #region imp
                    xml.Append("<imp>");
                    #region ICMS
                    //Buscar imposto ICMS
                    CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImposto =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_ImpostosNF().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "c.st_icms",
                                vOperador = "=",
                                vVL_Busca = "1"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lanctoctr",
                                vOperador = "=",
                                vVL_Busca = p.Nr_lanctoCTRC.Value.ToString()
                            }
                        }, 1, string.Empty);
                    if (lImposto.Count > 0)
                    {
                        xml.Append("<ICMS>");
                        #region ICMS00
                        if (lImposto[0].Cd_st.Trim().Equals("00"))
                        {
                            xml.Append("<ICMS00>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append(lImposto[0].Cd_st.Trim());
                            xml.Append("</CST>");
                            #endregion
                            #region vBC
                            xml.Append("<vBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBC>");
                            #endregion
                            #region pICMS
                            xml.Append("<pICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMS>");
                            #endregion
                            #region vICMS
                            xml.Append("<vICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMS>");
                            #endregion
                            xml.Append("</ICMS00>");
                        }
                        #endregion
                        #region ICMS20
                        if (lImposto[0].Cd_st.Trim().Equals("20"))
                        {
                            xml.Append("<ICMS20>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append(lImposto[0].Cd_st.Trim());
                            xml.Append("</CST>");
                            #endregion
                            #region pRedBC
                            xml.Append("<pRedBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pRedBC>");
                            #endregion
                            #region vBC
                            xml.Append("<vBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBC>");
                            #endregion
                            #region pICMS
                            xml.Append("<pICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMS>");
                            #endregion
                            #region vICMS
                            xml.Append("<vICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMS>");
                            #endregion
                            xml.Append("</ICMS20>");
                        }
                        #endregion
                        #region ICMS45
                        if (lImposto[0].Cd_st.Trim().Equals("40") ||
                            lImposto[0].Cd_st.Trim().Equals("41") ||
                            lImposto[0].Cd_st.Trim().Equals("51"))
                        {
                            xml.Append("<ICMS45>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append(lImposto[0].Cd_st.Trim());
                            xml.Append("</CST>");
                            #endregion
                            xml.Append("</ICMS45>");
                        }
                        #endregion
                        #region ICMS60
                        if (lImposto[0].Cd_st.Trim().Equals("60"))
                        {
                            xml.Append("<ICMS60>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append(lImposto[0].Cd_st.Trim());
                            xml.Append("</CST>");
                            #endregion
                            #region vBCSTRet
                            xml.Append("<vBCSTRet>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBCSTRet>");
                            #endregion
                            #region vICMSSTRet
                            xml.Append("<vICMSSTRet>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMSSTRet>");
                            #endregion
                            #region pICMSSTRet
                            xml.Append("<pICMSSTRet>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMSSTRet>");
                            #endregion
                            #region vCred
                            //if (lImposto[0].Vl_credpresumido > decimal.Zero)
                            //{
                            //    xml.Append("<vCred>");
                            //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_impostocalc - lImposto[0].Vl_credpresumido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            //    xml.Append("</vCred>");
                            //}
                            #endregion
                            xml.Append("</ICMS60>");
                        }
                        #endregion
                        #region ICMS90
                        if (lImposto[0].Cd_st.Trim().Equals("90"))
                        {
                            xml.Append("<ICMS90>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append(lImposto[0].Cd_st.Trim());
                            xml.Append("</CST>");
                            #endregion
                            #region pRedBC
                            if (lImposto[0].Pc_reducaobasecalc > decimal.Zero)
                            {
                                xml.Append("<pRedBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pRedBC>");
                            }
                            #endregion
                            #region vBC
                            xml.Append("<vBC>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vBC>");
                            #endregion
                            #region pICMS
                            xml.Append("<pICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</pICMS>");
                            #endregion
                            #region vICMS
                            xml.Append("<vICMS>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vICMS>");
                            #endregion
                            xml.Append("</ICMS90>");
                        }
                        #endregion
                        #region ICMSSN
                        if (Empresa.Tp_regimetributario.Trim().Equals("1") &&
                            !lImposto[0].Cd_st.Trim().Length.Equals(2))
                        {
                            xml.Append("<ICMSSN>");
                            #region CST
                            xml.Append("<CST>");
                            xml.Append("90");//90-ICMS Simples Nacional
                            xml.Append("</CST>");
                            #endregion
                            #region indSN
                            xml.Append("<indSN>");
                            xml.Append("1");//1=Simples Nacional
                            xml.Append("</indSN>");
                            #endregion
                            xml.Append("</ICMSSN>");
                        }
                        #endregion
                        xml.Append("</ICMS>");
                    }
                    else throw new Exception("Erro: Não existe ICMS configurado para emitir CTe.");
                    #endregion

                    #region vTotTrib
                    if (p.Vl_impAprox > decimal.Zero)
                    {
                        xml.Append("<vTotTrib>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_impAprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vTotTrib>");
                    }
                    #endregion

                    #region ICMSUFFim
                    if (lImposto[0].Pc_aliquotaICMSDest > decimal.Zero)
                    {
                        xml.Append("<ICMSUFFim>");
                        #region vBCUFFim
                        xml.Append("<vBCUFFim>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vBCUFFim>");
                        #endregion
                        #region pFCPUFFim
                        xml.Append("<pFCPUFFim>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pFCPUFFim>");
                        #endregion
                        #region pICMSUFFim
                        xml.Append("<pICMSUFFim>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquotaICMSDest)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pICMSUFFim>");
                        #endregion
                        #region pICMSInter
                        xml.Append("<pICMSInter>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pICMSInter>");
                        #endregion
                        #region pICMSInterPart
                        xml.Append("<pICMSInterPart>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", 100)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pICMSInterPart>");
                        #endregion
                        #region vFCPUFFim
                        xml.Append("<vFCPUFFim>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vFCPUFFim>");
                        #endregion
                        #region vICMSUFFim
                        xml.Append("<vICMSUFFim>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", lImposto[0].Vl_pauta)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vICMSUFFim>");
                        #endregion
                        #region vICMSUFIni
                        xml.Append("<vICMSUFIni>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vICMSUFIni>");
                        #endregion
                        xml.Append("</ICMSUFFim>");
                    }
                    #endregion
                    xml.Append("</imp>");
                    #endregion

                    if (p.Tp_cte.Trim().Equals("0") ||
                        p.Tp_cte.Trim().Equals("3"))
                    {
                        #region infCTeNorm
                        xml.Append("<infCTeNorm>");
                        #region infCarga
                        xml.Append("<infCarga>");
                        #region vCarga
                        xml.Append("<vCarga>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_carga)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vCarga>");
                        #endregion
                        #region proPred
                        xml.Append("<proPred>");
                        xml.Append(p.Ds_prodpredominante.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</proPred>");
                        #endregion
                        #region xOutCat
                        if (!string.IsNullOrEmpty(p.OutrasCaracCarga))
                        {
                            xml.Append("<xOutCat>");
                            xml.Append(p.OutrasCaracCarga.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xOutCat>");
                        }
                        #endregion
                        #region infQ
                        p.lQtdeCarga.ForEach(v =>
                            {
                                xml.Append("<infQ>");
                                #region cUnid
                                xml.Append("<cUnid>");
                                xml.Append(v.cUnid.Trim());
                                xml.Append("</cUnid>");
                                #endregion
                                #region tpMed
                                xml.Append("<tpMed>");
                                xml.Append(v.Tp_medida.RemoverCaracteres().Trim());
                                xml.Append("</tpMed>");
                                #endregion
                                #region qCarga
                                xml.Append("<qCarga>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Qt_carga)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</qCarga>");
                                #endregion
                                xml.Append("</infQ>");
                            });
                        #endregion
                        xml.Append("</infCarga>");
                        #endregion
                        #region infDoc
                        xml.Append("<infDoc>");
                        CamadaDados.Faturamento.CTRC.TList_CTRNotaFiscal lDoc =
                            CamadaNegocio.Faturamento.CTRC.TCN_CTRNotaFiscal.Buscar(p.Cd_empresa,
                                                                                    p.Nr_lanctoCTRC.Value.ToString(),
                                                                                    string.Empty,
                                                                                    0,
                                                                                    string.Empty,
                                                                                    null);
                        #region infNFe
                        lDoc.FindAll(v => !string.IsNullOrEmpty(v.Chave_acesso_nfe)).ForEach(v =>
                            {
                                xml.Append("<infNFe>");
                                #region chave
                                xml.Append("<chave>");
                                xml.Append(v.Chave_acesso_nfe.Trim());
                                xml.Append("</chave>");
                                #endregion
                                xml.Append("</infNFe>");
                            });
                        #endregion
                        #region infOutros
                        lDoc.FindAll(v => !string.IsNullOrEmpty(v.Tp_documento)).ForEach(v =>
                            {
                                xml.Append("<infOutros>");
                                #region tpDoc
                                xml.Append("<tpDoc>");
                                xml.Append(v.Tp_documento.Trim());
                                xml.Append("</tpDoc>");
                                #endregion
                                #region descOutros
                                if (!string.IsNullOrEmpty(v.Ds_documento))
                                {
                                    xml.Append("<descOutros>");
                                    xml.Append(v.Ds_documento.RemoverCaracteres().Trim());
                                    xml.Append("</descOutros>");
                                }
                                #endregion
                                #region nDoc
                                if (!string.IsNullOrEmpty(v.Nr_documento))
                                {
                                    xml.Append("<nDoc>");
                                    xml.Append(v.Nr_documento.Trim());
                                    xml.Append("</nDoc>");
                                }
                                #endregion
                                #region dEmi
                                if (v.Dt_documento.HasValue)
                                {
                                    xml.Append("<dEmi>");
                                    xml.Append(v.Dt_documento.Value.ToString("yyyy-MM-dd"));
                                    xml.Append("</dEmi>");
                                }
                                #endregion
                                #region vDocFisc
                                if (v.Vl_documento > decimal.Zero)
                                {
                                    xml.Append("<vDocFisc>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_documento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vDocFisc>");
                                }
                                #endregion
                                xml.Append("</infOutros>");
                            });
                        #endregion
                        xml.Append("</infDoc>");
                        #endregion
                        #region docAnt
                        if (!p.Tp_servico.Trim().Equals("0"))
                        {
                            xml.Append("<docAnt>");
                            #region emiDocAnt
                            if (string.IsNullOrWhiteSpace(p.Cd_cliforCTeRef))
                                throw new Exception("Obrigatório informar Emitente CT-e referenciado.");
                            xml.Append("<emiDocAnt>");
                            #region CNPJ
                            xml.Append("<CNPJ>");
                            xml.Append(p.Cnpj_cliforCTeRef.SoNumero());
                            xml.Append("</CNPJ>");
                            #endregion
                            //Buscar endereco Emitente
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEndEmit =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + p.Cd_cliforCTeRef.Trim() + "'" } }, 1, string.Empty);
                            if (lEndEmit.Count.Equals(0))
                                throw new Exception("Não existe endereço cadastrado para o Emitente CT-e referenciado.");
                            #region IE
                            xml.Append("<IE>");
                            xml.Append(lEndEmit[0].Insc_estadual.SoNumero());
                            xml.Append("</IE>");
                            #endregion
                            #region UF
                            xml.Append("<UF>");
                            xml.Append(lEndEmit[0].UF.Trim());
                            xml.Append("</UF>");
                            #endregion
                            #region xNome
                            xml.Append("<xNome>");
                            xml.Append(p.Nm_cliforCTeRef.RemoverCaracteres().SubstCaracteresEsp());
                            xml.Append("</xNome>");
                            #endregion
                            #region idDocAnt
                            xml.Append("<idDocAnt>");
                            #region idDocAntEle
                            if (string.IsNullOrWhiteSpace(p.Chave_acessoCTRRef.SoNumero()))
                                throw new Exception("Obrigatório informar Chave Acesso CT-e referenciado para tipo serviço diferente de NORMAL.");
                            xml.Append("<idDocAntEle>");
                            #region chCTe 
                            xml.Append("<chCTe>");
                            xml.Append(p.Chave_acessoCTRRef.SoNumero());
                            xml.Append("</chCTe>");
                            #endregion
                            xml.Append("</idDocAntEle>");
                            #endregion
                            xml.Append("</idDocAnt>");
                            #endregion
                            xml.Append("</emiDocAnt>");
                            #endregion
                            xml.Append("</docAnt>");
                        }
                        #endregion
                        #region infModal
                        xml.Append("<infModal versaoModal=\"" + rCfgCte.Cd_versaomodalrod.Trim() + "\">");
                        #region rodo
                        xml.Append("<rodo>");
                        #region RNTRC
                        xml.Append("<RNTRC>");
                        xml.Append(rCfgCte.RNTRC.Trim());
                        xml.Append("</RNTRC>");
                        #endregion
                        #region Ordem Coleta
                        p.lOrdemColeta.ForEach(v =>
                            {
                                xml.Append("<occ>");
                                #region serie
                                if (!string.IsNullOrEmpty(v.Nr_serie))
                                {
                                    xml.Append("<serie>");
                                    xml.Append(v.Nr_serie.Trim());
                                    xml.Append("</serie>");
                                }
                                #endregion
                                #region nOcc
                                xml.Append("<nOcc>");
                                xml.Append(v.Nr_ordem.Trim());
                                xml.Append("</nOcc>");
                                #endregion
                                #region dEmi
                                xml.Append("<dEmi>");
                                xml.Append(v.Dt_emissao.Value.ToString("yyyy-MM-dd"));
                                xml.Append("</dEmi>");
                                #endregion
                                #region emiOcc
                                xml.Append("<emiOcc>");
                                #region CNPJ
                                xml.Append("<CNPJ>");
                                xml.Append(v.Cnpj_clifor.SoNumero());
                                xml.Append("</CNPJ>");
                                #endregion
                                #region IE
                                xml.Append("<IE>");
                                xml.Append(v.Insc_estadual.SoNumero());
                                xml.Append("</IE>");
                                #endregion
                                #region UF
                                xml.Append("<UF>");
                                xml.Append(v.Uf.Trim());
                                xml.Append("</UF>");
                                #endregion
                                #region fone
                                if (!string.IsNullOrEmpty(v.Fone.SoNumero()))
                                {
                                    xml.Append("<fone>");
                                    xml.Append(v.Fone.SoNumero());
                                    xml.Append("</fone>");
                                }
                                #endregion
                                xml.Append("</emiOcc>");
                                #endregion
                                xml.Append("</occ>");
                            });
                        #endregion
                        xml.Append("</rodo>");
                        #endregion
                        xml.Append("</infModal>");
                        #endregion
                        #region infCteSub
                        if (p.Tp_cte.Trim().Equals("3"))
                        {
                            xml.Append("<infCteSub>");
                            #region chCte
                            xml.Append("<chCte>");
                            xml.Append(p.Chave_acessoCTRRef.Trim());
                            xml.Append("</chCte>");
                            #endregion
                            #region tomaICMS
                            xml.Append("<tomaICMS>");
                            #region refNFe
                            xml.Append("<refNFe>");
                            xml.Append(p.CH_AcessoNFeTom.Trim());
                            xml.Append("</refNFe>");
                            #endregion
                            xml.Append("</tomaICMS>");
                            #endregion
                            xml.Append("</infCteSub>");
                        }
                        #endregion
                        xml.Append("</infCTeNorm>");
                        #endregion
                    }
                    else if (p.Tp_cte.Trim().Equals("1"))
                    {
                        #region infCteComp
                        xml.Append("<infCteComp>");
                        #region chave
                        xml.Append("<chCTe>");
                        xml.Append(p.Chave_acessoCTRRef.Trim());
                        xml.Append("</chCTe>");
                        #endregion
                        xml.Append("</infCteComp>");
                        #endregion
                    }
                    else if (p.Tp_cte.Trim().Equals("2"))
                    {
                        #region infCteAnu
                        xml.Append("<infCteAnu>");
                        #region chCte
                        xml.Append("<chCte>");
                        xml.Append(p.Chave_acessoCTRAnulado.Trim());
                        xml.Append("</chCte>");
                        #endregion
                        #region dEmi
                        xml.Append("<dEmi>");
                        xml.Append(CamadaDados.UtilData.Data_Servidor().ToString("yyyy-MM-dd"));
                        xml.Append("</dEmi>");
                        #endregion
                        xml.Append("</infCteAnu>");
                        #endregion
                    }
                    #region Autorização para obter XML
                    if (!string.IsNullOrWhiteSpace(rCfgCte.Cnpj_contador.SoNumero()))
                    {

                        #region autXML 
                        xml.Append("<autXML>\n");
                        #region CNPJ 
                        xml.Append("<CNPJ>");
                        xml.Append(rCfgCte.Cnpj_contador.SoNumero());
                        xml.Append("</CNPJ>\n");
                        #endregion
                        xml.Append("</autXML>\n");
                        #endregion
                    }
                    #endregion
                    xml.Append("</infCte>");
                    #endregion
                    xml.Append("</CTe>");
                    #endregion
                    //Assinar XML
                    xmlassinado = new Utils.Assinatura.TAssinatura2(rCfgCte.Nr_seriecertificado,
                                                                    Utils.Assinatura.TAssinatura2.TTpArq.tpEnviaCTe,
                                                                    xml.ToString()).Assinar();
                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgCte.Path_schemas.SeparadorDiretorio() + "cte_v" + rCfgCte.Cd_versaolayout.Trim() + ".xsd",
                                                            "CTE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                    //Gravar codigo acesso da nfe e alterar status para nfe gerada na tabela nota fiscal
                    try
                    {
                        //Chave de acesso
                        p.Chaveacesso = MontarChaveAcessoCte(p, Empresa, rCfgCte) + CalcularDigitoChave(MontarChaveAcessoCte(p, Empresa, rCfgCte));
                        p.Xml_cte = xmlassinado;
                        new TCD_ConhecimentoFrete().Gravar(p);
                    }
                    catch
                    { }
                });
        }

        public static string GerarArquivoXmlPeriodo(string vPath_xml,
                                                    TList_ConhecimentoFrete lCte, 
                                                    TRegistro_CfgFrota rCfg)
        {
            try
            {
                string retorno = string.Empty;
                //Criar arquivo xml
                CriarArquivoXml(lCte,
                                rCfg);
                //Path XML
                if (vPath_xml.Trim().Substring(vPath_xml.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath_xml += System.IO.Path.DirectorySeparatorChar.ToString();
                lCte.ForEach(p =>
                {
                    if (p.Status_cte != null)
                        if (p.Cd_empresa == rCfg.Cd_empresa && p.Status_cte.Value.Equals(100))
                        {
                            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                                retorno += Utils.ValidaSchema.ValidaXML2.Retorno.Trim() + "\r\n";
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(p.Xml_cte);
                                //Salvar arquivo no Path indicado 
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() + p.Chaveacesso.Trim().Remove(0, 3) + "-cte.xml"))
                                {
                                    sw.Write(p.Xml_cte.Trim());
                                    sw.Flush();
                                    sw.Close();
                                }
                                //Buscar Eventos CTe
                                CamadaNegocio.Faturamento.CTRC.TCN_EventoCTe.Buscar(p.Cd_empresa,
                                                                                    p.Nr_lanctoCTRC.Value.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    "T",
                                                                                    null).ForEach(v =>
                                                                                    {
                                                                                        XmlDocument docevent = new XmlDocument();
                                                                                        docevent.LoadXml(v.Xml_evento);
                                                                                        string versao = doc.LastChild.Attributes.GetNamedItem("versao").InnerText;
                                                                                        StringBuilder xml = new StringBuilder();
                                                                                        xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                                                                        xml.Append("<procEventoCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"" + versao.Trim() + "\">");
                                                                                        xml.Append(v.Xml_evento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty).Replace(" xmlns=\"http://www.portalfiscal.inf.br/cte\"", string.Empty));
                                                                                        xml.Append(v.Xml_retevent.Replace(" xmlns=\"http://www.portalfiscal.inf.br/cte\"", string.Empty));
                                                                                        xml.Append("</procEventoCTe>");
                                                                                        //Salvar arquivo no Path indicado 
                                                                                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() +
                                                                                                                                                      v.Cd_eventostr.Trim() + "-" +
                                                                                                                                                      p.Chaveacesso.Trim() + "-procEventoCTe.xml"))
                                                                                        {
                                                                                            sw.Write(xml.ToString());
                                                                                            sw.Flush();
                                                                                            sw.Close();
                                                                                        }
                                                                                    });
                            }
                        }
                });
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.Trim());
            }
        }
    }
}
