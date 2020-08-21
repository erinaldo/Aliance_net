using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;
using BancoDados;
using Utils;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CadSerieNF
    {
        public static TList_CadSerieNF Busca( string vNr_Serie,
                                              string vCD_Modelo,
                                              string vDS_SerieNf,
                                              string vST_Registro,
                                              string vST_GeraSintegra,
                                              string vST_SequenciaAuto,
                                              string vTp_Serie,
                                              BancoDados.TObjetoBanco banco)
        {
        TpBusca[] vBusca = new TpBusca[0];
        
            if (!string.IsNullOrEmpty(vNr_Serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_Serie";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNr_Serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Modelo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Modelo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Modelo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDS_SerieNf))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_SerieNf";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_SerieNf.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_GeraSintegra))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_GeraSintegra";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_GeraSintegra.Trim() + "'";
            }
            if (vST_SequenciaAuto.Trim().Equals("S"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_SequenciaAuto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_SequenciaAuto + "'";
            }
            if (!string.IsNullOrEmpty(vTp_Serie))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_Serie";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTp_Serie.Trim() + "'";
            }

            return new TCD_CadSerieNF(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_CadSerieNF val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadSerieNF cd = new TCD_CadSerieNF();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Nr_Serie = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_NR_SERIE");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Nr_Serie;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadSerieNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSerieNF cd = new TCD_CadSerieNF();
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
                throw new Exception("Erro excluir serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
