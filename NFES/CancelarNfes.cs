using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Utils;

namespace NFES
{
    public class TCancelarNfes
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
                            return nfes.esCancelarNfse(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                        else//Homologacao
                        {
                            br.com.esnfs.HTOONfes.Enfs nfes = new NFES.br.com.esnfs.HTOONfes.Enfs();
                            nfes.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfes.Nr_certificado_nfe));
                            return nfes.esCancelarNfse(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                    }
                default:
                    return string.Empty;
            }
        }

        public static void CancelarNFSe(List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNf,
                                        string MotivoCanc,
                                        CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfes)
        {
            lNf.ForEach(p =>
                {
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    #region esCancelarNfseEnvio
                    xml.Append("<es:esCancelarNfseEnvio xmlns:es=\"http://www.equiplano.com.br/esnfs\" ");
                    xml.Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                    xml.Append("xsi:schemaLocation=\"http://www.equiplano.com.br/enfs esCancelarNfseEnvio_v01.xsd\">");

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

                    #region nrNfse
                    xml.Append("<nrNfse>");
                    xml.Append(p.Nr_notafiscal);
                    xml.Append("</nrNfse>");
                    #endregion

                    #region dsMotivoCancelamento
                    xml.Append("<dsMotivoCancelamento>");
                    xml.Append(MotivoCanc.Trim());
                    xml.Append("</dsMotivoCancelamento>");
                    #endregion
                    xml.Append("</es:esCancelarNfseEnvio>");
                    #endregion

                    //Assinar documento XML
                    string xmlassinado = 
                        new Utils.Assinatura.TAssinatura2(rCfgNfes.Nr_certificado_nfe,
                                                          xml.ToString()).AssinarNFSe();

                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgNfes.Path_nfe_schemas.SeparadorDiretorio() + "esCancelarNfseEnvio_v01.xsd",
                                                            "NFES");

                    //Conectar Web Service
                    string retorno = ConectarWebServico(xmlassinado, rCfgNfes);

                    //Tratar retorno
                    if (!string.IsNullOrEmpty(retorno))
                    {
                        XmlDocument documento = new XmlDocument();
                        documento.LoadXml(retorno);
                        try
                        {
                            if (documento["es:esCancelarNfseResposta"]["sucesso"].InnerText.Trim().ToUpper().Equals("TRUE"))
                            {
                                //Gravar Data Cancelamento
                                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                                hs.Add("@P_EMPRESA", p.Cd_empresa);
                                hs.Add("@P_LANCTO", p.Nr_lanctofiscal);
                                hs.Add("@DT_CANC", Convert.ToDateTime(documento["es:esCancelarNfseResposta"]["dtCancelamento"].InnerText));
                                new CamadaDados.TDataQuery().executarSql("update tb_fat_loterps_x_nfes " +
                                                                         "set dt_cancelamento = @DT_CANC, " +
                                                                         "dt_alt = getdate() " +
                                                                         "where cd_empresa = @P_EMPRESA " +
                                                                         "and nr_lanctofiscal = @P_LANCTO", hs);
                            }
                        }
                        catch
                        {
                            string msg = string.Empty;
                            string rtCancelado = string.Empty;
                            foreach (XmlNode no in documento["es:esCancelarNfseResposta"]["mensagemRetorno"]["listaErros"].ChildNodes){
                                msg += no["cdMensagem"].InnerText + "-" + no["dsMensagem"].InnerText;
                                rtCancelado = no["cdMensagem"].InnerText;
                            }
                            // se retorno = 8009  ou seja cancelado na receita
                            try
                            {
                                if (rtCancelado.Equals("8009"))
                                {
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.CancelarFaturamento(p, null);
                                    throw new Exception("NFS-e já está cancelada na prefeitura!\r\n" +
                                                        "NFS-e cancelada no sistema Aliance.Net com sucesso!");
                                }
                            }
                            catch(Exception ex)
                            {
                                throw new Exception("erro ao cancelar a nfs-e" + ex);
                            }
                            throw new Exception(msg);
                        }
                    }
                });
        }
    }
}
