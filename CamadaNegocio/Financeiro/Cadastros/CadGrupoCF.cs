using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadGrupoCF
    {
        public static TList_CadGrupoCF Buscar(string Cd_grupocf,
                                              string Ds_grupocf,
                                              string Cd_grupocf_pai,
                                              string St_sintetico,
                                              string Tp_custo,
                                              int vTop,
                                              string vNm_campo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_grupocf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupocf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupocf.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ds_grupocf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_grupocf";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + Ds_grupocf.Trim() + "%')";
            }
            if (!string.IsNullOrEmpty(Cd_grupocf_pai))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupocf_pai";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_grupocf_pai.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_sintetico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_sintetico, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_sintetico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_custo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_custo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_custo.Trim() + "'";
            }

            return new TCD_CadGrupoCF(banco).Select(filtro, vTop, vNm_campo);
        }

        public static string Gravar(TRegistro_CadGrupoCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoCF qtb_grupocf = new TCD_CadGrupoCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_grupocf.CriarBanco_Dados(true);
                else
                    qtb_grupocf.Banco_Dados = banco;
                if (string.IsNullOrEmpty(val.Cd_grupocf_pai) && (!val.St_sinteticobool))
                    throw new Exception("Obrigatorio informar grupo custo fixo pai para gravar registro analitico.");
                //Gravar GrupoCf
                val.Cd_grupocf = CamadaDados.TDataQuery.getPubVariavel(qtb_grupocf.Gravar(val), "@P_CD_GRUPOCF");
                //Gravar Grupo CF nos Historicos
                val.lHistorico.ForEach(p =>
                    {
                        p.Cd_grupoCF = val.Cd_grupocf;
                        TCN_CadHistorico.Gravar(p, qtb_grupocf.Banco_Dados);
                    });
                //Excluir Historicos do Grupo CF
                val.lHistDel.ForEach(p =>
                    {
                        p.Cd_grupoCF = string.Empty;
                        TCN_CadHistorico.Gravar(p, qtb_grupocf.Banco_Dados);
                    });

                if (st_transacao)
                    qtb_grupocf.Banco_Dados.Commit_Tran();
                return val.Cd_grupocf;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_grupocf.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar grupo custo fixo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_grupocf.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadGrupoCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadGrupoCF qtb_grupocf = new TCD_CadGrupoCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_grupocf.CriarBanco_Dados(true);
                else
                    qtb_grupocf.Banco_Dados = banco;
                //Excluir historicos do grupo cf
                val.lHistDel.ForEach(p =>
                    {
                        p.Cd_grupoCF = string.Empty;
                        TCN_CadHistorico.Gravar(p, qtb_grupocf.Banco_Dados);
                    });
                val.lHistorico.ForEach(p =>
                    {
                        p.Cd_grupoCF = string.Empty;
                        TCN_CadHistorico.Gravar(p, qtb_grupocf.Banco_Dados);
                    });
                //Gravar GrupoCf
                qtb_grupocf.Excluir(val);
                if (st_transacao)
                    qtb_grupocf.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch
            {
                val.St_registro = "C";
                return Gravar(val, null);
            }
            finally
            {
                if (st_transacao)
                    qtb_grupocf.deletarBanco_Dados();
            }
        }
    }
}
