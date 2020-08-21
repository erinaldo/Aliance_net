using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_EmissorCF
    {
        public static TList_EmissorCF Buscar(string Id_equipamento,
                                             string Ds_equipamento,
                                             string Id_pdv,
                                             string Cd_terminal,
                                             string Nr_serie,
                                             string Tp_marca,
                                             string St_registro,
                                             BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_equipamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_equipamento;
            }
            if (!string.IsNullOrEmpty(Ds_equipamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_equipamento";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_equipamento.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(Cd_terminal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.cd_terminal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_terminal.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_marca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_marca.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }

            return new TCD_EmissorCF(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EmissorCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EmissorCF qtb_ecf = new TCD_EmissorCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ecf.CriarBanco_Dados(true);
                else
                    qtb_ecf.Banco_Dados = banco;
                val.Id_equipamentostr = CamadaDados.TDataQuery.getPubVariavel(qtb_ecf.Gravar(val), "@P_ID_EQUIPAMENTO");
                if (st_transacao)
                    qtb_ecf.Banco_Dados.Commit_Tran();
                return val.Id_equipamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ecf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar ECF: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ecf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EmissorCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EmissorCF qtb_ecf = new TCD_EmissorCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ecf.CriarBanco_Dados(true);
                else
                    qtb_ecf.Banco_Dados = banco;
                qtb_ecf.Excluir(val);
                if (st_transacao)
                    qtb_ecf.Banco_Dados.Commit_Tran();
                return val.Id_equipamentostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ecf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir ECF: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ecf.deletarBanco_Dados();
            }
        }
    }
}
