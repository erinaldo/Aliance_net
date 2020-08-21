using System;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.PostoCombustivel;
using CamadaDados.Faturamento.Cadastros;

namespace PostoCombustivel.LMC
{
    public class TLMC
    {
        private static XmlNode ConectarWebService(XmlNode lmcDadosMsg, TRegistro_CfgNfe rCfgNfce)
        {
            switch (rCfgNfce.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (rCfgNfce.Tp_ambiente_lmc.Trim().Equals("1"))//Producao
                        {
                            System.Net.ServicePointManager.Expect100Continue = false;
                            br.gov.pr.fazenda.lmcws.LMC.LMCAutorizacao lmc = new PostoCombustivel.br.gov.pr.fazenda.lmcws.LMC.LMCAutorizacao();
                            lmc.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            lmc.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                            return lmc.lmcAutorizacao(lmcDadosMsg);
                        }
                        else//Homologacao
                        {
                            System.Net.ServicePointManager.Expect100Continue = false;
                            br.gov.pr.fazenda.lmcws.homologacao.LMC.LMCAutorizacao lmc = new PostoCombustivel.br.gov.pr.fazenda.lmcws.homologacao.LMC.LMCAutorizacao();
                            lmc.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            lmc.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                            return lmc.lmcAutorizacao(lmcDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static bool GerarXMLLMC(TRegistro_LMC val,
                                       TRegistro_CfgNfe rCfgNfe,
                                       ref string Msg)
        {
            bool ret = false;
            val.Chaveacesso = CamadaNegocio.PostoCombustivel.TCN_LMC.GerarChaveLMC(val);
            //Validar certificado
            srvNFE.ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?> ");
            #region autorizacao
            xml.Append("<autorizacao xmlns=\"http://www.fazenda.pr.gov.br/sefaws\">");
            #region LivroCombustivel
            xml.Append("<livroCombustivel xmlns=\"http://www.fazenda.pr.gov.br/sefaws\">");
            #region infLivroCombustivel
            xml.Append("<infLivroCombustivel versao=\"" + rCfgNfe.Cd_versaoLMC.Trim() + "\" Id=\"LMC" + val.Chaveacesso.Trim() + "\">");
            #region Ambiente
            xml.Append("<tpAmb>");
            xml.Append(rCfgNfe.Tp_ambiente_lmc);
            xml.Append("</tpAmb>");
            #endregion
            #region Codigo LMC
            xml.Append("<cNumerico>");
            xml.Append(val.Id_lmcstr.FormatStringEsquerda(5, '0'));
            xml.Append("</cNumerico>");
            #endregion
            #region Codigo Digito Verificador Chave Acesso
            xml.Append("<cDV>");
            xml.Append(val.Chaveacesso.Substring(val.Chaveacesso.Length - 1, 1));
            xml.Append("</cDV>");
            #endregion
            #region Emitente LMC
            xml.Append("<emit>");
            #region Insc. Estadual
            xml.Append("<IE>");
            xml.Append(val.IE_empresa.SoNumero());
            xml.Append("</IE>");
            #endregion
            #region CNPJ
            xml.Append("<CNPJ>");
            xml.Append(val.Cnpj_empresa.SoNumero());
            xml.Append("</CNPJ>");
            #endregion
            #region Nome Emitente
            xml.Append("<xNome>");
            xml.Append(val.Nm_empresa.Trim().SubstCaracteresEsp());
            xml.Append("</xNome>");
            #endregion
            xml.Append("</emit>");
            #endregion
            #region Movimento
            xml.Append("<movimento dEmissao=\"" + val.Dt_emissao.Value.ToString("yyyy-MM-dd") + "\">");
            #region infMovimento
            CamadaNegocio.PostoCombustivel.TCN_MovLMC.Buscar(val.Cd_empresa, val.Id_lmcstr, string.Empty, null).ForEach(p =>
                {
                    xml.Append("<infMovimento nrProduto=\"" + p.Tp_combustivel + "\">");
                    //Volume Abertura
                    xml.Append("<volEstoqueAbertura>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N3}", p.Volumeabertura)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</volEstoqueAbertura>");
                    #region volumeRecebido
                    p.lRec = CamadaNegocio.PostoCombustivel.TCN_MovRec.Buscar(p.Cd_empresa, p.Id_lmcstr, p.Id_movtostr, null);
                    if (p.lRec.Count > 0)
                        p.lRec.ForEach(v =>
                            {
                                xml.Append("<volumeRecebido>");
                                //CNPJ
                                xml.Append("<CNPJ>");
                                xml.Append(v.Cnpj_fornecedor.SoNumero());
                                xml.Append("</CNPJ>");
                                //Nota Fiscal
                                xml.Append("<nNF>");
                                xml.Append(v.Nr_notafiscalstr);
                                xml.Append("</nNF>");
                                //Data Nota
                                xml.Append("<dNF>");
                                xml.Append(v.Dt_saient.Value.ToString("yyyy-MM-dd"));
                                xml.Append("</dNF>");
                                //Volume Recebido
                                xml.Append("<volVolume>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", v.VolumeRecebido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</volVolume>");
                                //Tanque
                                xml.Append("<xTanque>");
                                xml.Append(v.Id_tanquestr);
                                xml.Append("</xTanque>");
                                xml.Append("</volumeRecebido>");
                            });
                    #endregion
                    #region volumeVendido
                    p.lVend = CamadaNegocio.PostoCombustivel.TCN_MovVend.Buscar(p.Cd_empresa, p.Id_lmcstr, p.Id_movtostr, null);
                    if (p.lVend.Count > 0)
                        p.lVend.ForEach(v =>
                            {
                                xml.Append("<volumeVendido>");
                                //Tanque
                                xml.Append("<xTanque>");
                                xml.Append(v.Id_tanquestr);
                                xml.Append("</xTanque>");
                                //Bico
                                xml.Append("<nrBico>");
                                xml.Append(v.Ds_labelbico);
                                xml.Append("</nrBico>");
                                //Fechamento
                                xml.Append("<volFechamento>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", v.Volfechamento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</volFechamento>");
                                //Abertura
                                xml.Append("<volAbertura>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", v.Volabertura)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</volAbertura>");
                                //Afericoes
                                xml.Append("<volAfericoes>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N3}", v.Volafericao)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</volAfericoes>");
                                xml.Append("</volumeVendido>");
                            });
                    #endregion
                    //Estoque Fechamento
                    xml.Append("<volEstoqueFechamento>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N3}", p.Volumefechamento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</volEstoqueFechamento>");
                    //Valor Vendas Dia
                    xml.Append("<valVendasDiaBomba>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_vendasdia)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</valVendasDiaBomba>");
                    //Vendas Acumuladas Mes
                    xml.Append("<valAcumuladoMes>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_vendasdia)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</valAcumuladoMes>");
                    //Observacoes
                    xml.Append("<observacoes>");
                    xml.Append(p.Obs.Trim().SubstCaracteresEsp());
                    xml.Append("</observacoes>");
                    xml.Append("</infMovimento>");
                });
            #endregion
            xml.Append("</movimento>");
            #endregion
            xml.Append("</infLivroCombustivel>");
            #endregion
            xml.Append("</livroCombustivel>");
            #endregion
            xml.Append("</autorizacao>");
            #endregion

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgNfe.Nr_certificado_nfe,
                                                  Utils.Assinatura.TAssinatura2.TTpArq.tpLMCe,
                                                  xml.ToString()).Assinar();

            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                     rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "autorizacao_v" + rCfgNfe.Cd_versaoLMC.Trim() + ".xsd",
                                                     "LMC");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Enviar arquivo para Receita
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlassinado);
            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);
            if (retorno != null)
            {
                if (retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["cStat"].InnerText.Trim().Equals("100") ||
                    retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["cStat"].InnerText.Trim().Equals("101") ||
                    retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["cStat"].InnerText.Trim().Equals("1001"))
                {
                    try
                    {
                        CamadaDados.TDataQuery query = new CamadaDados.TDataQuery();
                        System.Collections.Hashtable hs = new System.Collections.Hashtable();
                        hs.Add("@P_CHAVE", val.Chaveacesso);
                        hs.Add("@P_RECEBIMENTO", DateTime.Parse(retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["dhRecbto"].InnerText));
                        hs.Add("@P_STATUS", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["cStat"].InnerText);
                        hs.Add("@P_XMOTIVO", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["xMotivo"].InnerText);
                        hs.Add("@P_NPROT", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["nProt"].InnerText);
                        hs.Add("@P_DIGVAL", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["digVal"].InnerText);
                        hs.Add("@P_XML", xmlassinado);
                        hs.Add("@P_EMPRESA", val.Cd_empresa);
                        hs.Add("@P_LMC", val.Id_lmc);
                        query.executarSql("update tb_pdc_lmc set " +
                                          "chaveacesso = @P_CHAVE, " +
                                          "dt_recebimento = @P_RECEBIMENTO, " +
                                          "status = @P_STATUS, " +
                                          "xMotivo = @P_XMOTIVO, " +
                                          "nProt = @P_NPROT, " +
                                          "digVal = @P_DIGVAL, " +
                                          "xml_lmc = @P_XML, " +
                                          "dt_alt = getdate() " +
                                          "where cd_empresa = @P_EMPRESA and id_lmc = @P_LMC", hs);
                        ret = true;
                        Msg = retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["xMotivo"].InnerText;
                    }
                    catch (Exception ex)
                    { throw new Exception("Erro gravar chave acesso LMC-e: " + ex.Message.Trim()); }
                }
                else
                {
                    try
                    {
                        CamadaDados.TDataQuery query = new CamadaDados.TDataQuery();
                        System.Collections.Hashtable hs = new System.Collections.Hashtable();
                        hs.Add("@P_STATUS", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["cStat"].InnerText);
                        hs.Add("@P_XMOTIVO", retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["xMotivo"].InnerText);
                        hs.Add("@P_EMPRESA", val.Cd_empresa);
                        hs.Add("@P_LMC", val.Id_lmc);
                        query.executarSql("update tb_pdc_lmc set " +
                                          "status = @P_STATUS, " +
                                          "xMotivo = @P_XMOTIVO, " +
                                          "dt_alt = getdate() " +
                                          "where cd_empresa = @P_EMPRESA and id_lmc = @P_LMC", hs);
                    }
                    catch (Exception ex)
                    { throw new Exception("Erro gravar chave acesso LMC-e: " + ex.Message.Trim()); }
                    Msg = retorno["autorizacaoRetorno"]["livroCombustivelRetorno"]["protLivroCombustivel"]["infProt"]["xMotivo"].InnerText;
                }
            }
            return ret;
        }
    }
}
