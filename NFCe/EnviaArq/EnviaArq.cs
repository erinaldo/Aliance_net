using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Utils;

namespace NFCe.EnviaArq
{
    public class TEnviaArq
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg,
                                                  CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            switch (rCfgNfe.Cd_uf_empresa.Trim())
            {
                case ("41"):
                    {
                        if (rCfgNfe.Tp_ambiente_nfce.Trim().Equals("1"))//Producao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfce.Autoriza.NfeAutorizacao3 nfce = new br.gov.pr.fazenda.nfce.Autoriza.NfeAutorizacao3();
                                nfce.nfeCabecMsgValue = new br.gov.pr.fazenda.nfce.Autoriza.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeAutorizacaoLote(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.Autoriza4.NFeAutorizacao4 nfce = new br.gov.pr.sefa.nfce.Autoriza4.NFeAutorizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeAutorizacaoLote(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfe.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                br.gov.pr.fazenda.nfce.homologacao.Autoriza.NfeAutorizacao3 nfce = new NFCe.br.gov.pr.fazenda.nfce.homologacao.Autoriza.NfeAutorizacao3();
                                nfce.nfeCabecMsgValue = new NFCe.br.gov.pr.fazenda.nfce.homologacao.Autoriza.nfeCabecMsg()
                                {
                                    cUF = rCfgNfe.Cd_uf_empresa,
                                    versaoDados = rCfgNfe.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeAutorizacaoLote(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.Autoriza4.NFeAutorizacao4 nfce = new br.gov.pr.sefa.nfce.homologacao.Autoriza4.NFeAutorizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfe.Nr_certificado_nfe));
                                return nfce.nfeAutorizacaoLote(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static decimal? GerarIdLote(decimal? Id_lote,
                                           decimal? Nr_protocololote,
                                           DateTime? dt_recebimento,
                                           decimal? tempomedio,
                                           string st_registro,
                                           decimal? status,
                                           string ds_mensagem,
                                           CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNFCe)
        {
            return decimal.Parse(CamadaNegocio.Faturamento.NFCe.TCN_LoteNFCe.Gravar(
                                new CamadaDados.Faturamento.NFCe.TRegistro_LoteNFCe()
                                {
                                    Id_lote = Id_lote,
                                    Cd_empresa = rCfgNFCe.Cd_empresa,
                                    Nr_protocololote = Nr_protocololote,
                                    Dt_recebimento = dt_recebimento,
                                    Tempomedio = tempomedio.HasValue ? tempomedio.Value : decimal.Zero,
                                    St_registro = st_registro,
                                    Status = status.HasValue ? status.Value : decimal.Zero,
                                    Ds_mensagem = ds_mensagem,
                                    Tp_ambiente = rCfgNFCe.Tp_ambiente_nfce
                                }, null));
        }

        public static void GravarLoteXNFCe(decimal Id_lote,
                                           CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe,
                                           DateTime? dt_processamento,
                                           decimal nr_protocolo,
                                           string digitoverificado,
                                           decimal status,
                                           string ds_mensagem,
                                           string Veraplic)
        {
            CamadaNegocio.Faturamento.NFCe.TCN_Lote_X_NFCe.Gravar(
                new CamadaDados.Faturamento.NFCe.TRegistro_Lote_X_NFCe()
                {
                    Id_lote = Id_lote,
                    Cd_empresa = rNFCe.Cd_empresa,
                    Id_cupom = rNFCe.Id_nfce,
                    Dt_processamento = dt_processamento,
                    Nr_protocolo = nr_protocolo,
                    Digval = digitoverificado,
                    Status = status,
                    Ds_mensagem = ds_mensagem,
                    Veraplic = Veraplic
                }, null);
        }

        public static void DeletarNFCeLotesProblemas(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().Select(
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
                        vVL_Busca = "(select 1 from tb_fat_lotenfce x "+
                                    "where x.id_lote = a.id_lote "+
                                    "and isnull(x.st_registro, 'A') = 'A' "+
                                    "and x.status is null "+
                                    "and x.tp_ambiente <> '3')"
                    }
                }, 0, string.Empty).ForEach(p => CamadaNegocio.Faturamento.NFCe.TCN_Lote_X_NFCe.Excluir(p, null));
        }

        public static void DeletarLotesProblemas(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().Select(
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
                }, 0, string.Empty).ForEach(p => CamadaNegocio.Faturamento.NFCe.TCN_LoteNFCe.Excluir(p, null));
        }

        public static bool EnviarLote(decimal? Id_lote,
                                      List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> lNFCe)
        {
            bool ret = false;
            if (lNFCe.Count > 0)
            {
                //Validar Certificado
                srvNFE.ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(lNFCe[0].rCfgNFCe);
                //Verificar status do servico junto a receita
                if (ConsultaStatusServico.TConsultaStatusServico.StatusServico(lNFCe[0].rCfgNFCe).Trim() != "107")
                    throw new Exception("Serviço indisponivel no momento.\r\nAguarde alguns minutos e tente novamente.");
                GerarXML.TGerarXML.GerarXML(lNFCe);

                StringBuilder xml = new StringBuilder();
                xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
                #region enviNFe
                xml.Append("<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + lNFCe[0].rCfgNFCe.Cd_versaonfce.Trim() + "\">\n");
                if (!Id_lote.HasValue)
                    Id_lote = GerarIdLote(null,
                                          null,
                                          null,
                                          decimal.Zero,
                                          "A",
                                          null,
                                          string.Empty,
                                          lNFCe[0].rCfgNFCe);
                if (!Id_lote.HasValue)
                    throw new Exception("Erro gerar Id. do lote");
                #region "idLote"
                xml.Append("<idLote>");
                xml.Append(Id_lote.ToString().PadLeft(15, '0'));
                xml.Append("</idLote>\n");
                #endregion
                #region indSinc
                xml.Append("<indSinc>");
                xml.Append(lNFCe.Count > 1 ? "0" : "1");
                xml.Append("</indSinc>");
                #endregion
                lNFCe.ForEach(p =>
                {
                    XmlDocument documento = new XmlDocument();
                    documento.LoadXml(p.XmlNFCe);
                    //Gravar lote x nota fiscal
                    GravarLoteXNFCe(Id_lote.Value,
                                    p,
                                    null,
                                    decimal.Zero,
                                    string.Empty,
                                    decimal.Zero,
                                    string.Empty,
                                    string.Empty);
                    xml.Append(p.XmlNFCe + "\n");
                });
                xml.Append("</enviNFe>\n");
                #endregion

                //Validar Arquivo Lote
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                        lNFCe[0].rCfgNFCe.Path_nfe_schemas.SeparadorDiretorio() + "enviNFe_v" + lNFCe[0].rCfgNFCe.Cd_versaonfce.Trim() + ".xsd",
                                                        "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                try
                {
                    //Enviar Lote para Receita
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml.ToString());
                    XmlNode retorno = ConectarWebService(doc.DocumentElement, lNFCe[0].rCfgNFCe);
                    //Tratar retorno
                    if (retorno != null)
                    {
                        if (retorno["cStat"].InnerText.Trim().Equals("103") ||
                            retorno["cStat"].InnerText.Trim().Equals("104"))
                        {
                            //Lote recebido com sucesso
                            //Gravar dados do lote no banco de dados
                            decimal? nRec = null;
                            DateTime? dhRecbto = null;
                            decimal? tMed = null;
                            try
                            {
                                dhRecbto = Convert.ToDateTime(retorno["dhRecbto"].InnerText);
                            }
                            catch { }
                            if (retorno.InnerXml.Contains("infRec"))
                            {
                                nRec = Convert.ToDecimal(retorno["infRec"]["nRec"].InnerText);
                                tMed = Convert.ToDecimal(retorno["infRec"]["tMed"].InnerText);
                            }
                            else if (retorno.InnerXml.Contains("protNFe"))
                            {
                                DateTime? dt_rec = null;
                                try
                                {
                                    dt_rec = Convert.ToDateTime(retorno["protNFe"]["infProt"]["dhRecbto"].InnerText);
                                    lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Dt_processamento = dt_rec;
                                }
                                catch { }
                                decimal nprot = decimal.Zero;
                                try
                                {
                                    nprot = Convert.ToDecimal(retorno["protNFe"]["infProt"]["nProt"].InnerText);
                                    lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Nr_protocolo = nprot;
                                }
                                catch { }
                                decimal status = decimal.Zero;
                                try
                                {
                                    status = Convert.ToDecimal(retorno["protNFe"]["infProt"]["cStat"].InnerText);
                                    if (status.Equals(100))
                                        lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Digval =
                                            retorno["protNFe"]["infProt"]["digVal"].InnerText;
                                }
                                catch { }
                                GravarLoteXNFCe(Id_lote.Value,
                                                lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)),
                                                dt_rec,
                                                nprot,
                                                (status.Equals(100) ? retorno["protNFe"]["infProt"]["digVal"].InnerText : string.Empty),
                                                status,
                                                retorno["protNFe"]["infProt"]["xMotivo"].InnerText,
                                                retorno["protNFe"]["infProt"]["verAplic"].InnerText);
                                if (lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Id_contingencia.HasValue &&
                                    lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).St_registro.Trim().ToUpper().Equals("C"))
                                {
                                    try
                                    {
                                        //Buscar evento de cancelamento
                                        CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                            CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Cd_empresa,
                                                                                                lNFCe.Find(p => p.Chave_acesso.Trim().Equals(retorno["protNFe"]["infProt"]["chNFe"].InnerText)).Id_nfcestr,
                                                                                                string.Empty,
                                                                                                null);
                                        if (lEvento.Count > 0)
                                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                            {
                                                lEvento[0].Chave_acesso_nfce = retorno["protNFe"]["infProt"]["chNFe"].InnerText;
                                                NFCe.EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], lNFCe[0].rCfgNFCe);
                                            }
                                    }
                                    catch { }
                                }
                                ret = true;
                            }
                            GerarIdLote(Id_lote,
                                        nRec,
                                        dhRecbto,
                                        tMed,
                                        ret ? "P" : "E",
                                        Convert.ToDecimal(retorno["cStat"].InnerText),
                                        retorno["xMotivo"].InnerText,
                                        lNFCe[0].rCfgNFCe);
                            //Gravar xml e chave acesso no banco
                            lNFCe.ForEach(p =>
                            {
                                CamadaDados.TDataQuery query = new CamadaDados.TDataQuery();
                                System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
                                hs.Add("@CHAVE", p.Chave_acesso);
                                hs.Add("@CD_EMPRESA", p.Cd_empresa);
                                hs.Add("@ID_NFCE", p.Id_nfce);
                                query.executarSql("update tb_pdv_nfce set chave_acesso = @CHAVE, dt_alt = getdate() " +
                                                  "where cd_empresa = @CD_EMPRESA and id_nfce = @ID_NFCE", hs);
                                new CamadaDados.Faturamento.PDV.TCD_XML_NFCe()
                                .Gravar(new CamadaDados.Faturamento.PDV.TRegistro_XML_NFCe
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Id_nfce = p.Id_nfce,
                                    Xml_nfce = p.XmlNFCe
                                });
                            });
                        }
                        else
                            //Erro no envio do lote
                            //Gravar mensagem de erro de envio do lote
                            GerarIdLote(Id_lote,
                                        null,
                                        null,
                                        null,
                                        "A",
                                        Convert.ToDecimal(retorno["cStat"].InnerText),
                                        retorno["xMotivo"].InnerText,
                                        lNFCe[0].rCfgNFCe);
                    }
                    else
                        throw new Exception("Serviço Enviar NFC-e indisponivel no momento.");
                }
                catch (Exception ex)
                {
                    DeletarNFCeLotesProblemas(lNFCe[0].rCfgNFCe);
                    DeletarLotesProblemas(lNFCe[0].rCfgNFCe);
                    throw new Exception(ex.Message.Trim());
                }
            }
            return ret;
        }
    }
}
