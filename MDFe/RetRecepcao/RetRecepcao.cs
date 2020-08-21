using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.RetRecepcao
{
    public class TRetRecepcao
    {
        private static XmlNode ConectarWebService(XmlNode mdfeDadosMsg,
                                                  TRegistro_CfgMDFe rCfgMDFe)
        {
            switch (rCfgMDFe.rEmp.rEndereco.Cd_uf.Trim())
            {
                case ("41")://Minas Gerais
                    {
                        if (rCfgMDFe.Tp_ambiente.Trim().ToUpper().Equals("1"))//Producao
                        {
                            br.gov.rs.svrs.mdfe.RetRec.MDFeRetRecepcao mdfe = new MDFe.br.gov.rs.svrs.mdfe.RetRec.MDFeRetRecepcao();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.RetRec.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeRetRecepcao(mdfeDadosMsg);
                        }
                        else //Homologacao
                        {
                            br.gov.rs.svrs.mdfe.homolog.RetRec.MDFeRetRecepcao mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.RetRec.MDFeRetRecepcao();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.RetRec.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeRetRecepcao(mdfeDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static string ConsultaRetRecepcao(TRegistro_CfgMDFe rCfgMDFe)
        {
            string msg = string.Empty;
            new CamadaDados.Frota.TCD_LoteMDFe().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCfgMDFe.Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cStat",
                                vOperador = "=",
                                vVL_Busca = "103"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nRec",
                                vOperador = "is not",
                                vVL_Busca = "null"
                            }
                        }, 0, string.Empty, string.Empty).ForEach(p =>
                        {
                            StringBuilder xml = new StringBuilder();
                            xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                            xml.Append("<consReciMDFe versao=\"" + rCfgMDFe.Cd_versaomdfe.Trim() + "\" xmlns=\"http://www.portalfiscal.inf.br/mdfe\">");
                            xml.Append("<tpAmb>");
                            xml.Append(rCfgMDFe.Tp_ambiente);
                            xml.Append("</tpAmb>");
                            xml.Append("<nRec>");
                            xml.Append(p.nRec.PadLeft(15, '0'));
                            xml.Append("</nRec>");
                            xml.Append("</consReciMDFe>");

                            //Validar schema xml
                            Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                                     rCfgMDFe.Path_schemas.SeparadorDiretorio() + "consReciMDFe_v" + rCfgMDFe.Cd_versaomdfe.Trim() + ".xsd",
                                                                     "MDFE");
                            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno);

                            //Conectar Web Service
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(xml.ToString());
                            XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMDFe);

                            //Tratar retorno
                            if (retorno["cStat"].InnerText.Trim().Equals("104"))
                            {
                                p.cStat = retorno["cStat"].InnerText;
                                p.xMotivo = retorno["xMotivo"].InnerText;
                                CamadaNegocio.Frota.TCN_LoteMDFe.Gravar(p, null);
                                msg += "Lote: " + p.Id_lote.ToString() + "\r\nMensagem: " + retorno["xMotivo"].InnerText.Trim() + "\r\n";
                                //Tratar as Notas do Lote
                                foreach (XmlNode no in retorno.ChildNodes)
                                {
                                    if (no.Name.Trim().Equals("protMDFe"))
                                    {
                                        DateTime? dt_rec = null;
                                        try
                                        {
                                            dt_rec = Convert.ToDateTime(no["infProt"]["dhRecbto"].InnerText);
                                        }
                                        catch { }
                                        //Buscar CTe
                                        new CamadaDados.Frota.TCD_Lote_X_MDFe().Select(
                                            new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rCfgMDFe.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_lote",
                                                        vOperador = "=",
                                                        vVL_Busca = p.Id_lotestr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "c.chaveacesso",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + no["infProt"]["chMDFe"].InnerText.Trim() + "'"
                                                    }
                                                }, 1, string.Empty).ForEach(v =>
                                                {
                                                    v.dhRecbto = dt_rec;
                                                    v.nProt = no["infProt"]["cStat"].InnerText.Equals("100") ? no["infProt"]["nProt"].InnerText : string.Empty;
                                                    v.digVal = no["infProt"]["cStat"].InnerText.Equals("100") ? no["infProt"]["digVal"].InnerText : string.Empty;
                                                    v.cStat = no["infProt"]["cStat"].InnerText;
                                                    v.xMotivo = no["infProt"]["xMotivo"].InnerText;
                                                    v.Xml_lote = no.OuterXml;
                                                    CamadaNegocio.Frota.TCN_Lote_X_MDFe.Gravar(v, null);
                                                });
                                    }
                                }
                            }
                            else
                            {
                                p.cStat = retorno["cStat"].InnerText;
                                p.xMotivo = retorno["xMotivo"].InnerText;
                                CamadaNegocio.Frota.TCN_LoteMDFe.Gravar(p, null);
                            }
                        });
            return msg;
        }
    }
}
