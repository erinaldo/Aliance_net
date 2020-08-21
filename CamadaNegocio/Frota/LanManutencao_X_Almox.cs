using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota;

namespace CamadaNegocio.Frota
{
    public class TCN_Manutencao_X_Almox
    {
        public static TList_Manutencao_X_Almox Buscar(string Id_manutencao,
                                                  string Id_veiculo,
                                                  string Id_movimento,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_manutencao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_manutencao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_manutencao;
            }
            if (!string.IsNullOrEmpty(Id_veiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_veiculo.Trim();
            }
            if (!string.IsNullOrEmpty(Id_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movimento;
            }

            return new TCD_Manutencao_X_Almox(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Almoxarifado.TList_Movimentacao BuscarMovimentacao(string Id_manutencao,
                                                                                      string Id_veiculo,
                                                                                      BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Almoxarifado.TCD_Movimentacao(banco).Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_frt_manutencao_X_almox x " +
                                    "where x.id_movimento = a.id_movimento " +
                                    "and x.id_manutencao = " + Id_manutencao.Trim() + " " +
                                    "and x.id_veiculo = " + Id_veiculo + ")"
                    }
                },0, string.Empty);
        }

        public static string Gravar(TRegistro_Manutencao_X_Almox val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Manutencao_X_Almox qtb_almox = new TCD_Manutencao_X_Almox();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_almox.CriarBanco_Dados(true);
                else
                    qtb_almox.Banco_Dados = banco;
                string retorno = qtb_almox.Gravar(val);
                if (st_transacao)
                    qtb_almox.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_almox.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Almoxarifado: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_almox.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Manutencao_X_Almox val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Manutencao_X_Almox qtb_almox = new TCD_Manutencao_X_Almox();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_almox.CriarBanco_Dados(true);
                else
                    qtb_almox.Banco_Dados = banco;
                qtb_almox.Excluir(val);
                if (st_transacao)
                    qtb_almox.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_almox.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Almoxarifado " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_almox.deletarBanco_Dados();
            }
        }
    }
}
