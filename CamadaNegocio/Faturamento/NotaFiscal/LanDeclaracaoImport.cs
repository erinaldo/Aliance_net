using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_DeclaracaoImport
    {
        public static TList_DeclaracaoImport Buscar(string Cd_empresa,
                                                     string Nr_lanctofiscal,
                                                     string Id_nfitem,
                                                     string Nr_di,
                                                     string Id_di,
                                                     string Cd_ufdesemb,
                                                     string Dt_di,
                                                     string xLocDesemb,
                                                     string Dt_desemb,
                                                     string Tp_viatransp,
                                                     string Nr_adicao,
                                                     string nSeqAdic,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            if (!string.IsNullOrEmpty(Id_di))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_di";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_di;
            }
            if (!string.IsNullOrEmpty(Cd_ufdesemb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_ufdesemb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_ufdesemb;
            }
            if (!string.IsNullOrEmpty(Nr_di))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_di";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_di;
            }
            if (!string.IsNullOrEmpty(Dt_di))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_di";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Dt_di;
            }
            if (!string.IsNullOrEmpty(xLocDesemb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.xLocDesemb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = xLocDesemb;
            }
            if (!string.IsNullOrEmpty(Dt_desemb))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_desemb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Dt_desemb;
            }
            if (!string.IsNullOrEmpty(Tp_viatransp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_viatransp";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Tp_viatransp;
            }
            if (!string.IsNullOrEmpty(Nr_adicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_adicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_adicao;
            }
            if (!string.IsNullOrEmpty(nSeqAdic))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nSeqAdic";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nSeqAdic;
            }
            return new TCD_DeclaracaoImport(banco).Select(filtro, 0, string.Empty);
        }


        public static string Gravar(TRegistro_DeclaracaoImport val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DeclaracaoImport qtb_cfg = new TCD_DeclaracaoImport();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                string retorno = qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DeclaracaoImport val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DeclaracaoImport qtb_cfg = new TCD_DeclaracaoImport();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir configuração: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }


    }
}
