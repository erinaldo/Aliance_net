using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadTpVeiculo
    {
        public static TList_CadTpVeiculo Busca(string vCD_TpVeiculo, 
                                               string vDS_TpVeiculo,
                                               string Tp_veiculo,
                                               string Tp_rodado,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_TpVeiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_TpVeiculo";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_TpVeiculo.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDS_TpVeiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_TpVeiculo";
                vBusca[vBusca.Length - 1].vOperador = " like ";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDS_TpVeiculo.Trim() + "%')";
                
            }
            if (!string.IsNullOrEmpty(Tp_veiculo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_veiculo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_veiculo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_rodado))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_rodado";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_rodado.Trim() + "'";
            }
            return new TCD_CadTpVeiculo(banco).Select(vBusca, 0, string.Empty);
        }

        public static string GravarVeiculo(TRegistro_CadTpVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpVeiculo qtb_veic = new TCD_CadTpVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veic.CriarBanco_Dados(true);
                else
                    qtb_veic.Banco_Dados = banco;
                val.CD_TpVeiculo = CamadaDados.TDataQuery.getPubVariavel(qtb_veic.GravaVeiculo(val), "@P_CD_TPVEICULO");
                if (st_transacao)
                    qtb_veic.Banco_Dados.Commit_Tran();
                return val.CD_TpVeiculo;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tipo veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veic.deletarBanco_Dados();
            }
        }

        public static string DeletarVeiculo(TRegistro_CadTpVeiculo val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTpVeiculo qtb_veic = new TCD_CadTpVeiculo();
            try
            {
                if (banco == null)
                    st_transacao = qtb_veic.CriarBanco_Dados(true);
                else
                    qtb_veic.Banco_Dados = banco;
                qtb_veic.DeletaVeiculo(val);
                if (st_transacao)
                    qtb_veic.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_veic.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tipo veiculo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_veic.deletarBanco_Dados();
            }
        }
    }
}
