using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento.Cadastro;
using CamadaDados.Empreendimento;
using Utils;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    
    public class TCN_CadFatDireto
    {
        public static TList_CadFatDireto Buscar(string Cd_empresa,
                                             string Id_orcamento,
                                             string Id_Projeto,
                                             string Nr_versao,
                                             string id_ficha,
                                             string Cd_clifor,
                                             string Cd_vendedor,
                                             string Tp_data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            

            if (!string.IsNullOrEmpty(Id_Projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vOperador = "exists ";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EMP_ItensFatDireto x where a.cd_empresa = x.cd_empresa and a.id_faturamento = x.id_faturamento and x.Id_Projeto = '" + Id_Projeto + "' )";
            }

            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vOperador = "exists ";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EMP_ItensFatDireto x where a.cd_empresa = x.cd_empresa and a.id_faturamento = x.id_faturamento and x.id_orcamento = '"+Id_orcamento+"' )";
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vOperador = "exists ";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EMP_ItensFatDireto x where a.cd_empresa = x.cd_empresa and a.id_faturamento = x.id_faturamento and x.Nr_versao = '" + Nr_versao + "' )";
            }

            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            return new TCD_CadFatDireto(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadFatDireto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadFatDireto qtb_orc = new TCD_CadFatDireto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.Id_faturamentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_orc.Gravar(val), "@P_ID_FATURAMENTO");
                val.lFicha.Where(p=> p.st_agregar).ToList().ForEach(p =>
                {
                    TRegistro_CadFatDireto_Item item = new TRegistro_CadFatDireto_Item();
                    item.Id_orcamentostr = p.Id_orcamentostr;
                    item.Id_projetostr = p.Id_projetostr;
                    item.Nr_versaostr = p.Nr_versaostr;
                    item.Id_registro = p.Id_registro;
                    item.quantidade = p.quantidade_agregar;
                    item.id_faturamento = Convert.ToDecimal(val.Id_faturamento);
                    item.id_ficha = p.Id_fichastr;
                    item.cd_empresa = p.Cd_empresa;
                    TCN_CadFatDiretoItem.Gravar(item, qtb_orc.Banco_Dados);
                });


                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.Id_faturamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadFatDireto qtb_orc = new TCD_CadFatDireto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Excluir despesas
                val.lDespesas.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                val.lDespesasDel.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir Projetos
                val.lOrcProjeto.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                val.lOrcProjetoDel.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir Orcamento
               // qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }


    public class TCN_CadFatDiretoItem
    {
        public static TList_CadFatDireto_item Buscar(string Cd_empresa,
                                             string Id_orcamento,
                                             string Id_projeto,
                                             string Nr_versao,
                                             string Cd_clifor,
                                             string id_faturamento,
                                             string Tp_data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_orcamento;
            }
            if (!string.IsNullOrEmpty(Id_projeto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_projeto;
            }
            if (!string.IsNullOrEmpty(Nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_versao;
            }

            if (!string.IsNullOrEmpty(id_faturamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_faturamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_faturamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("I") ? "a.dt_previni" : Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_prevfin" : "a.dt_orcamento") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = St_registro.Trim();
            }
            return new TCD_CadFatDiretoItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadFatDireto_Item val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadFatDiretoItem qtb_orc = new TCD_CadFatDiretoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                qtb_orc.Gravar(val);
                


                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return string.Empty;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_Orcamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadFatDireto qtb_orc = new TCD_CadFatDireto();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Excluir despesas
                val.lDespesas.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                val.lDespesasDel.ForEach(p => TCN_Despesas.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir Projetos
                val.lOrcProjeto.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                val.lOrcProjetoDel.ForEach(p => TCN_OrcProjeto.Excluir(p, qtb_orc.Banco_Dados));
                //Excluir Orcamento
                // qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir orçamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
