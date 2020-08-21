using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace NFES
{
    public class TConsultarNfes
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
                            return nfes.esConsultarNfsePorRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                        else//Homologacao
                        {
                            br.com.esnfs.HTOONfes.Enfs nfes = new NFES.br.com.esnfs.HTOONfes.Enfs();
                            nfes.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfes.Nr_certificado_nfe));
                            return nfes.esConsultarNfsePorRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                    }
                default:
                    return string.Empty;
            }
        }
                
        public static string ConsultarNFSePorRPS(decimal Nr_RPS,
                                                 CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfes)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            #region es:esConsultarNfseEnvio
            xml.Append("<es:esConsultarNfsePorRpsEnvio xmlns:es=\"http://www.equiplano.com.br/esnfs\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.equiplano.com.br/enfs esConsultarNfsePorRpsEnvio_v01.xsd\">");
            #region rps
            xml.Append("<rps>");
            #region nrRps
            xml.Append("<nrRps>");
            xml.Append(Nr_RPS);
            xml.Append("</nrRps>");
            #endregion

            #region nrEmissorRps
            xml.Append("<nrEmissorRps>");
            xml.Append(1);
            xml.Append("</nrEmissorRps>");
            #endregion
            xml.Append("</rps>");
            #endregion

            #region prestador
            xml.Append("<prestador>");
            #region nrInscricaoMunicipal
            xml.Append("<nrInscricaoMunicipal>");
            xml.Append(System.Text.RegularExpressions.Regex.Replace(rCfgNfes.Insc_municipal_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
            xml.Append("</nrInscricaoMunicipal>");
            #endregion

            #region cnpj
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

            xml.Append("</es:esConsultarNfsePorRpsEnvio>");
            #endregion

            //Assinar documento XML
            string xmlassinado =
                new Utils.Assinatura.TAssinatura2(rCfgNfes.Nr_certificado_nfe,
                                                  xml.ToString()).AssinarNFSe();
            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                     rCfgNfes.Path_nfe_schemas.SeparadorDiretorio() + "esConsultarNfsePorRpsEnvio_v01.xsd",
                                                     "NFES");
            if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
            //Conectar Web Service
            return ConectarWebServico(xmlassinado, rCfgNfes);
        }
    }
}
