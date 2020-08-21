using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaNegocio.Financeiro.Duplicata
{
    public class TCN_ComplDevol_X_Parcela
    {
        public static TList_ComplDevol_X_Parcela Buscar(decimal Id_compldev,
                                                        string Cd_empresa,
                                                        decimal Nr_lancto,
                                                        decimal Cd_parcela,
                                                        decimal Nr_lanctofiscal,
                                                        int vTop,
                                                        string vNm_campo)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (Id_compldev > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_compldev";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_compldev.ToString();
            }
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lancto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto.ToString();
            }
            if (Cd_parcela > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_parcela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_parcela.ToString();
            }
            if ((Cd_empresa.Trim() != string.Empty) && (Nr_lanctofiscal > 0))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_compdevol_nf x " +
                                                      "where x.id_compldev = a.id_compldev " +
                                                      "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                                      "and ((x.nr_lanctofiscal_origem = " + Nr_lanctofiscal.ToString() + ") " +
                                                      "   or(x.nr_lanctofiscal_destino = " + Nr_lanctofiscal.ToString() + ")))";
            }
            return new TCD_ComplDevol_X_Parcela().Select(filtro, vTop, vNm_campo);
        }

        public static string GravarCompDevol_X_Parcela(TRegistroComplDevol_X_Parcela val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ComplDevol_X_Parcela qtb_comdev = new TCD_ComplDevol_X_Parcela();
            try
            {
                if (banco == null)
                {
                    qtb_comdev.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_comdev.Banco_Dados = banco;
                string retorno = qtb_comdev.GravarComplDevol_X_Parcela(val);
                if (st_transacao)
                    qtb_comdev.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_comdev.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_comdev.deletarBanco_Dados();
            }
        }

        public static string ExcluirComDevol_X_Parcela(TRegistroComplDevol_X_Parcela val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ComplDevol_X_Parcela qtb_compdev = new TCD_ComplDevol_X_Parcela();
            try
            {
                if (banco == null)
                {
                    qtb_compdev.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                    qtb_compdev.Banco_Dados = banco;
                qtb_compdev.ExcluirComplDevol_X_Parcela(val);
                if (st_transacao)
                    qtb_compdev.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_compdev.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    qtb_compdev.deletarBanco_Dados();
            }
        }
    }
}
