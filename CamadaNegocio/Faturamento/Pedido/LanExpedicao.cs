using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_Expedicao
    {
        public static TList_Expedicao Busca(string Cd_empresa,
                                                    string Id_ordem,
                                                    string Id_expedicao,
                                                    string Cd_clifor,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_ordem";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_ordem;
            }
            if (!string.IsNullOrEmpty(Id_expedicao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_expedicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_expedicao;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_clifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }

            return new TCD_Expedicao(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Expedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Expedicao cd = new TCD_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Id_expedicaostr = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_EXPEDICAO");
                //Excluir Itens
                val.lItensDel.ForEach(p => TCN_ItensExpedicao.Excluir(p, cd.Banco_Dados));
                //Gravar Itens
                val.lItens.Where(p=> p.St_processar).ToList().ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_expedicao = val.Id_expedicao;
                    TCN_ItensExpedicao.Gravar(p, cd.Banco_Dados);
                });
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_expedicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar EXPEDICAO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Expedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Expedicao cd = new TCD_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Excluir Itens
                val.lItensDel.ForEach(p => TCN_ItensExpedicao.Excluir(p, cd.Banco_Dados));
                val.lItens.ForEach(p => TCN_ItensExpedicao.Excluir(p, cd.Banco_Dados));
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensExpedicao
    {
        public static TList_ItensExpedicao Busca(string Cd_empresa,
                                                    string Id_expedicao,
                                                    string Id_item,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_expedicao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_expedicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_expedicao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }

            return new TCD_ItensExpedicao(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensExpedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensExpedicao cd = new TCD_ItensExpedicao();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_ITEM");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensExpedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensExpedicao cd = new TCD_ItensExpedicao();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }

    public class TCN_TrocaSerieExped
    {
        public static TList_TrocaSerieExped Busca(string Id_troca,
                                                    string Cd_empresa,
                                                    string Id_expedicao,
                                                    string Id_item,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_troca))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_troca";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_troca;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_expedicao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_expedicao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_expedicao;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }

            return new TCD_TrocaSerieExped(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TrocaSerieExped val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaSerieExped cd = new TCD_TrocaSerieExped();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Id_trocastr = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_TROCA");
                //Alterar Item expedição
                cd.executarSql("update TB_FAT_ItensExpedicao set ID_Serie = " + val.Id_SerieNewstr + " " +
                               "where cd_empresa = '" + val.Cd_empresa.Trim() + "'" +
                               "and id_expedicao = " + val.Id_expedicaostr + " " +
                               "and id_item = " + val.Id_itemstr, null);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar itens: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocaSerieExped val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaSerieExped cd = new TCD_TrocaSerieExped();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
