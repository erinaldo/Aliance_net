using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;

namespace CamadaNegocio.Graos
{
    public class TCN_LanTaxas_Deposito
    {
        public static TList_TaxaDeposito BuscarTx(string Nr_contrato, 
                                                string Tp_lancto,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Tp_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_lancto";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_lancto.Trim() + ")";
            }

            return new TCD_LanTaxaDeposito(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TaxaDeposito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTaxaDeposito qtb_taxa = new TCD_LanTaxaDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                //Gravar Taxa Deposito
                string retorno = qtb_taxa.Gravar(val);
                if (st_transacao)
                    qtb_taxa.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar taxa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TaxaDeposito val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTaxaDeposito qtb_taxa = new TCD_LanTaxaDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                //Excluir taxa
                qtb_taxa.Excluir(val);
                if (st_transacao)
                    qtb_taxa.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir taxa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }

        public static void ExcluirTaxasProvisionadas(List<TRegistro_TaxaDeposito> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanTaxaDeposito qtb_taxa = new TCD_LanTaxaDeposito();
            try
            {
                if (banco == null)
                    st_transacao = qtb_taxa.CriarBanco_Dados(true);
                else
                    qtb_taxa.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        //Verificar se a taxa esta faturada
                        TList_Taxa_X_PedidoItem lTxPed = TCN_Taxa_X_PedidoItem.Buscar(p.Id_LanTaxa.ToString(), string.Empty, qtb_taxa.Banco_Dados);
                        lTxPed.ForEach(v => TCN_Taxa_X_PedidoItem.Excluir(v, qtb_taxa.Banco_Dados));
                        Excluir(p, qtb_taxa.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_taxa.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_taxa.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir taxas provisionadas: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_taxa.deletarBanco_Dados();
            }
        }
    }
}
