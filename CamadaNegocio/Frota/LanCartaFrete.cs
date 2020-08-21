using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_CartaFrete
    {
        public static TList_CartaFrete Buscar(string Nr_cartafrete,
                                              string Cd_empresa,
                                              string Cd_motorista,
                                              string Id_acerto,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string St_registro,
                                              BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_cartafrete))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cartafrete";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_cartafrete;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_motorista))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_motorista";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_motorista.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_acerto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_acerto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_acerto;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_CartaFrete(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CartaFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaFrete qtb_carta = new TCD_CartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carta.CriarBanco_Dados(true);
                else
                    qtb_carta.Banco_Dados = banco;
                val.Nr_cartafretestr = CamadaDados.TDataQuery.getPubVariavel(qtb_carta.Gravar(val), "@P_NR_CARTAFRETE");
                if (st_transacao)
                    qtb_carta.Banco_Dados.Commit_Tran();
                return val.Nr_cartafretestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carta.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carta.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CartaFrete val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaFrete qtb_carta = new TCD_CartaFrete();
            try
            {
                if (banco == null)
                    st_transacao = qtb_carta.CriarBanco_Dados(true);
                else
                    qtb_carta.Banco_Dados = banco;
                qtb_carta.Excluir(val);
                if (st_transacao)
                    qtb_carta.Banco_Dados.Commit_Tran();
                return val.Nr_cartafretestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_carta.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir carta frete: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_carta.deletarBanco_Dados();
            }
        }
    }
}
