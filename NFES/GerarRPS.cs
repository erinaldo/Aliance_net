using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Utils;

namespace NFES
{
    public class TGerarRPS
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
                            return nfes.esRecepcionarLoteRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                        else//Homologacao
                        {
                            br.com.esnfs.HTOONfes.Enfs nfes = new NFES.br.com.esnfs.HTOONfes.Enfs();
                            nfes.ClientCertificates.Add(Utils.Assinatura.TAssinatura2.BuscaNroSerie(rCfgNfes.Nr_certificado_nfe));
                            return nfes.esRecepcionarLoteRps(TGerarRPS.CriarArquivoCabecalho(), mensagem);
                        }
                    }
                default:
                    return string.Empty;
            }
        }

        public static string CriarArquivoCabecalho()
        {
            XmlDocument documento = new XmlDocument();
            documento.AppendChild(documento.CreateXmlDeclaration("1.0", "UTF-8", null));
            #region cabecalho
            XmlNode cabec = documento.CreateElement("cabecalho");

            #region Versão
            XmlNode Versao = documento.CreateElement("Versão");

            #region versaoDados
            XmlNode versaoDados = documento.CreateElement("versaoDados");
            versaoDados.InnerText = "1";
            Versao.AppendChild(versaoDados);
            #endregion
            cabec.AppendChild(Versao);
            #endregion
            documento.AppendChild(cabec);
            #endregion

            return documento.InnerXml;
        }

        public static string CriarArquivoRPS(CamadaDados.Faturamento.Cadastros.TRegistro_CfgNfe rCfgNfes,
                                             List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento> lNf)
        {
            if(lNf == null)
            //Buscar Lista de NFSe para enviar a receita
            lNf = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rCfgNfes.Cd_empresa,
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
                                                                                "'S'",
                                                                                false,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
            if (lNf.Count > 0)
            {
                //Criar Lote RPS
                string id_loterps = CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Gravar(
                                    new CamadaDados.Faturamento.NFES.TRegistro_LoteRPS()
                                    {
                                        Cd_empresa = rCfgNfes.Cd_empresa,
                                        Dt_lote = CamadaDados.UtilData.Data_Servidor(),
                                        Tp_ambiente = rCfgNfes.Tp_ambiente_nfes
                                    }, null);
                try
                {
                    //Montar arquivo xml
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    #region es:enviarLoteRpsEnvio
                    xml.Append("<es:enviarLoteRpsEnvio xmlns:es=\"http://www.equiplano.com.br/esnfs\" ");
                    xml.Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                    xml.Append("xsi:schemaLocation=\"http://www.equiplano.com.br/enfs esRecepcionarLoteRpsEnvio_v01.xsd\">");

                    #region lote
                    xml.Append("<lote>");
                    #region nrLote
                    xml.Append("<nrLote>");
                    xml.Append(id_loterps);//Numero do Lote RPS
                    xml.Append("</nrLote>");
                    #endregion

                    #region qtRps
                    xml.Append("<qtRps>");
                    xml.Append(lNf.Count);//Quantidade Total de NFS no Lote
                    xml.Append("</qtRps>");
                    #endregion

                    #region nrVersaoXml
                    xml.Append("<nrVersaoXml>");
                    xml.Append(1);//Versao Atual do XML
                    xml.Append("</nrVersaoXml>");
                    #endregion

                    #region prestador
                    xml.Append("<prestador>");
                    #region nrCnpj
                    xml.Append("<nrCnpj>");
                    xml.Append(System.Text.RegularExpressions.Regex.Replace(rCfgNfes.Cnpj_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                    xml.Append("</nrCnpj>");
                    #endregion

                    #region nrInscricaoMunicipal
                    xml.Append("<nrInscricaoMunicipal>");
                    xml.Append(System.Text.RegularExpressions.Regex.Replace(rCfgNfes.Insc_municipal_empresa.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                    xml.Append("</nrInscricaoMunicipal>");
                    #endregion

                    #region isOptanteSimplesNacional
                    xml.Append("<isOptanteSimplesNacional>");
                    xml.Append(rCfgNfes.Tp_regimetributario.Trim().Equals("1") ? 1 : 2);//1=SIM, 2=NAO
                    xml.Append("</isOptanteSimplesNacional>");
                    #endregion

                    #region idEntidade
                    xml.Append("<idEntidade>");
                    xml.Append(rCfgNfes.Id_entidadenfes);
                    xml.Append("</idEntidade>");
                    #endregion
                    xml.Append("</prestador>");
                    #endregion

                    #region listaRps
                    xml.Append("<listaRps>");
                    lNf.ForEach(p =>
                    {
                        //Buscar Itens da NFe com os impostos
                        p.ItensNota = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.Busca(p.Cd_empresa, p.Nr_lanctofiscalstr, string.Empty, null);
                        #region rps
                        xml.Append("<rps>");
                        #region nrRps
                        xml.Append("<nrRps>");
                        xml.Append(p.Nr_rps);
                        xml.Append("</nrRps>");
                        #endregion

                        #region nrEmissorRps
                        xml.Append("<nrEmissorRps>");
                        xml.Append(1);//Utilizado para identificar qual terminal emitiu a nfse dentro da empresa
                        xml.Append("</nrEmissorRps>");
                        #endregion

                        #region dtEmissaoRps
                        xml.Append("<dtEmissaoRps>");
                        xml.Append(p.Dt_emissao.Value.ToString("yyyy-MM-dd") + "T" + p.Dt_emissao.Value.ToString("HH:mm:ss"));
                        xml.Append("</dtEmissaoRps>");
                        #endregion

                        #region stRps
                        xml.Append("<stRps>");
                        xml.Append(1);//1=converter, 2=converter e cancelar NFS, 3=cancelar RPS
                        xml.Append("</stRps>");
                        #endregion

                        #region tpTributacao
                        xml.Append("<tpTributacao>");
                        xml.Append(p.ItensNota[0].Tp_naturezaOperacaoISS);
                        xml.Append("</tpTributacao>");
                        #endregion

                        #region isIssRetido
                        xml.Append("<isIssRetido>");
                        xml.Append(p.ItensNota.Exists(v=> v.Vl_issretido > decimal.Zero) ? 1 : 2);//ISS retido 1=SIM, 2=NAO
                        xml.Append("</isIssRetido>");
                        #endregion

                        #region tomador
                        xml.Append("<tomador>");
                        #region documento
                        xml.Append("<documento>");
                        #region nrDocumento
                        xml.Append("<nrDocumento>");
                        xml.Append(p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ?
                            System.Text.RegularExpressions.Regex.Replace(p.rClifor.Nr_cgc.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty) :
                            System.Text.RegularExpressions.Regex.Replace(p.rClifor.Nr_cpf.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                        xml.Append("</nrDocumento>");
                        #endregion

                        #region tpDocumento
                        xml.Append("<tpDocumento>");
                        xml.Append(p.rClifor.Tp_pessoa.Trim().ToUpper().Equals("J") ? 2 : 1);//1=CPF, 2=CNPJ, 3=ESTRANGEIRO
                        xml.Append("</tpDocumento>");
                        #endregion
                        xml.Append("</documento>");
                        #endregion

                        #region nmTomador
                        xml.Append("<nmTomador>");
                        xml.Append(p.Nm_clifor.Trim().Length > 80 ? p.Nm_clifor.Trim().RemoverCaracteres().SubstCaracteresEsp().Substring(0, 80) : p.Nm_clifor.Trim().RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</nmTomador>");
                        #endregion

                        #region dsEmail
                        if (!string.IsNullOrEmpty(p.rClifor.Email))
                        {
                            xml.Append("<dsEmail>");
                            xml.Append(p.rClifor.Email.Trim().Length > 80 ? p.rClifor.Email.Trim().Substring(0, 80) : p.rClifor.Email.Trim());
                            xml.Append("</dsEmail>");
                        }
                        #endregion

                        #region nrInscricaoEstadual
                        if (!string.IsNullOrEmpty(p.rEndereco.Insc_estadual))
                        {
                            xml.Append("<nrInscricaoEstadual>");
                            xml.Append(System.Text.RegularExpressions.Regex.Replace(p.rEndereco.Insc_estadual.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                            xml.Append("</nrInscricaoEstadual>");
                        }
                        #endregion

                        #region dsEndereco
                        if (!string.IsNullOrEmpty(p.Ds_endereco))
                        {
                            xml.Append("<dsEndereco>");
                            xml.Append(p.rEndereco.Ds_endereco.Trim().Length > 40 ? p.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Substring(0, 40) : p.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</dsEndereco>");
                        }
                        #endregion

                        #region nrEndereco
                        if (!string.IsNullOrEmpty(p.rEndereco.Numero))
                        {
                            xml.Append("<nrEndereco>");
                            xml.Append(p.rEndereco.Numero.Trim().Length > 10 ? p.rEndereco.Numero.RemoverCaracteres().SubstCaracteresEsp().Substring(0, 10) : p.rEndereco.Numero.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</nrEndereco>");
                        }
                        #endregion

                        #region dsComplemento
                        if (!string.IsNullOrEmpty(p.rEndereco.Ds_complemento))
                        {
                            xml.Append("<dsComplemento>");
                            xml.Append(p.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</dsComplemento>");
                        }
                        #endregion

                        #region nmBairro
                        if (!string.IsNullOrEmpty(p.rEndereco.Bairro))
                        {
                            xml.Append("<nmBairro>");
                            xml.Append(p.rEndereco.Bairro.Trim().Length > 25 ? p.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Substring(0, 25) : p.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</nmBairro>");
                        }
                        #endregion

                        #region nrCidadeIbge
                        if (!string.IsNullOrEmpty(p.rEndereco.Cd_cidade))
                        {
                            xml.Append("<nrCidadeIbge>");
                            xml.Append(p.rEndereco.Cd_cidade.Trim());
                            xml.Append("</nrCidadeIbge>");
                        }
                        #endregion

                        #region nmUf
                        if (!string.IsNullOrEmpty(p.rEndereco.UF))
                        {
                            xml.Append("<nmUf>");
                            xml.Append(p.rEndereco.UF.Trim());
                            xml.Append("</nmUf>");
                        }
                        #endregion

                        #region nmPais
                        xml.Append("<nmPais>");
                        xml.Append(p.rEndereco.NM_Pais.Trim().Length > 40 ? p.rEndereco.NM_Pais.RemoverCaracteres().SubstCaracteresEsp().Substring(0, 40) : p.rEndereco.NM_Pais.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</nmPais>");
                        #endregion

                        #region nrCep
                        if (!string.IsNullOrEmpty(System.Text.RegularExpressions.Regex.Replace(p.rEndereco.Cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)))
                        {
                            xml.Append("<nrCep>");
                            xml.Append(System.Text.RegularExpressions.Regex.Replace(p.rEndereco.Cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                            xml.Append("</nrCep>");
                        }
                        #endregion

                        #region nrTelefone
                        if (!string.IsNullOrEmpty(System.Text.RegularExpressions.Regex.Replace(p.rEndereco.Fone.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Trim()))
                        {
                            xml.Append("<nrTelefone>");
                            xml.Append(System.Text.RegularExpressions.Regex.Replace(p.rEndereco.Fone.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                            xml.Append("</nrTelefone>");
                        }
                        #endregion
                        xml.Append("</tomador>");
                        #endregion

                        #region listaServicos
                        xml.Append("<listaServicos>");
                        p.ItensNota.ForEach(v =>
                        {
                            if (string.IsNullOrEmpty(v.Id_tpservico))
                                throw new Exception("Obrigatorio informar tipo de serviço no cadastro do serviço para poder emitir NFS-e");
                            #region servico
                            xml.Append("<servico>");
                            #region nrServicoItem
                            xml.Append("<nrServicoItem>");
                            xml.Append(v.Id_tpservico.Substring(0, v.Id_tpservico.IndexOfAny(new char[] { '.' })));
                            xml.Append("</nrServicoItem>");
                            #endregion

                            #region nrServicoSubItem
                            xml.Append("<nrServicoSubItem>");
                            xml.Append(v.Id_tpservico.Substring(v.Id_tpservico.IndexOfAny(new char[] { '.' }) + 1, v.Id_tpservico.Length - v.Id_tpservico.IndexOfAny(new char[] { '.' }) - 1));
                            xml.Append("</nrServicoSubItem>");
                            #endregion

                            #region vlServico
                            xml.Append("<vlServico>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_subtotal + v.Vl_outrasdesp + v.Vl_juro_fin - v.Vl_desconto)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vlServico>");
                            #endregion
                            if (v.Pc_aliquotaISS.Equals(decimal.Zero))
                                throw new Exception("Obrigatorio informar imposto ISSQN para emitir NFS-e.");
                            #region vlAliquota
                            xml.Append("<vlAliquota>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaISS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vlAliquota>");
                            #endregion
                            //Dedução
                            if (v.Pc_reducaobasecalcISS > decimal.Zero)
                            {
                                #region deducao
                                xml.Append("<deducao>");
                                #region vlDeducao
                                xml.Append("<vlDeducao>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", Math.Round(decimal.Multiply(v.Vl_basecalcISS, decimal.Divide(v.Pc_reducaobasecalcISS, 100)), 2, MidpointRounding.AwayFromZero))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlDeducao>");
                                #endregion
                                #region dsJustificativaDeducao
                                xml.Append("<dsJustificativaDeducao>");
                                xml.Append(v.Ds_deducao.RemoverCaracteres());
                                xml.Append("</dsJustificativaDeducao>");
                                #endregion
                                xml.Append("</deducao>");
                                #endregion
                                #region vlBaseCalculo
                                xml.Append("<vlBaseCalculo>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcISS - Math.Round(decimal.Multiply(v.Vl_basecalcISS, decimal.Divide(v.Pc_reducaobasecalcISS, 100)), 2, MidpointRounding.AwayFromZero))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlBaseCalculo>");
                                #endregion
                            }
                            else
                            {
                                #region vlBaseCalculo
                                xml.Append("<vlBaseCalculo>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcISS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlBaseCalculo>");
                                #endregion
                            }

                            #region vlIssServico
                            xml.Append("<vlIssServico>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_iss + v.Vl_issretido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vlIssServico>");
                            #endregion

                            #region dsDiscriminacaoServico
                            xml.Append("<dsDiscriminacaoServico>");
                            xml.Append((v.Ds_produto.RemoverCaracteres().SubstCaracteresEsp().Trim() + "\r\n" + p.Obsfiscal.Trim() + " " + p.Dadosadicionais.Trim() + " " + v.Observacao_item.Trim()).Length > 1024 ? 
                                (v.Ds_produto.RemoverCaracteres().SubstCaracteresEsp().Trim() + "\r\n" + p.Obsfiscal.Trim() + " " + p.Dadosadicionais.Trim() + " " + v.Observacao_item.Trim()).Substring(0, 1023) :
                                (v.Ds_produto.RemoverCaracteres().SubstCaracteresEsp().Trim() + "\r\n" + p.Obsfiscal.Trim() + " " + p.Dadosadicionais.Trim() + " " + v.Observacao_item.Trim()));
                            xml.Append("</dsDiscriminacaoServico>");
                            #endregion
                            xml.Append("</servico>");
                            #endregion
                        });
                        xml.Append("</listaServicos>");
                        #endregion

                        #region vlTotalRps
                        xml.Append("<vlTotalRps>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_subtotal + v.Vl_outrasdesp + v.Vl_juro_fin - v.Vl_desconto))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vlTotalRps>");
                        #endregion

                        #region vlLiquidoRps
                        xml.Append("<vlLiquidoRps>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalnota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vlLiquidoRps>");
                        #endregion

                        #region retencoes
                        if ((p.ItensNota.Sum(v=> v.Vl_retidoCofins) > 0) ||
                            (p.ItensNota.Sum(v=> v.Vl_retidoCSLL) > 0) ||
                            (p.ItensNota.Sum(v=> v.Vl_retidoINSS) > 0) ||
                            (p.ItensNota.Sum(v=> v.Vl_retidoIRRF) > 0) ||
                            (p.ItensNota.Sum(v=> v.Vl_retidoPIS) > 0) ||
                            (p.ItensNota.Sum(v=> v.Vl_issretido) > 0))
                        {
                            xml.Append("<retencoes>");
                            #region vlCofins
                            if (p.ItensNota.Sum(v=> v.Vl_retidoCofins) > 0)
                            {
                                xml.Append("<vlCofins>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_retidoCofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlCofins>");
                            }
                            #endregion

                            #region vlCsll
                            if (p.ItensNota.Sum(v=> v.Vl_retidoCSLL) > 0)
                            {
                                xml.Append("<vlCsll>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_retidoCSLL))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlCsll>");
                            }
                            #endregion

                            #region vlInss
                            if (p.ItensNota.Sum(v=> v.Vl_retidoINSS) > 0)
                            {
                                xml.Append("<vlInss>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_retidoINSS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlInss>");
                            }
                            #endregion

                            #region vlIrrf
                            if (p.ItensNota.Sum(v=> v.Vl_retidoIRRF) > 0)
                            {
                                xml.Append("<vlIrrf>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_retidoIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlIrrf>");
                            }
                            #endregion

                            #region vlPis
                            if (p.ItensNota.Sum(v=> v.Vl_retidoPIS) > 0)
                            {
                                xml.Append("<vlPis>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_retidoPIS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlPis>");
                            }
                            #endregion

                            #region vlIss
                            if (p.ItensNota.Sum(v=> v.Vl_issretido) > 0)
                            {
                                xml.Append("<vlIss>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Sum(v=> v.Vl_issretido))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlIss>");
                            }
                            #endregion

                            #region vlAliquotaCofins
                            if (p.ItensNota.Average(v=> v.Pc_retencaoCofins) > 0)
                            {
                                xml.Append("<vlAliquotaCofins>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Average(v=> v.Pc_retencaoCofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlAliquotaCofins>");
                            }
                            #endregion

                            #region vlAliquotaCsll
                            if (p.ItensNota.Average(v=> v.Pc_retencaoCSLL) > 0)
                            {
                                xml.Append("<vlAliquotaCsll>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Average(v=> v.Pc_retencaoCSLL))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlAliquotaCsll>");
                            }
                            #endregion

                            #region vlAliquotaInss
                            if (p.ItensNota.Average(v=> v.Pc_retencaoINSS) > 0)
                            {
                                xml.Append("<vlAliquotaInss>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Average(v=> v.Pc_retencaoINSS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlAliquotaInss>");
                            }
                            #endregion

                            #region vlAliquotaIrrf
                            if (p.ItensNota.Average(v=> v.Pc_retencaoIRRF) > 0)
                            {
                                xml.Append("<vlAliquotaIrrf>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Average(v=> v.Pc_retencaoIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlAliquotaIrrf>");
                            }
                            #endregion

                            #region vlAliquotaPis
                            if (p.ItensNota.Average(v=> v.Pc_retencaoPIS) > 0)
                            {
                                xml.Append("<vlAliquotaPis>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.ItensNota.Average(v=> v.Pc_retencaoPIS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vlAliquotaPis>");
                            }
                            #endregion
                            xml.Append("</retencoes>");
                        }
                        #endregion

                        if (p.ItensNota.Exists(v => v.Vl_imposto_Aprox > decimal.Zero))
                        {
                            #region dsImpostos
                            xml.Append("<dsImpostos>");
                            xml.Append("VL.Imposto Aprox: " + p.ItensNota.Sum(v => v.Vl_imposto_Aprox).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)) +
                                       ", PC.Imposto Aprox: " + p.ItensNota.Average(v => v.Pc_imposto_Aprox).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)));
                            xml.Append("</dsImpostos>");
                            #endregion
                        }
                        xml.Append("</rps>");
                        #endregion
                    });
                    xml.Append("</listaRps>");
                    #endregion
                    xml.Append("</lote>");
                    #endregion
                    xml.Append("</es:enviarLoteRpsEnvio>");
                    #endregion

                    //Assinar documento XML
                    string xmlassinado = 
                        new Utils.Assinatura.TAssinatura2(rCfgNfes.Nr_certificado_nfe,
                                                          xml.ToString()).AssinarNFSe();

                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgNfes.Path_nfe_schemas.SeparadorDiretorio() + "esRecepcionarLoteRpsEnvio_v01.xsd",
                                                            "NFES");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());

                    //Conectar Web Service
                    string retorno = ConectarWebServico(xmlassinado, rCfgNfes);
                    if (!string.IsNullOrEmpty(retorno))
                    {
                        XmlDocument documento = new XmlDocument();
                        documento.LoadXml(retorno);
                        //Buscar lote
                        CamadaDados.Faturamento.NFES.TList_LoteRPS lRps =
                            CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Buscar(id_loterps,
                                                                              rCfgNfes.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                        if (lRps.Count > 0)
                        {
                            if (documento["es:esEnviarLoteRpsResposta"].GetElementsByTagName("protocolo").Count > 0)
                            {
                                lRps[0].Nr_protocolo = documento["es:esEnviarLoteRpsResposta"]["protocolo"]["nrProtocolo"].InnerText.Trim();
                                lRps[0].lNfes = lNf;
                                //Gravar lote RPS
                                CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Gravar(lRps[0], null);
                            }
                            if (documento["es:esEnviarLoteRpsResposta"].GetElementsByTagName("mensagemRetorno").Count > 0)
                            {
                                foreach (XmlNode no in documento["es:esEnviarLoteRpsResposta"]["mensagemRetorno"].ChildNodes)
                                {
                                    lRps[0].lMsgRPS.Add(new CamadaDados.Faturamento.NFES.TRegistro_MsgRetornoRPS()
                                    {
                                        Cd_mensagem = no["erro"]["cdMensagem"].InnerText.Trim(),
                                        Ds_mensagem = no["erro"]["dsMensagem"].InnerText.Trim(),
                                        Tp_origem = "1"
                                    });
                                    CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Gravar(lRps[0], null);
                                }
                            }
                        }
                    }
                    return xml.ToString();
                }
                catch (Exception ex)
                {
                    //Excluir Lote Criado
                    CamadaNegocio.Faturamento.NFES.TCN_LoteRPS.Excluir(
                        new CamadaDados.Faturamento.NFES.TRegistro_LoteRPS()
                        {
                            Id_lotestr = id_loterps,
                            Cd_empresa = rCfgNfes.Cd_empresa
                        }, null);
                    throw new Exception(ex.Message.Trim());
                }
            }
            else
                return string.Empty;
        }
    }
}
