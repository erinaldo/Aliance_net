using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Utils;

namespace NFCe.RetAutoriza
{
    public class TRetAutoriza
    {
        private static XmlNode ConectarWebService(XmlNode nfceDadosMsg, CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfce)
        {
            switch (rCfgNfce.Cd_uf_empresa.Trim())
            {
                case "41":
                    {
                        if (rCfgNfce.Tp_ambiente_nfce.Trim().Equals("1"))//Producao
                        {
                            if (rCfgNfce.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.PRRetAutoriza3.NfeRetAutorizacao3 nfce = new srvNFE.br.gov.pr.fazenda.nfe.PRRetAutoriza3.NfeRetAutorizacao3();
                                nfce.Url = "https://nfce.fazenda.pr.gov.br/nfce/NFeRetAutorizacao3";
                                nfce.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.PRRetAutoriza3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaonfce
                                };
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRetAutorizacao(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.RetAutoriza4.NFeRetAutorizacao4 nfce = new br.gov.pr.sefa.nfce.RetAutoriza4.NFeRetAutorizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRetAutorizacaoLote(nfceDadosMsg);
                            }
                        }
                        else//Homologacao
                        {
                            if (rCfgNfce.Cd_versaonfce.Trim().Equals("3.10"))
                            {
                                srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.NfeRetAutorizacao3 nfe = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.NfeRetAutorizacao3();
                                nfe.Url = "https://homologacao.nfce.fazenda.pr.gov.br/nfce/NFeRetAutorizacao3";
                                nfe.nfeCabecMsgValue = new srvNFE.br.gov.pr.fazenda.nfe.homologacao.PRRetAutoriza3.nfeCabecMsg()
                                {
                                    cUF = rCfgNfce.Cd_uf_empresa,
                                    versaoDados = rCfgNfce.Cd_versaonfce
                                };
                                nfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfe.nfeRetAutorizacao(nfceDadosMsg);
                            }
                            else//4.00
                            {
                                br.gov.pr.sefa.nfce.homologacao.RetAutorizacao4.NFeRetAutorizacao4 nfce = new br.gov.pr.sefa.nfce.homologacao.RetAutorizacao4.NFeRetAutorizacao4();
                                nfce.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                                nfce.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfce.Nr_certificado_nfe));
                                return nfce.nfeRetAutorizacaoLote(nfceDadosMsg);
                            }
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaNFERecepcao(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfe)
        {
            //Validar certificado
            srvNFE.ConsultaStatusServico.ConsultaStatusServico.ValidarCertificado(rCfgNfe);
            string msg = string.Empty;
            //Buscar Lotes aguardando processamento
            new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.st_registro",
                        vOperador = "=",
                        vVL_Busca = "'E'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.status",
                        vOperador = "<>",
                        vVL_Busca = "'215'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x "+
                                    "where x.id_lote = a.id_lote "+
                                    "and x.cd_empresa = '" + rCfgNfe.Cd_empresa.Trim() + "')"
                    }
                }, 0, string.Empty).ForEach(p =>
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
                xml.Append("<consReciNFe versao=\"" + rCfgNfe.Cd_versaonfce.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">\n");
                xml.Append("<tpAmb>");
                xml.Append(p.Tp_ambiente.Trim());
                xml.Append("</tpAmb>\n");
                xml.Append("<nRec>");
                xml.Append(p.Nr_protocololote.ToString().PadLeft(15, '0'));
                xml.Append("</nRec>\n");
                xml.Append("</consReciNFe>\n");

                //Validar schema xml
                Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                         rCfgNfe.Path_nfe_schemas.SeparadorDiretorio() + "consReciNFe_v" + rCfgNfe.Cd_versaonfce.Trim() + ".xsd",
                                                         "NFE");
                if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                    throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

                //Conectar Web Service
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml.ToString());
                XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgNfe);

                //Tratar retorno
                if (retorno["cStat"].InnerText.Trim().Equals("104"))
                {
                    //Atualizar status do lote
                    NFCe.EnviaArq.TEnviaArq.GerarIdLote(p.Id_lote,
                                                        p.Nr_protocololote,
                                                        p.Dt_recebimento,
                                                        p.Tempomedio,
                                                        "P",
                                                        Convert.ToDecimal(retorno["cStat"].InnerText),
                                                        retorno["xMotivo"].InnerText,
                                                        rCfgNfe);
                    msg += "Lote: " + p.Id_lote.ToString() + "\r\nMensagem: " + retorno["xMotivo"].InnerText.Trim() + "\r\n";
                    //Tratar as Notas do Lote
                    foreach (XmlNode no in retorno.ChildNodes)
                    {
                        if (no.Name.Trim().Equals("protNFe"))
                        {
                            DateTime? dt_rec = null;
                            try
                            {
                                dt_rec = Convert.ToDateTime(no["infProt"]["dhRecbto"].InnerText);
                            }
                            catch { }
                            decimal nprot = decimal.Zero;
                            try
                            {
                                nprot = Convert.ToDecimal(no["infProt"]["nProt"].InnerText);
                            }
                            catch { }
                            decimal status = decimal.Zero;
                            try
                            {
                                status = Convert.ToDecimal(no["infProt"]["cStat"].InnerText);
                            }
                            catch { }
                            //Buscar NFCe
                            CamadaDados.Faturamento.PDV.TList_NFCe lNFCe =
                                new CamadaDados.Faturamento.PDV.TCD_NFCe().Select(
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
                                        vNM_Campo = "a.chave_acesso",
                                        vOperador = "=",
                                        vVL_Busca = "'" + no["infProt"]["chNFe"].InnerText + "'"
                                    }
                                }, 1, string.Empty, string.Empty);
                            if (lNFCe.Count > 0)
                            {
                                EnviaArq.TEnviaArq.GravarLoteXNFCe(p.Id_lote.Value,
                                                                   lNFCe[0],
                                                                   dt_rec,
                                                                   nprot,
                                                                   (status.Equals(100) ? no["infProt"]["digVal"].InnerText : string.Empty),
                                                                   status,
                                                                   no["infProt"]["xMotivo"].InnerText,
                                                                   no["infProt"]["verAplic"].InnerText);
                                if (lNFCe[0].Id_contingencia.HasValue &&
                                    lNFCe[0].St_registro.Trim().ToUpper().Equals("C"))
                                {
                                    try
                                    {
                                        //Buscar evento de cancelamento
                                        CamadaDados.Faturamento.PDV.TList_EventoNFCe lEvento =
                                            CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(lNFCe[0].Cd_empresa,
                                                                                                lNFCe[0].Id_nfcestr,
                                                                                                string.Empty,
                                                                                                null);
                                        if (lEvento.Count > 0)
                                            if (!lEvento[0].St_registro.Trim().ToUpper().Equals("T"))
                                            {
                                                lEvento[0].Chave_acesso_nfce = retorno["protNFe"]["infProt"]["chNFe"].InnerText;
                                                EventoNFCe.TEventoNFCe.EnviarEvento(lEvento[0], rCfgNfe);
                                            }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
                else
                    EnviaArq.TEnviaArq.GerarIdLote(p.Id_lote,
                                                   p.Nr_protocololote,
                                                   p.Dt_recebimento,
                                                   p.Tempomedio,
                                                   p.St_registro,
                                                   Convert.ToDecimal(retorno["cStat"].InnerText),
                                                   retorno["xMotivo"].InnerText,
                                                   rCfgNfe);
            });
            return msg;
        }
    }
}
