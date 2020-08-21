using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.Pedido;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_OrdemCarregamento
    {
        public static TList_OrdemCarregamento Busca(string Cd_empresa,
                                                    string Id_ordem,
                                                    string Nr_pedido,
                                                    string vDt_ini,
                                                    string vDt_fin,
                                                    string vTp_data,  
                                                    string Status,
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
            if (!string.IsNullOrEmpty(Nr_pedido))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                                      "inner join TB_FAT_Ordem_X_Expedicao y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_expedicao = y.id_expedicao " +
                                                      "where y.cd_empresa = a.cd_empresa " +
                                                      "and y.id_ordem = a.id_ordem " +
                                                      "and x.Nr_pedido = " + Nr_pedido.Trim() + ") ";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_carregamento" : "a.dt_entrega") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("C") ? "a.dt_carregamento" : "a.dt_entrega") + ")))";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(Status))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Status";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + Status.Trim() + ")";
            }

            return new TCD_OrdemCarregamento(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_OrdemCarregamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCarregamento cd = new TCD_OrdemCarregamento();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Id_ordemstr = CamadaDados.TDataQuery.getPubVariavel(cd.Gravar(val), "@P_ID_ORDEM");
                //Excluir Itens
                val.lItensDel.ForEach(p => TCN_Ordem_X_Expedicao.Excluir(p, cd.Banco_Dados));
                //Gravar Itens
                val.lExp.ForEach(p =>
                {
                    if (p.St_processar)
                        TCN_Ordem_X_Expedicao.Gravar(new TRegistro_Ordem_X_Expedicao()
                                                     {
                                                         Cd_empresa = val.Cd_empresa,
                                                         Id_ordem = val.Id_ordem,
                                                         Id_expedicao = p.Id_expedicao
                                                     }, cd.Banco_Dados);
                });
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_ordemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ordem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_OrdemCarregamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_OrdemCarregamento cd = new TCD_OrdemCarregamento();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Excluir Ordem X Expedição
                val.lItens.ForEach(p=> TCN_Ordem_X_Expedicao.Excluir(p, cd.Banco_Dados));
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

    public class TCN_Ordem_X_Expedicao
    {
        public static TList_Ordem_X_Expedicao Busca(string Cd_empresa,
                                                    string Id_ordem,
                                                    string Id_expedicao,
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

            return new TCD_Ordem_X_Expedicao(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Ordem_X_Expedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_X_Expedicao cd = new TCD_Ordem_X_Expedicao();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Gravar(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static string Excluir(TRegistro_Ordem_X_Expedicao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Ordem_X_Expedicao cd = new TCD_Ordem_X_Expedicao();
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
