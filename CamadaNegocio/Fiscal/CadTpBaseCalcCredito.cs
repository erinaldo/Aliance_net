using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_TpBaseCalcCredito
    {
        public static TList_TpBaseCalcCredito Buscar(string Id_basecredito,
                                                     string Ds_basecredito,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_basecredito))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_basecredito";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_basecredito;
            }
            if (!string.IsNullOrEmpty(Ds_basecredito))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_basecredito";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_basecredito.Trim() + "%')";
            }
            return new TCD_TpBaseCalcCredito(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpBaseCalcCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpBaseCalcCredito qtb_tp = new TCD_TpBaseCalcCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                val.Id_basecreditostr = CamadaDados.TDataQuery.getPubVariavel(qtb_tp.Gravar(val), "@P_ID_BASECREDITO");
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_basecreditostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TpBaseCalcCredito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpBaseCalcCredito qtb_tp = new TCD_TpBaseCalcCredito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Id_basecreditostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tp.deletarBanco_Dados();
            }
        }
    }
}
