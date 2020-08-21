using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanAtividades
    {
        public static TList_LanAtividades Buscar(string vId_os,
                                                    string vCd_empresa,
                                                    string vId_evolucao,
                                                    string vId_etapa,
                                                    string vId_atividade,
                                                    string vLogin,
                                                    string vCd_tecnico,
                                                    string vTp_data,
                                                    string vDt_ini,
                                                    string vDt_fin,
                                                    string vSt_registro,
                                                    TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_os;
            }
            if (vCd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_evolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Evolucao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_evolucao;
            }
            if (vId_etapa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                                       "where  a.ID_Evolucao = x.ID_Evolucao " +
                                                       "and a.ID_OS = x.ID_OS " +
                                                       "and a.CD_Empresa = x.CD_Empresa " +
                                                       "and a.CD_Tecnico = '" + vCd_tecnico.Trim() + "'" +
                                                       "and x.ID_Etapa = '" + vId_etapa.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(vId_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_atividade;
            }
            if (vLogin.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vLogin.Trim() + "'";
            }
            if (vCd_tecnico.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Tecnico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_tecnico.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("A") ? "a.dt_atividade" : vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_conclusao" : string.Empty) + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("A") ? "a.dt_atividade" : vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_conclusao" : string.Empty) + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (vSt_registro.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + vSt_registro.Trim() + ")";
            }

            return  new TCD_LanAtividades(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanAtividades val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAtividades qtb_atividades = new TCD_LanAtividades();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atividades.CriarBanco_Dados(true);
                else
                    qtb_atividades.Banco_Dados = banco;

                string retorno = qtb_atividades.Gravar(val);
                val.Id_atividadestr = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_ATIVIDADE");
                if (st_transacao)
                    qtb_atividades.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_atividades.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atividades.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanAtividades val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAtividades qtb_atividades = new TCD_LanAtividades();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atividades.CriarBanco_Dados(true);
                else
                    qtb_atividades.Banco_Dados = banco;
                qtb_atividades.Excluir(val);

                if (st_transacao)
                    qtb_atividades.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_atividades.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atividades.deletarBanco_Dados();
            }
        }

        public static string Finalizar(TRegistro_LanAtividades val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAtividades qtb_atividades = new TCD_LanAtividades();
            try
            {
                if (banco == null)
                    st_transacao = qtb_atividades.CriarBanco_Dados(true);
                else
                    qtb_atividades.Banco_Dados = banco;
                val.St_registro = "C";
                val.Dt_Conclusao = CamadaDados.UtilData.Data_Servidor();
                string retorno = qtb_atividades.Gravar(val);
                //Verificar se etapa está concluida
                if (new CamadaDados.Servicos.TCD_LanAtividades(qtb_atividades.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.st_registro",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_EVOLUCAO",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Id_evolucaostr.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_OS",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Id_osstr.Trim() + "'"
                                },
                                 new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                }
                            }, string.Empty) == null)
                {
                    //Buscar etapa/evolucao da atividade
                    TList_LanServicoEvolucao lEvolucao =
                        new TCD_LanServicoEvolucao(qtb_atividades.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_EVOLUCAO",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Id_evolucaostr + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_OS",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Id_osstr + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            }
                        },0, string.Empty, string.Empty);

                    if (lEvolucao.Count > 0)
                    {
                        lEvolucao.ForEach(p =>
                            {
                                p.St_evolucao = "E";
                                p.Dt_final = CamadaDados.UtilData.Data_Servidor();
                                TCN_LanServicoEvolucao.Gravar(p, qtb_atividades.Banco_Dados);
                            });
                    }
                }
                //Verificar se Projeto está Concluído
                if (new CamadaDados.Servicos.TCD_LanServicoEvolucao(qtb_atividades.Banco_Dados).BuscarEscalar(
                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.st_evolucao",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_OS",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Id_osstr.Trim() + "'"
                                },
                                 new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                }
                            }, string.Empty) == null)
                {
                    //Buscar Projeto da atividade
                    TList_LanServico lProjeto = new TList_LanServico();
                        lProjeto =
                        new TCD_LanServico(qtb_atividades.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.ID_OS",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Id_osstr + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            }
                        }, 0, string.Empty, string.Empty);

                    if (lProjeto.Count > 0)
                    {
                        lProjeto.ForEach(p =>
                        {
                            p.St_os = "FE";
                            p.Dt_finalizada = CamadaDados.UtilData.Data_Servidor();
                            TCN_LanServico.Gravar(p, qtb_atividades.Banco_Dados);
                        });
                    }
                }
                if (st_transacao)
                    qtb_atividades.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_atividades.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_atividades.deletarBanco_Dados();
            }
        }
    }
}
