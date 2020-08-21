using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados.Empreendimento.Cadastro;
using Utils;

namespace CamadaNegocio.Empreendimento.Cadastro
{
    public class TCN_CadMaoObra
    {
        public static TList_CadMaoObra Busca(
                                             string id_orcamento,
                                             string nr_versao,
                                             string cd_empresa,
                                             string DSMaoObra,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];


            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_orcamento";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_orcamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_versao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_versao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nr_versao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(DSMaoObra))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_MaoObra";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DSMaoObra.Trim() + "%')";
            }


            return new TCD_CadMaoObra(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_CadMaoObra val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadMaoObra cd = new TCD_CadMaoObra();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                //Buscar ultimo numero da ordem
                val.Id_cargostr = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_CARGO");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_cargostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar mão de obra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        public static void Excluir(TRegistro_CadMaoObra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadMaoObra cd = new TCD_CadMaoObra();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
               

                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir mão de obra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }





    public class TCN_ExecCadMaoObra
    {
        public static TList_ExecCadMaoObra Busca(
            string id_execucao,
                                             string id_orcamento,
                                             string nr_versao,
                                             string cd_empresa,
                                             string DSMaoObra,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];



            if (!string.IsNullOrEmpty(id_execucao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_execucao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_execucao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_orcamento";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + id_orcamento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_versao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_versao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + nr_versao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(DSMaoObra))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_MaoObra";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DSMaoObra.Trim() + "%')";
            }


            return new TCD_ExecCadMaoObra(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_ExecCadMaoObra val, BancoDados.TObjetoBanco banco)
        {
            TCD_ExecCadMaoObra cd = new TCD_ExecCadMaoObra();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                //Buscar ultimo numero da ordem
                val.Id_execucaostr = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_EXECUCAO");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_execucaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar mão de obra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        public static void Excluir(TRegistro_ExecCadMaoObra val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ExecCadMaoObra cd = new TCD_ExecCadMaoObra();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);


                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir mão de obra: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
