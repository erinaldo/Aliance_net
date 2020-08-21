using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_TabSimples
    {
        public static TList_TabSimples Buscar(string Id_tabela,
                                              string Ds_tabela,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tabela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tabela;
            }
            if (!string.IsNullOrEmpty(Ds_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_tabela";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_tabela.Trim() + "%'";
            }
            return new TCD_TabSimples(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TabSimples val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TabSimples qtb_tab = new TCD_TabSimples();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                val.Id_tabelastr = CamadaDados.TDataQuery.getPubVariavel(qtb_tab.Gravar(val), "@P_ID_TABELA");
                //Excluir Aliquota
                val.lAliqDel.ForEach(p => TCN_AliquotaSimples.Excluir(p, qtb_tab.Banco_Dados));
                //Gravar Aliquota
                val.lAliq.ForEach(p =>
                    {
                        p.Id_tabela = val.Id_tabela;
                        TCN_AliquotaSimples.Gravar(p, qtb_tab.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return val.Id_tabelastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tabela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TabSimples val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TabSimples qtb_tab = new TCD_TabSimples();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tab.CriarBanco_Dados(true);
                else qtb_tab.Banco_Dados = banco;
                qtb_tab.Excluir(val);
                if (st_transacao)
                    qtb_tab.Banco_Dados.Commit_Tran();
                return val.Id_tabelastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tab.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tabela: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tab.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AliquotaSimples
    {
        public static TList_AliquotaSimples Buscar(string Id_tabela,
                                            string Id_aliquota,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tabela))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tabela";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tabela;
            }
            if (!string.IsNullOrEmpty(Id_aliquota))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_aliquota";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_aliquota;
            }
            return new TCD_AliquotaSimples(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AliquotaSimples val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AliquotaSimples qtb_aliq = new TCD_AliquotaSimples();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aliq.CriarBanco_Dados(true);
                else qtb_aliq.Banco_Dados = banco;
                val.Id_aliquotastr = CamadaDados.TDataQuery.getPubVariavel(qtb_aliq.Gravar(val), "@P_ID_ALIQUOTA");
                if (st_transacao)
                    qtb_aliq.Banco_Dados.Commit_Tran();
                return val.Id_aliquotastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aliq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar aliquota: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aliq.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AliquotaSimples val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AliquotaSimples qtb_aliq = new TCD_AliquotaSimples();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aliq.CriarBanco_Dados(true);
                else qtb_aliq.Banco_Dados = banco;
                qtb_aliq.Excluir(val);
                if (st_transacao)
                    qtb_aliq.Banco_Dados.Commit_Tran();
                return val.Id_aliquotastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aliq.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aliq.deletarBanco_Dados();
            }
        }
    }
}
