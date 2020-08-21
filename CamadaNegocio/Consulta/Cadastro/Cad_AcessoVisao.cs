using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;

namespace CamadaNegocio.Consulta.Cadastro
{

    public class TCN_Cad_AcessoVisao
    {
        public static TList_AcessoVisao Busca(decimal id_visao, string login)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (id_visao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_visao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_visao.ToString() + "'";
            }
            if (login.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.login";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + login.Replace("'", "''") + "%'";
            }
            TCD_AcessoVisao cd = new TCD_AcessoVisao();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava(TRegistro_AcessoVisao val)
        {
            TCD_AcessoVisao cd = new TCD_AcessoVisao();
            return cd.Grava(val);

        }

        public static string Deleta(TRegistro_AcessoVisao val)
        {
            TCD_AcessoVisao CD = new TCD_AcessoVisao();
            return CD.Deleta(val);
        }
    }

    public class TCN_Cad_VisaoBI
    {
        public static TList_VisaoBI Busca(decimal id_visao, string ds_visao)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (id_visao > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_visao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_visao.ToString() + "'";
            }
            if (ds_visao.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.ds_visao";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + ds_visao.Replace("'", "''") + "%'";
            }
            TCD_VisaoBI cd = new TCD_VisaoBI();
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava(TRegistro_VisaoBI val)
        {
            TCD_VisaoBI cd = new TCD_VisaoBI();
            return cd.Grava(val);

        }

        public static string DeletaOperador(TRegistro_VisaoBI val)
        {
            TCD_VisaoBI CD = new TCD_VisaoBI();
            return null;// CD.Deleta(val);
        }
    }

    public class TCN_CfgVendasUF
    {
        public static TList_CfgVendasUF Busca(string Cd_grupo, 
                                              string Ds_grupo,
                                              string Tp_visao,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_grupo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_grupo + "'";
            }
            if (!string.IsNullOrEmpty(Ds_grupo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.Ds_grupo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + Ds_grupo.Replace("'", "''") + "%'";
            }
            TCD_CfgVendasUF cd = new TCD_CfgVendasUF(banco);
            return cd.Select(vBusca, 0, "");
        }

        public static string Grava(TRegistro_CfgVendasUF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgVendasUF qtb_Report = new TCD_CfgVendasUF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;
                string retorno = qtb_Report.Grava(val);
                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }

        }

        public static string Deleta(TRegistro_CfgVendasUF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CfgVendasUF qtb_Report = new TCD_CfgVendasUF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Report.CriarBanco_Dados(true);
                else
                    qtb_Report.Banco_Dados = banco;
                //Deletar
                qtb_Report.Deleta(val);
                if (st_transacao)
                    qtb_Report.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Report.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Report.deletarBanco_Dados();
            }
        }
    }

}
