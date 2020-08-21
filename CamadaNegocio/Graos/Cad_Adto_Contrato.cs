using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Graos;
using BancoDados;
using CamadaDados.Financeiro.Adiantamento;
using CamadaNegocio.Financeiro.Adiantamento;

namespace CamadaNegocio.Graos
{
    public class TCN_Lan_Adto_Contrato
    {
        public static TList_Adto_Contrato Busca(string vNR_Contrato,
                                                    string vId_Adto,
                                                    BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vNR_Contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_Contrato;
            }
            if (!string.IsNullOrEmpty(vId_Adto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Adto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_Adto;
            }

            return new TCD_Adto_Contrato(banco).Select(vBusca, 0, string.Empty);
        }

        public static TList_LanAdiantamento BuscarAdiantamento(string Nr_contrato,
                                                               BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanAdiantamento(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_gro_adto_contrato x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.nr_contrato = " + Nr_contrato + ")"
                    }
                }, 0, string.Empty);
        }
        public static string Gravar(TRegistro_Adto_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adto_Contrato cd = new TCD_Adto_Contrato();
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
                throw new Exception("Erro gravar adiantamento contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Adto_Contrato val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Adto_Contrato qtb_adto = new TCD_Adto_Contrato();
            try
            {
                if (banco == null)
                    st_transacao = qtb_adto.CriarBanco_Dados(true);
                else
                    qtb_adto.Banco_Dados = banco;
                qtb_adto.Exclui(val);
                if (st_transacao)
                    qtb_adto.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_adto.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir adiantamento contrato: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_adto.deletarBanco_Dados();
            }
        }
    }
}
