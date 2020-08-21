using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public static class TCN_CTRDuplicata
    {
        public static TList_CTRDuplicata Buscar(string Cd_empresa,
                                                string Nr_lanctoctr,
                                                string Nr_lanctoduplicata,
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
            if (Nr_lanctoduplicata.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoduplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoduplicata;
            }
            return new TCD_CTRDuplicata(banco).Select(filtro, vTop, vNm_campo);
        }

        public static CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata BuscarDuplicatas(string Cd_empresa,
                                                                                              string Nr_lanctoctr,
                                                                                              BancoDados.TObjetoBanco banco)
        {
            if ((Cd_empresa.Trim() != string.Empty) && (Nr_lanctoctr.Trim() != string.Empty))
            {
                return new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata(banco).Select(new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_ctr_duplicata x "+
                                    "where x.cd_empresa = a.cd_empresa "+
                                    "and x.nr_lanctoduplicata = a.nr_lancto "+
                                    "and x.cd_empresa = '"+Cd_empresa.Trim()+"' "+
                                    "and x.nr_lanctoctr = "+Nr_lanctoctr+")"
                    }
                }, 0, string.Empty);
            }
            else
                return new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
        }

        public static string GravarCTRDuplicata(TRegistro_CTRDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRDuplicata qtb_ctrc = new TCD_CTRDuplicata();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Gravar Duplicata CTRC
                string retorno = qtb_ctrc.GravarCTRDuplicata(val);
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar duplicata CTRC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }

        public static string DeletarCTRDuplicata(TRegistro_CTRDuplicata val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CTRDuplicata qtb_ctrc = new TCD_CTRDuplicata();
            try
            {
                if(banco == null)
                    st_transacao = qtb_ctrc.CriarBanco_Dados(true);
                else
                    qtb_ctrc.Banco_Dados = banco;
                //Deletar Duplicata CTRC
                qtb_ctrc.DeletarCTRDuplicata(val);
                if(st_transacao)
                    qtb_ctrc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ctrc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro deletar Duplicata CTRC: "+ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ctrc.deletarBanco_Dados();
            }
        }
    }
}
