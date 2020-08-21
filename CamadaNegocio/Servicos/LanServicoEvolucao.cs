using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Servicos;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanServicoEvolucao
    {
        public static TList_LanServicoEvolucao Buscar(string vId_os,
                                                      string vCd_empresa,
                                                      string vId_evolucao,
                                                      string vId_tecnico,
                                                      string vDs_evolucao,
                                                      string vDt_inicio,
                                                      string vDt_final,
                                                      string vNm_campo,
                                                      bool vST_Evolucao,
                                                      int vTop,
                                                      TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                filtro[filtro.Length - 1].vVL_Busca = vId_os;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vId_evolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Evolucao";
                filtro[filtro.Length - 1].vVL_Busca = vId_evolucao;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vId_tecnico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Tecnico";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vId_tecnico.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_evolucao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Evolucao";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_evolucao.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if ((vDt_inicio.Trim() != string.Empty) && (vDt_inicio.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Inicio";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_inicio).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if ((vDt_final.Trim() != string.Empty) && (vDt_final.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DT_Inicio";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_final).ToString("yyyyMMdd")) + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (vST_Evolucao)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_Evolucao";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
            }
            
            return new TCD_LanServicoEvolucao(banco).Select(filtro, vTop, vNm_campo, string.Empty);
        }

        public static string Gravar(TRegistro_LanServicoEvolucao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicoEvolucao qtb_evolucao = new TCD_LanServicoEvolucao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evolucao.CriarBanco_Dados(true);
                else
                    qtb_evolucao.Banco_Dados = banco;
                //Gravar evolucao
                string retorno = qtb_evolucao.Gravar(val);
                val.Id_evolucao = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_EVOLUCAO"));
                //Deletar Atividades Etapa
                val.lAtividadeDel.ForEach(p => TCN_LanAtividades.Excluir(p, qtb_evolucao.Banco_Dados));
                //Gravar Atividade Etapa
                val.lAtividade.ForEach(p =>
                {
                    p.Id_os = val.Id_os;
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_evolucao = val.Id_evolucao;
                    if (string.IsNullOrEmpty(p.Login))
                        p.Login = Utils.Parametros.pubLogin;
                    TCN_LanAtividades.Gravar(p, qtb_evolucao.Banco_Dados);
                });
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evolucao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanServicoEvolucao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicoEvolucao qtb_evolucao = new TCD_LanServicoEvolucao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evolucao.CriarBanco_Dados(true);
                else
                    qtb_evolucao.Banco_Dados = banco;
                //Deletar Atividade
                val.lAtividade.ForEach(p=> TCN_LanAtividades.Excluir(p, qtb_evolucao.Banco_Dados));
                //Deletar evolucao;
                qtb_evolucao.Excluir(val);
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir evolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evolucao.deletarBanco_Dados();
            }
        }

        public static string OrganizarEtapas(TRegistro_LanServicoEvolucao val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicoEvolucao qtb_evolucao = new TCD_LanServicoEvolucao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evolucao.CriarBanco_Dados(true);
                else
                    qtb_evolucao.Banco_Dados = banco;
                //Gravar evolucao
                string retorno = qtb_evolucao.Gravar(val);
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evolucao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Organizar Etapas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evolucao.deletarBanco_Dados();
            }
        }
    }
}
