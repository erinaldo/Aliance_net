using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CargoFuncionario
    {
        public static TList_CargoFuncionario Buscar(string Id_cargo,
                                                    string Ds_cargo,
                                                    bool St_vendedor,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_cargo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cargo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cargo;
            }
            if (!string.IsNullOrEmpty(Ds_cargo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_cargo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_cargo.Trim() + "%')";
            }
            if (St_vendedor)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            return new TCD_CargoFuncionario(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CargoFuncionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargoFuncionario qtb_cargo = new TCD_CargoFuncionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cargo.CriarBanco_Dados(true);
                else
                    qtb_cargo.Banco_Dados = banco;
                val.Id_cargo = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_cargo.Gravar(val), "@P_ID_CARGO"));
                if (st_transacao)
                    qtb_cargo.Banco_Dados.Commit_Tran();
                return val.Id_cargostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cargo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cargo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CargoFuncionario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CargoFuncionario qtb_cargo = new TCD_CargoFuncionario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cargo.CriarBanco_Dados(true);
                else
                    qtb_cargo.Banco_Dados = banco;
                qtb_cargo.Excluir(val);
                if (st_transacao)
                    qtb_cargo.Banco_Dados.Commit_Tran();
                return val.Id_cargostr;

            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cargo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cargo.deletarBanco_Dados();
            }
        }
    }
}
