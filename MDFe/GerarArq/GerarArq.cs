using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Frota;
using CamadaDados.Frota.Cadastros;

namespace MDFe.GerarArq
{
    public class TGerarArq
    {
        public static string MontarChaveAcessoMDFe(TRegistro_MDFe val,
                                                   TRegistro_CfgMDFe rCfgMDFe)
        {
            return rCfgMDFe.rEmp.rEndereco.Cd_uf.Trim() + //Codigo UF Empresa
                    Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Year.ToString().FormatStringEsquerda(2, '0') + //Ano Emissao
                    Convert.ToDateTime(val.Dt_emissao.Value.ToString("dd/MM/yy")).Month.ToString().FormatStringEsquerda(2, '0') + //Mes Emissao
                    rCfgMDFe.rEmp.rClifor.Nr_cgc.SoNumero() + //CNPJ do Emitente
                    val.Cd_modelo.Trim() + //Modelo
                    val.Nr_serie.Trim().FormatStringEsquerda(3, '0') + //Serie
                    val.Nr_mdfe.Value.FormatStringEsquerda(9, '0') + //Nº MDFe
                    "1" + //Tipo Emissao
                    val.Id_mdfe.Value.FormatStringEsquerda(8, '0'); //Codigo Interno MDFe
        }

        public static string CalcularDigitoChave(string vChave)
        {
            return Estruturas.Mod11(System.Text.RegularExpressions.Regex.Replace(vChave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
        }

        public static void GerarArquivoXml(List<TRegistro_MDFe> lMDFe,
                                           TRegistro_CfgMDFe rCfgMDFe)
        {
            lMDFe.ForEach(p =>
                {
                    //Buscar Veiculo
                    p.lVeic = CamadaNegocio.Frota.TCN_MDFe_Veiculo.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    //Buscar Motorista
                    p.lMot = CamadaNegocio.Frota.TCN_MDFe_Motorista.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    //Mun. Carga
                    p.lMunCar = CamadaNegocio.Frota.TCN_MDFe_MunCarrega.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    //UF Percurso
                    p.lUfPerc = CamadaNegocio.Frota.TCN_MDFe_UfPercurso.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    //Documentos
                    p.lDoc = CamadaNegocio.Frota.TCN_MDFe_Documentos.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    //Buscar Seguros
                    p.lSeguro = CamadaNegocio.Frota.TCN_MDFe_Seguro.Buscar(p.Cd_empresa, p.Id_mdfestr, null);
                    string xmlassinado = string.Empty;
                    StringBuilder xml = new StringBuilder();
                    #region MDFe
                    xml.Append("<MDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\">");
                    #region infMDFe
                    xml.Append("<infMDFe Id=\"MDFe" + MontarChaveAcessoMDFe(p, rCfgMDFe) + CalcularDigitoChave(MontarChaveAcessoMDFe(p, rCfgMDFe)) + "\" versao=\"" + rCfgMDFe.Cd_versaomdfe.Trim() + "\">");
                    #region ide
                    xml.Append("<ide>");
                    #region cUF
                    xml.Append("<cUF>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Cd_uf.Trim());
                    xml.Append("</cUF>");
                    #endregion
                    #region tpAmb
                    xml.Append("<tpAmb>");
                    xml.Append(rCfgMDFe.Tp_ambiente.Trim());
                    xml.Append("</tpAmb>");
                    #endregion
                    #region tpEmit
                    xml.Append("<tpEmit>");
                    xml.Append(p.Tp_emitente.Trim());
                    xml.Append("</tpEmit>");
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
                    #region nMDF
                    xml.Append("<nMDF>");
                    xml.Append(p.Nr_mdfe.Value.ToString());
                    xml.Append("</nMDF>");
                    #endregion
                    #region cMDF
                    xml.Append("<cMDF>");
                    xml.Append(p.Id_mdfe.Value.ToString().FormatStringEsquerda(8, '0'));
                    xml.Append("</cMDF>");
                    #endregion
                    #region cDV 
                    xml.Append("<cDV>");
                    xml.Append(CalcularDigitoChave(MontarChaveAcessoMDFe(p, rCfgMDFe)));
                    xml.Append("</cDV>");
                    #endregion
                    #region modal
                    xml.Append("<modal>");
                    xml.Append(p.Tp_modalidade.Trim());
                    xml.Append("</modal>");
                    #endregion
                    #region dhEmi
                    xml.Append("<dhEmi>");
                    xml.Append(p.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    xml.Append("</dhEmi>");
                    #endregion
                    #region tpEmis
                    xml.Append("<tpEmis>");
                    xml.Append("1");
                    xml.Append("</tpEmis>");
                    #endregion
                    #region procEmi
                    xml.Append("<procEmi>");
                    xml.Append("0");
                    xml.Append("</procEmi>");
                    #endregion
                    #region verProc
                    xml.Append("<verProc>");
                    xml.Append("1.00");
                    xml.Append("</verProc>");
                    #endregion
                    #region UFIni
                    xml.Append("<UFIni>");
                    xml.Append(p.Sg_ufcarrega.Trim());
                    xml.Append("</UFIni>");
                    #endregion
                    #region UFFim
                    xml.Append("<UFFim>");
                    xml.Append(p.Sg_ufdescarrega.Trim());
                    xml.Append("</UFFim>");
                    #endregion
                    p.lMunCar.ForEach(v =>
                    {
                        #region infMunCarrega
                        xml.Append("<infMunCarrega>");
                        #region cMunCarrega
                        xml.Append("<cMunCarrega>");
                        xml.Append(v.Cd_cidade.Trim());
                        xml.Append("</cMunCarrega>");
                        #endregion
                        #region xMunCarrega
                        xml.Append("<xMunCarrega>");
                        xml.Append(v.Ds_cidade.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xMunCarrega>");
                        #endregion
                        xml.Append("</infMunCarrega>");
                        #endregion
                    });
                    #region infPercurso
                    p.lUfPerc.ForEach(v =>
                        {
                            xml.Append("<infPercurso>");
                            #region UFPer
                            xml.Append("<UFPer>");
                            xml.Append(v.Sg_uf.Trim());
                            xml.Append("</UFPer>");
                            #endregion
                            xml.Append("</infPercurso>");
                        });
                    #endregion
                    #region dhIniViagem
                    if (p.Dt_iniviagem.HasValue)
                    {
                        xml.Append("<dhIniViagem>");
                        xml.Append(p.Dt_iniviagem.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                        xml.Append("</dhIniViagem>");
                    }
                    #endregion
                    xml.Append("</ide>");
                    #endregion
                    #region emit
                    xml.Append("<emit>");
                    #region CNPJ
                    xml.Append("<CNPJ>");
                    xml.Append(rCfgMDFe.rEmp.rClifor.Nr_cgc.SoNumero());
                    xml.Append("</CNPJ>");
                    #endregion
                    #region IE
                    xml.Append("<IE>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Insc_estadual.SoNumero());
                    xml.Append("</IE>");
                    #endregion
                    #region xNome
                    xml.Append("<xNome>");
                    xml.Append(rCfgMDFe.rEmp.rClifor.Nm_clifor.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</xNome>");
                    #endregion
                    #region xFant
                    xml.Append("<xFant>");
                    xml.Append(rCfgMDFe.rEmp.rClifor.Nm_fantasia.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</xFant>");
                    #endregion
                    #region enderEmit
                    xml.Append("<enderEmit>");
                    #region xLgr
                    xml.Append("<xLgr>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Ds_endereco.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</xLgr>");
                    #endregion
                    #region nro
                    xml.Append("<nro>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Numero.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</nro>");
                    #endregion
                    #region xCpl
                    if (!string.IsNullOrEmpty(rCfgMDFe.rEmp.rEndereco.Ds_complemento))
                    {
                        xml.Append("<xCpl>");
                        xml.Append(rCfgMDFe.rEmp.rEndereco.Ds_complemento.RemoverCaracteres().SubstCaracteresEsp().Trim());
                        xml.Append("</xCpl>");
                    }
                    #endregion
                    #region xBairro
                    xml.Append("<xBairro>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Bairro.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</xBairro>");
                    #endregion
                    #region cMun
                    xml.Append("<cMun>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.Cd_cidade.Trim());
                    xml.Append("</cMun>");
                    #endregion
                    #region xMun
                    xml.Append("<xMun>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.DS_Cidade.RemoverCaracteres().SubstCaracteresEsp());
                    xml.Append("</xMun>");
                    #endregion
                    #region CEP
                    if (!string.IsNullOrEmpty(rCfgMDFe.rEmp.rEndereco.Cep.SoNumero()))
                    {
                        xml.Append("<CEP>");
                        xml.Append(rCfgMDFe.rEmp.rEndereco.Cep.SoNumero());
                        xml.Append("</CEP>");
                    }
                    #endregion
                    #region UF
                    xml.Append("<UF>");
                    xml.Append(rCfgMDFe.rEmp.rEndereco.UF.Trim());
                    xml.Append("</UF>");
                    #endregion
                    #region fone
                    if (!string.IsNullOrEmpty(rCfgMDFe.rEmp.rEndereco.Fone.SoNumero()))
                    {
                        xml.Append("<fone>");
                        xml.Append(rCfgMDFe.rEmp.rEndereco.Fone.SoNumero());
                        xml.Append("</fone>");
                    }
                    #endregion
                    #region email
                    if (!string.IsNullOrEmpty(rCfgMDFe.rEmp.rClifor.Email))
                    {
                        xml.Append("<email>");
                        xml.Append(rCfgMDFe.rEmp.rClifor.Email.SubstCaracteresEsp().Trim());
                        xml.Append("</email>");
                    }
                    #endregion
                    xml.Append("</enderEmit>");
                    #endregion
                    xml.Append("</emit>");
                    #endregion
                    #region infModal
                    xml.Append("<infModal versaoModal=\"" + rCfgMDFe.Cd_versaomodal.Trim() + "\">");
                    #region rodo
                    xml.Append("<rodo>");
                    if (p.Tp_emitente.Trim().Equals("1"))
                    {
                        object obj_rntrc = new TCD_CfgFrota().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                }
                                            }, "a.rntrc");
                        if(obj_rntrc != null)
                        {
                            xml.Append("<infANTT>");
                            xml.Append("<RNTRC>");
                            xml.Append(obj_rntrc.ToString());
                            xml.Append("</RNTRC>");
                            p.lDoc.ForEach(x =>
                            {
                                xml.Append("<infContratante>");
                                xml.Append("<CNPJ>");
                                xml.Append(x.Cnpj_contratante.SoNumero());
                                xml.Append("</CNPJ>");
                                xml.Append("</infContratante>");
                            });
                            xml.Append("</infANTT>");
                        }
                    }
                    #region veicTracao
                    if (!p.lVeic.Exists(v => v.rVeic.Tp_veiculo.Trim().ToUpper().Equals("T")))
                        throw new Exception("Obrigatório informar veiculo TRAÇÃO para emitir MDF-e RODOVIARIO.");
                    TRegistro_CadVeiculo rVeicT = p.lVeic.Find(v => v.rVeic.Tp_veiculo.Trim().ToUpper().Equals("T")).rVeic;
                    xml.Append("<veicTracao>");
                    #region cInt
                    xml.Append("<cInt>");
                    xml.Append(rVeicT.Id_veiculostr);
                    xml.Append("</cInt>");
                    #endregion
                    #region placa
                    if (rVeicT.placa.Replace("-", string.Empty).Length != 7)
                        throw new Exception("Placa invalida: " + rVeicT.placa.Replace("-", string.Empty) + "\r\nPlaca deve possuir 7 caracteres.");
                    xml.Append("<placa>");
                    xml.Append(rVeicT.placa.Replace("-", string.Empty));
                    xml.Append("</placa>");
                    #endregion
                    #region RENAVAM
                    if (!string.IsNullOrEmpty(rVeicT.renavan))
                    {
                    if (rVeicT.renavan.Length < 9 ||
                    rVeicT.renavan.Length > 11)
                        throw new Exception("Renavan invalido: " + rVeicT.renavan + "\r\nRenavan deve possuir entre nove e onze caracteres.");
                        xml.Append("<RENAVAM>");
                        xml.Append(rVeicT.renavan);
                        xml.Append("</RENAVAM>");
                    }
                    #endregion
                    #region tara
                    if (rVeicT.Ps_tara_kg.Equals(decimal.Zero))
                        throw new Exception("Obrigatório informar peso tara do veiculo.");
                    xml.Append("<tara>");
                    xml.Append(rVeicT.Ps_tara_kg.ToString());
                    xml.Append("</tara>");
                    #endregion
                    #region capKG
                    if (rVeicT.Capacidade_kg > decimal.Zero)
                    {
                        xml.Append("<capKG>");
                        xml.Append(rVeicT.Capacidade_kg.ToString());
                        xml.Append("</capKG>");
                    }
                    #endregion
                    #region capM3
                    if (rVeicT.Capacidade_m3 > decimal.Zero)
                    {
                        xml.Append("<capM3>");
                        xml.Append(rVeicT.Capacidade_m3.ToString());
                        xml.Append("</capM3>");
                    }
                    #endregion
                    #region prop
                    if (!string.IsNullOrEmpty(rVeicT.Cd_proprietario))
                    {
                        xml.Append("<prop>");
                        #region CPF
                        if (rVeicT.Cnpj_cpf_prop.SoNumero().Length.Equals(11))
                        {
                            xml.Append("<CPF>");
                            xml.Append(rVeicT.Cnpj_cpf_prop.SoNumero());
                            xml.Append("</CPF>");
                        }
                        #endregion
                        #region CNPJ
                        if (rVeicT.Cnpj_cpf_prop.SoNumero().Length.Equals(14))
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(rVeicT.Cnpj_cpf_prop.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion
                        #region RNTRC
                        xml.Append("<RNTRC>");
                        xml.Append(rVeicT.Rntrc_prop.Trim());
                        xml.Append("</RNTRC>");
                        #endregion
                        #region xNome
                        xml.Append("<xNome>");
                        xml.Append(rVeicT.Nm_proprietario.RemoverCaracteres().SubstCaracteresEsp());
                        xml.Append("</xNome>");
                        #endregion
                        #region IE
                        if (!string.IsNullOrEmpty(rVeicT.Insc_estadual_prop))
                        {
                            xml.Append("<IE>");
                            xml.Append(rVeicT.Insc_estadual_prop.RemoverCaracteres().SubstCaracteresEsp());
                            xml.Append("</IE>");
                        }
                        #endregion
                        #region UF
                        xml.Append("<UF>");
                        xml.Append(rVeicT.Uf_proprietario.Trim());
                        xml.Append("</UF>");
                        #endregion
                        #region tpProp
                        xml.Append("<tpProp>");
                        xml.Append(rVeicT.Tp_proprietario.Trim());
                        xml.Append("</tpProp>");
                        #endregion
                        xml.Append("</prop>");
                    }
                    #endregion
                    #region condutor
                    p.lMot.ForEach(v =>
                        {
                            xml.Append("<condutor>");
                            #region xNome
                            xml.Append("<xNome>");
                            xml.Append(v.Nm_motorista.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xNome>");
                            #endregion
                            #region CPF
                            xml.Append("<CPF>");
                            xml.Append(v.Cpf_motorista.SoNumero());
                            xml.Append("</CPF>");
                            #endregion
                            xml.Append("</condutor>");
                        });
                    #endregion
                    #region tpRod
                    xml.Append("<tpRod>");
                    xml.Append(rVeicT.Tp_rodado.Trim());
                    xml.Append("</tpRod>");
                    #endregion
                    #region tpCar
                    xml.Append("<tpCar>");
                    xml.Append(rVeicT.Tp_carroceria.Trim());
                    xml.Append("</tpCar>");
                    #endregion
                    #region UF
                    xml.Append("<UF>");
                    xml.Append(rVeicT.Uf_veiculo.Trim());
                    xml.Append("</UF>");
                    #endregion
                    xml.Append("</veicTracao>");
                    #endregion
                    #region veicReboque
                    p.lVeic.FindAll(v => v.rVeic.Tp_veiculo.Trim().ToUpper() != "T").ForEach(v =>
                    {
                        xml.Append("<veicReboque>");
                        #region cInt
                        xml.Append("<cInt>");
                        xml.Append(v.Id_veiculostr);
                        xml.Append("</cInt>");
                        #endregion
                        #region placa
                        if (v.Placa.Replace("-", string.Empty).Length != 7)
                            throw new Exception("Placa invalida: " + v.Placa.Replace("-", string.Empty) + "\r\nPlaca deve possuir 7 caracteres.");
                        xml.Append("<placa>");
                        xml.Append(v.Placa.Replace("-", string.Empty));
                        xml.Append("</placa>");
                        #endregion
                        #region RENAVAM
                        if (!string.IsNullOrEmpty(v.rVeic.renavan))
                        {
                            if (v.rVeic.renavan.Length < 9 ||
                                v.rVeic.renavan.Length > 11)
                                throw new Exception("Renavan invalido: " + v.rVeic.renavan + "\r\nRenavan deve possuir entre nove e onze caracteres.");
                            xml.Append("<RENAVAM>");
                            xml.Append(v.rVeic.renavan);
                            xml.Append("</RENAVAM>");
                        }
                        #endregion
                        #region tara
                        if (v.rVeic.Ps_tara_kg.Equals(decimal.Zero))
                            throw new Exception("Obrigatório informar peso tara do veiculo.");
                        xml.Append("<tara>");
                        xml.Append(v.rVeic.Ps_tara_kg.ToString());
                        xml.Append("</tara>");
                        #endregion
                        #region capKG
                        xml.Append("<capKG>");
                        xml.Append(v.rVeic.Capacidade_kg.ToString());
                        xml.Append("</capKG>");
                        #endregion
                        #region capM3
                        if (v.rVeic.Capacidade_m3 > decimal.Zero)
                        {
                            xml.Append("<capM3>");
                            xml.Append(v.rVeic.Capacidade_m3.ToString());
                            xml.Append("</capM3>");
                        }
                        #endregion
                        #region prop
                        if (!string.IsNullOrEmpty(v.rVeic.Cd_proprietario))
                        {
                            xml.Append("<prop>");
                            #region CPF
                            if (v.rVeic.Cnpj_cpf_prop.SoNumero().Length.Equals(11))
                            {
                                xml.Append("<CPF>");
                                xml.Append(v.rVeic.Cnpj_cpf_prop.SoNumero());
                                xml.Append("</CPF>");
                            }
                            #endregion
                            #region CNPJ
                            if (v.rVeic.Cnpj_cpf_prop.SoNumero().Length.Equals(14))
                            {
                                xml.Append("<CNPJ>");
                                xml.Append(v.rVeic.Cnpj_cpf_prop.SoNumero());
                                xml.Append("</CNPJ>");
                            }
                            #endregion
                            #region RNTRC
                            xml.Append("<RNTRC>");
                            xml.Append(v.rVeic.Rntrc_prop.Trim());
                            xml.Append("</RNTRC>");
                            #endregion
                            #region xNome
                            xml.Append("<xNome>");
                            xml.Append(v.rVeic.Nm_proprietario.RemoverCaracteres().SubstCaracteresEsp());
                            xml.Append("</xNome>");
                            #endregion
                            #region IE
                            if (!string.IsNullOrEmpty(v.rVeic.Insc_estadual_prop))
                            {
                                xml.Append("<IE>");
                                xml.Append(v.rVeic.Insc_estadual_prop.RemoverCaracteres().SubstCaracteresEsp());
                                xml.Append("</IE>");
                            }
                            #endregion
                            #region UF
                            xml.Append("<UF>");
                            xml.Append(v.rVeic.Uf_proprietario.Trim());
                            xml.Append("</UF>");
                            #endregion
                            #region tpProp
                            xml.Append("<tpProp>");
                            xml.Append(v.rVeic.Tp_proprietario.Trim());
                            xml.Append("</tpProp>");
                            #endregion
                            xml.Append("</prop>");
                        }
                        #endregion
                        #region tpCar
                        xml.Append("<tpCar>");
                        xml.Append(v.rVeic.Tp_carroceria.Trim());
                        xml.Append("</tpCar>");
                        #endregion
                        #region UF
                        xml.Append("<UF>");
                        xml.Append(v.rVeic.Uf_veiculo.Trim());
                        xml.Append("</UF>");
                        #endregion
                        xml.Append("</veicReboque>");
                    });
                    #endregion
                    xml.Append("</rodo>");
                    #endregion
                    xml.Append("</infModal>");
                    #endregion
                    #region infDoc
                    xml.Append("<infDoc>");
                    #region infMunDescarga
                    
                    if (p.lDoc.Exists(v => !string.IsNullOrEmpty(v.ChaveCTe)))
                    {
                        string aux = string.Empty;
                        p.lDoc.FindAll(v => !string.IsNullOrEmpty(v.ChaveCTe)).OrderBy(v=> v.Cd_cidadeCTe).ToList().ForEach(v=>
                            {
                                if (aux.Trim() != v.Cd_cidadeCTe.Trim())
                                {
                                    xml.Append("<infMunDescarga>");
                                    #region cMunDescarga
                                    xml.Append("<cMunDescarga>");
                                    xml.Append(v.Cd_cidadeCTe.Trim());
                                    xml.Append("</cMunDescarga>");
                                    #endregion
                                    #region xMunDescarga
                                    xml.Append("<xMunDescarga>");
                                    xml.Append(v.Ds_cidadeCTe.RemoverCaracteres().SubstCaracteresEsp());
                                    xml.Append("</xMunDescarga>");
                                    #endregion
                                    #region infCTe
                                    p.lDoc.FindAll(x => !string.IsNullOrEmpty(x.ChaveCTe) && x.Cd_cidadeCTe.Trim().Equals(v.Cd_cidadeCTe)).ForEach(x =>
                                        {
                                            xml.Append("<infCTe>");
                                            #region chCTe
                                            xml.Append("<chCTe>");
                                            xml.Append(x.ChaveCTe.Trim());
                                            xml.Append("</chCTe>");
                                            #endregion
                                            xml.Append("</infCTe>");
                                        });
                                    #endregion
                                    xml.Append("</infMunDescarga>");
                                }
                                aux = v.Cd_cidadeCTe;
                            });
                    }
                    if (p.lDoc.Exists(v => !string.IsNullOrEmpty(v.ChaveNFe)))
                    {
                        string aux = string.Empty;
                        p.lDoc.FindAll(v => !string.IsNullOrEmpty(v.ChaveNFe)).OrderBy(v => v.Cd_cidadeNFe).ToList().ForEach(v =>
                            {
                                if (aux.Trim() != v.Cd_cidadeNFe.Trim())
                                {
                                    xml.Append("<infMunDescarga>");
                                    #region cMunDescarga
                                    xml.Append("<cMunDescarga>");
                                    xml.Append(v.Cd_cidadeNFe.Trim());
                                    xml.Append("</cMunDescarga>");
                                    #endregion
                                    #region xMunDescarga
                                    xml.Append("<xMunDescarga>");
                                    xml.Append(v.Ds_cidadeNFe.RemoverCaracteres().SubstCaracteresEsp());
                                    xml.Append("</xMunDescarga>");
                                    #endregion
                                    p.lDoc.FindAll(x => !string.IsNullOrEmpty(x.ChaveNFe) && x.Cd_cidadeNFe.Trim().Equals(v.Cd_cidadeNFe)).ForEach(x =>
                                        {
                                            #region infNFe
                                            xml.Append("<infNFe>");
                                            #region chNFe
                                            xml.Append("<chNFe>");
                                            xml.Append(x.ChaveNFe.Trim());
                                            xml.Append("</chNFe>");
                                            #endregion
                                            xml.Append("</infNFe>");
                                            #endregion
                                        });
                                    xml.Append("</infMunDescarga>");
                                }
                                aux = v.Cd_cidadeNFe;
                            });
                    }
                    
                    #endregion
                    xml.Append("</infDoc>");
                    #endregion
                    p.lSeguro.ForEach(x =>
                    {
                        #region seg
                        xml.Append("<seg>");
                        #region infResp
                        xml.Append("<infResp>");
                        #region respSeg
                        xml.Append("<respSeg>");
                        xml.Append(x.Tp_responsavel); //1-Emitente do MDF-e 2-Contratante do servico
                        xml.Append("</respSeg>");
                        if (x.Tp_responsavel.Trim().Equals("2"))
                        {
                            if (string.IsNullOrWhiteSpace(x.CnpjCpf_responsavel.SoNumero()))
                                throw new Exception("Obrigatório informar CNPJ/CPF do responsavel pelo seguro quando for por conta do Contratante.");
                            if (x.CnpjCpf_responsavel.SoNumero().Length.Equals(11))
                            {
                                xml.Append("<CPF>");
                                xml.Append(x.CnpjCpf_responsavel.SoNumero());
                                xml.Append("</CPF>");
                            }
                            else
                            {
                                xml.Append("<CNPJ>");
                                xml.Append(x.CnpjCpf_responsavel.SoNumero());
                                xml.Append("</CNPJ>");
                            }
                        }
                        else
                        {
                            xml.Append("<CNPJ>");
                            xml.Append(rCfgMDFe.rEmp.rClifor.Nr_cgc.SoNumero());
                            xml.Append("</CNPJ>");
                        }
                        #endregion
                        xml.Append("</infResp>");
                        #endregion
                        if (!string.IsNullOrWhiteSpace(x.Cd_seguradora))
                        {
                            #region infSeg
                            xml.Append("<infSeg>");
                            #region xSeg
                            xml.Append("<xSeg>");
                            xml.Append(x.Nm_seguradora.RemoverCaracteres().SubstCaracteresEsp().Trim());
                            xml.Append("</xSeg>");
                            #endregion
                            #region CNPJ
                            xml.Append("<CNPJ>");
                            xml.Append(x.Cnpj_seguradora.SoNumero());
                            xml.Append("</CNPJ>");
                            #endregion
                            xml.Append("</infSeg>");
                            #endregion
                        }
                        #region nApol
                        xml.Append("<nApol>");
                        xml.Append(x.Nr_apolice.Trim());
                        xml.Append("</nApol>");
                        #endregion
                        #region nAver
                        if (!string.IsNullOrWhiteSpace(x.Nr_averbacao))
                        {
                            xml.Append("<nAver>");
                            xml.Append(x.Nr_averbacao.Trim());
                            xml.Append("</nAver>");
                        }
                        #endregion
                        xml.Append("</seg>");
                        #endregion
                    });
                    #region tot
                    xml.Append("<tot>");
                    #region qCTe
                    if (p.lDoc.Count(v => !string.IsNullOrEmpty(v.ChaveCTe)) > 0)
                    {
                        xml.Append("<qCTe>");
                        xml.Append(p.lDoc.Count(v => !string.IsNullOrEmpty(v.ChaveCTe)).ToString());
                        xml.Append("</qCTe>");
                    }
                    #endregion
                    #region qNFe
                    if (p.lDoc.Count(v => !string.IsNullOrEmpty(v.ChaveNFe)) > 0)
                    {
                        xml.Append("<qNFe>");
                        xml.Append(p.lDoc.Count(v => !string.IsNullOrEmpty(v.ChaveNFe)).ToString());
                        xml.Append("</qNFe>");
                    }
                    #endregion
                    #region vCarga
                    xml.Append("<vCarga>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.lDoc.Sum(v => v.Vl_CargaCTe + v.Vl_NFe))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCarga>");
                    #endregion
                    #region cUnid
                    xml.Append("<cUnid>");
                    xml.Append("01");//KG
                    xml.Append("</cUnid>");
                    #endregion
                    #region qCarga
                    xml.Append("<qCarga>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N4}", p.lDoc.Sum(v => v.PesoBrutoNFe))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</qCarga>");
                    #endregion
                    xml.Append("</tot>");
                    #endregion
                    #region Autorização para obter XML
                    if (!string.IsNullOrWhiteSpace(rCfgMDFe.Cnpj_contador.SoNumero()))
                    {
                        #region autXML 
                        xml.Append("<autXML>\n");
                        #region CNPJ 
                        xml.Append("<CNPJ>");
                        xml.Append(rCfgMDFe.Cnpj_contador.SoNumero());
                        xml.Append("</CNPJ>\n");
                        #endregion
                        xml.Append("</autXML>\n");
                        #endregion
                    }
                    #endregion
                    #region infAdic
                    if (!string.IsNullOrEmpty(p.infAdFisco) ||
                        !string.IsNullOrEmpty(p.infCpl))
                    {
                        xml.Append("<infAdic>");
                        #region infAdFisco
                        if (!string.IsNullOrEmpty(p.infAdFisco))
                        {
                            xml.Append("<infAdFisco>");
                            xml.Append(p.infAdFisco.Trim());
                            xml.Append("</infAdFisco>");
                        }
                        #endregion
                        #region infCpl
                        if (!string.IsNullOrEmpty(p.infCpl))
                        {
                            xml.Append("<infCpl>");
                            xml.Append(p.infCpl.Trim());
                            xml.Append("</infCpl>");
                        }
                        #endregion
                        xml.Append("</infAdic>");
                    }
                    #endregion
                    xml.Append("</infMDFe>");
                    #endregion
                    xml.Append("</MDFe>");
                    #endregion
                    //Assinar XML
                    xmlassinado = new Utils.Assinatura.TAssinatura2(rCfgMDFe.Nr_certificado,
                                                                    Utils.Assinatura.TAssinatura2.TTpArq.tpMDFe,
                                                                    xml.ToString()).Assinar();
                    //Validar Schema XML
                    Utils.ValidaSchema.ValidaXML2.validaXML(xmlassinado,
                                                            rCfgMDFe.Path_schemas.SeparadorDiretorio() + "mdfe_v" + rCfgMDFe.Cd_versaomdfe.Trim() + ".xsd",
                                                            "MDFE");
                    if (!string.IsNullOrEmpty(Utils.ValidaSchema.ValidaXML2.Retorno))
                        throw new Exception(Utils.ValidaSchema.ValidaXML2.Retorno.Trim());
                    p.Xml_mdfe = xmlassinado;
                    //Gravar codigo acesso da nfe e alterar status para nfe gerada na tabela nota fiscal
                    try
                    {
                        System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
                        hs.Add("@P_CHAVE", MontarChaveAcessoMDFe(p, rCfgMDFe) + CalcularDigitoChave(MontarChaveAcessoMDFe(p, rCfgMDFe)));
                        hs.Add("@P_XML", xmlassinado);
                        hs.Add("@P_CD_EMPRESA", p.Cd_empresa);
                        hs.Add("@P_ID_MDFE", p.Id_mdfe);
                        new CamadaDados.TDataQuery().executarSql("update tb_ctr_mdfe set chaveacesso = @P_CHAVE, xml_mdfe = @P_XML, dt_alt = getdate() " +
                                                                 "where cd_empresa = @P_CD_EMPRESA and ID_MDFe = @P_ID_MDFE", hs);
                    }
                    catch
                    { }
                });
        }

        public static void GerarArquivoXmlPeriodo(string vPath_xml,
                                                  TList_MDFe lMDFe,
                                                  TRegistro_CfgMDFe rCfg)
        {
            try
            {
                string retorno = string.Empty;
                //Path XML
                if (vPath_xml.Trim().Substring(vPath_xml.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    vPath_xml += System.IO.Path.DirectorySeparatorChar.ToString();
                lMDFe.ForEach(p =>
                {
                    StringBuilder xml = new StringBuilder();
                    xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    xml.Append("<mdfeProc xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfg.Cd_versaomdfe.Trim() + "\">");
                    xml.Append(p.Xml_mdfe.Replace(" xmlns=\"http://www.portalfiscal.inf.br/mdfe\"", string.Empty));
                    xml.Append(p.Xml_lote.Replace(" xmlns=\"http://www.portalfiscal.inf.br/mdfe\"", string.Empty));
                    xml.Append("</mdfeProc>");
                    //Salvar arquivo no Path indicado 
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() + p.Chaveacesso.Trim() + "-procMDFe.xml"))
                    {
                        sw.Write(xml.ToString());
                        sw.Flush();
                        sw.Close();
                    }
                    //Buscar Eventos MDFe
                    CamadaNegocio.Frota.TCN_MDFe_Evento.Buscar(p.Cd_empresa,
                                                               p.Id_mdfestr,
                                                               string.Empty,
                                                               "T",
                                                               null).ForEach(v =>
                                                                   {
                                                                       xml = new StringBuilder();
                                                                       xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                                                       xml.Append("<procEventoMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"" + rCfg.Cd_versaomdfe.Trim() + "\">");
                                                                       xml.Append(v.Xml_evento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty).Replace(" xmlns=\"http://www.portalfiscal.inf.br/mdfe\"", string.Empty));
                                                                       xml.Append(v.Xml_retevent.Replace(" xmlns=\"http://www.portalfiscal.inf.br/mdfe\"", string.Empty));
                                                                       xml.Append("</procEventoMDFe>");
                                                                       //Salvar arquivo no Path indicado 
                                                                       using (System.IO.StreamWriter sw = new System.IO.StreamWriter(vPath_xml.Trim() +
                                                                                                                                     v.Cd_eventostr.Trim() + "-" +
                                                                                                                                     p.Chaveacesso.Trim() + "-procEventoMDFe.xml"))
                                                                       {
                                                                           sw.Write(xml.ToString());
                                                                           sw.Flush();
                                                                           sw.Close();
                                                                       }
                                                                   });
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.Trim());
            }
        }
    }
}
