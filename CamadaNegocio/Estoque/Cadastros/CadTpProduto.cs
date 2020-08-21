using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using CamadaDados.Estoque.Cadastros;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadTpProduto
    {
        public static TList_CadTpProduto Busca(string vTP_Produto,
                                               string vDS_TPProduto,
                                               string vST_Registro,
                                               string vST_Servico,
                                               string vST_Composto,
                                               string vST_MPrima,
                                               string vST_Semente,
                                               string vSt_MPrimaSemente,
                                               string vSt_ConsumoInterno,
                                               string vSt_Industrializado,
                                               string vSt_patrimonio,
                                               BancoDados.TObjetoBanco Banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vTP_Produto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.TP_Produto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDS_TPProduto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_TpProduto";
                vBusca[vBusca.Length - 1].vOperador = "like ";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_TPProduto.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Servico))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Servico, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Servico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Composto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Composto, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Composto.Trim() + "'";

            }
            if (!string.IsNullOrEmpty(vST_MPrima))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_MPrima, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_MPrima.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Semente))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Semente, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Semente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vSt_MPrimaSemente))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_MPrimaSemente, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_MPrimaSemente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vSt_ConsumoInterno))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_ConsumoInterno, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_ConsumoInterno.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vSt_Industrializado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_industrializado, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_Industrializado.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vSt_patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.st_patrimonio, 'N')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSt_patrimonio.Trim() + "'";
            }

            return new TCD_CadTpProduto(Banco).Select(vBusca, 0, string.Empty);
        }

        public static string Grava_CadTpProduto(TRegistro_CadTpProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpProduto cd = new TCD_CadTpProduto();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo produto: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Deleta_CadTpProduto(TRegistro_CadTpProduto val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpProduto cd = new TCD_CadTpProduto();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

    }
}
