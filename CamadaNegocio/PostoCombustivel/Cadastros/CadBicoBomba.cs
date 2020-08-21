using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_BicoBomba
    {
        public static TList_BicoBomba Buscar(string Id_bico,
                                             string Id_bomba,
                                             string Cd_empresa,
                                             string Id_tanque,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_bico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bico;
            }
            if (!string.IsNullOrEmpty(Id_bomba))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bomba";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_bomba;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_tanque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tanque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tanque;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            
            return new TCD_BicoBomba(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_BicoBomba val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_BicoBomba qtb_bico = new TCD_BicoBomba();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bico.CriarBanco_Dados(true);
                else
                    qtb_bico.Banco_Dados = banco;
                val.Id_bicostr = CamadaDados.TDataQuery.getPubVariavel(qtb_bico.Gravar(val), "@P_ID_BICO");
                if (st_transacao)
                    qtb_bico.Banco_Dados.Commit_Tran();
                return val.Id_bicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar bico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_bico.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_BicoBomba val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_BicoBomba qtb_bico = new TCD_BicoBomba();
            try
            {
                if (banco == null)
                    st_transacao = qtb_bico.CriarBanco_Dados(true);
                else
                    qtb_bico.Banco_Dados = banco;
                if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel(qtb_bico.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_bico",
                            vOperador = "=",
                            vVL_Busca = val.Id_bicostr
                        }
                    }, "1") != null)
                {
                    val.St_registro = "C";
                    qtb_bico.Gravar(val);
                }
                else
                    qtb_bico.Excluir(val);
                if (st_transacao)
                    qtb_bico.Banco_Dados.Commit_Tran();
                return val.Id_bicostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_bico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir bico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_bico.deletarBanco_Dados();
            }
        }
    }
}
