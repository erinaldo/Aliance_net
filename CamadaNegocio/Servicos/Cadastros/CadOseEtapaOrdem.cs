using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_EtapaOrdem
    {
        public static TList_EtapaOrdem Buscar(string Id_etapa,
                                              string Ds_etapa,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_etapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_etapa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_etapa;
            }
            if (!string.IsNullOrEmpty(Ds_etapa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_etapa";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_etapa.Trim() + "%'";
            }
            return new TCD_EtapaOrdem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EtapaOrdem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EtapaOrdem qtb_etapa = new TCD_EtapaOrdem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_etapa.CriarBanco_Dados(true);
                else
                    qtb_etapa.Banco_Dados = banco;
                val.Id_etapastr = CamadaDados.TDataQuery.getPubVariavel(qtb_etapa.Gravar(val), "@P_ID_ETAPA");
                if (st_transacao)
                    qtb_etapa.Banco_Dados.Commit_Tran();
                return val.Id_etapastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_etapa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_etapa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EtapaOrdem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EtapaOrdem qtb_etapa = new TCD_EtapaOrdem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_etapa.CriarBanco_Dados(true);
                else
                    qtb_etapa.Banco_Dados = banco;
                qtb_etapa.Excluir(val);
                if (st_transacao)
                    qtb_etapa.Banco_Dados.Commit_Tran();
                return val.Id_etapastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_etapa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_etapa.deletarBanco_Dados();
            }
        }
    }
}
