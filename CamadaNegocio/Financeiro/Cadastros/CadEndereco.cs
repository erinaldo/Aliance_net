using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.Cadastros;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadEndereco
    {
        public static string RemoverCaracteres(string texto)
        {
            string resultado = texto;

            resultado = resultado.Replace("\n", "");
            resultado = resultado.Replace("\r", "");
            resultado = resultado.Replace("\t", "");
            resultado = resultado.Trim();

            return resultado;
        }

        public static TList_CadEndereco Buscar(string vCd_clifor,
                                               string vCd_endereco,
                                               string vDs_endereco,
                                               string vCd_cidade,
                                               string vNumero,
                                               string vBairro,
                                               string vProximo,
                                               string vCep,
                                               string vCp,
                                               string vFone,
                                               string vInsc_estadual,
                                               string vNm_contato,
                                               string vDs_complemento,
                                               string vNm_campo,
                                               int vTop,
                                               TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_clifor.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Endereco";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_endereco.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_endereco))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Endereco";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_endereco.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vCd_cidade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Cidade";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_cidade.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vNumero))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Numero";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNumero.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vBairro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Bairro";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vBairro.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vProximo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Proximo";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vProximo.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vCep))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cep";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCep.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCp))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CP";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCp.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vFone))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Fone";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vFone.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vInsc_estadual))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Insc_Estadual";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vInsc_estadual.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vNm_contato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Contato";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vNm_contato.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vDs_complemento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_Complemento";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_complemento.Trim() + "%')";
                filtro[filtro.Length - 1].vOperador = "like";
            }
            return new TCD_CadEndereco(banco).Select(filtro, vTop, vNm_contato);
        }

        public static string Gravar(TRegistro_CadEndereco val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEndereco qtb_endereco = new TCD_CadEndereco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_endereco.CriarBanco_Dados(true);
                else
                    qtb_endereco.Banco_Dados = banco;
                //Gravar Endereco
                string retorno = qtb_endereco.Gravar(val);
                val.Cd_endereco = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_ENDERECO");
                if (st_transacao)
                    qtb_endereco.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_endereco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar endereço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_endereco.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadEndereco val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEndereco qtb_endereco = new TCD_CadEndereco();
            try
            {
                if (banco == null)
                    st_transacao = qtb_endereco.CriarBanco_Dados(true);
                else
                    qtb_endereco.Banco_Dados = banco;
                //Deletar Endereco
                qtb_endereco.Excluir(val);
                if (st_transacao)
                    qtb_endereco.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_endereco.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir endereço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_endereco.deletarBanco_Dados();
            }
        }
    }
}
