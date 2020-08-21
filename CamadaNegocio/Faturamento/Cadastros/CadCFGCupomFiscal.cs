using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    public class TCN_CFGCupomFiscal
    {
        public static TList_CFGCupomFiscal Buscar(string Cd_empresa,
                                                  BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            return new TCD_CFGCupomFiscal(banco).Select(filtro, 0, string.Empty);
        }

        public static string BuscarAliquotaICMS(CamadaDados.Faturamento.NotaFiscal.TList_ImpostosNF lImp, BancoDados.TObjetoBanco banco)
        {
            if(lImp.Exists(p=> p.Imposto.St_ICMS))
                if (lImp.Find(p=> p.Imposto.St_ICMS).Pc_aliquota > decimal.Zero)
                    return lImp.Find(p=> p.Imposto.St_ICMS).Pc_aliquota.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                else if (lImp.Find(p=> p.Imposto.St_ICMS).St_substtrib)
                    return "FF";
                else
                {
                    //Buscar situacao tributaria
                    CamadaDados.Fiscal.TList_CadSitTribut lSt =
                        Fiscal.TCN_CadSitTribut.Busca(lImp.Find(p=> p.Imposto.St_ICMS).Cd_st,
                                                                    string.Empty,
                                                                    lImp.Find(p=> p.Imposto.St_ICMS).Cd_impostostr,                                                                    banco);
                    if (lSt.Count > 0)
                        if (lSt[0].Tp_situacao.Trim().ToUpper().Equals("2"))
                            return "II";
                        else if (lSt[0].Tp_situacao.Trim().ToUpper().Equals("3"))
                            return "NN";
                        else return string.Empty;
                    else
                        return string.Empty;
                }
            else
                return string.Empty;
        }

        public static string Gravar(TRegistro_CFGCupomFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCupomFiscal qtb_cfg = new TCD_CFGCupomFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Gravar(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Cd_empresa;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar config.:" + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CFGCupomFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CFGCupomFiscal qtb_cfg = new TCD_CFGCupomFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cfg.CriarBanco_Dados(true);
                else
                    qtb_cfg.Banco_Dados = banco;
                qtb_cfg.Excluir(val);
                if (st_transacao)
                    qtb_cfg.Banco_Dados.Commit_Tran();
                return val.Cd_empresa;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cfg.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir config.:" + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cfg.deletarBanco_Dados();
            }
        }
    }
}
