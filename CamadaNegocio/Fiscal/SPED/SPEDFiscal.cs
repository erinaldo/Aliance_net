using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaNegocio.Diversos;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using SPED.CamadaDados;

namespace SPED.ProcessarSPED
{
    public class SPEDFiscal
    {
        public DateTime DTInicio { get; set; } 
        public DateTime DTFinal  { get; set; } 
        public string CD_Empresa { get; set; }
        public string CD_Finalidade { get; set; }
        public string IND_Perfil { get; set; }
        public string IND_Atividade { get; set; }
        public TList_CadEmpresa Reg_Empresa;
        private int QTDLinhas = 0;
        private int QTDLinhasBlocoC = 0;

        public bool ProcessaSPEDFiscal()
        {
            try
            {
                List<string[]> LinhasSPED = new List<string[]>();
                //CRIA O BLOCO 0
                GeradorSPED gerarSPED = new GeradorSPED();
                Reg_Empresa = TCN_CadEmpresa.Busca(this.CD_Empresa, "", "", null);

                //GERA A LINHA DO BLOCO 0
                LinhasSPED.Add(GerarRegistro0000());
                //ABERTURA DO BLOCO 0
                LinhasSPED.Add(GerarRegistro0001());
                //DADOS COMPLEMENTARES DA ENTIDADE
                LinhasSPED.Add(GerarRegistro0005());
                //DADOS CONTABILISTA
                LinhasSPED.Add(GerarRegistro0100());
                //PARTICIPANTES
                AddListLinhas(ref LinhasSPED, GerarRegistro0150());
                //UNIDADES
                AddListLinhas(ref LinhasSPED, GerarRegistro0190());
                //ITEMS
                AddListLinhas(ref LinhasSPED, GerarRegistro0200());
                //FATORES DE CONVERSÃO DE UNIDADES DE MEDIDA
                AddListLinhas(ref LinhasSPED, GerarRegistro0220());
                //NATUREZA DA OPERACAO
                AddListLinhas(ref LinhasSPED, GerarRegistro0400());
                //TABELA DE INFORMAÇÃO COMPLEMENTAR DO DOCUMENTO FISCAL
                AddListLinhas(ref LinhasSPED, GerarRegistro0450());
                //OBS FISCAL
                AddListLinhas(ref LinhasSPED, GerarRegistro0460());
                //FIM BLOCO 0
                LinhasSPED.Add(GerarRegistro0990());
                //GERA INICIO DO BLOCO C
                LinhasSPED.Add(GerarRegistroC001());
                //NOTASFISCAIS
                AddListLinhas(ref LinhasSPED, GerarRegistroC100());
                //OUTROS IMPOSTOS
                AddListLinhas(ref LinhasSPED, GerarRegistroC130());
                //FATURA / DUPLICATA ? PARCELAS
                AddListLinhas(ref LinhasSPED, GerarRegistroC140());
                //VOLUMES TRANSP
                AddListLinhas(ref LinhasSPED, GerarRegistroC160());

                //ESCREVE NO ARQUIVO AS LINHAS DO ARQUIVO
                gerarSPED.GerarArquivo("C:/Documents and Settings/emanoel/Desktop/Teste.txt", LinhasSPED);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return true;
        }

        public void AddListLinhas(ref List<string[]> LinhasSPED, List<string[]> ListDados)
        {
            foreach (string[] linha in ListDados)
            {
                LinhasSPED.Add(linha);
            }
        }

        #region "BLOCO 0"

            private string[] GerarRegistro0000()
            {
                string[] bloco0 = new string[15];

                try
                {

                    //CAMPO FIXO NUMERO DE IDENTIFICAÇÂO DO BLOCO
                    bloco0[0] = "0000";
                    //CAMPO FIXO DO CÓD DO LAYOUT
                    bloco0[1] = "002";
                    //CÓD DA FINALIDADE DO ARQUIVO
                    bloco0[2] = this.CD_Finalidade.Trim();
                    //DATA INICIAL DO PERIODO DO ARQUIVO
                    bloco0[3] = this.DTInicio.Day.ToString().PadLeft(2, '0') + this.DTInicio.Month.ToString().PadLeft(2, '0') + this.DTInicio.Year.ToString().PadLeft(4, '0');
                    //DATA FINAL DO PERIODO DO ARQUIVO
                    bloco0[4] = this.DTFinal.Day.ToString().PadLeft(2, '0') + this.DTFinal.Month.ToString().PadLeft(2, '0') + this.DTFinal.Year.ToString().PadLeft(4, '0');

                    if (Reg_Empresa.Count > 0)
                    {
                        //NM RAZÃO SOCIAL DA EMPRSA
                        if (Reg_Empresa[0].Nm_clifor.Trim().Length > 59)
                            bloco0[5] = Reg_Empresa[0].Nm_clifor.Trim().Substring(0, 59);
                        else
                            bloco0[5] = Reg_Empresa[0].Nm_clifor.Trim();
                        //CNPJ DA EMPRESA
                        if (Reg_Empresa[0].Clifor.rClifor_PJ != null)
                            bloco0[6] = Reg_Empresa[0].Clifor.rClifor_PJ.Nr_cgc.Trim().Replace(".", "").Replace("/", "").Replace("-", "").Trim();
                        else
                            bloco0[6] = "";

                        if (Reg_Empresa[0].Clifor.rClifor_PF != null)
                            bloco0[7] = Reg_Empresa[0].Clifor.rClifor_PF.Nr_cpf.Trim().Replace(".", "").Replace("-", "").Trim();
                        else
                            bloco0[7] = "";

                        //SIGLA DA UF DA EMPRESA
                        bloco0[8] = Reg_Empresa[0].Endereco.Cidade.Uf.Uf;
                        //INSC ESTADUAL DA EMPRESA
                        bloco0[9] = Reg_Empresa[0].Endereco.Insc_estadual.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
                        //CÓD DO MUNICIAL CONFORME O IBGE
                        bloco0[10] = Reg_Empresa[0].Endereco.Cidade.Cd_cidade.Substring(0, 6).Trim();
                        //INSCRIÇÂO municipal da empresa
                        bloco0[11] = Reg_Empresa[0].Insc_municipal.Trim();
                        //CÒD DA ENTIDADE NA SUFRAMA
                        bloco0[12] = "";
                        //PERFIL DO ARQUIVO FISCAL
                        bloco0[13] = this.IND_Perfil.Trim();
                        //IND DA ATIVIDADE
                        bloco0[14] = this.IND_Atividade.Trim();
                    }
                    else
                    {
                        throw new Exception("Não foi possível encontrar a empresa!");
                    }

                    QTDLinhas++;
                    return bloco0;
                }
                catch(Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private string[] GerarRegistro0001()
            {
                string[] reg0001 = new string[2];

                reg0001[0] = "0001";
                reg0001[1] = "0";

                QTDLinhas++;
                return reg0001;
            }

            private string[] GerarRegistro0005()
            {
                string[] reg0005 = new string[10];

                try
                {

                    //CAMPO FIXO NUMERO DE IDENTIFICAÇÂO DO REGISTRO
                    reg0005[0] = "0005";

                    if (Reg_Empresa.Count > 0)
                    {
                        //Nome FANTASIA
                        if (Reg_Empresa[0].Clifor.rClifor_PJ != null)
                        {
                            if (Reg_Empresa[0].Clifor.rClifor_PJ.Nm_fantasia.Trim().Length > 59)
                                reg0005[1] = Reg_Empresa[0].Clifor.rClifor_PJ.Nm_fantasia.Trim().Substring(0, 59);
                            else
                                reg0005[1] = Reg_Empresa[0].Clifor.rClifor_PJ.Nm_fantasia.Trim();
                        }
                        else
                        {
                            if (Reg_Empresa[0].Clifor.rClifor_PJ.Nm_razaosocial.Trim().Length > 59)
                                reg0005[1] = Reg_Empresa[0].Clifor.rClifor_PJ.Nm_razaosocial.Trim().Substring(0, 59);
                            else
                                reg0005[1] = Reg_Empresa[0].Clifor.rClifor_PJ.Nm_razaosocial.Trim();
                        }

                        //CEP
                        reg0005[2] = Reg_Empresa[0].Endereco.Cep.Replace("-","").Replace(".","").Trim();
                        //ENDERECO
                        if (Reg_Empresa[0].Endereco.Ds_endereco.Trim().Length > 59)
                            reg0005[3] = Reg_Empresa[0].Endereco.Ds_endereco.Trim().Substring(0, 59);
                        else
                            reg0005[3] = Reg_Empresa[0].Endereco.Ds_endereco.Trim();
                        //NUMERO
                        reg0005[4] = Reg_Empresa[0].Endereco.Numero.Trim();
                        //COMPLEMENTE
                        if (Reg_Empresa[0].Endereco.Ds_complemento.Trim().Length > 59)
                            reg0005[5] = Reg_Empresa[0].Endereco.Ds_complemento.Trim().Substring(0, 59);
                        else
                            reg0005[5] = Reg_Empresa[0].Endereco.Ds_complemento.Trim();
                        //BAIRRO
                        if (Reg_Empresa[0].Endereco.Bairro.Trim().Length > 59)
                            reg0005[6] = Reg_Empresa[0].Endereco.Bairro.Trim().Substring(0, 59);
                        else
                            reg0005[6] = Reg_Empresa[0].Endereco.Bairro.Trim();
                        //TELEFONE
                        reg0005[7] = Reg_Empresa[0].Endereco.Fone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                        //FAX
                        reg0005[8] = Reg_Empresa[0].Endereco.Fax.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                        //EMAIL
                        reg0005[9] = Reg_Empresa[0].Clifor.Email.Trim();
                    }
                    else
                    {
                        throw new Exception("Não foi possível encontrar a empresa!");
                    }

                    QTDLinhas++;
                    return reg0005;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private string[] GerarRegistro0100()
            {
                string[] reg0100 = new string[14];

                try
                {
                    reg0100[0] = "0100";

                    if (Reg_Empresa[0].Cd_clifor_contador.Trim() != "")
                    {

                        TList_CadClifor Reg_CliforContador = TCN_CadClifor.Busca_Clifor(Reg_Empresa[0].Cd_clifor_contador, "", "", "", "", "", "", "", false, false, false, false, "", 0);

                        if (Reg_CliforContador.Count > 0)
                        {
                            //NOME CONTABILISTA
                            if (Reg_CliforContador[0].NM_Clifor.Trim().Length > 59)
                                reg0100[1] = Reg_CliforContador[0].NM_Clifor.Trim().Substring(0, 59);
                            else
                                reg0100[1] = Reg_CliforContador[0].NM_Clifor.Trim();
                            //CPF DO CONTADOR
                            if (Reg_CliforContador[0].rClifor_PF != null)
                                reg0100[2] = Reg_CliforContador[0].rClifor_PF.Nr_cpf.Trim().Replace(".", "").Replace("-", "");
                            else
                                reg0100[2] = "";
                            //CRC DO CONTADOR
                            reg0100[3] = Reg_Empresa[0].Crc_contador;
                            //CNPJ DO CONTADOR
                            if (Reg_CliforContador[0].rClifor_PJ != null)
                                reg0100[4] = Reg_CliforContador[0].rClifor_PJ.Nr_cgc.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
                            else
                                reg0100[4] = "";

                            Reg_CliforContador[0].lEndereco = TCN_CadEndereco.Buscar(Reg_CliforContador[0].CD_Clifor, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, null);
                            if (Reg_CliforContador[0].lEndereco.Count > 0)
                            {
                                //CEP
                                reg0100[5] = Reg_CliforContador[0].lEndereco[0].Cep.Replace("-", "").Replace(".", "").Trim();
                                //ENDERECO
                                if (Reg_CliforContador[0].lEndereco[0].Ds_endereco.Trim().Length > 59)
                                    reg0100[6] = Reg_CliforContador[0].lEndereco[0].Ds_endereco.Trim().Substring(0, 59);
                                else
                                    reg0100[6] = Reg_CliforContador[0].lEndereco[0].Ds_endereco.Trim();
                                //NUMERO
                                reg0100[7] = Reg_CliforContador[0].lEndereco[0].Numero.Trim();
                                //COMPLEMENTE
                                if (Reg_CliforContador[0].lEndereco[0].Ds_complemento.Trim().Length > 59)
                                    reg0100[8] = Reg_CliforContador[0].lEndereco[0].Ds_complemento.Trim().Substring(0, 59);
                                else
                                    reg0100[8] = Reg_CliforContador[0].lEndereco[0].Ds_complemento.Trim();
                                //BAIRRO
                                if (Reg_CliforContador[0].lEndereco[0].Bairro.Trim().Length > 59)
                                    reg0100[9] = Reg_CliforContador[0].lEndereco[0].Bairro.Trim().Substring(0, 59);
                                else
                                    reg0100[9] = Reg_CliforContador[0].lEndereco[0].Bairro.Trim();
                                //TELEFONE
                                reg0100[10] = Reg_CliforContador[0].lEndereco[0].Fone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                                //FAX
                                reg0100[11] = Reg_CliforContador[0].lEndereco[0].Fax.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                                //EMAIL
                                reg0100[12] = Reg_CliforContador[0].Email.Trim();
                                //COD MUNICIPIO
                                reg0100[13] = Reg_CliforContador[0].lEndereco[0].Cidade.Cd_cidade.Substring(0, 6).Trim();
                            }
                            else
                            {
                                throw new Exception("ERRO: Não foi possível encontrar o endereço do clifor contador!");
                            }
                        }
                        else
                        {
                            throw new Exception("ERRO: Não foi possível encontrar o clifor contador!");
                        }
                    }
                    else
                    {
                        throw new Exception("ERRO: Não existe clifor contador cadastrado!");
                    }

                    QTDLinhas++;
                    return reg0100;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0150()
            {
                List<string[]> ListReg0150 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal+ "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> UsuarioPeriodo = new TCD_SPEDFiscal().SelectParticipantes(vBusca);

                    for (int i = 0; i < UsuarioPeriodo.Count; i++)
                    {
                        string[] reg0150 = new string[13];
                        string[] regUsuario = UsuarioPeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0150[0] = "0150";

                        //CÒD PARTICIPANTE
                        reg0150[1] = regUsuario[0]; //CD_Clifor

                        //NM RAZÃO SOCIAL DO PARTICIPANTE
                        if (regUsuario[1].Trim().Length > 59)
                            reg0150[2] = regUsuario[1].Trim().Substring(0, 59); //NM_Clifor
                        else
                            reg0150[2] = regUsuario[1].Trim(); //NM_Clifor
                        
                        //CÓD DO PAÍS
                        reg0150[3] = regUsuario[2].Trim(); //CD_Pais
                        
                        //CNPJ DO PARTICIPANTE
                        reg0150[4] = regUsuario[3].Trim().Replace(".", "").Replace("/", "").Replace("-", ""); //NR_CGC

                        //CPF DO PARTICIPANTE
                        reg0150[5] = regUsuario[4].Trim().Replace(".", "").Replace("-", ""); //NR_CPF

                        //INSCRICAO ESTADUAL DO PARTICIPANTE
                        reg0150[6] = regUsuario[5].Trim().Replace(".", "").Replace("-", "").Replace("/", ""); //Insc_Estadual

                        //COD MUNICIPIO
                        reg0150[7] = regUsuario[6].Trim().Substring(0, 6); //CD_Cidade

                        //SUFRAMA
                        reg0150[8] = "         ";

                        //ENDERECO
                        if (regUsuario[7].Trim().Length > 59)
                            reg0150[9] = regUsuario[7].Trim().Substring(0, 59); //DS_Endereco
                        else
                            reg0150[9] = regUsuario[7].Trim(); //DS_Endereco
                        //NUMERO
                        reg0150[10] = regUsuario[8].Trim(); // Numero
                        //COMPLEMENTE
                        if (regUsuario[9].Trim().Length > 59)
                            reg0150[11] = regUsuario[9].Trim().Substring(0, 59); //DS_Complemento
                        else
                            reg0150[11] = regUsuario[9].Trim(); //DS_Complemento
                        //BAIRRO
                        if (regUsuario[10].Trim().Length > 59)
                            reg0150[12] = regUsuario[10].Trim().Substring(0, 59); //Bairro
                        else
                            reg0150[12] = regUsuario[10].Trim(); //Bairro

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0150.Add(reg0150);
                    }

                    return ListReg0150;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0190()
            {
                List<string[]> ListReg0190 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> UnidadePeriodo = new TCD_SPEDFiscal().SelectUnidades(vBusca);

                    for (int i = 0; i < UnidadePeriodo.Count; i++)
                    {
                        string[] reg0190 = new string[3];
                        string[] regUnidade = UnidadePeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0190[0] = "0190";

                        //CÒD UNIDADE
                        reg0190[1] = regUnidade[0].Trim(); //CD_Unidade

                        //DS UNIDADE
                        reg0190[2] = regUnidade[1].Trim(); //DS_Unidade

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0190.Add(reg0190);
                    }

                    return ListReg0190;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0200()
            {
                List<string[]> ListReg0200 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    /*List<string[]> ItensPeriodo = new TCD_SPEDFiscal().SelectUnidades(vBusca);

                    for (int i = 0; i < ItensPeriodo.Count; i++)
                    {
                        string[] reg0200 = new string[3];
                        string[] regUnidade = ItensPeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0200[0] = "0200";

                        //CÒD UNIDADE
                        reg0200[1] = regUnidade[0].Trim(); //CD_Unidade

                        //DS UNIDADE
                        reg0200[2] = regUnidade[1].Trim(); //DS_Unidade

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0200.Add(reg0200);
                    }*/

                    return ListReg0200;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0220()
            {
                List<string[]> ListReg0220 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> FatorUnidadePeriodo = new TCD_SPEDFiscal().SelectFatorConversao(vBusca);

                    for (int i = 0; i < FatorUnidadePeriodo.Count; i++)
                    {
                        string[] reg0220 = new string[3];
                        string[] regUnidade = FatorUnidadePeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0220[0] = "0220";

                        //CÒD UNIDADE
                        reg0220[1] = regUnidade[0].Trim(); //CD_Unidade

                        //VL INDICE
                        reg0220[2] = Convert.ToDecimal(regUnidade[1].Trim()).ToString("N6", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_Indice

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0220.Add(reg0220);
                    }

                    return ListReg0220;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0400()
            {
                List<string[]> ListReg0400 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> CFOPPeriodo = new TCD_SPEDFiscal().SelectFatorConversao(vBusca);

                    for (int i = 0; i < CFOPPeriodo.Count; i++)
                    {
                        string[] reg0400 = new string[3];
                        string[] regCFOP = CFOPPeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0400[0] = "0400";

                        //CÒD CFOP
                        reg0400[1] = regCFOP[0].Trim(); //CD_CFOP

                        //DS CFOP
                        reg0400[2] = regCFOP[1].Trim(); //DS_CFOP

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0400.Add(reg0400);
                    }

                    return ListReg0400;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0450()
            {
                List<string[]> ListReg0450 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectDadosAdicionais(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] reg0450 = new string[3];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0450[0] = "0450";

                        //CÒD DADOS
                        reg0450[1] = regDados[0].Trim(); //CD_Dados

                        //DADOSADICIONAIS
                        reg0450[2] = regDados[1].Trim(); //DAdosAdicionais

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0450.Add(reg0450);
                    }

                    return ListReg0450;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistro0460()
            {
                List<string[]> ListReg0460 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectOBSFiscal(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] reg0460 = new string[3];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        reg0460[0] = "0460";

                        //CÒD OBS
                        reg0460[1] = regDados[0].Trim(); //CD_Obs

                        //DS OBS
                        reg0460[2] = regDados[1].Trim(); //DS_Obs

                        //ADD A LISTA PRINCIPAL
                        QTDLinhas++;
                        ListReg0460.Add(reg0460);
                    }

                    return ListReg0460;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private string[] GerarRegistro0990()
            {
                string[] reg0990 = new string[2];

                //CÒD MASTER
                reg0990[0] = "0990";

                //NUMERO DE LINHAS
                reg0990[1] = QTDLinhas.ToString();

                QTDLinhas++;
                return reg0990;
            }

        #endregion

        #region "BLOCO C"

            private string[] GerarRegistroC001()
            {
                string[] regC001 = new string[2];

                regC001[0] = "C001";
                regC001[1] = "0";

                QTDLinhasBlocoC++;
                return regC001;
            }

            private List<string[]> GerarRegistroC100()
            {
                List<string[]> ListRegC100 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectNotaFiscal(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] regC100 = new string[29];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        regC100[0] = "C100";

                        //IND_OPER
                        regC100[1] = regDados[2].Trim(); //IND_OPER

                        //IND_EMIT
                        regC100[2] = regDados[3].Trim(); //IND_EMIT

                        //CÓD PARTICIPANTE
                        regC100[3] = regDados[4].Trim(); //CD_Clifor

                        //CD_Modelo
                        regC100[4] = regDados[5].Trim(); //CD_Modelo

                        //CÓD SITUAÇÃO DO DOCUMENTO
                        regC100[5] = regDados[6].Trim(); //CD_Sit

                        //NUmero de serie
                        regC100[6] = regDados[7].Trim(); //NR_Serie

                        //NUMERO DO DOCUMENTO
                        regC100[7] = regDados[1].Trim(); //NR_NotaFiscal

                        //Chave_Acesso_NFE
                        regC100[8] = regDados[9].Trim(); //Chave_Acesso_NFE

                        //DT_Emissao
                        regC100[9] = regDados[10].Trim(); //DT_Emissao

                        //DT_SaiEnt
                        regC100[10] = regDados[11].Trim(); //DT_SaiEnt

                        //VL_TotalNota
                        regC100[11] = Convert.ToDecimal(regDados[12].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_TotalNota

                        //Cond_PAGTO
                        regC100[12] = regDados[13].Trim(); //Cond_PAGTO

                        //VL_Desconto
                        regC100[13] = Convert.ToDecimal(regDados[14].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", "");  //VL_Desconto

                        //VL_SUBTotalProduto
                        regC100[14] = Convert.ToDecimal(regDados[15].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_SUBTotalProduto

                        //VL_ABAT_NT
                        regC100[15] = ""; //VL_ABAT_NT

                        //FretePorConta
                        regC100[16] = regDados[16].Trim(); //FretePorConta

                        //VL_Frete
                        regC100[17] = Convert.ToDecimal(regDados[17].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_Frete

                        //VL_Seguro
                        regC100[18] = Convert.ToDecimal(regDados[18].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_Seguro

                        //VL_OutrasDesp
                        regC100[19] = Convert.ToDecimal(regDados[28].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_OutrasDesp

                        //VL_TotalBaseCalc
                        regC100[20] = Convert.ToDecimal(regDados[19].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_TotalBaseCalc

                        //VL_ICMS
                        regC100[21] = Convert.ToDecimal(regDados[20].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_ICMS

                        //Vl_BaseCalcSubstTrib
                        regC100[22] = Convert.ToDecimal(regDados[21].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_BaseCalcSubstTrib

                        //VL_ICMS_SubsTrib
                        regC100[23] = Convert.ToDecimal(regDados[22].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_ICMS_SubsTrib

                        //Vl_IPI
                        regC100[24] = Convert.ToDecimal(regDados[23].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_IPI

                        //Vl_PIS
                        regC100[24] = Convert.ToDecimal(regDados[24].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_PIS

                        //Vl_Cofins
                        regC100[26] = Convert.ToDecimal(regDados[25].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_Cofins

                        //Vl_PISST
                        regC100[27] = Convert.ToDecimal(regDados[26].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_PISST

                        //Vl_CofinsST
                        regC100[28] = Convert.ToDecimal(regDados[27].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_CofinsST

                        //ADD A LISTA PRINCIPAL
                        QTDLinhasBlocoC++;
                        ListRegC100.Add(regC100);
                    }

                    return ListRegC100;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistroC130()
            {
                List<string[]> ListRegC130 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectOutrosImpostos(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] regC130 = new string[8];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        regC130[0] = "C130";

                        //VL_SERV_NT
                        regC130[1] = Convert.ToDecimal(regDados[0].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_SERV_NT

                        //VL_BaseCalcISSQN
                        regC130[2] = Convert.ToDecimal(regDados[1].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_BaseCalcISSQN

                        //CÓD Vl_ISSQN
                        regC130[3] = Convert.ToDecimal(regDados[2].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_ISSQN

                        //VL_BaseCalcIRRF
                        regC130[4] = Convert.ToDecimal(regDados[3].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_BaseCalcIRRF

                        //Vl_IRRF
                        regC130[5] = Convert.ToDecimal(regDados[4].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Vl_IRRF

                        //VL_BaseCalcINSS
                        regC130[6] = Convert.ToDecimal(regDados[5].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_BaseCalcINSS

                        //VL_INSS
                        regC130[7] = Convert.ToDecimal(regDados[6].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_INSS

                        //ADD A LISTA PRINCIPAL
                        QTDLinhasBlocoC++;
                        ListRegC130.Add(regC130);
                    }

                    return ListRegC130;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistroC140()
            {
                List<string[]> ListRegC140 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectTitulosaPrazo(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] regC140 = new string[7];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        regC140[0] = "C140";

                        //TP_Emissao
                        regC140[1] = regDados[2].Trim(); //TP_Emissao

                        //TP_Titulo
                        regC140[2] = regDados[3].Trim(); //TP_Titulo

                        //DS_Observacao
                        regC140[3] = regDados[4].Trim(); //DS_Observacao

                        //NR_Lancto
                        regC140[4] = regDados[1].Trim(); //NR_Lancto

                        //QT_Parcelas
                        regC140[5] = regDados[6].Trim(); //QT_Parcelas

                        //VL_Documento
                        regC140[6] = Convert.ToDecimal(regDados[5].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_Documento

                        //ADD A LISTA PRINCIPAL
                        QTDLinhasBlocoC++;
                        ListRegC140.Add(regC140);

                        //CARREGA AS PARCELAS DESTA DUPLICATA
                        List<string[]> Parcelas = new TCD_SPEDFiscal().SelectParcela(vBusca, regDados[1].Trim());

                        for (int x = 0; x < Parcelas.Count; x++)
                        {
                            string[] regC141 = new string[4];
                            string[] regParcela = Parcelas[x];

                            //NUMERO DO REGISTRO
                            regC141[0] = "C141";

                            //CD_Parcela
                            regC141[1] = regParcela[1].Trim(); //CD_Parcela

                            //DT_Vencto
                            regC141[2] = regParcela[2].Trim(); //DT_Vencto

                            //VL_Parcela
                            regC141[3] = Convert.ToDecimal(regParcela[3].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //VL_Parcela

                            //ADD A LISTA PRINCIPAL
                            QTDLinhasBlocoC++;
                            ListRegC140.Add(regC141);
                        }
                    }

                    return ListRegC140;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistroC160()
            {
                List<string[]> ListRegC160 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectVolumes(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] regC160 = new string[7];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        regC160[0] = "C160";

                        //CD_Clifor
                        regC160[1] = regDados[0].Trim(); //CD_Clifor

                        //PlacaVeiculo
                        regC160[2] = regDados[1].Trim().Replace(" ", "").Replace(".", ""); //PlacaVeiculo

                        //Quantidade
                        regC160[3] = Convert.ToDecimal(regDados[2].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //Quantidade

                        //PesoBruto
                        regC160[4] = Convert.ToDecimal(regDados[3].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //PesoBruto

                        //PesoLiquido
                        regC160[5] = Convert.ToDecimal(regDados[4].Trim()).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Replace(" ", "").Replace(".", ""); //PesoLiquido

                        //ADD A LISTA PRINCIPAL
                        QTDLinhasBlocoC++;
                        ListRegC160.Add(regC160);
                    }

                    return ListRegC160;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            private List<string[]> GerarRegistroC170()
            {
                List<string[]> ListRegC170 = new List<string[]>();

                TpBusca[] vBusca = new TpBusca[0];
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTInicio + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Emissao";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.DTFinal + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + this.CD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";

                try
                {
                    List<string[]> DadosPeriodo = new TCD_SPEDFiscal().SelectNotaFiscal(vBusca);

                    for (int i = 0; i < DadosPeriodo.Count; i++)
                    {
                        string[] regC170 = new string[0];
                        string[] regDados = DadosPeriodo[i];

                        //NUMERO DO REGISTRO
                        Array.Resize(ref regC170, regC170.Length + 1);
                        regC170[regC170.Length - 1] = "C170";

                        //IND_OPER
                        Array.Resize(ref regC170, regC170.Length + 1);
                        regC170[regC170.Length - 1] = regDados[2].Trim(); //IND_OPER

                        //IND_EMIT
                        Array.Resize(ref regC170, regC170.Length + 1);
                        regC170[regC170.Length - 1] = regDados[3].Trim(); //IND_EMIT

                        //CÓD PARTICIPANTE
                        Array.Resize(ref regC170, regC170.Length + 1);
                        regC170[regC170.Length - 1] = regDados[4].Trim(); //CD_Clifor

                        //ADD A LISTA PRINCIPAL
                        QTDLinhasBlocoC++;
                        ListRegC170.Add(regC170);
                    }

                    return ListRegC170;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

        #endregion
    }
}
