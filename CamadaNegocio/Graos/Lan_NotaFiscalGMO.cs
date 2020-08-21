using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Graos;
using Utils;
using BancoDados;

namespace CamadaNegocio.Graos
{
    public class TCN_Lan_NotaFiscalGMO
    {
        public static TList_Lan_NotaFiscalGMO Buscar(string Id_lanctoGMO,
                                                     string Cd_empresa,
                                                     string Nr_lanctoFiscal,
                                                     string Id_nfitem,
                                                     TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(Id_lanctoGMO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoGMO";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoGMO;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Nr_lanctoFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoFiscal";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoFiscal;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_Lan_NotaFiscalGMO(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento BuscarNF(string Id_lanctoGMO, BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(banco).Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_gro_notafiscalGMO x " + 
                                            "where x.cd_empresa = a.cd_empresa " + 
                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                            "and x.id_lanctoGMO = " + Id_lanctoGMO + ")"
                            }
                        }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lan_NotaFiscalGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_NotaFiscalGMO cd = new TCD_Lan_NotaFiscalGMO();
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
                throw new Exception("Erro gravar NF GMO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Lan_NotaFiscalGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lan_NotaFiscalGMO cd = new TCD_Lan_NotaFiscalGMO();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Excluir NF GMO
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir NF GMO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
