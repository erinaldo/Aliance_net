using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_PrecoANP
    {
        public static TList_PrecoANP Buscar(string Id_preco,
                                            string Cd_combustivel,
                                            string Dt_preco,
                                            string vOrder,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_preco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_preco";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_preco;
            }
            if (!string.IsNullOrEmpty(Cd_combustivel))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_combustivel";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_combustivel.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_preco)) && (Dt_preco.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_preco)))";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_preco).ToString("yyyMMdd") + "'";
            }
            return new TCD_PrecoANP(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static decimal BuscarPrecoANP(string Cd_combustivel,
                                             BancoDados.TObjetoBanco banco)
        {
            object obj = new TCD_PrecoANP(banco).BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_combustivel",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Cd_combustivel.Trim() + "'"
                                }
                            }, "a.vl_preco", string.Empty, "a.dt_preco desc", null);
            return obj == null ? decimal.Zero : decimal.Parse(obj.ToString());
        }

        public static string Gravar(TRegistro_PrecoANP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoANP qtb_preco = new TCD_PrecoANP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                val.Id_precostr = CamadaDados.TDataQuery.getPubVariavel(qtb_preco.Gravar(val), "@P_ID_PRECO");
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return val.Id_precostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PrecoANP val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoANP qtb_preco = new TCD_PrecoANP();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else
                    qtb_preco.Banco_Dados = banco;
                qtb_preco.Excluir(val);
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return val.Id_precostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }
    }
}
