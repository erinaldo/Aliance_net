using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public static class TCN_CTRNotaFiscal
    {
        public static TList_CTRNotaFiscal Buscar(string Cd_empresa,
                                                 string Nr_lanctoctr,
                                                 string Nr_lanctofiscal,
                                                 short vTop,
                                                 string vNm_campo,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (Cd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (Nr_lanctoctr.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (Nr_lanctofiscal.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            return new TCD_CTRNotaFiscal(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento BuscarNf(string Cd_empresa,
                                                                                          string Nr_lanctoctr,
                                                                                          BancoDados.TObjetoBanco banco)
        {
            if ((Cd_empresa.Trim() != string.Empty) &&
                (Nr_lanctoctr.Trim() != string.Empty))
                return new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(banco).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ctr_notafiscal x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                        "and x.cd_empresa = '"+Cd_empresa.Trim()+"' "+
                                        "and x.nr_lanctoctr = "+Nr_lanctoctr+")"
                        }
                    }, 0, string.Empty);
            else
                return new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
        }

        public static string Gravar(TRegistro_CTRNotaFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRNotaFiscal qtb_ctrc = new TCD_CTRNotaFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Gravar Nota Fiscal CTRC
                string retorno = qtb_ctrc.Gravar(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar nota fiscal CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CTRNotaFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRNotaFiscal qtb_ctrc = new TCD_CTRNotaFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Deletar Nota Fiscal CTRC
                qtb_ctrc.Excluir(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar Nota Fiscal CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }
    }
}
