using CamadaDados.Graos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Graos
{
    public class TCN_PrecoCommodities
    {
        public static TList_PrecoCommodities Buscar(string Cd_produto,
                                                    string Dt_ini,
                                                    string Dt_fin,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_preco)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_preco)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_PrecoCommodities(banco).Select(filtro, 0, string.Empty, string.Empty);
        }
        public static string Gravar(TRegistro_PrecoCommodities val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoCommodities qtb_preco = new TCD_PrecoCommodities();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else qtb_preco.Banco_Dados = banco;
                val.Id_precostr = CamadaDados.TDataQuery.getPubVariavel(qtb_preco.Gravar(val), "@P_ID_PRECO");
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return val.Id_precostr;
            }
            catch(Exception ex)
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
        public static string Excluir(TRegistro_PrecoCommodities val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PrecoCommodities qtb_preco = new TCD_PrecoCommodities();
            try
            {
                if (banco == null)
                    st_transacao = qtb_preco.CriarBanco_Dados(true);
                else qtb_preco.Banco_Dados = banco;
                qtb_preco.Excluir(val);
                if (st_transacao)
                    qtb_preco.Banco_Dados.Commit_Tran();
                return val.Id_precostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_preco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir preço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_preco.deletarBanco_Dados();
            }
        }
    }
}
