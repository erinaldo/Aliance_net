using System;
using CamadaDados.Locacao;
using BancoDados;
using Utils;
using System.Collections.Generic;

namespace CamadaNegocio.Locacao
{
    public class TCN_MedicaoProdutoItens
    {
        public static TList_MedicaoProdutoItens Buscar(string Cd_empresa,
                                                       string Cd_patrimonio,
                                                       string Cd_produto,
                                                       string Cd_endereco,
                                                       string Dt_ini,
                                                       string Dt_fin,
                                                       TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Cd_patrimonio))
                Estruturas.CriarParametro(ref filtro, "e.cd_patrimonio", "'" + Cd_patrimonio.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Cd_produto))
                Estruturas.CriarParametro(ref filtro, "d.cd_produto", "'" + Cd_produto.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Cd_endereco))
                Estruturas.CriarParametro(ref filtro, "d.Endereco", "'" + Cd_endereco.Trim() + "'");
            if (Dt_ini.IsDateTime())
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), a.dt_medicao)))",
                    "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            if(Dt_fin.IsDateTime())
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), a.dt_medicao)))",
                    "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            return new TCD_MedicaoProdutoItens(banco).Select(filtro, 0, string.Empty);
        }

        public static void Gravar(List<TRegistro_ProdutoItens> lista, DateTime Dt_Medicao, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MedicaoProdutoItens qtb = new TCD_MedicaoProdutoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else qtb.Banco_Dados = banco;
                lista.ForEach(x => 
                Gravar(new TRegistro_MedicaoProdutoItens
                {
                    Cd_empresa = x.Cd_empresa,
                    Id_loc = x.Id_loc,
                    Id_item = x.Id_item,
                    Cd_produto = x.Cd_produto,
                    Dt_medicao = Dt_Medicao,
                    Qt_medicao = x.Qt_medida
                }, qtb.Banco_Dados));
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar medições: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_MedicaoProdutoItens val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MedicaoProdutoItens qtb = new TCD_MedicaoProdutoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else qtb.Banco_Dados = banco;
                //Verificar se existe medicao para item na data
                object obj = qtb.BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" },
                        new TpBusca { vNM_Campo = "a.id_loc", vOperador = "=", vVL_Busca = val.Id_locstr },
                        new TpBusca { vNM_Campo = "a.id_item", vOperador = "=", vVL_Busca = val.Id_itemstr },
                        new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + val.Cd_produto.Trim() + "'" },
                        new TpBusca { vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_medicao)))", vOperador = "=", vVL_Busca = "'" + val.Dt_medicao.Value.ToString("yyyyMMdd") + "'" }
                    }, "a.id_medicao");
                if (obj != null)
                    val.Id_medicao = decimal.Parse(obj.ToString());
                val.Id_medicao = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb.Gravar(val), "@P_ID_MEDICAO"));
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_medicaostr;
            }
            catch(Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar medição produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MedicaoProdutoItens val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MedicaoProdutoItens qtb = new TCD_MedicaoProdutoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb.CriarBanco_Dados(true);
                else qtb.Banco_Dados = banco;
                qtb.Excluir(val);
                if (st_transacao)
                    qtb.Banco_Dados.Commit_Tran();
                return val.Id_medicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir medição produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb.deletarBanco_Dados();
            }
        }
    }
}
