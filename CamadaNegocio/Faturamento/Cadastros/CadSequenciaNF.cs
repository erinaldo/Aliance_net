using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;
using BancoDados;
using Utils;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CadSequenciaNF
    {
        public static TList_CadSequenciaNF Busca(string vNr_Serie,
                                                 string vCd_modelo,
                                                 string vCD_Empresa,
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
            if (!string.IsNullOrEmpty(vCd_modelo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_modelo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_modelo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }

            return new TCD_CadSequenciaNF(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadSequenciaNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSequenciaNF cd = new TCD_CadSequenciaNF();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Buscar ultima nota emitida para esta sequencia
                object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(banco).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.CD_Empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_serie",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Nr_Serie.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_modelo",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_modelo.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_nota",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    }
                                }, "a.nr_notafiscal", string.Empty, "a.nr_notafiscal desc", null);
                if (obj != null)
                    if (decimal.Parse(obj.ToString()) > val.Seq_NotaFiscal)
                        throw new Exception("Existe nota fiscal propria emitida com numero maior que a sequencia.");
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar sequencia: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadSequenciaNF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadSequenciaNF cd = new TCD_CadSequenciaNF();
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
                throw new Exception("Erro excluir sequencia: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
