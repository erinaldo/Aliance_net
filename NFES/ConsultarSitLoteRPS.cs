using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace NFES
{
    public class TConsultarSitLoteRPS
    {
        private static string ConectarWebServico(string mensagem,
                                                 CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfes)
        {
            switch (rCfgNfes.Cd_municipio_empresa.Trim())
            {
                case ("4127700")://Toledo-PR
                    {
                        if (rCfgNfes.Tp_ambiente_nfes.Trim().ToUpper().Equals("P"))//Producao
                        {
                            br.com.esnfs.TOONfes.Enfs nfes = new NFES.br.com.esnfs.TOONfes.Enfs();
                            nfes.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfes.Nr_certificado_nfe));
                            return nfes.esConsultarSituacaoLoteRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                        else//Homologacao
                        {
                            br.com.esnfs.HTOONfes.Enfs nfes = new NFES.br.com.esnfs.HTOONfes.Enfs();
                            nfes.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfes.Nr_certificado_nfe));
                            return nfes.esConsultarSituacaoLoteRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                    }
                default:
                    return string.Empty;
            }
        }

        public static void ConsultarSitLoteRPS(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfes)
        {
            //Buscar Lotes a Serem Consultados
            new CamadaDados.Faturamento.NFES.TCD_LoteRPS().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rCfgNfes.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_ambiente",
                        vOperador = "=",
                        vVL_Busca = "'" + rCfgNfes.Tp_ambiente_nfes.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.st_lote",
                        vOperador = "in",
                        vVL_Busca = "('1', '2')"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fat_loterps_x_nfes x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_lote = a.id_lote)"
                    }
                }, 0, string.Empty).ForEach(p =>
                {
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    #region es:esConsultarSituacaoLoteRpsEnvio
                    xml.Append("<es:esConsultarSituacaoLoteRpsEnvio xmlns:es=\"http://www.equiplano.com.br/esnfs\" ");
                    xml.Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                    xml.Append("xsi:schemaLocation=\"http://www.equiplano.com.br/enfs esConsultarSituacaoLoteRpsEnvio_v01.xsd\">");

                    #region prestador
                    xml.Append("<prestador>");
                    #region nrInscricaoMunicipal
                    xml.Append("<nrInscricaoMunicipal>");
                    xml.Append(System.Text.RegularExpressions.Regex.Replace(rCfgNfes.Insc_municipal_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                    xml.Append("</nrInscricaoMunicipal>");
                    #endregion

                    #region nrCnpj
                    xml.Append("<cnpj>");
                    xml.Append(System.Text.RegularExpressions.Regex.Replace(rCfgNfes.Cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                    xml.Append("</cnpj>");
                    #endregion

                    #region idEntidade
                    xml.Append("<idEntidade>");
                    xml.Append(rCfgNfes.Id_entidadenfes);
                    xml.Append("</idEntidade>");
                    #endregion
                    xml.Append("</prestador>");
                    #endregion

                    #region nrLoteRps
                    xml.Append("<nrLoteRps>");
                    xml.Append(p.Id_lotestr);
                    xml.Append("</nrLoteRps>");
                    #endregion

                    xml.Append("</es:esConsultarSituacaoLoteRpsEnvio>");
                    #endregion

                    //Assinar documento XML
                    string xmlassinado = 
                        new Utils.Assinatura.TAssinatura2(rCfgNfes.Nr_certificado_nfe,
                                                          xml.ToString()).AssinarNFSe();

                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgNfes.Path_nfe_schemas.SeparadorDiretorio() + "esConsultarSituacaoLoteRpsEnvio_v01.xsd",
                                                            "NFES");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());

                    //Conectar Web Service
                    string retorno = ConectarWebServico(xmlassinado, rCfgNfes);
                    if (!string.IsNullOrEmpty(retorno))
                    {
                        XmlDocument documento = new XmlDocument();
                        documento.LoadXml(retorno);
                        p.St_lote = documento["es:esConsultarSituacaoLoteRpsResposta"]["stLote"].InnerText.Trim();
                        CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Gravar(p, null);
                        if (documento["es:esConsultarSituacaoLoteRpsResposta"].GetElementsByTagName("mensagemRetorno").Count > 0)
                        {
                            foreach (XmlNode no in documento["es:esConsultarSituacaoLoteRpsResposta"]["mensagemRetorno"].ChildNodes)
                            {
                                p.lMsgRPS.Add(new CamadaDados.Faturamento.NFES.TRegistro_MsgRetornoRPS()
                                {
                                    Cd_mensagem = no["erro"]["cdMensagem"].InnerText.Trim(),
                                    Ds_mensagem = no["erro"]["dsMensagem"].InnerText.Trim(),
                                    Tp_origem = "2"
                                });
                                CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Gravar(p, null);
                            }
                        }
                        if (p.St_lote.Trim().Equals("3"))
                            CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.Buscar(p.Id_lotestr,
                                                                                     p.Cd_empresa,
                                                                                     string.Empty,
                                                                                     null).ForEach(v =>
                                                                                     {
                                                                                         string ret = TConsultarNfes.ConsultarNFSePorRPS(v.Nr_rps.Value, rCfgNfes);
                                                                                         if (!string.IsNullOrEmpty(ret))
                                                                                         {
                                                                                             XmlDocument doc = new XmlDocument();
                                                                                             doc.LoadXml(ret);
                                                                                             if (doc["es:esConsultarNfsePorRpsResposta"].ChildNodes.Count > 0)
                                                                                             {
                                                                                                 v.Cd_autenticacao = doc["es:esConsultarNfsePorRpsResposta"]["nfse"]["cdAutenticacao"].InnerText;
                                                                                                 try
                                                                                                 {
                                                                                                     v.Dt_autorizacao = DateTime.Parse(doc["es:esConsultarNfsePorRpsResposta"]["nfse"]["dtEmissaoNfs"].InnerText);
                                                                                                 }
                                                                                                 catch { }
                                                                                                 try
                                                                                                 {
                                                                                                     v.Nr_nfse = decimal.Parse(doc["es:esConsultarNfsePorRpsResposta"]["nfse"]["nrNfse"].InnerText);
                                                                                                 }
                                                                                                 catch { }
                                                                                                 CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.Gravar(v, null);
                                                                                                 CamadaNegocio.Faturamento.NFES.TCN_LoteRPS_X_NFES.CorrigirNumeroNFSe(v, null);
                                                                                             }
                                                                                         }
                                                                                     });
                    }
                });
        }
    }
}
