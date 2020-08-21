using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_Contrato_X_DesdEspecial
    {
        public static TList_Contrato_X_DesdEspecial Buscar(string Id_tpdesdobro,
                                                           string Nr_contrato,
                                                           string Nr_contrato_dest,
                                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tpdesdobro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tpdesdobro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tpdesdobro;
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Nr_contrato_dest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato_dest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato_dest;
            }

            return new TCD_Contrato_X_DesdEspecial(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Contrato_X_DesdEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_DesdEspecial qtb_reg = new TCD_Contrato_X_DesdEspecial();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else
                    qtb_reg.Banco_Dados = banco;
                string retorno = qtb_reg.Gravar(val);
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Contrato_X_DesdEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Contrato_X_DesdEspecial qtb_reg = new TCD_Contrato_X_DesdEspecial();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_reg.CriarBanco_Dados(true);
                else
                    qtb_reg.Banco_Dados = banco;
                qtb_reg.Excluir(val);
                if (st_transacao)
                    qtb_reg.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reg.deletarBanco_Dados();
            }
        }
    }
}
