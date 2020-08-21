using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Estoque.Cadastros;
using Utils;

namespace CamadaNegocio.Estoque.Cadastros
{
    public class TCN_CadConvUnidade
    {
        public static TList_CadConvUnidade Busca(string vCD_Unidade_Orig,
                                                 string vCD_Unidade_Dest,
                                                 string vST_Fator,
                                                 decimal vVL_Indice,
                                                 string vST_Registro,
                                                 BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(vCD_Unidade_Orig))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Unidade_Orig";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Unidade_Orig.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Unidade_Dest))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Unidade_Dest";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Unidade_Dest.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vST_Fator))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Fator";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Fator.Trim() + "'";
            }
            if (vVL_Indice > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.VL_Indice";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vVL_Indice.ToString();
            }
            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
            }

            return new TCD_CadConvUnidade(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadConvUnidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConvUnidade cd = new TCD_CadConvUnidade();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                string ret = cd.Gravar(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadConvUnidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadConvUnidade cd = new TCD_CadConvUnidade();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else cd.Banco_Dados = banco;
                cd.Excluir(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }

        }

        public static decimal ConvertUnid(string vCD_Unid_Orig,
                                          string vCD_Unid_Dest,
                                          decimal vVl_Orig,
                                          int CasasDecimais,
                                          BancoDados.TObjetoBanco banco)
        {
            if (vCD_Unid_Orig != vCD_Unid_Dest)
            {
                TList_CadConvUnidade lConvUnid = Busca(vCD_Unid_Orig, vCD_Unid_Dest, string.Empty, 0, string.Empty, banco);
                if (lConvUnid.Count > 0)
                {
                    if (vCD_Unid_Dest.Trim().Equals(string.Empty))
                        throw new Exception("ERRO: Conversão de Unidade destino Inválida ou vazia !");
                    if (vCD_Unid_Orig.Trim().Equals(string.Empty))
                        throw new Exception("ERRO: Conversão de Unidade origem Inválida ou vazia !");
                    if (lConvUnid[0].ST_Fator.Trim() == "*")
                        return CasasDecimais > decimal.Zero ? Math.Round(vVl_Orig * lConvUnid[0].VL_Indice, CasasDecimais, MidpointRounding.AwayFromZero) : vVl_Orig * lConvUnid[0].VL_Indice;
                    else if (lConvUnid[0].ST_Fator.Trim() == "/")
                        return CasasDecimais > decimal.Zero ? Math.Round(vVl_Orig / lConvUnid[0].VL_Indice, CasasDecimais, MidpointRounding.AwayFromZero) : vVl_Orig / lConvUnid[0].VL_Indice;
                    else
                        throw new Exception("ERRO: Conversão de Unidades operador de conversão cadastrado para a unidade é inválido !");
                }
                else
                    throw new Exception("ERRO: Não foi encontrado nenhuma conversão de unidade para un orig: " + vCD_Unid_Orig + " e dest: " + vCD_Unid_Dest + "!");
            }
            else
                return CasasDecimais > decimal.Zero ? Math.Round(vVl_Orig, CasasDecimais, MidpointRounding.AwayFromZero) : vVl_Orig;
        }
    }
}
