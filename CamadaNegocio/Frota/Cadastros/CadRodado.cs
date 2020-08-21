using CamadaDados.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_Rodado
    {
        public static TList_Rodado Buscar(string Id_rodado,
                                           string Ds_rodado,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_rodado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rodado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rodado;
            }
            if (!string.IsNullOrEmpty(Ds_rodado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_rodado";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_rodado.Trim() + "%'";
            }
            return new TCD_Rodado(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Rodado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rodado qtb_con = new TCD_Rodado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else
                    qtb_con.Banco_Dados = banco;
                val.Id_rodadostr = CamadaDados.TDataQuery.getPubVariavel(qtb_con.Gravar(val), "@P_ID_RODADO");
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return val.Id_rodadostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar rodado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Rodado val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Rodado qtb_con = new TCD_Rodado();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else
                    qtb_con.Banco_Dados = banco;
                //Validar se possui veiculo relacionado
                TpBusca[] tpBuscas = new TpBusca[0];
                Estruturas.CriarParametro(ref tpBuscas, "a.id_rodado", val.Id_rodadostr);
                if (Convert.ToInt32(new TCD_RodadoVeic().BuscarEscalar(tpBuscas, "count(*)")) > 0)
                    throw new Exception("Não foi possível excluir o rodado selecionado, pois possui veiculo vinculado.");

                qtb_con.Excluir(val);
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir rodado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }
    }

    public class TCN_RodadoVeic
    {
        public static TList_RodadoVeic Buscar(string Id_rodado,
                                           string Id_veiculo,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_rodado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_rodado";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_rodado;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo;
            }
            return new TCD_RodadoVeic(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(List<TRegistro_RodadoVeic> lRodado, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RodadoVeic qtb_con = new TCD_RodadoVeic();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else
                    qtb_con.Banco_Dados = banco;
                lRodado.ForEach(p=>
                {
                    if (p.St_processar)
                        qtb_con.Gravar(p);
                    else
                        qtb_con.Excluir(p);
                });
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar rodado veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_RodadoVeic val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RodadoVeic qtb_con = new TCD_RodadoVeic();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else
                    qtb_con.Banco_Dados = banco;
                qtb_con.Excluir(val);
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir rodado veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }
    }
}
