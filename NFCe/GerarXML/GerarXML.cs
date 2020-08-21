using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;
using CamadaDados.Faturamento.PDV;

namespace NFCe.GerarXML
{
    public class TGerarXML
    {
        public static string CalcularDigitoChave(string vChave)
        {
            return Estruturas.Mod11(Regex.Replace(vChave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
        }

        public static string MontarChaveAcessoNfe(TRegistro_NFCe val, bool CalcDig)
        {
            string chave = val.rEmpresa.rEndereco.Cd_uf.FormatStringEsquerda(2, '0') + //UF Emitente
                           Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Year.ToString().FormatStringEsquerda(2, '0') + //Ano Emissao
                           Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Month.ToString().FormatStringEsquerda(2, '0') + //Mes Emissao
                           val.rEmpresa.rClifor.Nr_cgc.SoNumero() + //CNPJ Emitente
                           val.Cd_modelo.FormatStringEsquerda(2, '0') + //Modelo NFe
                           val.Nr_serie.FormatStringEsquerda(3, '0') + //Serie NFe
                           val.NR_NFCestr.FormatStringEsquerda(9, '0') + //Numero Nota Fiscal
                           (val.Id_contingencia.HasValue ? "9" : "1") + //Tipo Emissao 1 - Normal 9 - OFFLine
                           val.Id_nfcestr.FormatStringEsquerda(8, '0'); //Numero Lancto Fiscal
            return CalcDig ? chave + CalcularDigitoChave(chave) : chave;
        }

        public static void GerarXML(List<TRegistro_NFCe> lCf)
        {
            //Buscar data atual
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            lCf.ForEach(p =>
                {
                    //Validar Data Emissão
                    if ((dt_atual.Subtract(p.Dt_emissao.Value).Minutes > 5) && !p.St_contingencia)
                    {
                        new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set dt_emissao = '" + dt_atual.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                                                 "where cd_empresa = '" + p.Cd_empresa.Trim() + "' and id_nfce = " + p.Id_nfcestr, null);
                        p.Dt_emissao = dt_atual;
                    }
                    StringBuilder xml = new StringBuilder();
                    #region NFe
                    xml.Append("<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
                    #region infNFe
                    xml.Append("<infNFe Id=\"NFe" + MontarChaveAcessoNfe(p, true) + "\" versao=\"" + p.rCfgNFCe.Cd_versaonfce.Trim() + "\">");
                    #region ide
                    xml.Append("<ide>");
                    #region cUF
                    xml.Append("<cUF>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_uf.Trim());
                    xml.Append("</cUF>");
                    #endregion

                    #region cNF
                    xml.Append("<cNF>");
                    xml.Append(p.Id_nfcestr.FormatStringEsquerda(8, '0'));
                    xml.Append("</cNF>");
                    #endregion

                    #region natOp
                    xml.Append("<natOp>");
                    xml.Append(p.Ds_movimentacao.Trim().RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</natOp>");
                    #endregion

                    #region indPag
                    if (p.rCfgNFCe.Cd_versaonfce.Trim().Equals("3.10"))
                    {
                        xml.Append("<indPag>");
                        xml.Append("0");
                        //0-Pagamento a Vista
                        //1-Pagamento a Prazo
                        //2-Outros
                        xml.Append("</indPag>");
                    }
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

                    #region nNF
                    xml.Append("<nNF>");
                    xml.Append(p.NR_NFCestr.Trim());
                    
                    xml.Append("</nNF>");
                    #endregion

                    #region dhEmi
                    xml.Append("<dhEmi>");
                    xml.Append(p.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de emissão do cupom fiscal
                    xml.Append("</dhEmi>");
                    #endregion

                    #region tpNF
                    xml.Append("<tpNF>");
                    xml.Append("1");//Saida
                    xml.Append("</tpNF>");
                    #endregion

                    #region idDest
                    xml.Append("<idDest>");
                    xml.Append("1");//Dentro do Estado NFC-e não permite emissão interestadual
                    xml.Append("</idDest>");
                    #endregion

                    #region cMunFG
                    xml.Append("<cMunFG>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_cidade.Trim().PadLeft(7, '0')); //Codigo do municipio gerador do icms
                    xml.Append("</cMunFG>");
                    #endregion

                    #region tpImp
                    xml.Append("<tpImp>");
                    xml.Append("4"); //Formato de impressão do DANFE 
                    xml.Append("</tpImp>");
                    #endregion

                    #region tpEmis
                    xml.Append("<tpEmis>");
                    xml.Append(p.Id_contingencia.HasValue ? "9" : "1"); //1-Emissao Normal 9 - Contingencia OFFLine
                    xml.Append("</tpEmis>");
                    #endregion

                    #region cDV
                    xml.Append("<cDV>");
                    xml.Append(CalcularDigitoChave(MontarChaveAcessoNfe(p, false)).Trim()); //Digito verificador da chave de acesso da NFC-e
                    xml.Append("</cDV>");
                    #endregion

                    #region tpAmb
                    xml.Append("<tpAmb>");
                    xml.Append(p.rCfgNFCe.Tp_ambiente_nfce);
                    xml.Append("</tpAmb>");
                    #endregion

                    #region finNFe
                    xml.Append("<finNFe>");
                    xml.Append("1");//Normal
                    xml.Append("</finNFe>");
                    #endregion

                    #region indFinal
                    xml.Append("<indFinal>");
                    xml.Append("1");//0-Nao ; 1-Consumidor final
                    xml.Append("</indFinal>");
                    #endregion

                    #region indPres
                    xml.Append("<indPres>");
                    xml.Append("1");//Operacao Presencial
                    xml.Append("</indPres>");
                    #endregion

                    #region procEmi
                    xml.Append("<procEmi>");
                    xml.Append("0");//Emissao de NFCe com aplicação do contribuinte
                    xml.Append("</procEmi>");
                    #endregion

                    #region verProc
                    xml.Append("<verProc>");
                    xml.Append(p.rCfgNFCe.Cd_versaonfce.Trim());
                    xml.Append("</verProc>");
                    #endregion

                    if (p.Id_contingencia.HasValue)
                    {
                        #region dhCont
                        xml.Append("<dhCont>");
                        xml.Append(p.dt_entcontingencia.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                        xml.Append("</dhCont>");
                        #endregion

                        #region xJust
                        xml.Append("<xJust>");
                        xml.Append(p.Justificativacontingencia.RemoverCaracteres().SubstCaracteresEsp());
                        xml.Append("</xJust>");
                        #endregion
                    }
                    xml.Append("</ide>");
                    #endregion

                    #region emit
                    xml.Append("<emit>");
                    #region CNPJ
                    xml.Append("<CNPJ>");
                    xml.Append(p.rEmpresa.rClifor.Nr_cgc.SoNumero());
                    xml.Append("</CNPJ>");
                    #endregion

                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(p.rEmpresa.Nm_empresa.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xNome>");
                    #endregion

                    #region xFant
                    xml.Append("<xFant>");
                    xml.Append(p.rEmpresa.rClifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xFant>");
                    #endregion
                    
                    #region enderEmit
                    xml.Append("<enderEmit>");
                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(p.rEmpresa.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xLgr>");
                    #endregion

                    #region nro
                    xml.Append("<nro>");
                    xml.Append(p.rEmpresa.rEndereco.Numero.Trim().RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</nro>");
                    #endregion

                    #region xCpl
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(p.rEmpresa.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xCpl>");
                    }
                    #endregion

                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(p.rEmpresa.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xBairro>");
                    #endregion

                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(p.rEmpresa.rEndereco.Cd_cidade.Trim());
                    xml.Append("</cMun>");
                    #endregion

                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(p.rEmpresa.rEndereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xMun>");
                    #endregion

                    #region UF
                    xml.Append("<UF>");
                    xml.Append(p.rEmpresa.rEndereco.UF.Trim());
                    xml.Append("</UF>");
                    #endregion

                    #region CEP
                    xml.Append("<CEP>");
                    xml.Append(p.rEmpresa.rEndereco.Cep.SoNumero());
                    xml.Append("</CEP>");
                    #endregion

                    #region cPais
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.CD_Pais))
                    {
                        xml.Append("<cPais>");
                        xml.Append(p.rEmpresa.rEndereco.CD_Pais.Trim());
                        xml.Append("</cPais>");
                    }
                    #endregion

                    #region xPais
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.NM_Pais))
                    {
                        xml.Append("<xPais>");
                        xml.Append(p.rEmpresa.rEndereco.NM_Pais.Trim());
                        xml.Append("</xPais>");
                    }
                    #endregion

                    #region fone
                    if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(p.rEmpresa.rEndereco.Fone.SoNumero());
                        xml.Append("</fone>");
                    }
                    #endregion
                    xml.Append("</enderEmit>");
                    #endregion

                    #region IE
                    xml.Append("<IE>");
                    xml.Append(p.rEmpresa.rEndereco.Insc_estadual.SoNumero());
                    xml.Append("</IE>");
                    #endregion

                    #region CRT
                    xml.Append("<CRT>");
                    xml.Append(p.rEmpresa.Tp_regimetributario.Trim());
                    xml.Append("</CRT>");
                    #endregion
                    xml.Append("</emit>");
                    #endregion

                    #region dest
                    if (p.rCliente == null ? false : !string.IsNullOrEmpty((p.rCliente.Nr_cgc + p.rCliente.Nr_cpf).SoNumero()))
                    {
                        xml.Append("<dest>");
                        #region CNPJ
                        if (p.rCliente.Tp_pessoa.Trim().ToUpper().Equals("J"))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(p.rCliente.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion

                        #region CPF
                        if (p.rCliente.Tp_pessoa.Trim().ToUpper().Equals("F"))
                        {
                            xml.Append("<CPF>");
                            xml.Append(p.rCliente.Nr_cpf.SoNumero());
                            xml.Append("</CPF>");
                        }
                        #endregion

                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(p.rCliente.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xNome>");
                        #endregion

                        #region indIEDest
                        xml.Append("<indIEDest>");
                        xml.Append("9");//NFC-e obrigatoriamente deve informar valor 9(Não contribuinte) e não informar tag insc. estadual
                        xml.Append("</indIEDest>");
                        #endregion

                        #region email
                        if (!string.IsNullOrEmpty(p.rCliente.Email))
                        {
                            xml.Append("<email>");
                            xml.Append(p.rCliente.Email.Trim());
                            xml.Append("</email>");
                        }
                        #endregion
                        xml.Append("</dest>");
                    }
                    else if (!string.IsNullOrEmpty(p.Nr_cgc_cpf.SoNumero()) && 
                             (p.Nr_cgc_cpf.SoNumero().Length.Equals(14) ||
                             p.Nr_cgc_cpf.SoNumero().Length.Equals(11)))
                    {
                        xml.Append("<dest>");
                        #region CNPJ
                        if (p.Nr_cgc_cpf.SoNumero().Length.Equals(14))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(p.Nr_cgc_cpf.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion

                        #region CPF
                        if (p.Nr_cgc_cpf.SoNumero().Length.Equals(11))
                        {
                            xml.Append("<CPF>");
                            xml.Append(p.Nr_cgc_cpf.SoNumero());
                            xml.Append("</CPF>");
                        }
                        #endregion

                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(!string.IsNullOrEmpty(p.Nm_clifor) ? p.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim() : "CONSUMIDOR FINAL");
                        xml.Append("</xNome>");
                        #endregion


                        #region indIEDest
                        xml.Append("<indIEDest>");
                        xml.Append("9");//NFC-e obrigatoriamente deve informar valor 9(Não contribuinte) e não informar tag insc. estadual
                        xml.Append("</indIEDest>");
                        #endregion
                        xml.Append("</dest>");
                    }
                    #endregion

                    #region Autorização para obter XML
                    if (!string.IsNullOrWhiteSpace(p.rCfgNFCe.Cnpj_contador.SoNumero()))
                    {

                        #region autXML 
                        xml.Append("<autXML>\n");
                        #region CNPJ 
                        xml.Append("<CNPJ>");
                        xml.Append(p.rCfgNFCe.Cnpj_contador.SoNumero());
                        xml.Append("</CNPJ>\n");
                        #endregion
                        xml.Append("</autXML>\n");
                        #endregion
                    }
                    #endregion

                    #region det
                    int qt_item = 1;
                    p.lItem.ForEach(v =>
                        {
                            xml.Append("<det nItem=\"" + qt_item.ToString() + "\">");
                            #region prod
                            xml.Append("<prod>");
                            #region cProd
                            xml.Append("<cProd>");
                            xml.Append(v.Cd_produto.Trim());
                            xml.Append("</cProd>");
                            #endregion

                            #region cEAN
                            xml.Append("<cEAN>");
                            xml.Append("SEM GTIN");
                            //xml.Append(v.Cod_barra.Trim().Length.Equals(8) ||
                            //    v.Cod_barra.Trim().Length.Equals(12) ||
                            //    v.Cod_barra.Trim().Length.Equals(13) ||
                            //    v.Cod_barra.Trim().Length.Equals(14) ? v.Cod_barra : "SEM GTIN");
                            xml.Append("</cEAN>");
                            #endregion

                            #region xProd
                            xml.Append("<xProd>");
                            if (qt_item.Equals(1) && p.rCfgNFCe.Tp_ambiente_nfce.Trim().Equals("2"))
                                xml.Append("NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
                            else xml.Append(v.Ds_produto.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xProd>");
                            #endregion

                            #region NCM
                            xml.Append("<NCM>");
                            xml.Append(v.Ncm.Trim());
                            xml.Append("</NCM>");
                            #endregion

                            #region CEST
                            if (!string.IsNullOrEmpty(v.Cest))
                            {
                                xml.Append("<CEST>");
                                xml.Append(v.Cest.Trim());
                                xml.Append("</CEST>");
                            }
                            #endregion

                            #region CFOP
                            xml.Append("<CFOP>");
                            xml.Append(v.Cd_cfop.FormatStringEsquerda(4, '0'));
                            xml.Append("</CFOP>");
                            #endregion

                            #region uCom
                            xml.Append("<uCom>");
                            xml.Append(v.Sigla_unidade.Trim());
                            xml.Append("</uCom>");
                            #endregion

                            #region qCom
                            xml.Append("<qCom>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</qCom>");
                            #endregion

                            #region vUnCom
                            xml.Append("<vUnCom>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N10}", v.Vl_unitario)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vUnCom>");
                            #endregion

                            #region vProd
                            xml.Append("<vProd>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_subtotal)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vProd>");
                            #endregion

                            #region cEANTrib
                            xml.Append("<cEANTrib>");
                            xml.Append("SEM GTIN");
                            //xml.Append(v.Cod_barra.Trim().Length.Equals(8) ||
                            //    v.Cod_barra.Trim().Length.Equals(12) ||
                            //    v.Cod_barra.Trim().Length.Equals(13) ||
                            //    v.Cod_barra.Trim().Length.Equals(14) ? v.Cod_barra : "SEM GTIN");
                            xml.Append("</cEANTrib>");
                            #endregion

                            #region uTrib
                            xml.Append("<uTrib>");
                            xml.Append(v.Sigla_unidade.Trim());
                            xml.Append("</uTrib>");
                            #endregion

                            #region qTrib
                            xml.Append("<qTrib>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</qTrib>");
                            #endregion

                            #region vUnTrib
                            xml.Append("<vUnTrib>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N10}", v.Vl_unitario)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vUnTrib>");
                            #endregion

                            #region vFrete
                            if (v.Vl_frete > decimal.Zero)
                            {
                                xml.Append("<vFrete>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_frete)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vFrete>");
                            }

                            #endregion

                            #region vDesc
                            if (v.Vl_desconto > decimal.Zero)
                            {
                                xml.Append("<vDesc>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_desconto)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vDesc>");
                            }
                            #endregion

                            #region vOutro
                            if ((v.Vl_juro_fin + v.Vl_acrescimo) > decimal.Zero)
                            {
                                xml.Append("<vOutro>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_acrescimo + v.Vl_juro_fin)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vOutro>");
                            }
                            #endregion

                            #region indTot
                            xml.Append("<indTot>");
                            xml.Append("1");//Valor do item compoe o valor total da NFCe
                            xml.Append("</indTot>");
                            #endregion
                            
                            bool st_comb = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(v.Cd_produto);
                            if (st_comb || 
                                new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoLubrificante(v.Cd_produto))
                            {
                                #region Combustiveis e Lubrificantes
                                xml.Append("<comb>");

                                #region cProdANP
                                xml.Append("<cProdANP>");
                                xml.Append(v.Cd_anp.Trim());
                                xml.Append("</cProdANP>");
                                #endregion
                                #region descANP
                                if (p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                                {
                                    xml.Append("<descANP>");
                                    xml.Append(v.Ds_anp.Trim());
                                    xml.Append("</descANP>");
                                }
                                #endregion
                                #region UFCons
                                xml.Append("<UFCons>");
                                xml.Append(p.rEmpresa.rEndereco.UF.Trim());
                                xml.Append("</UFCons>");
                                #endregion

                                if (st_comb)
                                {
                                    //Buscar Abastecida Cupom
                                    CamadaDados.PostoCombustivel.TList_VendaCombustivel lVComp =
                                        new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_vendarapida = a.id_cupom " +
                                                        "and x.id_lanctovenda = a.id_lancto " +
                                                        "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                        "and x.id_cupom = " + v.ID_NFCe.Value.ToString() + " " +
                                                        "and x.id_lancto = " + v.Id_lancto.Value.ToString() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
                                    if (lVComp.Count.Equals(0))
                                        throw new Exception("Item combustivel não teve origem abastecimento [nItem:" + v.Id_lancto.Value.ToString() + "].");
                                    #region encerrante
                                    xml.Append("<encerrante>");

                                    #region nBico
                                    xml.Append("<nBico>");
                                    xml.Append(lVComp[0].Ds_label.Trim());
                                    xml.Append("</nBico>");
                                    #endregion

                                    #region nBomba
                                    xml.Append("<nBomba>");
                                    xml.Append(lVComp[0].Id_bombastr);
                                    xml.Append("</nBomba>");
                                    #endregion

                                    #region nTanque
                                    xml.Append("<nTanque>");
                                    xml.Append(lVComp[0].Id_tanquestr);
                                    xml.Append("</nTanque>");
                                    #endregion

                                    #region vEncIni
                                    xml.Append("<vEncIni>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico - lVComp[0].Volumeabastecido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vEncIni>");
                                    #endregion

                                    #region vEncFin
                                    xml.Append("<vEncFin>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vEncFin>");
                                    #endregion

                                    xml.Append("</encerrante>");
                                    #endregion
                                }
                                
                                xml.Append("</comb>\n");
                                #endregion
                            }
                            
                            xml.Append("</prod>");
                            #endregion

                            #region imposto
                            xml.Append("<imposto>");
                            #region vTotTrib
                            if (v.Vl_imposto_Aprox > decimal.Zero)
                            {
                                xml.Append("<vTotTrib>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_imposto_Aprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vTotTrib>");
                            }
                            #endregion

                            #region ICMS
                            if(!v.Cd_icms.HasValue)
                                throw new Exception("Não é permitido gerar NFC-e com item sem destacar ICMS.");
                            if (v.Cd_st_icms.Trim().Equals("50") ||
                                v.Cd_st_icms.Trim().Equals("51"))
                                throw new Exception("NFC-e não permite ICMS com CST igual a 50 ou 51.");
                            xml.Append("<ICMS>");
                            #region ICMS00
                            if (v.Cd_st_icms.Trim().Equals("00"))
                            {
                                xml.Append("<ICMS00>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region modBC
                                xml.Append("<modBC>");
                                xml.Append(v.Tp_modbasecalc.Trim());
                                xml.Append("</modBC>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pICMS
                                xml.Append("<pICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMS>");
                                #endregion

                                #region vICMS
                                xml.Append("<vICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMS>");
                                #endregion
                                xml.Append("</ICMS00>");
                            }
                            #endregion

                            #region ICMS10
                            if (v.Cd_st_icms.Trim().Equals("10"))
                            {
                                xml.Append("<ICMS10>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region modBC
                                xml.Append("<modBC>");
                                xml.Append(v.Tp_modbasecalc.Trim());
                                xml.Append("</modBC>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pICMS
                                xml.Append("<pICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMS>");
                                #endregion

                                #region vICMS
                                xml.Append("<vICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMS>");
                                #endregion

                                #region modBCST
                                xml.Append("<modBCST>");
                                xml.Append(v.Tp_modbasecalcST.Trim());
                                xml.Append("</modBCST>");
                                #endregion
                                /*
                                #region pMVAST
                                if (rICMS.Pc_iva_st > decimal.Zero)
                                {
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>");
                                }
                                #endregion

                                #region pRedBCST
                                if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                                {
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>");
                                }
                                #endregion
                                */
                                #region vBCST
                                xml.Append("<vBCST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBCST>");
                                #endregion

                                #region pICMSST
                                xml.Append("<pICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMSST>");
                                #endregion

                                #region vICMSST
                                xml.Append("<vICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMSST>");
                                #endregion
                                xml.Append("</ICMS10>");
                            }
                            #endregion
                            /*
                            #region ICMS20
                            if (v.Cd_st_icms.Trim().Equals("20"))
                            {
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region modBC
                                xml.Append("<modBC>");
                                xml.Append(v.Tp_modbasecalc.Trim());
                                xml.Append("</modBC>");
                                #endregion

                                #region pRedBC
                                xml.Append("<pRedBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pRedBC>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pICMS
                                xml.Append("<pICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMS>");
                                #endregion

                                #region vICMS
                                xml.Append("<vICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMS>");
                                #endregion
                            }
                            #endregion
                            
                            #region ICMS30
                            if (rICMS.Cd_st.Trim().Equals("30"))
                            {
                                xml.Append("<ICMS30>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(rICMS.Cd_st.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region modBCST
                                xml.Append("<modBCST>");
                                xml.Append(rICMS.Tp_modbasecalcST.Trim());
                                xml.Append("</modBCST>");
                                #endregion

                                #region pMVAST
                                if (rICMS.Pc_iva_st > decimal.Zero)
                                {
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>");
                                }
                                #endregion

                                #region pRedBCST
                                if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                                {
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>");
                                }
                                #endregion

                                #region vBCST
                                xml.Append("<vBCST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBCST>");
                                #endregion

                                #region pICMSST
                                xml.Append("<pICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMSST>");
                                #endregion

                                #region vICMSST
                                xml.Append("<vICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMSST>");
                                #endregion
                                xml.Append("</ICMS30>");
                            }
                            #endregion
                            */
                            #region ICMS40
                            if (v.Cd_st_icms.Trim().Equals("40") ||
                                v.Cd_st_icms.Trim().Equals("41"))
                            {
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion
                            }
                            #endregion

                            #region ICMS60
                            if (v.Cd_st_icms.Trim().Equals("60"))
                            {
                                xml.Append("<ICMS60>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion
                                xml.Append("</ICMS60>");
                            }
                            #endregion
                            /*
                            #region ICMS70
                            if (rICMS.Cd_st.Trim().Equals("70"))
                            {
                                xml.Append("<ICMS70>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(rICMS.Cd_st.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region modBC
                                xml.Append("<modBC>");
                                xml.Append(rICMS.Tp_modbasecalc.Trim());
                                xml.Append("</modBC>");
                                #endregion

                                #region pRedBC
                                xml.Append("<pRedBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pRedBC>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pICMS
                                xml.Append("<pICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMS>");
                                #endregion

                                #region vICMS
                                xml.Append("<vICMS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMS>");
                                #endregion

                                #region modBCST
                                xml.Append("<modBCST>");
                                xml.Append(rICMS.Tp_modbasecalcST.Trim());
                                xml.Append("</modBCST>");
                                #endregion

                                #region pMVAST
                                if (rICMS.Pc_iva_st > decimal.Zero)
                                {
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>");
                                }
                                #endregion

                                #region pRedBCST
                                if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                                {
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST");
                                }
                                #endregion

                                #region vBCST
                                xml.Append("<vBCST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBCST>");
                                #endregion

                                #region pICMSST
                                xml.Append("<pICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMSST>");
                                #endregion

                                #region vICMSST
                                xml.Append("<vICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMSST>");
                                #endregion
                                xml.Append("</ICMS70>");
                            }
                            #endregion
                            */
                            #region ICMS90
                            if (v.Cd_st_icms.Trim().Equals("90"))
                            {
                                xml.Append("<ICMS90>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CST>");
                                #endregion
                                xml.Append("</ICMS90>");
                            }
                            #endregion

                            #region ICMSSN101
                            if (v.Cd_st_icms.Trim().Equals("101"))
                            {
                                xml.Append("<ICMSSN101>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CSOSN>");
                                #endregion

                                #region pCredSN
                                xml.Append("<pCredSN>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pCredSN>");
                                #endregion

                                #region vCredICMSSN
                                xml.Append("<vCredICMSSN>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCredICMSSN>");
                                #endregion
                                xml.Append("</ICMSSN101>");
                            }
                            #endregion

                            #region ICMSSN102
                            if (v.Cd_st_icms.Trim().Equals("102") ||
                                v.Cd_st_icms.Trim().Equals("103") ||
                                v.Cd_st_icms.Trim().Equals("300") ||
                                v.Cd_st_icms.Trim().Equals("400"))
                            {
                                xml.Append("<ICMSSN102>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CSOSN>");
                                #endregion
                                xml.Append("</ICMSSN102>");
                            }
                            #endregion
                            /*
                            #region ICMSSN201
                            if (rICMS.Cd_st.Trim().Equals("201"))
                            {
                                xml.Append("<ICMSSN201>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(rICMS.Cd_st.Trim());
                                xml.Append("</CSOSN>");
                                #endregion

                                #region modBCST
                                xml.Append("<modBCST>");
                                xml.Append(rICMS.Tp_modbasecalcST.Trim());
                                xml.Append("</modBCST>");
                                #endregion

                                #region pMVAST
                                if (rICMS.Pc_iva_st > decimal.Zero)
                                {
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>");
                                }
                                #endregion

                                #region pRedBCST
                                if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                                {
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>");
                                }
                                #endregion

                                #region vBCST
                                xml.Append("<vBCST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBCST>");
                                #endregion

                                #region pICMSST
                                xml.Append("<pICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMSST>");
                                #endregion

                                #region vICMSST
                                xml.Append("<vICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMSST>");
                                #endregion

                                #region pCredSN
                                xml.Append("<pCredSN>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pCredSN>");
                                #endregion

                                #region vCredICMSSN
                                xml.Append("<vCredICMSSN>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCredICMSSN>");
                                #endregion
                                xml.Append("</ICMSSN201>");
                            }
                            #endregion

                            #region ICMSSN202
                            if (rICMS.Cd_st.Trim().Equals("202") ||
                                rICMS.Cd_st.Trim().Equals("203"))
                            {
                                xml.Append("<ICMSSN202>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(rICMS.Cd_st.Trim());
                                xml.Append("</CSOSN>");
                                #endregion

                                #region modBCST
                                xml.Append("<modBCST>");
                                xml.Append(rICMS.Tp_modbasecalcST.Trim());
                                xml.Append("</modBCST>");
                                #endregion

                                #region pMVAST
                                if (rICMS.Pc_iva_st > decimal.Zero)
                                {
                                    xml.Append("<pMVAST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pMVAST>");
                                }
                                #endregion

                                #region pRedBCST
                                if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                                {
                                    xml.Append("<pRedBCST>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pRedBCST>");
                                }
                                #endregion

                                #region vBCST
                                xml.Append("<vBCST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBCST>");
                                #endregion

                                #region pICMSST
                                xml.Append("<pICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pICMSST>");
                                #endregion

                                #region vICMSST
                                xml.Append("<vICMSST>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vICMSST>");
                                #endregion
                                xml.Append("</ICMSSN202>");
                            }
                            #endregion
                            */
                            #region ICMSSN500
                            if (v.Cd_st_icms.Trim().Equals("500"))
                            {
                                xml.Append("<ICMSSN500>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CSOSN>");
                                #endregion
                                xml.Append("</ICMSSN500>");
                            }
                            #endregion

                            #region ICMSSN900
                            if (v.Cd_st_icms.Trim().Equals("900"))
                            {
                                xml.Append("<ICMSSN900>");
                                #region orig
                                xml.Append("<orig>");
                                xml.Append("0");//Nacional
                                xml.Append("</orig>");
                                #endregion

                                #region CSOSN
                                xml.Append("<CSOSN>");
                                xml.Append(v.Cd_st_icms.Trim());
                                xml.Append("</CSOSN>");
                                #endregion
                                xml.Append("</ICMSSN900>");
                            }
                            #endregion
                            xml.Append("</ICMS>");
                            #endregion

                            #region PIS
                            if (!v.Cd_pis.HasValue)
                                throw new Exception("Não é permitido gerar NFC-e com item sem destacar PIS.");
                            xml.Append("<PIS>");
                            #region PISAliq
                            if (v.Cd_st_pis.Trim().Equals("01") ||
                                v.Cd_st_pis.Trim().Equals("02"))
                            {
                                xml.Append("<PISAliq>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_pis.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pPIS
                                xml.Append("<pPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pPIS>");
                                #endregion

                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPIS>");
                                #endregion
                                xml.Append("</PISAliq>");
                            }
                            #endregion
                            /*
                            #region PISQtde
                            if (v.Cd_st_pis.Trim().Equals("03"))
                            {
                                xml.Append("<PISQtde>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_pis.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region qBCProd
                                xml.Append("<qBCProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</qBCProd>");
                                #endregion

                                #region vAliqProd
                                xml.Append("<vAliqProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vAliqProd>");
                                #endregion

                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPIS>");
                                #endregion
                                xml.Append("</PISQtde>");
                            }
                            #endregion
                            */
                            #region PISNT
                            if (v.Cd_st_pis.Trim().Equals("04") ||
                                v.Cd_st_pis.Trim().Equals("05") ||
                                v.Cd_st_pis.Trim().Equals("06") ||
                                v.Cd_st_pis.Trim().Equals("07") ||
                                v.Cd_st_pis.Trim().Equals("08") ||
                                v.Cd_st_pis.Trim().Equals("09"))
                            {
                                xml.Append("<PISNT>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_pis.Trim());
                                xml.Append("</CST>");
                                #endregion
                                xml.Append("</PISNT>");
                            }
                            #endregion

                            #region PISOutr
                            if (v.Cd_st_pis.Trim().Equals("49") ||
                                v.Cd_st_pis.Trim().Equals("50") ||
                                v.Cd_st_pis.Trim().Equals("51") ||
                                v.Cd_st_pis.Trim().Equals("52") ||
                                v.Cd_st_pis.Trim().Equals("53") ||
                                v.Cd_st_pis.Trim().Equals("54") ||
                                v.Cd_st_pis.Trim().Equals("55") ||
                                v.Cd_st_pis.Trim().Equals("56") ||
                                v.Cd_st_pis.Trim().Equals("60") ||
                                v.Cd_st_pis.Trim().Equals("61") ||
                                v.Cd_st_pis.Trim().Equals("62") ||
                                v.Cd_st_pis.Trim().Equals("63") ||
                                v.Cd_st_pis.Trim().Equals("64") ||
                                v.Cd_st_pis.Trim().Equals("65") ||
                                v.Cd_st_pis.Trim().Equals("66") ||
                                v.Cd_st_pis.Trim().Equals("67") ||
                                v.Cd_st_pis.Trim().Equals("70") ||
                                v.Cd_st_pis.Trim().Equals("71") ||
                                v.Cd_st_pis.Trim().Equals("72") ||
                                v.Cd_st_pis.Trim().Equals("73") ||
                                v.Cd_st_pis.Trim().Equals("74") ||
                                v.Cd_st_pis.Trim().Equals("75") ||
                                v.Cd_st_pis.Trim().Equals("98") ||
                                v.Cd_st_pis.Trim().Equals("99"))
                            {
                                xml.Append("<PISOutr>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_pis.Trim());
                                xml.Append("</CST>");
                                #endregion

                                if (v.Pc_aliquotaPIS > decimal.Zero)
                                {
                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBC>");
                                    #endregion

                                    #region pPIS
                                    xml.Append("<pPIS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pPIS>");
                                    #endregion
                                }
                                //else
                                //{
                                //    #region qBCProd
                                //    xml.Append("<qBCProd>");
                                //    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                //    xml.Append("</qBCProd>");
                                //    #endregion

                                //    #region vAliqProd
                                //    xml.Append("<vAliqProd>");
                                //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                //    xml.Append("</vAliqProd>");
                                //    #endregion
                                //}
                                #region vPIS
                                xml.Append("<vPIS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPIS>");
                                #endregion
                                xml.Append("</PISOutr>");
                            }
                            #endregion
                            xml.Append("</PIS>");
                            #endregion

                            #region COFINS
                            if (!v.Cd_cofins.HasValue)
                                throw new Exception("Não é permitido gerar NFC-e com item sem destacar COFINS.");
                            xml.Append("<COFINS>");
                            #region COFINSAliq
                            if (v.Cd_st_cofins.Trim().Equals("01") ||
                                v.Cd_st_cofins.Trim().Equals("02"))
                            {
                                xml.Append("<COFINSAliq>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_cofins.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region vBC
                                xml.Append("<vBC>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vBC>");
                                #endregion

                                #region pCOFINS
                                xml.Append("<pCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</pCOFINS>");
                                #endregion

                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCOFINS>");
                                #endregion
                                xml.Append("</COFINSAliq>");
                            }
                            #endregion
                            /*
                            #region COFINSQtde
                            if (rCOFINS.Cd_st.Trim().Equals("03"))
                            {
                                xml.Append("<COFINSQtde>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(rCOFINS.Cd_st.Trim());
                                xml.Append("</CST>");
                                #endregion

                                #region qBCProd
                                xml.Append("<qBCProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</qBCProd>");
                                #endregion

                                #region vAliqProd
                                xml.Append("<vAliqProd>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vAliqProd>");
                                #endregion

                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCOFINS>");
                                #endregion
                                xml.Append("</COFINSQtde>");
                            }
                            #endregion
                            */
                            #region COFINSNT
                            if (v.Cd_st_cofins.Trim().Equals("04") ||
                                v.Cd_st_cofins.Trim().Equals("05") ||
                                v.Cd_st_cofins.Trim().Equals("06") ||
                                v.Cd_st_cofins.Trim().Equals("07") ||
                                v.Cd_st_cofins.Trim().Equals("08") ||
                                v.Cd_st_cofins.Trim().Equals("09"))
                            {
                                xml.Append("<COFINSNT>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_cofins.Trim());
                                xml.Append("</CST>");
                                #endregion
                                xml.Append("</COFINSNT>");
                            }
                            #endregion

                            #region COFINSOutr
                            if (v.Cd_st_cofins.Trim().Equals("49") ||
                                v.Cd_st_cofins.Trim().Equals("50") ||
                                v.Cd_st_cofins.Trim().Equals("51") ||
                                v.Cd_st_cofins.Trim().Equals("52") ||
                                v.Cd_st_cofins.Trim().Equals("53") ||
                                v.Cd_st_cofins.Trim().Equals("54") ||
                                v.Cd_st_cofins.Trim().Equals("55") ||
                                v.Cd_st_cofins.Trim().Equals("56") ||
                                v.Cd_st_cofins.Trim().Equals("60") ||
                                v.Cd_st_cofins.Trim().Equals("61") ||
                                v.Cd_st_cofins.Trim().Equals("62") ||
                                v.Cd_st_cofins.Trim().Equals("63") ||
                                v.Cd_st_cofins.Trim().Equals("64") ||
                                v.Cd_st_cofins.Trim().Equals("65") ||
                                v.Cd_st_cofins.Trim().Equals("66") ||
                                v.Cd_st_cofins.Trim().Equals("67") ||
                                v.Cd_st_cofins.Trim().Equals("70") ||
                                v.Cd_st_cofins.Trim().Equals("71") ||
                                v.Cd_st_cofins.Trim().Equals("72") ||
                                v.Cd_st_cofins.Trim().Equals("73") ||
                                v.Cd_st_cofins.Trim().Equals("74") ||
                                v.Cd_st_cofins.Trim().Equals("75") ||
                                v.Cd_st_cofins.Trim().Equals("98") ||
                                v.Cd_st_cofins.Trim().Equals("99"))
                            {
                                xml.Append("<COFINSOutr>");
                                #region CST
                                xml.Append("<CST>");
                                xml.Append(v.Cd_st_cofins.Trim());
                                xml.Append("</CST>");
                                #endregion

                                if (v.Pc_aliquotaCofins > decimal.Zero)
                                {
                                    #region vBC
                                    xml.Append("<vBC>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</vBC>");
                                    #endregion

                                    #region pCOFINS
                                    xml.Append("<pCOFINS>");
                                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                    xml.Append("</pCOFINS>");
                                    #endregion
                                }
                                //else
                                //{
                                //    #region qBCProd
                                //    xml.Append("<qBCProd>");
                                //    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                //    xml.Append("</qBCProd>");
                                //    #endregion

                                //    #region vAliqProd
                                //    xml.Append("<vAliqProd>");
                                //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                //    xml.Append("</vAliqProd>");
                                //    #endregion
                                //}
                                #region vCOFINS
                                xml.Append("<vCOFINS>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vCOFINS>");
                                #endregion
                                xml.Append("</COFINSOutr>");
                            }
                            #endregion
                            xml.Append("</COFINS>");
                            #endregion
                            xml.Append("</imposto>");
                            #endregion

                            qt_item++;

                            xml.Append("</det>");
                        });
                    #endregion

                    #region total
                    xml.Append("<total>");
                    #region ICMSTot
                    xml.Append("<ICMSTot>");
                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_basecalcICMS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion
                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>");
                    #endregion
                    #region vICMSDeson
                    xml.Append("<vICMSDeson>");
                    xml.Append("0.00");
                    xml.Append("</vICMSDeson>");
                    #endregion
                    #region vFCP 
                    if(p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                    {
                        xml.Append("<vFCP>");
                        xml.Append("0.00");
                        xml.Append("</vFCP>");
                    }
                    #endregion
                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion
                    #region vST
                    xml.Append("<vST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vST>");
                    #endregion
                    #region vFCPST
                    if(p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                    {
                        xml.Append("<vFCPST>");
                        xml.Append("0.00");
                        xml.Append("</vFCPST>");
                    }
                    #endregion vFCPSTRet
                    if(p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                    {
                        xml.Append("<vFCPSTRet>");
                        xml.Append("0.00");
                        xml.Append("</vFCPSTRet>");
                    }
                    #endregion
                    #region 
                    #region vProd
                    xml.Append("<vProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_subtotal))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vProd>");
                    #endregion
                    #region vFrete
                    xml.Append("<vFrete>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_frete))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vFrete>");
                    #endregion
                    #region vSeg
                    xml.Append("<vSeg>");
                    xml.Append("0.00");
                    xml.Append("</vSeg>");
                    #endregion
                    #region vDesc
                    xml.Append("<vDesc>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_desconto))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vDesc>");
                    #endregion
                    #region vII
                    xml.Append("<vII>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vII>");
                    #endregion
                    #region vIPI
                    xml.Append("<vIPI>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vIPI>");
                    #endregion
                    #region vIPIDevol
                    if(p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                    {
                        xml.Append("<vIPIDevol>");
                        xml.Append("0.00");
                        xml.Append("</vIPIDevol>");
                    }
                    #endregion
                    #region vPIS
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_pis))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPIS>");
                    #endregion
                    #region vCOFINS
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_cofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCOFINS>");
                    #endregion
                    #region vOutro
                    xml.Append("<vOutro>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_acrescimo + v.Vl_juro_fin))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vOutro>");
                    #endregion
                    #region vNF
                    xml.Append("<vNF>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vNF>");
                    #endregion
                    #region vTotTrib
                    if (p.lItem.Sum(v => v.Vl_imposto_Aprox) > decimal.Zero)
                    {
                        xml.Append("<vTotTrib>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lItem.Sum(v => v.Vl_imposto_Aprox))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vTotTrib>");
                    }
                    #endregion
                    xml.Append("</ICMSTot>");
                    #endregion
                    xml.Append("</total>");
                    #endregion

                    #region transp
                    xml.Append("<transp>");
                    #region modFrete
                    xml.Append("<modFrete>");
                    xml.Append("9");//Sem Frete
                    xml.Append("</modFrete>");
                    #endregion
                    xml.Append("</transp>");
                    #endregion

                    #region pag
                    if (p.rCfgNFCe.Cd_versaonfce.Trim().Equals("3.10"))
                    {
                        if ((p.lPagto.Sum(v => v.Vl_recebidoliq) + p.lDup.Sum(v => v.Vl_atual) != p.Vl_cupom) ||
                            (p.lPagto.Count.Equals(0) && p.lDup.Count.Equals(0)))
                        {
                            //Valor Pago igual valor do cupom(Cupom Finalizador)
                            xml.Append("<pag>");
                            #region tPag
                            xml.Append("<tPag>");
                            xml.Append("01");
                            xml.Append("</tPag>");
                            #endregion
                            #region vPag
                            xml.Append("<vPag>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vPag>");
                            #endregion
                            xml.Append("</pag>");
                        }
                        else
                        {
                            if (p.lPagto.Count > 0)
                            {
                                p.lPagto.GroupBy(v => v.Tp_portador,
                                    (aux, venda) =>
                                        new
                                        {
                                            tp_portador = aux,
                                            vl_portador = venda.Sum(x => x.Vl_DevCredito > decimal.Zero ? x.Vl_DevCredito : x.Vl_recebidoliq)
                                        }).ToList().ForEach(v =>
                                {
                                    xml.Append("<pag>");
                                    #region tPag
                                    xml.Append("<tPag>");
                                        xml.Append(v.tp_portador);
                                        xml.Append("</tPag>");
                                    #endregion
                                    #region vPag
                                    xml.Append("<vPag>");
                                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.vl_portador)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                        xml.Append("</vPag>");
                                    #endregion

                                    #region card
                                    if (v.tp_portador.Trim().Equals("03") ||
                                            v.tp_portador.Trim().Equals("04"))
                                        {
                                            xml.Append("<card>");
                                        #region tpIntegra
                                        xml.Append("<tpIntegra>");
                                            xml.Append("2");//Pagamento não integrado com o sistema de automação da empresa
                                        xml.Append("</tpIntegra>");
                                        #endregion
                                        xml.Append("</card>");
                                        }
                                    #endregion

                                    xml.Append("</pag>");
                                });
                            }
                            if (p.lDup.Count > 0)
                            {
                                xml.Append("<pag>");
                                #region tPag
                                xml.Append("<tPag>");
                                xml.Append("05");
                                xml.Append("</tPag>");
                                #endregion
                                #region vPag
                                xml.Append("<vPag>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lDup[0].Vl_documento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPag>");
                                #endregion
                                xml.Append("</pag>");
                            }
                        }
                    }
                    else//4.00
                    {
                        xml.Append("<pag>");
                        if ((p.lPagto.Sum(v => v.Vl_recebidoliq) + p.lDup.Sum(v => v.Vl_atual) != p.Vl_cupom) ||
                            (p.lPagto.Count.Equals(0) && p.lDup.Count.Equals(0)))
                        {
                            //Valor Pago igual valor do cupom(Cupom Finalizador)
                            #region detPag
                            xml.Append("<detPag>");
                            #region tPag
                            xml.Append("<tPag>");
                            xml.Append("01");
                            xml.Append("</tPag>");
                            #endregion
                            #region vPag
                            xml.Append("<vPag>");
                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                            xml.Append("</vPag>");
                            #endregion
                            xml.Append("</detPag>");
                            #endregion
                        }
                        else
                        {
                            if (p.lPagto.Count > 0)
                            {
                                p.lPagto.GroupBy(v => v.Tp_portador,
                                    (aux, venda) =>
                                        new
                                        {
                                            tp_portador = aux,
                                            vl_portador = venda.Sum(x => x.Vl_DevCredito > decimal.Zero ? x.Vl_DevCredito : x.Vl_recebidoliq)
                                        }).ToList().ForEach(v =>
                                        {
                                            #region detPag
                                            xml.Append("<detPag>");
                                            #region tPag
                                            xml.Append("<tPag>");
                                            xml.Append(v.tp_portador);
                                            xml.Append("</tPag>");
                                            #endregion
                                            #region vPag
                                            xml.Append("<vPag>");
                                            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.vl_portador)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                            xml.Append("</vPag>");
                                            #endregion

                                            #region card
                                            if (v.tp_portador.Trim().Equals("03") ||
                                                    v.tp_portador.Trim().Equals("04"))
                                            {
                                                xml.Append("<card>");
                                                #region tpIntegra
                                                xml.Append("<tpIntegra>");
                                                xml.Append("2");//Pagamento não integrado com o sistema de automação da empresa
                                                xml.Append("</tpIntegra>");
                                                #endregion
                                                xml.Append("</card>");
                                            }
                                            #endregion
                                            xml.Append("</detPag>");
                                            #endregion
                                        });
                            }
                            if (p.lDup.Count > 0)
                            {
                                #region detPag
                                xml.Append("<detPag>");
                                #region tPag
                                xml.Append("<tPag>");
                                xml.Append("05");
                                xml.Append("</tPag>");
                                #endregion
                                #region vPag
                                xml.Append("<vPag>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lDup[0].Vl_documento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPag>");
                                #endregion
                                xml.Append("</detPag>");
                                #endregion
                            }
                        }
                        xml.Append("</pag>");
                    }
                    #endregion
                    xml.Append("</infNFe>");
                    #endregion

                    #region infNFeSupl
                    xml.Append("<infNFeSupl>");
                    #region qrCode
                    xml.Append("<qrCode>");
                    xml.Append("@QRCODE");
                    xml.Append("</qrCode>");
                    #endregion
                    #region urlChave 
                    if (p.rCfgNFCe.Cd_versaonfce.Trim().Equals("4.00"))
                    {
                        xml.Append("<urlChave>");
                        xml.Append(p.rCfgNFCe.Url_chavenfce.Trim());
                        xml.Append("</urlChave>");
                    }
                    #endregion
                    xml.Append("</infNFeSupl>");
                    #endregion
                    
                    xml.Append("</NFe>");
                    #endregion

                    //Assinar XML
                    string xmlassinado = new Utils.Assinatura.TAssinatura2(p.rCfgNFCe.Nr_certificado_nfe,
                                                                           Utils.Assinatura.TAssinatura2.TTpArq.tpEnviaNFE,
                                                                           xml.ToString()).Assinar();
                    p.Digval = xmlassinado.Substring(xmlassinado.IndexOf("<DigestValue>") + 13, xmlassinado.IndexOf("</DigestValue>") - xmlassinado.IndexOf("<DigestValue>") - 13);
                    xmlassinado = xmlassinado.Replace("@QRCODE", "<![CDATA[" + TGerarQRCode.GerarQRCode2(p) + "]]>");
                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            p.rCfgNFCe.Path_nfe_schemas.SeparadorDiretorio() + "nfe_v" + p.rCfgNFCe.Cd_versaonfce + ".xsd",
                                                            "NFE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                    try
                    {
                        p.Chave_acesso = MontarChaveAcessoNfe(p, true);
                       p.XmlNFCe = xmlassinado;
                        //Gravar campos no banco dados
                        System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
                        hs.Add("@P_CHAVE", p.Chave_acesso);
                        hs.Add("@P_EMPRESA", p.Cd_empresa);
                        hs.Add("@P_ID_NFCE", p.Id_nfcestr);
                        new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set chave_acesso = @P_CHAVE, dt_alt = getdate() " +
                                                                  "where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_NFCE", hs);
                        new TCD_XML_NFCe()
                        .Gravar(new TRegistro_XML_NFCe
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_nfce = p.Id_nfce,
                            Xml_nfce = p.XmlNFCe
                        });
                    }
                    catch { }
                });
        }

        public static string GerarXMLRegistro(TRegistro_NFCe val)
        {
            //Buscar Empresa
            val.rEmpresa = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa, string.Empty, string.Empty, null)[0];
            //Buscar Itens
            val.lItem = CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(val.Id_nfcestr,
                                                                           val.Cd_empresa,
                                                                           string.Empty,
                                                                           null);
            //Buscar Pagto
            val.lPagto = new TCD_CaixaPDV().SelectMovCaixa(
                                                    new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_nfcestr
                                                            }
                                                        }, string.Empty);
            //Buscar Dup
            val.lDup = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                            "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom = " + val.Id_nfcestr + ")"
                                            }
                                        }, 1, string.Empty);
            StringBuilder xml = new StringBuilder();
            #region NFe
            xml.Append("<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
            #region infNFe
            xml.Append("<infNFe Id=\"NFe" + MontarChaveAcessoNfe(val, true) + "\" versao=\"" + val.rCfgNFCe.Cd_versaonfce.Trim() + "\">");
            #region ide
            xml.Append("<ide>");
            #region cUF
            xml.Append("<cUF>");
            xml.Append(val.rEmpresa.rEndereco.Cd_uf.Trim());
            xml.Append("</cUF>");
            #endregion

            #region cNF
            xml.Append("<cNF>");
            xml.Append(val.Id_nfcestr.FormatStringEsquerda(8, '0'));
            xml.Append("</cNF>");
            #endregion

            #region natOp
            xml.Append("<natOp>");
            xml.Append(val.Ds_movimentacao.Trim().RemoverCaracteres().SubstCaracteresEsp());
            xml.Append("</natOp>");
            #endregion

            #region indPag
            xml.Append("<indPag>");
            xml.Append("0");
            //0-Pagamento a Vista
            //1-Pagamento a Prazo
            //2-Outros
            xml.Append("</indPag>");
            #endregion

            #region mod
            xml.Append("<mod>");
            xml.Append(val.Cd_modelo.Trim());
            xml.Append("</mod>");
            #endregion

            #region serie
            xml.Append("<serie>");
            xml.Append(val.Nr_serie.Trim());
            xml.Append("</serie>");
            #endregion

            #region nNF
            xml.Append("<nNF>");
            xml.Append(val.NR_NFCestr.Trim());

            xml.Append("</nNF>");
            #endregion

            #region dhEmi
            xml.Append("<dhEmi>");
            xml.Append(val.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de emissão do cupom fiscal
            xml.Append("</dhEmi>");
            #endregion

            #region tpNF
            xml.Append("<tpNF>");
            xml.Append("1");//Saida
            xml.Append("</tpNF>");
            #endregion

            #region idDest
            xml.Append("<idDest>");
            xml.Append("1");//Dentro do Estado NFC-e não permite emissão interestadual
            xml.Append("</idDest>");
            #endregion

            #region cMunFG
            xml.Append("<cMunFG>");
            xml.Append(val.rEmpresa.rEndereco.Cd_cidade.Trim().PadLeft(7, '0')); //Codigo do municipio gerador do icms
            xml.Append("</cMunFG>");
            #endregion

            #region tpImp
            xml.Append("<tpImp>");
            xml.Append("4"); //Formato de impressão do DANFE 
            xml.Append("</tpImp>");
            #endregion

            #region tpEmis
            xml.Append("<tpEmis>");
            xml.Append(val.Id_contingencia.HasValue ? "9" : "1"); //1-Emissao Normal 9 - Contingencia OFFLine
            xml.Append("</tpEmis>");
            #endregion

            #region cDV
            xml.Append("<cDV>");
            xml.Append(CalcularDigitoChave(MontarChaveAcessoNfe(val, false)).Trim()); //Digito verificador da chave de acesso da NFC-e
            xml.Append("</cDV>");
            #endregion

            #region tpAmb
            xml.Append("<tpAmb>");
            xml.Append(val.rCfgNFCe.Tp_ambiente_nfce);
            xml.Append("</tpAmb>");
            #endregion

            #region finNFe
            xml.Append("<finNFe>");
            xml.Append("1");//Normal
            xml.Append("</finNFe>");
            #endregion

            #region indFinal
            xml.Append("<indFinal>");
            xml.Append("1");//0-Nao ; 1-Consumidor final
            xml.Append("</indFinal>");
            #endregion

            #region indPres
            xml.Append("<indPres>");
            xml.Append("1");//Operacao Presencial
            xml.Append("</indPres>");
            #endregion

            #region procEmi
            xml.Append("<procEmi>");
            xml.Append("0");//Emissao de NFCe com aplicação do contribuinte
            xml.Append("</procEmi>");
            #endregion

            #region verProc
            xml.Append("<verProc>");
            xml.Append(val.rCfgNFCe.Cd_versaonfce.Trim());
            xml.Append("</verProc>");
            #endregion

            if (val.Id_contingencia.HasValue)
            {
                #region dhCont
                xml.Append("<dhCont>");
                xml.Append(val.dt_entcontingencia.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                xml.Append("</dhCont>");
                #endregion

                #region xJust
                xml.Append("<xJust>");
                xml.Append(val.Justificativacontingencia.RemoverCaracteres().SubstCaracteresEsp());
                xml.Append("</xJust>");
                #endregion
            }
            xml.Append("</ide>");
            #endregion

            #region emit
            xml.Append("<emit>");
            #region CNPJ
            xml.Append("<CNPJ>");
            xml.Append(val.rEmpresa.rClifor.Nr_cgc.SoNumero());
            xml.Append("</CNPJ>");
            #endregion

            #region xNome
            xml.Append("<xNome>");
            xml.Append(val.rEmpresa.Nm_empresa.RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</xNome>");
            #endregion

            #region xFant
            xml.Append("<xFant>");
            xml.Append(val.rEmpresa.rClifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</xFant>");
            #endregion

            #region enderEmit
            xml.Append("<enderEmit>");
            #region xLgr
            xml.Append("<xLgr>");
            xml.Append(val.rEmpresa.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</xLgr>");
            #endregion

            #region nro
            xml.Append("<nro>");
            xml.Append(val.rEmpresa.rEndereco.Numero.Trim().RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</nro>");
            #endregion

            #region xCpl
            if (!string.IsNullOrEmpty(val.rEmpresa.rEndereco.Ds_complemento))
            {
                xml.Append("<xCpl>");
                xml.Append(val.rEmpresa.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                xml.Append("</xCpl>");
            }
            #endregion

            #region xBairro
            xml.Append("<xBairro>");
            xml.Append(val.rEmpresa.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</xBairro>");
            #endregion

            #region cMun
            xml.Append("<cMun>");
            xml.Append(val.rEmpresa.rEndereco.Cd_cidade.Trim());
            xml.Append("</cMun>");
            #endregion

            #region xMun
            xml.Append("<xMun>");
            xml.Append(val.rEmpresa.rEndereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
            xml.Append("</xMun>");
            #endregion

            #region UF
            xml.Append("<UF>");
            xml.Append(val.rEmpresa.rEndereco.UF.Trim());
            xml.Append("</UF>");
            #endregion

            #region CEP
            xml.Append("<CEP>");
            xml.Append(val.rEmpresa.rEndereco.Cep.SoNumero());
            xml.Append("</CEP>");
            #endregion

            #region cPais
            if (!string.IsNullOrEmpty(val.rEmpresa.rEndereco.CD_Pais))
            {
                xml.Append("<cPais>");
                xml.Append(val.rEmpresa.rEndereco.CD_Pais.Trim());
                xml.Append("</cPais>");
            }
            #endregion

            #region xPais
            if (!string.IsNullOrEmpty(val.rEmpresa.rEndereco.NM_Pais))
            {
                xml.Append("<xPais>");
                xml.Append(val.rEmpresa.rEndereco.NM_Pais.Trim());
                xml.Append("</xPais>");
            }
            #endregion

            #region fone
            if (!string.IsNullOrEmpty(val.rEmpresa.rEndereco.Fone.SoNumero()))
            {
                xml.Append("<fone>");
                xml.Append(val.rEmpresa.rEndereco.Fone.SoNumero());
                xml.Append("</fone>");
            }
            #endregion
            xml.Append("</enderEmit>");
            #endregion

            #region IE
            xml.Append("<IE>");
            xml.Append(val.rEmpresa.rEndereco.Insc_estadual.SoNumero());
            xml.Append("</IE>");
            #endregion

            #region CRT
            xml.Append("<CRT>");
            xml.Append(val.rEmpresa.Tp_regimetributario.Trim());
            xml.Append("</CRT>");
            #endregion
            xml.Append("</emit>");
            #endregion

            #region dest
            if (val.rCliente == null ? false : !string.IsNullOrEmpty((val.rCliente.Nr_cgc + val.rCliente.Nr_cpf).SoNumero()))
            {
                xml.Append("<dest>");
                    #region CNPJ
                    if (val.rCliente.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    {
                        xml.Append("<CNPJ>");
                        xml.Append(val.rCliente.Nr_cgc.SoNumero());
                        xml.Append("</CNPJ>");
                    }
                    #endregion

                    #region CPF
                    if (val.rCliente.Tp_pessoa.Trim().ToUpper().Equals("F"))
                    {
                        xml.Append("<CPF>");
                        xml.Append(val.rCliente.Nr_cpf.SoNumero());
                        xml.Append("</CPF>");
                    }
                    #endregion

                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(val.rCliente.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim());
                    xml.Append("</xNome>");
                    #endregion


                    #region indIEDest
                    xml.Append("<indIEDest>");
                    xml.Append("9");//NFC-e obrigatoriamente deve informar valor 9(Não contribuinte) e não informar tag insc. estadual
                    xml.Append("</indIEDest>");
                    #endregion

                    #region email
                    if (!string.IsNullOrEmpty(val.rCliente.Email))
                    {
                        xml.Append("<email>");
                        xml.Append(val.rCliente.Email.Trim());
                        xml.Append("</email>");
                    }
                    #endregion
                    xml.Append("</dest>");
                
            }
            else if (!string.IsNullOrEmpty(val.Nr_cgc_cpf.SoNumero()) &&
                     (val.Nr_cgc_cpf.SoNumero().Length.Equals(14) ||
                     val.Nr_cgc_cpf.SoNumero().Length.Equals(11)))
            {
                xml.Append("<dest>");
                #region CNPJ
                if (val.Nr_cgc_cpf.SoNumero().Length.Equals(14))
                {
                    xml.Append("<CNPJ>");
                    xml.Append(val.Nr_cgc_cpf.SoNumero());
                    xml.Append("</CNPJ>");
                }
                #endregion

                #region CPF
                if (val.Nr_cgc_cpf.SoNumero().Length.Equals(11))
                {
                    xml.Append("<CPF>");
                    xml.Append(val.Nr_cgc_cpf.SoNumero());
                    xml.Append("</CPF>");
                }
                #endregion

                #region xNome
                xml.Append("<xNome>");
                xml.Append(!string.IsNullOrEmpty(val.Nm_clifor) ? val.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp().Trim() : "CONSUMIDOR FINAL");
                xml.Append("</xNome>");
                #endregion


                #region indIEDest
                xml.Append("<indIEDest>");
                xml.Append("9");//NFC-e obrigatoriamente deve informar valor 9(Não contribuinte) e não informar tag insc. estadual
                xml.Append("</indIEDest>");
                #endregion
                xml.Append("</dest>");
            }
            #endregion

            #region det
            int qt_item = 1;
            val.lItem.ForEach(v =>
            {
                xml.Append("<det nItem=\"" + qt_item.ToString() + "\">");
                #region prod
                xml.Append("<prod>");
                #region cProd
                xml.Append("<cProd>");
                xml.Append(v.Cd_produto.Trim());
                xml.Append("</cProd>");
                #endregion

                #region cEAN
                xml.Append("<cEAN>");
                xml.Append("</cEAN>");
                #endregion

                #region xProd
                xml.Append("<xProd>");
                xml.Append(v.Ds_produto.RemoverCaracteres().SubstCaracteresEsp().Trim());
                xml.Append("</xProd>");
                #endregion

                #region NCM
                xml.Append("<NCM>");
                xml.Append(v.Ncm.Trim());
                xml.Append("</NCM>");
                #endregion

                #region CEST
                if (!string.IsNullOrEmpty(v.Cest))
                {
                    xml.Append("<CEST>");
                    xml.Append(v.Cest.Trim());
                    xml.Append("</CEST>");
                }
                #endregion

                #region CFOP
                xml.Append("<CFOP>");
                xml.Append(v.Cd_cfop.FormatStringEsquerda(4, '0'));
                xml.Append("</CFOP>");
                #endregion

                #region uCom
                xml.Append("<uCom>");
                xml.Append(v.Sigla_unidade.Trim());
                xml.Append("</uCom>");
                #endregion

                #region qCom
                xml.Append("<qCom>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</qCom>");
                #endregion

                #region vUnCom
                xml.Append("<vUnCom>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N10}", v.Vl_unitario)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vUnCom>");
                #endregion

                #region vProd
                xml.Append("<vProd>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_subtotal)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vProd>");
                #endregion

                #region cEANTrib
                xml.Append("<cEANTrib>");
                xml.Append("</cEANTrib>");
                #endregion

                #region uTrib
                xml.Append("<uTrib>");
                xml.Append(v.Sigla_unidade.Trim());
                xml.Append("</uTrib>");
                #endregion

                #region qTrib
                xml.Append("<qTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</qTrib>");
                #endregion

                #region vUnTrib
                xml.Append("<vUnTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N10}", v.Vl_unitario)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vUnTrib>");
                #endregion

                #region vFrete
                if (v.Vl_frete > decimal.Zero)
                {
                    xml.Append("<vFrete>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_frete)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vFrete>");
                }

                #endregion

                #region vDesc
                if (v.Vl_desconto > decimal.Zero)
                {
                    xml.Append("<vDesc>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_desconto)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vDesc>");
                }
                #endregion

                #region vOutro
                if ((v.Vl_juro_fin + v.Vl_acrescimo) > decimal.Zero)
                {
                    xml.Append("<vOutro>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_acrescimo + v.Vl_juro_fin)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vOutro>");
                }
                #endregion

                #region indTot
                xml.Append("<indTot>");
                xml.Append("1");//Valor do item compoe o valor total da NFCe
                xml.Append("</indTot>");
                #endregion

                bool st_comb = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(v.Cd_produto);
                if (st_comb ||
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoLubrificante(v.Cd_produto))
                {
                    #region Combustiveis e Lubrificantes
                    xml.Append("<comb>");

                    #region cProdANP
                    xml.Append("<cProdANP>");
                    xml.Append(v.Cd_anp.Trim());
                    xml.Append("</cProdANP>");
                    #endregion

                    #region UFCons
                    xml.Append("<UFCons>");
                    xml.Append(val.rEmpresa.rEndereco.UF.Trim());
                    xml.Append("</UFCons>");
                    #endregion

                    if (st_comb)
                    {
                        //Buscar Abastecida Cupom
                        CamadaDados.PostoCombustivel.TList_VendaCombustivel lVComp =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_vendarapida = a.id_cupom " +
                                                        "and x.id_lanctovenda = a.id_lancto " +
                                                        "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                        "and x.id_cupom = " + v.ID_NFCe.Value.ToString() + " " +
                                                        "and x.id_lancto = " + v.Id_lancto.Value.ToString() + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
                        if (lVComp.Count.Equals(0))
                            throw new Exception("Item combustivel não teve origem abastecimento [nItem:" + v.Id_lancto.Value.ToString() + "].");
                        #region encerrante
                        xml.Append("<encerrante>");

                        #region nBico
                        xml.Append("<nBico>");
                        xml.Append(lVComp[0].Ds_label.Trim());
                        xml.Append("</nBico>");
                        #endregion

                        #region nBomba
                        xml.Append("<nBomba>");
                        xml.Append(lVComp[0].Id_bombastr);
                        xml.Append("</nBomba>");
                        #endregion

                        #region nTanque
                        xml.Append("<nTanque>");
                        xml.Append(lVComp[0].Id_tanquestr);
                        xml.Append("</nTanque>");
                        #endregion

                        #region vEncIni
                        xml.Append("<vEncIni>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico - lVComp[0].Volumeabastecido)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vEncIni>");
                        #endregion

                        #region vEncFin
                        xml.Append("<vEncFin>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N3}", lVComp[0].Encerrantebico)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vEncFin>");
                        #endregion

                        xml.Append("</encerrante>");
                        #endregion
                    }

                    xml.Append("</comb>\n");
                    #endregion
                }

                xml.Append("</prod>");
                #endregion

                #region imposto
                xml.Append("<imposto>");
                #region vTotTrib
                if (v.Vl_imposto_Aprox > decimal.Zero)
                {
                    xml.Append("<vTotTrib>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_imposto_Aprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vTotTrib>");
                }
                #endregion

                #region ICMS
                if (!v.Cd_icms.HasValue)
                    throw new Exception("Não é permitido gerar NFC-e com item sem destacar ICMS.");
                if (v.Cd_st_icms.Trim().Equals("50") ||
                    v.Cd_st_icms.Trim().Equals("51"))
                    throw new Exception("NFC-e não permite ICMS com CST igual a 50 ou 51.");
                xml.Append("<ICMS>");
                #region ICMS00
                if (v.Cd_st_icms.Trim().Equals("00"))
                {
                    xml.Append("<ICMS00>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region modBC
                    xml.Append("<modBC>");
                    xml.Append(v.Tp_modbasecalc.Trim());
                    xml.Append("</modBC>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pICMS
                    xml.Append("<pICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMS>");
                    #endregion

                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>");
                    #endregion
                    xml.Append("</ICMS00>");
                }
                #endregion
                /*
                #region ICMS10
                if (rICMS.Cd_st.Trim().Equals("10"))
                {
                    xml.Append("<ICMS10>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region modBC
                    xml.Append("<modBC>");
                    xml.Append(rICMS.Tp_modbasecalc.Trim());
                    xml.Append("</modBC>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pICMS
                    xml.Append("<pICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMS>");
                    #endregion

                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>");
                    #endregion

                    #region modBCST
                    xml.Append("<modBCST>");
                    xml.Append(rICMS.Tp_modbasecalcST.Trim());
                    xml.Append("</modBCST>");
                    #endregion

                    #region pMVAST
                    if (rICMS.Pc_iva_st > decimal.Zero)
                    {
                        xml.Append("<pMVAST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pMVAST>");
                    }
                    #endregion

                    #region pRedBCST
                    if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                    {
                        xml.Append("<pRedBCST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pRedBCST>");
                    }
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion

                    #region pICMSST
                    xml.Append("<pICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMSST>");
                    #endregion

                    #region vICMSST
                    xml.Append("<vICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMSST>");
                    #endregion
                    xml.Append("</ICMS10>");
                }
                #endregion

                #region ICMS20
                if (rICMS.Cd_st.Trim().Equals("20"))
                {
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region modBC
                    xml.Append("<modBC>");
                    xml.Append(rICMS.Tp_modbasecalc.Trim());
                    xml.Append("</modBC>");
                    #endregion

                    #region pRedBC
                    xml.Append("<pRedBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pRedBC>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pICMS
                    xml.Append("<pICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMS>");
                    #endregion

                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>");
                    #endregion
                }
                #endregion

                #region ICMS30
                if (rICMS.Cd_st.Trim().Equals("30"))
                {
                    xml.Append("<ICMS30>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region modBCST
                    xml.Append("<modBCST>");
                    xml.Append(rICMS.Tp_modbasecalcST.Trim());
                    xml.Append("</modBCST>");
                    #endregion

                    #region pMVAST
                    if (rICMS.Pc_iva_st > decimal.Zero)
                    {
                        xml.Append("<pMVAST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pMVAST>");
                    }
                    #endregion

                    #region pRedBCST
                    if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                    {
                        xml.Append("<pRedBCST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pRedBCST>");
                    }
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion

                    #region pICMSST
                    xml.Append("<pICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMSST>");
                    #endregion

                    #region vICMSST
                    xml.Append("<vICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMSST>");
                    #endregion
                    xml.Append("</ICMS30>");
                }
                #endregion
                */
                #region ICMS40
                if (v.Cd_st_icms.Trim().Equals("40") ||
                    v.Cd_st_icms.Trim().Equals("41"))
                {
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CST>");
                    #endregion
                }
                #endregion

                #region ICMS60
                if (v.Cd_st_icms.Trim().Equals("60"))
                {
                    xml.Append("<ICMS60>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CST>");
                    #endregion
                    xml.Append("</ICMS60>");
                }
                #endregion
                /*
                #region ICMS70
                if (rICMS.Cd_st.Trim().Equals("70"))
                {
                    xml.Append("<ICMS70>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region modBC
                    xml.Append("<modBC>");
                    xml.Append(rICMS.Tp_modbasecalc.Trim());
                    xml.Append("</modBC>");
                    #endregion

                    #region pRedBC
                    xml.Append("<pRedBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pRedBC>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pICMS
                    xml.Append("<pICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMS>");
                    #endregion

                    #region vICMS
                    xml.Append("<vICMS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMS>");
                    #endregion

                    #region modBCST
                    xml.Append("<modBCST>");
                    xml.Append(rICMS.Tp_modbasecalcST.Trim());
                    xml.Append("</modBCST>");
                    #endregion

                    #region pMVAST
                    if (rICMS.Pc_iva_st > decimal.Zero)
                    {
                        xml.Append("<pMVAST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pMVAST>");
                    }
                    #endregion

                    #region pRedBCST
                    if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                    {
                        xml.Append("<pRedBCST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pRedBCST");
                    }
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion

                    #region pICMSST
                    xml.Append("<pICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMSST>");
                    #endregion

                    #region vICMSST
                    xml.Append("<vICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMSST>");
                    #endregion
                    xml.Append("</ICMS70>");
                }
                #endregion
                */
                #region ICMS90
                if (v.Cd_st_icms.Trim().Equals("90"))
                {
                    xml.Append("<ICMS90>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CST>");
                    #endregion
                    xml.Append("</ICMS90>");
                }
                #endregion

                #region ICMSSN101
                if (v.Cd_st_icms.Trim().Equals("101"))
                {
                    xml.Append("<ICMSSN101>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CSOSN>");
                    #endregion

                    #region pCredSN
                    xml.Append("<pCredSN>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaICMS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pCredSN>");
                    #endregion

                    #region vCredICMSSN
                    xml.Append("<vCredICMSSN>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_icms)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCredICMSSN>");
                    #endregion
                    xml.Append("</ICMSSN101>");
                }
                #endregion

                #region ICMSSN102
                if (v.Cd_st_icms.Trim().Equals("102") ||
                    v.Cd_st_icms.Trim().Equals("103") ||
                    v.Cd_st_icms.Trim().Equals("300") ||
                    v.Cd_st_icms.Trim().Equals("400"))
                {
                    xml.Append("<ICMSSN102>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CSOSN>");
                    #endregion
                    xml.Append("</ICMSSN102>");
                }
                #endregion
                /*
                #region ICMSSN201
                if (rICMS.Cd_st.Trim().Equals("201"))
                {
                    xml.Append("<ICMSSN201>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CSOSN>");
                    #endregion

                    #region modBCST
                    xml.Append("<modBCST>");
                    xml.Append(rICMS.Tp_modbasecalcST.Trim());
                    xml.Append("</modBCST>");
                    #endregion

                    #region pMVAST
                    if (rICMS.Pc_iva_st > decimal.Zero)
                    {
                        xml.Append("<pMVAST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pMVAST>");
                    }
                    #endregion

                    #region pRedBCST
                    if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                    {
                        xml.Append("<pRedBCST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pRedBCST>");
                    }
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion

                    #region pICMSST
                    xml.Append("<pICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMSST>");
                    #endregion

                    #region vICMSST
                    xml.Append("<vICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMSST>");
                    #endregion

                    #region pCredSN
                    xml.Append("<pCredSN>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquota)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pCredSN>");
                    #endregion

                    #region vCredICMSSN
                    xml.Append("<vCredICMSSN>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCredICMSSN>");
                    #endregion
                    xml.Append("</ICMSSN201>");
                }
                #endregion

                #region ICMSSN202
                if (rICMS.Cd_st.Trim().Equals("202") ||
                    rICMS.Cd_st.Trim().Equals("203"))
                {
                    xml.Append("<ICMSSN202>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(rICMS.Cd_st.Trim());
                    xml.Append("</CSOSN>");
                    #endregion

                    #region modBCST
                    xml.Append("<modBCST>");
                    xml.Append(rICMS.Tp_modbasecalcST.Trim());
                    xml.Append("</modBCST>");
                    #endregion

                    #region pMVAST
                    if (rICMS.Pc_iva_st > decimal.Zero)
                    {
                        xml.Append("<pMVAST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_iva_st)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pMVAST>");
                    }
                    #endregion

                    #region pRedBCST
                    if (rICMS.Pc_reducaobasecalcsubsttrib > decimal.Zero)
                    {
                        xml.Append("<pRedBCST>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_reducaobasecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pRedBCST>");
                    }
                    #endregion

                    #region vBCST
                    xml.Append("<vBCST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_basecalcsubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBCST>");
                    #endregion

                    #region pICMSST
                    xml.Append("<pICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Pc_aliquotasubst)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pICMSST>");
                    #endregion

                    #region vICMSST
                    xml.Append("<vICMSST>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rICMS.Vl_impostosubsttrib)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vICMSST>");
                    #endregion
                    xml.Append("</ICMSSN202>");
                }
                #endregion
                */
                #region ICMSSN500
                if (v.Cd_st_icms.Trim().Equals("500"))
                {
                    xml.Append("<ICMSSN500>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CSOSN>");
                    #endregion
                    xml.Append("</ICMSSN500>");
                }
                #endregion

                #region ICMSSN900
                if (v.Cd_st_icms.Trim().Equals("900"))
                {
                    xml.Append("<ICMSSN900>");
                    #region orig
                    xml.Append("<orig>");
                    xml.Append("0");//Nacional
                    xml.Append("</orig>");
                    #endregion

                    #region CSOSN
                    xml.Append("<CSOSN>");
                    xml.Append(v.Cd_st_icms.Trim());
                    xml.Append("</CSOSN>");
                    #endregion
                    xml.Append("</ICMSSN900>");
                }
                #endregion
                xml.Append("</ICMS>");
                #endregion

                #region PIS
                if (!v.Cd_pis.HasValue)
                    throw new Exception("Não é permitido gerar NFC-e com item sem destacar PIS.");
                xml.Append("<PIS>");
                #region PISAliq
                if (v.Cd_st_pis.Trim().Equals("01") ||
                    v.Cd_st_pis.Trim().Equals("02"))
                {
                    xml.Append("<PISAliq>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_pis.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pPIS
                    xml.Append("<pPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pPIS>");
                    #endregion

                    #region vPIS
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPIS>");
                    #endregion
                    xml.Append("</PISAliq>");
                }
                #endregion
                /*
                #region PISQtde
                if (rPIS.Cd_st.Trim().Equals("03"))
                {
                    xml.Append("<PISQtde>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(rPIS.Cd_st.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region qBCProd
                    xml.Append("<qBCProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</qBCProd>");
                    #endregion

                    #region vAliqProd
                    xml.Append("<vAliqProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vAliqProd>");
                    #endregion

                    #region vPIS
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPIS>");
                    #endregion
                    xml.Append("</PISQtde>");
                }
                #endregion
                */
                #region PISNT
                if (v.Cd_st_pis.Trim().Equals("04") ||
                    v.Cd_st_pis.Trim().Equals("05") ||
                    v.Cd_st_pis.Trim().Equals("06") ||
                    v.Cd_st_pis.Trim().Equals("07") ||
                    v.Cd_st_pis.Trim().Equals("08") ||
                    v.Cd_st_pis.Trim().Equals("09"))
                {
                    xml.Append("<PISNT>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_pis.Trim());
                    xml.Append("</CST>");
                    #endregion
                    xml.Append("</PISNT>");
                }
                #endregion

                #region PISOutr
                if (v.Cd_st_pis.Trim().Equals("49") ||
                    v.Cd_st_pis.Trim().Equals("50") ||
                    v.Cd_st_pis.Trim().Equals("51") ||
                    v.Cd_st_pis.Trim().Equals("52") ||
                    v.Cd_st_pis.Trim().Equals("53") ||
                    v.Cd_st_pis.Trim().Equals("54") ||
                    v.Cd_st_pis.Trim().Equals("55") ||
                    v.Cd_st_pis.Trim().Equals("56") ||
                    v.Cd_st_pis.Trim().Equals("60") ||
                    v.Cd_st_pis.Trim().Equals("61") ||
                    v.Cd_st_pis.Trim().Equals("62") ||
                    v.Cd_st_pis.Trim().Equals("63") ||
                    v.Cd_st_pis.Trim().Equals("64") ||
                    v.Cd_st_pis.Trim().Equals("65") ||
                    v.Cd_st_pis.Trim().Equals("66") ||
                    v.Cd_st_pis.Trim().Equals("67") ||
                    v.Cd_st_pis.Trim().Equals("70") ||
                    v.Cd_st_pis.Trim().Equals("71") ||
                    v.Cd_st_pis.Trim().Equals("72") ||
                    v.Cd_st_pis.Trim().Equals("73") ||
                    v.Cd_st_pis.Trim().Equals("74") ||
                    v.Cd_st_pis.Trim().Equals("75") ||
                    v.Cd_st_pis.Trim().Equals("98") ||
                    v.Cd_st_pis.Trim().Equals("99"))
                {
                    xml.Append("<PISOutr>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_pis.Trim());
                    xml.Append("</CST>");
                    #endregion

                    if (v.Pc_aliquotaPIS > decimal.Zero)
                    {
                        #region vBC
                        xml.Append("<vBC>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vBC>");
                        #endregion

                        #region pPIS
                        xml.Append("<pPIS>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaPIS)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pPIS>");
                        #endregion
                    }
                    //else
                    //{
                    //    #region qBCProd
                    //    xml.Append("<qBCProd>");
                    //    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    //    xml.Append("</qBCProd>");
                    //    #endregion

                    //    #region vAliqProd
                    //    xml.Append("<vAliqProd>");
                    //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rPIS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    //    xml.Append("</vAliqProd>");
                    //    #endregion
                    //}
                    #region vPIS
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_pis)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPIS>");
                    #endregion
                    xml.Append("</PISOutr>");
                }
                #endregion
                xml.Append("</PIS>");
                #endregion

                #region COFINS
                if (!v.Cd_cofins.HasValue)
                    throw new Exception("Não é permitido gerar NFC-e com item sem destacar COFINS.");
                xml.Append("<COFINS>");
                #region COFINSAliq
                if (v.Cd_st_cofins.Trim().Equals("01") ||
                    v.Cd_st_cofins.Trim().Equals("02"))
                {
                    xml.Append("<COFINSAliq>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_cofins.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region vBC
                    xml.Append("<vBC>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vBC>");
                    #endregion

                    #region pCOFINS
                    xml.Append("<pCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</pCOFINS>");
                    #endregion

                    #region vCOFINS
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCOFINS>");
                    #endregion
                    xml.Append("</COFINSAliq>");
                }
                #endregion
                /*
                #region COFINSQtde
                if (v.Cd_st_cofins.Trim().Equals("03"))
                {
                    xml.Append("<COFINSQtde>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_cofins.Trim());
                    xml.Append("</CST>");
                    #endregion

                    #region qBCProd
                    xml.Append("<qBCProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</qBCProd>");
                    #endregion

                    #region vAliqProd
                    xml.Append("<vAliqProd>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vAliqProd>");
                    #endregion

                    #region vCOFINS
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_impostocalc)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCOFINS>");
                    #endregion
                    xml.Append("</COFINSQtde>");
                }
                #endregion
                */
                #region COFINSNT
                if (v.Cd_st_cofins.Trim().Equals("04") ||
                    v.Cd_st_cofins.Trim().Equals("05") ||
                    v.Cd_st_cofins.Trim().Equals("06") ||
                    v.Cd_st_cofins.Trim().Equals("07") ||
                    v.Cd_st_cofins.Trim().Equals("08") ||
                    v.Cd_st_cofins.Trim().Equals("09"))
                {
                    xml.Append("<COFINSNT>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_cofins.Trim());
                    xml.Append("</CST>");
                    #endregion
                    xml.Append("</COFINSNT>");
                }
                #endregion

                #region COFINSOutr
                if (v.Cd_st_cofins.Trim().Equals("49") ||
                    v.Cd_st_cofins.Trim().Equals("50") ||
                    v.Cd_st_cofins.Trim().Equals("51") ||
                    v.Cd_st_cofins.Trim().Equals("52") ||
                    v.Cd_st_cofins.Trim().Equals("53") ||
                    v.Cd_st_cofins.Trim().Equals("54") ||
                    v.Cd_st_cofins.Trim().Equals("55") ||
                    v.Cd_st_cofins.Trim().Equals("56") ||
                    v.Cd_st_cofins.Trim().Equals("60") ||
                    v.Cd_st_cofins.Trim().Equals("61") ||
                    v.Cd_st_cofins.Trim().Equals("62") ||
                    v.Cd_st_cofins.Trim().Equals("63") ||
                    v.Cd_st_cofins.Trim().Equals("64") ||
                    v.Cd_st_cofins.Trim().Equals("65") ||
                    v.Cd_st_cofins.Trim().Equals("66") ||
                    v.Cd_st_cofins.Trim().Equals("67") ||
                    v.Cd_st_cofins.Trim().Equals("70") ||
                    v.Cd_st_cofins.Trim().Equals("71") ||
                    v.Cd_st_cofins.Trim().Equals("72") ||
                    v.Cd_st_cofins.Trim().Equals("73") ||
                    v.Cd_st_cofins.Trim().Equals("74") ||
                    v.Cd_st_cofins.Trim().Equals("75") ||
                    v.Cd_st_cofins.Trim().Equals("98") ||
                    v.Cd_st_cofins.Trim().Equals("99"))
                {
                    xml.Append("<COFINSOutr>");
                    #region CST
                    xml.Append("<CST>");
                    xml.Append(v.Cd_st_cofins.Trim());
                    xml.Append("</CST>");
                    #endregion

                    if (v.Pc_aliquotaCofins > decimal.Zero)
                    {
                        #region vBC
                        xml.Append("<vBC>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_basecalcCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</vBC>");
                        #endregion

                        #region pCOFINS
                        xml.Append("<pCOFINS>");
                        xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Pc_aliquotaCofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                        xml.Append("</pCOFINS>");
                        #endregion
                    }
                    //else
                    //{
                    //    #region qBCProd
                    //    xml.Append("<qBCProd>");
                    //    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    //    xml.Append("</qBCProd>");
                    //    #endregion

                    //    #region vAliqProd
                    //    xml.Append("<vAliqProd>");
                    //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", rCOFINS.Vl_imposto_unit)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    //    xml.Append("</vAliqProd>");
                    //    #endregion
                    //}
                    #region vCOFINS
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_cofins)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCOFINS>");
                    #endregion
                    xml.Append("</COFINSOutr>");
                }
                #endregion
                xml.Append("</COFINS>");
                #endregion
                xml.Append("</imposto>");
                #endregion

                qt_item++;

                xml.Append("</det>");
            });
            #endregion

            #region total
            xml.Append("<total>");
            #region ICMSTot
            xml.Append("<ICMSTot>");
            #region vBC
            xml.Append("<vBC>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_basecalcICMS))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vBC>");
            #endregion
            #region vICMS
            xml.Append("<vICMS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vICMS>");
            #endregion
            #region vICMSDeson
            xml.Append("<vICMSDeson>");
            xml.Append("0.00");
            xml.Append("</vICMSDeson>");
            #endregion
            #region vBCST
            xml.Append("<vBCST>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vBCST>");
            #endregion
            #region vST
            xml.Append("<vST>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vST>");
            #endregion
            #region vProd
            xml.Append("<vProd>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_subtotal))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vProd>");
            #endregion
            #region vFrete
            xml.Append("<vFrete>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_frete))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vFrete>");
            #endregion
            #region vSeg
            xml.Append("<vSeg>");
            xml.Append("0.00");
            xml.Append("</vSeg>");
            #endregion
            #region vDesc
            xml.Append("<vDesc>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_desconto))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vDesc>");
            #endregion
            #region vII
            xml.Append("<vII>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vII>");
            #endregion
            #region vIPI
            xml.Append("<vIPI>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vIPI>");
            #endregion
            #region vPIS
            xml.Append("<vPIS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_pis))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vPIS>");
            #endregion
            #region vCOFINS
            xml.Append("<vCOFINS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_cofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vCOFINS>");
            #endregion
            #region vOutro
            xml.Append("<vOutro>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_acrescimo + v.Vl_juro_fin))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vOutro>");
            #endregion
            #region vNF
            xml.Append("<vNF>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vNF>");
            #endregion
            #region vTotTrib
            if (val.lItem.Sum(v => v.Vl_imposto_Aprox) > decimal.Zero)
            {
                xml.Append("<vTotTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lItem.Sum(v => v.Vl_imposto_Aprox))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vTotTrib>");
            }
            #endregion
            xml.Append("</ICMSTot>");
            #endregion
            xml.Append("</total>");
            #endregion

            #region transp
            xml.Append("<transp>");
            #region modFrete
            xml.Append("<modFrete>");
            xml.Append("9");//Sem Frete
            xml.Append("</modFrete>");
            #endregion
            xml.Append("</transp>");
            #endregion

            #region pag
            if ((val.lPagto.Sum(v => v.Vl_recebidoliq) + val.lDup.Sum(v => v.Vl_atual) != val.Vl_cupom) ||
                (val.lPagto.Count.Equals(0) && val.lDup.Count.Equals(0)))
            {
                //Valor Pago igual valor do cupom(Cupom Finalizador)
                xml.Append("<pag>");
                #region tPag
                xml.Append("<tPag>");
                xml.Append("01");
                xml.Append("</tPag>");
                #endregion
                #region vPag
                xml.Append("<vPag>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vPag>");
                #endregion
                xml.Append("</pag>");
            }
            else
            {
                if (val.lPagto.Count > 0)
                {
                    val.lPagto.GroupBy(v => v.Tp_portador,
                        (aux, venda) =>
                            new
                            {
                                tp_portador = aux,
                                vl_portador = venda.Sum(x => x.Vl_DevCredito > decimal.Zero ? x.Vl_DevCredito : x.Vl_recebidoliq)
                            }).ToList().ForEach(v =>
                            {
                                xml.Append("<pag>");
                                #region tPag
                                xml.Append("<tPag>");
                                xml.Append(v.tp_portador);
                                xml.Append("</tPag>");
                                #endregion
                                #region vPag
                                xml.Append("<vPag>");
                                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.vl_portador)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                                xml.Append("</vPag>");
                                #endregion

                                #region card
                                if (v.tp_portador.Trim().Equals("03") ||
                                    v.tp_portador.Trim().Equals("04"))
                                {
                                    xml.Append("<card>");
                                    #region tpIntegra
                                    xml.Append("<tpIntegra>");
                                    xml.Append("2");//Pagamento não integrado com o sistema de automação da empresa
                                    xml.Append("</tpIntegra>");
                                    #endregion
                                    xml.Append("</card>");
                                }
                                #endregion

                                xml.Append("</pag>");
                            });
                }
                if (val.lDup.Count > 0)
                {
                    xml.Append("<pag>");
                    #region tPag
                    xml.Append("<tPag>");
                    xml.Append("05");
                    xml.Append("</tPag>");
                    #endregion
                    #region vPag
                    xml.Append("<vPag>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", val.lDup[0].Vl_documento)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPag>");
                    #endregion
                    xml.Append("</pag>");
                }
            }
            #endregion
            xml.Append("</infNFe>");
            #endregion

            #region infNFeSupl
            xml.Append("<infNFeSupl>");
            #region qrCode
            xml.Append("<qrCode>");
            xml.Append("@QRCODE");
            xml.Append("</qrCode>");
            #endregion
            xml.Append("</infNFeSupl>");
            #endregion

            xml.Append("</NFe>");
            #endregion

            //Assinar XML
            string xmlassinado = new Utils.Assinatura.TAssinatura2(val.rCfgNFCe.Nr_certificado_nfe,
                                                                   Utils.Assinatura.TAssinatura2.TTpArq.tpEnviaNFE,
                                                                   xml.ToString()).Assinar();
            val.Digval = xmlassinado.Substring(xmlassinado.IndexOf("<DigestValue>") + 13, xmlassinado.IndexOf("</DigestValue>") - xmlassinado.IndexOf("<DigestValue>") - 13);
            xmlassinado = xmlassinado.Replace("@QRCODE", "<![CDATA[" + TGerarQRCode.GerarQRCode2(val) + "]]>");
            //Validar Schema XML
            Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                    val.rCfgNFCe.Path_nfe_schemas.SeparadorDiretorio() + "nfe_v" + val.rCfgNFCe.Cd_versaonfce + ".xsd",
                                                    "NFE");
            try
            {
                val.Chave_acesso = MontarChaveAcessoNfe(val, true);
                val.XmlNFCe = xmlassinado;
                //Gravar campos no banco dados
                System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
                hs.Add("@P_CHAVE", val.Chave_acesso);
                hs.Add("@P_EMPRESA", val.Cd_empresa);
                hs.Add("@P_ID_NFCE", val.Id_nfce);
                new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set chave_acesso = @P_CHAVE, dt_alt = getdate() " +
                                                          "where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_NFCE", hs);
                new TCD_XML_NFCe().Gravar(
                    new TRegistro_XML_NFCe
                    {
                        Cd_empresa = val.Cd_empresa,
                        Id_nfce = val.Id_nfce,
                        Xml_nfce = val.XmlNFCe
                    });
            }
            catch { }
            return val.XmlNFCe;
        }

        public static string GerarXMLPeriodo(string vPath,
                                             string Cd_cliente,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string Cd_empresa,
                                             string Id_nfce)
        {
            try
            {
                string retorno = string.Empty;
                //Path XML
                if (vPath.Trim().Substring(vPath.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath += System.IO.Path.DirectorySeparatorChar.ToString();
                //Buscar NFCe 
                TpBusca[] filtro = new TpBusca[2];
                filtro[0].vNM_Campo = "b.cd_modelo";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'65'";
                filtro[1].vNM_Campo = "isnull(c.nr_protocolo, 0)";
                filtro[1].vOperador = "<>";
                filtro[1].vVL_Busca = "0";
                if(!string.IsNullOrEmpty(Dt_ini.SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd HH:mm:ss") + "'";
                }
                if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), b.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd HH:mm:ss") + "'";
                }
                if(!string.IsNullOrEmpty(Cd_empresa))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                }
                if(!string.IsNullOrEmpty(Cd_cliente))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_clifor";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_cliente.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(Id_nfce))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.NR_NFCe";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = Id_nfce;
                }
                TList_XML_NFCe lXML = new TCD_XML_NFCe().Select(filtro, 0, string.Empty);
                if (lXML.Count > 0)
                    lXML.ForEach(p =>
                        {
                            if (string.IsNullOrWhiteSpace(p.Xml_nfce))
                                p.Xml_nfce = GerarXMLRegistro(
                                    new TCD_NFCe().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca
                                            {
                                                vNM_Campo = "a.id_nfce",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_nfcestr
                                            }
                                        }, 1, string.Empty, string.Empty)[0]);
                            if (!string.IsNullOrWhiteSpace(p.Xml_nfce))
                            {
                                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                                doc.LoadXml(p.Xml_nfce);
                                string versao = doc.GetElementsByTagName("infNFe")[0].Attributes["versao"].InnerText;
                                string xmlLote = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
                                xmlLote += "<nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + versao + "\">\n";
                                xmlLote += p.Xml_nfce + "\n";
                                xmlLote += "<protNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + versao + "\">\n";
                                xmlLote += "<infProt>\n";
                                xmlLote += "<tpAmb>" + p.Tp_ambiente + "</tpAmb>\n";
                                xmlLote += "<verAplic>" + p.Veraplic.Trim() + "</verAplic>\n";
                                xmlLote += "<chNFe>" + p.Chave_acesso.Trim() + "</chNFe>\n";
                                xmlLote += "<dhRecbto>" + p.Dt_processamento.Value.ToString("yyyy-MM-ddTHH:mm:sszzz") + "</dhRecbto>\n";
                                xmlLote += "<nProt>" + p.Nr_protocolo.Value.ToString() + "</nProt>\n";
                                xmlLote += "<digVal>" + p.Digval.Trim() + "</digVal>\n";
                                xmlLote += "<cStat>" + p.Statusnfce.Value.ToString() + "</cStat>\n";
                                xmlLote += "<xMotivo>" + p.Ds_msgnfce.Trim() + "</xMotivo>\n";
                                xmlLote += "</infProt>\n";
                                xmlLote += "</protNFe>\n";
                                xmlLote += "</nfeProc>";
                                //Salvar arquivo no Path indicado 
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath.Trim() + p.Chave_acesso.Trim() + "-nfe.xml"))
                                {
                                    sw.Write(xmlLote);
                                    sw.Flush();
                                    sw.Close();
                                }
                                //Buscar Eventos NFe
                                CamadaNegocio.Faturamento.PDV.TCN_EventoNFCe.Buscar(p.Cd_empresa,
                                                                                    p.Id_nfcestr,
                                                                                    "T",
                                                                                    null).ForEach(v =>
                                                                                    {
                                                                                        System.Xml.XmlDocument docevent = new System.Xml.XmlDocument();
                                                                                        docevent.LoadXml(v.Xml_evento);
                                                                                        var e = docevent.GetElementsByTagName("verEvento");
                                                                                        string teste = e[0].InnerText;
                                                                                        StringBuilder xml = new StringBuilder();
                                                                                        xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                                                                        xml.Append("<procEventoNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + teste + "\">");
                                                                                        xml.Append(v.Xml_evento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty).Replace(" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", string.Empty));
                                                                                        xml.Append(v.Xml_retevento.Replace(" xmlns=\"http://www.portalfiscal.inf.br/nfe\"", string.Empty));
                                                                                        xml.Append("</procEventoNFe>");
                                                                                        //Salvar arquivo no Path indicado 
                                                                                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath.Trim() +
                                                                                                                                                      v.Cd_eventostr.Trim() + "-" +
                                                                                                                                                      p.Chave_acesso.Trim() + "-procEventoNFe.xml"))
                                                                                        {
                                                                                            sw.Write(xml.ToString());
                                                                                            sw.Flush();
                                                                                            sw.Close();
                                                                                        }
                                                                                    });
                            }
                            else retorno += "NFC-e <" + p.Nr_NFCe?.ToString() + "> não possui XML.\r\n";
                        });
                return retorno;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message.Trim()); }
        }
    }
}
