using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos;
using BancoDados;
using Utils;

namespace CamadaNegocio.Servicos
{
        public class TCN_OSE_LanServicoDefeito_Tec
        {
            public static TList_LanServicoDefeito_Tec Buscar(decimal vID_OS,
                                                             string vCD_EMPRESA,
                                                             decimal vID_Defeito
                                                             )
            {
                TpBusca[] filtro = new TpBusca[0];
                if (vID_OS > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_OS";
                    filtro[filtro.Length - 1].vVL_Busca = vID_OS.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                if (vCD_EMPRESA.Trim() != "")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_EMPRESA + "'";
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                if (vID_Defeito > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.ID_Defeito";
                    filtro[filtro.Length - 1].vVL_Busca = vID_Defeito.ToString();
                    filtro[filtro.Length - 1].vOperador = "=";
                }

                return new TCD_LanServicoDefeito_Tec().Select(filtro, 0, "");
            }

            public static string Gravar(TRegistro_LanServicoDefeito_Tec val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_LanServicoDefeito_Tec qtb_Defeito_Tec = new TCD_LanServicoDefeito_Tec();
                try
                {
                    if (banco == null)
                    {
                        qtb_Defeito_Tec.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Defeito_Tec.Banco_Dados = banco;

                    string retorno = qtb_Defeito_Tec.Gravar(val);
                    if (st_transacao)
                        qtb_Defeito_Tec.Banco_Dados.Commit_Tran();
                    return retorno;
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Defeito_Tec.Banco_Dados.RollBack_Tran();
                    
                     throw new Exception(ex.Message);                    
                }
                finally
                {
                    if (st_transacao)
                        qtb_Defeito_Tec.deletarBanco_Dados();
                }
            }

            public static string Deletar(TRegistro_LanServicoDefeito_Tec val, TObjetoBanco banco)
            {
                bool st_transacao = false;
                TCD_LanServicoDefeito_Tec qtb_Defeito_Tec = new TCD_LanServicoDefeito_Tec();
                try
                {
                    if (banco == null)
                    {
                        qtb_Defeito_Tec.CriarBanco_Dados(true);
                        st_transacao = true;
                    }
                    else
                        qtb_Defeito_Tec.Banco_Dados = banco;

                    qtb_Defeito_Tec.Deletar(val);

                    if (st_transacao)
                        qtb_Defeito_Tec.Banco_Dados.Commit_Tran();
                    return "";
                }
                catch (Exception ex)
                {
                    if (st_transacao)
                        qtb_Defeito_Tec.Banco_Dados.RollBack_Tran();
                    else
                        throw new Exception(ex.Message);
                    return "";
                }
                finally
                {
                    if (st_transacao)
                        qtb_Defeito_Tec.deletarBanco_Dados();
                }
            }
        }
    
}
