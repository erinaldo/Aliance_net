using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Cadastros;
using Utils;

namespace CamadaNegocio.Fazenda.Cadastros
{
    public class TCN_Area
    {
        public static TList_Area Buscar(string Cd_fazenda,
                                        string Id_area,
                                        string Ds_area,
                                        BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_fazenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fazenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fazenda.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_area";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_area;
            }
            if (!string.IsNullOrEmpty(Ds_area))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_area";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_area.Trim() + "%')";
            }
            return new TCD_Area(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Area val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Area qtb_area = new TCD_Area();
            try
            {
                if (banco == null)
                    st_transacao = qtb_area.CriarBanco_Dados(true);
                else
                    qtb_area.Banco_Dados = banco;
                val.Id_areastr = CamadaDados.TDataQuery.getPubVariavel(qtb_area.Gravar(val), "@P_ID_AREA");
                if (st_transacao)
                    qtb_area.Banco_Dados.Commit_Tran();
                return val.Id_areastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_area.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar area: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_area.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Area val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Area qtb_area = new TCD_Area();
            try
            {
                if (banco == null)
                    st_transacao = qtb_area.CriarBanco_Dados(true);
                else
                    qtb_area.Banco_Dados = banco;
                val.St_registro = "I";
                Gravar(val, qtb_area.Banco_Dados);
                if (st_transacao)
                    qtb_area.Banco_Dados.Commit_Tran();
                return val.Id_areastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_area.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir area: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_area.deletarBanco_Dados();
            }
        }
    }
}
