using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_TpOrdem
    {
        public static TList_TpOrdem Buscar(string Tp_ordem,
                                           string Ds_tipoordem,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_ordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Tp_ordem;
            }
            if (!string.IsNullOrEmpty(Ds_tipoordem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tipoordem";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_tipoordem.Trim() + "%'";
            }
            return new TCD_TpOrdem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TpOrdem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpOrdem qtb_tp = new TCD_TpOrdem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                val.Tp_ordemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_tp.Gravar(val), "@P_TP_ORDEM");
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Tp_ordemstr;
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

        public static string Excluir(TRegistro_TpOrdem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TpOrdem qtb_tp = new TCD_TpOrdem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tp.CriarBanco_Dados(true);
                else
                    qtb_tp.Banco_Dados = banco;
                qtb_tp.Excluir(val);
                if (st_transacao)
                    qtb_tp.Banco_Dados.Commit_Tran();
                return val.Tp_ordemstr;
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
