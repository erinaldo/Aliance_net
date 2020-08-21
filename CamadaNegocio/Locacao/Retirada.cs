using CamadaDados.Locacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Locacao
{
    public class TCN_Retirada
    {
        public static TList_Retirada buscar(string Cd_empresa,
                                            string Id_retirada,
                                            string Cd_funcionario,
                                            string Dt_ini,
                                            string Dt_fin,
                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Cd_empresa))
                Estruturas.CriarParametro(ref vBusca, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Id_retirada))
                Estruturas.CriarParametro(ref vBusca, "a.id_retirada", Id_retirada);
            if (!string.IsNullOrWhiteSpace(Cd_funcionario))
                Estruturas.CriarParametro(ref vBusca, "a.cd_funcionario", "'" + Cd_funcionario.Trim() + "'");
            if (Dt_ini.IsDateTime())
                Estruturas.CriarParametro(ref vBusca, "convert(datetime, floor(convert(decimal(30,10), a.dt_retirada)))",
                    "'" + Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            if(Dt_fin.IsDateTime())
                Estruturas.CriarParametro(ref vBusca, "convert(datetime, floor(convert(decimal(30,10), a.dt_retirada)))",
                    "'" + Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            return new TCD_Retirada(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Retirada val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Retirada qtb_locacao = new TCD_Retirada();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Gravar Caixa
                object obj = new CamadaDados.Diversos.TCD_CfgEmpresa(qtb_locacao.Banco_Dados).BuscarEscalar(
                    new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + val.Cd_empresa.Trim() + "'" } }, "a.cd_historico");
                if (obj == null)
                    throw new Exception("Obrigatório configurar historico <Parametros-Diversos-Configuração Parâmetros Empresa>.");
                string ret = Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(
                    new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa
                    {
                        Cd_ContaGer = val.Cd_contager,
                        Cd_Empresa = val.Cd_empresa,
                        Nr_Docto = "RETIRADA",
                        Cd_Historico = obj.ToString(),
                        Login = Parametros.pubLogin,
                        ComplHistorico = val.Obs.Trim(),
                        Dt_lancto = val.Dt_Retirada,
                        Vl_PAGAR = decimal.Zero,
                        Vl_RECEBER = val.Vl_retirada,
                        St_Titulo = "N",
                        St_Estorno = "N",
                        St_avulso = "N"
                    }, qtb_locacao.Banco_Dados);
                val.Cd_lanctocaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_CD_LANCTOCAIXA"));
                qtb_locacao.Gravar(val);
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Retirada val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Retirada qtb_loc = new TCD_Retirada();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Estornar lancamento caixa
                Financeiro.Caixa.TCN_LanCaixa.EstornarSomenteCaixa(
                    Financeiro.Caixa.TCN_LanCaixa.Busca(val.Cd_contager,
                                                        val.Cd_lanctocaixastr,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        decimal.Zero,
                                                        decimal.Zero,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        false,
                                                        string.Empty,
                                                        decimal.Zero,
                                                        false,
                                                        qtb_loc.Banco_Dados)[0], qtb_loc.Banco_Dados);
                qtb_loc.Excluir(val);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }
    }
}
