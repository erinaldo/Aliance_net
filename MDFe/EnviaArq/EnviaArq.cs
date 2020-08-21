using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;
using CamadaDados.Frota.Cadastros;

namespace MDFe.EnviaArq
{
    public class TEnviaArq
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
                            br.gov.rs.svrs.mdfe.RecLote.MDFeRecepcao mdfe = new MDFe.br.gov.rs.svrs.mdfe.RecLote.MDFeRecepcao();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.RecLote.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeRecepcaoLote(mdfeDadosMsg);
                        }
                        else //Homologacao
                        {
                            br.gov.rs.svrs.mdfe.homolog.RecLote.MDFeRecepcao mdfe = new MDFe.br.gov.rs.svrs.mdfe.homolog.RecLote.MDFeRecepcao();
                            mdfe.mdfeCabecMsgValue = new MDFe.br.gov.rs.svrs.mdfe.homolog.RecLote.mdfeCabecMsg()
                            {
                                cUF = rCfgMDFe.rEmp.rEndereco.Cd_uf,
                                versaoDados = rCfgMDFe.Cd_versaomdfe
                            };
                            mdfe.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                            mdfe.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgMDFe.Nr_certificado));
                            return mdfe.mdfeRecepcaoLote(mdfeDadosMsg);
                        }
                    }
                default: return null;
            }
        }

        public static void EnviarLoteMDFe(List<CamadaDados.Frota.TRegistro_MDFe> lMDFe,
                                          TRegistro_CfgMDFe rCfgMDFe)
        {
            if (lMDFe != null)
            {
                //Verificar status do servico junto a receita
                if (MDFe.StatusServico.TStatusServico.StatusServico(rCfgMDFe).Trim() != "107")
                    throw new Exception("Serviço indisponivel no momento.\r\nAguarde alguns minutos e tente novamente.");
                CamadaDados.Frota.TRegistro_LoteMDFe lote = new CamadaDados.Frota.TRegistro_LoteMDFe();
                try
                {
                    lote.Cd_empresa = rCfgMDFe.Cd_empresa;
                    lote.Tp_ambiente = rCfgMDFe.Tp_ambiente;
                    CamadaNegocio.Frota.TCN_LoteMDFe.Gravar(lote, null);
                    MDFe.GerarArq.TGerarArq.GerarArquivoXml(lMDFe, rCfgMDFe);
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    xml.Append("<enviMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfgMDFe.Cd_versaomdfe.Trim() + "\">");
                    xml.Append("<idLote>");
                    xml.Append(lote.Id_lotestr);
                    xml.Append("</idLote>");
                    lMDFe.ForEach(p =>
                    {
                        //Gravar lote x cte
                        CamadaNegocio.Frota.TCN_Lote_X_MDFe.Gravar(
                            new CamadaDados.Frota.TRegistro_Lote_X_MDFe()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_mdfe = p.Id_mdfe,
                                Id_lote = lote.Id_lote
                            }, null);
                        xml.Append(p.Xml_mdfe);
                    });
                    xml.Append("</enviMDFe>");
                    //Validar arquivo lote
                    Utils.ValidaSchema.ValidaXML2.validaXML(xml.ToString(),
                                                            rCfgMDFe.Path_schemas.SeparadorDiretorio() + "enviMDFe_v" + rCfgMDFe.Cd_versaomdfe.Trim() + ".xsd",
                                                            "MDFE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                    //Enviar Lote para Receita
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml.ToString());
                    XmlNode retorno = ConectarWebService(doc.DocumentElement, rCfgMDFe);
                    //Tratar retorno
                    if (retorno != null)
                    {
                        if (retorno["cStat"].InnerText.Trim().Equals("103"))
                        {
                            //Lote recebido com sucesso
                            //Gravar dados do lote no banco de dados
                            lote.cStat = retorno["cStat"].InnerText;
                            lote.xMotivo = retorno["xMotivo"].InnerText;
                            if (retorno["infRec"].FirstChild != null)
                            {
                                try
                                {
                                    lote.dhRebcto = DateTime.Parse(retorno["infRec"]["dhRecbto"].InnerText);
                                }
                                catch { }
                                lote.nRec = retorno["infRec"]["nRec"].InnerText;
                            }
                            CamadaNegocio.Frota.TCN_LoteMDFe.Gravar(lote, null);
                        }
                        else
                        {
                            lote.cStat = retorno["cStat"].InnerText;
                            lote.xMotivo = retorno["xMotivo"].InnerText;
                            CamadaNegocio.Frota.TCN_LoteMDFe.Gravar(lote, null);
                        }
                    }
                    else
                        throw new Exception("Serviço Enviar MDF-e indisponivel no momento.");
                }
                catch (Exception ex)
                {
                    CamadaNegocio.Frota.TCN_Lote_X_MDFe.Buscar(lote.Cd_empresa, lote.Id_lotestr, null).ForEach(p =>
                        CamadaNegocio.Frota.TCN_Lote_X_MDFe.Excluir(p, null));
                    CamadaNegocio.Frota.TCN_LoteMDFe.Excluir(lote, null);
                    throw new Exception("Erro ao enviar Lote!" + ex.Message.Trim());
                }
            }
        }
    }
}
