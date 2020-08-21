using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using BancoDados;
using CamadaDados.Balanca;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace CamadaNegocio.Balanca
{
    public class TCN_LanClassificacao
    {
        public TCN_LanClassificacao()
        {
            
        }

        public static TList_RegLanClassificacao Buscar(string vCD_Empresa,
                                                       string vID_Ticket,
                                                       string vTP_Pesagem,
                                                       string vCD_TipoAmostra,
                                                       string vCD_TabelaDesconto,
                                                       Int32 vTop,
                                                       string vNM_Campo,
                                                       TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Ticket.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "d.ID_Ticket";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Ticket;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vTP_Pesagem.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "d.TP_Pesagem";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Pesagem + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_TipoAmostra.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TipoAmostra";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TipoAmostra + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vCD_TabelaDesconto.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_TabelaDesconto";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TabelaDesconto + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_LanClassificacao qtb_classif;
            if (vCD_TabelaDesconto.Trim() == "")
                qtb_classif = new TCD_LanClassificacao();
            else
                qtb_classif = new TCD_LanClassificacao("SqlCodeBuscaAmostrasClassif");
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_classif.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_classif.Banco_Dados = banco;
                return qtb_classif.Select(vBusca, vTop, vNM_Campo);
            }
            finally
            {
                if (pode_liberar)
                { qtb_classif.deletarBanco_Dados(); }
            }
        }

        public static TList_RegLanClassificacao buscarDadosClassif(string vCD_TabelaDesconto,
                                              string vLogin)
        {
            CamadaDados.Graos.TList_DescontoXAmostra lDesc =
                CamadaNegocio.Graos.TCN_DescontoXAmostra.Buscar(vCD_TabelaDesconto,
                                                                string.Empty,
                                                                null);
            TList_RegLanClassificacao ret = new TList_RegLanClassificacao();
            if (lDesc.Count > 0)
            {
                lDesc.ForEach(p =>
                {
                    TRegistro_LanClassificacao regClassif = new TRegistro_LanClassificacao();
                    regClassif.Cd_tipoamostra = p.Cd_tipoamostra;
                    regClassif.Ds_amostra = p.Ds_tipoamostra;
                    regClassif.Fator_conversao = p.Fator_conversao;
                    regClassif.InformarR_P = p.InformarR_P;
                    regClassif.Maiorque = p.Maiorque;
                    regClassif.Menorque = p.Menorque;
                    regClassif.Ps_referencia = p.Ps_referencia_padrao;
                    regClassif.Login_cla = vLogin;
                    regClassif.Capturapeso = p.Capturapeso;
                    regClassif.Capturareferencia = p.Capturareferencia;
                    regClassif.Cd_protocolopeso = p.Cd_protocolo;
                    regClassif.Cd_protocoloreferencia = p.Cd_protocolo_ref;
                    regClassif.Ds_protocolopeso = p.Ds_protocolo;
                    regClassif.Ds_protocoloreferencia = p.Ds_protocolo_ref;
                    regClassif.Dt_classif = DateTime.Now;
                    ret.Add(regClassif);
                });             
            }
            return ret;
        }

        public static bool existeClassificacao(string vCD_Empresa,
                                                 string vID_Ticket,
                                                 string vTP_Pesagem)
        {
            object obj = new TCD_LanClassificacao().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + vCD_Empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_ticket",
                        vOperador = "=",
                        vVL_Busca = vID_Ticket
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.tp_pesagem",
                        vOperador = "=",
                        vVL_Busca = "'" + vTP_Pesagem.Trim() + "'"
                    }
                }, "1");
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }
                
        public static bool produtoClassificavel(string vCD_Produto,
                                                string vCD_TabelaDesconto)
        {
            object obj = new TCD_LanClassificacao("SqlCodeBuscaProdutoClassificavel").BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCD_Produto.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_tabeladesconto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + vCD_TabelaDesconto.Trim() + "'"
                                }
                            }, "1");
            return obj == null ? false : obj.ToString().Trim().Equals("1");
        }

        public static bool ValidaIndiceClassif(string Cd_tabeladesconto,
                                               string Cd_tipoamostra,
                                               decimal Pc_resultado)
        {
            object obj = new CamadaDados.Graos.TCD_PercDesconto().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.CD_TabelaDesconto",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_tabeladesconto.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.CD_TipoAmostra",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_tipoamostra.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.PC_Resultado",
                        vOperador = "=",
                        vVL_Busca = Pc_resultado.ToString("N2", new System.Globalization.CultureInfo("en-US", true))
                    }
                }, "1");
            if (obj == null)
                return false;
            else
                return obj.ToString().Trim().Equals("1");
        }

        public static decimal calcClassif(string vCD_Empresa,
                                          string vID_Ticket,
                                          string vTP_Pesagem,
                                          TObjetoBanco banco)
        {
            decimal retorno = 0;
            TCD_LanClassificacao qtb_classif = new TCD_LanClassificacao();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                    pode_liberar = qtb_classif.CriarBanco_Dados(true);
                else qtb_classif.Banco_Dados = banco;
                //Calcular Classif
                retorno = qtb_classif.calcClassif(vCD_Empresa, vID_Ticket, vTP_Pesagem);
                if (pode_liberar)
                    qtb_classif.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            { return decimal.Zero; }
            finally
            {
                if (pode_liberar)
                    qtb_classif.deletarBanco_Dados();
            }
        }
        
        public static string GravarClassificacao(TList_RegLanClassificacao val, TObjetoBanco banco)
        {
            if (val != null)
            {
                string retorno = "";
                for (int i = 0; i < val.Count; i++)
                    retorno = retorno + "|" + GravarClassificacao(val[i], banco);
                return retorno;
            }
            else
                return "";
        }

        public static string GravarClassificacao(TRegistro_LanClassificacao val, TObjetoBanco banco)
        {
            string retorno = "";
            TCD_LanClassificacao qtb_classif = new TCD_LanClassificacao();
            bool pode_liberar = false;
            try
            {
                if (banco == null)
                {
                    qtb_classif.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_classif.Banco_Dados = banco;
                //Gravar Classificação
                retorno = qtb_classif.GravarClassificacao(val);
                if (pode_liberar)
                    qtb_classif.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    qtb_classif.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    qtb_classif.deletarBanco_Dados();
            }
        }
    }
}
