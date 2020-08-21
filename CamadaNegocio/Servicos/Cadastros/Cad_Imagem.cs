using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Servicos.Cadastros;

namespace CamadaNegocio.Servicos.Cadastros
{
    public class TCN_Imagens
    {
        public static TList_Imagens Buscar(string Id_os,
                                           string Cd_empresa,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_os;
            }
            if(!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }

            return new TCD_Imagens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Imagens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Imagens qtb_Imagem = new TCD_Imagens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Imagem.CriarBanco_Dados(true);
                else
                    qtb_Imagem.Banco_Dados = banco;
                //Gravar imagem
                string retorno = qtb_Imagem.Grava(val);
                if (st_transacao)
                    qtb_Imagem.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Imagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar imagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Imagem.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Imagens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Imagens qtb_Imagem = new TCD_Imagens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_Imagem.CriarBanco_Dados(true);
                else
                    qtb_Imagem.Banco_Dados = banco;
                qtb_Imagem.Deleta(val);
                if (st_transacao)
                    qtb_Imagem.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_Imagem.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir imagem: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_Imagem.deletarBanco_Dados();
            }            
        }
    }
}
