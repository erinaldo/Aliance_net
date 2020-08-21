using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using CamadaDados.Almoxarifado;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_CadAlmoxarifado
    {
        public static TList_CadAlmoxarifado Busca(string id_almox, 
                                                  string ds_almox,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(id_almox))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_almox";
                vBusca[vBusca.Length - 1].vVL_Busca = id_almox;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (ds_almox.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ds_almoxarifado";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + ds_almox + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            return new TCD_CadAlmoxarifado(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadAlmoxarifado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAlmoxarifado qtb_amx = new TCD_CadAlmoxarifado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_amx.CriarBanco_Dados(true);
                else
                    qtb_amx.Banco_Dados = banco;
                val.Id_almoxString = CamadaDados.TDataQuery.getPubVariavel(qtb_amx.Gravar(val), "@P_ID_ALMOX");
                if (st_transacao)
                    qtb_amx.Banco_Dados.Commit_Tran();
                return val.Id_almoxString;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_amx.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar almoxarifado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_amx.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadAlmoxarifado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadAlmoxarifado qtb_amx = new TCD_CadAlmoxarifado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_amx.CriarBanco_Dados(true);
                else
                    qtb_amx.Banco_Dados = banco;
                qtb_amx.Excluir(val);
                if (st_transacao)
                    qtb_amx.Banco_Dados.Commit_Tran();
                return val.Id_almoxString;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_amx.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir almoxarifado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_amx.deletarBanco_Dados();
            }
        }
    }
}
