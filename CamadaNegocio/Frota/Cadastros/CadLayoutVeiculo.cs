using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Frota.Cadastros;

namespace CamadaNegocio.Frota.Cadastros
{
    public class TCN_CadLayoutVeiculo
    {
        public static TList_CadLayoutVeiculo Buscar(string Id_layout,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_layout))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_layout";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_layout;
            }

            return new TCD_CadLayoutVeiculo(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadLayoutVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLayoutVeiculo qtb_layout = new TCD_CadLayoutVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_layout.CriarBanco_Dados(true);
                else
                    qtb_layout.Banco_Dados = banco;
                string retorno = qtb_layout.Gravar(val);
                if (st_transacao)
                    qtb_layout.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_layout.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar layout veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_layout.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadLayoutVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadLayoutVeiculo qtb_layout = new TCD_CadLayoutVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_layout.CriarBanco_Dados(true);
                else
                    qtb_layout.Banco_Dados = banco;
                qtb_layout.Excluir(val);
                if (st_transacao)
                    qtb_layout.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_layout.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir layout veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_layout.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CadConf_Layout
    {
        public static TList_CadConf_Layout Buscar(string Id_layout,
                                                  string Id_posicao,
                                            BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_layout))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_layout";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_layout;
            }
            if (!string.IsNullOrEmpty(Id_posicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_posicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_posicao;
            }

            return new TCD_CadConf_Layout(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadConf_Layout val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConf_Layout qtb_layout = new TCD_CadConf_Layout();
            try
            {
                if (banco == null)
                    st_transacao = qtb_layout.CriarBanco_Dados(true);
                else
                    qtb_layout.Banco_Dados = banco;
                val.Id_posicaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_layout.Gravar(val), "@P_ID_POSICAO");
                if (st_transacao)
                    qtb_layout.Banco_Dados.Commit_Tran();
                return val.Id_posicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_layout.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar conf layout: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_layout.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadConf_Layout val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConf_Layout qtb_layout = new TCD_CadConf_Layout();
            try
            {
                if (banco == null)
                    st_transacao = qtb_layout.CriarBanco_Dados(true);
                else
                    qtb_layout.Banco_Dados = banco;
                qtb_layout.Excluir(val);
                if (st_transacao)
                    qtb_layout.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_layout.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir conf layout: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_layout.deletarBanco_Dados();
            }
        }
    }
}
